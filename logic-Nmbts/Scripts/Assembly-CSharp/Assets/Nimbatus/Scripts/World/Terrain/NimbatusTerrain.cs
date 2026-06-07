using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain
{
	public class NimbatusTerrain : MonoBehaviour, INimbatusTerrain
	{
		public bool IsBackgroundTerrain;

		public int TerrainChunkSize = 20;

		public int ChunksPerAxis;

		private NimbatusTerrainChunk[,] _chunkNeighbourArray;

		private Vector3 _terrainPosition;

		private TerrainTaskManager _taskManager;

		private string _name;

		private bool _canControlDrone;

		private bool _hasWokenUp;

		public void Awake()
		{
			RuntimeGlobals.IsGameLoading = true;
		}

		public void Start()
		{
			_canControlDrone = RunningModeSpecifics.Can(ERunningModeSpecific.ControlDrone);
		}

		public void Init()
		{
			_chunkNeighbourArray = new NimbatusTerrainChunk[ChunksPerAxis, ChunksPerAxis];
			_taskManager = GetComponent<TerrainTaskManager>();
			RuntimeGlobals.IsGameLoading = true;
			StartCoroutine(GenerateTerrain());
			_name = base.gameObject.name;
		}

		public void OnEnable()
		{
			RuntimeGlobals.WakeUp += WakeUp;
		}

		public void OnDisable()
		{
			RuntimeGlobals.WakeUp -= WakeUp;
		}

		public void OnDestroy()
		{
			Cleanup();
		}

		private void WakeUp(object sender, EventArgs eventArgs)
		{
			if (!_hasWokenUp && _canControlDrone)
			{
				_hasWokenUp = true;
			}
		}

		public bool IsBackground()
		{
			return IsBackgroundTerrain;
		}

		public bool HasCollider()
		{
			return !IsBackgroundTerrain;
		}

		public string GetName()
		{
			return _name;
		}

		public NimbatusTerrainData GenerateData(Vector3 pos)
		{
			Vector2 worldPosition = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
			NimbatusTerrainClimateZone activeClimateZone = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone;
			NimbatusTerrainData data;
			if (!SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.GetDataFromCache(worldPosition, IsBackgroundTerrain, out data))
			{
				return activeClimateZone.GenerateData(worldPosition, IsBackgroundTerrain);
			}
			return data;
		}

		public NimbatusTerrainData? GetData(Vector3 pos)
		{
			pos.x = Mathf.RoundToInt(pos.x);
			pos.y = Mathf.RoundToInt(pos.y);
			pos.z = (int)_terrainPosition.z;
			float f = pos.x / (float)TerrainChunkSize;
			float f2 = pos.y / (float)TerrainChunkSize;
			int num = Mathf.FloorToInt(f);
			int num2 = Mathf.FloorToInt(f2);
			float num3 = num * TerrainChunkSize;
			f2 = num2 * TerrainChunkSize;
			int num4 = (int)(num3 - _terrainPosition.x) / TerrainChunkSize;
			int num5 = (int)(f2 - _terrainPosition.y) / TerrainChunkSize;
			if (num4 < 0 || num4 >= ChunksPerAxis)
			{
				return null;
			}
			if (num5 < 0 || num5 >= ChunksPerAxis)
			{
				return null;
			}
			NimbatusTerrainChunk nimbatusTerrainChunk = _chunkNeighbourArray[num4, num5];
			if (nimbatusTerrainChunk == null)
			{
				return null;
			}
			if (!nimbatusTerrainChunk.GetData(pos).HasValue)
			{
				return null;
			}
			NimbatusTerrainData? data = nimbatusTerrainChunk.GetData(pos);
			if (data.HasValue)
			{
				return data.Value;
			}
			return null;
		}

		public void SetData(Vector2 pos, NimbatusTerrainData data)
		{
			pos.x = Mathf.RoundToInt(pos.x);
			pos.y = Mathf.RoundToInt(pos.y);
			Vector2 vector = pos - new Vector2(_terrainPosition.x, _terrainPosition.y);
			if (vector.x > 1f && vector.y > 1f && vector.x < (float)(TerrainChunkSize * ChunksPerAxis - 1) && vector.y < (float)(TerrainChunkSize * ChunksPerAxis - 1))
			{
				PerformActionOnNeighbourChunks(pos, delegate(NimbatusTerrainChunk chunk)
				{
					chunk.SetData(pos, data);
					chunk.NeedsRebuilding = true;
				});
			}
		}

		public void LerpData(Vector3 worldPos, NimbatusTerrainData to, float time)
		{
			NimbatusTerrainData? data = GetData(worldPos);
			if (data.HasValue)
			{
				float value = Mathf.Lerp(data.Value.Volume, to.Volume, time);
				SetData(worldPos, new NimbatusTerrainData(Mathf.Clamp01(value), to.MaterialType));
			}
		}

		public void Cleanup()
		{
			for (int i = 0; i < ChunksPerAxis; i++)
			{
				for (int j = 0; j < ChunksPerAxis; j++)
				{
					NimbatusTerrainChunk nimbatusTerrainChunk = _chunkNeighbourArray[i, j];
					if (nimbatusTerrainChunk != null)
					{
						nimbatusTerrainChunk.CleanUpMesh();
					}
				}
			}
			_chunkNeighbourArray = null;
		}

		private IEnumerator GenerateTerrain()
		{
			yield return StartCoroutine(SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.WaitForCacheBuilt());
			Vector3 terrainOrigin = (_terrainPosition = new Vector3(0f, 0f, base.transform.position.z) - new Vector3(ChunksPerAxis / 2 * TerrainChunkSize, ChunksPerAxis / 2 * TerrainChunkSize, 0f));
			List<NimbatusTerrainChunk> chunkList = new List<NimbatusTerrainChunk>();
			int tempCount = 0;
			int count = 0;
			float num = ChunksPerAxis * ChunksPerAxis;
			float percentMod = 100f / num;
			for (int y = 0; y < ChunksPerAxis; y++)
			{
				for (int x = 0; x < ChunksPerAxis; x++)
				{
					Vector3 position = terrainOrigin + new Vector3(x * TerrainChunkSize, y * TerrainChunkSize, 0f);
					GameObject obj = new GameObject(base.gameObject.name + " Chunk ");
					obj.transform.parent = base.gameObject.transform;
					obj.layer = base.gameObject.layer;
					obj.transform.position = position;
					NimbatusTerrainChunk nimbatusTerrainChunk = obj.AddComponent<NimbatusTerrainChunk>();
					nimbatusTerrainChunk.Init(position, TerrainChunkSize, this);
					nimbatusTerrainChunk.IsRebuilding = true;
					chunkList.Add(nimbatusTerrainChunk);
					_chunkNeighbourArray[x, y] = nimbatusTerrainChunk;
					nimbatusTerrainChunk.GenerateTerrainData();
					nimbatusTerrainChunk.BuildTerrainMesh();
					nimbatusTerrainChunk.ApplyTerrainMesh();
					nimbatusTerrainChunk.GenerateBackgroundObjects();
					nimbatusTerrainChunk.IsRebuilding = false;
					count++;
					tempCount++;
					NimbatusSceneManager.LoadingProgress = (int)(percentMod * (float)count);
					if (tempCount > 30)
					{
						tempCount = 0;
						yield return true;
					}
				}
			}
			_taskManager.SetChunkList(chunkList);
			if (!IsBackground())
			{
				if (RuntimeGlobals.RunningMode != ERunningMode.TestFlightPlanet)
				{
					System.Random random = new System.Random(WorldController.Seed);
					yield return StartCoroutine(SerializableMonobehaviour<PlanetSpawnManager, SpawnManagerData>.Instance.StartSpawn(random));
					yield return StartCoroutine(RemoveCollectedMineral());
					SerializableMonobehaviour<MissionManager, MissionData>.Instance.InitMissions();
					RuntimeGlobals.IsGameLoading = false;
					PlanetLocationData planetLocationData = (PlanetLocationData)SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation;
					StartCoroutine(SerializableMonobehaviour<PlanetSpawnManager, SpawnManagerData>.Instance.StartEvents(planetLocationData.EventType));
				}
				else
				{
					RuntimeGlobals.IsGameLoading = false;
				}
			}
			yield return true;
		}

		private IEnumerator RemoveCollectedMineral()
		{
			Debug.Log("Remove collected Minerals");
			int count = 0;
			for (int x = 0; x < 1100; x++)
			{
				for (int y = 0; y < 1100; y++)
				{
					Vector2 vector = new Vector2(x - 540, y - 540);
					NimbatusTerrainData? data = GetData(vector);
					PlanetLocationData planetLocationData;
					if (!data.HasValue || (planetLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as PlanetLocationData) == null)
					{
						continue;
					}
					NimbatusTerrainData value = data.Value;
					if (planetLocationData.HasMineralBeenCollected(x, y))
					{
						value.Volume = 0f;
						SetData(vector, value);
						count++;
						if (count > 100)
						{
							count = 0;
							yield return true;
						}
					}
				}
			}
			Debug.Log("Done");
		}

		private Vector2 GetChunkArrayPos(Vector3 position)
		{
			float f = position.x / (float)TerrainChunkSize;
			float f2 = position.y / (float)TerrainChunkSize;
			int num = Mathf.FloorToInt(f);
			int num2 = Mathf.FloorToInt(f2);
			float num3 = num * TerrainChunkSize;
			f2 = num2 * TerrainChunkSize;
			int num4 = (int)(num3 - _terrainPosition.x) / TerrainChunkSize;
			int num5 = (int)(f2 - _terrainPosition.y) / TerrainChunkSize;
			return new Vector2(num4, num5);
		}

		private void PerformActionOnNeighbourChunks(Vector3 position, Action<NimbatusTerrainChunk> action)
		{
			Vector2 chunkArrayPos = GetChunkArrayPos(position);
			int num = (int)chunkArrayPos.x;
			int num2 = (int)chunkArrayPos.y;
			if ((int)position.x % TerrainChunkSize != 0 && (int)position.y % TerrainChunkSize != 0 && num >= 0 && num < ChunksPerAxis && num2 >= 0 && num2 < ChunksPerAxis)
			{
				action(_chunkNeighbourArray[num, num2]);
				return;
			}
			for (int i = -1; i <= 0; i++)
			{
				for (int j = -1; j <= 0; j++)
				{
					int num3 = Mathf.Min(ChunksPerAxis - 1, Mathf.Max(0, num + i));
					int num4 = Mathf.Min(ChunksPerAxis - 1, Mathf.Max(0, num2 + j));
					action(_chunkNeighbourArray[num3, num4]);
				}
			}
		}
	}
}
