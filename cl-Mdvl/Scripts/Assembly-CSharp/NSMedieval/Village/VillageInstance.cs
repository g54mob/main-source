using System;
using System.Collections;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.MovableBuildings;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Village
{
	[Serializable]
	[FVSerializableKey("VillageInstance", "")]
	public class VillageInstance : IFVSerializable
	{
		[SerializeField]
		private VillageMap map;

		[SerializeField]
		private WorldObjectStorage worldObjectStorage;

		[SerializeField]
		private string seed;

		private bool isLoaded;

		private bool savedObjectsSpawned;

		private int notificationIndex;

		public VillageMap Map => map;

		public Vec3Int MapSize => map.Size;

		public WorldObjectStorage WorldObjectStorage => worldObjectStorage;

		public string Seed => seed;

		public bool SavedObjectsSpawned => savedObjectsSpawned;

		public byte[] TemperatureBytesLoaded { get; set; }

		public byte[] SnowGrassWetDataBytesLoaded { get; set; }

		public byte[] WaterDataBytes { get; set; }

		public byte[] FireDataBytes { get; set; }

		public VillageInstance()
		{
		}

		public IEnumerator InitializeNew(MapGenerator mapGenerator)
		{
			Vec3Int vec3Int = mapGenerator.MapGenerationParameters.MapSize.Vec3Int;
			seed = mapGenerator.MapGenerationParameters.MapSeed;
			map.GenerateEmptyData(vec3Int, this);
			yield return MonoSingleton<MapGenerationController>.Instance.MapGenerator.FinalizeMapGenOnEnterScene(map);
			savedObjectsSpawned = true;
		}

		public void InitAfterLoad()
		{
			MapNode.RefreshEnabled = false;
			isLoaded = true;
			map.InitAfterLoad(this);
			MonoSingleton<Heightmap>.Instance.Init(map, MapSize.x, MapSize.y, MapSize.z);
			MonoSingleton<FloraRegrowController>.Instance.InitMapSize(map);
			MonoSingleton<FishRegrowController>.Instance.InitMapSize(map);
			worldObjectStorage.SynchronizeWorldData();
			MapNode[] gridSpaceData = Map.GridSpaceData;
			foreach (MapNode obj in gridSpaceData)
			{
				obj.RefreshTags();
				obj.RefreshIsWalkable();
			}
			MapNode.RefreshEnabled = true;
			gridSpaceData = Map.GridSpaceData;
			for (int i = 0; i < gridSpaceData.Length; i++)
			{
				gridSpaceData[i].RefreshAfterLoad();
			}
			MapNode.RefreshEnabled = false;
		}

		public IEnumerator SpawnObjects()
		{
			notificationIndex = 0;
			MonoSingleton<SlopeManager>.Instance.SpawnProfileSlopes();
			yield return NotifyAndWait();
			map.BuildingsManagerMain.LoadSavedBuildings(placedOnBeam: false);
			yield return NotifyAndWait();
			map.BuildingsManagerMain.LoadSavedBeams();
			yield return NotifyAndWait();
			map.BuildingsManagerMain.LoadSavedBuildings(placedOnBeam: true);
			yield return NotifyAndWait();
			MonoSingleton<MoveBuildingsManager>.Instance.LoadingSetup();
			yield return NotifyAndWait();
			MonoSingleton<NPCManager>.Instance.SpawnProfileNPCs();
			yield return NotifyAndWait();
			yield return NotifyAndWait();
			MonoSingleton<StockpileManager>.Instance.SpawnProfileStockpiles();
			yield return NotifyAndWait();
			MonoSingleton<CropsManager>.Instance.SpawnProfileCropfields();
			yield return NotifyAndWait();
			MonoSingleton<ResourcePileManager>.Instance.SpawnProfilePiles();
			yield return NotifyAndWait();
			for (int i = 0; i < Map.GridSpaceData.Length; i++)
			{
				Map.GridSpaceData[i].RefreshTags();
				Map.GridSpaceData[i].RefreshIsWalkable();
			}
			map.RefreshAllNodes();
			yield return NotifyAndWait();
			map.RegionManager.Initialize();
			yield return NotifyAndWait();
			map.RegionAreaManager.Initialize();
			yield return NotifyAndWait();
			map.RoomDetection.Initialize();
			MonoSingleton<NPCManager>.Instance.RepositionStuckNPCs();
			yield return NotifyAndWait();
			MonoSingleton<DigMarkerResourceManager>.Instance.LoadSavedDigMarkers();
			savedObjectsSpawned = true;
			yield return NotifyAndWait();
			yield return NotifyAndWait();
			foreach (WorldObject worldObject in worldObjectStorage.WorldObjects)
			{
				worldObject.UpdateReachability();
			}
			map.CommanderAIManager.InitAfterLoad(GlobalSaveController.CurrentVillageData.CommanderAICommanders);
			map.RaidManager.InitAfterLoad();
		}

		private IEnumerator NotifyAndWait()
		{
			MonoSingleton<LoadingController>.Instance.InvokeLoadingPhaseChanged("load_spawning_objects", 16 - notificationIndex);
			notificationIndex++;
			yield return new WaitForEndOfFrame();
		}

		public void Dispose()
		{
			map?.Dispose();
			map = null;
			worldObjectStorage = null;
		}

		public void OnCreated()
		{
			map = new VillageMap();
			worldObjectStorage = new WorldObjectStorage();
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("map", map);
			serializer.Write("worldObjectStorage", worldObjectStorage);
			serializer.Write("seed", seed);
		}

		public VillageInstance(FVDeserializer deserializer)
		{
			map = deserializer.ReadObject<VillageMap>("map");
			worldObjectStorage = deserializer.ReadObject<WorldObjectStorage>("worldObjectStorage");
			seed = deserializer.ReadString("seed");
		}
	}
}
