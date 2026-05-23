using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Melt (WIP)", Description = "Melts mesh onto flat surface", XRotation = -90f, Type = typeof(MeltDeformer), Category = Category.WIP)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/MeltDeformer")]
	public class MeltDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct MeltJob : IJobParallelFor
		{
			public float factor;

			public float radius;

			public float falloff;

			public bool useNormals;

			public bool clampAtBottom;

			public float top;

			public float bottom;

			public float verticalFrequency;

			public float verticalMagnitude;

			public float radialFrequency;

			public float radialMagnitude;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public NativeArray<float3> normals;

			public void Execute(int index)
			{
				if (top != bottom)
				{
					float4 float5 = math.mul(meshToAxis, math.float4(vertices[index], 1f));
					float4 float6 = math.mul(meshToAxis, math.float4(normals[index], 1f));
					float num = top - bottom;
					float num2 = math.pow(1f - math.saturate((float5.z - bottom) / num), falloff) * factor;
					if (useNormals)
					{
						float5.xy += float6.xy * num2 * radius;
					}
					else
					{
						float5.xy += math.normalize(float5.xy) * num2 * radius;
					}
					float num3 = noise.snoise(float5 * verticalFrequency) * verticalMagnitude;
					float num4 = math.sin(math.saturate((float5.z - bottom) / num) * MathF.PI);
					float5.z += num3 * num4 * num2;
					if (clampAtBottom)
					{
						float5.z = math.max(bottom, float5.z);
					}
					float num5 = noise.snoise(float5.xy * radialFrequency) * radialMagnitude * num2;
					float5.xy += num5;
					vertices[index] = math.mul(axisToMesh, float5).xyz;
				}
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float falloff = 2f;

		[SerializeField]
		[HideInInspector]
		private float radius = 1f;

		[SerializeField]
		[HideInInspector]
		private bool useNormals;

		[SerializeField]
		[HideInInspector]
		private bool clampAtBottom = true;

		[SerializeField]
		[HideInInspector]
		private float top = 1f;

		[SerializeField]
		[HideInInspector]
		private float bottom;

		[SerializeField]
		[HideInInspector]
		private float verticalFrequency = 1f;

		[SerializeField]
		[HideInInspector]
		private float verticalMagnitude;

		[SerializeField]
		[HideInInspector]
		private float radialFrequency = 1f;

		[SerializeField]
		[HideInInspector]
		private float radialMagnitude;

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
				factor = Mathf.Clamp01(value);
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
				falloff = Mathf.Max(value, 0f);
			}
		}

		public float Radius
		{
			get
			{
				return radius;
			}
			set
			{
				radius = value;
			}
		}

		public bool UseNormals
		{
			get
			{
				return useNormals;
			}
			set
			{
				useNormals = value;
			}
		}

		public bool ClampAtBottom
		{
			get
			{
				return clampAtBottom;
			}
			set
			{
				clampAtBottom = value;
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

		public float VerticalFrequency
		{
			get
			{
				return verticalFrequency;
			}
			set
			{
				verticalFrequency = value;
			}
		}

		public float VerticalMagnitude
		{
			get
			{
				return verticalMagnitude;
			}
			set
			{
				verticalMagnitude = value;
			}
		}

		public float RadialFrequency
		{
			get
			{
				return radialFrequency;
			}
			set
			{
				radialFrequency = value;
			}
		}

		public float RadialMagnitude
		{
			get
			{
				return radialMagnitude;
			}
			set
			{
				radialMagnitude = value;
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
			if (Mathf.Approximately(Factor, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new MeltJob
			{
				factor = Factor,
				radius = Radius,
				falloff = Falloff,
				useNormals = UseNormals,
				clampAtBottom = ClampAtBottom,
				top = Top,
				bottom = Bottom,
				verticalFrequency = VerticalFrequency,
				verticalMagnitude = VerticalMagnitude,
				radialFrequency = RadialFrequency,
				radialMagnitude = RadialMagnitude,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
