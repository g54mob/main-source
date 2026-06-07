using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Digger.Modules.Core.Sources.Generators;
using Digger.Modules.Core.Sources.Polygonizers;
using Digger.Modules.Core.Sources.TerrainInterface;
using Digger.Modules.Core.Sources.Versioning;
using Digger.Modules.Core.Sources.VoxelPhysics;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Digger.Modules.Core.Sources
{
	public class DiggerSystem : MonoBehaviour
	{
		public const int DiggerVersion = 80000;

		public const string VoxelFileExtension = "vox3";

		public const string VoxelMetadataFileExtension = "vom";

		public const string LabelFileExtension = "labels";

		private const string VersionFileExtension = "ver";

		private const int UndoStackSize = 15;

		private Dictionary<Vector3i, Chunk> chunks;

		private HashSet<VoxelChunk> chunksToPersist;

		private readonly Dictionary<Vector3i, Chunk> builtChunks = new Dictionary<Vector3i, Chunk>(new Vector3iComparer());

		private readonly Dictionary<Vector3i, Chunk> missingBuiltChunks = new Dictionary<Vector3i, Chunk>(new Vector3iComparer());

		private readonly Dictionary<Vector3i, Chunk> chunksPendingForMeshBuild = new Dictionary<Vector3i, Chunk>(new Vector3iComparer());

		private readonly List<LinkLabelOfNeighborChunksXJobData> linkLabelOfNeighborChunksXJobs = new List<LinkLabelOfNeighborChunksXJobData>();

		private readonly List<LinkLabelOfNeighborChunksYJobData> linkLabelOfNeighborChunksYJobs = new List<LinkLabelOfNeighborChunksYJobData>();

		private readonly List<LinkLabelOfNeighborChunksZJobData> linkLabelOfNeighborChunksZJobs = new List<LinkLabelOfNeighborChunksZJobData>();

		private readonly HashSet<int3> surfaceChunkPositionsOnHoles = new HashSet<int3>();

		private bool disablePersistence;

		private Bounds bounds;

		private bool needRecordUndo;

		private HeightsFeeder heightsFeeder;

		private NormalsFeeder normalsFeeder;

		private AlphamapsFeeder alphamapsFeeder;

		private APolygonizerProvider polygonizerProvider;

		[SerializeField]
		private DiggerMaster master;

		[SerializeField]
		private string guid;

		[SerializeField]
		private long version = 1L;

		[SerializeField]
		private string basePathData;

		[SerializeField]
		private TerrainCutter cutter;

		[SerializeField]
		private Vector3 heightmapScale;

		[SerializeField]
		private int2 alphamapsSize;

		[SerializeField]
		private Vector2 uvScale;

		[SerializeField]
		private Vector3 holeMapScale;

		[SerializeField]
		public Terrain Terrain;

		[SerializeField]
		public Material[] Materials;

		[SerializeField]
		private TerrainMaterialType materialType;

		[SerializeField]
		private Texture2D[] terrainTextures;

		[SerializeField]
		private Vector3i[] chunksInStreamingAssets;

		[SerializeField]
		private string persistenceSubPath;

		[SerializeField]
		public bool ShowDebug;

		[SerializeField]
		public UnityEvent<ChunkObject> onChunkObjectCreated;

		private readonly Dictionary<Vector3i, HashSet<int>> connectedLabels = new Dictionary<Vector3i, HashSet<int>>(new Vector3iComparer());

		private readonly Dictionary<Vector3i, HashSet<int>> visitedLabels = new Dictionary<Vector3i, HashSet<int>>(new Vector3iComparer());

		private bool connectedLabelsAreConnectedToTheGround;

		private ConnectedComponentLabeling.AABB connectedLabelsAABB;

		private readonly HashSet<Vector3i> chunksWithFloatingVoxels = new HashSet<Vector3i>(new Vector3iComparer());

		public string Guid
		{
			get
			{
				return guid;
			}
			set
			{
				guid = value;
			}
		}

		public HeightsFeeder HeightsFeeder => heightsFeeder;

		public NormalsFeeder NormalsFeeder => normalsFeeder;

		public AlphamapsFeeder AlphamapsFeeder => alphamapsFeeder;

		public APolygonizerProvider PolygonizerProvider => polygonizerProvider;

		public IVoxelGenerator VoxelGenerator => master.VoxelGenerator;

		public Vector3 HeightmapScale => heightmapScale;

		public int2 AlphamapsSize => alphamapsSize;

		public Vector2 UVScale => uvScale;

		public Vector3 HoleMapScale => holeMapScale;

		public Vector3 CutMargin => new Vector3(Math.Max(2f, 2.1f * holeMapScale.x), Math.Max(2f, 2.1f * holeMapScale.y), Math.Max(2f, 2.1f * holeMapScale.z));

		public TerrainCutter Cutter => cutter;

		public Texture2D[] TerrainTextures
		{
			get
			{
				return terrainTextures;
			}
			set
			{
				terrainTextures = value;
			}
		}

		public float ScreenRelativeTransitionHeightLod0 => master.ScreenRelativeTransitionHeightLod0;

		public float ScreenRelativeTransitionHeightLod1 => master.ScreenRelativeTransitionHeightLod1;

		public int ColliderLodIndex => master.ColliderLodIndex;

		public bool CreateLODs => master.CreateLODs;

		public int LODCount
		{
			get
			{
				if (!master.CreateLODs)
				{
					return 1;
				}
				return 3;
			}
		}

		private int Layer => master.Layer;

		private string Tag => master.ChunksTag;

		public bool EnableOcclusionCulling => master.EnableOcclusionCulling;

		public bool EnableContributeGI => master.EnableContributeGI;

		public int SizeOfMesh => master.SizeOfMesh;

		public int SizeVox => master.SizeVox;

		public int ResolutionMult => master.ResolutionMult;

		public bool AutoVoxelHeight => master.AutoVoxelHeight;

		public float VoxelHeight => master.VoxelHeight;

		public bool ForceMicroSplatMaterialAssetUpdate => master.ForceMicroSplatMaterialAssetUpdate;

		public bool AutoRemoveFloatingVoxels => master.AutoRemoveFloatingVoxels;

		public int MaxFloatingVoxelGroupSizeToRemove => master.MaxFloatingVoxelGroupSizeToRemove;

		public int DefaultNavMeshArea { get; set; }

		public TerrainMaterialType MaterialType
		{
			get
			{
				return materialType;
			}
			set
			{
				materialType = value;
			}
		}

		private string BaseFolder => guid ?? "";

		public string BasePathData
		{
			get
			{
				if (string.IsNullOrEmpty(basePathData))
				{
					basePathData = ComputeBasePathData();
				}
				return basePathData;
			}
		}

		public string InternalPathData => Path.Combine(BasePathData, ".internal");

		public string MeshesPathData => Path.Combine(BasePathData, "meshes");

		public string StreamingAssetsPathData => Path.Combine(Application.streamingAssetsPath, "DiggerData", BaseFolder);

		public string PersistentRuntimePathData
		{
			get
			{
				if (!string.IsNullOrEmpty(persistenceSubPath))
				{
					return Path.Combine(Application.persistentDataPath, "DiggerData", persistenceSubPath, BaseFolder);
				}
				return Path.Combine(Application.persistentDataPath, "DiggerData", BaseFolder);
			}
		}

		public long Version => version;

		public long PreviousVersion => version - 1;

		public int TerrainChunkWidth => Terrain.terrainData.heightmapResolution * master.ResolutionMult / SizeOfMesh - 1;

		public int TerrainChunkHeight => Terrain.terrainData.heightmapResolution * master.ResolutionMult / SizeOfMesh - 1;

		public bool IsInitialized
		{
			get
			{
				if (Terrain != null && master != null && chunks != null && cutter != null && heightsFeeder != null && normalsFeeder != null && alphamapsFeeder != null && chunksToPersist != null)
				{
					return polygonizerProvider != null;
				}
				return false;
			}
		}

		public Bounds Bounds => bounds;

		public string PersistenceSubPath
		{
			get
			{
				return persistenceSubPath;
			}
			set
			{
				persistenceSubPath = value;
			}
		}

		public static bool SkipPersistedDataOnRead { get; set; }

		public string TerrainHolesRuntimePath => Path.Combine(PersistentRuntimePathData, "terrain.holes");

		private bool CanUndo
		{
			get
			{
				if (Application.isEditor && (bool)Terrain && (bool)cutter && Directory.Exists(InternalPathData))
				{
					return File.Exists(GetPathVersionFile(PreviousVersion));
				}
				return false;
			}
		}

		public bool DisablePersistence => disablePersistence;

		public Vector3i[] ChunksInStreamingAssets
		{
			set
			{
				chunksInStreamingAssets = value;
			}
		}

		public HashSet<VoxelChunk> ChunksToPersist => chunksToPersist;

		private string ComputeBasePathData()
		{
			if (!master)
			{
				master = UnityEngine.Object.FindFirstObjectByType<DiggerMaster>();
			}
			return Path.Combine(master.SceneDataPath, BaseFolder);
		}

		private string GetPathDiggerVersionFile()
		{
			return Path.Combine(BasePathData, "digger_version.asset");
		}

		private string GetPathCurrentVersionFile()
		{
			return Path.Combine(BasePathData, "current_version.asset");
		}

		private string GetPathVersionFile(long v)
		{
			return Path.Combine(InternalPathData, string.Format("version_{0}.{1}", v, "ver"));
		}

		public string GetEditorOnlyPathVoxelFile(Vector3i chunkPosition)
		{
			return Path.Combine(InternalPathData, Chunk.GetName(chunkPosition) + ".vox3");
		}

		public string GetPathVoxelFile(Vector3i chunkPosition, bool forPersistence)
		{
			if (forPersistence)
			{
				return Path.Combine(PersistentRuntimePathData, Chunk.GetName(chunkPosition) + ".vox3");
			}
			if (!SkipPersistedDataOnRead)
			{
				string text = Path.Combine(PersistentRuntimePathData, Chunk.GetName(chunkPosition) + ".vox3");
				if (File.Exists(text))
				{
					return text;
				}
			}
			return Path.Combine(StreamingAssetsPathData, Chunk.GetName(chunkPosition) + ".vox3");
		}

		public string GetPathVoxelMetadataFile(Vector3i chunkPosition, bool forPersistence)
		{
			return Path.ChangeExtension(GetPathVoxelFile(chunkPosition, forPersistence), "vom");
		}

		public string GetPathLabelFile(Vector3i chunkPosition, bool forPersistence)
		{
			return Path.ChangeExtension(GetPathVoxelFile(chunkPosition, forPersistence), "labels");
		}

		public string GetEditorOnlyPathVoxelMetadataFile(Vector3i chunkPosition)
		{
			return Path.ChangeExtension(GetEditorOnlyPathVoxelFile(chunkPosition), "vom");
		}

		public string GetEditorOnlyPathLabelFile(Vector3i chunkPosition)
		{
			return Path.ChangeExtension(GetEditorOnlyPathVoxelFile(chunkPosition), "labels");
		}

		public string GetPathVersionedVoxelFile(Vector3i chunkPosition, long v)
		{
			return Path.ChangeExtension(GetEditorOnlyPathVoxelFile(chunkPosition), string.Format("{0}_v{1}", "vox3", v));
		}

		public string GetPathVersionedVoxelMetadataFile(Vector3i chunkPosition, long v)
		{
			return Path.ChangeExtension(GetEditorOnlyPathVoxelMetadataFile(chunkPosition), string.Format("{0}_v{1}", "vom", v));
		}

		public string GetPathVersionedLabelFile(Vector3i chunkPosition, long v)
		{
			return Path.ChangeExtension(GetEditorOnlyPathLabelFile(chunkPosition), string.Format("{0}_v{1}", "labels", v));
		}

		public Bounds GetChunkBounds()
		{
			Vector3 vector = Vector3.one * SizeOfMesh;
			vector.x *= HeightmapScale.x;
			vector.y *= HeightmapScale.y;
			vector.z *= HeightmapScale.z;
			return new Bounds(vector * 0.5f, vector);
		}

		public void DoUndo()
		{
		}

		public void PersistDiggerVersion()
		{
		}

		public int GetDiggerVersion()
		{
			return 0;
		}

		private void PersistVersion()
		{
		}

		private long GetLastPersistedVersion()
		{
			return 0L;
		}

		private void SyncChunksWithVersion(VersionInfo versionInfo)
		{
			List<Chunk> list = new List<Chunk>();
			foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
			{
				if (!versionInfo.AliveChunks.Contains(chunk.Key))
				{
					list.Add(chunk.Value);
				}
			}
			foreach (Chunk item in list)
			{
				RemoveChunk(item);
			}
			ComputeBounds();
		}

		private void DeleteOtherVersions(bool lower, long comparandVersion)
		{
		}

		public void PreInit(bool enablePersistence)
		{
			disablePersistence = !enablePersistence;
			Terrain = base.transform.parent.GetComponent<Terrain>();
			if (!Terrain)
			{
				Debug.LogError("DiggerSystem component can only be added as a child of a terrain.");
				return;
			}
			master = UnityEngine.Object.FindFirstObjectByType<DiggerMaster>();
			if (!master)
			{
				Debug.LogError("A DiggerMaster is required in the scene.");
			}
			else
			{
				CreateDirs();
			}
		}

		public void Init(LoadType loadType)
		{
			TerrainData terrainData = Terrain.terrainData;
			heightmapScale = terrainData.heightmapScale / master.ResolutionMult;
			if (master.AutoVoxelHeight)
			{
				heightmapScale.y = terrainData.heightmapScale.x / (float)master.ResolutionMult;
			}
			else
			{
				heightmapScale.y = master.VoxelHeight;
			}
			alphamapsSize = new int2(terrainData.alphamapWidth, terrainData.alphamapHeight);
			uvScale = new Vector2(1f / terrainData.size.x, 1f / terrainData.size.z);
			holeMapScale = new Vector3(terrainData.size.x / (float)terrainData.holesResolution, 1f, terrainData.size.z / (float)terrainData.holesResolution);
			long lastPersistedVersion = GetLastPersistedVersion();
			if (lastPersistedVersion != Version && CanUndo)
			{
				Debug.LogWarning($"Digger of terrain {terrainData.name} Version is {Version} but PersistedVersion is {lastPersistedVersion}. Re-syncing...");
				DoUndo();
			}
			else
			{
				Reload(loadType);
			}
		}

		private void Reload(LoadType loadType)
		{
			CreateDirs();
			base.gameObject.layer = Layer;
			Terrain.transform.rotation = Quaternion.identity;
			Terrain.transform.localScale = Vector3.one;
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
			Terrain.heightmapPixelError = 1f;
			if (!cutter)
			{
				cutter = GetComponent<TerrainCutter>();
				if (!cutter)
				{
					cutter = TerrainCutter.CreateInstance(this);
				}
			}
			cutter.Refresh();
			if ((!Application.isEditor || Application.isPlaying) && File.Exists(TerrainHolesRuntimePath))
			{
				try
				{
					cutter.LoadFrom(TerrainHolesRuntimePath);
				}
				catch (Exception ex)
				{
					Debug.LogWarning("[Digger] Failed to load terrain.holes, skipping: " + ex.Message);
				}
			}
			cutter.Apply(persist: true);
			chunks = new Dictionary<Vector3i, Chunk>(100, new Vector3iComparer());
			heightsFeeder = new HeightsFeeder(this, master.ResolutionMult);
			normalsFeeder = new NormalsFeeder(this, master.ResolutionMult);
			alphamapsFeeder = new AlphamapsFeeder(this);
			polygonizerProvider = master.GetComponent<APolygonizerProvider>();
			if ((bool)polygonizerProvider)
			{
				polygonizerProvider.Init();
			}
			chunksToPersist = new HashSet<VoxelChunk>();
			foreach (Transform item in base.transform.Cast<Transform>().ToList())
			{
				Chunk component = item.GetComponent<Chunk>();
				if ((bool)component)
				{
					if (component.Digger != this)
					{
						Debug.LogError("Chunk is badly defined. Missing/wrong cutter and/or digger reference.");
					}
					if (!loadType.RebuildMeshes)
					{
						chunks.Add(component.ChunkPosition, component);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(item.gameObject);
					}
				}
			}
			LoadChunks(loadType);
			ComputeBounds();
			UpdateStaticEditorFlags();
		}

		public void AddNavMeshSources(List<NavMeshBuildSource> sources)
		{
			foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
			{
				NavMeshBuildSource navMeshBuildSource = chunk.Value.NavMeshBuildSource;
				if ((bool)navMeshBuildSource.sourceObject)
				{
					sources.Add(navMeshBuildSource);
				}
			}
		}

		private bool GetOrCreateChunk(Vector3i position, out Chunk chunk)
		{
			if (!chunks.TryGetValue(position, out chunk))
			{
				chunk = Chunk.CreateChunk(position, this, Terrain, Materials, Layer, Tag);
				chunks.Add(position, chunk);
				Bounds chunkBounds = GetChunkBounds();
				ExpandBounds(chunk.WorldPosition, chunk.WorldPosition + chunkBounds.size);
				return false;
			}
			return true;
		}

		internal bool GetChunk(Vector3i position, out Chunk chunk)
		{
			return chunks.TryGetValue(position, out chunk);
		}

		public async Awaitable<ModificationResult> Modify<T>(IOperation<T> operation, bool useBackgroundThreads = false) where T : struct, IJobParallelFor
		{
			ModificationArea areaToModify = operation.GetAreaToModify(this);
			if (!areaToModify.NeedsModification)
			{
				return ModificationResult.Empty;
			}
			return await Modify(operation, areaToModify, buildMeshes: true, useBackgroundThreads);
		}

		public async Awaitable<bool> ModifyWithoutMeshes<T>(IOperation<T> operation, bool useBackgroundThreads = false) where T : struct, IJobParallelFor
		{
			ModificationArea areaToModify = operation.GetAreaToModify(this);
			if (!areaToModify.NeedsModification)
			{
				return false;
			}
			await Modify(operation, areaToModify, buildMeshes: false, useBackgroundThreads);
			foreach (Chunk value in builtChunks.Values)
			{
				value.ResetVoxelArrayBeforeOperation();
			}
			builtChunks.Clear();
			return true;
		}

		public async Awaitable BuildPendingMeshesAsync(bool useBackgroundThreads)
		{
			await BuildMeshes(chunksPendingForMeshBuild, useBackgroundThreads);
			chunksPendingForMeshBuild.Clear();
		}

		private async Awaitable BuildMeshes(Dictionary<Vector3i, Chunk> pendingChunks, bool useBackgroundThreads)
		{
			int lodIndex = 0;
			while (lodIndex < LODCount)
			{
				if (useBackgroundThreads)
				{
					await Awaitable.BackgroundThreadAsync();
				}
				int lod = ChunkLODGroup.IndexToLod(lodIndex);
				foreach (Chunk value in pendingChunks.Values)
				{
					value.BuildVisualMesh(lod);
				}
				foreach (Chunk value2 in pendingChunks.Values)
				{
					value2.CompleteBuildVisualMeshJob();
				}
				await Awaitable.MainThreadAsync();
				foreach (Chunk value3 in pendingChunks.Values)
				{
					value3.CompleteBuildVisualMesh(lod, lodIndex);
				}
				if (useBackgroundThreads)
				{
					await Awaitable.BackgroundThreadAsync();
				}
				foreach (Chunk value4 in pendingChunks.Values)
				{
					value4.BakePhysicMesh();
				}
				foreach (Chunk value5 in pendingChunks.Values)
				{
					value5.CompleteBakePhysicMesh();
				}
				int num = lodIndex + 1;
				lodIndex = num;
			}
			await Awaitable.MainThreadAsync();
			foreach (Chunk value6 in pendingChunks.Values)
			{
				value6.ApplyModify();
			}
			builtChunks.Clear();
			cutter.Apply(persist: true);
		}

		private async Awaitable<ModificationResult> Modify<T>(IOperation<T> operation, ModificationArea area, bool buildMeshes, bool useBackgroundThreads) where T : struct, IJobParallelFor
		{
			if (!area.NeedsModification)
			{
				return ModificationResult.Empty;
			}
			needRecordUndo = true;
			useBackgroundThreads = Application.isPlaying && useBackgroundThreads;
			for (int i = area.Min.x; i <= area.Max.x; i++)
			{
				for (int j = area.Min.z; j <= area.Max.z; j++)
				{
					for (int k = area.Min.y; k <= area.Max.y; k++)
					{
						Vector3i vector3i = new Vector3i(i, k, j);
						if (!builtChunks.TryGetValue(vector3i, out var value))
						{
							GetOrCreateChunk(vector3i, out value);
							builtChunks.Add(vector3i, value);
						}
						value.LazyLoad();
						value.PrepareOperationJob(operation);
					}
				}
			}
			if (useBackgroundThreads)
			{
				await Awaitable.BackgroundThreadAsync();
			}
			foreach (Chunk value14 in builtChunks.Values)
			{
				value14.ScheduleOperationJob(operation);
			}
			foreach (Chunk value15 in builtChunks.Values)
			{
				value15.CompleteOperation(operation);
			}
			ModificationResult aggregatedResult = ModificationResult.Empty;
			foreach (Chunk value16 in builtChunks.Values)
			{
				ModificationResult andClearOperationResult = value16.VoxelChunk.GetAndClearOperationResult();
				aggregatedResult.Add(andClearOperationResult);
			}
			foreach (Chunk value17 in builtChunks.Values)
			{
				value17.GetSurfaceChunksOnHoles();
			}
			surfaceChunkPositionsOnHoles.Clear();
			foreach (Chunk value18 in builtChunks.Values)
			{
				surfaceChunkPositionsOnHoles.UnionWith(value18.CompleteGetSurfaceChunksOnHoles());
			}
			missingBuiltChunks.Clear();
			await Awaitable.MainThreadAsync();
			foreach (int3 surfaceChunkPositionsOnHole in surfaceChunkPositionsOnHoles)
			{
				Vector3i vector3i2 = new Vector3i(surfaceChunkPositionsOnHole.x, surfaceChunkPositionsOnHole.y, surfaceChunkPositionsOnHole.z);
				if (!builtChunks.ContainsKey(vector3i2) && !missingBuiltChunks.ContainsKey(vector3i2))
				{
					GetOrCreateChunk(vector3i2, out var chunk);
					chunk.LazyLoad();
					missingBuiltChunks.Add(vector3i2, chunk);
				}
			}
			if (useBackgroundThreads)
			{
				await Awaitable.BackgroundThreadAsync();
			}
			foreach (Chunk value19 in missingBuiltChunks.Values)
			{
				builtChunks.Add(value19.ChunkPosition, value19);
			}
			foreach (Chunk value20 in builtChunks.Values)
			{
				value20.UpdateVoxelsOnSurface();
			}
			foreach (Chunk value21 in builtChunks.Values)
			{
				value21.CompleteUpdateVoxelsOnSurface();
			}
			if (AutoRemoveFloatingVoxels)
			{
				foreach (Chunk value22 in builtChunks.Values)
				{
					value22.LabelizeVoxels();
				}
				foreach (Chunk value23 in builtChunks.Values)
				{
					value23.CompleteLabelizeVoxels();
				}
				await Awaitable.MainThreadAsync();
				foreach (Chunk value24 in builtChunks.Values)
				{
					chunks.TryGetValue(value24.ChunkPosition + Vector3i.left, out var value2);
					value2?.LazyLoad();
					chunks.TryGetValue(value24.ChunkPosition + Vector3i.right, out var value3);
					value3?.LazyLoad();
					chunks.TryGetValue(value24.ChunkPosition + Vector3i.down, out var value4);
					value4?.LazyLoad();
					chunks.TryGetValue(value24.ChunkPosition + Vector3i.up, out var value5);
					value5?.LazyLoad();
					chunks.TryGetValue(value24.ChunkPosition + Vector3i.back, out var value6);
					value6?.LazyLoad();
					chunks.TryGetValue(value24.ChunkPosition + Vector3i.forward, out var value7);
					value7?.LazyLoad();
				}
				if (useBackgroundThreads)
				{
					await Awaitable.BackgroundThreadAsync();
				}
				foreach (Chunk value25 in builtChunks.Values)
				{
					chunks.TryGetValue(value25.ChunkPosition + Vector3i.left, out var value8);
					LinkLabelOfNeighborChunksXJob linkLabelOfNeighborChunksXJob = LinkLabelOfNeighborChunks.DoX(SizeVox, value8?.VoxelChunk, value25.VoxelChunk);
					JobHandle handle = linkLabelOfNeighborChunksXJob.Schedule();
					linkLabelOfNeighborChunksXJobs.Add(new LinkLabelOfNeighborChunksXJobData
					{
						Job = linkLabelOfNeighborChunksXJob,
						Handle = handle,
						Chunk1 = value8?.VoxelChunk,
						Chunk2 = value25.VoxelChunk
					});
					chunks.TryGetValue(value25.ChunkPosition + Vector3i.right, out var value9);
					LinkLabelOfNeighborChunksXJob linkLabelOfNeighborChunksXJob2 = LinkLabelOfNeighborChunks.DoX(SizeVox, value25.VoxelChunk, value9?.VoxelChunk);
					JobHandle handle2 = linkLabelOfNeighborChunksXJob2.Schedule();
					linkLabelOfNeighborChunksXJobs.Add(new LinkLabelOfNeighborChunksXJobData
					{
						Job = linkLabelOfNeighborChunksXJob2,
						Handle = handle2,
						Chunk1 = value25.VoxelChunk,
						Chunk2 = value9?.VoxelChunk
					});
					chunks.TryGetValue(value25.ChunkPosition + Vector3i.down, out var value10);
					LinkLabelOfNeighborChunksYJob linkLabelOfNeighborChunksYJob = LinkLabelOfNeighborChunks.DoY(SizeVox, value10?.VoxelChunk, value25.VoxelChunk);
					JobHandle handle3 = linkLabelOfNeighborChunksYJob.Schedule();
					linkLabelOfNeighborChunksYJobs.Add(new LinkLabelOfNeighborChunksYJobData
					{
						Job = linkLabelOfNeighborChunksYJob,
						Handle = handle3,
						Chunk1 = value10?.VoxelChunk,
						Chunk2 = value25.VoxelChunk
					});
					chunks.TryGetValue(value25.ChunkPosition + Vector3i.up, out var value11);
					LinkLabelOfNeighborChunksYJob linkLabelOfNeighborChunksYJob2 = LinkLabelOfNeighborChunks.DoY(SizeVox, value25.VoxelChunk, value11?.VoxelChunk);
					JobHandle handle4 = linkLabelOfNeighborChunksYJob2.Schedule();
					linkLabelOfNeighborChunksYJobs.Add(new LinkLabelOfNeighborChunksYJobData
					{
						Job = linkLabelOfNeighborChunksYJob2,
						Handle = handle4,
						Chunk1 = value25.VoxelChunk,
						Chunk2 = value11?.VoxelChunk
					});
					chunks.TryGetValue(value25.ChunkPosition + Vector3i.back, out var value12);
					LinkLabelOfNeighborChunksZJob linkLabelOfNeighborChunksZJob = LinkLabelOfNeighborChunks.DoZ(SizeVox, value12?.VoxelChunk, value25.VoxelChunk);
					JobHandle handle5 = linkLabelOfNeighborChunksZJob.Schedule();
					linkLabelOfNeighborChunksZJobs.Add(new LinkLabelOfNeighborChunksZJobData
					{
						Job = linkLabelOfNeighborChunksZJob,
						Handle = handle5,
						Chunk1 = value12?.VoxelChunk,
						Chunk2 = value25.VoxelChunk
					});
					chunks.TryGetValue(value25.ChunkPosition + Vector3i.forward, out var value13);
					LinkLabelOfNeighborChunksZJob linkLabelOfNeighborChunksZJob2 = LinkLabelOfNeighborChunks.DoZ(SizeVox, value25.VoxelChunk, value13?.VoxelChunk);
					JobHandle handle6 = linkLabelOfNeighborChunksZJob2.Schedule();
					linkLabelOfNeighborChunksZJobs.Add(new LinkLabelOfNeighborChunksZJobData
					{
						Job = linkLabelOfNeighborChunksZJob2,
						Handle = handle6,
						Chunk1 = value25.VoxelChunk,
						Chunk2 = value13?.VoxelChunk
					});
				}
				foreach (LinkLabelOfNeighborChunksXJobData linkLabelOfNeighborChunksXJob3 in linkLabelOfNeighborChunksXJobs)
				{
					JobHandle handle7 = linkLabelOfNeighborChunksXJob3.Handle;
					handle7.Complete();
					LinkLabelOfNeighborChunks.CompleteX(linkLabelOfNeighborChunksXJob3.Job, linkLabelOfNeighborChunksXJob3.Chunk1, linkLabelOfNeighborChunksXJob3.Chunk2);
				}
				linkLabelOfNeighborChunksXJobs.Clear();
				foreach (LinkLabelOfNeighborChunksYJobData linkLabelOfNeighborChunksYJob3 in linkLabelOfNeighborChunksYJobs)
				{
					JobHandle handle7 = linkLabelOfNeighborChunksYJob3.Handle;
					handle7.Complete();
					LinkLabelOfNeighborChunks.CompleteY(linkLabelOfNeighborChunksYJob3.Job, linkLabelOfNeighborChunksYJob3.Chunk1, linkLabelOfNeighborChunksYJob3.Chunk2);
				}
				linkLabelOfNeighborChunksYJobs.Clear();
				foreach (LinkLabelOfNeighborChunksZJobData linkLabelOfNeighborChunksZJob3 in linkLabelOfNeighborChunksZJobs)
				{
					JobHandle handle7 = linkLabelOfNeighborChunksZJob3.Handle;
					handle7.Complete();
					LinkLabelOfNeighborChunks.CompleteZ(linkLabelOfNeighborChunksZJob3.Job, linkLabelOfNeighborChunksZJob3.Chunk1, linkLabelOfNeighborChunksZJob3.Chunk2);
				}
				linkLabelOfNeighborChunksZJobs.Clear();
				await UpdateAllLabels(useBackgroundThreads);
				foreach (Chunk value26 in builtChunks.Values)
				{
					value26.HandleFloatingVoxels();
				}
				foreach (Chunk value27 in builtChunks.Values)
				{
					value27.CompleteHandleFloatingVoxels();
				}
			}
			foreach (Chunk value28 in builtChunks.Values)
			{
				value28.RecordUndoIfNeeded();
			}
			if (buildMeshes)
			{
				await BuildMeshes(builtChunks, useBackgroundThreads);
			}
			else
			{
				foreach (KeyValuePair<Vector3i, Chunk> builtChunk in builtChunks)
				{
					if (!chunksPendingForMeshBuild.ContainsKey(builtChunk.Key))
					{
						chunksPendingForMeshBuild.Add(builtChunk.Key, builtChunk.Value);
					}
				}
			}
			await Awaitable.MainThreadAsync();
			return aggregatedResult;
		}

		private async Awaitable UpdateAllLabels(bool useBackgroundThreads)
		{
			visitedLabels.Clear();
			chunksWithFloatingVoxels.Clear();
			await Awaitable.MainThreadAsync();
			int num = 0;
			foreach (Chunk value in builtChunks.Values)
			{
				foreach (int key in value.VoxelChunk.LabelMap.Keys)
				{
					connectedLabels.Clear();
					connectedLabelsAreConnectedToTheGround = false;
					connectedLabelsAABB = new ConnectedComponentLabeling.AABB
					{
						Min = new int3(int.MaxValue),
						Max = new int3(int.MinValue)
					};
					TraverseLabel(value.VoxelChunk, key);
					UpdateLabelsStatus(num++);
				}
			}
			foreach (Vector3i chunksWithFloatingVoxel in chunksWithFloatingVoxels)
			{
				if (!builtChunks.ContainsKey(chunksWithFloatingVoxel))
				{
					GetOrCreateChunk(chunksWithFloatingVoxel, out var chunk);
					builtChunks.Add(chunksWithFloatingVoxel, chunk);
				}
			}
			if (useBackgroundThreads)
			{
				await Awaitable.BackgroundThreadAsync();
			}
		}

		private void TraverseLabel(VoxelChunk chunk, int label)
		{
			if (!visitedLabels.TryGetValue(chunk.ChunkPosition, out var value))
			{
				value = new HashSet<int>();
				visitedLabels.Add(chunk.ChunkPosition, value);
			}
			if (value.Contains(label))
			{
				return;
			}
			value.Add(label);
			if (!connectedLabels.TryGetValue(chunk.ChunkPosition, out var value2))
			{
				value2 = new HashSet<int>();
				connectedLabels.Add(chunk.ChunkPosition, value2);
			}
			if (!value2.Contains(label))
			{
				value2.Add(label);
				if (chunk.LabelsConnectedToTheGround.Contains(label))
				{
					connectedLabelsAreConnectedToTheGround = true;
				}
				if (chunk.LabelMap.TryGetValue(label, out var value3))
				{
					connectedLabelsAABB.Expand(value3.Min);
					connectedLabelsAABB.Expand(value3.Max);
				}
				TraverseNeighbor(chunk, label, chunk.LinksToRight, chunk.ChunkPosition + Vector3i.right);
				TraverseNeighbor(chunk, label, chunk.LinksToLeft, chunk.ChunkPosition + Vector3i.left);
				TraverseNeighbor(chunk, label, chunk.LinksToTop, chunk.ChunkPosition + Vector3i.up);
				TraverseNeighbor(chunk, label, chunk.LinksToBottom, chunk.ChunkPosition + Vector3i.down);
				TraverseNeighbor(chunk, label, chunk.LinksToBack, chunk.ChunkPosition + Vector3i.forward);
				TraverseNeighbor(chunk, label, chunk.LinksToFront, chunk.ChunkPosition + Vector3i.back);
			}
		}

		private void TraverseNeighbor(VoxelChunk chunk, int label, Dictionary<int, HashSet<int>> links, Vector3i neighborPosition)
		{
			if (!links.TryGetValue(label, out var value) || !chunks.TryGetValue(neighborPosition, out var value2))
			{
				return;
			}
			value2.LazyLoad();
			foreach (int item in value)
			{
				TraverseLabel(value2.VoxelChunk, item);
			}
		}

		private void UpdateLabelsStatus(int i)
		{
			bool flag = connectedLabelsAreConnectedToTheGround || connectedLabelsAABB.GreatestSideLength >= MaxFloatingVoxelGroupSizeToRemove;
			foreach (KeyValuePair<Vector3i, HashSet<int>> connectedLabel in connectedLabels)
			{
				if (!chunks.TryGetValue(connectedLabel.Key, out var value))
				{
					continue;
				}
				foreach (int item in connectedLabel.Value)
				{
					if (flag)
					{
						value.VoxelChunk.LabelsConnectedToTheGroundThroughNeighbors.Add(item);
					}
					else if (value.VoxelChunk.LabelsConnectedToTheGroundThroughNeighbors.Contains(item))
					{
						value.VoxelChunk.LabelsConnectedToTheGroundThroughNeighbors.Remove(item);
						chunksWithFloatingVoxels.Add(connectedLabel.Key);
					}
				}
			}
		}

		public bool IsChunkBelongingToMe(Vector3i chunkPosition)
		{
			if (chunkPosition.x >= 0 && chunkPosition.x <= TerrainChunkWidth && chunkPosition.z >= 0)
			{
				return chunkPosition.z <= TerrainChunkHeight;
			}
			return false;
		}

		public DiggerSystem GetNeighborAt(Vector3i chunkPosition)
		{
			if (chunkPosition.x < 0)
			{
				if (chunkPosition.z < 0)
				{
					if ((bool)Terrain.leftNeighbor)
					{
						return GetDiggerSystemOf(Terrain.leftNeighbor.bottomNeighbor);
					}
					if ((bool)Terrain.bottomNeighbor)
					{
						return GetDiggerSystemOf(Terrain.bottomNeighbor.leftNeighbor);
					}
				}
				else
				{
					if (chunkPosition.z <= TerrainChunkHeight)
					{
						return GetDiggerSystemOf(Terrain.leftNeighbor);
					}
					if ((bool)Terrain.leftNeighbor)
					{
						return GetDiggerSystemOf(Terrain.leftNeighbor.topNeighbor);
					}
					if ((bool)Terrain.topNeighbor)
					{
						return GetDiggerSystemOf(Terrain.topNeighbor.leftNeighbor);
					}
				}
			}
			else
			{
				if (chunkPosition.x <= TerrainChunkWidth)
				{
					if (chunkPosition.z < 0)
					{
						return GetDiggerSystemOf(Terrain.bottomNeighbor);
					}
					if (chunkPosition.z > TerrainChunkHeight)
					{
						return GetDiggerSystemOf(Terrain.topNeighbor);
					}
					return this;
				}
				if (chunkPosition.z < 0)
				{
					if ((bool)Terrain.rightNeighbor)
					{
						return GetDiggerSystemOf(Terrain.rightNeighbor.bottomNeighbor);
					}
					if ((bool)Terrain.bottomNeighbor)
					{
						return GetDiggerSystemOf(Terrain.bottomNeighbor.rightNeighbor);
					}
				}
				else
				{
					if (chunkPosition.z <= TerrainChunkHeight)
					{
						return GetDiggerSystemOf(Terrain.rightNeighbor);
					}
					if ((bool)Terrain.rightNeighbor)
					{
						return GetDiggerSystemOf(Terrain.rightNeighbor.topNeighbor);
					}
					if ((bool)Terrain.topNeighbor)
					{
						return GetDiggerSystemOf(Terrain.topNeighbor.rightNeighbor);
					}
				}
			}
			return null;
		}

		public Vector3i ToChunkPosition(Vector3 worldPosition)
		{
			Vector3 v = worldPosition - Terrain.transform.position;
			v.x /= heightmapScale.x;
			v.y /= heightmapScale.y;
			v.z /= heightmapScale.z;
			return new Vector3i(v) / SizeOfMesh;
		}

		public Vector3 ToWorldPosition(Vector3i chunkPosition)
		{
			Vector3 vector = chunkPosition * SizeOfMesh;
			vector.x *= heightmapScale.x;
			vector.y *= heightmapScale.y;
			vector.z *= heightmapScale.z;
			return vector + Terrain.transform.position;
		}

		private static DiggerSystem GetDiggerSystemOf(Terrain terrain)
		{
			if ((bool)terrain)
			{
				return terrain.GetComponentInChildren<DiggerSystem>();
			}
			return null;
		}

		public void RemoveTreesInSphere(Vector3 center, float radius)
		{
			TerrainData terrainData = Terrain.terrainData;
			for (int i = 0; i < terrainData.treeInstanceCount; i++)
			{
				TreeInstance treeInstance = terrainData.GetTreeInstance(i);
				if (Vector3.Distance(TerrainUtils.UVToWorldPosition(terrainData, treeInstance.position), center) < radius)
				{
					treeInstance.heightScale = 0f;
					treeInstance.widthScale = 0f;
					terrainData.SetTreeInstance(i, treeInstance);
				}
			}
		}

		public int2 GetMinMaxHeightWithin(Vector3i minVox, Vector3i maxVox)
		{
			float2 float5 = new float2(float.MaxValue, float.MinValue);
			for (int i = minVox.x; i <= maxVox.x; i++)
			{
				for (int j = minVox.z; j <= maxVox.z; j++)
				{
					float height = heightsFeeder.GetHeight(i, j);
					float5.x = math.min(float5.x, height);
					float5.y = math.max(float5.y, height);
				}
			}
			return new int2((int)(float5.x / heightmapScale.y - heightmapScale.y) / SizeOfMesh, (int)(float5.y / heightmapScale.y + heightmapScale.y) / SizeOfMesh);
		}

		private void ComputeBounds()
		{
			bool flag = true;
			Bounds chunkBounds = GetChunkBounds();
			foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
			{
				Vector3 worldPosition = chunk.Value.WorldPosition;
				Vector3 max = worldPosition + chunkBounds.size;
				if (flag)
				{
					flag = false;
					bounds.SetMinMax(worldPosition, max);
				}
				else
				{
					ExpandBounds(worldPosition, max);
				}
			}
		}

		private void ExpandBounds(Vector3 min, Vector3 max)
		{
			if (bounds.min.x < min.x)
			{
				min.x = bounds.min.x;
			}
			if (bounds.min.y < min.y)
			{
				min.y = bounds.min.y;
			}
			if (bounds.min.z < min.z)
			{
				min.z = bounds.min.z;
			}
			if (bounds.max.x > max.x)
			{
				max.x = bounds.max.x;
			}
			if (bounds.max.y > max.y)
			{
				max.y = bounds.max.y;
			}
			if (bounds.max.z > max.z)
			{
				max.z = bounds.max.z;
			}
			bounds.SetMinMax(min, max);
		}

		public void EnsureChunkWillBePersisted(VoxelChunk voxelChunk)
		{
			if (!disablePersistence)
			{
				chunksToPersist.Add(voxelChunk);
			}
		}

		private void RemoveUselessChunks()
		{
			List<Chunk> list = new List<Chunk>();
			foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
			{
				if (IsUseless(chunk.Key))
				{
					list.Add(chunk.Value);
				}
			}
			foreach (Chunk item in list)
			{
				RemoveChunk(item);
			}
			ComputeBounds();
		}

		private void RemoveChunk(Chunk chunk)
		{
			chunks.Remove(chunk.ChunkPosition);
			string pathVoxelFile = GetPathVoxelFile(chunk.ChunkPosition, forPersistence: true);
			if (File.Exists(pathVoxelFile))
			{
				File.Delete(pathVoxelFile);
			}
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(chunk.gameObject);
			}
			else
			{
				UnityEngine.Object.Destroy(chunk.gameObject);
			}
		}

		private bool IsUseless(Vector3i chunkPosition)
		{
			if (!chunks.TryGetValue(chunkPosition, out var value))
			{
				return false;
			}
			if (value.HasVisualMesh)
			{
				return false;
			}
			Vector3i[] allDirections = Vector3i.allDirections;
			foreach (Vector3i vector3i in allDirections)
			{
				chunks.TryGetValue(chunkPosition + vector3i, out var _);
			}
			if ((bool)value.VoxelChunk && value.VoxelChunk.HasAlteredVoxels())
			{
				return false;
			}
			return true;
		}

		private void LoadChunks(LoadType loadType)
		{
			if (chunks == null)
			{
				Debug.LogError("Chunks dico should not be null in loading");
				return;
			}
			if (loadType.LoadVoxels)
			{
				foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
				{
					LoadChunk(loadType.RebuildMeshes, loadType.SyncVoxelsWithTerrain, chunk.Value);
				}
			}
			if (!SkipPersistedDataOnRead)
			{
				LoadChunksFromDir(loadType, new DirectoryInfo(PersistentRuntimePathData));
			}
			LoadChunksFromStreamingAssetsDir(loadType);
		}

		private void LoadChunksFromDir(LoadType loadType, DirectoryInfo dir)
		{
			if (!dir.Exists)
			{
				return;
			}
			foreach (FileInfo item in dir.EnumerateFiles("*.vox3"))
			{
				Vector3i positionFromName = Chunk.GetPositionFromName(item.Name);
				LoadChunkFromFile(loadType, positionFromName);
			}
		}

		private void LoadChunksFromStreamingAssetsDir(LoadType loadType)
		{
			if (chunksInStreamingAssets != null && chunksInStreamingAssets.Length != 0)
			{
				Debug.Log($"Digger will now load {chunksInStreamingAssets.Length} chunks from StreamingAssets folder");
				Vector3i[] array = chunksInStreamingAssets;
				foreach (Vector3i chunkPosition in array)
				{
					LoadChunkFromFile(loadType, chunkPosition);
				}
			}
		}

		private void LoadChunkFromFile(LoadType loadType, Vector3i chunkPosition)
		{
			if (!chunks.ContainsKey(chunkPosition) && chunkPosition.x >= 0 && chunkPosition.z >= 0 && chunkPosition.x <= TerrainChunkWidth && chunkPosition.z <= TerrainChunkHeight)
			{
				Chunk chunk;
				bool orCreateChunk = GetOrCreateChunk(chunkPosition, out chunk);
				if (loadType.LoadVoxels || !orCreateChunk)
				{
					LoadChunk(loadType.RebuildMeshes || !orCreateChunk, loadType.SyncVoxelsWithTerrain, chunk);
				}
			}
		}

		private static void LoadChunk(bool rebuildMeshes, bool syncVoxelsWithTerrain, Chunk chunk)
		{
			bool flag = chunk.LoadVoxels(syncVoxelsWithTerrain);
			if (rebuildMeshes || flag)
			{
				chunk.RebuildMeshes();
			}
		}

		public void UpdateStaticEditorFlags()
		{
			if (chunks == null)
			{
				return;
			}
			foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
			{
				chunk.Value.UpdateStaticEditorFlags();
			}
		}

		public void Clear()
		{
		}

		public void ClearAtRuntime()
		{
			if (cutter != null)
			{
				cutter.Clear();
			}
			if (chunks != null)
			{
				foreach (KeyValuePair<Vector3i, Chunk> chunk in chunks)
				{
					UnityEngine.Object.Destroy(chunk.Value.gameObject);
				}
				chunks.Clear();
			}
			chunksToPersist.Clear();
		}

		public void CreateDirs()
		{
		}
	}
}
