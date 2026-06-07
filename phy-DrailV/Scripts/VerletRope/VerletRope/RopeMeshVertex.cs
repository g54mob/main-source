using Unity.Mathematics;
using UnityEngine.Rendering;

namespace VerletRope
{
	public readonly struct RopeMeshVertex
	{
		public static readonly VertexAttributeDescriptor[] Layout = new VertexAttributeDescriptor[4]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal),
			new VertexAttributeDescriptor(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2)
		};

		public readonly float3 position;

		public readonly float3 normal;

		public readonly float4 tangent;

		public readonly float2 uv;

		public RopeMeshVertex(float3 position, float3 normal, float4 tangent, float2 uv)
		{
			this.position = position;
			this.normal = normal;
			this.tangent = tangent;
			this.uv = uv;
		}
	}
}
