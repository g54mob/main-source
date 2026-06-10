using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.DevConsole;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.RoomDetection;
using NSMedieval.Sound;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TopLeftPanelView : UIView, IObserver
	{
		[Header("Buttons")]
		[SerializeField]
		private SoundButton[] topLeftButtons;

		[SerializeField]
		private SoundButton workerJobsButton;

		[SerializeField]
		private SoundButton workerScheduleButton;

		[SerializeField]
		private SoundButton workerResearchButton;

		[SerializeField]
		private SoundButton workerManageButton;

		[FormerlySerializedAs("animalsButton")]
		[SerializeField]
		private SoundButton overviewButton;

		[SerializeField]
		private SoundButton worldButton;

		[SerializeField]
		private SoundButton leaveMapButton;

		[SerializeField]
		private SoundButton travelButton;

		[SerializeField]
		private SoundButton devToolsButton;

		[Header("View Controls")]
		[SerializeField]
		private SoundButton[] viewControlsButtons;

		[SerializeField]
		private RectTransform viewControlsRect;

		[SerializeField]
		private SoundButton layerUpButton;

		[SerializeField]
		private SoundButton layerDownButton;

		[SerializeField]
		private TextMeshProUGUI currentLayerText;

		[SerializeField]
		private Animator layerFlashAnimator;

		[SerializeField]
		private Image roofHidden;

		[SerializeField]
		private Image treesHidden;

		[SerializeField]
		private SoundButton showHideRoofsButton;

		[SerializeField]
		private SoundButton showHideTreesButton;

		[SerializeField]
		private SoundButton cameraButton;

		[SerializeField]
		private Image roomsHidden;

		[SerializeField]
		private SoundButton showHideRoomsButton;

		[SerializeField]
		private Image zoneGridHidden;

		[SerializeField]
		private SoundButton showHideZoneGridButton;

		[SerializeField]
		private Image resourceIndicatorsHidden;

		[SerializeField]
		private SoundButton showHideResourceIndicatorsButton;

		[SerializeField]
		private Image resourceGroupsHidden;

		[SerializeField]
		private SoundButton showHideResourceGroupsButton;

		[SerializeField]
		private Image beautyOverlayHidden;

		[SerializeField]
		private SoundButton toggleBeautyOverlayButton;

		[SerializeField]
		private Image temperatureOverlayHidden;

		[SerializeField]
		private SoundButton toggleTemperatureOverlayButton;

		[SerializeField]
		private GameObject heatmapObjectUI;

		[SerializeField]
		private RawImage heatmapGradientImage;

		[SerializeField]
		private TMP_Text heatmapMinText;

		[SerializeField]
		private TMP_Text heatmapMaxText;

		[SerializeField]
		private TMP_Text heatmapCenterText;

		[Header("Camera Controls")]
		[SerializeField]
		private SoundButton resetCameraButton;

		[SerializeField]
		private SoundButton lockCameraToLayerButton;

		[SerializeField]
		private SoundButton lockCameraToLayerUp;

		[SerializeField]
		private SoundButton lockCameraToLayerDown;

		[SerializeField]
		private GameObject cameraLockedLayer;

		[SerializeField]
		private GameObject cameraOptions;

		[SerializeField]
		private Image cameraOptionsHidden;

		[SerializeField]
		private Image cameraLockHidden;

		[SerializeField]
		private TMP_Text lockedLayerText;

		[SerializeField]
		private Animator lockedLayerFlashAnimator;

		private Dictionary<string, SoundButton> viewButtonDictionary = new Dictionary<string, SoundButton>();

		private Dictionary<string, SoundButton> topLeftButtonDictionary = new Dictionary<string, SoundButton>();

		private int previousZoneColor;

		private World world;

		public RectTransform ViewControlsRect
		{
			get
			{
				return viewControlsRect;
			}
			set
			{
				viewControlsRect = value;
			}
		}

		private void Start()
		{
			world = MonoSingleton<World>.Instance;
			world.LayerChangeEvent += OnLayerChanged;
			world.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<UIController>.Instance.DevToolsActive += OnDevToolsActive;
			workerJobsButton.onClick.AddListener(ShowJobsPanel);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Jobs, ShowJobsPanel, activeOnWorldMap: true);
			workerScheduleButton.onClick.AddListener(ShowSchedulePanel);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Schedule, ShowSchedulePanel, activeOnWorldMap: true);
			workerManageButton.onClick.AddListener(ShowManagePanel);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Manage, ShowManagePanel, activeOnWorldMap: true);
			overviewButton.onClick.AddListener(ShowOverviewPanel);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Animals, ShowOverviewPanel, activeOnWorldMap: true);
			cameraButton.onClick.AddListener(ToggleCameraOptions);
			lockCameraToLayerButton.onClick.AddListener(ToggleCameraLockLayers);
			lockCameraToLayerUp.onClick.AddListener(OnLockCameraLayerUp);
			lockCameraToLayerDown.onClick.AddListener(OnLockCameraLayerDown);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.LockCameraToLayer, ToggleCameraLockLayers);
			MonoSingleton<RtsCamera>.Instance.LockedLayerUpEvent += OnLockCameraLayerUp;
			MonoSingleton<RtsCamera>.Instance.LockedLayerDownEvent += OnLockCameraLayerDown;
			MonoSingleton<RtsCamera>.Instance.CameraJumpToEvent += ToggleCameraLockLayers;
			cameraLockedLayer.SetActive(GlobalSaveController.CurrentVillageData.CameraLockedToLayer);
			bool flag = false;
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				worldButton.gameObject.SetActive(value: false);
				leaveMapButton.gameObject.SetActive(value: true);
				leaveMapButton.onClick.AddListener(OnLeaveMapClicked);
				workerResearchButton.gameObject.SetActive(value: false);
			}
			else
			{
				leaveMapButton.gameObject.SetActive(value: false);
				if (GlobalSaveController.CurrentVillageData.MapTableBuilt)
				{
					UnlockRegion();
				}
				else
				{
					worldButton.interactable = false;
					worldButton.onNonInteractableClick.AddListener(RegionLocked);
					flag = true;
					worldButton.GetComponent<LocalizedTextTooltipView>().TextKeys = new List<string> { "hud_lb_world", "hud_info_world", "error_build_map_table" };
				}
				workerResearchButton.gameObject.SetActive(value: true);
				if (GlobalSaveController.CurrentVillageData.ResearchTableBuilt)
				{
					UnlockResearch();
				}
				else
				{
					workerResearchButton.interactable = false;
					workerResearchButton.onNonInteractableClick.AddListener(ResearchLocked);
					flag = true;
					workerResearchButton.GetComponent<LocalizedTextTooltipView>().TextKeys = new List<string> { "hud_lb_Research", "hud_info_Research", "error_build_research_bench" };
				}
			}
			if (flag)
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			}
			MonoSingleton<UIController>.Instance.Attach(this);
			devToolsButton.onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperToolsView>.Instance.Open();
			});
			travelButton.onClick.AddListener(TravelClicked);
			layerDownButton.onClick.AddListener(ShowLayerDown);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.LayerDown, ShowLayerDown);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToIntervalEvent(KeyInputEvent.LayerDown, ShowLayerDown);
			layerUpButton.onClick.AddListener(ShowLayerUp);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.LayerUp, ShowLayerUp);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToIntervalEvent(KeyInputEvent.LayerUp, ShowLayerUp);
			showHideRoofsButton.onClick.AddListener(ShowHideRoof);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideRoofs, ShowHideRoof);
			showHideTreesButton.onClick.AddListener(ShowHideTrees);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideTrees, ShowHideTrees);
			showHideResourceIndicatorsButton.onClick.AddListener(ShowHideResourceIndicators);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideItemIndicators, ShowHideResourceIndicators);
			showHideResourceGroupsButton.onClick.AddListener(ShowHideResourcesGroups);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideResourceGroups, ShowHideResourcesGroups);
			showHideRoomsButton.onClick.AddListener(ToggleRoomsOverlay);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideRooms, ToggleRoomsOverlay);
			toggleBeautyOverlayButton.onClick.AddListener(ToggleBeautyOverlay);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideEstheticMap, ToggleBeautyOverlay);
			toggleTemperatureOverlayButton.onClick.AddListener(ToggleTemperatureOverlay);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideHeatMap, ToggleTemperatureOverlay);
			resetCameraButton.onClick.AddListener(MonoSingleton<RtsCamera>.Instance.OnCameraReset);
			showHideZoneGridButton.onClick.AddListener(ShowHideZoneGrid);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideZoneGrid, ShowHideZoneGrid);
			OnDevToolsActive(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools);
			if (TutorialManager.IsTutorialActive)
			{
				SoundButton[] array = viewControlsButtons;
				foreach (SoundButton soundButton in array)
				{
					viewButtonDictionary.Add(soundButton.name, soundButton);
				}
				array = topLeftButtons;
				foreach (SoundButton soundButton2 in array)
				{
					topLeftButtonDictionary.Add(soundButton2.name, soundButton2);
				}
			}
		}

		public void SetViewControlsInteractable(HashSet<string> viewControlNames, bool interactable)
		{
			foreach (KeyValuePair<string, SoundButton> item in topLeftButtonDictionary)
			{
				if (viewControlNames != null && viewControlNames.Contains(item.Key))
				{
					item.Value.interactable = interactable;
				}
				else
				{
					item.Value.interactable = !interactable;
				}
			}
		}

		public void SetTopLeftButtonsInteractable(HashSet<string> viewControlNames, bool interactable)
		{
			foreach (KeyValuePair<string, SoundButton> item in topLeftButtonDictionary)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\TopLeftPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SetTopLeftButtonsInteractable: ");
					messageBuilder.AppendFormatted(item.Key);
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(viewControlNames?.Contains(item.Key) ?? false);
				}
				Log.Trace(messageBuilder);
				if (viewControlNames != null && viewControlNames.Contains(item.Key))
				{
					item.Value.interactable = interactable;
				}
				else
				{
					item.Value.interactable = !interactable;
				}
			}
		}

		public void ForceUnlockResearch()
		{
			UnlockResearch();
		}

		public RectTransform GetButtonRect(string controlName)
		{
			if (viewButtonDictionary.TryGetValue(controlName, out var value))
			{
				return value.transform as RectTransform;
			}
			if (topLeftButtonDictionary.TryGetValue(controlName, out var value2))
			{
				return value2.transform as RectTransform;
			}
			Log.Error("Could not find view control named " + controlName, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\TopLeftPanelView.cs");
			return null;
		}

		private void OnLeaveMapClicked()
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), delegate
				{
					VillageManager.ActiveVillage.Map.SecondMapLeaveManager.OnBeforeOpenLeaveMenu();
					MonoSingleton<CaravanManager>.Instance.OpenLeaveMapCaravanPanel();
				}),
				new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("leave_prompt_info", buttonActions));
		}

		protected override void OnDestroy()
		{
			if (world != null)
			{
				world.LayerChangeEvent -= OnLayerChanged;
				world.MapLoadedEvent -= OnMapLoaded;
				world = null;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.Detach(this);
				MonoSingleton<UIController>.Instance.DevToolsActive -= OnDevToolsActive;
			}
			if (MonoSingleton<RtsCamera>.IsInstantiated())
			{
				MonoSingleton<RtsCamera>.Instance.LockedLayerUpEvent -= OnLockCameraLayerUp;
				MonoSingleton<RtsCamera>.Instance.LockedLayerDownEvent -= OnLockCameraLayerDown;
				MonoSingleton<RtsCamera>.Instance.CameraJumpToEvent -= ToggleCameraLockLayers;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
			}
			workerJobsButton?.onClick.RemoveAllListeners();
			workerScheduleButton?.onClick.RemoveAllListeners();
			workerManageButton?.onClick.RemoveAllListeners();
			overviewButton?.onClick.RemoveAllListeners();
			cameraButton?.onClick.RemoveAllListeners();
			lockCameraToLayerButton?.onClick.RemoveAllListeners();
			lockCameraToLayerUp?.onClick.RemoveAllListeners();
			lockCameraToLayerDown?.onClick.RemoveAllListeners();
			leaveMapButton?.onClick.RemoveAllListeners();
			worldButton?.onNonInteractableClick.RemoveAllListeners();
			workerResearchButton?.onNonInteractableClick.RemoveAllListeners();
			devToolsButton?.onClick.RemoveAllListeners();
			travelButton?.onClick.RemoveAllListeners();
			layerDownButton?.onClick.RemoveAllListeners();
			layerUpButton?.onClick.RemoveAllListeners();
			showHideRoofsButton?.onClick.RemoveAllListeners();
			showHideTreesButton?.onClick.RemoveAllListeners();
			showHideResourceIndicatorsButton?.onClick.RemoveAllListeners();
			showHideResourceGroupsButton?.onClick.RemoveAllListeners();
			showHideRoomsButton?.onClick.RemoveAllListeners();
			toggleBeautyOverlayButton?.onClick.RemoveAllListeners();
			toggleTemperatureOverlayButton?.onClick.RemoveAllListeners();
			resetCameraButton?.onClick.RemoveAllListeners();
			showHideZoneGridButton?.onClick.RemoveAllListeners();
			base.OnDestroy();
		}

		private void SetDefaults()
		{
			roofHidden.gameObject.SetActive(!GlobalSaveController.CurrentVillageData.RoofsVisible);
			treesHidden.gameObject.SetActive(!GlobalSaveController.CurrentVillageData.TreesVisible);
			beautyOverlayHidden.gameObject.SetActive(GlobalSaveController.CurrentVillageData.HeatmapVisible != 1);
			zoneGridHidden.gameObject.SetActive(!MonoSingleton<GlobalVariableManager>.Instance.ZoneGridVisible);
			resourceIndicatorsHidden.gameObject.SetActive(!MonoSingleton<GlobalVariableManager>.Instance.ResourceIndicatorsVisible);
			resourceGroupsHidden.gameObject.SetActive(!MonoSingleton<UIController>.Instance.ResourceGroupsVisible);
			roomsHidden.gameObject.SetActive(GlobalSaveController.CurrentVillageData.HeatmapVisible != 3);
			RefreshHeatmapGradientUI();
		}

		private void ToggleWorldView()
		{
			bool isWorldMapVisible = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible;
			if (!isWorldMapVisible)
			{
				MonoSingleton<UIController>.Instance.CloseAllPanels();
			}
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetWorldMapVisible(!isWorldMapVisible);
			base.SceneUIManager.PanelOpen("WorldMap");
		}

		private void ResearchLocked()
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_build_research_bench"));
		}

		private void RegionLocked()
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_build_map_table"));
		}

		private void ShowResearchPanel()
		{
			Log.Debug("ResearchPanelManager.ShowResearchPanel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\TopLeftPanelView.cs");
			base.SceneUIManager.TogglePanel("ResearchPanelManager");
		}

		private void ShowSchedulePanel()
		{
			base.SceneUIManager.TogglePanel("SchedulePanelManager");
		}

		private void ShowJobsPanel()
		{
			base.SceneUIManager.TogglePanel("JobPanelManager");
		}

		private void ShowManagePanel()
		{
			base.SceneUIManager.TogglePanel("ManagePanelManager");
		}

		private void ShowOverviewPanel()
		{
			MonoSingleton<UIController>.Instance.OverviewPanelManager.SetDataAndShow();
		}

		private void TravelClicked()
		{
			base.SceneUIManager.ShowNewView("DebugTravelView");
		}

		private void OnDevToolsActive(bool active)
		{
			travelButton.gameObject.SetActive(value: false);
			devToolsButton.gameObject.SetActive(value: false);
		}

		private void PlayToggleSound(bool active)
		{
			string soundID = (active ? "UI_ToggleOn" : "UI_ToggleOff");
			MonoSingleton<AudioManager>.Instance.PlaySound(soundID);
		}

		private void ShowLayerDown()
		{
			world.OnLayerDown();
		}

		private void ShowLayerUp()
		{
			world.OnLayerUp();
		}

		private void ShowHideRoof()
		{
			VillageMap villageMap = VillageManager.ActiveVillage?.Map;
			if (villageMap != null)
			{
				villageMap.RoofComponentManager.ShowHideRoofs();
				roofHidden.gameObject.SetActive(!GlobalSaveController.CurrentVillageData.RoofsVisible);
				PlayToggleSound(GlobalSaveController.CurrentVillageData.RoofsVisible);
			}
		}

		private void ShowHideTrees()
		{
			MonoSingleton<PlantResourceManager>.Instance.ShowHideTrees();
			treesHidden.gameObject.SetActive(!GlobalSaveController.CurrentVillageData.TreesVisible);
			PlayToggleSound(GlobalSaveController.CurrentVillageData.TreesVisible);
		}

		private void ShowHideZoneGrid()
		{
			MonoSingleton<GlobalVariableManager>.Instance.ZoneGridToggle();
			zoneGridHidden.gameObject.SetActive(!MonoSingleton<GlobalVariableManager>.Instance.ZoneGridVisible);
			PlayToggleSound(MonoSingleton<GlobalVariableManager>.Instance.ZoneGridVisible);
		}

		private void ShowHideResourceIndicators()
		{
			MonoSingleton<GlobalVariableManager>.Instance.ResourceIndicatorsToggle();
			resourceIndicatorsHidden.gameObject.SetActive(!MonoSingleton<GlobalVariableManager>.Instance.ResourceIndicatorsVisible);
			PlayToggleSound(MonoSingleton<GlobalVariableManager>.Instance.ResourceIndicatorsVisible);
		}

		private void ToggleBeautyOverlay()
		{
			if (MonoSingleton<VillageManager>.IsInstantiated() && VillageManager.ActiveVillage?.Map != null)
			{
				MonoSingleton<VisualHeatmapManager>.Instance.ToggleHeatmapShowing(HeatmapType.Beauty);
				beautyOverlayHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.Beauty);
				temperatureOverlayHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.Temperature);
				roomsHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.RoomOverlay);
				cameraOptionsHidden.gameObject.SetActive(value: true);
				cameraOptions.SetActive(value: false);
				RefreshHeatmapGradientUI();
				PlayToggleSound(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing == HeatmapType.Beauty);
			}
		}

		private void ToggleRoomsOverlay()
		{
			if (MonoSingleton<VillageManager>.IsInstantiated() && VillageManager.ActiveVillage?.Map != null)
			{
				MonoSingleton<VisualHeatmapManager>.Instance.ToggleHeatmapShowing(HeatmapType.RoomOverlay);
				beautyOverlayHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.Beauty);
				temperatureOverlayHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.Temperature);
				roomsHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.RoomOverlay);
				cameraOptionsHidden.gameObject.SetActive(value: true);
				cameraOptions.SetActive(value: false);
				RefreshHeatmapGradientUI();
				PlayToggleSound(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing == HeatmapType.RoomOverlay);
			}
		}

		private void ToggleTemperatureOverlay()
		{
			if (MonoSingleton<VillageManager>.IsInstantiated() && VillageManager.ActiveVillage?.Map != null)
			{
				MonoSingleton<VisualHeatmapManager>.Instance.ToggleHeatmapShowing(HeatmapType.Temperature);
				beautyOverlayHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.Beauty);
				temperatureOverlayHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.Temperature);
				roomsHidden.gameObject.SetActive(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing != HeatmapType.RoomOverlay);
				cameraOptionsHidden.gameObject.SetActive(value: true);
				cameraOptions.SetActive(value: false);
				RefreshHeatmapGradientUI();
				PlayToggleSound(MonoSingleton<VisualHeatmapManager>.Instance.HeatmapShowing == HeatmapType.Temperature);
			}
		}

		private void RefreshHeatmapGradientUI()
		{
			if (!MonoSingleton<VillageManager>.IsInstantiated() || MonoSingleton<VillageManager>.IsApplicationIsQuitting())
			{
				return;
			}
			HeatmapType heatmapVisible = (HeatmapType)GlobalSaveController.CurrentVillageData.HeatmapVisible;
			HeatmapType heatmapType = ((!MonoSingleton<RoomViewManager>.Instance.IsShowingRooms) ? heatmapVisible : HeatmapType.None);
			if (heatmapObjectUI.gameObject.activeSelf != (heatmapType != HeatmapType.None))
			{
				heatmapObjectUI.gameObject.SetActive(heatmapType != HeatmapType.None);
			}
			VillageMap villageMap = VillageManager.ActiveVillage?.Map;
			if (villageMap != null)
			{
				if (heatmapType == HeatmapType.Beauty)
				{
					heatmapGradientImage.texture = villageMap.BeautyManager.GradientTexture;
					heatmapMinText.SetText(villageMap.BeautyManager.GradientMinText);
					heatmapMaxText.SetText(villageMap.BeautyManager.GradientMaxText);
					heatmapCenterText.SetText(villageMap.BeautyManager.GradientCenterText);
				}
				if (heatmapType == HeatmapType.Temperature)
				{
					heatmapGradientImage.texture = villageMap.TemperatureManager.GradientTexture;
					heatmapMinText.SetText(villageMap.TemperatureManager.GradientMinText);
					heatmapMaxText.SetText(villageMap.TemperatureManager.GradientMaxText);
					heatmapCenterText.SetText(villageMap.TemperatureManager.GradientCenterText);
				}
			}
		}

		private void ShowHideResourcesGroups()
		{
			MonoSingleton<UIController>.Instance.ResourceGroupViewToggle();
			resourceGroupsHidden.gameObject.SetActive(!MonoSingleton<UIController>.Instance.ResourceGroupsVisible);
			PlayToggleSound(MonoSingleton<UIController>.Instance.ResourceGroupsVisible);
		}

		private void OnLayerChanged(float currentLayer, int mapSize)
		{
			currentLayerText.text = $"{currentLayer:F1}/{mapSize}";
			layerFlashAnimator.Play("FlashBackground");
			layerDownButton.interactable = currentLayer > 1f;
			layerUpButton.interactable = currentLayer < (float)mapSize;
		}

		private void OnAutoConstructionCompleted(BaseBuildingInstance building)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				OnConstructionCompleted(building);
			});
		}

		private void OnConstructionCompleted(BaseBuildingInstance baseBuildableInstance)
		{
			if (!workerResearchButton.interactable && BuildingUtils.GetResearchBuildings.Contains(baseBuildableInstance.Blueprint.GetID()))
			{
				workerResearchButton.onNonInteractableClick.RemoveAllListeners();
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("research_panel_unlocked"));
				UnlockResearch();
			}
			else if (!worldButton.interactable && baseBuildableInstance.Blueprint.GetID() == "map_table")
			{
				worldButton.onNonInteractableClick.RemoveAllListeners();
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("region_panel_unlocked"));
				UnlockRegion();
			}
			if (GlobalSaveController.CurrentVillageData.ResearchTableBuilt && GlobalSaveController.CurrentVillageData.MapTableBuilt)
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
			}
		}

		private void UnlockResearch()
		{
			workerResearchButton.interactable = true;
			workerResearchButton.AddCleanListener(ShowResearchPanel);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Research, ShowResearchPanel, activeOnWorldMap: true);
			workerResearchButton.GetComponent<LocalizedTextTooltipView>().TextKeys = new List<string> { "hud_lb_Research", "hud_info_Research" };
		}

		private void UnlockRegion()
		{
			worldButton.interactable = true;
			worldButton.onClick.AddListener(ToggleWorldView);
			worldButton.GetComponent<LocalizedTextTooltipView>().TextKeys = new List<string> { "hud_lb_world", "hud_info_world" };
		}

		private void OnModifyZoneButtonClicked()
		{
			previousZoneColor = (int)Shader.GetGlobalFloat("_showZoneColors");
			if (previousZoneColor != 1)
			{
				MonoSingleton<GlobalVariableManager>.Instance.ForceShowZoneGrid();
				zoneGridHidden.gameObject.SetActive(value: false);
			}
		}

		private void OnDismissModifyZoneButton()
		{
			MonoSingleton<GlobalVariableManager>.Instance.DismissModifyZoneButton(previousZoneColor != 0);
			zoneGridHidden.gameObject.SetActive(!MonoSingleton<GlobalVariableManager>.Instance.ZoneGridVisible);
		}

		private void OnMapLoaded(bool loadedFromSave)
		{
			currentLayerText.text = $"{world.LayerLevel:F1}/{world.SizeY}";
			SetDefaults();
		}

		private void ToggleCameraOptions()
		{
			if (MonoSingleton<VillageManager>.IsInstantiated() && VillageManager.ActiveVillage?.Map != null)
			{
				MonoSingleton<VisualHeatmapManager>.Instance.ToggleHeatmapShowing(HeatmapType.None);
				bool activeSelf = cameraOptions.activeSelf;
				cameraOptions.SetActive(!activeSelf);
				if (!activeSelf)
				{
					heatmapObjectUI.SetActive(value: false);
					beautyOverlayHidden.gameObject.SetActive(value: true);
					temperatureOverlayHidden.gameObject.SetActive(value: true);
					roomsHidden.gameObject.SetActive(value: true);
					cameraOptionsHidden.gameObject.SetActive(value: false);
				}
				else
				{
					cameraOptionsHidden.gameObject.SetActive(value: true);
				}
				RefreshHeatmapGradientUI();
				UpdateLockedLayerText();
			}
		}

		private void ToggleCameraLockLayers()
		{
			cameraLockedLayer.SetActive(!cameraLockedLayer.activeSelf);
			LayoutRebuilder.ForceRebuildLayoutImmediate(cameraOptions.GetComponent<RectTransform>());
			MonoSingleton<RtsCamera>.Instance.OnCameraLayerLockedEvent(cameraLockedLayer.activeSelf);
			if (cameraLockedLayer.activeSelf)
			{
				cameraLockHidden.gameObject.SetActive(value: false);
				MonoSingleton<CameraVisuals>.Instance.LockAnimator.SetTrigger("CameraLock");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("camera_locked").Replace("<layer_number>", MonoSingleton<RtsCamera>.Instance.LockedLayerIndex.ToString()));
			}
			else
			{
				cameraLockHidden.gameObject.SetActive(value: true);
				MonoSingleton<CameraVisuals>.Instance.LockAnimator.SetTrigger("CameraUnlock");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("camera_unlocked"));
			}
			UpdateLockedLayerText();
		}

		private void OnLockCameraLayerUp()
		{
			int lockedLayerIndex = MonoSingleton<RtsCamera>.Instance.LockedLayerIndex;
			if (lockedLayerIndex < 16)
			{
				lockedLayerIndex++;
				MonoSingleton<RtsCamera>.Instance.OnLockedLayerChangedEvent(lockedLayerIndex);
			}
			UpdateLockedLayerText();
		}

		private void OnLockCameraLayerDown()
		{
			int lockedLayerIndex = MonoSingleton<RtsCamera>.Instance.LockedLayerIndex;
			if (lockedLayerIndex > 1)
			{
				lockedLayerIndex--;
				MonoSingleton<RtsCamera>.Instance.OnLockedLayerChangedEvent(lockedLayerIndex);
			}
			UpdateLockedLayerText();
		}

		private void UpdateLockedLayerText()
		{
			lockedLayerText.text = $"{MonoSingleton<RtsCamera>.Instance.LockedLayerIndex}/{world.SizeY}";
			lockedLayerFlashAnimator.Play("FlashBackground");
		}
	}
}
