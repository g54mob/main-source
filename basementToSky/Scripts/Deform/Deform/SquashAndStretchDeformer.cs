using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Squash and Stretch", Description = "Squashes and stretches a mesh", XRotation = -90f, Type = typeof(SquashAndStretchDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/SquashAndStretchDeformer")]
	public class SquashAndStretchDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct SquashAndStretchJob : IJobParallelFor
		{
			public float factor;

			public float curvature;

			public float top;

			public float bottom;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float num = math.abs(top - bottom);
				float num2 = 1f / num;
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num3 = 0f;
				num3 = ((b.z > top) ? (num * num2) : ((!(b.z < bottom)) ? ((b.z - bottom) * num2) : ((bottom - bottom) * num2)));
				float num4 = 0f;
				float num5 = 0f;
				if (factor > 0f)
				{
					num4 = 1f / (curvature * factor + 1f);
					num5 = factor + 1f;
				}
				else
				{
					num4 = curvature * (0f - factor) + 1f;
					num5 = -1f / (factor - 1f);
				}
				float num6 = 4f * (1f - num4);
				num4 = (num6 * num3 - num6) * num3 + 1f;
				b.xy *= num4;
				if (b.z < bottom)
				{
					b.z += (num5 - 1f) * bottom;
				}
				else if (b.z <= top)
				{
					b.z *= num5;
				}
				else if (b.z > top)
				{
					b.z += (num5 - 1f) * top;
				}
				else
				{
					b.z *= num5;
				}
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float curvature = 1f;

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

		public float Curvature
		{
			get
			{
				return curvature;
			}
			set
			{
				curvature = Mathf.Clamp01(value);
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
				top = Mathf.Max(value, Bottom);
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
				bottom = Mathf.Min(value, Top);
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
			if (Factor == 0f || Top == Bottom)
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new SquashAndStretchJob
			{
				factor = Factor,
				curvature = ((Curvature >= 0f) ? (Curvature + 1f) : (1f / (0f - Curvature + 1f))),
				top = Top,
				bottom = Bottom,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
