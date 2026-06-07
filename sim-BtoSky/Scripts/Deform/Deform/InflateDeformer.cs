using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Inflate", Description = "Moves vertices along normals", Type = typeof(InflateDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/InflateDeformer")]
	public class InflateDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct InflateJob : IJobParallelFor
		{
			public float factor;

			public NativeArray<float3> vertices;

			public NativeArray<float3> normals;

			public void Execute(int index)
			{
				vertices[index] += normals[index] * factor;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private bool useUpdatedNormals;

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

		public bool UseUpdatedNormals
		{
			get
			{
				return useUpdatedNormals;
			}
			set
			{
				useUpdatedNormals = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (Factor == 0f)
			{
				return dependency;
			}
			if (UseUpdatedNormals)
			{
				dependency = MeshUtils.RecalculateNormals(data.DynamicNative, dependency);
			}
			return new InflateJob
			{
				factor = Factor,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
