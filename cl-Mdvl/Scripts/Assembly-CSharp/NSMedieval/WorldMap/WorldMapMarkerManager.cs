using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using Repository.Map;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapMarkerManager
	{
		private readonly WorldMap worldMap;

		private readonly Dictionary<WorldMapMarkerPlace, WorldMapMarkerView> instanceToView;

		private WorldDate cachedDateTime;

		private WorldDate DateTime
		{
			get
			{
				if (cachedDateTime == null)
				{
					cachedDateTime = GlobalSaveController.CurrentVillageData.DateAndTime;
				}
				return cachedDateTime;
			}
		}

		public HashSet<WorldMapMarkerPlace> AllMarkers => worldMap.Data.Markers;

		public IEnumerable<WorldMapMarkerPlace> VisibleMarkers => instanceToView.Keys;

		public bool HasVisibleMarkers => instanceToView.Count > 0;

		public event Action<WorldMapMarkerPlace> MarkerCreatedEvent;

		public event Action<WorldMapMarkerPlace> MarkerDestroyedEvent;

		public WorldMapMarkerManager(WorldMap worldMap)
		{
			this.worldMap = worldMap;
			instanceToView = new Dictionary<WorldMapMarkerPlace, WorldMapMarkerView>();
		}

		public WorldMapMarkerPlace SpawnMarker(string name, in Vector2Int gridPosition, string mapId, string prefabAddress, int durationMinutes = int.MaxValue, string lootSpawnConfig = null, bool createView = true, FactionInstance faction = null, string linkedObjective = null)
		{
			WorldMapMarkerPlace worldMapMarkerPlace = new WorldMapMarkerPlace(name, mapId, prefabAddress, gridPosition, durationMinutes, lootSpawnConfig, createView, faction, linkedObjective);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapMarkerManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning map marker ");
				messageBuilder.AppendFormatted(worldMapMarkerPlace);
			}
			Log.Info(messageBuilder);
			CreateView(worldMapMarkerPlace);
			worldMap.Data.Markers.Add(worldMapMarkerPlace);
			this.MarkerCreatedEvent?.Invoke(worldMapMarkerPlace);
			return worldMapMarkerPlace;
		}

		public WorldMapMarkerPlace SpawnMarker(string name, string mapId, string prefabAddress, IntRange spawnRange, int durationMinutes = int.MaxValue, string lootSpawnConfig = null, bool createView = true, FactionInstance faction = null)
		{
			Vector2Int villagePosition = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			return SpawnMarker(name, GenerateFreePosition(villagePosition, spawnRange), mapId, prefabAddress, durationMinutes, lootSpawnConfig, createView, faction);
		}

		public Vector2Int GenerateFreePosition(Vector2Int center, IntRange spawnRange)
		{
			if (spawnRange.Min == 0 && spawnRange.Max == 0)
			{
				return center;
			}
			Vector2Int position = default(Vector2Int);
			for (int i = 0; i < spawnRange.Max - spawnRange.Min; i++)
			{
				int num = UnityEngine.Random.Range(spawnRange.Min, spawnRange.Max);
				int num2 = num * num;
				for (int j = -num; j <= num; j++)
				{
					int num3 = UnityEngine.Random.Range(-num, num);
					int num4 = (int)Mathf.Sqrt(num2 - num3 * num3);
					if (UnityEngine.Random.value > 0.5f)
					{
						num4 = -num4;
					}
					position.x = center.x + num3;
					position.y = center.y + num4;
					if (position.x > 0 && position.x <= worldMap.Data.WorldMapResolution.x && position.y > 0 && position.y <= worldMap.Data.WorldMapResolution.y)
					{
						if (worldMap.IsPositionFree(in position) && worldMap.GetMapTypeName(in position) != null)
						{
							return position;
						}
						num4 = -num4;
						position.y = center.y + num4;
						if (worldMap.IsPositionFree(in position) && worldMap.GetMapTypeName(in position) != null)
						{
							return position;
						}
					}
				}
			}
			throw new Exception("Failed to find free random position");
		}

		public void DestroyMarker(WorldMapMarkerPlace marker)
		{
			CaravanManager.SendAllHome(marker);
			MonoSingleton<CaravanFormingManager>.Instance.CancelCaravansFormingTo(marker);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapMarkerManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Destroying marker ");
				messageBuilder.AppendFormatted(marker);
			}
			Log.Info(messageBuilder);
			if (!AllMarkers.Remove(marker))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(82, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapMarkerManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Failed to destroy marker because it was not found in the list of markers, marker: ");
					messageBuilder2.AppendFormatted(marker);
				}
				Log.Error(messageBuilder2);
				return;
			}
			marker.Dispose();
			this.MarkerDestroyedEvent?.Invoke(marker);
			if (instanceToView.TryGetValue(marker, out var value))
			{
				if (value != null)
				{
					UnityEngine.Object.Destroy(value.gameObject);
				}
				instanceToView.Remove(marker);
			}
		}

		public WorldMapMarkerView GetMarkerView(WorldMapMarkerPlace markerPlace)
		{
			instanceToView.TryGetValue(markerPlace, out var value);
			return value;
		}

		public int GetMarkerCount(SecondMapType mapType)
		{
			return AllMarkers.Count((WorldMapMarkerPlace marker) => marker.MapId != null && Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetByID(marker.MapId).Type == mapType);
		}

		public bool HasMaxMarkerCount(SecondMapType mapType)
		{
			int markerCount = GetMarkerCount(mapType);
			return mapType switch
			{
				SecondMapType.LootStash => markerCount >= SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.MaxLootStashes, 
				SecondMapType.Attack => markerCount >= SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.MaxBanditCamps, 
				_ => false, 
			};
		}

		public void OnLoaded()
		{
			MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
			foreach (WorldMapMarkerView value in instanceToView.Values)
			{
				if (value != null)
				{
					UnityEngine.Object.Destroy(value.gameObject);
				}
			}
			instanceToView.Clear();
			foreach (WorldMapMarkerPlace marker in worldMap.Data.Markers)
			{
				CreateView(marker);
			}
		}

		public void Dispose()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
			}
			if (worldMap?.Data?.Markers == null)
			{
				return;
			}
			foreach (WorldMapMarkerPlace marker in worldMap.Data.Markers)
			{
				if (!instanceToView.TryGetValue(marker, out var value))
				{
					marker.Dispose();
					continue;
				}
				if (value != null)
				{
					UnityEngine.Object.Destroy(value.gameObject);
				}
				instanceToView.Remove(marker);
				marker.Dispose();
			}
		}

		public void TryForceTick()
		{
			if (GlobalSaveController.CurrentVillageData.IsSecondMap || !MonoSingleton<UIController>.Instance.GameStarted)
			{
				return;
			}
			if (AllMarkers.Count > 0)
			{
				using PooledList<WorldMapMarkerPlace> pooledList = ListPool<WorldMapMarkerPlace>.GetJanitor(AllMarkers);
				foreach (WorldMapMarkerPlace item in pooledList)
				{
					item.TickScheduledStateChanges();
					if (item.HasExpired)
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("Map marker '" + item.Name + "' has expired");
						DestroyMarker(item);
					}
				}
			}
			foreach (VillagePlace villagePlace in worldMap.Data.VillagePlaces)
			{
				villagePlace.TickScheduledStateChanges();
			}
		}

		private void OnQuarterHourUpdate()
		{
			TryForceTick();
		}

		public void CreateView(WorldMapMarkerPlace instance)
		{
			if (instance.HasView)
			{
				WorldMapMarkerView component = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetByAddress(instance.PrefabAddress) ?? throw new Exception("Failed to spawn world map marker, prefab with address '" + instance.PrefabAddress + "' not found"), worldMap.HeightmapContent.transform).GetComponent<WorldMapMarkerView>();
				if ((object)component == null)
				{
					throw new Exception("Failed to spawn world map marker, prefab with address '" + instance.PrefabAddress + "' does not have a WorldMapMarkerView component");
				}
				component.Instance = instance;
				instanceToView[instance] = component;
			}
		}

		public bool MarkerExists(uint id)
		{
			return AllMarkers.Any((WorldMapMarkerPlace marker) => marker.Id == id);
		}
	}
}
