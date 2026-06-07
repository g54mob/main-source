using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Cylindrify", Description = "Blends mesh into a cylinder", XRotation = -90f, Type = typeof(CylindrifyDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/CylindrifyDeformer")]
	public class CylindrifyDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct CylindrifyJob : IJobParallelFor
		{
			public float factor;

			public float radius;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float2 end = math.normalize(b.xy) * radius;
				b.xy = math.lerp(b.xy, end, factor);
				vertices[index] = math.mul(axisToMesh, b).xyz;
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
			return new CylindrifyJob
			{
				factor = Factor,
				radius = Radius,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
