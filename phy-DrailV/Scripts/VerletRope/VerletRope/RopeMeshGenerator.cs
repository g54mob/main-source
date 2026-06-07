using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace VerletRope
{
	[RequireComponent(typeof(MeshFilter))]
	public class RopeMeshGenerator : MonoBehaviour
	{
		public Rope rope;

		public float uvScale = 3f;

		public int interpolation = 2;

		public float thickness = 0.05f;

		private Mesh mesh;

		private MeshFilter meshFilter;

		private MeshRenderer meshRenderer;

		private NativeArray<RopeMeshVertex> verticesNA;

		private NativeArray<int> trianglesNA;

		private NativeArray<BurstBounds> boundsNA;

		private MeshInitialGenerateJob job;

		private JobHandle handle;

		private bool reinitializeMesh;

		private static readonly ProfilerMarker prof_assignToMesh = new ProfilerMarker("VRLT assign to mesh");

		private static readonly ProfilerMarker prof_Dispose = new ProfilerMarker("VRLT job.Dispose");

		private void Awake()
		{
			meshFilter = GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				Debug.LogError("RopeMeshGenerator couldn't find a MeshFilter, destroying self", base.gameObject);
				Object.Destroy(this);
				return;
			}
			if (meshFilter.mesh == null)
			{
				Debug.LogError("RopeMeshGenerator found a MeshFilter with null mesh, destroying self", base.gameObject);
				Object.Destroy(this);
				return;
			}
			meshRenderer = GetComponent<MeshRenderer>();
			mesh = meshFilter.mesh;
			mesh.MarkDynamic();
			reinitializeMesh = true;
		}

		private void InitializeArrays()
		{
			Deinitialize();
			int totalInterpolatedPoints = MeshInitialGenerateJob.GetTotalInterpolatedPoints(rope.points.Length, interpolation);
			int length = totalInterpolatedPoints * MeshInitialGenerateJob.shapePoints.Length;
			int length2 = (totalInterpolatedPoints - 1) * (MeshInitialGenerateJob.shapePoints.Length - 1) * 6;
			verticesNA = new NativeArray<RopeMeshVertex>(length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			trianglesNA = new NativeArray<int>(length2, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			boundsNA = new NativeArray<BurstBounds>(1, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
		}

		internal void Deinitialize()
		{
			if (verticesNA.IsCreated)
			{
				verticesNA.Dispose();
			}
			if (trianglesNA.IsCreated)
			{
				trianglesNA.Dispose();
			}
			if (boundsNA.IsCreated)
			{
				boundsNA.Dispose();
			}
			reinitializeMesh = true;
		}

		internal JobHandle Schedule(JobHandle dependsOn, NativeArray<bool> isMeshInFrustum)
		{
			if (reinitializeMesh)
			{
				mesh.Clear(keepVertexLayout: false);
				InitializeArrays();
				reinitializeMesh = false;
			}
			job = new MeshInitialGenerateJob(rope.points, uvScale, thickness, interpolation, isMeshInFrustum, verticesNA, trianglesNA, boundsNA);
			handle = job.Schedule(dependsOn);
			return handle;
		}

		internal void UpdateMeshAndDispose()
		{
			bool flag = job.isMeshInFrustum[0];
			meshRenderer.enabled = flag;
			if (flag)
			{
				using (prof_assignToMesh.Auto())
				{
					mesh.SetVertexBufferParams(job.vertices.Length, RopeMeshVertex.Layout);
					mesh.SetVertexBufferData(job.vertices, 0, 0, job.vertices.Length, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
					mesh.SetIndexBufferParams(job.triangles.Length, IndexFormat.UInt32);
					mesh.SetIndexBufferData(job.triangles, 0, 0, job.triangles.Length, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
					mesh.SetSubMesh(0, new SubMeshDescriptor(0, job.triangles.Length), MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
					mesh.bounds = job.bounds[0];
				}
			}
			using (prof_Dispose.Auto())
			{
				job.Dispose();
			}
		}
	}
}
