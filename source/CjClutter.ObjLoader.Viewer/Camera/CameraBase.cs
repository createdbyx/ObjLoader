using System;
using OpenTK;

namespace CjClutter.ObjLoader.Viewer.Camera
{
    public class CameraBase
    {
        private Vector3d position;

        private Vector3d target;

        private Vector3d up;

        public event Action CameraChanged;

        protected void FireCameraChanged()
        {
            if (CameraChanged != null)
            {
                CameraChanged();
            }
        }

        public Vector3d Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                this.FireCameraChanged();
            }
        }

        public Vector3d Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
                this.FireCameraChanged();
            }
        }

        public Vector3d Up
        {
            get
            {
                return this.up;
            }
            set
            {
                this.up = value;
                this.FireCameraChanged();
            }
        }
    }
}