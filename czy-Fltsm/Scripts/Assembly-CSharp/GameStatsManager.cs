using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class GameStatsManager
{
	[Serializable]
	private class ActorStats
	{
		public int SpawnedCount;

		public int LastSpawnedDay;

		public int RescuedCount;

		public int LastRescuedDay;

		public int DeathCount;

		public int GetValue(ActorStat stat)
		{
			return stat switch
			{
				ActorStat.LastSpawnedDay => LastSpawnedDay, 
				ActorStat.SpawnedCount => SpawnedCount, 
				ActorStat.LastRescuedDay => LastRescuedDay, 
				ActorStat.RescuedCount => RescuedCount, 
				ActorStat.DeathCount => DeathCount, 
				_ => LogNotImplementedException(), 
			};
		}

		private int LogNotImplementedException()
		{
			Debug.LogException(new NotImplementedException());
			return 0;
		}
	}

	[Serializable]
	public class PersistentData
	{
		[OptionalField(VersionAdded = 2)]
		private Dictionary<ActorType, ActorStats> _actorStats;

		private int _regionsScoutedCount;

		private readonly float _totalCameraMovedDistance;

		private readonly float _totalCameraRotationChanges;

		private readonly float _totalCameraZoomChanges;

		private readonly bool _hasEverResetCamera;

		private readonly List<string> _landmarkActionsInProgressActionNames = new List<string>();

		private readonly List<int> _landmarkActionsInProgressCounts = new List<int>();

		private readonly List<int> _salvagedMarkerItemPropertiesIDs = new List<int>();

		private readonly List<int> _salvagedMarkerItemCounts = new List<int>();

		private readonly List<int> _salvagedLandmarkItemPropertiesIDs = new List<int>();

		private readonly List<int> _salvagedLandmarkItems = new List<int>();

		[OptionalField(VersionAdded = 3)]
		private readonly List<int> _salvagedSalvagerItemPropertiesIDs = new List<int>();

		[OptionalField(VersionAdded = 3)]
		private readonly List<int> _salvagedSalvagerItems = new List<int>();

		private readonly List<int> _itemProductionsQueuedPropertiesIDs = new List<int>();

		private readonly List<int> _itemProductionsQueuedCounts = new List<int>();

		private readonly List<int> _producedItemPropertiesIDs = new List<int>();

		private readonly List<int> _producedItemCounts = new List<int>();

		[OptionalField(VersionAdded = 3)]
		private readonly List<int> _farmedItemPropertiesIDs = new List<int>();

		[OptionalField(VersionAdded = 3)]
		private readonly List<int> _farmedItemCounts = new List<int>();

		private readonly List<int> _builtBuildablePropertiesIDs = new List<int>();

		private readonly List<int> _builtBuildableCounts = new List<int>();

		private readonly List<int> _placedMarkerPropertiesIDs = new List<int>();

		private readonly List<int> _placedMarkerCounts = new List<int>();

		private int _driftersRescuedCount;

		private int _birdsRescuedCount;

		private readonly int _deadDriftersCount;

		public PersistentData()
		{
			GameStatsManager gameStatsManager = GameManager.GameStatsManager;
			_actorStats = gameStatsManager._actorStats;
			_regionsScoutedCount = gameStatsManager.RegionsScoutedCount;
			_totalCameraMovedDistance = gameStatsManager.TotalCameraMovedDistance;
			_totalCameraRotationChanges = gameStatsManager.TotalCameraRotationChanges;
			_totalCameraZoomChanges = gameStatsManager.TotalCameraZoomChanges;
			_hasEverResetCamera = gameStatsManager.HasEverResetCamera;
			SaveItems(gameStatsManager._landmarkActionsInProgress, _landmarkActionsInProgressActionNames, _landmarkActionsInProgressCounts);
			SaveItems(gameStatsManager._salvagedMarkerItems, _salvagedMarkerItemPropertiesIDs, _salvagedMarkerItemCounts);
			SaveItems(gameStatsManager._salvagedLandmarkItems, _salvagedLandmarkItemPropertiesIDs, _salvagedLandmarkItems);
			SaveItems(gameStatsManager._salvagedSalvagerItems, _salvagedSalvagerItemPropertiesIDs, _salvagedSalvagerItems);
			SaveItems(gameStatsManager._itemProductionsQueued, _itemProductionsQueuedPropertiesIDs, _itemProductionsQueuedCounts);
			SaveItems(gameStatsManager._itemsProduced, _producedItemPropertiesIDs, _producedItemCounts);
			SaveItems(gameStatsManager._itemsFarmed, _farmedItemPropertiesIDs, _farmedItemCounts);
			SaveItems(gameStatsManager._buildablesBuilt, _builtBuildablePropertiesIDs, _builtBuildableCounts);
			SaveItems(gameStatsManager._markersPlaced, _placedMarkerPropertiesIDs, _placedMarkerCounts);
		}

		private static void SaveItems(IReadOnlyDictionary<string, int> items, List<string> names, List<int> counts)
		{
			foreach (KeyValuePair<string, int> item in items)
			{
				names.Add(item.Key);
				counts.Add(item.Value);
			}
		}

		private static void SaveItems<TKey>(IReadOnlyDictionary<TKey, int> items, List<int> ids, List<int> counts) where TKey : PersistentProperties
		{
			foreach (KeyValuePair<TKey, int> item in items)
			{
				ids.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(item.Key));
				counts.Add(item.Value);
			}
		}

		public void Restore()
		{
			if (_placedMarkerPropertiesIDs.Count == 0 && _builtBuildablePropertiesIDs.Count == 0)
			{
				AssessDataFromCurrentWorldState();
			}
			GameStatsManager gameStatsManager = GameManager.GameStatsManager;
			gameStatsManager.Clear();
			if (!_actorStats.IsNullOrEmpty())
			{
				foreach (KeyValuePair<ActorType, ActorStats> actorStat in _actorStats)
				{
					gameStatsManager._actorStats.Add(actorStat.Key, actorStat.Value);
				}
			}
			gameStatsManager.RegionsScoutedCount = _regionsScoutedCount;
			gameStatsManager.TotalCameraMovedDistance = _totalCameraMovedDistance;
			gameStatsManager.TotalCameraRotationChanges = _totalCameraRotationChanges;
			gameStatsManager.TotalCameraZoomChanges = _totalCameraZoomChanges;
			gameStatsManager.HasEverResetCamera = _hasEverResetCamera;
			if (!_landmarkActionsInProgressActionNames.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._landmarkActionsInProgress, _landmarkActionsInProgressActionNames, _landmarkActionsInProgressCounts);
			}
			if (!_salvagedMarkerItemPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._salvagedMarkerItems, _salvagedMarkerItemPropertiesIDs, _salvagedMarkerItemCounts);
			}
			if (!_salvagedLandmarkItemPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._salvagedLandmarkItems, _salvagedLandmarkItemPropertiesIDs, _salvagedLandmarkItems);
			}
			if (!_salvagedSalvagerItemPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._salvagedSalvagerItems, _salvagedSalvagerItemPropertiesIDs, _salvagedSalvagerItems);
			}
			if (!_itemProductionsQueuedPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._itemProductionsQueued, _itemProductionsQueuedPropertiesIDs, _itemProductionsQueuedCounts);
			}
			if (!_producedItemPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._itemsProduced, _producedItemPropertiesIDs, _producedItemCounts);
			}
			if (!_farmedItemPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._itemsFarmed, _farmedItemPropertiesIDs, _farmedItemCounts);
			}
			if (!_builtBuildablePropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._buildablesBuilt, _builtBuildablePropertiesIDs, _builtBuildableCounts);
			}
			if (!_placedMarkerPropertiesIDs.IsNullOrEmpty())
			{
				RestoreDictionary(gameStatsManager._markersPlaced, _placedMarkerPropertiesIDs, _placedMarkerCounts);
			}
		}

		private void AssessDataFromCurrentWorldState()
		{
			Community playerCommunity = Community.PlayerCommunity;
			_regionsScoutedCount = GameManager.WorldManager.World.GetScoutedRegionsCount();
			foreach (Item item in (IEnumerable<Item>)playerCommunity.Inventory.GetAllItems(SubInventoryType.Storage))
			{
				if (item.ContainsTagSet(Item.Tags.Resource))
				{
					AddOrIncrement(item.Properties, _salvagedMarkerItemPropertiesIDs, _salvagedMarkerItemCounts);
				}
				else
				{
					AddOrIncrement(item.Properties, _producedItemPropertiesIDs, _producedItemCounts);
				}
			}
			List<Buildable> buildables = playerCommunity.Buildables;
			BuildableProperties properties = GameManager.Settings.SessionSettings.StartingScenario.Townheart.Properties;
			foreach (Buildable item2 in (IEnumerable<Buildable>)buildables)
			{
				if (item2.Properties != properties)
				{
					AddOrIncrement(item2.Properties, _builtBuildablePropertiesIDs, _builtBuildableCounts);
				}
			}
		}

		private static void AddOrIncrement<TKey>(TKey key, List<int> ids, List<int> counts) where TKey : PersistentProperties
		{
			int item = GameManager.PersistenceManager.ReturnPropertiesIndex(key);
			int num = ids.IndexOf(item);
			if (num == -1)
			{
				ids.Add(item);
				counts.Add(1);
			}
			else
			{
				counts[num]++;
			}
		}

		private static void RestoreDictionary(Dictionary<string, int> dictionary, IReadOnlyList<string> names, IReadOnlyList<int> counts)
		{
			int i = 0;
			for (int count = names.Count; i < count; i++)
			{
				dictionary.Add(names[i], counts[i]);
			}
		}

		private static void RestoreDictionary<TKey>(Dictionary<TKey, int> dictionary, IReadOnlyList<int> ids, IReadOnlyList<int> counts) where TKey : PersistentProperties
		{
			int i = 0;
			for (int count = ids.Count; i < count; i++)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<TKey>(ids[i], out var reference))
				{
					dictionary.Add(reference, counts[i]);
				}
			}
		}
	}

	private readonly Dictionary<ActorType, ActorStats> _actorStats = new Dictionary<ActorType, ActorStats>();

	private readonly Dictionary<string, int> _landmarkActionsInProgress = new Dictionary<string, int>();

	private readonly Dictionary<ItemProperties, int> _salvagedMarkerItems = new Dictionary<ItemProperties, int>();

	private readonly Dictionary<ItemProperties, int> _salvagedLandmarkItems = new Dictionary<ItemProperties, int>();

	private readonly Dictionary<ItemProperties, int> _salvagedSalvagerItems = new Dictionary<ItemProperties, int>();

	private readonly Dictionary<ItemProperties, int> _itemProductionsQueued = new Dictionary<ItemProperties, int>();

	private readonly Dictionary<ItemProperties, int> _itemsProduced = new Dictionary<ItemProperties, int>();

	private readonly Dictionary<ItemProperties, int> _itemsFarmed = new Dictionary<ItemProperties, int>();

	private readonly Dictionary<BuildableProperties, int> _buildablesBuilt = new Dictionary<BuildableProperties, int>();

	private readonly Dictionary<MarkerCursorProperties, int> _markersPlaced = new Dictionary<MarkerCursorProperties, int>();

	public GameData GameData { get; } = new GameData();

	public int RegionsScoutedCount { get; private set; }

	public float TotalCameraMovedDistance { get; private set; }

	public float TotalCameraRotationChanges { get; private set; }

	public float TotalCameraZoomChanges { get; private set; }

	public bool HasEverResetCamera { get; private set; }

	public void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.LandmarkSpawned, OnLandmarkSpawned);
		GameEventDispatcher.AddListener(GameEventType.ActorRescue, OnActorEvent);
		GameEventDispatcher.AddListener(GameEventType.ActorDeath, OnActorEvent);
		GameEventDispatcher.AddListener(GameEventType.RegionScouted, OnRegionScouted);
		GameEventDispatcher.AddListener(GameEventType.ManualCameraMovement, OnCameraMovement);
		GameEventDispatcher.AddListener(GameEventType.ManualCameraRotation, OnCameraRotation);
		GameEventDispatcher.AddListener(GameEventType.ManualCameraZoom, OnCameraZoom);
		GameEventDispatcher.AddListener(GameEventType.CameraReset, OnCameraReset);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationWorking, OnLandmarkActionStarted);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationIdle, OnLandmarkActionStopped);
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedMarkerItem, OnItemEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedLandmarkItem, OnItemEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedSalvagerItem, OnItemEvent);
		GameEventDispatcher.AddListener(GameEventType.ProducerItemQueued, OnItemProductionQueued);
		GameEventDispatcher.AddListener(GameEventType.ProducerItemProduced, OnItemProduced);
		GameEventDispatcher.AddListener(GameEventType.ItemFarmed, OnItemFarmed);
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
		GameEventDispatcher.AddListener(GameEventType.MarkerPlaced, OnMarkerPlaced);
	}

	~GameStatsManager()
	{
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkSpawned, OnLandmarkSpawned);
		GameEventDispatcher.RemoveListener(GameEventType.ActorRescue, OnActorEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ActorDeath, OnActorEvent);
		GameEventDispatcher.RemoveListener(GameEventType.RegionScouted, OnRegionScouted);
		GameEventDispatcher.RemoveListener(GameEventType.ManualCameraMovement, OnCameraMovement);
		GameEventDispatcher.RemoveListener(GameEventType.ManualCameraRotation, OnCameraRotation);
		GameEventDispatcher.RemoveListener(GameEventType.ManualCameraZoom, OnCameraZoom);
		GameEventDispatcher.RemoveListener(GameEventType.CameraReset, OnCameraReset);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationWorking, OnLandmarkActionStarted);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationIdle, OnLandmarkActionStopped);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedMarkerItem, OnItemEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedLandmarkItem, OnItemEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedSalvagerItem, OnItemEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemQueued, OnItemProductionQueued);
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemProduced, OnItemProduced);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
		GameEventDispatcher.RemoveListener(GameEventType.MarkerPlaced, OnMarkerPlaced);
	}

	public void Clear()
	{
		_actorStats.Clear();
		RegionsScoutedCount = 0;
		_landmarkActionsInProgress.Clear();
		_salvagedMarkerItems.Clear();
		_salvagedLandmarkItems.Clear();
		_salvagedSalvagerItems.Clear();
		_itemProductionsQueued.Clear();
		_itemsProduced.Clear();
		_itemsFarmed.Clear();
		_buildablesBuilt.Clear();
		_markersPlaced.Clear();
	}

	public static int GetActorStat(ActorType type, ActorStat stat)
	{
		if (GameManager.GameStatsManager == null)
		{
			return 0;
		}
		return GameManager.GameStatsManager.GetActorStatValue(type, stat);
	}

	private ActorStats GetActorStats(ActorType type)
	{
		if (_actorStats.TryGetValue(type, out var value))
		{
			return value;
		}
		value = new ActorStats();
		_actorStats.Add(type, value);
		return value;
	}

	private int GetActorStatValue(ActorType type, ActorStat stat)
	{
		if (!_actorStats.TryGetValue(type, out var value))
		{
			return 0;
		}
		return value.GetValue(stat);
	}

	public int GetLandmarkActionsInProgressCount(LandmarkAction action)
	{
		if ((string)action.Title == null)
		{
			return 0;
		}
		return GetCount(_landmarkActionsInProgress, action.Title.mTerm);
	}

	public int GetSalvagedMarkerItemsCount(ItemProperties itemProperties)
	{
		return GetCount(_salvagedMarkerItems, itemProperties);
	}

	public int GetSalvagedLandmarkItemsCount(ItemProperties itemProperties)
	{
		return GetCount(_salvagedLandmarkItems, itemProperties);
	}

	public int GetSalvagedSalvagerItemCount(ItemProperties itemProperties)
	{
		return GetCount(_salvagedSalvagerItems, itemProperties);
	}

	public int GetItemProductionsQueuedCount(ItemProperties itemProperties)
	{
		return GetCount(_itemProductionsQueued, itemProperties);
	}

	public int GetProducedItemsCount(ItemProperties itemProperties)
	{
		return GetCount(_itemsProduced, itemProperties);
	}

	public int GetProducedItemsCount(ItemType itemType)
	{
		return GetItemCount(_itemsProduced, itemType);
	}

	public int GetFarmedItemCount(ItemProperties itemProperties)
	{
		return GetCount(_itemsFarmed, itemProperties);
	}

	public int GetBuildablesBuiltCount(BuildableProperties buildableProperties)
	{
		return GetCount(_buildablesBuilt, buildableProperties);
	}

	public int GetMarkersPlacedCount(ItemProperties itemProperties)
	{
		int num = 0;
		foreach (KeyValuePair<MarkerCursorProperties, int> item in _markersPlaced)
		{
			if ((item.Key.AllowedItemTags & itemProperties.Tags) != Item.Tags.None)
			{
				num += item.Value;
			}
		}
		return num;
	}

	private int GetItemCount(Dictionary<ItemProperties, int> countedItems, ItemType itemType)
	{
		Dictionary<ItemProperties, int>.Enumerator enumerator = countedItems.GetEnumerator();
		int num = 0;
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Key.ItemType == itemType)
			{
				num += enumerator.Current.Value;
			}
		}
		return num;
	}

	private void OnActorEvent(GameEvent gameEvent)
	{
		if (gameEvent is ActorEvent actorEvent)
		{
			ActorStats actorStats = GetActorStats(actorEvent.ActorDescriptor.ActorType);
			switch (gameEvent.EventType)
			{
			case GameEventType.ActorRescue:
				actorStats.RescuedCount++;
				actorStats.LastRescuedDay = GameManager.TimeManager.Days.Count;
				break;
			case GameEventType.ActorDeath:
				actorStats.DeathCount++;
				break;
			}
		}
	}

	private void OnRegionScouted(GameEvent gameEvent)
	{
		int regionsScoutedCount = RegionsScoutedCount + 1;
		RegionsScoutedCount = regionsScoutedCount;
	}

	private void OnCameraMovement(GameEvent gameEvent)
	{
		if (gameEvent is CameraGameEvent cameraGameEvent)
		{
			TotalCameraMovedDistance += cameraGameEvent.DistanceMoved;
		}
	}

	private void OnCameraRotation(GameEvent gameEvent)
	{
		if (gameEvent is CameraGameEvent cameraGameEvent)
		{
			TotalCameraRotationChanges += Mathf.Abs(cameraGameEvent.Rotation);
		}
	}

	private void OnCameraZoom(GameEvent gameEvent)
	{
		if (gameEvent is CameraGameEvent cameraGameEvent)
		{
			TotalCameraZoomChanges += Mathf.Abs(cameraGameEvent.Zoom);
		}
	}

	private void OnCameraReset(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.CameraReset, OnCameraReset);
		HasEverResetCamera = true;
	}

	private void OnLandmarkSpawned(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent { LandmarkBehaviour: ActionsBehaviour landmarkBehaviour } && landmarkBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false))
		{
			int count = GameManager.TimeManager.Days.Count;
			ActorStats actorStats = GetActorStats(action.ActorType);
			actorStats.SpawnedCount++;
			actorStats.LastSpawnedDay = count;
		}
	}

	private void OnLandmarkActionStarted(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && landmarkNotificationEvent.LandmarkAction != null && (string)landmarkNotificationEvent.LandmarkAction.Title != null)
		{
			IncrementCount(_landmarkActionsInProgress, landmarkNotificationEvent.LandmarkAction.Title.mTerm);
		}
	}

	private void OnLandmarkActionStopped(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && landmarkNotificationEvent.LandmarkAction != null && (string)landmarkNotificationEvent.LandmarkAction.Title != null && _landmarkActionsInProgress.ContainsKey(landmarkNotificationEvent.LandmarkAction.Title.mTerm))
		{
			DecrementCount(_landmarkActionsInProgress, landmarkNotificationEvent.LandmarkAction.Title.mTerm);
		}
	}

	private void OnItemEvent(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent { ItemProperties: var itemProperties } agentActionItemPropertiesEvent)
		{
			switch (agentActionItemPropertiesEvent.EventType)
			{
			case GameEventType.AgentActionSalvagedMarkerItem:
				IncrementCount(_salvagedMarkerItems, itemProperties);
				break;
			case GameEventType.AgentActionSalvagedLandmarkItem:
				IncrementCount(_salvagedLandmarkItems, itemProperties);
				break;
			case GameEventType.AgentActionSalvagedSalvagerItem:
				IncrementCount(_salvagedSalvagerItems, itemProperties);
				break;
			}
		}
	}

	private void OnItemProductionQueued(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent && itemEvent.ItemProperties != null)
		{
			IncrementCount(_itemProductionsQueued, itemEvent.ItemProperties);
		}
	}

	private void OnItemProduced(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent { Item: not null } itemEvent && itemEvent.Item.Properties != null)
		{
			IncrementCount(_itemsProduced, itemEvent.Item.Properties);
			DecrementCount(_itemProductionsQueued, itemEvent.Item.Properties);
		}
	}

	private void OnItemFarmed(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent { Item: not null } itemEvent && (bool)itemEvent.Item.Properties)
		{
			IncrementCount(_itemsFarmed, itemEvent.Item.Properties);
		}
	}

	private void OnBuildableBuilt(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent)
		{
			IncrementCount(_buildablesBuilt, buildableEvent.BuildableProperties);
		}
	}

	private void OnMarkerPlaced(GameEvent gameEvent)
	{
		if (gameEvent is MarkerEvent markerEvent)
		{
			IncrementCount(_markersPlaced, markerEvent.Marker.MarkerCursorProperties);
		}
	}

	private static void IncrementCount<TKey>(Dictionary<TKey, int> dictionary, TKey key)
	{
		if (!dictionary.ContainsKey(key))
		{
			dictionary[key] = 1;
		}
		else
		{
			dictionary[key]++;
		}
	}

	private static void DecrementCount<TKey>(Dictionary<TKey, int> dictionary, TKey key)
	{
		if (dictionary.ContainsKey(key) && dictionary[key] > 0)
		{
			dictionary[key]--;
		}
	}

	private static int GetCount<TKey>(Dictionary<TKey, int> dictionary, TKey key)
	{
		if (!dictionary.TryGetValue(key, out var value))
		{
			return 0;
		}
		return value;
	}
}
