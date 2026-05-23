using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Spherify", Description = "Morphs vertices onto a sphere", Type = typeof(SpherifyDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/SpherifyDeformer")]
	public class SpherifyDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedSpherifyJob : IJobParallelFor
		{
			public float factor;

			public float radius;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				float3 end = math.normalize(xyz) * radius;
				xyz = math.lerp(xyz, end, factor);
				vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LimitedSpherifyJob : IJobParallelFor
		{
			public float factor;

			public float radius;

			public bool smooth;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 float5 = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				float num = math.length(float5);
				if (num == 0f)
				{
					return;
				}
				float num2 = num / radius;
				if (num2 < 1f)
				{
					float num3 = factor;
					if (smooth)
					{
						num3 *= 1f - math.smoothstep(0f, 1f, num2);
					}
					float5 = math.lerp(float5, math.normalize(float5) * radius, num3);
				}
				vertices[index] = math.mul(axisToMesh, math.float4(float5, 1f)).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float radius = 1f;

		[SerializeField]
		[HideInInspector]
		private BoundsMode mode;

		[SerializeField]
		[HideInInspector]
		private bool smooth;

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
				factor = Mathf.Clamp01(value);
			}
		}

		public float Radius
		{
			get
			{
				return radius;
			}
			set
			{
				radius = value;
			}
		}

		public BoundsMode Mode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
			}
		}

		public bool Smooth
		{
			get
			{
				return smooth;
			}
			set
			{
				smooth = value;
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
			if (Mathf.Approximately(Factor, 0f) || Mathf.Approximately(Radius, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			BoundsMode boundsMode = Mode;
			if (boundsMode == BoundsMode.Unlimited || boundsMode != BoundsMode.Limited)
			{
				return new UnlimitedSpherifyJob
				{
					factor = Factor,
					radius = Radius,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new LimitedSpherifyJob
			{
				factor = Factor,
				radius = Radius,
				smooth = Smooth,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
