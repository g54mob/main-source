using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Taper", Description = "Tapers a mesh", XRotation = -90f, Type = typeof(TaperDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/TaperDeformer")]
	public class TaperDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct TaperJob : IJobParallelFor
		{
			public float top;

			public float bottom;

			public float2 topFactor;

			public float2 bottomFactor;

			public float curvature;

			public bool smooth;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				if (bottom == top)
				{
					if (b.z > top)
					{
						b.xy *= topFactor;
					}
					else
					{
						b.xy *= bottomFactor;
					}
				}
				else
				{
					float num = (math.clamp(b.z, bottom, top) - bottom) / (top - bottom);
					if (smooth)
					{
						num = math.smoothstep(0f, 1f, num);
					}
					float num2 = (num - 0.5f) * 2f;
					float2 float5 = math.lerp(bottomFactor, topFactor, num);
					float num3 = num2 * num2 * curvature - curvature + 1f;
					b.xy *= float5 * num3;
				}
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float top = 0.5f;

		[SerializeField]
		[HideInInspector]
		private float bottom = -0.5f;

		[SerializeField]
		[HideInInspector]
		private Vector2 topFactor = Vector2.one;

		[SerializeField]
		[HideInInspector]
		private Vector2 bottomFactor = Vector2.one;

		[SerializeField]
		[HideInInspector]
		private float curvature;

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
				return Vector2.Max(TopFactor, BottomFactor).magnitude;
			}
			set
			{
				Vector2 vector = (BottomFactor = Vector2.one * value);
				TopFactor = vector;
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

		public Vector2 TopFactor
		{
			get
			{
				return topFactor;
			}
			set
			{
				topFactor = value;
			}
		}

		public Vector2 BottomFactor
		{
			get
			{
				return bottomFactor;
			}
			set
			{
				bottomFactor = value;
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
				curvature = value;
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
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new TaperJob
			{
				top = Top,
				bottom = Bottom,
				topFactor = TopFactor * new Vector2(Axis.lossyScale.x, Axis.lossyScale.y),
				bottomFactor = BottomFactor * new Vector2(Axis.lossyScale.x, Axis.lossyScale.y),
				curvature = Curvature,
				smooth = Smooth,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
