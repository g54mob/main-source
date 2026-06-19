using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RibbonMenu : MenuBase, IRibbonMenuView
	{
		public enum Mode
		{
			Null = 0,
			Items = 1,
			Rooms = 2,
			Hire = 3
		}

		[Serializable]
		public class RibbonMenuSettings
		{
			[Header("Assets")]
			public Sprite GridButtonSpirte;

			public Sprite TableButtonSpirte;

			[Header("GUI Components")]
			public GameObject StaffTypesGameObject;

			public InputField SearchInputField;

			public Table Table;

			public ScrollRect ScrollRect;

			public RibbonMenuScrollbar _ribbonMenuScrollbar;

			public GridLayoutGroup GridLayoutGroup;

			public GameObject TableHeaders;

			public TMP_Text HeaderText;

			public float HeaderTextWidth = 330f;

			public DynamicButton CloseButton;

			public RectTransform BodyRectTransform;

			public Image GridToggleImage;

			public GameObject GridToggleGameObject;

			[Header("Localisation")]
			public LocalisedString ItemsString;

			public LocalisedString RoomsString;

			public LocalisedString HireString;

			[Header("Audio Event Names")]
			public string SelectItem;

			public string UnlockItem;

			public string FailUnlockingItem;

			public string SelectInactiveItem;
		}

		[SerializeField]
		private RibbonMenuData _data;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private RibbonMenuBarAnimatorParams _ribbonMenuBarBarAnimatorParams;

		[SerializeField]
		private RibbonMenuBodyAnimatorParams _ribbonMenuBodyAnimatorParams;

		[SerializeField]
		private GameObject _tutorialGameObject;

		[SerializeField]
		private DynamicButton _templatesButton;

		[SerializeField]
		private ButtonAnimator _templatesButtonAnimator;

		private Level _level;

		private RibbonMenuBarAnimator _ribbonMenuBarAnimator;

		private RibbonMenuBodyAnimator _ribbonMenuBodyAnimator;

		private RibbonMenuItemsState _ribbonMenuItemsState;

		private RibbonMenuRoomsState _ribbonMenuRoomsState;

		private RibbonMenuBuildState _ribbonMenuBuildState;

		private RibbonMenuHireState _ribbonMenuHireState;

		[NonSerialized]
		public Action<Mode> OnEnterMode;

		public GameObject TutorialGameObject => _tutorialGameObject;

		public RibbonMenuSettings Settings => _data.RibbonMenuSettings;

		public RibbonMenuBarAnimatorParams BarAnimatorSettings => _ribbonMenuBarBarAnimatorParams;

		public RibbonMenuBodyAnimatorParams BodyAnimatorSettings => _ribbonMenuBodyAnimatorParams;

		public RibbonMenuHireState.Settings HireStateSettings => _data.HireStateSettings;

		public RibbonMenuBuildState.Settings BuildStateSettings => _data.BuildStateSettings;

		public RibbonMenuItemsState.Settings ItemsStateSettings => _data.ItemsStateSettings;

		public RibbonMenuRoomsState.Settings RoomsStateSettings => _data.RoomsStateSettings;

		public bool ShowGridForItems
		{
			get
			{
				return _ribbonMenuItemsState.ShowGridForItems;
			}
			set
			{
				_ribbonMenuItemsState.ShowGridForItems = value;
			}
		}

		public RibbonMenuItemsState RibbonMenuItemsState => _ribbonMenuItemsState;

		public RibbonMenuRoomsState RibbonMenuRoomsState => _ribbonMenuRoomsState;

		public RibbonMenuBuildState RibbonMenuBuildState => _ribbonMenuBuildState;

		public RibbonMenuHireState RibbonMenuHireState => _ribbonMenuHireState;

		public Mode CurrentMode
		{
			get
			{
				if (_ribbonMenuItemsState.Enabled)
				{
					return Mode.Items;
				}
				if (_ribbonMenuRoomsState.Enabled)
				{
					return Mode.Rooms;
				}
				if (_ribbonMenuHireState.Enabled)
				{
					return Mode.Hire;
				}
				return Mode.Null;
			}
		}

		public void EnableGrid()
		{
			_data.RibbonMenuSettings.Table.enabled = false;
			_data.RibbonMenuSettings.ScrollRect.content = _data.RibbonMenuSettings.GridLayoutGroup.GetComponent<RectTransform>();
			GameObjectUtils.SetActive(_data.RibbonMenuSettings.GridLayoutGroup.gameObject, isActive: true);
		}

		public void EnableTable()
		{
			_data.RibbonMenuSettings.Table.enabled = true;
			_data.RibbonMenuSettings.ScrollRect.content = _data.RibbonMenuSettings.Table.Rows;
			GameObjectUtils.SetActive(_data.RibbonMenuSettings.GridLayoutGroup.gameObject, isActive: false);
		}

		public void SetToggleGridButtonActive(bool active)
		{
			_data.RibbonMenuSettings.GridToggleGameObject.SetActive(active);
		}

		public void SwapToggleToGridIcon()
		{
			_data.RibbonMenuSettings.GridToggleImage.sprite = _data.RibbonMenuSettings.GridButtonSpirte;
		}

		public void SwapToggleToTableIcon()
		{
			_data.RibbonMenuSettings.GridToggleImage.sprite = _data.RibbonMenuSettings.TableButtonSpirte;
		}

		public void DestroyAllListItems()
		{
			foreach (Transform item in _data.RibbonMenuSettings.GridLayoutGroup.transform)
			{
				item.gameObject.name = "ToDestroy";
				UnityEngine.Object.Destroy(item.gameObject);
			}
			_data.RibbonMenuSettings.GridLayoutGroup.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, 0f, 0f);
			foreach (Transform row in _data.RibbonMenuSettings.Table.Rows)
			{
				UnityEngine.Object.Destroy(row.gameObject);
			}
		}

		public void SetTableRowHeight(float rowHeight)
		{
			_data.RibbonMenuSettings.Table.RowHeight = rowHeight;
		}

		public void SetTableHeadersActive(bool active)
		{
			GameObjectUtils.SetActive(_data.RibbonMenuSettings.TableHeaders, active);
		}

		public void SetTableRowFilter(Func<RectTransform, bool> filter)
		{
			_data.RibbonMenuSettings.Table.RowFilter = filter;
		}

		public void SetTableColumnHeaders(RectTransform columnHeaders)
		{
			_data.RibbonMenuSettings.Table.ColumnHeaders = columnHeaders;
		}

		public void SetTableColumnDefinitions(List<Table.ColumnDefinition> columnDefinitions)
		{
			_data.RibbonMenuSettings.Table.ColumnDefinitions = columnDefinitions;
		}

		public void SetTableDirtyLayout()
		{
			_data.RibbonMenuSettings.Table.SetDirty();
		}

		public GameObject InstantiateAsRowInTable(GameObject row)
		{
			return _data.RibbonMenuSettings.Table.InstantiateAsRow(row);
		}

		public void ResortTable()
		{
			_data.RibbonMenuSettings.Table.Resort();
		}

		public GameObject InstantiateAsCellInGrid(GameObject cell)
		{
			return UnityEngine.Object.Instantiate(cell, _data.RibbonMenuSettings.GridLayoutGroup.transform);
		}

		public void RecalulateGridHeight()
		{
			GridLayoutGroup gridLayoutGroup = _data.RibbonMenuSettings.GridLayoutGroup;
			int num = 0;
			foreach (Transform item in gridLayoutGroup.transform)
			{
				if (item.gameObject != null && item.gameObject.activeSelf && item.gameObject.name != "ToDestroy")
				{
					num++;
				}
			}
			int numOfGridColumns = GetNumOfGridColumns();
			int num2 = Mathf.CeilToInt((float)num / (float)numOfGridColumns);
			float size = (float)gridLayoutGroup.padding.vertical + (float)num2 * gridLayoutGroup.cellSize.y + (float)Mathf.Max(0, num2 - 1) * gridLayoutGroup.spacing.y;
			gridLayoutGroup.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, 0f, size);
		}

		public int GetNumOfGridColumns()
		{
			return 3;
		}

		public float GetGridCellWidth()
		{
			return _data.RibbonMenuSettings.GridLayoutGroup.cellSize.x;
		}

		public float GetGridCellSpacingHorizontal()
		{
			return _data.RibbonMenuSettings.GridLayoutGroup.spacing.x;
		}

		public void FilterGridCells(Func<RectTransform, bool> filter)
		{
			GridLayoutGroup gridLayoutGroup = _data.RibbonMenuSettings.GridLayoutGroup;
			if (filter == null)
			{
				foreach (Transform item in gridLayoutGroup.transform)
				{
					GameObjectUtils.SetActive(item.gameObject, isActive: true);
				}
				return;
			}
			foreach (Transform item2 in gridLayoutGroup.transform)
			{
				GameObjectUtils.SetActive(item2.gameObject, filter(item2 as RectTransform));
			}
		}

		public void TransitionBody(ref RibbonMenuBodyAnimator.Target target, GameObject[] gameObjectsToEnable)
		{
			_ribbonMenuBodyAnimator.Transition(ref target, gameObjectsToEnable);
		}

		public void SetStaffTypeButtonsActive(bool active)
		{
			GameObjectUtils.SetActive(_data.RibbonMenuSettings.StaffTypesGameObject, active);
		}

		public void PlaySelectItemSFX()
		{
			AudioManager.Instance.Play(_data.RibbonMenuSettings.SelectItem);
		}

		public void PlayFailUnlockingItemSFX()
		{
			AudioManager.Instance.Play(_data.RibbonMenuSettings.FailUnlockingItem);
		}

		public void PlaySelectInactiveItemSFX()
		{
			AudioManager.Instance.Play(_data.RibbonMenuSettings.SelectInactiveItem);
		}

		public void PlayUnlockItemSFX()
		{
			AudioManager.Instance.Play(_data.RibbonMenuSettings.UnlockItem);
		}

		public float GetScrollVerticalPosition()
		{
			float result = 1f;
			if (_data.RibbonMenuSettings.Table.RowsScrollRect != null)
			{
				result = _data.RibbonMenuSettings.Table.RowsScrollRect.verticalNormalizedPosition;
			}
			return result;
		}

		public void ResetScrollVerticalPosition(float position = 1f)
		{
			if (_data.RibbonMenuSettings.Table.RowsScrollRect != null)
			{
				_data.RibbonMenuSettings.Table.RowsScrollRect.verticalNormalizedPosition = position;
			}
		}

		public void Setup(Level level)
		{
			_level = level;
			_data.RibbonMenuSettings.HeaderText.text = string.Empty;
			_ribbonMenuBarAnimator = new RibbonMenuBarAnimator(_ribbonMenuBarBarAnimatorParams);
			_ribbonMenuBodyAnimator = new RibbonMenuBodyAnimator(_ribbonMenuBodyAnimatorParams);
			_ribbonMenuBuildState = new RibbonMenuBuildState(_level, _data.BuildStateSettings);
			_ribbonMenuItemsState = new RibbonMenuItemsState(_level, this, _data.ItemsStateSettings);
			_ribbonMenuRoomsState = new RibbonMenuRoomsState(_level, this, _data.RoomsStateSettings);
			_ribbonMenuHireState = new RibbonMenuHireState(_level, this, _data.HireStateSettings);
			if (_data.RibbonMenuSettings._ribbonMenuScrollbar != null)
			{
				_data.RibbonMenuSettings._ribbonMenuScrollbar.Setup(this, _level.InputManager);
			}
			_level.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			_data.RibbonMenuSettings.CloseButton.onPrimaryDown.AddListener(TryCloseMenu);
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Combine(buildEvents2.OnBeginItemEditBuildMode, new Action<RoomItem>(OnBeginItemEditBuildMode));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnAcceptRoom = (Action)Delegate.Combine(buildEvents3.OnAcceptRoom, new Action(OnAcceptRoom));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnMoveRoomStart = (Action)Delegate.Combine(buildEvents4.OnMoveRoomStart, new Action(OnMoveRoomStart));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Combine(buildEvents5.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnCancelRoom = (Action)Delegate.Combine(buildEvents6.OnCancelRoom, new Action(OnCancelRoom));
			CursorManager cursorManager = _level.CursorManager;
			cursorManager.OnModeBecomeActive = (Action<CursorMode>)Delegate.Combine(cursorManager.OnModeBecomeActive, new Action<CursorMode>(OnCursorModeBecomeActive));
			CursorManager cursorManager2 = _level.CursorManager;
			cursorManager2.OnModeBecomeInactive = (Action<CursorMode>)Delegate.Combine(cursorManager2.OnModeBecomeInactive, new Action<CursorMode>(OnCursorModeBecomeInactive));
			_templatesButton.onPrimaryDown.AddListener(ToggleRoomTemplatesMenu);
		}

		protected override void Update()
		{
			base.Update();
			_ribbonMenuBuildState.Update();
			_ribbonMenuItemsState.Update();
			_ribbonMenuRoomsState.Update();
		}

		public void RefreshHeaderText()
		{
			(_data.RibbonMenuSettings.HeaderText.gameObject.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _data.RibbonMenuSettings.HeaderTextWidth);
			if (CurrentMode == Mode.Rooms)
			{
				if (_ribbonMenuRoomsState.TemplatesEnabled)
				{
					_data.RibbonMenuSettings.HeaderText.text = ScriptLocalization.Menu_Inspector.ButtonTemplates_CS;
					if (_templatesButton != null)
					{
						GameObjectUtils.SetActive(_templatesButton.gameObject, isActive: true);
					}
					return;
				}
				_data.RibbonMenuSettings.HeaderText.text = _data.RibbonMenuSettings.RoomsString.Translation;
				if (_templatesButton != null)
				{
					GameObjectUtils.SetActive(_templatesButton.gameObject, isActive: true);
					_templatesButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				}
				return;
			}
			if (_templatesButton != null)
			{
				GameObjectUtils.SetActive(_templatesButton.gameObject, isActive: false);
			}
			if (CurrentMode == Mode.Items)
			{
				if (_level.BuildingLogic.CurrentFloorPlan != null)
				{
					_data.RibbonMenuSettings.HeaderText.text = _level.BuildingLogic.CurrentFloorPlan.Definition.GetLocalisedName();
				}
				else
				{
					_data.RibbonMenuSettings.HeaderText.text = _data.RibbonMenuSettings.ItemsString.Translation;
				}
			}
			else if (CurrentMode == Mode.Hire)
			{
				_data.RibbonMenuSettings.HeaderText.text = _data.RibbonMenuSettings.HireString.Translation;
			}
			else
			{
				_data.RibbonMenuSettings.HeaderText.text = string.Empty;
			}
		}

		private void OnBeginItemEditBuildMode(RoomItem roomItem)
		{
			_ribbonMenuBuildState.Enable();
			RefreshHeaderText();
		}

		private void OnMoveRoomStart()
		{
			_ribbonMenuBuildState.Enable();
			RefreshHeaderText();
		}

		private void OnCursorModeBecomeActive(CursorMode cursorMode)
		{
			if (cursorMode is CursorRoomMove)
			{
				OnRoomMoveMode(bMoveModeStart: true);
			}
		}

		private void OnCursorModeBecomeInactive(CursorMode cursorMode)
		{
			if (cursorMode is CursorRoomMove)
			{
				OnRoomMoveMode(bMoveModeStart: false);
			}
		}

		private void OnBeginNewRoom(RoomDefinition roomDefinition)
		{
			_ribbonMenuBuildState.Enable();
			RefreshHeaderText();
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			_ribbonMenuBuildState.Enable();
			RefreshHeaderText();
		}

		private void OnAcceptRoom()
		{
			_ribbonMenuBuildState.Disable();
			RefreshHeaderText();
		}

		private void OnCancelRoom()
		{
			_ribbonMenuBuildState.Disable();
			RefreshHeaderText();
		}

		public void InitializeForRoomCopy()
		{
			OnRoomMoveMode(bMoveModeStart: true);
			_ribbonMenuBuildState.InitializeForRoomCopy();
		}

		private void OnRoomMoveMode(bool bMoveModeStart)
		{
			GameObjectUtils.SetActive(BodyAnimatorSettings.Body.gameObject, !bMoveModeStart);
			HubMenu hubMenu = _level.HUD.FindMenu<HubMenu>();
			if (hubMenu != null && hubMenu.HubMenuButtons != null)
			{
				hubMenu.HubMenuButtons.UpdateHubMenuButtonStates((!bMoveModeStart) ? CurrentMode : Mode.Null);
			}
		}

		protected void OnDestroy()
		{
			_level.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Remove(buildEvents2.OnBeginItemEditBuildMode, new Action<RoomItem>(OnBeginItemEditBuildMode));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnMoveRoomStart = (Action)Delegate.Remove(buildEvents3.OnMoveRoomStart, new Action(OnMoveRoomStart));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Remove(buildEvents4.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnAcceptRoom = (Action)Delegate.Remove(buildEvents5.OnAcceptRoom, new Action(OnAcceptRoom));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnCancelRoom = (Action)Delegate.Remove(buildEvents6.OnCancelRoom, new Action(OnCancelRoom));
			CursorManager cursorManager = _level.CursorManager;
			cursorManager.OnModeBecomeActive = (Action<CursorMode>)Delegate.Remove(cursorManager.OnModeBecomeActive, new Action<CursorMode>(OnCursorModeBecomeActive));
			CursorManager cursorManager2 = _level.CursorManager;
			cursorManager2.OnModeBecomeInactive = (Action<CursorMode>)Delegate.Remove(cursorManager2.OnModeBecomeInactive, new Action<CursorMode>(OnCursorModeBecomeInactive));
			_ribbonMenuRoomsState.Destroy();
			_ribbonMenuItemsState.Destroy();
			_ribbonMenuBuildState.Destroy();
			_ribbonMenuHireState.Destroy();
		}

		public void TransitionIntoItemsList(RoomDefinition.Type roomType, FloorPlan floorPlan, bool decorationOnly)
		{
			if (!IsClosing())
			{
				if (CurrentMode != Mode.Items)
				{
					TransitionToNullState();
				}
				_ribbonMenuItemsState.TransitionInto(roomType, floorPlan, decorationOnly);
				if (!_ribbonMenuBuildState.Enabled)
				{
					GameObject[] gameObjectsToEnable = ((_ribbonMenuItemsState.BarGameObjects != null && _ribbonMenuItemsState.BarGameObjects.Length != 0) ? _ribbonMenuItemsState.BarGameObjects : _data.ItemsStateSettings.BarGameObjects);
					_ribbonMenuBarAnimator.Transition(_data.ItemsStateSettings.BarWidth, _data.ItemsStateSettings.BarLeftSectionWidth, gameObjectsToEnable);
					_ribbonMenuItemsState.RefreshUGCButtonState();
				}
				OnEnterMode.InvokeSafe(CurrentMode);
				RefreshHeaderText();
			}
		}

		public void TransitionIntoRoomsList()
		{
			if (!IsClosing())
			{
				if (CurrentMode != Mode.Rooms)
				{
					TransitionToNullState();
					ShrinkBuildBar();
				}
				_ribbonMenuRoomsState.TransitionInto();
				if (!_ribbonMenuBuildState.Enabled)
				{
					_ribbonMenuBarAnimator.Transition(_data.RoomsStateSettings.BarWidth, _data.RoomsStateSettings.BarLeftSectionWidth, _data.RoomsStateSettings.BarGameObjects);
				}
				OnEnterMode.InvokeSafe(CurrentMode);
				RefreshHeaderText();
			}
		}

		public void TransitionIntoHireList()
		{
			if (!IsClosing())
			{
				if (CurrentMode != Mode.Hire)
				{
					TransitionToNullState();
				}
				_ribbonMenuHireState.TransitionInto();
				_ribbonMenuBarAnimator.Transition(_data.HireStateSettings.BarWidth, _data.HireStateSettings.BarLeftSectionWidth, _data.HireStateSettings.BarGameObjects);
				OnEnterMode.InvokeSafe(CurrentMode);
				RefreshHeaderText();
			}
		}

		public void ExpandBuildBar()
		{
			_ribbonMenuBuildState.Enable();
			List<GameObject> list = new List<GameObject>(_data.BuildStateSettings.BarGameObjects);
			if (_ribbonMenuItemsState.Enabled)
			{
				GameObject[] collection = ((_ribbonMenuItemsState.BarGameObjects != null && _ribbonMenuItemsState.BarGameObjects.Length != 0) ? _ribbonMenuItemsState.BarGameObjects : _data.ItemsStateSettings.BarGameObjects);
				list.AddRange(collection);
			}
			if (_ribbonMenuRoomsState.Enabled)
			{
				list.AddRange(_data.RoomsStateSettings.BarGameObjects);
			}
			_ribbonMenuBarAnimator.Transition(_data.BuildStateSettings.BarWidth, _data.BuildStateSettings.BarLeftSectionWidth, list.ToArray());
			if (_ribbonMenuItemsState.Enabled)
			{
				_ribbonMenuItemsState.RefreshUGCButtonState();
			}
			RefreshHeaderText();
		}

		public void ShrinkBuildBar()
		{
			_ribbonMenuBuildState.Disable();
			switch (CurrentMode)
			{
			case Mode.Hire:
				_ribbonMenuBarAnimator.Transition(_data.HireStateSettings.BarWidth, _data.HireStateSettings.BarLeftSectionWidth, _data.HireStateSettings.BarGameObjects);
				break;
			case Mode.Items:
			{
				GameObject[] gameObjectsToEnable = ((_ribbonMenuItemsState.BarGameObjects != null && _ribbonMenuItemsState.BarGameObjects.Length != 0) ? _ribbonMenuItemsState.BarGameObjects : _data.ItemsStateSettings.BarGameObjects);
				_ribbonMenuBarAnimator.Transition(_data.ItemsStateSettings.BarWidth, _data.ItemsStateSettings.BarLeftSectionWidth, gameObjectsToEnable);
				_ribbonMenuItemsState.RefreshUGCButtonState();
				break;
			}
			case Mode.Rooms:
				_ribbonMenuBarAnimator.Transition(_data.RoomsStateSettings.BarWidth, _data.RoomsStateSettings.BarLeftSectionWidth, _data.RoomsStateSettings.BarGameObjects);
				break;
			}
			RefreshHeaderText();
		}

		public RibbonItemRow FindItemRow(RoomItemDefinition roomItemDefinition)
		{
			if (CurrentMode != Mode.Items)
			{
				return null;
			}
			return _ribbonMenuItemsState.FindRow(roomItemDefinition);
		}

		public RibbonRoomRow FindRoomRow(RoomDefinition roomDefinition)
		{
			if (CurrentMode != Mode.Rooms)
			{
				return null;
			}
			return _ribbonMenuRoomsState.FindRow(roomDefinition);
		}

		private void TransitionToNullState()
		{
			if (CurrentMode != Mode.Null)
			{
				switch (CurrentMode)
				{
				case Mode.Items:
					_ribbonMenuItemsState.TransitionOut();
					break;
				case Mode.Rooms:
					_ribbonMenuRoomsState.TransitionOut();
					break;
				case Mode.Hire:
					_ribbonMenuHireState.TransitionOut();
					break;
				}
				_data.RibbonMenuSettings.Table.RowFilter = null;
				if (_data.RibbonMenuSettings.SearchInputField != null)
				{
					_data.RibbonMenuSettings.SearchInputField.text = string.Empty;
				}
				OnEnterMode.InvokeSafe(CurrentMode);
			}
		}

		public void ShowTutorialObject(bool show, RectTransform attachTransform = null)
		{
			GameObjectUtils.SetActive(_tutorialGameObject, show);
			if (attachTransform != null)
			{
				_tutorialGameObject.transform.position = attachTransform.position;
			}
		}

		public void ToggleRoomTemplatesMenu()
		{
			if (CurrentMode != Mode.Rooms)
			{
				return;
			}
			_ribbonMenuRoomsState.ToggleTemplatesList();
			if ((bool)_templatesButtonAnimator)
			{
				if (_ribbonMenuRoomsState.TemplatesEnabled)
				{
					_templatesButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				}
				else
				{
					_templatesButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				}
			}
		}

		public override void TryCloseMenu()
		{
			_level.HospitalHUDManager.TryHideRibbonMenu();
			RefreshHeaderText();
		}
	}
}
