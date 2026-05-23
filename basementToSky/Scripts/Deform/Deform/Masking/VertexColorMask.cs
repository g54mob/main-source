using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform.Masking
{
	[Deformer(Name = "Vertex Color Mask", Description = "Masks vertices based on their color", Type = typeof(VertexColorMask), Category = Category.Mask)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/VertexColorMask")]
	public class VertexColorMask : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct VertexColorJob : IJobParallelFor
		{
			public float factor;

			public float falloff;

			public int channel;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			[ReadOnly]
			public NativeArray<float4> colors;

			public void Execute(int index)
			{
				float num = colors[index][channel];
				num = math.exp((0f - falloff) * num) * factor;
				currentVertices[index] = math.lerp(currentVertices[index], maskVertices[index], math.saturate(num));
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct InvertedVertexColorJob : IJobParallelFor
		{
			public float factor;

			public float falloff;

			public int channel;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			[ReadOnly]
			public NativeArray<float4> colors;

			public void Execute(int index)
			{
				float num = colors[index][channel];
				num = 1f - math.exp((0f - falloff) * num) * factor;
				currentVertices[index] = math.lerp(currentVertices[index], maskVertices[index], math.saturate(num));
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float falloff = 1f;

		[SerializeField]
		[HideInInspector]
		private bool invert;

		[SerializeField]
		[HideInInspector]
		private ColorChannel channel;

		public float Factor
		{
			get
			{
				return factor;
			}
			set
			{
				factor = value;
			}
		}

		public float Falloff
		{
			get
			{
				return falloff;
			}
			set
			{
				falloff = value;
			}
		}

		public bool Invert
		{
			get
			{
				return invert;
			}
			set
			{
				invert = value;
			}
		}

		public ColorChannel Channel
		{
			get
			{
				return channel;
			}
			set
			{
				channel = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (Invert)
			{
				return new VertexColorJob
				{
					factor = Factor,
					falloff = Falloff,
					channel = (int)Channel,
					currentVertices = data.DynamicNative.VertexBuffer,
					maskVertices = data.DynamicNative.MaskVertexBuffer,
					colors = data.DynamicNative.ColorBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new InvertedVertexColorJob
			{
				factor = Factor,
				falloff = Falloff,
				channel = (int)Channel,
				currentVertices = data.DynamicNative.VertexBuffer,
				maskVertices = data.DynamicNative.MaskVertexBuffer,
				colors = data.DynamicNative.ColorBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
