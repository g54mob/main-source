using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StructurePresets;
using NSMedieval.Types;
using NSMedieval.UI.PhotoMode;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.WorldMap;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.UI
{
	public class UIController : MonoController<UIController>
	{
		public delegate void JobToggleWorldPosition(Vector3 position, bool enabled);

		public delegate void SelectionPanelToggle(bool opened, int panelObjectId);

		public delegate void UpdateInfoCursorHandle(List<string> textLines, string tag, int tagSortValue, bool background, float fontSizeScaler);

		[SerializeField]
		private SceneUIManager sceneUIManager;

		[SerializeField]
		private TopLeftPanelView topLeftPanelView;

		[SerializeField]
		private ConstructionPanelView constructionPanel;

		[SerializeField]
		private SelectionPanelManager selectionPanel;

		[SerializeField]
		private AlmanacPanelManager almanacPanel;

		[SerializeField]
		private ActionInfoView actionInfo;

		[SerializeField]
		private PromptPanelManager promptPanel;

		[SerializeField]
		private PromptPanelManager demoWelcomePanel;

		[SerializeField]
		private PanelBase[] initPanels;

		[SerializeField]
		private InGameMenuView ingameMenu;

		[SerializeField]
		private OrdersPanelView ordersPanelView;

		[SerializeField]
		private ResourcePanelManager resourcePanelManager;

		[SerializeField]
		private LogPanelView logPanelView;

		[SerializeField]
		private PlayerTriggeredEventView playerTriggeredEventView;

		[SerializeField]
		private AssignRoleView assignRoleView;

		[SerializeField]
		private ProduceSettingsPanel productionSettingsPanel;

		[FormerlySerializedAs("overviewPanelManager")]
		[SerializeField]
		private OverviewPanelManager overviewOverviewPanelManager;

		[SerializeField]
		private List<GameObject> hideIfWorldMapVisible;

		[SerializeField]
		private List<GameObject> hideIfPhotoModeVisible;

		[SerializeField]
		private List<GameObject> hideIfHideUI;

		private string stockpileBlueprint;

		private bool isSelectionPanelVisible;

		[NonSerialized]
		public JobToggleWorldPosition OnHoverJobToggleEvent;

		public bool HideUI { get; set; }

		public bool AltCameraActive { get; set; }

		public bool GameStarted { get; private set; }

		public SelectionPanelManager SelectionPanel => selectionPanel;

		public bool ResourceGroupsVisible { get; private set; }

		public bool IsSelectionPanelVisible => isSelectionPanelVisible;

		public string StockpileBlueprint
		{
			get
			{
				return stockpileBlueprint;
			}
			set
			{
				stockpileBlueprint = value;
			}
		}

		public bool IsPromptShown => promptPanel.MainPanel.activeSelf;

		public PromptPanelManager PromptPanel => promptPanel;

		public InGameMenuView InGameMenu => ingameMenu;

		public TopLeftPanelView LeftPanelView => topLeftPanelView;

		public int PopupsActive { get; set; }

		public bool TradeWindowActive { get; set; }

		public SceneUIManager UIManager => sceneUIManager;

		public LogPanelView LogPanelView => logPanelView;

		public PlayerTriggeredEventView TriggeredEventView => playerTriggeredEventView;

		public AssignRoleView AssignRoleView => assignRoleView;

		public ProduceSettingsPanel ProductionSettingsPanel => productionSettingsPanel;

		public OverviewPanelManager OverviewPanelManager => overviewOverviewPanelManager;

		public ConstructionPanelView ConstructionPanel => constructionPanel;

		public OrdersPanelView OrdersPanelView => ordersPanelView;

		[field: NonSerialized]
		public event SelectionPanelToggle SelectionPanelToggleEvent;

		[field: NonSerialized]
		public event Action<bool, string> InfoCursorToggleEvent;

		[field: NonSerialized]
		public event UpdateInfoCursorHandle UpdateInfoCursorContentEvent;

		[field: NonSerialized]
		public event Action<bool> UpdateInfoCursorBackground;

		[field: NonSerialized]
		public event Action<bool> ResurcesShowGroupView;

		[field: NonSerialized]
		public event Action<ProductionInstance> ToggleEditProductionUIEvent;

		[field: NonSerialized]
		public event Action<ProductionInstance> QueuedProductionSelectedEvent;

		[field: NonSerialized]
		public event Action<ProductionLayoutItemView> ProductionCanceledUIEvent;

		[field: NonSerialized]
		public event Action ForceUpdateProductionLayoutItemViewsEvent;

		[field: NonSerialized]
		public event Action<string> AlmanacEntrySelected;

		[field: NonSerialized]
		public event Action<bool> GameStartedEvent;

		[field: NonSerialized]
		public event Action<bool> DevToolsActive;

		[field: NonSerialized]
		public event Action<int> ShowWorkerExtraSelectionTab;

		[field: NonSerialized]
		public event Action<string> LinkClickedEvent;

		[field: NonSerialized]
		public event Action<bool> HideUIToggleEvent;

		[field: NonSerialized]
		public event Action SelectNextWorkerEvent;

		[field: NonSerialized]
		public event Action<string> SelectMaterialEvent;

		[field: NonSerialized]
		public event Action<string, BuildingCategoryUI, BuildingSubCategoryUI> CopyBuildingEvent;

		[field: NonSerialized]
		public event Action OnCopyJobSettingsEvent;

		[field: NonSerialized]
		public event Action OnCopyScheduleSettingsEvent;

		[field: NonSerialized]
		public event Action<JobType, int> OnJobNameClickEvent;

		[field: NonSerialized]
		public event Action<Vector3, bool> OnScheduleHourButtonHoverEvent;

		[field: NonSerialized]
		public event Action BuildButtonClickEvent;

		public void ToggleUI()
		{
			if (!MonoSingleton<GlobalShaderVariables>.IsInstantiated())
			{
				return;
			}
			HideUI = !HideUI;
			this.HideUIToggleEvent?.Invoke(HideUI);
			MonoSingleton<GlobalShaderVariables>.Instance.SetScreenshotModeEnabled(HideUI);
			foreach (GameObject item in hideIfHideUI)
			{
				item.SetActive(!HideUI);
			}
			if (HideUI)
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(ToggleUI, base.gameObject);
			}
			else
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(ToggleUI, base.gameObject);
			}
		}

		public void StartGame()
		{
			NotifyGameStart(started: true);
		}

		public void ShowPrompt(PromptPanelData data, bool handleInput = true)
		{
			promptPanel.OpenPanel(data, handleInput);
		}

		public void ShowCustomPrompt(PromptPanelData data, bool handleInput = true)
		{
			promptPanel.OpenCustomPanel(data, handleInput);
		}

		public void ShowDemoPrompt(PromptPanelData data, bool handleInput = true)
		{
			demoWelcomePanel.OpenPanel(data, handleInput);
		}

		public void ClosePrompt()
		{
			promptPanel.ClosePanel();
		}

		public void UpdatePromptText(string text)
		{
			promptPanel.UpdateDescriptionText(text);
		}

		public void ShowActionInfo(List<string> textKeys, bool overrideExisting = true)
		{
			actionInfo.UpdateTextAndShow(textKeys, overrideExisting);
		}

		public void HideActionInfo()
		{
			actionInfo.Hide();
		}

		public void HideIfActiveActionInfo(List<string> textKeys)
		{
			actionInfo.HideIfActive(textKeys);
		}

		public void ShowFactionsPanel(string factionLinkId)
		{
			sceneUIManager.TogglePanelTab("StatisticsPanelManager", 2);
		}

		public void NotifyMaterialSelect(string materialId)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(0, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\UIController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(materialId);
			}
			Log.Debug(messageBuilder);
			this.SelectMaterialEvent?.Invoke(materialId);
		}

		public void ToggleConstructionCategory(BuildingCategoryUI category, params string[] subcategories)
		{
			constructionPanel.OpenPanelAndHighlight(category, subcategories);
		}

		public void ToggleConstructionCategory(BuildingCategoryUI category, IEnumerable<string> subcategories)
		{
			constructionPanel.OpenPanelAndHighlight(category, subcategories);
		}

		public void ToggleInfoCursor(bool active, string tag = "default")
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\UIController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ToggleInfoCursor: ");
				messageBuilder.AppendFormatted(active);
				messageBuilder.AppendLiteral(" tag: ");
				messageBuilder.AppendFormatted(tag);
			}
			Log.Debug(messageBuilder);
			this.InfoCursorToggleEvent?.Invoke(active, tag);
		}

		public void ShowAlmanacEntry(string entryId)
		{
			this.AlmanacEntrySelected?.Invoke(entryId);
		}

		public void UpdateInfoCursorContent(List<string> textLines, string tag, int tagSortValue, bool background = true, float fontSizeScaler = 1f)
		{
			this.UpdateInfoCursorContentEvent?.Invoke(textLines, tag, tagSortValue, background, fontSizeScaler);
		}

		public void UpdateInfoCursorContent(List<string> textLines, bool background = true, float fontSizeScaler = 1f)
		{
			this.UpdateInfoCursorContentEvent?.Invoke(textLines, "default", 0, background, fontSizeScaler);
		}

		public void UpdateInfoCursorContent(string iconID, bool background, float fontSizeScaler = 1f)
		{
			this.UpdateInfoCursorContentEvent?.Invoke(new List<string> { AssetUtils.GetSpriteAsset(iconID) }, "default", 0, background, fontSizeScaler);
		}

		public void SelectBuilding(string building)
		{
			ToggleInfoCursor(active: false);
			string text = building.Split('_')[building.Split('_').Length - 1];
			if (text.Equals("stockpile"))
			{
				stockpileBlueprint = building;
				MonoSingleton<SelectionManager>.Instance.OnSelectArea(AreaType.Stockpile, building);
			}
			else
			{
				if (!text.Equals("cropfield"))
				{
					return;
				}
				MonoSingleton<SelectionManager>.Instance.OnSelectArea(AreaType.Crops, building);
			}
			MonoSingleton<BuildingPlacementManager>.Instance.CancelSelection();
		}

		public void SelectNextObject()
		{
			if (!MonoSingleton<SelectableObjectManager>.Instance.GetFirstSelected(out var selected))
			{
				this.SelectNextWorkerEvent?.Invoke();
			}
			else if (selected.GetType() != typeof(WorkerView))
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectNextOfType();
			}
			else
			{
				this.SelectNextWorkerEvent?.Invoke();
			}
		}

		public void CloseOtherPanels(string panelName, PanelGroupType panelGroup)
		{
			if (MonoSingleton<SelectionManager>.IsInstantiated() && !MonoSingleton<SelectionManager>.Instance.ReadyToPlaceArea)
			{
				MonoSingleton<SelectionManager>.Instance.ResetSelectionTool();
				NotifyAll("OnOtherPanelOpened", panelName, panelGroup);
			}
		}

		public void CloseAllPanels()
		{
			NotifyAll("OnHideAllPanels");
			ToggleInfoCursor(active: false);
		}

		public void ShowExtraSelectionPanelTab(int tabIndex)
		{
			this.ShowWorkerExtraSelectionTab?.Invoke(tabIndex);
		}

		public void OnMenuPause()
		{
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.MenuSnapshot);
			MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: true);
		}

		public void OnMenuResume()
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			});
			MonoSingleton<MixerSnapshotManager>.Instance.ActivatePreviousSnapshot();
			ordersPanelView.Show();
			resourcePanelManager.Show();
			MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: false);
		}

		public void Start()
		{
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent += OnPhotoModeVisibilitySet;
			MonoSingleton<StructurePresetModeController>.Instance.StructurePresetModeVisibleEvent += OnStructurePresetModeVisibilitySet;
			SetupAlmanac();
			SetupResearchPanel();
			ToggleInfoCursor(active: false);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(CloseSelectionPanel);
			if (MonoSingleton<InputManager>.IsInstantiated() && MonoSingleton<KeybindingManager>.IsInstantiated())
			{
				MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.SelectNextWorker, SelectNextObject);
			}
			NotifyGameStart(started: false);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
			}
			if (MonoSingleton<PhotoModeController>.IsInstantiated())
			{
				MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent -= OnPhotoModeVisibilitySet;
			}
			if (MonoSingleton<StructurePresetModeController>.IsInstantiated())
			{
				MonoSingleton<StructurePresetModeController>.Instance.StructurePresetModeVisibleEvent -= OnStructurePresetModeVisibilitySet;
			}
			if (MonoSingleton<InputManager>.IsInstantiated() && MonoSingleton<KeybindingManager>.IsInstantiated())
			{
				MonoSingleton<KeybindingManager>.Instance.UnsubscribeFromEvent(KeyInputEvent.SelectNextWorker, SelectNextObject);
			}
			base.OnDestroy();
			OnHoverJobToggleEvent = null;
			this.OnCopyJobSettingsEvent = null;
			this.OnCopyScheduleSettingsEvent = null;
			this.OnJobNameClickEvent = null;
			this.OnScheduleHourButtonHoverEvent = null;
		}

		private void OnWorldMapVisibilitySet(bool isEnabled)
		{
			foreach (GameObject item in hideIfWorldMapVisible)
			{
				if (!(item == null))
				{
					item.SetActive(!isEnabled);
				}
			}
			if (!isEnabled)
			{
				ordersPanelView.Show();
				resourcePanelManager.Show();
			}
		}

		private void OnStructurePresetModeVisibilitySet(bool isEnabled)
		{
			bool isEnabled2;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\UIController.cs");
			if (isEnabled2)
			{
				messageBuilder.AppendLiteral("OnStructurePresetModeVisibilitySet: ");
				messageBuilder.AppendFormatted(isEnabled);
			}
			Log.Debug(messageBuilder);
			foreach (GameObject item in hideIfPhotoModeVisible)
			{
				item.SetActive(!isEnabled);
			}
		}

		private void OnPhotoModeVisibilitySet(bool isEnabled)
		{
			foreach (GameObject item in hideIfPhotoModeVisible)
			{
				item.SetActive(!isEnabled);
			}
		}

		public void ToggleEditProductionUI(ProductionInstance productionInstance)
		{
			this.ToggleEditProductionUIEvent?.Invoke(productionInstance);
		}

		public void ProductionCanceled(ProductionLayoutItemView productionLayoutItemView)
		{
			this.ProductionCanceledUIEvent?.Invoke(productionLayoutItemView);
		}

		public void HideSelectionHighlight()
		{
			MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
		}

		public void ForceUpdateProductionLayoutItemViews()
		{
			this.ForceUpdateProductionLayoutItemViewsEvent?.Invoke();
		}

		public void SetDevToolsActive(bool active)
		{
			this.DevToolsActive?.Invoke(active);
		}

		public void CopyBuilding(string id, BuildingCategoryUI categoryUI, BuildingSubCategoryUI subCategoryUI)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(64, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\UIController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Copy building: ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(". BuildingCategoryUI: ");
				messageBuilder.AppendFormatted(categoryUI);
				messageBuilder.AppendLiteral(". BuildingSubcategoryUI: ");
				messageBuilder.AppendFormatted(subCategoryUI);
				messageBuilder.AppendLiteral(". ");
			}
			Log.Info(messageBuilder);
			this.CopyBuildingEvent?.Invoke(id, categoryUI, subCategoryUI);
		}

		public void HoverJobToggle(Vector3 position, bool enabled)
		{
			OnHoverJobToggleEvent?.Invoke(position, enabled);
		}

		public void ModifyZoneButtonClicked()
		{
			if (MonoSingleton<SelectionManager>.Instance.AreaOrderType != AreaType.Stockpile && MonoSingleton<SelectionManager>.Instance.AreaOrderType != AreaType.Crops)
			{
				NotifyAll("OnModifyZoneButtonClicked");
			}
		}

		public void DismissModifyZoneButton()
		{
			NotifyAll("OnDismissModifyZoneButton");
		}

		public void ResourceGroupViewToggle()
		{
			ResourceGroupsVisible = !ResourceGroupsVisible;
			this.ResurcesShowGroupView?.Invoke(ResourceGroupsVisible);
			GlobalSaveController.CurrentVillageData.ResourceGroupsVisible = ResourceGroupsVisible;
		}

		private void OnSelectableObjectSelectedEvent(SelectableObject selectableObject)
		{
			if (selectableObject == null)
			{
				CloseSelectionPanel();
				return;
			}
			WorldObject asWorldObject = selectableObject.GetAsWorldObject();
			if (asWorldObject == null || !asWorldObject.HasDisposed)
			{
				selectionPanel.OnSelectUpdate(selectableObject);
			}
		}

		private void OnObjectsDeselected(List<SelectableObject> deselectedObjectsList)
		{
			if (deselectedObjectsList != null)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\UIController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnObjectsDeselected: ");
					messageBuilder.AppendFormatted(deselectedObjectsList.Count);
				}
				Log.Debug(messageBuilder);
				selectionPanel.OnDeSelectUpdate(deselectedObjectsList);
			}
		}

		private void OnSelectableObjectDeSelectAllEvent()
		{
			CloseSelectionPanel();
		}

		public void CloseSelectionPanel()
		{
			if ((bool)selectionPanel && selectionPanel.gameObject.activeInHierarchy)
			{
				selectionPanel.Hide();
			}
		}

		public void NotifySelectionPanelToggle(bool visible)
		{
			isSelectionPanelVisible = visible;
			this.SelectionPanelToggleEvent?.Invoke(visible, selectionPanel.PanelObjectId);
			HideActionInfo();
		}

		public void OnLoadingFinished()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += MonoSingleton<UIController>.Instance.OnSelectableObjectSelectedEvent;
			MonoSingleton<SelectableObjectController>.Instance.ObjectsDeselectedEvent += MonoSingleton<UIController>.Instance.OnObjectsDeselected;
			MonoSingleton<SelectableObjectController>.Instance.DeselectAllEvent += MonoSingleton<UIController>.Instance.OnSelectableObjectDeSelectAllEvent;
			ResourceGroupsVisible = !GlobalSaveController.CurrentVillageData.ResourceGroupsVisible;
			ResourceGroupViewToggle();
		}

		private void SetupAlmanac()
		{
			if (!(almanacPanel == null) && !(almanacPanel.gameObject == null))
			{
				almanacPanel.SetupAlmanac();
			}
		}

		public bool IsAlmanacEntryLocked(string entryId)
		{
			return almanacPanel.IsEntryLocked(entryId);
		}

		private void SetupResearchPanel()
		{
			if (!(sceneUIManager == null))
			{
				sceneUIManager.TogglePanel("ResearchPanelManager");
			}
		}

		public void OnTemperatureUnitsChange()
		{
			if (Repository<AlmanacEntriesRepository, AlmanacEntry>.IsInstantiated())
			{
				Repository<AlmanacEntriesRepository, AlmanacEntry>.Instance.OnTemperatureUnitsChange();
			}
			if (almanacPanel != null)
			{
				almanacPanel.RefreshAlmanac();
			}
		}

		private void NotifyGameStart(bool started)
		{
			GameStarted = started;
			this.GameStartedEvent?.Invoke(started);
		}

		public void LinkClicked(string getLinkID)
		{
			this.LinkClickedEvent?.Invoke(getLinkID);
		}

		public void SetInfoCursorBackground(bool isActive)
		{
			this.UpdateInfoCursorBackground?.Invoke(isActive);
		}

		public void OnCopyJobSettings()
		{
			this.OnCopyJobSettingsEvent?.Invoke();
		}

		public void JobNameClick(JobType jobJobType, int priority)
		{
			this.OnJobNameClickEvent?.Invoke(jobJobType, priority);
		}

		public void OnCopyScheduleSettings()
		{
			this.OnCopyScheduleSettingsEvent?.Invoke();
		}

		public void OnScheduleHourButtonHover(Vector3 position, bool enabled)
		{
			this.OnScheduleHourButtonHoverEvent?.Invoke(position, enabled);
		}

		public void BuildButtonClick()
		{
			this.BuildButtonClickEvent?.Invoke();
		}
	}
}
