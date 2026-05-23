using Beans.Unity.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[Deformer(Name = "Blend", Description = "Blends between current vertices and vertices stored in a vertex cache", Type = typeof(BlendDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/BlendDeformer")]
	public class BlendDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct BlendJob : IJobParallelFor
		{
			public float factor;

			public NativeArray<float3> currentVertices;

			[ReadOnly]
			public NativeArray<float3> cachedVertices;

			public void Execute(int index)
			{
				float3 value = math.lerp(currentVertices[index], cachedVertices[index], factor);
				currentVertices[index] = value;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor;

		[SerializeField]
		[HideInInspector]
		private VertexCache cache;

		private NativeArray<float3> vertices;

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

		public VertexCache Cache
		{
			get
			{
				return cache;
			}
			set
			{
				cache = value;
				Initialize();
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public bool Initialize()
		{
			if (vertices.IsCreated)
			{
				vertices.Dispose();
			}
			if (Cache == null)
			{
				return false;
			}
			vertices = new NativeArray<float3>(Cache.Data.Vertices.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			Cache.Data.Vertices.MemCpy(vertices);
			return true;
		}

		private void OnEnable()
		{
			Initialize();
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (!vertices.IsCreated && !Initialize())
			{
				return dependency;
			}
			if (data.Length != vertices.Length)
			{
				Debug.LogError("Vertex cache has different vertex count than deformable's mesh, " + data.Target.GetGameObject().name + ".");
				return dependency;
			}
			return new BlendJob
			{
				factor = Factor,
				currentVertices = data.DynamicNative.VertexBuffer,
				cachedVertices = vertices
			}.Schedule(data.Length, 64, dependency);
		}

		private void OnDisable()
		{
			if (vertices.IsCreated)
			{
				vertices.Dispose();
			}
		}
	}
}
