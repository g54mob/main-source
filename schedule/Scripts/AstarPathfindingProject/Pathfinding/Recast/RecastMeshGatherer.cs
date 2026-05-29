using System.Collections.Generic;
using Pathfinding.Voxels;
using UnityEngine;

namespace Pathfinding.Recast
{
	internal class RecastMeshGatherer
	{
		private class CapsuleCache
		{
			public int rows;

			public float height;

			public Vector3[] verts;

			public int[] tris;
		}

		private readonly int terrainSampleSize;

		private readonly LayerMask mask;

		private readonly List<string> tagMask;

		private readonly float colliderRasterizeDetail;

		private readonly Bounds bounds;

		private static readonly int[] BoxColliderTris;

		private static readonly Vector3[] BoxColliderVerts;

		private List<CapsuleCache> capsuleCache;

		public RecastMeshGatherer(Bounds bounds, int terrainSampleSize, LayerMask mask, List<string> tagMask, float colliderRasterizeDetail)
		{
		}

		private static List<MeshFilter> FilterMeshes(MeshFilter[] meshFilters, List<string> tagMask, LayerMask layerMask)
		{
			return null;
		}

		public void CollectSceneMeshes(List<RasterizationMesh> meshes)
		{
		}

		public void CollectRecastMeshObjs(List<RasterizationMesh> buffer)
		{
		}

		public void CollectTerrainMeshes(bool rasterizeTrees, float desiredChunkSize, List<RasterizationMesh> result)
		{
		}

		private void GenerateTerrainChunks(Terrain terrain, Bounds bounds, float desiredChunkSize, List<RasterizationMesh> result)
		{
		}

		private static int CeilDivision(int lhs, int rhs)
		{
			return 0;
		}

		private RasterizationMesh GenerateHeightmapChunk(float[,] heights, Vector3 sampleSize, Vector3 offset, int x0, int z0, int width, int depth, int stride)
		{
			return null;
		}

		private void CollectTreeMeshes(Terrain terrain, List<RasterizationMesh> result)
		{
		}

		public void CollectColliderMeshes(List<RasterizationMesh> result)
		{
		}

		private RasterizationMesh RasterizeCollider(Collider col)
		{
			return null;
		}

		private RasterizationMesh RasterizeCollider(Collider col, Matrix4x4 localToWorldMatrix)
		{
			return null;
		}

		private RasterizationMesh RasterizeBoxCollider(BoxCollider collider, Matrix4x4 localToWorldMatrix)
		{
			return null;
		}

		private RasterizationMesh RasterizeCapsuleCollider(float radius, float height, Bounds bounds, Matrix4x4 localToWorldMatrix)
		{
			return null;
		}
	}
}
