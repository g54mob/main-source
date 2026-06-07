using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	public class RecastMeshGatherer
	{
		private static class Markers
		{
			public static readonly ProfilerMarker MarkerCalculateBounds;

			public static readonly ProfilerMarker MarkerGetMissingMeshDataAndBounds;

			public static readonly ProfilerMarker MarkerPatchMissingMeshDataAndBounds;

			public static readonly ProfilerMarker MarkerCreateRasterizationMeshes;
		}

		private struct TreeInfo
		{
			public UnsafeList<int> submeshIndices;

			public Vector3 localScale;

			public bool supportsRotation;
		}

		public struct MeshCollection : IArenaDisposable
		{
			private UnsafeList<UnsafeSpan<Vector3>> vertexBuffers;

			private UnsafeList<UnsafeSpan<int>> triangleBuffers;

			private UnsafeList<UnsafeSpan<int>> tagsBuffers;

			public NativeArray<RasterizationMesh> meshes;

			public MeshCollection(UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, UnsafeList<UnsafeSpan<int>> triangleBuffers, UnsafeList<UnsafeSpan<int>> tagsBuffers, NativeArray<RasterizationMesh> meshes)
			{
				this.vertexBuffers = default(UnsafeList<UnsafeSpan<Vector3>>);
				this.triangleBuffers = default(UnsafeList<UnsafeSpan<int>>);
				this.tagsBuffers = default(UnsafeList<UnsafeSpan<int>>);
				this.meshes = default(NativeArray<RasterizationMesh>);
			}

			void IArenaDisposable.DisposeWith(DisposeArena arena)
			{
			}
		}

		public struct GatheredMesh
		{
			public int meshDataIndex;

			public int area;

			public int tagDataIndex;

			public int indexStart;

			public int indexEnd;

			public Bounds bounds;

			public Matrix4x4 matrix;

			public bool solid;

			public bool doubleSided;

			public bool flatten;

			public bool areaIsTag;

			public void RecalculateBounds()
			{
			}

			public void ApplyNavmeshModifier(RecastNavmeshModifier navmeshModifier)
			{
			}

			public void ApplyLayerModification(RecastGraph.PerLayerModification modification)
			{
			}
		}

		private enum MeshType
		{
			Mesh = 0,
			Box = 1,
			Capsule = 2
		}

		private struct MeshCacheItem : IEquatable<MeshCacheItem>
		{
			public MeshType type;

			public Mesh mesh;

			public int rows;

			public int quantizedHeight;

			public static readonly MeshCacheItem Box;

			public MeshCacheItem(Mesh mesh)
			{
				type = default(MeshType);
				this.mesh = null;
				rows = 0;
				quantizedHeight = 0;
			}

			public bool Equals(MeshCacheItem other)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[BurstCompile]
		private struct JobGenerateHeightmapChunk : IJobFor
		{
			public struct TerrainChunk
			{
				public UnsafeSpan<Vector3> verts;

				public UnsafeSpan<int> tris;

				public UnsafeSpan<int> tags;
			}

			public UnsafeSpan<float> heights;

			public UnsafeSpan<bool> holes;

			public IntRect sampleRect;

			public Vector2Int chunkSize;

			public Vector2Int chunks;

			public int stride;

			public float alphamapScale;

			public UnsafeSpan<UnsafeSpan<byte>> alphaMaps;

			public UnsafeSpan<int> areaMapping;

			public UnsafeSpan<float> areaMappingThresholds;

			public NativeArray<TerrainChunk> output;

			public void Execute(int index)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void CalculateBounds_00000BF3_0024PostfixBurstDelegate(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds);

		internal static class CalculateBounds_00000BF3_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
			{
				bounds = default(Bounds);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void PatchMissingMeshDataAndBounds_00000BF5_0024PostfixBurstDelegate(ref UnsafeList<GatheredMesh> gatheredMeshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, int meshBufferOffset);

		internal static class PatchMissingMeshDataAndBounds_00000BF5_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeList<GatheredMesh> gatheredMeshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, int meshBufferOffset)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void CreateRasterizationMeshes_00000BF7_0024PostfixBurstDelegate(ref UnsafeList<GatheredMesh> meshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, ref UnsafeList<UnsafeSpan<int>> triangleBuffers, ref UnsafeList<UnsafeSpan<int>> tagsBuffers, ref UnsafeSpan<RasterizationMesh> rasterizationMeshesOutput);

		internal static class CreateRasterizationMeshes_00000BF7_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeList<GatheredMesh> meshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, ref UnsafeList<UnsafeSpan<int>> triangleBuffers, ref UnsafeList<UnsafeSpan<int>> tagsBuffers, ref UnsafeSpan<RasterizationMesh> rasterizationMeshesOutput)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ConvertTreesToMeshes_00000C0A_0024PostfixBurstDelegate(ref UnsafeSpan<TreeInstance> treeInstances, ref float3 terrainPos, ref float3 terrainSize, ref UnsafeSpan<TreeInfo> treeInfos, ref UnsafeList<GatheredMesh> allSubmeshes, ref Bounds graphBounds, ref UnsafeList<GatheredMesh> meshes);

		internal static class ConvertTreesToMeshes_00000C0A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeSpan<TreeInstance> treeInstances, ref float3 terrainPos, ref float3 terrainSize, ref UnsafeSpan<TreeInfo> treeInfos, ref UnsafeList<GatheredMesh> allSubmeshes, ref Bounds graphBounds, ref UnsafeList<GatheredMesh> meshes)
			{
			}
		}

		private readonly int terrainDownsamplingFactor;

		public readonly LayerMask mask;

		public readonly List<string> tagMask;

		private readonly float maxColliderApproximationError;

		public readonly Bounds bounds;

		public readonly PhysicsScene physicsScene;

		public readonly PhysicsScene2D physicsScene2D;

		private Dictionary<MeshCacheItem, int> cachedMeshes;

		private UnsafeList<UnsafeSpan<Vector3>> vertexBuffers;

		private UnsafeList<UnsafeSpan<int>> triangleBuffers;

		private UnsafeList<UnsafeSpan<int>> tagsBuffers;

		private List<Mesh> meshData;

		private readonly RecastGraph.PerLayerModification[] modificationsByLayer;

		private readonly RecastGraph.PerLayerModification[] modificationsByLayer2D;

		private readonly List<RecastGraph.PerTerrainLayerModification> perTerrainLayerModifications;

		private bool anyNonReadableMesh;

		private UnsafeList<GatheredMesh> meshes;

		private List<Material> dummyMaterials;

		private static readonly int[] BoxColliderTris;

		private static readonly Vector3[] BoxColliderVerts;

		public RecastMeshGatherer(PhysicsScene physicsScene, PhysicsScene2D physicsScene2D, Bounds bounds, int terrainDownsamplingFactor, LayerMask mask, List<string> tagMask, List<RecastGraph.PerLayerModification> perLayerModifications, List<RecastGraph.PerTerrainLayerModification> perTerrainLayerModifications, float maxColliderApproximationError)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(CalculateBounds_00000BF3_0024PostfixBurstDelegate))]
		private static void CalculateBounds(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
		{
			bounds = default(Bounds);
		}

		private static void GetMissingMeshDataAndBounds(List<Mesh> meshData, ref UnsafeList<GatheredMesh> gatheredMeshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, ref UnsafeList<UnsafeSpan<int>> triangleBuffers)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(PatchMissingMeshDataAndBounds_00000BF5_0024PostfixBurstDelegate))]
		private static void PatchMissingMeshDataAndBounds(ref UnsafeList<GatheredMesh> gatheredMeshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, int meshBufferOffset)
		{
		}

		public MeshCollection Finalize()
		{
			return default(MeshCollection);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(CreateRasterizationMeshes_00000BF7_0024PostfixBurstDelegate))]
		private static void CreateRasterizationMeshes(ref UnsafeList<GatheredMesh> meshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, ref UnsafeList<UnsafeSpan<int>> triangleBuffers, ref UnsafeList<UnsafeSpan<int>> tagsBuffers, ref UnsafeSpan<RasterizationMesh> rasterizationMeshesOutput)
		{
		}

		public int AddMeshBuffers(Vector3[] vertices, int[] triangles)
		{
			return 0;
		}

		public int AddMeshBuffers(UnsafeSpan<Vector3> vertices, UnsafeSpan<int> triangles)
		{
			return 0;
		}

		public void AddMesh(Renderer renderer, Mesh gatheredMesh)
		{
		}

		public void AddMesh(GatheredMesh gatheredMesh)
		{
		}

		private bool MeshFilterShouldBeIncluded(MeshFilter filter)
		{
			return false;
		}

		private bool ConvertMeshToGatheredMesh(Renderer renderer, Mesh mesh, out GatheredMesh gatheredMesh)
		{
			gatheredMesh = default(GatheredMesh);
			return false;
		}

		private GatheredMesh? GetColliderMesh(MeshCollider collider, Matrix4x4 localToWorldMatrix)
		{
			return null;
		}

		public void CollectSceneMeshes()
		{
		}

		private static int AreaFromSurfaceMode(RecastNavmeshModifier.Mode mode, int surfaceID)
		{
			return 0;
		}

		public void CollectRecastNavmeshModifiers()
		{
		}

		private void AddNavmeshModifier(RecastNavmeshModifier navmeshModifier)
		{
		}

		public void CollectTerrainMeshes(bool rasterizeTrees, float desiredChunkSize)
		{
		}

		private static int NonNegativeModulus(int x, int m)
		{
			return 0;
		}

		private static int CeilDivision(int lhs, int rhs)
		{
			return 0;
		}

		private static void GetAlphamaps(List<RecastGraph.PerTerrainLayerModification> perTerrainLayerModifications, out UnsafeSpan<UnsafeSpan<byte>> alphamaps, out UnsafeSpan<int> areaMapping, out UnsafeSpan<float> areaMappingThresholds, out float alphamapScale, TerrainData terrainData, int terrainDownsamplingFactor)
		{
			alphamaps = default(UnsafeSpan<UnsafeSpan<byte>>);
			areaMapping = default(UnsafeSpan<int>);
			areaMappingThresholds = default(UnsafeSpan<float>);
			alphamapScale = default(float);
		}

		private static void CalculateTerrainChunkLayout(float desiredChunkSize, Vector3 sampleSize, int terrainDownsamplingFactor, int heightmapResolution, Bounds bounds, Vector3 offset, out IntRect sampleRect, out Vector2Int chunks, out Vector2Int chunkSize)
		{
			sampleRect = default(IntRect);
			chunks = default(Vector2Int);
			chunkSize = default(Vector2Int);
		}

		private bool GenerateTerrainChunks(Terrain terrain, Bounds bounds, float desiredChunkSize)
		{
			return false;
		}

		private void CollectTreeMeshes(Terrain terrain)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(ConvertTreesToMeshes_00000C0A_0024PostfixBurstDelegate))]
		private static void ConvertTreesToMeshes(ref UnsafeSpan<TreeInstance> treeInstances, ref float3 terrainPos, ref float3 terrainSize, ref UnsafeSpan<TreeInfo> treeInfos, ref UnsafeList<GatheredMesh> allSubmeshes, ref Bounds graphBounds, ref UnsafeList<GatheredMesh> meshes)
		{
		}

		private bool ShouldIncludeCollider(Collider collider)
		{
			return false;
		}

		public void CollectColliderMeshes()
		{
		}

		private GatheredMesh? ConvertColliderToGatheredMesh(Collider col)
		{
			return null;
		}

		public GatheredMesh? ConvertColliderToGatheredMesh(Collider col, Matrix4x4 localToWorldMatrix)
		{
			return null;
		}

		private GatheredMesh RasterizeBoxCollider(BoxCollider collider, Matrix4x4 localToWorldMatrix)
		{
			return default(GatheredMesh);
		}

		private static int CircleSteps(Matrix4x4 matrix, float radius, float maxError)
		{
			return 0;
		}

		private static float CircleRadiusAdjustmentFactor(int steps)
		{
			return 0f;
		}

		private GatheredMesh RasterizeCapsuleCollider(float radius, float height, Bounds bounds, Matrix4x4 localToWorldMatrix)
		{
			return default(GatheredMesh);
		}

		private bool ShouldIncludeCollider2D(Collider2D collider)
		{
			return false;
		}

		public void Collect2DColliderMeshes()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void CalculateBounds_0024BurstManaged(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
		{
			bounds = default(Bounds);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void PatchMissingMeshDataAndBounds_0024BurstManaged(ref UnsafeList<GatheredMesh> gatheredMeshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, int meshBufferOffset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void CreateRasterizationMeshes_0024BurstManaged(ref UnsafeList<GatheredMesh> meshes, ref UnsafeList<UnsafeSpan<Vector3>> vertexBuffers, ref UnsafeList<UnsafeSpan<int>> triangleBuffers, ref UnsafeList<UnsafeSpan<int>> tagsBuffers, ref UnsafeSpan<RasterizationMesh> rasterizationMeshesOutput)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void ConvertTreesToMeshes_0024BurstManaged(ref UnsafeSpan<TreeInstance> treeInstances, ref float3 terrainPos, ref float3 terrainSize, ref UnsafeSpan<TreeInfo> treeInfos, ref UnsafeList<GatheredMesh> allSubmeshes, ref Bounds graphBounds, ref UnsafeList<GatheredMesh> meshes)
		{
		}
	}
}
