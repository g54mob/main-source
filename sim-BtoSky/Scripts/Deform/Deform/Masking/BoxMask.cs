using Beans.Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform.Masking
{
	[Deformer(Name = "Box Mask", Description = "Masks deformation in a box", Type = typeof(BoxMask), Category = Category.Mask)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/BoxMask")]
	public class BoxMask : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct CubeMaskJob : IJobParallelFor
		{
			public float factor;

			public bounds innerBounds;

			public bounds outerBounds;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			public void Execute(int index)
			{
				float3 float5 = currentVertices[index];
				float3 xyz = math.mul(meshToAxis, math.float4(float5, 1f)).xyz;
				float num = 0f;
				if (innerBounds.contains(xyz))
				{
					num = 1f;
				}
				else
				{
					float3 x = innerBounds.closestsurfacepoint(xyz);
					float3 y = outerBounds.closestsurfacepoint(xyz);
					num = 1f - math.distance(x, xyz) / math.distance(x, y);
				}
				num *= factor;
				currentVertices[index] = math.lerp(float5, maskVertices[index], math.saturate(num));
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct InvertedCubeMaskJob : IJobParallelFor
		{
			public float factor;

			public bounds innerBounds;

			public bounds outerBounds;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> maskVertices;

			public void Execute(int index)
			{
				float3 float5 = currentVertices[index];
				float3 xyz = math.mul(meshToAxis, math.float4(float5, 1f)).xyz;
				float num = 0f;
				if (innerBounds.contains(xyz))
				{
					num = 0f;
				}
				else
				{
					float3 x = innerBounds.closestsurfacepoint(xyz);
					float3 y = outerBounds.closestsurfacepoint(xyz);
					num = math.distance(x, xyz) / math.distance(x, y);
				}
				num *= factor;
				currentVertices[index] = math.lerp(float5, maskVertices[index], math.saturate(num));
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private Bounds innerBounds = new Bounds(Vector3.zero, Vector3.one * 0.5f);

		[SerializeField]
		[HideInInspector]
		private Bounds outerBounds = new Bounds(Vector3.zero, Vector3.one);

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

		public Bounds InnerBounds
		{
			get
			{
				return innerBounds;
			}
			set
			{
				innerBounds = value;
			}
		}

		public Bounds OuterBounds
		{
			get
			{
				return outerBounds;
			}
			set
			{
				outerBounds = value;
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
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			if (!invert)
			{
				return new CubeMaskJob
				{
					factor = Factor,
					innerBounds = InnerBounds,
					outerBounds = OuterBounds,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					currentVertices = data.DynamicNative.VertexBuffer,
					maskVertices = data.DynamicNative.MaskVertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new InvertedCubeMaskJob
			{
				factor = Factor,
				innerBounds = InnerBounds,
				outerBounds = OuterBounds,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				currentVertices = data.DynamicNative.VertexBuffer,
				maskVertices = data.DynamicNative.MaskVertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
