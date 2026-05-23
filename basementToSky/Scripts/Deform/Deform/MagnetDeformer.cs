using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Magnet", Description = "Attracts or repels vertices from a point", Type = typeof(MagnetDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/MagnetDeformer")]
	public class MagnetDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct MagnetJob : IJobParallelFor
		{
			public float factor;

			public float falloff;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				float num = math.pow(math.length(xyz), 2f) / factor;
				if (num != 0f)
				{
					float t = math.clamp(factor * (1f / math.pow(math.abs(num), falloff)), float.MinValue, 1f);
					xyz = math.lerp(xyz, math.float3(0), t);
					vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
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
		private Transform center;

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

		public Transform Center
		{
			get
			{
				if (center == null)
				{
					center = base.transform;
				}
				return center;
			}
			set
			{
				center = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (Mathf.Approximately(Factor, 0f))
			{
				return dependency;
			}
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Center, data.Target.GetTransform());
			return new MagnetJob
			{
				factor = Factor,
				falloff = Falloff,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
