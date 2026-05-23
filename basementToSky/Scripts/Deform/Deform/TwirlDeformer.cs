using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Twirl", Description = "Rotates vertices around an axis based off of distance from that axis", XRotation = -90f, Type = typeof(TwirlDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/TwirlDeformer")]
	public class TwirlDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedTwistJob : IJobParallelFor
		{
			public float angle;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float x = math.radians(math.length(b.xy) * angle);
				b.xy = math.float2(b.x * math.cos(x) - b.y * math.sin(x), b.x * math.sin(x) + b.y * math.cos(x));
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LimitedTwistJob : IJobParallelFor
		{
			public float angle;

			public float inner;

			public float outer;

			public bool smooth;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float num = math.abs(outer - inner);
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float valueToClamp = math.length(b.xy);
				float num2 = 0f;
				num2 = ((!smooth) ? math.lerp(angle, 0f, (math.clamp(valueToClamp, inner, outer) - inner) / num) : (math.smoothstep(num, 0f, math.clamp(valueToClamp, inner, outer) - inner) * angle));
				float x = math.radians(num2);
				b.xy = math.float2(b.x * math.cos(x) - b.y * math.sin(x), b.x * math.sin(x) + b.y * math.cos(x));
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		private const float MIN_RANGE = 0.0001f;

		[SerializeField]
		[HideInInspector]
		private float angle;

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

		[SerializeField]
		[HideInInspector]
		private BoundsMode mode = BoundsMode.Limited;

		[SerializeField]
		[HideInInspector]
		private float inner;

		[SerializeField]
		[HideInInspector]
		private float outer = 1f;

		[SerializeField]
		[HideInInspector]
		private bool smooth = true;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

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

		public float Inner
		{
			get
			{
				return inner;
			}
			set
			{
				inner = Mathf.Max(0f, Mathf.Min(value, Outer));
			}
		}

		public float Outer
		{
			get
			{
				return outer;
			}
			set
			{
				outer = Mathf.Max(value, Inner);
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
			if (Factor == 0f)
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			if (Mode != BoundsMode.Limited)
			{
				return new UnlimitedTwistJob
				{
					angle = Angle * Factor,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			if (Mathf.Abs(Inner - Outer) < 0.0001f)
			{
				return dependency;
			}
			return new LimitedTwistJob
			{
				angle = Angle * Factor,
				inner = Inner,
				outer = Outer,
				smooth = Smooth,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
