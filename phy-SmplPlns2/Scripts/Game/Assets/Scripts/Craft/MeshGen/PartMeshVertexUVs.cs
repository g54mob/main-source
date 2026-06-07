using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.MeshGen
{
	public struct PartMeshVertexUVs
	{
		public static readonly NativeArray<VertexAttributeDescriptor> PartMeshVertexLayout = new NativeArray<VertexAttributeDescriptor>(new VertexAttributeDescriptor[4]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2, 1),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.Float32, 3, 1)
		}, Allocator.Domain);

		public float2 uv0;

		public float3 uv1;

		public PartMeshVertexUVs(float2 uv0, float3 uv1)
		{
			this.uv0 = uv0;
			this.uv1 = uv1;
		}

		public PartMeshVertexUVs(float3 uv1)
		{
			uv0 = default(float2);
			this.uv1 = uv1;
		}
	}
}
