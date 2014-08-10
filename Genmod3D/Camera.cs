using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genmod3D
{
    public class Camera
    {
        public Vector2 Angle;
        public Vector3 Position;
        public Matrix Projection;
        public Matrix View;
        public Matrix Orientation;
        public float Distance;

        public void Update()
        {
            Orientation = Matrix.RotationY(Angle.X);
            Orientation *= Matrix.RotationAxis(Orientation.Left, Angle.Y);

            View = Matrix.LookAtLH(Position + Orientation.Backward * Distance, Position + Orientation.Forward, Orientation.Up);
        }
    }
}
