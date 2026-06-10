using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GlobalStats;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.GlobalStats;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Objectives;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.UI;
using Objectives;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.WorldMap
{
	public class WorldMapViewMainScene : WorldMapView
	{
		[SerializeField]
		private GameObject villageMarkerPrefab;

		[SerializeField]
		private GameObject worldMapUIContent;

		[SerializeField]
		private GameObject selectionMarker;

		[SerializeField]
		private LayoutGroupView globalStatEntriesParent;

		[SerializeField]
		private GameObject activeObjectiveUI;

		[SerializeField]
		private TMP_Text activeObjectiveName;

		[SerializeField]
		private TMP_Text activeObjectiveInfo;

		[SerializeField]
		private LayoutGroupView objectiveTasksListUI;

		[NonSerialized]
		private readonly List<GlobalStatListItemView> globalStatEntries = new List<GlobalStatListItemView>();

		[NonSerialized]
		private readonly Dictionary<GlobalStatInstance, GlobalStatListItemView> viewByGlobalStat = new Dictionary<GlobalStatInstance, GlobalStatListItemView>();

		[NonSerialized]
		private readonly Dictionary<WorldMapPlace, GameObject> gameObjectsByPlace = new Dictionary<WorldMapPlace, GameObject>();

		[NonSerialized]
		private readonly List<LayoutGroupItemView> objectiveTasksList = new List<LayoutGroupItemView>();

		private GameObject playerVillageMarkerInstance;

		private string influenceLocalized;

		private WorldMap worldMap;

		private bool skipInputOnNextFrame;

		protected override void Update()
		{
			if (MonoSingleton<WorldMap>.Instance.IsWorldMapVisible)
			{
				if (skipInputOnNextFrame)
				{
					skipInputOnNextFrame = false;
				}
				else if (!(EventSystem.current != null) || !EventSystem.current.IsPointerOverGameObject())
				{
					base.Update();
				}
			}
		}

		protected override Vector3 GetMousePosition()
		{
			return MonoSingleton<CameraManager>.Instance.GameplayCamera.ScreenToViewportPoint(Input.mousePosition);
		}

		private void Start()
		{
			worldMap = MonoSingleton<WorldMap>.Instance;
			if (GlobalSaveController.CurrentVillageData.IsSecondMap && worldMap.Data == null)
			{
				worldMap.Data = GlobalSaveController.CurrentVillageData.WorldMapData;
			}
			MonoSingleton<WorldMap>.Instance.InitFromMainScene();
			WorldMapCamera = MonoSingleton<WorldMap>.Instance.MainSceneWorldCamera;
			worldMap.Data.CheckUpdateOldSave();
			PlaceVillageMarker();
			PlaceNeighborVillageMarkers();
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			MonoSingleton<WorldMapController>.Instance.PlaceClickedEvent += OnPlaceClicked;
			MonoSingleton<WorldMapController>.Instance.PlaceDeselectClickedEvent += OnPlaceDeselectClicked;
			MonoSingleton<WorldMapController>.Instance.CaravanClickedEvent += OnCaravanClicked;
			worldMap.MarkerManager.MarkerDestroyedEvent += OnMarkerDestroyed;
			CaravanController instance = MonoSingleton<CaravanController>.Instance;
			instance.SelectedCaravanEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance.SelectedCaravanEvent, new CaravanController.CaravanDelegate(OnCaravanSelected));
			CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
			instance2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturnedHome));
			MonoSingleton<GlobalStatController>.Instance.GlobalStatValueSetEvent += OnGlobalStatValueSet;
			MonoSingleton<GlobalStatController>.Instance.GlobalStatTriggerActivatedEvent += ObGlobalStatTriggerActivated;
			MonoSingleton<GlobalStatController>.Instance.ObjectiveActivatedEvent += OnObjectiveActivated;
			MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskRequirementChangedEvent += OnObjectiveTaskRequirementChanged;
			MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskCompletedEvent += OnObjectiveTaskCompleted;
			MonoSingleton<GameEventSystemController>.Instance.GameEventStarted += OnGameEventStarted;
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnGameEventEnded;
			influenceLocalized = MonoSingleton<LocalizationController>.Instance.GetText("ui_region_influence");
			MonoSingleton<WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: false);
			selectionMarker.SetActive(value: false);
		}

		private void OnMarkerDestroyed(WorldMapMarkerPlace marker)
		{
			OnPlaceDeselectClicked();
		}

		private void OnDestroy()
		{
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
				MonoSingleton<WorldMapController>.Instance.PlaceClickedEvent -= OnPlaceClicked;
				MonoSingleton<WorldMapController>.Instance.PlaceDeselectClickedEvent -= OnPlaceDeselectClicked;
				MonoSingleton<WorldMapController>.Instance.CaravanClickedEvent -= OnCaravanClicked;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController instance = MonoSingleton<CaravanController>.Instance;
				instance.SelectedCaravanEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance.SelectedCaravanEvent, new CaravanController.CaravanDelegate(OnCaravanSelected));
				CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
				instance2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturnedHome));
			}
			if (MonoSingleton<GlobalStatController>.IsInstantiated())
			{
				MonoSingleton<GlobalStatController>.Instance.GlobalStatValueSetEvent -= OnGlobalStatValueSet;
				MonoSingleton<GlobalStatController>.Instance.GlobalStatTriggerActivatedEvent -= ObGlobalStatTriggerActivated;
				MonoSingleton<GlobalStatController>.Instance.ObjectiveActivatedEvent -= OnObjectiveActivated;
			}
			if (MonoSingleton<ObjectiveController>.IsInstantiated())
			{
				MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskRequirementChangedEvent -= OnObjectiveTaskRequirementChanged;
				MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskCompletedEvent -= OnObjectiveTaskCompleted;
			}
			if (MonoSingleton<WorldMap>.IsInstantiated())
			{
				MonoSingleton<WorldMap>.Instance.DestroyGeneratedContent();
				MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent -= OnMarkerDestroyed;
			}
			if (MonoSingleton<GameEventSystemController>.IsInstantiated())
			{
				MonoSingleton<GameEventSystemController>.Instance.GameEventStarted -= OnGameEventStarted;
				MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnGameEventEnded;
			}
		}

		private void OnWorldMapVisibilitySet(bool isEnabled)
		{
			worldMapUIContent.gameObject.SetActive(isEnabled);
			skipInputOnNextFrame = true;
			if (isEnabled)
			{
				UpdateGlobalStatEntriesUIInternal();
			}
		}

		private void ScheduleUpdateGlobalStatEntriesUI()
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "UpdateGlobalStatEntriesUI", UpdateGlobalStatEntriesUIInternal);
		}

		private void UpdateGlobalStatEntriesUIInternal()
		{
			if (!base.isActiveAndEnabled || !MonoSingleton<World>.IsInstantiated() || !MonoSingleton<World>.Instance.IsLoaded || !MonoSingleton<WorldMap>.Instance.IsWorldMapVisible)
			{
				return;
			}
			viewByGlobalStat.Clear();
			ObjectiveInstance activeObjective = worldMap.Data.ActiveObjective;
			if (activeObjective != null)
			{
				activeObjectiveName.SetText(activeObjective.Blueprint.GetNameLocalized());
				activeObjectiveInfo.SetText(activeObjective.Blueprint.GetInfoLocalized());
				activeObjectiveUI?.SetActive(value: true);
				int num = 0;
				for (int i = 0; i < activeObjective.Blueprint.Tasks.Length; i++)
				{
					ObjectiveTask objectiveTask = activeObjective.Blueprint.Tasks[i];
					if (!objectiveTask.Hidden)
					{
						LayoutGroupItemView at = objectiveTasksList.GetAt(objectiveTasksListUI, num);
						if (!at.gameObject.activeSelf)
						{
							at.gameObject.SetActive(value: true);
						}
						activeObjective.FillUITaskView(objectiveTask, at);
						num++;
					}
				}
				objectiveTasksList.SetActiveFromIndex(activeObjective.Blueprint.Tasks.Length, active: false);
				globalStatEntries.SetActiveFromIndex(0, active: false);
				return;
			}
			activeObjectiveUI?.SetActive(value: false);
			int num2 = 0;
			foreach (GlobalStatInstance globalStatInstance in worldMap.Data.GlobalStatInstances)
			{
				if (!globalStatInstance.IsHidden())
				{
					GlobalStatListItemView at2 = globalStatEntries.GetAt(globalStatEntriesParent, num2);
					viewByGlobalStat.Add(globalStatInstance, at2);
					at2.SetGlobalStatInstance(globalStatInstance);
					at2.Show();
					num2++;
				}
			}
			globalStatEntries.SetActiveFromIndex(num2, active: false);
		}

		private void OnGlobalStatValueSet(GlobalStatInstance globalStatInstance, float oldValue, bool _)
		{
			if (MonoSingleton<WorldMap>.Instance.IsWorldMapVisible && !LoadingController.IsSceneTransition && viewByGlobalStat.TryGetValue(globalStatInstance, out var value))
			{
				value.UpdateGlobalStatValue();
			}
		}

		private void ObGlobalStatTriggerActivated(GlobalStatInstance globalStatInstance, GlobalStatTrigger globalStatTrigger)
		{
			if (MonoSingleton<WorldMap>.Instance.IsWorldMapVisible && !LoadingController.IsSceneTransition)
			{
				GlobalStatListItemView value;
				if (globalStatTrigger.StartShowing)
				{
					ScheduleUpdateGlobalStatEntriesUI();
				}
				else if (viewByGlobalStat.TryGetValue(globalStatInstance, out value))
				{
					value.SetGlobalStatInstance(globalStatInstance);
				}
			}
		}

		private void OnObjectiveActivated(ObjectiveInstance objectiveInstance)
		{
			ScheduleUpdateGlobalStatEntriesUI();
		}

		private void OnObjectiveTaskRequirementChanged(ObjectiveInstance objectiveInstance, ObjectiveTask task, ObjectiveTaskRequirement requirement)
		{
			ScheduleUpdateGlobalStatEntriesUI();
		}

		private void OnObjectiveTaskCompleted(ObjectiveInstance objectiveInstance, ObjectiveTask task, bool isCompleted)
		{
			ScheduleUpdateGlobalStatEntriesUI();
		}

		private void OnGameEventStarted(GameEventInstance gameEventStarted)
		{
			ScheduleUpdateGlobalStatEntriesUI();
		}

		private void OnGameEventEnded(GameEventInstance gameEventEnded)
		{
			ScheduleUpdateGlobalStatEntriesUI();
		}

		private void RemoveHiddenVillagePlaces()
		{
			for (int num = MonoSingleton<WorldMap>.Instance.Data.VillagePlaces.Count; num >= 0; num--)
			{
				if (num < MonoSingleton<WorldMap>.Instance.Data.VillagePlaces.Count)
				{
					VillagePlace villagePlace = MonoSingleton<WorldMap>.Instance.Data.VillagePlaces[num];
					if (villagePlace.FactionInstance == null || villagePlace.FactionInstance.Blueprint == null || villagePlace.FactionInstance.Blueprint.FactionType.HideOnMap)
					{
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapViewMainScene.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Removing village place ");
							messageBuilder.AppendFormatted(villagePlace.Name);
							messageBuilder.AppendLiteral(" | ");
							messageBuilder.AppendFormatted(villagePlace.FactionInstance?.BlueprintId);
						}
						Log.Info(messageBuilder);
						MonoSingleton<WorldMap>.Instance.Data.VillagePlaces.Remove(villagePlace);
					}
				}
			}
		}

		private void PlaceNeighborVillageMarkers()
		{
			RemoveHiddenVillagePlaces();
			gameObjectsByPlace.Clear();
			List<VillagePlace> villagePlaces = MonoSingleton<WorldMap>.Instance.Data.VillagePlaces;
			System.Random random = new System.Random(GlobalSaveController.CurrentVillageData.MapSeed.GetHashCode());
			foreach (VillagePlace item in villagePlaces)
			{
				int index = random.Next(0, item.FactionInstance.Blueprint.Prefabs.Count);
				GameObject gameObject = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(item.FactionInstance.Blueprint.Prefabs[index]), MonoSingleton<WorldMap>.Instance.HeightmapContent.transform);
				gameObject.transform.localPosition = new Vector3(item.Position.x, MonoSingleton<WorldMap>.Instance.GetHeightAt(item.Position), item.Position.y);
				gameObject.SetActive(value: true);
				gameObjectsByPlace.Add(item, gameObject);
				gameObject.name = item.FactionInstance.Blueprint.FactionType.GetID() ?? "";
				WorldMapItemVillage componentInChildren = gameObject.GetComponentInChildren<WorldMapItemVillage>();
				if (componentInChildren != null)
				{
					componentInChildren.SetVillagePlace(item);
				}
			}
		}

		private void PlaceVillageMarker()
		{
			Vector2Int villagePosition = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			playerVillageMarkerInstance = UnityEngine.Object.Instantiate(villageMarkerPrefab, MonoSingleton<WorldMap>.Instance.HeightmapContent.transform);
			playerVillageMarkerInstance.transform.localPosition = new Vector3(villagePosition.x, MonoSingleton<WorldMap>.Instance.GetHeightAt(villagePosition), villagePosition.y);
			playerVillageMarkerInstance.SetActive(value: true);
		}

		private void OnPlaceClicked(WorldMapPlace selectedPlace)
		{
			if (selectedPlace != null)
			{
				GameObject gameObject = null;
				if (selectedPlace is VillagePlace)
				{
					gameObject = gameObjectsByPlace[selectedPlace];
				}
				else if (selectedPlace is WorldMapMarkerPlace markerPlace)
				{
					gameObject = worldMap.MarkerManager.GetMarkerView(markerPlace)?.gameObject;
				}
				if (!(gameObject == null))
				{
					selectionMarker.transform.parent = gameObject.transform;
					selectionMarker.transform.localPosition = Vector3.zero;
					selectionMarker.SetActive(value: true);
					MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonClick");
				}
			}
		}

		private void OnPlaceDeselectClicked()
		{
			if (!(selectionMarker.transform.parent == null))
			{
				selectionMarker.transform.parent = null;
				selectionMarker.SetActive(value: false);
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonClose");
			}
		}

		private void OnCaravanSelected(CaravanInstance caravanInstance)
		{
			if (MonoSingleton<WorldMap>.Instance.IsWorldMapVisible)
			{
				HighlightCaravan(caravanInstance);
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				HighlightCaravan(caravanInstance);
			});
		}

		private void OnCaravanClicked(CaravanInstance caravanInstance)
		{
			if (HighlightCaravan(caravanInstance))
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonClick");
			}
		}

		private bool HighlightCaravan(CaravanInstance caravanInstance)
		{
			CaravanView view = MonoSingleton<CaravanManager>.Instance.GetView(caravanInstance);
			if (view == null)
			{
				return false;
			}
			selectionMarker.transform.parent = view.transform;
			selectionMarker.transform.localPosition = Vector3.zero;
			selectionMarker.SetActive(value: true);
			return true;
		}

		private void OnCaravanReturnedHome(CaravanInstance caravanInstance)
		{
			CaravanView view = MonoSingleton<CaravanManager>.Instance.GetView(caravanInstance);
			if (selectionMarker.transform.parent == view.transform)
			{
				selectionMarker.transform.parent = null;
				selectionMarker.SetActive(value: false);
			}
		}
	}
}
