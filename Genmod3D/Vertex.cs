using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genmod3D
{
    public struct Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 UV;

        public Vertex(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
            Normal = Vector3.Zero;
            UV = Vector2.Zero;
        }

        public Vertex(Vector3 position, Vector3 normal, Vector2 uv)
        {
            Position = position;
            Normal = normal;
            UV = uv;
        }

        private static VertexDeclaration vdecl;

        public const int VertexSize = sizeof(float) * (3 + 3 + 2);

        public static VertexDeclaration GetDeclaration(Device device)
        {
            return vdecl ?? (vdecl = new VertexDeclaration(device, new VertexElement[]{
                new VertexElement(0,0,DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                new VertexElement(0,sizeof(float)*3, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Normal, 0),
                new VertexElement(0,sizeof(float)*6, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 0),
                VertexElement.VertexDeclarationEnd
            }));
        }
    }
}
