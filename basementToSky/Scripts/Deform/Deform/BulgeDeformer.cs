using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Bulge", Description = "Bulges a mesh", Type = typeof(BulgeDeformer), XRotation = -90f)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/BulgeDeformer")]
	public class BulgeDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct BulgeJob : IJobParallelFor
		{
			public float factor;

			public float top;

			public float bottom;

			public bool smooth;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = (math.clamp(b.z, bottom, top) - bottom) / (top - bottom);
				if (smooth)
				{
					num = math.smoothstep(0f, 1f, num);
				}
				float num2 = (num - 0.5f) * 2f;
				b.xy *= num2 * num2 * (0f - factor) + factor + 1f;
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float top = 0.5f;

		[SerializeField]
		[HideInInspector]
		private float bottom = -0.5f;

		[SerializeField]
		[HideInInspector]
		private bool smooth = true;

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
			if (Mathf.Approximately(top, bottom) || Mathf.Approximately(Factor, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new BulgeJob
			{
				factor = Factor,
				top = Top,
				bottom = Bottom,
				smooth = Smooth,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
