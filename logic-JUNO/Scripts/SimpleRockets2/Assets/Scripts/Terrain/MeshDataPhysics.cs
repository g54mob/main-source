using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Assets.Scripts.Terrain
{
	public class MeshDataPhysics
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct PhysicsVertex
		{
			[FieldOffset(0)]
			public float3 Position;
		}

		public PhysicsVertex[] Vertices;

		public MeshDataPhysics(int vertexCount)
		{
			Vertices = new PhysicsVertex[vertexCount];
		}
	}
}
