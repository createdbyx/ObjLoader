using System;
using ObjLoader.Loader.Common;
using ObjLoader.Loader.Data;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.TypeParsers.Interfaces;

namespace ObjLoader.Loader.TypeParsers
{
    public class FaceParser : TypeParserBase, IFaceParser
    {
        private readonly IFaceGroup _faceGroup;

        public FaceParser(IFaceGroup faceGroup)
        {
            _faceGroup = faceGroup;
        }

        protected override string Keyword
        {
            get { return "f"; }
        }

        public override void Parse(string line)
        {
            var vertices = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var face = new Face();

            var i = 0;
            var count = 0;
            var wrapped = false;
            while (i <= vertices.Length)
            {
                string vertexString;
                FaceVertex faceVertex;
                //if (count == 2 && i == vertices.Length)
                //{
                //    vertexString = vertices[0];
                //    faceVertex = this.ParseFaceVertex(vertexString);
                //    face.AddVertex(faceVertex); 
                //    break;
                //}

                if (count == 3)
                {
                    _faceGroup.AddFace(face);
                    face = new Face();
                    count = 0;
                    i--;
                    if (wrapped)
                    {
                        return;
                    }
                }

                vertexString = vertices[i];
                faceVertex = this.ParseFaceVertex(vertexString);
                face.AddVertex(faceVertex);
                var index = i;
                i = (i + 1) % vertices.Length;
                if (i - index < 0)
                {
                    wrapped = true;
                }
                count++;
            }

            _faceGroup.AddFace(face);
        }

        private FaceVertex ParseFaceVertex(string vertexString)
        {
            var fields = vertexString.Split(new[] { '/' }, StringSplitOptions.None);

            var vertexIndex = fields[0].ParseInvariantInt();
            var faceVertex = new FaceVertex(vertexIndex, 0, 0);

            if (fields.Length > 1)
            {
                var textureIndex = fields[1].Length == 0 ? 0 : fields[1].ParseInvariantInt();
                faceVertex.TextureIndex = textureIndex;
            }

            if (fields.Length > 2)
            {
                var normalIndex = fields.Length > 2 && fields[2].Length == 0 ? 0 : fields[2].ParseInvariantInt();
                faceVertex.NormalIndex = normalIndex;
            }

            return faceVertex;
        }
    }
}