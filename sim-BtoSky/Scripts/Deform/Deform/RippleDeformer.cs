using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Ripple", Description = "Adds ripple to mesh", XRotation = -90f, Type = typeof(RippleDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/RippleDeformer")]
	public class RippleDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedRippleJob : IJobParallelFor
		{
			public float frequency;

			public float amplitude;

			public float offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = math.length(b.xy);
				b.z += math.sin((offset + num * frequency) * MathF.PI * 2f) * amplitude;
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LimitedRippleJob : IJobParallelFor
		{
			public float frequency;

			public float amplitude;

			public float falloff;

			public float innerRadius;

			public float outerRadius;

			public float offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float num = outerRadius - innerRadius;
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num2 = math.length(b.xy);
				float num3 = math.clamp(num2, innerRadius, outerRadius);
				float num4 = math.sin((0f - offset + num3 * frequency) * MathF.PI * 2f) * amplitude;
				if (num != 0f)
				{
					float num5 = math.clamp((num3 - innerRadius) / num, 0f, 1f);
					b.z += math.lerp(num4, 0f, num5 * falloff);
				}
				else if (num2 > outerRadius)
				{
					b.z += math.lerp(num4, 0f, falloff);
				}
				else if (num2 < innerRadius)
				{
					b.z += num4;
				}
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float frequency = 1f;

		[SerializeField]
		[HideInInspector]
		private float amplitude;

		[SerializeField]
		[HideInInspector]
		private BoundsMode mode = BoundsMode.Limited;

		[SerializeField]
		[HideInInspector]
		private float falloff = 1f;

		[SerializeField]
		[HideInInspector]
		private float innerRadius;

		[SerializeField]
		[HideInInspector]
		private float outerRadius = 1f;

		[SerializeField]
		[HideInInspector]
		private float speed;

		[SerializeField]
		[HideInInspector]
		private float offset;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		[SerializeField]
		[HideInInspector]
		private float speedOffset;

		public float Factor
		{
			get
			{
				return Amplitude;
			}
			set
			{
				Amplitude = value;
			}
		}

		public float Frequency
		{
			get
			{
				return frequency;
			}
			set
			{
				frequency = value;
			}
		}

		public float Amplitude
		{
			get
			{
				return amplitude;
			}
			set
			{
				amplitude = value;
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

		public float Falloff
		{
			get
			{
				return falloff;
			}
			set
			{
				falloff = Mathf.Clamp01(value);
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
				innerRadius = Mathf.Max(0f, Mathf.Min(value, OuterRadius));
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

		public float Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
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

		private void Update()
		{
			speedOffset += Speed * Time.deltaTime;
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (Mathf.Approximately(Amplitude, 0f) || Mathf.Approximately(Frequency, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			if (Mode != BoundsMode.Limited)
			{
				return new UnlimitedRippleJob
				{
					frequency = Frequency,
					amplitude = Amplitude,
					offset = GetTotalOffset(),
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new LimitedRippleJob
			{
				frequency = Frequency,
				amplitude = Amplitude,
				falloff = Falloff,
				innerRadius = InnerRadius,
				outerRadius = OuterRadius,
				offset = GetTotalOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}

		public float GetTotalOffset()
		{
			return Offset + speedOffset;
		}
	}
}
