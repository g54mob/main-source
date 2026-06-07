using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.MeshGen
{
	public struct Vertex
	{
		public static readonly NativeArray<VertexAttributeDescriptor> SimpleMeshVertexLayout = new NativeArray<VertexAttributeDescriptor>(new VertexAttributeDescriptor[2]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal)
		}, Allocator.Domain);

		public float3 position;

		public float3 normal;

		public Vertex(float3 position)
		{
			this.position = position;
			normal = default(float3);
		}

		public Vertex(float3 position, float3 normal)
		{
			this.position = position;
			this.normal = normal;
		}

		public static implicit operator Vertex(float3 pos)
		{
			return new Vertex(pos);
		}

		public static VertexAttributeDescriptor[] GetDescription()
		{
			return new VertexAttributeDescriptor[2]
			{
				new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
				new VertexAttributeDescriptor(VertexAttribute.Normal)
			};
		}

		public static int OffsetOfNormal()
		{
			return 0;
		}
	}
}
