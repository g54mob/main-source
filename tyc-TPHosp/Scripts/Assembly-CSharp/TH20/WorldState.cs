#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using TH20.EventUnlockItem;
using UnityEngine;

namespace TH20
{
	public class WorldState : MustCallDestroy, Interface, IGameEventCallback
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public float initialTemperature;

			public float initialAttractiveness;

			public float initialHygiene;

			public SharedInstance<RoomDefinition>[] _availableRooms;

			public SharedInstance<RoomDefinition> _roomBuiltDefinition;

			public SharedInstance<RoomDefinition> _roomBuildingDefinition;

			public SharedInstance<RoomDefinition> _roomUnbuiltDefinition;

			public SharedInstance<RoomItemDefinition> MainEntranceDefinition;

			public SharedInstance<RoomItemDefinition> SideEntranceDefinition;

			public SharedInstance<RoomItemDefinition> InternalEntranceDefinition;

			public SharedInstance<RoomItemDefinition> WindowDefinition;

			public SharedInstance<RoomItemDefinition>[] RequiredUnlockableItems;

			public SharedInstance<RoomWallDefinition> CorridorWallDefinition;

			public List<SharedInstance<HospitalPlotDefinition>> HospitalPlots;

			public FogOfWarLevelTextureDefinition FogOfWarDefinition;

			public PostProcessingRendererData PostProcessingRendererData;

			public bool createBaseLandscapeItems = true;

			public GameObject[] PerimeterPrefabs;

			public float PerimeterOffset = 0.75f;

