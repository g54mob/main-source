using System;
using Beans.Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Bounded Bend (WIP)", Description = "Bends a mesh within a bounding box", Type = typeof(BoundedBendDeformer), Category = Category.WIP)]
	public class BoundedBendDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UnlimitedBendJob : IJobParallelFor
		{
			public float angle;

			public bounds bounds;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = math.radians(angle) * (1f / (bounds.max.y - bounds.min.y));
				float num2 = 1f / num;
				float num3 = b.y * num;
				float num4 = math.cos(MathF.PI - num3);
				float num5 = math.sin(MathF.PI - num3);
				b.xy = math.float2(num2 * num4 + num2 - b.x * num4, num2 * num5 - b.x * num5);
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct LimitedBendJob : IJobParallelFor
		{
			public float angle;

			public bounds bounds;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 float5 = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				if (!(float5.x > bounds.max.x) && !(float5.x < bounds.min.x) && !(float5.z > bounds.max.z) && !(float5.z < bounds.min.z) && !(float5.y < bounds.min.y))
				{
					float4 float6 = float5;
					float y = bounds.max.y;
					float y2 = bounds.min.y;
					float num = math.radians(angle);
					float num2 = 1f / (num * (1f / (y - y2)));
					float num3 = (math.clamp(float5.y, y2, y) - y2) / (y - y2) * num;
					float num4 = math.cos(MathF.PI - num3);
					float num5 = math.sin(MathF.PI - num3);
					float5.xy = math.float2(num2 * num4 + num2 - float5.x * num4, num2 * num5 - float5.x * num5);
					if (float6.y > y)
					{
						float5.y += (0f - num4) * (float6.y - y);
						float5.x += num5 * (float6.y - y);
					}
					else if (float6.y < y2)
					{
						float5.y += (0f - num4) * (float6.y - y2);
						float5.x += num5 * (float6.y - y2);
					}
					float5.y += y2;
					vertices[index] = math.mul(axisToMesh, float5).xyz;
				}
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
		private BoundsMode mode = BoundsMode.Limited;

		[SerializeField]
		[HideInInspector]
		private Bounds bounds;

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

		public Bounds Bounds
		{
			get
			{
				return bounds;
			}
			set
			{
				bounds = value;
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
			float a = Angle * Factor;
			if (Mathf.Approximately(a, 0f) || Mathf.Approximately(Bounds.size.y, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			BoundsMode boundsMode = mode;
			if (boundsMode == BoundsMode.Unlimited || boundsMode != BoundsMode.Limited)
			{
				return new UnlimitedBendJob
				{
					angle = a,
					bounds = Bounds,
					meshToAxis = meshToAxisSpace,
					axisToMesh = meshToAxisSpace.inverse,
					vertices = data.DynamicNative.VertexBuffer
				}.Schedule(data.Length, 64, dependency);
			}
			return new LimitedBendJob
			{
				angle = a,
				bounds = Bounds,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
