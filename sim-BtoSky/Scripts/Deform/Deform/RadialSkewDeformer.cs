using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Radial Skew (WIP)", Description = "Skews vertices away from axis", Type = typeof(RadialSkewDeformer), Category = Category.WIP)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/RadialSkewDeformer")]
	public class RadialSkewDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedRadialSkewJob : IJobParallelFor
		{
			public float factor;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				b.xz += b.y * factor * math.normalize(b.xz);
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LimitedRadialSkewJob : IJobParallelFor
		{
			public float factor;

			public float top;

			public float bottom;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = math.clamp(b.y, bottom, top);
				b.xz += num * factor * math.normalize(b.xz);
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private BoundsMode mode;

		[SerializeField]
		[HideInInspector]
		private float top = 0.5f;

		[SerializeField]
		[HideInInspector]
		private float bottom = -0.5f;

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
				factor = value;
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

		public float Top
		{
			get
			{
				return top;
			}
			set
			{
				top = Mathf.Max(value, bottom);
			}
		}

		public float Bottom
		{
			get
			{
				return bottom;
			}
			set
			{
				bottom = Mathf.Min(value, top);
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
			if (Mathf.Approximately(Factor, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			if (Mode != BoundsMode.Limited)
			{
				return new UnlimitedRadialSkewJob
				{
					factor = Factor,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new LimitedRadialSkewJob
			{
				factor = Factor,
				top = top,
				bottom = bottom,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
