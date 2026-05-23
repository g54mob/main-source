using Beans.Unity.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[Deformer(Name = "Lathe Displace", Description = "Moves vertices away from axis based on distance along curve", Type = typeof(LatheDisplaceDeformer), XRotation = -90f)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/LatheDisplaceDeformer")]
	public class LatheDisplaceDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct LatheDisplaceJob : IJobParallelFor
		{
			public float factor;

			public float bias;

			public float offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeCurve curve;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				b.xy *= bias + curve.Evaluate(b.z + offset) * factor;
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

		[SerializeField]
		[HideInInspector]
		private float bias;

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

		public float Bias
		{
			get
			{
				return bias;
			}
			set
			{
				bias = value;
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
			JobHandle jobHandle = new LatheDisplaceJob
			{
				factor = Factor,
				bias = Bias,
				offset = Offset,
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
