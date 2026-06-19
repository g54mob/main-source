using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class RibbonMenuBuildState : MustCallDestroy
	{
		[Serializable]
		public class Settings
		{
			public GameObject RoomSizePrefab;

			[Header("Ribbon Bar")]
			public int BarWidth;

			public int BarLeftSectionWidth;

			public GameObject[] BarGameObjects;

			[Header("Tutorial Components")]
			public GameObject TutorialGameObject;

			[Header("GUI Components")]
			public DynamicButton AcceptBuildButton;

			public ButtonAnimator AcceptBuildButtonAnimator;

			public TooltipSpawner AcceptBuildButtonTooltip;

			[Space]
			public DynamicButton AddFloorButton;

			public ButtonAnimator AddFloorButtonAnimator;

			[Space]
			public DynamicButton SubtractFloorButton;

			public ButtonAnimator SubtractFloorButtonAnimator;

			[Space]
			public ProgressBarMaskable PrestigeProgressBar;

			public TMP_Text PrestigeLevelText;

			public TMP_Text RoomCostText;

			public Color CostOfRoomTextAffordableColor;

			public Color CostOfRoomTextUnaffordableColor;

			public TMP_Text BuildPromptText;
		}

		private Settings _settings;

		private Level _level;

		private GameObject _roomSizeUI;

		private bool _enabled;

		private bool _currentlyMovingRoom;

		public bool Enabled => _enabled;

		public RibbonMenuBuildState(Level level, Settings settings)
		{
			_settings = settings;
			GameObject[] barGameObjects = _settings.BarGameObjects;
			for (int i = 0; i < barGameObjects.Length; i++)
			{
				barGameObjects[i].SetActive(value: false);
			}
			_level = level;
			_settings.AcceptBuildButton.onPrimaryDown.AddListener(OnAcceptBuildButton);
			_settings.AddFloorButton.onPrimaryDown.AddListener(OnAddFloorButton);
			_settings.SubtractFloorButton.onPrimaryDown.AddListener(OnRemoveFloorButton);
			_settings.AcceptBuildButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = (_level.BuildingLogic.CanApplyEditedRoomChanges ? ScriptLocalization.Tooltip.RibbonMenu_RoomBuild_BuildRoom_CS : ScriptLocalization.Tooltip.RibbonMenu_RoomBuild_BuildRoomInvalid_CS);
			});
		}

		public void Enable()
		{
			if (!Enabled)
			{
				_settings.AcceptBuildButtonAnimator.CurrentState = ((!_level.BuildingLogic.CanApplyEditedRoomChanges) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				_settings.PrestigeProgressBar.Progress = 1f;
				RegisterEvents();
				RefreshAddAndSubtractButtons();
				RefreshPrestige();
				RefreshRoomCost();
				RefreshPromptText(null);
				_currentlyMovingRoom = false;
				_enabled = true;
			}
		}

		public void Disable()
		{
			if (Enabled)
			{
				if (_roomSizeUI != null)
				{
					UnityEngine.Object.Destroy(_roomSizeUI);
					_roomSizeUI = null;
				}
				UnregisterEvents();
				_enabled = false;
			}
		}

		private void RegisterEvents()
		{
			CursorManager cursorManager = _level.CursorManager;
			cursorManager.OnModeBecomeActive = (Action<CursorMode>)Delegate.Combine(cursorManager.OnModeBecomeActive, new Action<CursorMode>(OnCursorModeBecomeActive));
			CursorManager cursorManager2 = _level.CursorManager;
			cursorManager2.OnModeBecomeInactive = (Action<CursorMode>)Delegate.Combine(cursorManager2.OnModeBecomeInactive, new Action<CursorMode>(OnCursorModeBecomeInactive));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Combine(buildEvents.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnBeginItemPlacement = (Action<IRoomItemDefinition, FloorPlan, bool>)Delegate.Combine(buildEvents2.OnBeginItemPlacement, new Action<IRoomItemDefinition, FloorPlan, bool>(OnBeginItemPlacement));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnFloorPlanUpdated = (Action<BlueprintFloorPlan>)Delegate.Combine(buildEvents3.OnFloorPlanUpdated, new Action<BlueprintFloorPlan>(OnFloorPlanUpdated));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomValidityChanged = (Action<BlueprintFloorPlan>)Delegate.Combine(buildEvents4.OnRoomValidityChanged, new Action<BlueprintFloorPlan>(OnRoomValidityChanged));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnBuildModeChanged = (Action<CursorRoomBuild.RoomAreaDragOperation>)Delegate.Combine(buildEvents5.OnBuildModeChanged, new Action<CursorRoomBuild.RoomAreaDragOperation>(OnBuildModeChanged));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents6.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents7.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents8.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnEnterNewRoomState = (Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents9.OnEnterNewRoomState, new Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterNewRoomState));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnRoomDragStart = (Action<FloorPlan>)Delegate.Combine(buildEvents10.OnRoomDragStart, new Action<FloorPlan>(OnRoomDragStart));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnRoomDragEnd = (Action)Delegate.Combine(buildEvents11.OnRoomDragEnd, new Action(OnRoomDragEnd));
		}

		private void UnregisterEvents()
		{
			CursorManager cursorManager = _level.CursorManager;
			cursorManager.OnModeBecomeActive = (Action<CursorMode>)Delegate.Remove(cursorManager.OnModeBecomeActive, new Action<CursorMode>(OnCursorModeBecomeActive));
			CursorManager cursorManager2 = _level.CursorManager;
			cursorManager2.OnModeBecomeInactive = (Action<CursorMode>)Delegate.Remove(cursorManager2.OnModeBecomeInactive, new Action<CursorMode>(OnCursorModeBecomeInactive));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Remove(buildEvents.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnBeginItemPlacement = (Action<IRoomItemDefinition, FloorPlan, bool>)Delegate.Remove(buildEvents2.OnBeginItemPlacement, new Action<IRoomItemDefinition, FloorPlan, bool>(OnBeginItemPlacement));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnFloorPlanUpdated = (Action<BlueprintFloorPlan>)Delegate.Remove(buildEvents3.OnFloorPlanUpdated, new Action<BlueprintFloorPlan>(OnFloorPlanUpdated));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomValidityChanged = (Action<BlueprintFloorPlan>)Delegate.Remove(buildEvents4.OnRoomValidityChanged, new Action<BlueprintFloorPlan>(OnRoomValidityChanged));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnBuildModeChanged = (Action<CursorRoomBuild.RoomAreaDragOperation>)Delegate.Remove(buildEvents5.OnBuildModeChanged, new Action<CursorRoomBuild.RoomAreaDragOperation>(OnBuildModeChanged));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents6.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents7.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents8.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnEnterNewRoomState = (Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents9.OnEnterNewRoomState, new Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterNewRoomState));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnRoomDragStart = (Action<FloorPlan>)Delegate.Remove(buildEvents10.OnRoomDragStart, new Action<FloorPlan>(OnRoomDragStart));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnRoomDragEnd = (Action)Delegate.Remove(buildEvents11.OnRoomDragEnd, new Action(OnRoomDragEnd));
		}

		public void Update()
		{
			if (Enabled && _level.InputManager != null && !_level.CursorManager.IsModeActive<CursorRoomMove>())
			{
				if (_level.InputManager.GetButtonDown(12))
				{
					_level.BuildingLogic.ChangeRoomBuildMode(CursorRoomBuild.RoomAreaDragOperation.Add);
				}
				if (_level.InputManager.GetButtonDown(13))
				{
					_level.BuildingLogic.ChangeRoomBuildMode(CursorRoomBuild.RoomAreaDragOperation.Subtract);
				}
			}
		}

		private void RefreshAddAndSubtractButtons()
		{
			if (_level.CursorManager.TryGetActiveMode<CursorRoomBuild>(out var activeMode))
			{
				_settings.AddFloorButtonAnimator.CurrentState = ((activeMode.DragOperation == CursorRoomBuild.RoomAreaDragOperation.Add) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_settings.SubtractFloorButtonAnimator.CurrentState = ((activeMode.DragOperation == CursorRoomBuild.RoomAreaDragOperation.Subtract) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			}
			else if (_level.CursorManager.IsModeActive<CursorRoomMove>())
			{
				_settings.AddFloorButtonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
				_settings.SubtractFloorButtonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
			}
			else
			{
				_settings.AddFloorButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_settings.SubtractFloorButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
			}
		}

		private void RefreshAcceptButton()
		{
			if (_level.CursorManager.IsModeActive<CursorRoomMove>())
			{
				_settings.AcceptBuildButtonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
				return;
			}
			BlueprintFloorPlan currentBlueprintFloorPlan = _level.BuildingLogic.CurrentBlueprintFloorPlan;
			if (currentBlueprintFloorPlan == null)
			{
				_settings.AcceptBuildButtonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
			}
			else
			{
				_settings.AcceptBuildButtonAnimator.CurrentState = ((!currentBlueprintFloorPlan.CanBeBuilt) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
		}

		private void RefreshPrestige()
		{
			BlueprintFloorPlan currentBlueprintFloorPlan = _level.BuildingLogic.CurrentBlueprintFloorPlan;
			RoomPrestige roomPrestige = default(RoomPrestige);
			if (currentBlueprintFloorPlan == null)
			{
				roomPrestige.Level = 1;
				roomPrestige.Progress = 0f;
				_settings.PrestigeProgressBar.Progress = (float)roomPrestige.Level + roomPrestige.Progress;
			}
			else
			{
				roomPrestige = GameAlgorithms.CalculateRoomPrestige(currentBlueprintFloorPlan);
				_settings.PrestigeProgressBar.SetProgressSmooth((float)roomPrestige.Level + roomPrestige.Progress);
			}
			_settings.PrestigeLevelText.text = ScriptLocalization.Menu.BuildRoom_RoomPrestige_CS.Replace("{[Level]}", roomPrestige.Level.ToString());
		}

		private void RefreshRoomCost()
		{
			BlueprintFloorPlan currentBlueprintFloorPlan = _level.BuildingLogic.CurrentBlueprintFloorPlan;
			if (currentBlueprintFloorPlan != null)
			{
				bool isNewRoom = _level.BuildingLogic.CurrentState == BuildingLogic.State.NewRoom;
				int num = Mathf.Max(GameAlgorithms.CalculatePurchaseCostOfRoom(currentBlueprintFloorPlan, isNewRoom), 0);
				_settings.RoomCostText.text = StringUtils.FormatCurrencyWithoutSymbol(num);
				_settings.RoomCostText.color = (currentBlueprintFloorPlan.CanAfford ? _settings.CostOfRoomTextAffordableColor : _settings.CostOfRoomTextUnaffordableColor);
			}
			else
			{
				_settings.RoomCostText.text = StringUtils.FormatCurrencyWithoutSymbol(0m);
				_settings.RoomCostText.color = _settings.CostOfRoomTextAffordableColor;
			}
		}

		private void RefreshPromptText(BlueprintFloorPlan floorPlan)
		{
			if (floorPlan == null)
			{
				GameObjectUtils.SetActive(_settings.BuildPromptText.gameObject, isActive: false);
				return;
			}
			string text = null;
			if (!floorPlan.ValidRoomSize)
			{
				text = ScriptLocalization.Menu.BuildRoom_MinimumRoomSize_CS.Replace("{[X]}", floorPlan.Definition._minSizeX.ToString()).Replace("{[Y]}", floorPlan.Definition._minSizeY.ToString());
			}
			else
			{
				bool flag = false;
				List<RoomItem> items = floorPlan.Items;
				RequiredItem[] requiredItems = floorPlan.Definition.GetRequiredItems();
				foreach (RequiredItem requiredItem in requiredItems)
				{
					bool flag2 = false;
					string newValue = (string.IsNullOrEmpty(requiredItem.GroupName) ? requiredItem.Items[0].Instance.GetLocalisedName() : requiredItem.GroupName);
					foreach (RoomItem item in items)
					{
						if (requiredItem.Contains(item.Definition))
						{
							flag2 = true;
						}
					}
					if (!flag2)
					{
						flag = true;
						text = ScriptLocalization.Menu.BuildRoom_PlaceItem_CS.Replace("{[ITEM]}", newValue);
						break;
					}
				}
				if (!flag)
				{
					if (!floorPlan.CanAfford)
					{
						text = ScriptLocalization.Menu.BuildRoom_Unaffordable_CS;
					}
					else if (!floorPlan.ValidRoomItems)
					{
						text = ScriptLocalization.Menu.BuildRoom_FixInvalidItems_CS;
					}
				}
			}
			if (text != null)
			{
				_settings.BuildPromptText.text = text;
				GameObjectUtils.SetActive(_settings.BuildPromptText.gameObject, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_settings.BuildPromptText.gameObject, isActive: false);
			}
		}

		private void RefreshItemsList()
		{
			if (!_currentlyMovingRoom)
			{
				BlueprintFloorPlan currentBlueprintFloorPlan = _level.BuildingLogic.CurrentBlueprintFloorPlan;
				if (currentBlueprintFloorPlan != null && currentBlueprintFloorPlan.HasAnyTiles())
				{
					_level.HospitalHUDManager.ShowItemsList(currentBlueprintFloorPlan.Definition._type, currentBlueprintFloorPlan, playSFX: false);
				}
			}
		}

		public Settings GetSettings()
		{
			return _settings;
		}

		public void ShowTutorialHighlight(bool show)
		{
			GameObjectUtils.SetActive(_settings.TutorialGameObject, show);
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			RefreshPrestige();
			RefreshRoomCost();
			RefreshPromptText(_level.BuildingLogic.CurrentBlueprintFloorPlan);
		}

		private void OnRoomItemPlaced(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Prestige > 0f)
			{
				AudioManager.Instance.Play("PrestigeBarIncrease");
			}
		}

		private void OnEnterNewRoomState(BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			RefreshPromptText(floorPlan);
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			RefreshPrestige();
			RefreshRoomCost();
			RefreshPromptText(_level.BuildingLogic.CurrentBlueprintFloorPlan);
		}

		private void OnCursorModeBecomeActive(CursorMode cursorMode)
		{
			RefreshAddAndSubtractButtons();
			RefreshAcceptButton();
			if (cursorMode is CursorRoomMove)
			{
				_currentlyMovingRoom = true;
			}
		}

		private void OnCursorModeBecomeInactive(CursorMode cursorMode)
		{
			if (cursorMode is CursorRoomMove)
			{
				_currentlyMovingRoom = false;
			}
		}

		public void InitializeForRoomCopy()
		{
			_currentlyMovingRoom = true;
		}

		private void OnBuildModeChanged(CursorRoomBuild.RoomAreaDragOperation dragOperation)
		{
			RefreshAddAndSubtractButtons();
			RefreshRoomCost();
			RefreshPromptText(_level.BuildingLogic.CurrentBlueprintFloorPlan);
		}

		private void OnBeginItemPlacement(IRoomItemDefinition roomItemDefinition, FloorPlan floorPlan, bool endOnPlace)
		{
			RefreshAddAndSubtractButtons();
			RefreshItemsList();
		}

		private void OnBeginNewRoom(RoomDefinition roomDefinition)
		{
			RefreshAddAndSubtractButtons();
			RefreshPrestige();
			RefreshRoomCost();
			RefreshItemsList();
		}

		private void OnFloorPlanUpdated(BlueprintFloorPlan floorPlan)
		{
			RefreshRoomCost();
			RefreshPrestige();
			RefreshPromptText(floorPlan);
			RefreshItemsList();
			RefreshAcceptButton();
		}

		private void OnRoomValidityChanged(BlueprintFloorPlan floorPlan)
		{
			RefreshAcceptButton();
			RefreshItemsList();
			RefreshPromptText(floorPlan);
		}

		private void OnAddFloorButton()
		{
			if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
			{
				_level.BuildingLogic.ChangeRoomBuildMode(CursorRoomBuild.RoomAreaDragOperation.Add);
			}
		}

		private void OnRemoveFloorButton()
		{
			if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
			{
				_level.BuildingLogic.ChangeRoomBuildMode(CursorRoomBuild.RoomAreaDragOperation.Subtract);
			}
		}

		private void OnAcceptBuildButton()
		{
			_level.BuildingLogic.TryAcceptRoomChanges();
		}

		private void OnRoomDragStart(FloorPlan floorPlan)
		{
			if (_roomSizeUI == null)
			{
				_roomSizeUI = UnityEngine.Object.Instantiate(_settings.RoomSizePrefab);
				_roomSizeUI.GetComponent<RoomSize>().Initialise(_level.HUD, floorPlan);
			}
		}

		private void OnRoomDragEnd()
		{
			if (_roomSizeUI != null)
			{
				UnityEngine.Object.Destroy(_roomSizeUI);
				_roomSizeUI = null;
			}
		}

		public override void Destroy()
		{
			OnRoomDragEnd();
			UnregisterEvents();
			base.Destroy();
		}
	}
}
