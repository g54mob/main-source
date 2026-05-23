using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
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
				this.vertexBuffers = vertexBuffers;
				this.triangleBuffers = triangleBuffers;
				this.meshes = meshes;
			}

			void IArenaDisposable.DisposeWith(DisposeArena arena)
			{
				for (int i = 0; i < vertexBuffers.Count; i++)
				{
					arena.Add(vertexBuffers[i]);
					arena.Add(triangleBuffers[i]);
				}
				arena.Add(meshes);
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
				bounds = default(Bounds);
			}

			public void ApplyRecastMeshObj(RecastMeshObj recastMeshObj)
			{
				area = AreaFromSurfaceMode(recastMeshObj.mode, recastMeshObj.surfaceID);
				areaIsTag = recastMeshObj.mode == RecastMeshObj.Mode.WalkableSurfaceWithTag;
				solid |= recastMeshObj.solid;
			}

			public void ApplyLayerModification(RecastGraph.PerLayerModification modification)
			{
				area = AreaFromSurfaceMode(modification.mode, modification.surfaceID);
				areaIsTag = modification.mode == RecastMeshObj.Mode.WalkableSurfaceWithTag;
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

			public static readonly MeshCacheItem Box = new MeshCacheItem
			{
				type = MeshType.Box,
				mesh = null,
				rows = 0,
				quantizedHeight = 0
			};

			public MeshCacheItem(Mesh mesh)
			{
				type = MeshType.Mesh;
				this.mesh = mesh;
				rows = 0;
				quantizedHeight = 0;
			}

			public bool Equals(MeshCacheItem other)
			{
				if (type == other.type && mesh == other.mesh && rows == other.rows)
				{
					return quantizedHeight == other.quantizedHeight;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return ((((((int)type * 31) ^ ((mesh != null) ? mesh.GetHashCode() : (-1))) * 31) ^ rows) * 31) ^ quantizedHeight;
			}
		}

		public delegate void CalculateBounds_00000ACF_0024PostfixBurstDelegate(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds);

		internal static class CalculateBounds_00000ACF_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(CalculateBounds_00000ACF_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static CalculateBounds_00000ACF_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<float3>, ref float4x4, ref Bounds, void>)functionPointer)(ref vertices, ref localToWorldMatrix, ref bounds);
						return;
					}
				}
				CalculateBounds_0024BurstManaged(ref vertices, ref localToWorldMatrix, out bounds);
			}
		}

		public delegate void GenerateHeightmapChunk_00000AE0_0024PostfixBurstDelegate(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris);

		internal static class GenerateHeightmapChunk_00000AE0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(GenerateHeightmapChunk_00000AE0_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static GenerateHeightmapChunk_00000AE0_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<float>, ref UnsafeSpan<bool>, int, int, int, int, int, int, int, ref UnsafeSpan<Vector3>, ref UnsafeSpan<int>, void>)functionPointer)(ref heights, ref holes, heightmapWidth, heightmapDepth, x0, z0, width, depth, stride, ref verts, ref tris);
						return;
					}
				}
				GenerateHeightmapChunk_0024BurstManaged(ref heights, ref holes, heightmapWidth, heightmapDepth, x0, z0, width, depth, stride, out verts, out tris);
			}
		}

		private readonly int terrainDownsamplingFactor;

		public readonly LayerMask mask;

		public readonly List<string> tagMask;

		private readonly float maxColliderApproximationError;

		public readonly Bounds bounds;

		public readonly Scene scene;

		private Dictionary<MeshCacheItem, int> cachedMeshes = new Dictionary<MeshCacheItem, int>();

		private readonly Dictionary<GameObject, TreeInfo> cachedTreePrefabs = new Dictionary<GameObject, TreeInfo>();

		private readonly List<NativeArray<Vector3>> vertexBuffers;

		private readonly List<NativeArray<int>> triangleBuffers;

		private readonly List<Mesh> meshData;

		private readonly RecastGraph.PerLayerModification[] modificationsByLayer;

		private readonly RecastGraph.PerLayerModification[] modificationsByLayer2D;

		private bool anyNonReadableMesh;

		private List<GatheredMesh> meshes;

		private List<Material> dummyMaterials = new List<Material>();

		private static readonly int[] BoxColliderTris = new int[36]
		{
			0, 1, 2, 0, 2, 3, 6, 5, 4, 7,
			6, 4, 0, 5, 1, 0, 4, 5, 1, 6,
			2, 1, 5, 6, 2, 7, 3, 2, 6, 7,
			3, 4, 0, 3, 7, 4
		};

		private static readonly Vector3[] BoxColliderVerts = new Vector3[8]
		{
			new Vector3(-1f, -1f, -1f),
			new Vector3(1f, -1f, -1f),
			new Vector3(1f, -1f, 1f),
			new Vector3(-1f, -1f, 1f),
			new Vector3(-1f, 1f, -1f),
			new Vector3(1f, 1f, -1f),
			new Vector3(1f, 1f, 1f),
			new Vector3(-1f, 1f, 1f)
		};

		public RecastMeshGatherer(Scene scene, Bounds bounds, int terrainDownsamplingFactor, LayerMask mask, List<string> tagMask, List<RecastGraph.PerLayerModification> perLayerModifications, float maxColliderApproximationError)
		{
			terrainDownsamplingFactor = Math.Max(terrainDownsamplingFactor, 1);
			this.bounds = bounds;
			this.terrainDownsamplingFactor = terrainDownsamplingFactor;
			this.mask = mask;
			this.tagMask = tagMask ?? new List<string>();
			this.maxColliderApproximationError = maxColliderApproximationError;
			this.scene = scene;
			meshes = ListPool<GatheredMesh>.Claim();
			vertexBuffers = ListPool<NativeArray<Vector3>>.Claim();
			triangleBuffers = ListPool<NativeArray<int>>.Claim();
			cachedMeshes = ObjectPoolSimple<Dictionary<MeshCacheItem, int>>.Claim();
			meshData = ListPool<Mesh>.Claim();
			modificationsByLayer = RecastGraph.PerLayerModification.ToLayerLookup(perLayerModifications, RecastGraph.PerLayerModification.Default);
			RecastGraph.PerLayerModification defaultValue = RecastGraph.PerLayerModification.Default;
			defaultValue.mode = RecastMeshObj.Mode.UnwalkableSurface;
			modificationsByLayer2D = RecastGraph.PerLayerModification.ToLayerLookup(perLayerModifications, defaultValue);
		}

		[BurstCompile]
		private static void CalculateBounds(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
		{
			CalculateBounds_00000ACF_0024BurstDirectCall.Invoke(ref vertices, ref localToWorldMatrix, out bounds);
		}

		public MeshCollection Finalize()
		{
			Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(meshData);
			NativeArray<RasterizationMesh> nativeArray = new NativeArray<RasterizationMesh>(meshes.Count, Allocator.Persistent);
			int count = vertexBuffers.Count;
			for (int i = 0; i < meshDataArray.Length; i++)
			{
				MeshUtility.GetMeshData(meshDataArray, i, out var vertices, out var indices);
				vertexBuffers.Add(vertices);
				triangleBuffers.Add(indices);
			}
			for (int j = 0; j < nativeArray.Length; j++)
			{
				GatheredMesh gatheredMesh = meshes[j];
				int index = ((gatheredMesh.meshDataIndex < 0) ? (-(gatheredMesh.meshDataIndex + 1)) : (count + gatheredMesh.meshDataIndex));
				Bounds bounds = gatheredMesh.bounds;
				UnsafeSpan<float3> vertices2 = vertexBuffers[index].Reinterpret<float3>().AsUnsafeReadOnlySpan();
				if (bounds == default(Bounds))
				{
					float4x4 localToWorldMatrix = gatheredMesh.matrix;
					CalculateBounds(ref vertices2, ref localToWorldMatrix, out bounds);
				}
				NativeArray<int> arr = triangleBuffers[index];
				nativeArray[j] = new RasterizationMesh
				{
					vertices = vertices2,
					triangles = arr.AsUnsafeSpan().Slice(gatheredMesh.indexStart, ((gatheredMesh.indexEnd != -1) ? gatheredMesh.indexEnd : arr.Length) - gatheredMesh.indexStart),
					area = gatheredMesh.area,
					areaIsTag = gatheredMesh.areaIsTag,
					bounds = bounds,
					matrix = gatheredMesh.matrix,
					solid = gatheredMesh.solid,
					doubleSided = gatheredMesh.doubleSided,
					flatten = gatheredMesh.flatten
				};
			}
			cachedMeshes.Clear();
			ObjectPoolSimple<Dictionary<MeshCacheItem, int>>.Release(ref cachedMeshes);
			ListPool<GatheredMesh>.Release(ref meshes);
			meshDataArray.Dispose();
			return new MeshCollection(vertexBuffers, triangleBuffers, nativeArray);
		}

		public int AddMeshBuffers(Vector3[] vertices, int[] triangles)
		{
			return AddMeshBuffers(new NativeArray<Vector3>(vertices, Allocator.Persistent), new NativeArray<int>(triangles, Allocator.Persistent));
		}

		public int AddMeshBuffers(NativeArray<Vector3> vertices, NativeArray<int> triangles)
		{
			int result = -vertexBuffers.Count - 1;
			vertexBuffers.Add(vertices);
			triangleBuffers.Add(triangles);
			return result;
		}

		public void AddMesh(Renderer renderer, Mesh gatheredMesh)
		{
			if (ConvertMeshToGatheredMesh(renderer, gatheredMesh, out var gatheredMesh2))
			{
				meshes.Add(gatheredMesh2);
			}
		}

		public void AddMesh(GatheredMesh gatheredMesh)
		{
			meshes.Add(gatheredMesh);
		}

		private bool MeshFilterShouldBeIncluded(MeshFilter filter)
		{
			if (filter.TryGetComponent<Renderer>(out var component) && filter.sharedMesh != null && component.enabled && (((1 << filter.gameObject.layer) & (int)mask) != 0 || (tagMask.Count > 0 && tagMask.Contains(filter.tag))) && (!filter.TryGetComponent<RecastMeshObj>(out var component2) || !component2.enabled))
			{
				return true;
			}
			return false;
		}

		private bool ConvertMeshToGatheredMesh(Renderer renderer, Mesh mesh, out GatheredMesh gatheredMesh)
		{
			if (!mesh.HasVertexAttribute(VertexAttribute.Position))
			{
				gatheredMesh = default(GatheredMesh);
				return false;
			}
			if (!mesh.isReadable)
			{
				if (!anyNonReadableMesh)
				{
					Debug.LogError("Some meshes could not be included when scanning the graph because they are marked as not readable. This includes the mesh '" + mesh.name + "'. You need to mark the mesh with read/write enabled in the mesh importer. Alternatively you can only rasterize colliders and not meshes. Mesh Collider meshes still need to be readable.", mesh);
				}
				anyNonReadableMesh = true;
				gatheredMesh = default(GatheredMesh);
				return false;
			}
			renderer.GetSharedMaterials(dummyMaterials);
			int num = ((renderer is MeshRenderer meshRenderer) ? meshRenderer.subMeshStartIndex : 0);
			int count = dummyMaterials.Count;
			int indexStart = 0;
			int indexEnd = -1;
			if (num > 0 || count < mesh.subMeshCount)
			{
				SubMeshDescriptor subMesh = mesh.GetSubMesh(num);
				SubMeshDescriptor subMesh2 = mesh.GetSubMesh(num + count - 1);
				indexStart = subMesh.indexStart;
				indexEnd = subMesh2.indexStart + subMesh2.indexCount;
			}
			if (!cachedMeshes.TryGetValue(new MeshCacheItem(mesh), out var value))
			{
				value = meshData.Count;
				meshData.Add(mesh);
				cachedMeshes[new MeshCacheItem(mesh)] = value;
			}
			gatheredMesh = new GatheredMesh
			{
				meshDataIndex = value,
				bounds = renderer.bounds,
				indexStart = indexStart,
				indexEnd = indexEnd,
				matrix = renderer.localToWorldMatrix,
				doubleSided = false,
				flatten = false
			};
			return true;
		}

		private GatheredMesh? GetColliderMesh(MeshCollider collider, Matrix4x4 localToWorldMatrix)
		{
			if (collider.sharedMesh != null)
			{
				Mesh sharedMesh = collider.sharedMesh;
				if (!sharedMesh.HasVertexAttribute(VertexAttribute.Position))
				{
					return null;
				}
				if (!sharedMesh.isReadable)
				{
					if (!anyNonReadableMesh)
					{
						Debug.LogError("Some mesh collider meshes could not be included when scanning the graph because they are marked as not readable. This includes the mesh '" + sharedMesh.name + "'. You need to mark the mesh with read/write enabled in the mesh importer.", sharedMesh);
					}
					anyNonReadableMesh = true;
					return null;
				}
				if (!cachedMeshes.TryGetValue(new MeshCacheItem(sharedMesh), out var value))
				{
					value = meshData.Count;
					meshData.Add(sharedMesh);
					cachedMeshes[new MeshCacheItem(sharedMesh)] = value;
				}
				return new GatheredMesh
				{
					meshDataIndex = value,
					bounds = collider.bounds,
					areaIsTag = false,
					area = 0,
					indexStart = 0,
					indexEnd = -1,
					solid = collider.convex,
					matrix = localToWorldMatrix,
					doubleSided = false,
					flatten = false
				};
			}
			return null;
		}

		public void CollectSceneMeshes()
		{
			if (tagMask.Count <= 0 && (int)mask == 0)
			{
				return;
			}
			MeshFilter[] array = UnityCompatibility.FindObjectsByTypeSorted<MeshFilter>();
			bool flag = false;
			foreach (MeshFilter meshFilter in array)
			{
				if (MeshFilterShouldBeIncluded(meshFilter))
				{
					meshFilter.TryGetComponent<Renderer>(out var component);
					GatheredMesh gatheredMesh;
					if (component.isPartOfStaticBatch)
					{
						flag = true;
					}
					else if (component.bounds.Intersects(bounds) && ConvertMeshToGatheredMesh(component, meshFilter.sharedMesh, out gatheredMesh))
					{
						gatheredMesh.ApplyLayerModification(modificationsByLayer[meshFilter.gameObject.layer]);
						meshes.Add(gatheredMesh);
					}
				}
			}
			if (flag)
			{
				Debug.LogWarning("Some meshes were statically batched. These meshes can not be used for navmesh calculation due to technical constraints.\nDuring runtime scripts cannot access the data of meshes which have been statically batched.\nOne way to solve this problem is to use cached startup (Save & Load tab in the inspector) to only calculate the graph when the game is not playing.");
			}
		}

		private static int AreaFromSurfaceMode(RecastMeshObj.Mode mode, int surfaceID)
		{
			switch (mode)
			{
			default:
				return -1;
			case RecastMeshObj.Mode.WalkableSurface:
				return 0;
			case RecastMeshObj.Mode.WalkableSurfaceWithSeam:
			case RecastMeshObj.Mode.WalkableSurfaceWithTag:
				return surfaceID;
			}
		}

		public void CollectRecastMeshObjs()
		{
			List<RecastMeshObj> list = ListPool<RecastMeshObj>.Claim();
			RecastMeshObj.GetAllInBounds(list, bounds);
			for (int i = 0; i < list.Count; i++)
			{
				AddRecastMeshObj(list[i]);
			}
			ListPool<RecastMeshObj>.Release(ref list);
		}

		private void AddRecastMeshObj(RecastMeshObj recastMeshObj)
		{
			if (recastMeshObj.includeInScan == RecastMeshObj.ScanInclusion.AlwaysExclude || (recastMeshObj.includeInScan == RecastMeshObj.ScanInclusion.Auto && (((int)mask >> recastMeshObj.gameObject.layer) & 1) == 0 && !tagMask.Contains(recastMeshObj.tag)))
			{
				return;
			}
			recastMeshObj.ResolveMeshSource(out var meshFilter, out var collider, out var collider2D);
			if (meshFilter != null)
			{
				Mesh sharedMesh = meshFilter.sharedMesh;
				if (meshFilter.TryGetComponent<MeshRenderer>(out var component) && sharedMesh != null && ConvertMeshToGatheredMesh(component, meshFilter.sharedMesh, out var gatheredMesh))
				{
					gatheredMesh.ApplyRecastMeshObj(recastMeshObj);
					meshes.Add(gatheredMesh);
				}
			}
			else if (collider != null)
			{
				GatheredMesh? gatheredMesh2 = ConvertColliderToGatheredMesh(collider);
				if (gatheredMesh2.HasValue)
				{
					GatheredMesh valueOrDefault = gatheredMesh2.GetValueOrDefault();
					valueOrDefault.ApplyRecastMeshObj(recastMeshObj);
					meshes.Add(valueOrDefault);
				}
			}
			else if (!(collider2D != null))
			{
				if (recastMeshObj.geometrySource == RecastMeshObj.GeometrySource.Auto)
				{
					Debug.LogError("Couldn't get geometry source for RecastMeshObject (" + recastMeshObj.gameObject.name + "). It didn't have a collider or MeshFilter+Renderer attached", recastMeshObj.gameObject);
					return;
				}
				Debug.LogError("Couldn't get geometry source for RecastMeshObject (" + recastMeshObj.gameObject.name + "). It didn't have a " + recastMeshObj.geometrySource.ToString() + " attached", recastMeshObj.gameObject);
			}
		}

		public void CollectTerrainMeshes(bool rasterizeTrees, float desiredChunkSize)
		{
			Terrain[] activeTerrains = Terrain.activeTerrains;
			if (activeTerrains.Length == 0)
			{
				return;
			}
			for (int i = 0; i < activeTerrains.Length; i++)
			{
				if (!(activeTerrains[i].terrainData == null))
				{
					bool flag = GenerateTerrainChunks(activeTerrains[i], bounds, desiredChunkSize);
					if (rasterizeTrees && flag)
					{
						CollectTreeMeshes(activeTerrains[i]);
					}
				}
			}
		}

		private static int NonNegativeModulus(int x, int m)
		{
			int num = x % m;
			if (num >= 0)
			{
				return num;
			}
			return num + m;
		}

		private static int CeilDivision(int lhs, int rhs)
		{
			return (lhs + rhs - 1) / rhs;
		}

		private bool GenerateTerrainChunks(Terrain terrain, Bounds bounds, float desiredChunkSize)
		{
			TerrainData terrainData = terrain.terrainData;
			if (terrainData == null)
			{
				throw new ArgumentException("Terrain contains no terrain data");
			}
			Vector3 position = terrain.GetPosition();
			Vector3 size = terrainData.size;
			Vector3 center = position + size * 0.5f;
			if (!new Bounds(center, size).Intersects(bounds))
			{
				return false;
			}
			int heightmapResolution = terrainData.heightmapResolution;
			int heightmapResolution2 = terrainData.heightmapResolution;
			Vector3 heightmapScale = terrainData.heightmapScale;
			heightmapScale.y = size.y;
			int a = Mathf.CeilToInt(Mathf.Max(desiredChunkSize / (heightmapScale.x * (float)terrainDownsamplingFactor), 12f)) * terrainDownsamplingFactor;
			int a2 = Mathf.CeilToInt(Mathf.Max(desiredChunkSize / (heightmapScale.z * (float)terrainDownsamplingFactor), 12f)) * terrainDownsamplingFactor;
			a = Mathf.Min(a, heightmapResolution);
			a2 = Mathf.Min(a2, heightmapResolution2);
			Int2 offset;
			Int2 int5;
			if (float.IsFinite(bounds.size.x))
			{
				offset = new Int2(Mathf.FloorToInt((bounds.min.x - position.x) / heightmapScale.x), Mathf.FloorToInt((bounds.min.z - position.z) / heightmapScale.z));
				offset.x -= NonNegativeModulus(offset.x, terrainDownsamplingFactor);
				offset.y -= NonNegativeModulus(offset.y, terrainDownsamplingFactor);
				float num = (float)a * heightmapScale.x;
				float num2 = (float)a2 * heightmapScale.z;
				int5 = new Int2(Mathf.CeilToInt((bounds.max.x - position.x - (float)offset.x * heightmapScale.x) / num), Mathf.CeilToInt((bounds.max.z - position.z - (float)offset.y * heightmapScale.z) / num2));
			}
			else
			{
				offset = new Int2(0, 0);
				int5 = new Int2(CeilDivision(heightmapResolution, a), CeilDivision(heightmapResolution2, a2));
			}
			IntRect a3 = new IntRect(0, 0, int5.x * a - 1, int5.y * a2 - 1).Offset(offset);
			IntRect b = new IntRect(0, 0, heightmapResolution - 1, heightmapResolution2 - 1);
			a3 = IntRect.Intersection(a3, b);
			if (!a3.IsValid())
			{
				return false;
			}
			int5 = new Int2(CeilDivision(a3.Width, a), CeilDivision(a3.Height, a2));
			float[,] heights = terrainData.GetHeights(a3.xmin, a3.ymin, a3.Width, a3.Height);
			bool[,] holes = terrainData.GetHoles(a3.xmin, a3.ymin, a3.Width - 1, a3.Height - 1);
			ulong gcHandle;
			UnsafeSpan<float> heights2 = new UnsafeSpan<float>(heights, out gcHandle);
			ulong gcHandle2;
			UnsafeSpan<bool> holes2 = new UnsafeSpan<bool>(holes, out gcHandle2);
			Matrix4x4 matrix = Matrix4x4.TRS(position + new Vector3((float)a3.xmin * heightmapScale.x, 0f, (float)a3.ymin * heightmapScale.z), Quaternion.identity, heightmapScale);
			for (int i = 0; i < int5.y; i++)
			{
				for (int j = 0; j < int5.x; j++)
				{
					GenerateHeightmapChunk(ref heights2, ref holes2, a3.Width, a3.Height, j * a, i * a2, a, a2, terrainDownsamplingFactor, out var verts, out var tris);
					NativeArray<Vector3> vertices = verts.MoveToNativeArray(Allocator.Persistent);
					NativeArray<int> triangles = tris.MoveToNativeArray(Allocator.Persistent);
					int meshDataIndex = AddMeshBuffers(vertices, triangles);
					GatheredMesh item = new GatheredMesh
					{
						meshDataIndex = meshDataIndex,
						bounds = default(Bounds),
						indexStart = 0,
						indexEnd = -1,
						areaIsTag = false,
						area = 0,
						solid = false,
						matrix = matrix,
						doubleSided = false,
						flatten = false
					};
					item.ApplyLayerModification(modificationsByLayer[terrain.gameObject.layer]);
					meshes.Add(item);
				}
			}
			UnsafeUtility.ReleaseGCObject(gcHandle);
			UnsafeUtility.ReleaseGCObject(gcHandle2);
			return true;
		}

		[BurstCompile]
		public static void GenerateHeightmapChunk(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris)
		{
			GenerateHeightmapChunk_00000AE0_0024BurstDirectCall.Invoke(ref heights, ref holes, heightmapWidth, heightmapDepth, x0, z0, width, depth, stride, out verts, out tris);
		}

		private void CollectTreeMeshes(Terrain terrain)
		{
			TerrainData terrainData = terrain.terrainData;
			TreeInstance[] treeInstances = terrainData.treeInstances;
			TreePrototype[] treePrototypes = terrainData.treePrototypes;
			Vector3 position = terrain.transform.position;
			Vector3 size = terrainData.size;
			TreeInfo[] array = new TreeInfo[treePrototypes.Length];
			for (int i = 0; i < treePrototypes.Length; i++)
			{
				TreePrototype treePrototype = treePrototypes[i];
				if (treePrototype.prefab == null)
				{
					continue;
				}
				if (!cachedTreePrefabs.TryGetValue(treePrototype.prefab, out var value))
				{
					value.submeshes = new List<GatheredMesh>();
					value.supportsRotation = treePrototype.prefab.TryGetComponent<LODGroup>(out var _);
					value.localScale = treePrototype.prefab.transform.localScale;
					List<Collider> list = ListPool<Collider>.Claim();
					Matrix4x4 inverse = treePrototype.prefab.transform.localToWorldMatrix.inverse;
					treePrototype.prefab.GetComponentsInChildren(includeInactive: false, list);
					for (int j = 0; j < list.Count; j++)
					{
						Collider collider = list[j];
						GatheredMesh? gatheredMesh = ConvertColliderToGatheredMesh(collider, inverse * collider.transform.localToWorldMatrix);
						if (!gatheredMesh.HasValue)
						{
							continue;
						}
						GatheredMesh valueOrDefault = gatheredMesh.GetValueOrDefault();
						if (collider.gameObject.TryGetComponent<RecastMeshObj>(out var component2) && component2.enabled)
						{
							if (component2.includeInScan == RecastMeshObj.ScanInclusion.AlwaysExclude)
							{
								continue;
							}
							valueOrDefault.ApplyRecastMeshObj(component2);
						}
						else
						{
							valueOrDefault.ApplyLayerModification(modificationsByLayer[collider.gameObject.layer]);
						}
						valueOrDefault.RecalculateBounds();
						value.submeshes.Add(valueOrDefault);
					}
					ListPool<Collider>.Release(ref list);
					cachedTreePrefabs[treePrototype.prefab] = value;
				}
				array[i] = value;
			}
			for (int k = 0; k < treeInstances.Length; k++)
			{
				TreeInstance treeInstance = treeInstances[k];
				TreeInfo treeInfo = array[treeInstance.prototypeIndex];
				if (treeInfo.submeshes != null && treeInfo.submeshes.Count != 0)
				{
					Vector3 pos = position + Vector3.Scale(treeInstance.position, size);
					Vector3 s = Vector3.Scale(new Vector3(treeInstance.widthScale, treeInstance.heightScale, treeInstance.widthScale), treeInfo.localScale);
					Quaternion q = (treeInfo.supportsRotation ? Quaternion.AngleAxis(treeInstance.rotation * 57.29578f, Vector3.up) : Quaternion.identity);
					Matrix4x4 matrix4x = Matrix4x4.TRS(pos, q, s);
					for (int l = 0; l < treeInfo.submeshes.Count; l++)
					{
						GatheredMesh item = treeInfo.submeshes[l];
						item.matrix = matrix4x * item.matrix;
						meshes.Add(item);
					}
				}
			}
		}

		private bool ShouldIncludeCollider(Collider collider)
		{
			if (!collider.enabled || collider.isTrigger || !collider.bounds.Intersects(bounds) || (collider.TryGetComponent<RecastMeshObj>(out var component) && component.enabled))
			{
				return false;
			}
			GameObject gameObject = collider.gameObject;
			if ((((int)mask >> gameObject.layer) & 1) != 0)
			{
				return true;
			}
			for (int i = 0; i < tagMask.Count; i++)
			{
				if (gameObject.CompareTag(tagMask[i]))
				{
					return true;
				}
			}
			return false;
		}

		public void CollectColliderMeshes()
		{
			if (tagMask.Count == 0 && (int)mask == 0)
			{
				return;
			}
			PhysicsScene physicsScene = scene.GetPhysicsScene();
			int num = 256;
			Collider[] array = null;
			bool flag = math.all(math.isfinite(bounds.extents));
			if (!flag)
			{
				array = UnityCompatibility.FindObjectsByTypeSorted<Collider>();
				num = array.Length;
			}
			else
			{
				do
				{
					if (array != null)
					{
						ArrayPool<Collider>.Release(ref array);
					}
					array = ArrayPool<Collider>.Claim(num * 4);
					num = physicsScene.OverlapBox(bounds.center, bounds.extents, array, Quaternion.identity, -1, QueryTriggerInteraction.Ignore);
				}
				while (num == array.Length);
			}
			for (int i = 0; i < num; i++)
			{
				Collider collider = array[i];
				if (ShouldIncludeCollider(collider))
				{
					GatheredMesh? gatheredMesh = ConvertColliderToGatheredMesh(collider);
					if (gatheredMesh.HasValue)
					{
						GatheredMesh valueOrDefault = gatheredMesh.GetValueOrDefault();
						valueOrDefault.ApplyLayerModification(modificationsByLayer[collider.gameObject.layer]);
						meshes.Add(valueOrDefault);
					}
				}
			}
			if (flag)
			{
				ArrayPool<Collider>.Release(ref array);
			}
		}

		private GatheredMesh? ConvertColliderToGatheredMesh(Collider col)
		{
			return ConvertColliderToGatheredMesh(col, col.transform.localToWorldMatrix);
		}

		public GatheredMesh? ConvertColliderToGatheredMesh(Collider col, Matrix4x4 localToWorldMatrix)
		{
			if (col is BoxCollider collider)
			{
				return RasterizeBoxCollider(collider, localToWorldMatrix);
			}
			if (col is SphereCollider || col is CapsuleCollider)
			{
				SphereCollider sphereCollider = col as SphereCollider;
				CapsuleCollider capsuleCollider = col as CapsuleCollider;
				float num = ((sphereCollider != null) ? sphereCollider.radius : capsuleCollider.radius);
				float height = ((sphereCollider != null) ? 0f : (capsuleCollider.height * 0.5f / num - 1f));
				Quaternion q = Quaternion.identity;
				if (capsuleCollider != null)
				{
					q = Quaternion.Euler((capsuleCollider.direction == 2) ? 90 : 0, 0f, (capsuleCollider.direction == 0) ? 90 : 0);
				}
				Matrix4x4 matrix4x = Matrix4x4.TRS((sphereCollider != null) ? sphereCollider.center : capsuleCollider.center, q, Vector3.one * num);
				matrix4x = localToWorldMatrix * matrix4x;
				return RasterizeCapsuleCollider(num, height, col.bounds, matrix4x);
			}
			if (col is MeshCollider collider2)
			{
				return GetColliderMesh(collider2, localToWorldMatrix);
			}
			return null;
		}

		private GatheredMesh RasterizeBoxCollider(BoxCollider collider, Matrix4x4 localToWorldMatrix)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(collider.center, Quaternion.identity, collider.size * 0.5f);
			matrix4x = localToWorldMatrix * matrix4x;
			if (!cachedMeshes.TryGetValue(MeshCacheItem.Box, out var value))
			{
				value = AddMeshBuffers(BoxColliderVerts, BoxColliderTris);
				cachedMeshes[MeshCacheItem.Box] = value;
			}
			return new GatheredMesh
			{
				meshDataIndex = value,
				bounds = collider.bounds,
				indexStart = 0,
				indexEnd = -1,
				areaIsTag = false,
				area = 0,
				solid = true,
				matrix = matrix4x,
				doubleSided = false,
				flatten = false
			};
		}

		private static int CircleSteps(Matrix4x4 matrix, float radius, float maxError)
		{
			float num = math.sqrt(math.max(math.max(math.lengthsq((Vector3)matrix.GetColumn(0)), math.lengthsq((Vector3)matrix.GetColumn(1))), math.lengthsq((Vector3)matrix.GetColumn(2))));
			float num2 = radius * num;
			float num3 = 1f - maxError / num2;
			if (!(num3 < 0f))
			{
				return (int)math.ceil(MathF.PI / math.acos(num3));
			}
			return 3;
		}

		private static float CircleRadiusAdjustmentFactor(int steps)
		{
			return 0.5f * (1f - math.cos(MathF.PI * 2f / (float)steps));
		}

		private GatheredMesh RasterizeCapsuleCollider(float radius, float height, Bounds bounds, Matrix4x4 localToWorldMatrix)
		{
			int num = CircleSteps(localToWorldMatrix, radius, maxColliderApproximationError);
			int num2 = num;
			MeshCacheItem key = new MeshCacheItem
			{
				type = MeshType.Capsule,
				mesh = null,
				rows = num,
				quantizedHeight = Mathf.RoundToInt(height / maxColliderApproximationError)
			};
			if (!cachedMeshes.TryGetValue(key, out var value))
			{
				NativeArray<Vector3> vertices = new NativeArray<Vector3>(num * num2 + 2, Allocator.Persistent);
				NativeArray<int> triangles = new NativeArray<int>(num * num2 * 2 * 3, Allocator.Persistent);
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < num2; j++)
					{
						vertices[j + i * num2] = new Vector3(Mathf.Cos((float)j * MathF.PI * 2f / (float)num2) * Mathf.Sin((float)i * MathF.PI / (float)(num - 1)), Mathf.Cos((float)i * MathF.PI / (float)(num - 1)) + ((i < num / 2) ? height : (0f - height)), Mathf.Sin((float)j * MathF.PI * 2f / (float)num2) * Mathf.Sin((float)i * MathF.PI / (float)(num - 1)));
					}
				}
				vertices[vertices.Length - 1] = Vector3.up;
				vertices[vertices.Length - 2] = Vector3.down;
				int num3 = 0;
				int num4 = 0;
				int value2 = num2 - 1;
				while (num4 < num2)
				{
					triangles[num3] = vertices.Length - 1;
					triangles[num3 + 1] = value2;
					triangles[num3 + 2] = num4;
					num3 += 3;
					value2 = num4++;
				}
				for (int k = 1; k < num; k++)
				{
					int num5 = 0;
					int num6 = num2 - 1;
					while (num5 < num2)
					{
						triangles[num3] = k * num2 + num5;
						triangles[num3 + 1] = k * num2 + num6;
						triangles[num3 + 2] = (k - 1) * num2 + num5;
						num3 += 3;
						triangles[num3] = (k - 1) * num2 + num6;
						triangles[num3 + 1] = (k - 1) * num2 + num5;
						triangles[num3 + 2] = k * num2 + num6;
						num3 += 3;
						num6 = num5++;
					}
				}
				int num7 = 0;
				int num8 = num2 - 1;
				while (num7 < num2)
				{
					triangles[num3] = vertices.Length - 2;
					triangles[num3 + 1] = (num - 1) * num2 + num8;
					triangles[num3 + 2] = (num - 1) * num2 + num7;
					num3 += 3;
					num8 = num7++;
				}
				value = AddMeshBuffers(vertices, triangles);
				cachedMeshes[key] = value;
			}
			return new GatheredMesh
			{
				meshDataIndex = value,
				bounds = bounds,
				areaIsTag = false,
				area = 0,
				indexStart = 0,
				indexEnd = -1,
				solid = true,
				matrix = localToWorldMatrix,
				doubleSided = false,
				flatten = false
			};
		}

		private bool ShouldIncludeCollider2D(Collider2D collider)
		{
			if ((((int)mask >> collider.gameObject.layer) & 1) != 0)
			{
				return true;
			}
			if (((Component)(((object)collider.attachedRigidbody) ?? ((object)collider))).TryGetComponent(out RecastMeshObj component) && component.enabled && component.includeInScan == RecastMeshObj.ScanInclusion.AlwaysInclude)
			{
				return true;
			}
			for (int i = 0; i < tagMask.Count; i++)
			{
				if (collider.CompareTag(tagMask[i]))
				{
					return true;
				}
			}
			return false;
		}

		public void Collect2DColliderMeshes()
		{
			if (tagMask.Count == 0 && (int)mask == 0)
			{
				return;
			}
			PhysicsScene2D physicsScene2D = scene.GetPhysicsScene2D();
			int num = 256;
			Collider2D[] array = null;
			bool flag = math.isfinite(bounds.extents.x) && math.isfinite(bounds.extents.y);
			if (!flag)
			{
				array = UnityCompatibility.FindObjectsByTypeSorted<Collider2D>();
				num = array.Length;
			}
			else
			{
				Vector2 pointA = bounds.min;
				Vector2 pointB = bounds.max;
				ContactFilter2D contactFilter = default(ContactFilter2D).NoFilter();
				contactFilter.useTriggers = false;
				do
				{
					if (array != null)
					{
						ArrayPool<Collider2D>.Release(ref array);
					}
					array = ArrayPool<Collider2D>.Claim(num * 4);
					num = physicsScene2D.OverlapArea(pointA, pointB, contactFilter, array);
				}
				while (num == array.Length);
			}
			for (int i = 0; i < num; i++)
			{
				if (!ShouldIncludeCollider2D(array[i]))
				{
					array[i] = null;
				}
			}
			NativeArray<float3> outputVertices;
			NativeArray<int> outputIndices;
			NativeArray<ColliderMeshBuilder2D.ShapeMesh> outputShapeMeshes;
			int num2 = ColliderMeshBuilder2D.GenerateMeshesFromColliders(array, num, maxColliderApproximationError, out outputVertices, out outputIndices, out outputShapeMeshes);
			int meshDataIndex = AddMeshBuffers(outputVertices.Reinterpret<Vector3>(), outputIndices);
			for (int j = 0; j < num2; j++)
			{
				ColliderMeshBuilder2D.ShapeMesh shapeMesh = outputShapeMeshes[j];
				if (!bounds.Intersects(shapeMesh.bounds))
				{
					continue;
				}
				Collider2D collider2D = array[shapeMesh.tag];
				((Component)(((object)collider2D.attachedRigidbody) ?? ((object)collider2D))).TryGetComponent(out RecastMeshObj component);
				GatheredMesh item = new GatheredMesh
				{
					meshDataIndex = meshDataIndex,
					bounds = shapeMesh.bounds,
					indexStart = shapeMesh.startIndex,
					indexEnd = shapeMesh.endIndex,
					areaIsTag = false,
					area = -1,
					solid = false,
					matrix = shapeMesh.matrix,
					doubleSided = true,
					flatten = true
				};
				if (component != null)
				{
					if (component.includeInScan == RecastMeshObj.ScanInclusion.AlwaysExclude)
					{
						continue;
					}
					item.ApplyRecastMeshObj(component);
				}
				else
				{
					item.ApplyLayerModification(modificationsByLayer2D[collider2D.gameObject.layer]);
				}
				item.solid = false;
				meshes.Add(item);
			}
			if (flag)
			{
				ArrayPool<Collider2D>.Release(ref array);
			}
			outputShapeMeshes.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void CalculateBounds_0024BurstManaged(ref UnsafeSpan<float3> vertices, ref float4x4 localToWorldMatrix, out Bounds bounds)
		{
			if (vertices.Length == 0)
			{
				bounds = default(Bounds);
				return;
			}
			float3 float5 = float.NegativeInfinity;
			float3 float6 = float.PositiveInfinity;
			for (uint num = 0u; num < vertices.Length; num++)
			{
				float3 y = math.transform(localToWorldMatrix, vertices[num]);
				float5 = math.max(float5, y);
				float6 = math.min(float6, y);
			}
			bounds = new Bounds((float6 + float5) * 0.5f, float5 - float6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void GenerateHeightmapChunk_0024BurstManaged(ref UnsafeSpan<float> heights, ref UnsafeSpan<bool> holes, int heightmapWidth, int heightmapDepth, int x0, int z0, int width, int depth, int stride, out UnsafeSpan<Vector3> verts, out UnsafeSpan<int> tris)
		{
			int num = CeilDivision(Mathf.Min(width, heightmapWidth - x0), stride) + 1;
			int num2 = CeilDivision(Mathf.Min(depth, heightmapDepth - z0), stride) + 1;
			int length = num * num2;
			int length2 = (num - 1) * (num2 - 1) * 2 * 3;
			verts = new UnsafeSpan<Vector3>(Allocator.Persistent, length);
			tris = new UnsafeSpan<int>(Allocator.Persistent, length2);
			for (int i = 0; i < num2; i++)
			{
				int num3 = Math.Min(z0 + i * stride, heightmapDepth - 1);
				for (int j = 0; j < num; j++)
				{
					int num4 = Math.Min(x0 + j * stride, heightmapWidth - 1);
					verts[i * num + j] = new Vector3(num4, heights[num3 * heightmapWidth + num4], num3);
				}
			}
			int num5 = 0;
			for (int k = 0; k < num2 - 1; k++)
			{
				for (int l = 0; l < num - 1; l++)
				{
					int num6 = Math.Min(x0 + stride / 2 + l * stride, heightmapWidth - 2);
					int num7 = Math.Min(z0 + stride / 2 + k * stride, heightmapDepth - 2);
					if (holes[num7 * (heightmapWidth - 1) + num6])
					{
						tris[num5] = k * num + l;
						tris[num5 + 1] = (k + 1) * num + l + 1;
						tris[num5 + 2] = k * num + l + 1;
						num5 += 3;
						tris[num5] = k * num + l;
						tris[num5 + 1] = (k + 1) * num + l;
						tris[num5 + 2] = (k + 1) * num + l + 1;
						num5 += 3;
					}
				}
			}
			tris = tris.Slice(0, num5);
		}
	}
}
