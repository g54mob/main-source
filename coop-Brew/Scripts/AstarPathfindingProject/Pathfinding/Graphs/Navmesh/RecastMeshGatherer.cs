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
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	public class RecastMeshGatherer
	{
		private struct TreeInfo
		{
			public List<GatheredMesh> submeshes;

			public Vector3 localScale;

			public bool supportsRotation;
		}

		public struct MeshCollection : IArenaDisposable
		{
			private List<NativeArray<Vector3>> vertexBuffers;

			private List<NativeArray<int>> triangleBuffers;

			public NativeArray<RasterizationMesh> meshes;

			public MeshCollection(List<NativeArray<Vector3>> vertexBuffers, List<NativeArray<int>> triangleBuffers, NativeArray<RasterizationMesh> meshes)
			{
				this.vertexBuffers = null;
				this.triangleBuffers = null;
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CalculateBounds_00000A92_0024PostfixBurstDelegate(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds);

		internal static class CalculateBounds_00000A92_0024BurstDirectCall
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
		internal delegate void GenerateHeightmapChunk_00000AA3_0024PostfixBurstDelegate(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris);

		internal static class GenerateHeightmapChunk_00000AA3_0024BurstDirectCall
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

			public static void Invoke(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris)
			{
				verts = default(UnsafeSpan<Vector3>);
				tris = default(UnsafeSpan<int>);
			}
		}

		private readonly int terrainDownsamplingFactor;

		public readonly LayerMask mask;

		public readonly List<string> tagMask;

		private readonly float maxColliderApproximationError;

		public readonly Bounds bounds;

		public readonly Scene scene;

		private Dictionary<MeshCacheItem, int> cachedMeshes;

		private readonly Dictionary<GameObject, TreeInfo> cachedTreePrefabs;

		private readonly List<NativeArray<Vector3>> vertexBuffers;

		private readonly List<NativeArray<int>> triangleBuffers;

		private readonly List<Mesh> meshData;

		private readonly RecastGraph.PerLayerModification[] modificationsByLayer;

		private readonly RecastGraph.PerLayerModification[] modificationsByLayer2D;

		private bool anyNonReadableMesh;

		private List<GatheredMesh> meshes;

		private List<Material> dummyMaterials;

		private static readonly int[] BoxColliderTris;

		private static readonly Vector3[] BoxColliderVerts;

		public RecastMeshGatherer(Scene scene, Bounds bounds, int terrainDownsamplingFactor, LayerMask mask, List<string> tagMask, List<RecastGraph.PerLayerModification> perLayerModifications, float maxColliderApproximationError)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(CalculateBounds_00000A92_0024PostfixBurstDelegate))]
		private static void CalculateBounds(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
		{
			bounds = default(Bounds);
		}

		public MeshCollection Finalize()
		{
			return default(MeshCollection);
		}

		public int AddMeshBuffers(Vector3[] vertices, int[] triangles)
		{
			return 0;
		}

		public int AddMeshBuffers(NativeArray<Vector3> vertices, NativeArray<int> triangles)
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

		private bool GenerateTerrainChunks(Terrain terrain, Bounds bounds, float desiredChunkSize)
		{
			return false;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(GenerateHeightmapChunk_00000AA3_0024PostfixBurstDelegate))]
		public static void GenerateHeightmapChunk(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris)
		{
			verts = default(UnsafeSpan<Vector3>);
			tris = default(UnsafeSpan<int>);
		}

		private void CollectTreeMeshes(Terrain terrain)
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
		internal static void CalculateBounds_0024BurstManaged(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
		{
			bounds = default(Bounds);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GenerateHeightmapChunk_0024BurstManaged(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris)
		{
			verts = default(UnsafeSpan<Vector3>);
			tris = default(UnsafeSpan<int>);
		}
	}
}
