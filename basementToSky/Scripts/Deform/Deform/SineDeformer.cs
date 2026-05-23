using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Sine", Description = "Moves vertices in direction based on distance along sine wave", Type = typeof(SineDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/SineDeformer")]
	public class SineDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct SineJob : IJobParallelFor
		{
			public float frequency;

			public float magnitude;

			public float falloff;

			public float offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = math.sin((b.z * frequency + offset) * MathF.PI * 2f) * magnitude;
				num *= math.exp((0f - falloff) * math.abs(b.z));
				b.y += num;
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
		private float falloff;

		[SerializeField]
		[HideInInspector]
		private float offset;

		[SerializeField]
		[HideInInspector]
		private float speed;

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

		public float GetTotalOffset()
		{
			return Offset + speedOffset;
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (Mathf.Approximately(Amplitude, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new SineJob
			{
				frequency = Frequency,
				magnitude = Amplitude,
				falloff = Falloff,
				offset = GetTotalOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
