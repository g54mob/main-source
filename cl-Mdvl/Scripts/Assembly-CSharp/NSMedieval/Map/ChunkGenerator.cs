using System;
using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Map
{
	public class ChunkGenerator : MonoBehaviour
	{
		[SerializeField]
		private GameObject chunkPrefab;

		[SerializeField]
		private GameObject frameChunkPrefab;

		[SerializeField]
		private GameObject chunkFolder;

		[SerializeField]
		private int chunkSize = 16;

		[NonSerialized]
		private VillageMap villageMap;

		[NonSerialized]
		private MapGenerationTextures mapGenerationTextures;

		[NonSerialized]
		private MapChunk[,] chunks;

		[NonSerialized]
		private MeshRenderer[,] chunksMeshes;

		[NonSerialized]
		private MeshCollider[,] meshColliders;

		[NonSerialized]
		private List<MapChunk> edgeChunks;

		[NonSerialized]
		private List<MeshRenderer> edgeChunkMeshes;

		[NonSerialized]
		private int chunksCountX;

		[NonSerialized]
		private int chunksCountZ;

		[NonSerialized]
		private int edgeChunksCountX;

		[NonSerialized]
		private int edgeChunksCountZ;

		private int remainingMapChunks;

		private int remainingEdgeMapChunks;

		private int mapSizeX;

		private int mapSizeZ;

		public int ChunkSize => chunkSize;

		public MapChunk[,] Chunks => chunks;

		public event Action AllMapChunksGeneratedEvent;

		public event Action AllEdgeFrameChunksGeneratedEvent;

		private void OnDestroy()
		{
			villageMap = null;
			mapGenerationTextures = null;
		}

		public void GenerateMapChunks(VillageMap villageMap, MapGenerationTextures mapGenerationTextures)
		{
			this.villageMap = villageMap;
			mapSizeX = this.villageMap.Size.x;
			mapSizeZ = this.villageMap.Size.z;
			chunksCountX = (mapSizeX + chunkSize - 1) / chunkSize;
			chunksCountZ = (mapSizeZ + chunkSize - 1) / chunkSize;
			edgeChunksCountX = (mapSizeX + chunkSize - 1 + 160) / chunkSize;
			edgeChunksCountZ = (mapSizeZ + chunkSize - 1 + 160) / chunkSize;
			this.mapGenerationTextures = mapGenerationTextures;
			remainingMapChunks = chunksCountX * chunksCountZ;
			chunks = new MapChunk[chunksCountX, chunksCountZ];
			edgeChunks = new List<MapChunk>();
			chunksMeshes = new MeshRenderer[chunksCountX, chunksCountZ];
			edgeChunkMeshes = new List<MeshRenderer>();
			meshColliders = new MeshCollider[chunksCountX, chunksCountZ];
			bool loadChunksFromSave = !GlobalSaveController.CurrentVillageData.FirstEnter;
			remainingEdgeMapChunks = 0;
			for (int i = 0; i < edgeChunksCountX; i++)
			{
				for (int j = 0; j < edgeChunksCountZ; j++)
				{
					if (CanInstantiateEdgeFrameChunk(i, j))
					{
						remainingEdgeMapChunks++;
					}
				}
			}
			StartCoroutine(SpawnChunks(loadChunksFromSave));
		}

		private void OnMapChunkGenerated()
		{
			if (remainingMapChunks > 0)
			{
				remainingMapChunks--;
				if (remainingMapChunks == 0)
				{
					MonoSingleton<LoadingController>.Instance.InvokeLoadingPhaseChanged("loading_placing_objects");
					this.AllMapChunksGeneratedEvent?.Invoke();
				}
				else
				{
					MonoSingleton<LoadingController>.Instance.InvokeLoadingPhaseChanged("loading_map_chunks", remainingMapChunks);
				}
			}
		}

		private void OnFrameChunkGenerated()
		{
			if (remainingEdgeMapChunks > 0)
			{
				remainingEdgeMapChunks--;
				if (remainingEdgeMapChunks == 0)
				{
					this.AllEdgeFrameChunksGeneratedEvent?.Invoke();
				}
			}
		}

		public void SetupBottomBlackMesh(float level)
		{
			for (int i = 0; i < chunksCountX; i++)
			{
				for (int j = 0; j < chunksCountZ; j++)
				{
					if (!(chunks[i, j] == null))
					{
						chunks[i, j].SetupBottomBlackMesh(level);
					}
				}
			}
		}

		public void SetupTopTransparentMesh(int level)
		{
			for (int i = 0; i < chunksCountX; i++)
			{
				for (int j = 0; j < chunksCountZ; j++)
				{
					if (!(chunks[i, j] == null))
					{
						chunks[i, j].SetupTopTransparentMesh(level);
					}
				}
			}
		}

		public void SetMeshesForAllChunks(int level)
		{
			for (int i = 0; i < chunksCountX; i++)
			{
				for (int j = 0; j < chunksCountZ; j++)
				{
					if (!(chunks[i, j] == null))
					{
						chunks[i, j].LoadMesh(level);
						chunks[i, j].SetShadowCasterMesh();
					}
				}
			}
			foreach (MapChunk edgeChunk in edgeChunks)
			{
				if (edgeChunk != null)
				{
					edgeChunk.LoadMesh(level);
					edgeChunk.SetShadowCasterMesh();
				}
			}
		}

		public MapChunk GetMapChunkAt(int x, int z)
		{
			int num = Mathf.FloorToInt((float)x / (float)chunkSize);
			if (num < 0 || num >= chunksCountX)
			{
				return null;
			}
			int num2 = Mathf.FloorToInt((float)z / (float)chunkSize);
			if (num2 < 0 || num2 >= chunksCountZ)
			{
				return null;
			}
			return chunks[num, num2];
		}

		public void SaveChunksToZip()
		{
			MapChunk[,] array = chunks;
			int upperBound = array.GetUpperBound(0);
			int upperBound2 = array.GetUpperBound(1);
			for (int i = array.GetLowerBound(0); i <= upperBound; i++)
			{
				for (int j = array.GetLowerBound(1); j <= upperBound2; j++)
				{
					array[i, j].SaveToZip();
				}
			}
		}

		public void SaveChunksToCache()
		{
			MapChunk[,] array = chunks;
			int upperBound = array.GetUpperBound(0);
			int upperBound2 = array.GetUpperBound(1);
			for (int i = array.GetLowerBound(0); i <= upperBound; i++)
			{
				for (int j = array.GetLowerBound(1); j <= upperBound2; j++)
				{
					array[i, j].SaveToCache();
				}
			}
		}

		private GameObject InstantiateChunk(int x, int z, bool loadFromSave)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(chunkPrefab, new Vector3((float)(x * chunkSize) - 0.5f, 0f, (float)(z * chunkSize) - 0.5f), Quaternion.identity);
			gameObject.name = $"Chunk ({x},{z})";
			gameObject.transform.parent = chunkFolder.transform;
			int chunkX = x * chunkSize;
			int chunkZ = z * chunkSize;
			MapChunk component = gameObject.GetComponent<MapChunk>();
			chunks[x, z] = component;
			component.Setup(loadFromSave, chunkX, 0, chunkZ, villageMap.Size, chunkSize);
			component.ChunkGeneratedEvent += OnMapChunkGenerated;
			chunksMeshes[x, z] = gameObject.GetComponent<MeshRenderer>();
			meshColliders[x, z] = gameObject.GetComponent<MeshCollider>();
			return gameObject;
		}

		private bool CanInstantiateEdgeFrameChunk(int x, int z)
		{
			Heightmap instance = MonoSingleton<Heightmap>.Instance;
			int num = x * chunkSize - 80;
			int num2 = z * chunkSize - 80;
			if (!instance.IsInFrame(num + 1, num2 + 1) && !instance.IsInFrame(num + chunkSize - 1, num2 + 1) && !instance.IsInFrame(num + 1, num2 + chunkSize - 1) && !instance.IsInFrame(num + chunkSize - 1, num2 + chunkSize - 1))
			{
				return false;
			}
			return true;
		}

		private void TryInstantiateEdgeChunk(int x, int z, bool loadFromSave)
		{
			int chunkX = x * chunkSize - 80;
			int chunkZ = z * chunkSize - 80;
			GameObject gameObject = UnityEngine.Object.Instantiate(position: new Vector3((float)(x * chunkSize) - 0.5f - 80f, 0f, (float)(z * chunkSize) - 0.5f - 80f), original: frameChunkPrefab, rotation: Quaternion.identity);
			if (!(gameObject == null))
			{
				gameObject.name = $"Frame Chunk ({x},{z})";
				gameObject.transform.parent = chunkFolder.transform;
				MapEdgeFrameChunk component = gameObject.GetComponent<MapEdgeFrameChunk>();
				edgeChunks.Add(component);
				component.Setup(loadFromSave, chunkX, 0, chunkZ, villageMap.Size, chunkSize);
				component.ChunkGeneratedEvent += OnFrameChunkGenerated;
				edgeChunkMeshes.Add(gameObject.GetComponent<MeshRenderer>());
			}
		}

		private IEnumerator SpawnChunks(bool loadChunksFromSave)
		{
			villageMap.StabilityManager.InitializeStabilityGrid(villageMap);
			for (int x = 0; x < chunksCountX; x++)
			{
				for (int i = 0; i < chunksCountZ; i++)
				{
					InstantiateChunk(x, i, loadChunksFromSave);
				}
				yield return new WaitForEndOfFrame();
			}
			for (int x = 0; x < edgeChunksCountX; x++)
			{
				for (int j = 0; j < edgeChunksCountZ; j++)
				{
					if (CanInstantiateEdgeFrameChunk(x, j))
					{
						TryInstantiateEdgeChunk(x, j, loadFromSave: false);
					}
				}
				yield return new WaitForEndOfFrame();
			}
			MonoSingleton<GrassChunksManager>.Instance.Setup(villageMap);
			MonoSingleton<GrassChunksManager>.Instance.SpawnGrassChunks();
			MonoSingleton<BuildingPlacementManager>.Instance.SetupCamera();
		}
	}
}
