using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Star", Description = "Moves vertices away from axis based on angle around axis on a sine wave", Type = typeof(StarDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/StarDeformer")]
	public class StarDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct StarJob : IJobParallelFor
		{
			public float frequency;

			public float magnitude;

			public float offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				if (math.length(b.xy) != 0f)
				{
					float2 float5 = math.normalize(b.xy);
					float num = math.atan2(float5.y, float5.x);
					float num2 = math.sin(frequency * num + offset) * magnitude * math.length(b.xy);
					b.xy += float5.xy * num2;
					vertices[index] = math.mul(axisToMesh, b).xyz;
				}
			}
		}

		[SerializeField]
		[HideInInspector]
		private float frequency = 5f;

		[SerializeField]
		[HideInInspector]
		private float magnitude;

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
				return Magnitude;
			}
			set
			{
				Magnitude = value;
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

		public float Magnitude
		{
			get
			{
				return magnitude;
			}
			set
			{
				magnitude = value;
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
			speedOffset += speed * Time.deltaTime;
		}

		public float GetTotalOffset()
		{
			return Offset + speedOffset;
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (Magnitude == 0f)
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new StarJob
			{
				frequency = Frequency,
				magnitude = Magnitude,
				offset = GetTotalOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
