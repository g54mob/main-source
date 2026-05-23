using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Deform
{
	[Deformer(Name = "Bend", Description = "Bends a mesh", Type = typeof(BendDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/BendDeformer")]
	public class BendDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedBendJob : IJobParallelFor
		{
			public float angle;

			public float top;

			public float bottom;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = math.radians(angle) * (1f / (top - bottom));
				float num2 = 1f / num;
				float num3 = b.y * num;
				float num4 = math.cos(MathF.PI - num3);
				float num5 = math.sin(MathF.PI - num3);
				b.xy = math.float2(num2 * num4 + num2 - b.x * num4, num2 * num5 - b.x * num5);
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct BendJob : IJobParallelFor
		{
			public float angle;

			public float top;

			public float bottom;

			public bool limitTop;

			public bool limitBottom;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 float5 = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float4 float6 = float5;
				float num = math.radians(angle);
				float num2 = 1f / (num * (1f / (top - bottom)));
				float num3 = float5.y;
				if (limitTop)
				{
					num3 = math.min(top, num3);
				}
				if (limitBottom)
				{
					num3 = math.max(bottom, num3);
				}
				float num4 = (num3 - bottom) / (top - bottom) * num;
				float num5 = math.cos(MathF.PI - num4);
				float num6 = math.sin(MathF.PI - num4);
				float5.xy = math.float2(num2 * num5 + num2 - float5.x * num5, num2 * num6 - float5.x * num6);
				if (limitTop && float6.y > top)
				{
					float5.y += (0f - num5) * (float6.y - top);
					float5.x += num6 * (float6.y - top);
				}
				else if (limitBottom && float6.y < bottom)
				{
					float5.y += (0f - num5) * (float6.y - bottom);
					float5.x += num6 * (float6.y - bottom);
				}
				float5.y += bottom;
				vertices[index] = math.mul(axisToMesh, float5).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float angle;

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

		[SerializeField]
		[HideInInspector]
		private float top = 1f;

		[FormerlySerializedAs("mode")]
		[SerializeField]
		[HideInInspector]
		private BoundsMode topMode = BoundsMode.Limited;

		[SerializeField]
		[HideInInspector]
		private float bottom;

		[FormerlySerializedAs("mode")]
		[SerializeField]
		[HideInInspector]
		private BoundsMode bottomMode = BoundsMode.Limited;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		[HideInInspector]
		public float minValidBendAngle = 0.001f;

		public float Angle
		{
			get
			{
				return angle;
			}
			set
			{
				angle = value;
			}
		}

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

		public BoundsMode BottomMode
		{
			get
			{
				return bottomMode;
			}
			set
			{
				bottomMode = value;
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

		public BoundsMode TopMode
		{
			get
			{
				return topMode;
			}
			set
			{
				topMode = value;
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
			float f = Angle * Factor;
			if (Mathf.Abs(f) < minValidBendAngle || Mathf.Approximately(Top, Bottom))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new BendJob
			{
				angle = f,
				top = Top,
				limitTop = (TopMode == BoundsMode.Limited),
				bottom = Bottom,
				limitBottom = (BottomMode == BoundsMode.Limited),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
