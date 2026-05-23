using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform.Masking
{
	[Deformer(Name = "Vertical Gradient Mask", Description = "Mask vertices based on distance along an axis", Type = typeof(VerticalGradientMask), Category = Category.Mask, XRotation = -90f)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/VerticalGradientMask")]
	public class VerticalGradientMask : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct VerticalGradientJob : IJobParallelFor
		{
			public float factor;

			public float falloff;

			public float4x4 meshToAxis;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			public void Execute(int index)
			{
				float3 float5 = currentVertices[index];
				float3 xyz = math.mul(meshToAxis, math.float4(float5, 1f)).xyz;
				float t = math.saturate(math.exp((0f - falloff) * xyz.z) * factor);
				currentVertices[index] = math.lerp(float5, maskVertices[index], t);
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct InvertedVerticalGradientJob : IJobParallelFor
		{
			public float factor;

			public float falloff;

			public float4x4 meshToAxis;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			public void Execute(int index)
			{
				float3 float5 = currentVertices[index];
				float3 xyz = math.mul(meshToAxis, math.float4(float5, 1f)).xyz;
				float t = math.saturate(1f - math.exp((0f - falloff) * xyz.z) * factor);
				currentVertices[index] = math.lerp(float5, maskVertices[index], t);
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float falloff = 10f;

		[SerializeField]
		[HideInInspector]
		private bool invert;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		public float Factor
		{
			get
			{
				return factor;
			}
			set
			{
				factor = Mathf.Clamp(value, -1f, 1f);
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

		public Transform Axis
		{
			get
			{
				if (axis == null)
				{
					axis = base.transform;
				}
				return axis;
			}
			set
			{
				axis = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (!invert)
			{
				return new VerticalGradientJob
				{
					factor = Factor,
					falloff = Falloff,
					meshToAxis = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform()),
					currentVertices = data.DynamicNative.VertexBuffer,
					maskVertices = data.DynamicNative.MaskVertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new InvertedVerticalGradientJob
			{
				factor = Factor,
				falloff = Falloff,
				meshToAxis = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform()),
				currentVertices = data.DynamicNative.VertexBuffer,
				maskVertices = data.DynamicNative.MaskVertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
