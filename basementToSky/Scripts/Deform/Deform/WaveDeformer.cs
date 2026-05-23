using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Wave (WIP)", Description = "Moves vertices up and down based on distance along a gerstner wave", Type = typeof(WaveDeformer), Category = Category.WIP)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/WaveDeformer")]
	public class WaveDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct WaveJob : IJobParallelFor
		{
			public float waveLength;

			public float steepness;

			public float offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float z = b.z;
				float num = MathF.PI * 2f / waveLength;
				float num2 = math.sqrt(1f / num);
				float num3 = steepness - 1f;
				b.z += math.exp(num * num3) / num * math.sin(num * (z + num2 * offset));
				b.y += (0f - math.exp(num * num3)) / num * math.cos(num * (z + num2 * offset));
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float waveLength = 1f;

		[SerializeField]
		[HideInInspector]
		private float steepness;

		[SerializeField]
		[HideInInspector]
		private float speed = 1f;

		[SerializeField]
		[HideInInspector]
		private float offset;

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		private float speedOffset;

		public float Factor
		{
			get
			{
				return Steepness;
			}
			set
			{
				Steepness = Factor;
			}
		}

		public float WaveLength
		{
			get
			{
				return waveLength;
			}
			set
			{
				waveLength = Mathf.Clamp(value, 0f, float.MaxValue);
			}
		}

		public float Steepness
		{
			get
			{
				return steepness;
			}
			set
			{
				steepness = Mathf.Clamp01(value);
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
			if (waveLength <= 0f)
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new WaveJob
			{
				waveLength = WaveLength,
				steepness = Steepness,
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
