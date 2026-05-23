using Beans.Unity.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[Deformer(Name = "Curve Displace", Description = "Pushes vertices in a direction based on distance along a curve", Type = typeof(CurveDisplaceDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/CurveDisplaceDeformer")]
	public class CurveDisplaceDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct CurveDisplaceJob : IJobParallelFor
		{
			public float factor;

			public float offset;

			public float firstKeyTime;

			public float lastKeyTime;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeCurve curve;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float t = b.z + offset;
				float num = curve.Evaluate(t);
				b.y += num * factor;
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
			JobHandle jobHandle = new CurveDisplaceJob
			{
				factor = Factor,
				offset = Offset,
				firstKeyTime = Curve[0].time,
				lastKeyTime = Curve[Curve.length - 1].time,
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
