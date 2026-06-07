using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Twist", Description = "Rotates vertices around an axis based on distance along that axis", XRotation = -90f, Type = typeof(TwistDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/TwistDeformer")]
	public class TwistDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedTwistJob : IJobParallelFor
		{
			public float startAngle;

			public float endAngle;

			public float top;

			public float bottom;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float num = math.abs(top - bottom);
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num2 = (b.z - bottom) / num * (endAngle - startAngle);
				float x = math.radians(startAngle + num2) + MathF.PI;
				b.xy = math.float2((0f - b.x) * math.cos(x) - b.y * math.sin(x), b.x * math.sin(x) - b.y * math.cos(x));
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LimitedTwistJob : IJobParallelFor
		{
			public float startAngle;

			public float endAngle;

			public float top;

			public float bottom;

			public bool smooth;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float num = math.abs(top - bottom);
				float num2 = endAngle - startAngle;
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num3 = 0f;
				num3 = ((!smooth) ? math.lerp(startAngle, endAngle, (math.clamp(b.z, bottom, top) - bottom) / num) : (startAngle + math.smoothstep(bottom, top, math.clamp(b.z, bottom, top)) * num2));
				float x = math.radians(num3) + MathF.PI;
				b.xy = math.float2((0f - b.x) * math.cos(x) - b.y * math.sin(x), b.x * math.sin(x) - b.y * math.cos(x));
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float startAngle;

		[SerializeField]
		[HideInInspector]
		private float endAngle;

		[SerializeField]
		[HideInInspector]
		private float offset;

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

		[SerializeField]
		[HideInInspector]
		private BoundsMode mode = BoundsMode.Limited;

		[SerializeField]
		[HideInInspector]
		private bool smooth = true;

		[SerializeField]
		[HideInInspector]
		private float top = 0.5f;

		[SerializeField]
		[HideInInspector]
		private float bottom = -0.5f;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		public float StartAngle
		{
			get
			{
				return startAngle;
			}
			set
			{
				startAngle = value;
			}
		}

		public float EndAngle
		{
			get
			{
				return endAngle;
			}
			set
			{
				endAngle = value;
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

		public BoundsMode Mode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
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
			if (Mathf.Approximately(Factor, 0f) || Mathf.Approximately(Top, Bottom))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			if (mode != BoundsMode.Limited)
			{
				return new UnlimitedTwistJob
				{
					startAngle = StartAngle * Factor + Offset,
					endAngle = EndAngle * Factor + Offset,
					top = Top,
					bottom = Bottom,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new LimitedTwistJob
			{
				startAngle = StartAngle * Factor + Offset,
				endAngle = EndAngle * Factor + Offset,
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
