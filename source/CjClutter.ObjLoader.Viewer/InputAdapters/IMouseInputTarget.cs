using OpenTK;

namespace CjClutter.ObjLoader.Viewer.InputAdapters
{
    using OpenTK.Input;

    public interface IMouseInputTarget
    {
        void OnMouseMove(Vector2d position);
        void OnMouseWheel(MouseWheelEventArgs e);
        void OnLeftMouseButtonDown(Vector2d position);
        void OnLeftMouseButtonUp(Vector2d position);
        void OnMouseDrag(MouseDragEventArgs mouseDragEventArgs);
        void OnMouseDragEnd(MouseDragEventArgs mouseDragEventArgs);
    }
}