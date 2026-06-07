using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform.Masking
{
	[Deformer(Name = "Sphere Mask", Description = "Masks deformation in a sphere", Type = typeof(SphereMask), Category = Category.Mask)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/SphereMask")]
	public class SphereMask : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct SphereMaskJob : IJobParallelFor
		{
			public float factor;

			public float innerRadius;

			public float outerRadius;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			public void Execute(int index)
			{
				float3 float5 = currentVertices[index];
				float num = math.length(math.mul(meshToAxis, math.float4(float5, 1f)).xyz);
				float num2 = 0f;
				num2 = ((num > outerRadius) ? 0f : ((!(num < innerRadius)) ? math.unlerp(outerRadius, innerRadius, num) : 1f));
				num2 *= factor;
				currentVertices[index] = math.lerp(float5, maskVertices[index], math.saturate(num2));
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct InvertedSphereMaskJob : IJobParallelFor
		{
			public float factor;

			public float innerRadius;

			public float outerRadius;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			public void Execute(int index)
			{
				float3 float5 = currentVertices[index];
				float num = math.length(math.mul(meshToAxis, math.float4(float5, 1f)).xyz);
				float num2 = 0f;
				num2 = ((num < innerRadius) ? 0f : ((!(num > outerRadius)) ? math.unlerp(innerRadius, outerRadius, num) : 1f));
				num2 *= factor;
				currentVertices[index] = math.lerp(float5, maskVertices[index], math.saturate(num2));
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
		private float innerRadius = 0.5f;

		[SerializeField]
		[HideInInspector]
		private float outerRadius = 1f;

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
				factor = Mathf.Clamp(value, 0f, 1f);
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
				falloff = Mathf.Max(0f, value);
			}
		}

		public float InnerRadius
		{
			get
			{
				return innerRadius;
			}
			set
			{
				innerRadius = Mathf.Min(value, OuterRadius);
			}
		}

		public float OuterRadius
		{
			get
			{
				return outerRadius;
			}
			set
			{
				outerRadius = Mathf.Max(value, InnerRadius);
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
			if (Mathf.Approximately(OuterRadius, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			if (!Invert)
			{
				return new SphereMaskJob
				{
					factor = Factor,
					innerRadius = InnerRadius * 0.5f,
					outerRadius = OuterRadius * 0.5f,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					currentVertices = data.DynamicNative.VertexBuffer,
					maskVertices = data.DynamicNative.MaskVertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new InvertedSphereMaskJob
			{
				factor = Factor,
				innerRadius = InnerRadius * 0.5f,
				outerRadius = OuterRadius * 0.5f,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				currentVertices = data.DynamicNative.VertexBuffer,
				maskVertices = data.DynamicNative.MaskVertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
