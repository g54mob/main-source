using Unity.Mathematics;
using UnityEngine.Rendering;

namespace Digger.Modules.Core.Sources
{
	public struct VertexData
	{
		public float3 Vertex;

		public float3 Normal;

		public float4 Color;

		public float2 UV;

		public float4 SplatControl0;

		public float4 SplatControl1;

		public float4 SplatControl2;

		public float4 SplatControl3;

		public float4 SplatControl4;

		public static readonly VertexAttributeDescriptor[] Layout = new VertexAttributeDescriptor[9]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal),
			new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord3, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord4, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord5, VertexAttributeFormat.Float32, 4)
		};
	}
}
