using Beans.Unity.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[Deformer(Name = "Radial Curve", Description = "Moves vertices up based on distance from point along a curve (similar to ripple)", Type = typeof(RadialCurveDeformer), XRotation = -90f)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/RadialCurveDeformer")]
	public class RadialCurveDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct RadialCurveJob : IJobParallelFor
		{
			public float factor;

			public float offset;

			public float falloff;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeCurve curve;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = math.length(b.xy);
				b.z += curve.Evaluate(num + offset) * factor * (1f / math.pow(num + 1f, falloff * 2f));
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

		[SerializeField]
		[HideInInspector]
		private float offset;

		[SerializeField]
		[HideInInspector]
		private float falloff;

		[SerializeField]
		[HideInInspector]
		private AnimationCurve curve;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		private JobHandle combinedHandle;

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

		public float Offset
		{
			get
			{
				return offset;
			}
			set
			{
				offset = value;
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
				falloff = Mathf.Max(0f, falloff);
			}
		}

		public AnimationCurve Curve
		{
			get
			{
				return curve;
			}
			set
			{
				curve = value;
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
			if (curve == null || curve.length == 0)
			{
				return dependency;
			}
			NativeCurve nativeCurve = new NativeCurve(curve, 32, Allocator.TempJob);
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			JobHandle jobHandle = new RadialCurveJob
			{
				factor = Factor,
				offset = Offset,
				falloff = Falloff,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				curve = nativeCurve,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 128, dependency);
			combinedHandle = JobHandle.CombineDependencies(combinedHandle, jobHandle);
			return jobHandle;
		}
	}
}