			public bool PerimeterNoRotation;
		}

		private readonly Config _config;

		private Level _level;

		[DontSave]
		private Metagame _metagame;

		private readonly VisualManager _visualManager;

		private readonly Material _valueMaterial;

		private readonly RoomItemVisualEdit.Config _roomItemEditConfig;

		private readonly List<RoomDefinition> _availableRooms;

		private readonly List<IRoomItemDefinition> _availableRoomItems;

		[DontSave]
		private NavMesh _navMesh;

		[DontSave]
		private InvalidNavAreaVisualManager _invalidNavAreaVisualManager;

		private readonly List<HospitalMap> _builtHospitalMaps;

		private readonly List<HospitalMap> _unbuiltHospitalMaps;

		private readonly List<HospitalPlot> _hospitalPlots;

		public List<HospitalAttributeMap> HospitalAttributeMaps = new List<HospitalAttributeMap>();

		private readonly List<KeyValuePair<RoomItem, float>>[] _needSatisfyingRoomItems = new List<KeyValuePair<RoomItem, float>>[13];

		[DontSave]
		public BoolArray2D ExteriorState;

		[DontSave]
		private EnvironmentRatingCalculator[] _environmentCalculators;

		[DontSave]
		private List<GridCoord> _entranceCache;

		private List<int[,]> _detailLayers;

		public GridCoord Anchor { get; private set; }

		public GridBounds Bounds
		{
			get
			{
				GridBounds result = default(GridBounds);
				foreach (HospitalMap builtHospitalMap in _builtHospitalMaps)
				{
					result |= builtHospitalMap.Bounds;
				}
				return result;
			}
		}

		public List<HospitalMap> HospitalMaps => _builtHospitalMaps;

		public List<HospitalPlot> HospitalPlots => _hospitalPlots;

		public List<Room> AllRooms { get; private set; }

		public List<RoomDefinition> AvailableRooms => _availableRooms;

		public List<IRoomItemDefinition> AvailableRoomItems => _availableRoomItems;

		public NavMesh NavMesh => _navMesh;

		public List<KeyValuePair<RoomItem, float>>[] NeedSatisfyingRoomItems => _needSatisfyingRoomItems;

		public List<HospitalMap> OwnedHospitalMaps
		{
			get
			{
				List<HospitalMap> list = new List<HospitalMap>(HospitalMaps);
				list.RemoveAll((HospitalMap map) => !map.Plot.Bought);
				return list;
			}
		}

		public GameObject[] PerimeterPrefabs => _config.PerimeterPrefabs;

		public float PerimeterOffset => _config.PerimeterOffset;

		public bool PerimeterNoRotation => _config.PerimeterNoRotation;

		public WorldState(Config config, Level level, Metagame metagame, VisualManager visualManager, Material valueMaterial, RoomItemVisualEdit.Config roomItemEditConfig)
		{
			_config = config;
			_level = level;
			_metagame = metagame;
			_visualManager = visualManager;
			_valueMaterial = valueMaterial;
			_roomItemEditConfig = roomItemEditConfig;
			_invalidNavAreaVisualManager = new InvalidNavAreaVisualManager(_roomItemEditConfig);
			CacheTerrainDetailLayers();
			PostProcessingRendererProxy.Instance.PostProcessRendererData = ((_config?.PostProcessingRendererData != null) ? _config.PostProcessingRendererData : ScriptableObject.CreateInstance<PostProcessingRendererData>());
			PostProcessingRendererProxy.Instance.PostProcessRendererData.FogOfWarDefinition = _config?.FogOfWarDefinition;
			AllRooms = new List<Room>();
			_availableRooms = new List<RoomDefinition>();
			_availableRoomItems = new List<IRoomItemDefinition>();
			SetupAvailableItems(metagame);
			_metagame.OnItemUnlocked.Add(this);
			_builtHospitalMaps = new List<HospitalMap>();
			_unbuiltHospitalMaps = new List<HospitalMap>();
			_hospitalPlots = new List<HospitalPlot>();
			if (config.HospitalPlots != null)
			{
				foreach (SharedInstance<HospitalPlotDefinition> hospitalPlot2 in _config.HospitalPlots)
				{
					_hospitalPlots.Add(new HospitalPlot(hospitalPlot2.Instance, this, level));
				}
			}
			CalculateLighting();
			UpdateNavigation();
			foreach (HospitalPlot hospitalPlot3 in _hospitalPlots)
			{
				if (hospitalPlot3.HospitalMap != null)
				{
					hospitalPlot3.HospitalMap.RebuildConnectedToDoorMap();
				}
			}
			if (_hospitalPlots.Count > 0)
			{
				HospitalPlot hospitalPlot = _hospitalPlots[0];
				if (hospitalPlot.HospitalMap != null)
				{
					GridCoord anchor = hospitalPlot.HospitalMap.Anchor;
					int width = hospitalPlot.HospitalMap.Width;
					int width2 = hospitalPlot.HospitalMap.Width;
					HospitalAttributeMaps.Add(new HospitalAttributeMap(anchor, width, width2, config.initialTemperature, level.BuildEvents));
					HospitalAttributeMaps.Add(new HospitalAttributeMap(anchor, width, width2, config.initialAttractiveness, level.BuildEvents));
					HospitalAttributeMaps.Add(new HospitalAttributeMap(anchor, width, width2, config.initialHygiene, level.BuildEvents));
					CreateEnvironmentRatingCalculators(restoredFromSave: false);
				}
			}
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnAddRoomDefinition = (Action<RoomDefinition, bool, bool, bool>)Delegate.Combine(buildEvents.OnAddRoomDefinition, new Action<RoomDefinition, bool, bool, bool>(OnAddRoomDefinition));
			buildEvents.OnRemoveRoomDefinition = (Action<RoomDefinition>)Delegate.Combine(buildEvents.OnRemoveRoomDefinition, new Action<RoomDefinition>(OnRemoveRoomDefinition));
			buildEvents.OnAddRoomItemDefinition = (Action<RoomItemDefinition, bool, bool, bool>)Delegate.Combine(buildEvents.OnAddRoomItemDefinition, new Action<RoomItemDefinition, bool, bool, bool>(OnAddRoomItemDefinition));
			buildEvents.OnRemoveRoomItemDefinition = (Action<RoomItemDefinition>)Delegate.Combine(buildEvents.OnRemoveRoomItemDefinition, new Action<RoomItemDefinition>(OnRemoveRoomItemDefinition));
		}

		public void SetupAvailableItems(Metagame metagame)
		{
			List<RoomItemDefinitionUGC> list = new List<RoomItemDefinitionUGC>();
			foreach (IRoomItemDefinition availableRoomItem in _availableRoomItems)
			{
				if (availableRoomItem is RoomItemDefinitionUGC item)
				{
					list.Add(item);
				}
			}
			_availableRooms.Clear();
			_availableRoomItems.Clear();
			bool flag = _level.IsSandbox();
			LevelRoomList levelRoomList = (flag ? _level.GetSandboxSettings().GetLevelRoomBlacklist() : _level.Config.GetLevelRoomBlacklist());
			LevelRoomList levelRoomList2 = (flag ? _level.GetSandboxSettings().GetLevelRoomWhitelist() : _level.Config.GetLevelRoomWhitelist());
			SharedInstance<RoomDefinition>[] rooms = metagame.RoomDatabase.Instance.Rooms;
			foreach (SharedInstance<RoomDefinition> sharedInstance in rooms)
			{
				if (sharedInstance != null)
				{
					RoomDefinition roomDef = sharedInstance.Instance;
					if ((roomDef.DlcPackRequired.IsNull() || DLCUtils.IsDLCInstalled(roomDef.DlcPackRequired.Instance)) && (!roomDef.MustBeWhiteListed || (levelRoomList2 != null && levelRoomList2.RoomList.Contains(sharedInstance))) && (levelRoomList == null || !levelRoomList.RoomList.Contains(sharedInstance)))
					{
						bool flag2 = _metagame.HasUnlocked(roomDef);
						bool flag3 = _config._availableRooms.Any((SharedInstance<RoomDefinition> def) => def.Instance == roomDef);
						if (flag2 || flag3)
						{
							bool unlock = flag2 || roomDef.SilverCost() == 0;
							OnAddRoomDefinition(roomDef, unlock, spendSilver: false, showMessage: false);
						}
					}
				}
				else
				{
					Logging.Warning(LogChannels.Metagame, "NULL room in database!");
				}
			}
			LevelItemList levelItemList = (flag ? _level.GetSandboxSettings().GetLevelItemBlacklist() : _level.Config.GetLevelItemBlacklist());
			LevelItemList levelItemList2 = (flag ? _level.GetSandboxSettings().GetLevelItemWhitelist() : _level.Config.GetLevelItemWhitelist());
			SharedInstance<RoomItemDefinition>[] roomItems = metagame.RoomItemDatabase.Instance.RoomItems;
			foreach (SharedInstance<RoomItemDefinition> sharedInstance2 in roomItems)
			{
				if (sharedInstance2 == null)
				{
					Logging.Warning(LogChannels.Metagame, "NULL room item in database!");
					continue;
				}
				RoomItemDefinition instance = sharedInstance2.Instance;
				if (instance.ItemDeprecated || (instance.MustBeWhiteListed && (!(levelItemList2 != null) || !levelItemList2.ItemList.Contains(sharedInstance2))))
				{
					continue;
				}
				bool initiallyAvailable = instance.InitiallyAvailable;
				bool flag4 = _metagame.HasUnlocked(instance);
				bool num = instance.DlcPackRequired.IsNull() && instance.PrimeEntitlementRequired == 0 && instance.CollaborativeResearchRequired.IsNull() && instance.SuperBugVictoryRequired.IsNull();
				bool flag5 = !instance.DlcPackRequired.IsNull() && DLCUtils.IsDLCOwned(instance.DlcPackRequired.Instance);
				bool flag6 = (instance.PrimeEntitlementRequired > 0 && _level.App.UserProfile.PrimeEntitlementClaimed(instance.PrimeEntitlementRequired.ToString())) || flag5;
				bool flag7 = !instance.CollaborativeResearchRequired.IsNull() && (_metagame.IsCollaborativeResearchProjectCompleted(instance.CollaborativeResearchRequired.Instance) || _metagame.GiveAllCollaborativeRewards);
				bool flag8 = !instance.SuperBugVictoryRequired.IsNull() && (_metagame.IsSuperBugVictoryAchieved(instance.SuperBugVictoryRequired.Instance) || _metagame.GiveAllCollaborativeRewards);
				if ((!num && !flag6 && !flag7 && !flag8) || (!flag4 && !initiallyAvailable))
				{
					continue;
				}
				bool flag9 = flag4 || (instance.SilverCost() == 0 && !instance.LockedFreeItem);
				if (!flag9 && _config.RequiredUnlockableItems != null)
				{
					SharedInstance<RoomItemDefinition>[] requiredUnlockableItems = _config.RequiredUnlockableItems;
					foreach (SharedInstance<RoomItemDefinition> sharedInstance3 in requiredUnlockableItems)
					{
						if (sharedInstance3.Instance == instance)
						{
							flag9 = true;
							_metagame.UnlockItem(sharedInstance3.Instance, spendSilver: false, showMessage: false);
						}
					}
				}
				if (levelItemList != null && levelItemList.ItemList.Contains(sharedInstance2))
				{
					flag9 = false;
				}
				OnAddRoomItemDefinition(instance, flag9, spendSilver: false, showMessage: false);
			}
			foreach (RoomItemDefinitionUGC item2 in list)
			{
				_availableRoomItems.Add(item2);
			}
		}

		public void RestoreFromSave(Metagame metagame)
		{
			_metagame = metagame;
			_metagame.OnItemUnlocked.Add(this);
			SetupAvailableItems(metagame);
			CacheTerrainDetailLayers();
			PostProcessingRendererProxy.Instance.PostProcessRendererData = ((_config?.PostProcessingRendererData != null) ? _config.PostProcessingRendererData : ScriptableObject.CreateInstance<PostProcessingRendererData>());
			PostProcessingRendererProxy.Instance.PostProcessRendererData.FogOfWarDefinition = _config?.FogOfWarDefinition;
			foreach (HospitalMap builtHospitalMap in _builtHospitalMaps)
			{
				builtHospitalMap.PreRestoreFromSave();
			}
			foreach (HospitalMap unbuiltHospitalMap in _unbuiltHospitalMaps)
			{
				unbuiltHospitalMap.PreRestoreFromSave();
			}
			foreach (Room allRoom in AllRooms)
			{
				allRoom.RestoreFromSave();
			}
			foreach (HospitalMap builtHospitalMap2 in _builtHospitalMaps)
			{
				builtHospitalMap2.RestoreFromSave();
			}
			foreach (HospitalMap unbuiltHospitalMap2 in _unbuiltHospitalMaps)
			{
				unbuiltHospitalMap2.RestoreFromSave();
			}
			if (_builtHospitalMaps.Count > 0)
			{
				Anchor = _builtHospitalMaps[0].Anchor;
			}
			CalculateLighting();
			_visualManager.RoomLightingManager.RengerateAfterLoad(AllRooms, ExteriorState.Values, Anchor.ToWorldPosition());
			HospitalPlot hospitalPlot = _hospitalPlots[0];
			if (hospitalPlot.HospitalMap != null)
			{
				_navMesh = new NavMesh(hospitalPlot.HospitalMap.FloorPlan.Width(), hospitalPlot.HospitalMap.FloorPlan.Height(), Anchor, 0);
			}
			foreach (HospitalPlot hospitalPlot2 in _hospitalPlots)
			{
				HospitalMap hospitalMap = hospitalPlot2.HospitalMap;
				if (_builtHospitalMaps.Contains(hospitalMap))
				{
					_navMesh.UpdateFromHospitalMap(Anchor, hospitalMap);
				}
				hospitalPlot2.RestoreFromSave();
			}
			_invalidNavAreaVisualManager = new InvalidNavAreaVisualManager(_roomItemEditConfig);
			foreach (HospitalAttributeMap hospitalAttributeMap in HospitalAttributeMaps)
			{
				hospitalAttributeMap.RestoreFromSave();
			}
			UpdateNavigation();
			foreach (HospitalPlot hospitalPlot3 in _hospitalPlots)
			{
				hospitalPlot3.HospitalMap?.RebuildConnectedToDoorMap();
			}
			CreateEnvironmentRatingCalculators(restoredFromSave: true);
			for (int i = 0; i < _needSatisfyingRoomItems.Length; i++)
			{
				List<KeyValuePair<RoomItem, float>> list = _needSatisfyingRoomItems[i];
				if (list == null)
				{
					continue;
				}
				List<RoomItem> list2 = new List<RoomItem>();
				for (int num = list.Count - 1; num >= 0; num--)
				{
					KeyValuePair<RoomItem, float> item = list[num];
					if (list2.Contains(item.Key))
					{
						list.Remove(item);
					}
					else
					{
						list2.Add(item.Key);
					}
				}
			}
			for (int j = 0; j < _needSatisfyingRoomItems.Length; j++)
			{
				List<KeyValuePair<RoomItem, float>> list3 = _needSatisfyingRoomItems[j];
				if (list3 == null)
				{
					continue;
				}
				for (int num2 = list3.Count - 1; num2 >= 0; num2--)
				{
					KeyValuePair<RoomItem, float> item2 = list3[num2];
					if (!item2.Key.HasBeenRestored)
					{
						list3.Remove(item2);
						Logging.Warning(LogChannels.Save, "Removing destroyed room item from WorldState._needSatisfyingRoomItems: Entity ID {0}, Entity: {1}", item2.Key.ID, item2.Key);
					}
				}
			}
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnAddRoomDefinition = (Action<RoomDefinition, bool, bool, bool>)Delegate.Combine(buildEvents.OnAddRoomDefinition, new Action<RoomDefinition, bool, bool, bool>(OnAddRoomDefinition));
			buildEvents.OnRemoveRoomDefinition = (Action<RoomDefinition>)Delegate.Combine(buildEvents.OnRemoveRoomDefinition, new Action<RoomDefinition>(OnRemoveRoomDefinition));
			buildEvents.OnAddRoomItemDefinition = (Action<RoomItemDefinition, bool, bool, bool>)Delegate.Combine(buildEvents.OnAddRoomItemDefinition, new Action<RoomItemDefinition, bool, bool, bool>(OnAddRoomItemDefinition));
			buildEvents.OnRemoveRoomItemDefinition = (Action<RoomItemDefinition>)Delegate.Combine(buildEvents.OnRemoveRoomItemDefinition, new Action<RoomItemDefinition>(OnRemoveRoomItemDefinition));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnAddRoomDefinition = (Action<RoomDefinition, bool, bool, bool>)Delegate.Remove(buildEvents.OnAddRoomDefinition, new Action<RoomDefinition, bool, bool, bool>(OnAddRoomDefinition));
			buildEvents.OnRemoveRoomDefinition = (Action<RoomDefinition>)Delegate.Remove(buildEvents.OnRemoveRoomDefinition, new Action<RoomDefinition>(OnRemoveRoomDefinition));
			buildEvents.OnAddRoomItemDefinition = (Action<RoomItemDefinition, bool, bool, bool>)Delegate.Remove(buildEvents.OnAddRoomItemDefinition, new Action<RoomItemDefinition, bool, bool, bool>(OnAddRoomItemDefinition));
			buildEvents.OnRemoveRoomItemDefinition = (Action<RoomItemDefinition>)Delegate.Remove(buildEvents.OnRemoveRoomItemDefinition, new Action<RoomItemDefinition>(OnRemoveRoomItemDefinition));
			_invalidNavAreaVisualManager.Destroy();
			_metagame.OnItemUnlocked.Remove(this);
			if (_navMesh != null)
			{
				_navMesh.Destroy();
			}
			_hospitalPlots.ClearAndCallDestroy();
			_builtHospitalMaps.ClearAndCallDestroy();
			_unbuiltHospitalMaps.ClearAndCallDestroy();
			AllRooms.ClearAndCallDestroy();
			HospitalAttributeMaps.ClearAndCallDestroy();
			RestoreTerrainDetailLayers();
			EnvironmentRatingCalculator[] environmentCalculators = _environmentCalculators;
			for (int i = 0; i < environmentCalculators.Length; i++)
			{
				environmentCalculators[i].Destroy();
			}
			_level = null;
			base.Destroy();
		}

		public void Update(float deltaTime)
		{
			foreach (HospitalPlot hospitalPlot in _hospitalPlots)
			{
				hospitalPlot.Update(deltaTime);
			}
			_invalidNavAreaVisualManager.Update();
		}

		public void BuildRoom(Room newRoom, int cost)
		{
			UpdateNavigation();
			CalculateLighting();
			_visualManager.RoomLightingManager.BuildRoom(newRoom);
			_level.BuildEvents.OnRoomBuiltEvent.InvokeSafe(newRoom, cost);
		}

		public void AddRoom(Room room, bool animateWalls)
		{
			AllRooms.Add(room);
			RoomAlgorithms.UpdateNeighbouringWindows(room.FloorPlan, this);
			room.FloorPlan.HospitalMap.ModifyHospitalFloorPlan(room, addRoom: true, animateWalls, affectNavigation: true);
			CalculateLighting();
			if (_level != null)
			{
				_level.BuildEvents.OnRoomAdded.InvokeSafe(room);
			}
		}

		public void RemoveRoom(Room room, bool affectNavigation)
		{
			AllRooms.Remove(room);
			RoomAlgorithms.UpdateNeighbouringWindows(room.FloorPlan, this);
			if (room.FloorPlan != null)
			{
				room.FloorPlan.HospitalMap.ModifyHospitalFloorPlan(room, addRoom: false, animateWalls: false, affectNavigation);
				CalculateLighting();
			}
			if (_level != null)
			{
				_level.BuildEvents.OnRoomRemoved.InvokeSafe(room);
			}
		}

		[CanBeNull]
		public Room GetRoomAtWorldCoord(Vector3 worldPosition, bool includeHospital, bool includeClosedPlots)
		{
			return GetRoomAtWorldCoord(worldPosition.ToGridCoord(), includeHospital, includeClosedPlots);
		}

		[CanBeNull]
		public Room GetRoomAtWorldCoord(GridCoord worldCoord, bool includeHospital, bool includeClosedPlots)
		{
			HospitalMap hospitalMapAtWorldPosition = GetHospitalMapAtWorldPosition(worldCoord);
			if (hospitalMapAtWorldPosition != null && hospitalMapAtWorldPosition.FloorPlan.WorldBounds.IsInBounds(worldCoord) && (includeClosedPlots || hospitalMapAtWorldPosition.Room.IsOpen))
			{
				return hospitalMapAtWorldPosition.GetRoomAtWorldCoord(worldCoord, includeHospital);
			}
			return null;
		}

		public void GetRoomsOfType(RoomDefinition.Type type, bool includeClosed, List<Room> roomsOut)
		{
			for (int i = 0; i < AllRooms.Count; i++)
			{
				Room room = AllRooms[i];
				if (room.Definition._type == type && (includeClosed || room.IsOpen))
				{
					roomsOut.Add(room);
				}
			}
		}

		public void IterateRoomsOfType(RoomDefinition definition, bool includeClosed, Action<Room> callback)
		{
			for (int i = 0; i < AllRooms.Count; i++)
			{
				Room room = AllRooms[i];
				if ((definition == null || room.Definition == definition) && (includeClosed || room.IsOpen))
				{
					callback(room);
				}
			}
		}

		public int CountRoomsOfType(RoomDefinition.Type type, bool includeClosed)
		{
			int num = 0;
			for (int i = 0; i < AllRooms.Count; i++)
			{
				Room room = AllRooms[i];
				if (room.Definition._type == type && (includeClosed || room.IsOpen))
				{
					num++;
				}
			}
			return num;
		}

		public void UpdateNavigation()
		{
			if (_navMesh != null)
			{
				_navMesh.UpdateFromRooms(AllRooms, Anchor);
			}
		}

		public void UpdateNavigationFromHospitalMap(HospitalMap hospitalMap)
		{
			if (_navMesh != null)
			{
				_navMesh.UpdateFromHospitalMap(Anchor, hospitalMap);
			}
		}

		public void DebugGUI()
		{
			foreach (Room allRoom in AllRooms)
			{
				allRoom.DebugGUI();
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					item.DebugGUI();
				}
			}
			foreach (HospitalMap builtHospitalMap in _builtHospitalMaps)
			{
				builtHospitalMap.DebugGUI();
			}
			foreach (HospitalMap unbuiltHospitalMap in _unbuiltHospitalMaps)
			{
				unbuiltHospitalMap.DebugGUI();
			}
		}

		public void DebugDraw()
		{
			foreach (Room allRoom in AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					item.DebugDraw();
				}
			}
		}

		private void OnAddRoomDefinition(RoomDefinition definition, bool unlock, bool spendSilver, bool showMessage)
		{
			_availableRooms.AddUnique(definition);
			if (unlock)
			{
				_metagame.UnlockItem(definition, spendSilver, showMessage);
			}
		}

		private void OnRemoveRoomDefinition(RoomDefinition definition)
		{
			_availableRooms.Remove(definition);
		}

		private void OnAddRoomItemDefinition(RoomItemDefinition definition, bool unlock, bool spendSilver, bool showMessage)
		{
			_availableRoomItems.AddUnique(definition);
			if (unlock)
			{
				_metagame.UnlockItem(definition, spendSilver, showMessage);
			}
		}

		private void OnRemoveRoomItemDefinition(RoomItemDefinition definition)
		{
			_availableRoomItems.Remove(definition);
		}

		public List<RoomItem> GetRoomItemsOfType(RoomItemDefinition definition)
		{
			List<RoomItem> list = new List<RoomItem>();
			for (int i = 0; i < AllRooms.Count; i++)
			{
				Room room = AllRooms[i];
				for (int j = 0; j < room.FloorPlan.Items.Count; j++)
				{
					RoomItem roomItem = room.FloorPlan.Items[j];
					if (definition == null || roomItem.Definition == definition)
					{
						list.Add(roomItem);
					}
				}
			}
			return list;
		}

		public List<RoomItem> GetRoomItemsWithMaintenanceDescription(JobMaintenance.JobDescription description)
		{
			List<RoomItem> list = new List<RoomItem>();
			for (int i = 0; i < AllRooms.Count; i++)
			{
				Room room = AllRooms[i];
				for (int j = 0; j < room.FloorPlan.Items.Count; j++)
				{
					RoomItem roomItem = room.FloorPlan.Items[j];
					if (roomItem.Definition.MaintenanceDescription == description)
					{
						list.Add(roomItem);
					}
				}
			}
			return list;
		}

		public Vector3 GetRandomHospitalEntrance()
		{
			if (_entranceCache == null)
			{
				_entranceCache = new List<GridCoord>();
			}
			_entranceCache.Clear();
			foreach (HospitalMap builtHospitalMap in _builtHospitalMaps)
			{
				_entranceCache.AddRange(builtHospitalMap.HospitalEntrances);
			}
			if (_entranceCache.Count != 0)
			{
				return _entranceCache.RandomItem().ToWorldPosition();
			}
			return Vector3.zero;
		}

		public IRoomItemDefinition GetRoomWindowDefinition(RoomDefinition.Type roomType)
		{
			foreach (IRoomItemDefinition availableRoomItem in _availableRoomItems)
			{
				if (availableRoomItem.ItemType == RoomItemDefinition.Type.Window && availableRoomItem.CanBePlacedIn(roomType))
				{
					return availableRoomItem;
				}
			}
			return null;
		}

		public void GetItemsForRoom(RoomDefinition.Type roomType, bool decorationOnly, List<IRoomItemDefinition> outItems)
		{
			foreach (IRoomItemDefinition availableRoomItem in _availableRoomItems)
			{
				if (availableRoomItem.CanBePlacedIn(roomType) && (!decorationOnly || (availableRoomItem.ItemType != RoomItemDefinition.Type.Door && availableRoomItem.ItemType != RoomItemDefinition.Type.Window)) && availableRoomItem.ItemType != RoomItemDefinition.Type.Landscape && availableRoomItem.ItemType != RoomItemDefinition.Type.Special && availableRoomItem.ItemType != RoomItemDefinition.Type.PlotObject)
				{
					outItems.Add(availableRoomItem);
				}
			}
		}

		public bool IsExterior(Vector3 worldPosition)
		{
			GridCoord gridCoord = worldPosition.ToGridCoord() - Anchor;
			if (gridCoord.X < 0 || gridCoord.X >= ExteriorState.Values.GetLength(0) || gridCoord.Y < 0 || gridCoord.Y >= ExteriorState.Values.GetLength(1))
			{
				return false;
			}
			return ExteriorState.Values[gridCoord.X, gridCoord.Y];
		}

		public HospitalMap GetHospitalPlotAtWorldPosition(GridCoord worldCoord)
		{
			for (int i = 0; i < _unbuiltHospitalMaps.Count; i++)
			{
				HospitalMap hospitalMap = _unbuiltHospitalMaps[i];
				GridCoord gridCoord = worldCoord - hospitalMap.Anchor;
				if (hospitalMap.FloorPlan.ValidCoord(gridCoord) && (hospitalMap.FloorPlan[gridCoord] || hospitalMap.WorldRooms[gridCoord.X, gridCoord.Y] != null))
				{
					return hospitalMap;
				}
			}
			return null;
		}

		public HospitalMap GetHospitalPlotAtWorldPosition(Vector3 worldPosition)
		{
			return GetHospitalPlotAtWorldPosition(worldPosition.ToGridCoord());
		}

		public HospitalMap GetHospitalMapAtWorldPosition(GridCoord worldCoord)
		{
			int num = worldCoord.X - Anchor.X;
			int num2 = worldCoord.Y - Anchor.Y;
			foreach (HospitalMap builtHospitalMap in _builtHospitalMaps)
			{
				bool[,] tiles = builtHospitalMap.FloorPlan.Tiles;
				if (num >= 0 && num2 >= 0 && num < tiles.GetLength(0) && num2 < tiles.GetLength(1) && (tiles[num, num2] || builtHospitalMap.WorldRooms[num, num2] != null))
				{
					return builtHospitalMap;
				}
			}
			return null;
		}

		public HospitalMap GetHospitalMapAtWorldPosition(Vector3 worldPosition)
		{
			return GetHospitalMapAtWorldPosition(worldPosition.ToGridCoord());
		}

		public HospitalMap CreateHospitalMap(HospitalPlot plot, bool animateWalls)
		{
			return new HospitalMap(plot, _level, this, _visualManager, _valueMaterial, _roomItemEditConfig, animateWalls);
		}

		public void DestroyHospitalMap(HospitalMap hospitalMap)
		{
			_builtHospitalMaps.Remove(hospitalMap);
			_unbuiltHospitalMaps.Remove(hospitalMap);
			hospitalMap.Destroy();
		}

		public void SetBoughtHospitalMap(HospitalMap hospitalMap)
		{
			if (_builtHospitalMaps.Contains(hospitalMap))
			{
				hospitalMap.Room.Open();
				UpdateNavigationFromHospitalMap(hospitalMap);
				UpdateNavigation();
				RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, null, hospitalMap.FloorPlan, this, null, null);
			}
		}

		public void SetBuiltHospitalMap(HospitalMap hospitalMap)
		{
			if (!_builtHospitalMaps.Contains(hospitalMap))
			{
				FloorPlan floorPlan = hospitalMap.FloorPlan;
				if (_builtHospitalMaps.Count == 0)
				{
					Anchor = hospitalMap.Anchor;
				}
				if (_navMesh == null)
				{
					_navMesh = new NavMesh(floorPlan.Width(), floorPlan.Height(), Anchor, 0);
				}
				_navMesh.UpdateFromHospitalMap(Anchor, hospitalMap);
				_builtHospitalMaps.Add(hospitalMap);
				_unbuiltHospitalMaps.Remove(hospitalMap);
				UpdateNavigation();
				CalculateLighting();
				RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, null, hospitalMap.FloorPlan, this, null, null);
			}
		}

		public void CalculateLighting()
		{
			if (ExteriorState.Values == null && _hospitalPlots.Count != 0)
			{
				HospitalPlot hospitalPlot = _hospitalPlots[0];
				if (hospitalPlot.HospitalMap != null)
				{
					ExteriorState.Values = new bool[hospitalPlot.HospitalMap.Width, hospitalPlot.HospitalMap.Height];
				}
			}
			if (ExteriorState.Values == null)
			{
				return;
			}
			bool flag = _level.DataViewManager != null && _level.DataViewManager.CurrentMode != DataViewManager.Mode.None;
			ArrayUtils.Populate(ExteriorState.Values, value: true);
			foreach (HospitalMap builtHospitalMap in _builtHospitalMaps)
			{
				if (builtHospitalMap.Plot.Definition.InstaBuild)
				{
					continue;
				}
				if (!flag && builtHospitalMap.FloorPlan.HasNoVisibleExteriorWalls())
				{
					for (int i = 0; i < ExteriorState.Values.GetLength(0); i++)
					{
						for (int j = 0; j < ExteriorState.Values.GetLength(1); j++)
						{
							GridCoord worldCoord = new GridCoord(i + Anchor.X, j + Anchor.Y);
							Room roomAtWorldCoord = GetRoomAtWorldCoord(worldCoord, includeHospital: false, includeClosedPlots: false);
							ExteriorState.Values[i, j] = roomAtWorldCoord?.Definition.IsLowWallRoom() ?? true;
						}
					}
					continue;
				}
				bool[,] indoorState = builtHospitalMap.IndoorState;
				for (int k = 0; k < indoorState.GetLength(0); k++)
				{
					for (int l = 0; l < indoorState.GetLength(1); l++)
					{
						if (indoorState[k, l])
						{
							ExteriorState.Values[k, l] = false;
						}
					}
				}
			}
			_visualManager.RoomLightingManager.RegenerateInteriorVolumeLights();
			_visualManager.RoomLightingManager.RegenerateExteriorVolumeLights(ExteriorState.Values, Anchor.ToWorldPosition());
		}

		public void SetUnbuiltHospitalPlot(HospitalMap hospitalMap)
		{
			if (!_unbuiltHospitalMaps.Contains(hospitalMap))
			{
				_builtHospitalMaps.Remove(hospitalMap);
				_unbuiltHospitalMaps.Add(hospitalMap);
				CalculateLighting();
				UpdateNavigation();
			}
		}

		public void GetLandscapeItems(out List<RoomItemDefinition> items)
		{
			items = new List<RoomItemDefinition>();
			SharedInstance<RoomItemDefinition>[] roomItems = _metagame.LandscapeItemDatabase.Instance.RoomItems;
			foreach (SharedInstance<RoomItemDefinition> sharedInstance in roomItems)
			{
				if (sharedInstance.NotNull())
				{
					items.Add(sharedInstance.Instance);
				}
			}
		}

		public RoomDefinition GetBuiltRoomDefinition()
		{
			return _config._roomBuiltDefinition.Instance;
		}

		public RoomDefinition GetBuildingRoomDefinition()
		{
			return _config._roomBuildingDefinition.Instance;
		}

		public RoomDefinition GetUnbuiltRoomDefinition()
		{
			return _config._roomUnbuiltDefinition.Instance;
		}

		public RoomItemDefinition GetMainEntranceDefinition()
		{
			if (!_config.MainEntranceDefinition.IsNull())
			{
				return _config.MainEntranceDefinition.Instance;
			}
			return null;
		}

		public RoomItemDefinition GetSideEntranceDefinition()
		{
			if (!_config.SideEntranceDefinition.IsNull())
			{
				return _config.SideEntranceDefinition.Instance;
			}
			return null;
		}

		public RoomItemDefinition GetInternalEntranceDefinition()
		{
			if (!_config.InternalEntranceDefinition.IsNull())
			{
				return _config.InternalEntranceDefinition.Instance;
			}
			return null;
		}

		public RoomWallDefinition GetCorridorWallDefinition()
		{
			if (!_config.CorridorWallDefinition.IsNull())
			{
				return _config.CorridorWallDefinition.Instance;
			}
			return null;
		}

		public RoomItemDefinition GetWindowDefinition()
		{
			return _config.WindowDefinition.Instance;
		}

		public bool ShouldCreateBaseLandscapeItems()
		{
			return _config.createBaseLandscapeItems;
		}

		public HospitalPlot GetHospitalPlotFromRoom(Room room)
		{
			foreach (HospitalPlot hospitalPlot in _hospitalPlots)
			{
				if (hospitalPlot.HospitalMap != null && hospitalPlot.HospitalMap.Room == room)
				{
					return hospitalPlot;
				}
			}
			return null;
		}

		public int GetHospitalPlotIndex(HospitalPlot hospitalPlot)
		{
			for (int i = 0; i < _hospitalPlots.Count; i++)
			{
				if (_hospitalPlots[i] == hospitalPlot)
				{
					return i;
				}
			}
			return -1;
		}

		public void AddNeedSatisfyingRoomItem(RoomItem roomItem)
		{
			if (roomItem.Definition.InteractionAttributeModifiers == null)
			{
				return;
			}
			InteractionAttributeModifier[] interactionAttributeModifiers = roomItem.Definition.InteractionAttributeModifiers;
			foreach (InteractionAttributeModifier interactionAttributeModifier in interactionAttributeModifiers)
			{
				if (interactionAttributeModifier._interactionType != InteractionAttributeModifier.Type.Use)
				{
					continue;
				}
				CharacterAttributeModifier[] characterModifiers = interactionAttributeModifier._characterModifiers;
				foreach (CharacterAttributeModifier characterAttributeModifier in characterModifiers)
				{
					if (!characterAttributeModifier.IsNeedModifer())
					{
						continue;
					}
					float num = characterAttributeModifier.Amount();
					if (num < 0f)
					{
						if (_needSatisfyingRoomItems[(int)characterAttributeModifier.Type] == null)
						{
							_needSatisfyingRoomItems[(int)characterAttributeModifier.Type] = new List<KeyValuePair<RoomItem, float>>();
						}
						_needSatisfyingRoomItems[(int)characterAttributeModifier.Type].Add(new KeyValuePair<RoomItem, float>(roomItem, 0f - num));
					}
				}
			}
		}

		public void RemoveNeedSatisfyingRoomItem(RoomItem roomItem)
		{
			for (int i = 0; i < _needSatisfyingRoomItems.Length; i++)
			{
				_needSatisfyingRoomItems[i]?.RemoveAll(delegate(KeyValuePair<RoomItem, float> pair)
				{
					_ = pair.Key;
					_ = roomItem;
					return pair.Key == roomItem;
				});
			}
		}

		public void OnItemUnlockedEvent(ISilverUnlockable item)
		{
			if (item is RoomDefinition)
			{
				_availableRooms.AddUnique((RoomDefinition)item);
			}
			else if (item is RoomItemDefinition)
			{
				_availableRoomItems.AddUnique((RoomItemDefinition)item);
			}
		}

		public HospitalPlot GetHospitalPlot(HospitalPlotDefinition definition)
		{
			foreach (HospitalPlot hospitalPlot in _hospitalPlots)
			{
				if (hospitalPlot.Definition == definition)
				{
					return hospitalPlot;
				}
			}
			return null;
		}

		private void CacheTerrainDetailLayers()
		{
			if (DebugVars.AllowTerrainModification.Value && _detailLayers == null && Terrain.activeTerrain != null && Terrain.activeTerrain.terrainData != null)
			{
				TerrainData terrainData = Terrain.activeTerrain.terrainData;
				_detailLayers = new List<int[,]>(terrainData.detailPrototypes.Length);
				for (int i = 0; i < terrainData.detailPrototypes.Length; i++)
				{
					_detailLayers.Add(terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, i));
				}
			}
		}

		private void RestoreTerrainDetailLayers()
		{
			if (!DebugVars.AllowTerrainModification.Value || _detailLayers == null)
			{
				return;
			}
			if (Terrain.activeTerrain != null && Terrain.activeTerrain.terrainData != null)
			{
				TerrainData terrainData = Terrain.activeTerrain.terrainData;
				for (int i = 0; i < _detailLayers.Count; i++)
				{
					terrainData.SetDetailLayer(0, 0, i, _detailLayers[i]);
				}
			}
			_detailLayers = null;
		}

		private void CreateEnvironmentRatingCalculators(bool restoredFromSave)
		{
			_environmentCalculators = new EnvironmentRatingCalculator[3];
			for (int i = 0; i < 3; i++)
			{
				EnvironmentRatingCalculator calculator = new EnvironmentRatingCalculator(_level, this, (HospitalAttributeMap.Attribute)i);
				_environmentCalculators[i] = calculator;
				HospitalAttributeMap hospitalAttributeMap = HospitalAttributeMaps[i];
				hospitalAttributeMap.OnMapUpdated = (System.Action)Delegate.Combine(hospitalAttributeMap.OnMapUpdated, (System.Action)delegate
				{
					calculator.Recalc();
				});
				if (restoredFromSave)
				{
					calculator.RestoreFromSave();
				}
			}
		}

		public int GetEnvironmentRating(HospitalAttributeMap.Attribute attribute)
		{
			if (_environmentCalculators == null)
			{
				return 0;
			}
			return _environmentCalculators[(int)attribute].Rating;
		}

		internal void ShowUnreachableNavIsland(RoomBuildingNavMesh roomBuildingNavMesh, RoomItem roomItem)
		{
			if (GetHospitalMapAtWorldPosition(roomItem.WorldPosition) != null && roomItem.UnreachableInteraction != null && roomItem.Visual != null && roomItem.Visual.StartTransforms.TryGetValue(roomItem.UnreachableInteraction, out var value))
			{
				int areaIDAtPosition = roomBuildingNavMesh.GetAreaIDAtPosition(value.position);
				if (areaIDAtPosition != -1)
				{
					_invalidNavAreaVisualManager.ShowUnreachableNavIsland(roomBuildingNavMesh, areaIDAtPosition);
				}
			}
		}

		public void DestroyAllRooms()
		{
			Room[] array = AllRooms.ToArray();
			foreach (Room room in array)
			{
				if (room.Definition.IsHospitalOrBay || room.Definition.IsHospitalUnbuilt)
				{
					RoomItem[] array2 = room.FloorPlan.Items.ToArray();
					foreach (RoomItem roomItem in array2)
					{
						RoomItemDefinition.Type itemType = roomItem.Definition.ItemType;
						if (itemType != RoomItemDefinition.Type.Door && itemType != RoomItemDefinition.Type.SideDoor)
						{
							_level.BuildEvents.OnRoomItemDestroy.InvokeSafe(roomItem);
						}
					}
				}
				else
				{
					room.Close();
					RemoveRoom(room, affectNavigation: true);
					room.FloorPlan.RemoveItemsFromWorld();
					room.Destroy();
				}
			}
		}
	}
}
