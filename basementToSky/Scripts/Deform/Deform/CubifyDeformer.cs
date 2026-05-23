using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Cubify (WIP)", Description = "Morphs mesh into a cube", Type = typeof(CubifyDeformer), Category = Category.WIP)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/CubifyDeformer")]
	public class CubifyDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct CubifyJob : IJobParallelFor
		{
			public float factor;

			public float width;

			public float height;

			public float length;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				float num = width * 0.5f;
				float num2 = height * 0.5f;
				float num3 = length * 0.5f;
				float num4 = b.x / width;
				float num5 = b.y / height;
				float num6 = b.z / length;
				bool test = num4 > 0f;
				bool test2 = num5 > 0f;
				bool test3 = num6 > 0f;
				float end = math.select(0f - num, num, test) / (factor * 0.5f + 1f) * 1.5f;
				float end2 = math.select(0f - num2, num2, test2) / (factor * 0.5f + 1f) * 1.5f;
				float end3 = math.select(0f - num3, num3, test3) / (factor * 0.5f + 1f) * 1.5f;
				float x = math.abs(num4) * factor * 2f;
				b.x = math.lerp(t: math.saturate(x), start: b.x, end: end);
				float x2 = math.abs(num5) * factor * 2f;
				b.y = math.lerp(t: math.saturate(x2), start: b.y, end: end2);
				float x3 = math.abs(num6) * factor * 2f;
				x3 = math.saturate(x3);
				b.z = math.lerp(b.z, end3, x3);
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private float width = 1f;

		[SerializeField]
		[HideInInspector]
		private float height = 1f;

		[SerializeField]
		[HideInInspector]
		private float length = 1f;

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

		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		public float Length
		{
			get
			{
				return length;
			}
			set
			{
				length = value;
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
			return new CubifyJob
			{
				factor = Factor,
				width = Width,
				height = Height,
				length = Length,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
