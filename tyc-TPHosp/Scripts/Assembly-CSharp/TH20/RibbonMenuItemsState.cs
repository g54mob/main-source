using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.EventAwardSilver;
using TH20.EventUnlockItem;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TH20
{
	public class RibbonMenuItemsState : MustCallDestroy, TH20.EventUnlockItem.Interface, IGameEventCallback, TH20.EventAwardSilver.Interface
	{
		[Serializable]
		public class Settings
		{
			public GameObject RibbonItemRowPrefab;

			public GameObject RibbonItemCellPrefab;

			public GameObject RibbonFilterRowPrefab;

			public RoomItemFilterDatabase RoomItemFilterDatabase;

			[Header("Grid")]
			public DynamicButton GridRowToggleButton;

			[Header("Table Settings")]
			public RectTransform TableHeader;

			public List<Table.ColumnDefinition> ColumnDefinitions;

			public int RowHeight;

			public int FilterRowHeight;

			[Header("Filter")]
			public LocalisedString AllFilterName;

			public DynamicButton FilterButton;

			public ButtonAnimator FilterButtonAnimator;

			public DynamicButton ClearTextFilterButton;

			public TMP_InputField _inputControlTextFilter;

			public Image _imageControlTextFilterBG;

			public float _textFilterUpdateDelaySecs;

			public Color _colorFilterNone = Color.white;

			public Color _colorFilterActive = Color.black;

			public Color _colorFilterTextActive = Color.blue;

			public Localize CurrentFilterNameLocalize;

			[Header("Ribbon Bar")]
			public int BarWidth;

			public int BarLeftSectionWidth;

			public GameObject[] BarGameObjects;

			public DynamicButton ButtonUGC;

			[Header("Ribbon Body")]
			[FormerlySerializedAs("BodyAnimatorTarget")]
			public RibbonMenuBodyAnimator.Target BodyTableAnimatorTarget;

			public RibbonMenuBodyAnimator.Target BodyGridAnimatorTarget;

			public int BodyHeight;

			public int BodyBackgroundWidth;

			public int BodyScrollViewWidth;

			public GameObject[] BodyGameObjects;
		}

		private readonly Settings _settings;

		private readonly List<IRoomItemDefinition> _items = new List<IRoomItemDefinition>(64);

		private readonly List<RibbonItemRow> _rows = new List<RibbonItemRow>(64);

		private readonly List<RibbonItemRow> _requiredRows = new List<RibbonItemRow>(64);

		private readonly Level _level;

		private readonly IRibbonMenuView _ribbonMenuView;

		private bool _enabled;

		private bool _decorationOnly;

		private bool _showFilters;

		private bool _showGridForItems;

		private FloorPlan _activeFloorPlan;

		private RoomDefinition.Type _activeRoomType = RoomDefinition.Type.Invalid;

		private RibbonItemRow _currentSelectedRow;

		private float _prevScrollBarVerticalPosition;

		private float _itemsListUpdatePendingTimer;

		private bool _bInputControlTextFilterCallbacksDisabled;

		private bool _bInputControlTextFilterActive;

		private string _textFilterTextLive;

		private string _textFilterText;

		private RoomItemFilter _itemFilter;

		private ExtContentBundleInfo _bundleFilter;

		private RoomItemDefinition _tutorialItem;

		public bool Enabled => _enabled;

		public bool ShowGridForItems
		{
			get
			{
				return _showGridForItems;
			}
			set
			{
				SetShowGridForItems(value);
			}
		}

		private RequiredItem[] RequiredItems
		{
			get
			{
				if (_activeFloorPlan == null)
				{
					return null;
				}
				return _activeFloorPlan.Definition.GetRequiredItems();
			}
		}

		public GameObject[] BarGameObjects { get; private set; }

		public RibbonMenuItemsState(Level level, IRibbonMenuView ribbonMenuView, Settings settings)
		{
			_settings = settings;
			_level = level;
			_ribbonMenuView = ribbonMenuView;
			GameObject[] barGameObjects = _settings.BarGameObjects;
			for (int i = 0; i < barGameObjects.Length; i++)
			{
				GameObjectUtils.SetActive(barGameObjects[i], isActive: false);
			}
			if (_settings.BodyGameObjects != null)
			{
				barGameObjects = _settings.BodyGameObjects;
				for (int i = 0; i < barGameObjects.Length; i++)
				{
					GameObjectUtils.SetActive(barGameObjects[i], isActive: false);
				}
			}
			BarGameObjects = _settings.BarGameObjects;
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnBeginItemPlacement = (Action<IRoomItemDefinition, FloorPlan, bool>)Delegate.Combine(buildEvents.OnBeginItemPlacement, new Action<IRoomItemDefinition, FloorPlan, bool>(OnBeginItemPlacement));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemCancel = (Action<RoomItem, bool>)Delegate.Combine(buildEvents3.OnRoomItemCancel, new Action<RoomItem, bool>(OnRoomItemCancel));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents4.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnBeginItemEdit = (Action<RoomItem, Room>)Delegate.Combine(buildEvents5.OnBeginItemEdit, new Action<RoomItem, Room>(OnBeginItemEdit));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Combine(buildEvents6.OnBeginItemEditBuildMode, new Action<RoomItem>(OnBeginItemEditBuildMode));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents7.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnEnterNullState = (Action<BuildingLogic.State, bool>)Delegate.Combine(buildEvents8.OnEnterNullState, new Action<BuildingLogic.State, bool>(OnEnterNullState));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnBuildModeChanged = (Action<CursorRoomBuild.RoomAreaDragOperation>)Delegate.Combine(buildEvents9.OnBuildModeChanged, new Action<CursorRoomBuild.RoomAreaDragOperation>(OnBuildModeChanged));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents10.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnEnterNewRoomState = (Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents11.OnEnterNewRoomState, new Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterNewRoomState));
			BuildEvents buildEvents12 = _level.BuildEvents;
			buildEvents12.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents12.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			_level.Metagame.OnSilverAwarded.Add(this);
			_level.Metagame.OnItemUnlocked.Add(this);
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			_settings.FilterButton.onPrimaryDown.AddListener(OnFilterButtonDown);
			_settings.FilterButton.onSecondaryDown.AddListener(OnFilterButtonSecondaryDown);
			_settings.GridRowToggleButton.onPrimaryDown.AddListener(OnGridRowToggleButtonDown);
			_settings.ButtonUGC?.onPrimaryDown.AddListener(OnUGCButton);
			_settings.ClearTextFilterButton?.onPrimaryDown.AddListener(OnClearTextFilterButtonDown);
			if (_settings._inputControlTextFilter != null)
			{
				_settings._inputControlTextFilter.onEndEdit.AddListener(OnInputControlTextFilterEndEdit);
				_settings._inputControlTextFilter.onValueChanged.AddListener(OnInputControlTextFilterValueChanged);
				_settings._inputControlTextFilter.onSelect.AddListener(OnInputControlTextFilterSelect);
				_settings._inputControlTextFilter.onDeselect.AddListener(OnInputControlTextFilterDeselect);
				TMP_InputField inputControlTextFilter = _settings._inputControlTextFilter;
				inputControlTextFilter.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(inputControlTextFilter.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnInputControlTextFilterValidateInput(addedChar)));
			}
			RefreshUGCButtonState();
		}

		public void TransitionInto(RoomDefinition.Type roomType, FloorPlan floorPlan, bool decorationOnly)
		{
			_activeFloorPlan = floorPlan;
			if (!_enabled || _activeRoomType != roomType || _decorationOnly != decorationOnly)
			{
				_ribbonMenuView.SetStaffTypeButtonsActive(active: false);
				_ribbonMenuView.ResetScrollVerticalPosition();
				_ribbonMenuView.SetToggleGridButtonActive(active: true);
				_settings.CurrentFilterNameLocalize.gameObject.SetActive(value: false);
				_settings._inputControlTextFilter.gameObject.SetActive(value: true);
				_settings.ClearTextFilterButton.gameObject.SetActive(value: false);
				_itemFilter = null;
				_bundleFilter = null;
				ClearTextFilterText();
				SetItemList(roomType, decorationOnly);
				_enabled = true;
				RefreshUGCButtonState();
				UpdateInputControlColorAndClearButton();
			}
		}

		public void TransitionOut()
		{
			_activeRoomType = RoomDefinition.Type.Invalid;
			_currentSelectedRow = null;
			_activeFloorPlan = null;
			_items.Clear();
			_rows.Clear();
			_requiredRows.Clear();
			_ribbonMenuView.SetToggleGridButtonActive(active: false);
			_settings._inputControlTextFilter.gameObject.SetActive(value: false);
			_settings.ClearTextFilterButton.gameObject.SetActive(value: false);
			_ribbonMenuView.DestroyAllListItems();
			_enabled = false;
			RefreshUGCButtonState();
		}

		public void Update()
		{
			if (_enabled)
			{
				ProcessItemsListUpdatePendingTimer();
			}
		}

		private void SetFiltersList()
		{
			_ribbonMenuView.TransitionBody(ref _settings.BodyTableAnimatorTarget, _settings.BodyGameObjects);
			_ribbonMenuView.EnableTable();
			_ribbonMenuView.SetTableRowFilter(null);
			_settings.FilterButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
			_showFilters = true;
			_ribbonMenuView.SetTableRowHeight(_settings.FilterRowHeight);
			SetInputControlTextFilterText(string.Empty);
			ClearTextFilterText();
			StopItemsListUpdatePendingTimer();
			_ribbonMenuView.DestroyAllListItems();
			_items.Clear();
			_level.WorldState.GetItemsForRoom(_activeRoomType, _decorationOnly, _items);
			RoomItemFilter[] filters = _settings.RoomItemFilterDatabase.Filters;
			int[] array = new int[filters.Length];
			int num = 0;
			foreach (IRoomItemDefinition item in _items)
			{
				if (item.Filters == null)
				{
					continue;
				}
				for (int i = 0; i < array.Length; i++)
				{
					for (int j = 0; j < item.Filters.Length; j++)
					{
						if (item.Filters[j] == filters[i])
						{
							array[i]++;
						}
					}
				}
				if (!_level.Metagame.HasUnlocked(item))
				{
					num++;
				}
			}
			RibbonFilterRow component = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonFilterRowPrefab).GetComponent<RibbonFilterRow>();
			component.FilterNameLocalize.Term = _settings.AllFilterName.Term;
			component.CountText.text = _items.Count.ToString("0");
			component.Button.onPrimaryDown.AddListener(delegate
			{
				_itemFilter = null;
				_bundleFilter = null;
				ClearTextFilterText();
				SetItemList(_activeRoomType, _decorationOnly);
			});
			for (int num2 = 0; num2 < filters.Length; num2++)
			{
				if (array[num2] != 0)
				{
					RoomItemFilter filter = filters[num2];
					RibbonFilterRow component2 = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonFilterRowPrefab).GetComponent<RibbonFilterRow>();
					component2.FilterNameLocalize.Term = filter.LocalisedName.Term;
					component2.CountText.text = array[num2].ToString("0");
					component2.Button.onPrimaryDown.AddListener(delegate
					{
						_itemFilter = filter;
						_bundleFilter = null;
						ClearTextFilterText();
						SetItemList(_activeRoomType, _decorationOnly);
					});
					if (filter.IsUGC)
					{
						component2.ApplyUGCBackground();
					}
				}
			}
			List<ExtContentBundleInfo> bundleInfoList = ExtContentUtils.ExtContentManager.ContentSourceWorkshop.GetBundleInfoList();
			for (int num3 = 0; num3 < bundleInfoList.Count; num3++)
			{
				ExtContentBundleInfo bundleInfo = bundleInfoList[num3];
				int num4 = 0;
				for (int num5 = 0; num5 < bundleInfo._bunldeGameItems.Count; num5++)
				{
					EContentType contentType = bundleInfo._bunldeGameItems[num5].ContentType;
					if (contentType == EContentType.Rug || contentType == EContentType.Picture)
					{
						num4++;
					}
				}
				if (num4 != 0)
				{
					RibbonFilterRow component3 = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonFilterRowPrefab).GetComponent<RibbonFilterRow>();
					component3.FilterNameLocalize.enabled = false;
					component3.FilterName.text = bundleInfo._bundleName;
					component3.CountText.text = num4.ToString("0");
					component3.Button.onPrimaryDown.AddListener(delegate
					{
						_itemFilter = null;
						_bundleFilter = bundleInfo;
						ClearTextFilterText();
						SetItemList(_activeRoomType, _decorationOnly);
					});
					component3.ApplyUGCBackground();
				}
			}
			RibbonFilterRow component4 = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonFilterRowPrefab).GetComponent<RibbonFilterRow>();
			component4.FilterNameLocalize.Term = _settings.RoomItemFilterDatabase.LockedFilter.LocalisedName.Term;
			component4.ApplyLockedBackground();
			component4.CountText.text = num.ToString("0");
			component4.Button.onPrimaryDown.AddListener(delegate
			{
				_itemFilter = _settings.RoomItemFilterDatabase.LockedFilter;
				_bundleFilter = null;
				ClearTextFilterText();
				SetItemList(_activeRoomType, _decorationOnly);
			});
			_ribbonMenuView.ResetScrollVerticalPosition();
		}

		private void SetItemList(RoomDefinition.Type roomType, bool decorationOnly)
		{
			if (_textFilterTextLive.IsNullOrEmpty())
			{
				if (_itemFilter == null && _bundleFilter == null)
				{
					SetTemporaryInputControlTextFilterText(string.Empty);
				}
				else
				{
					if (_itemFilter != null)
					{
						SetTemporaryInputControlTextFilterText(_itemFilter.LocalisedName.Translation);
					}
					if (_bundleFilter != null)
					{
						SetTemporaryInputControlTextFilterText(_bundleFilter._bundleName);
					}
				}
			}
			_ribbonMenuView.SetTableHeadersActive(active: false);
			if (_showGridForItems)
			{
				_ribbonMenuView.TransitionBody(ref _settings.BodyGridAnimatorTarget, _settings.BodyGameObjects);
				_ribbonMenuView.SwapToggleToTableIcon();
				_ribbonMenuView.EnableGrid();
			}
			else
			{
				_ribbonMenuView.TransitionBody(ref _settings.BodyTableAnimatorTarget, _settings.BodyGameObjects);
				_ribbonMenuView.EnableTable();
				_ribbonMenuView.SetTableColumnHeaders(_settings.TableHeader);
				_ribbonMenuView.SetTableColumnDefinitions(_settings.ColumnDefinitions);
				_ribbonMenuView.SetTableRowFilter((RectTransform rect) => FilterRow(rect.GetComponent<RibbonItemRow>()));
				_ribbonMenuView.SetTableRowHeight(_settings.RowHeight);
				_ribbonMenuView.SetTableDirtyLayout();
			}
			_settings.FilterButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
			_showFilters = false;
			_ribbonMenuView.DestroyAllListItems();
			_activeRoomType = roomType;
			_decorationOnly = decorationOnly;
			_items.Clear();
			_level.WorldState.GetItemsForRoom(roomType, decorationOnly, _items);
			_items.Sort(delegate(IRoomItemDefinition definition1, IRoomItemDefinition definition2)
			{
				int itemOrder = GetItemOrder(_level, definition1, RequiredItems);
				int itemOrder2 = GetItemOrder(_level, definition2, RequiredItems);
				return itemOrder.CompareTo(itemOrder2);
			});
			_rows.Clear();
			_requiredRows.Clear();
			foreach (IRoomItemDefinition item in _items)
			{
				GameObject gameObject = ((!_showGridForItems) ? _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonItemRowPrefab) : _ribbonMenuView.InstantiateAsCellInGrid(_settings.RibbonItemCellPrefab));
				RibbonItemRow ribbonItemRow = gameObject.GetComponent<RibbonItemRow>();
				ribbonItemRow.Setup(item, _level.Metagame, _level.GameplayStatsTracker);
				RefreshRequiredItemsState(ribbonItemRow);
				ribbonItemRow.Button.onPrimaryDown.AddListener(delegate
				{
					SelectItem(ribbonItemRow);
				});
				ribbonItemRow.ButtonExtContent?.onPrimaryDown.AddListener(delegate
				{
					OnRowUGCButton(ribbonItemRow);
				});
				RefreshRowMode(ribbonItemRow, placedThisFrame: false);
				if (ribbonItemRow.CurrentMode == RibbonItemRow.Mode.Locked)
				{
					ribbonItemRow.Affordable = _level.Metagame.CanAffordSilver(ribbonItemRow.RoomItemDefinition);
				}
				else
				{
					ribbonItemRow.Affordable = _level.FinanceManager.Balance >= ribbonItemRow.RoomItemDefinition.GetCost();
				}
				_rows.Add(ribbonItemRow);
				if (_activeFloorPlan != null && _activeFloorPlan.Definition.IsRequiredItem(ribbonItemRow.RoomItemDefinition))
				{
					_requiredRows.Add(ribbonItemRow);
				}
			}
			if (!_showGridForItems)
			{
				return;
			}
			_ribbonMenuView.FilterGridCells((RectTransform rect) => FilterRow(rect.GetComponent<RibbonItemRow>()));
			int numOfGridColumns = _ribbonMenuView.GetNumOfGridColumns();
			int num = 0;
			float num2 = _ribbonMenuView.GetGridCellWidth() - 0.5f * _ribbonMenuView.GetGridCellSpacingHorizontal();
			foreach (RibbonItemRow row in _rows)
			{
				if (row.isActiveAndEnabled)
				{
					int num3 = num % numOfGridColumns;
					float x = (float)(numOfGridColumns - num3 - 1) * num2;
					row.SetTooltipOffset(new Vector3(x, 0f, 0f));
					num++;
				}
			}
			_ribbonMenuView.RecalulateGridHeight();
		}

		private void RefreshRequiredItemsState(RibbonItemRow row)
		{
			if (row == null)
			{
				return;
			}
			RequiredItem[] requiredItems = RequiredItems;
			if (requiredItems == null)
			{
				row.IsRequired = false;
				return;
			}
			if (_activeFloorPlan != null)
			{
				foreach (RoomItem item in _activeFloorPlan.Items)
				{
					if (item.Definition == row.RoomItemDefinition)
					{
						row.IsRequired = false;
						return;
					}
				}
			}
			RequiredItem requiredItem = null;
			for (int i = 0; i < requiredItems.Length; i++)
			{
				if (requiredItems[i].Contains(row.RoomItemDefinition))
				{
					requiredItem = requiredItems[i];
					break;
				}
			}
			if (requiredItem == null)
			{
				row.IsRequired = false;
				return;
			}
			foreach (RoomItem item2 in _activeFloorPlan.Items)
			{
				if (requiredItem.Contains(item2.Definition))
				{
					row.IsRequired = false;
					return;
				}
			}
			if (!_level.Metagame.HasUnlocked(row.RoomItemDefinition))
			{
				row.IsRequired = false;
			}
			else
			{
				row.IsRequired = true;
			}
		}

		public void SetTutorialItem(RoomItemDefinition roomItemList)
		{
			if (_tutorialItem != roomItemList)
			{
				_tutorialItem = roomItemList;
				if (Enabled && !_showFilters)
				{
					SetItemList(RoomDefinition.Type.Hospital, decorationOnly: true);
				}
			}
		}

		private void SelectItem(RibbonItemRow ribbonItemRow)
		{
			switch (ribbonItemRow.CurrentMode)
			{
			case RibbonItemRow.Mode.Available:
				if (!_level.CursorManager.IsModeActive<CursorRoomMove>())
				{
					_level.BuildEvents.OnStopRoomAutoFlow.InvokeSafe();
					_level.BuildEvents.OnBeginItemPlacement.InvokeSafe(ribbonItemRow.RoomItemDefinition, _activeFloorPlan, param3: false);
					_ribbonMenuView.PlaySelectItemSFX();
				}
				break;
			case RibbonItemRow.Mode.Locked:
				if (!_level.CursorManager.IsModeActive<CursorRoomMove>())
				{
					if (ribbonItemRow.Affordable)
					{
						ShowUnlockItemMessage(ribbonItemRow.RoomItemDefinition);
					}
					else
					{
						_ribbonMenuView.PlayFailUnlockingItemSFX();
					}
				}
				break;
			case RibbonItemRow.Mode.Inactive:
			case RibbonItemRow.Mode.Banned:
				_ribbonMenuView.PlaySelectInactiveItemSFX();
				break;
			case RibbonItemRow.Mode.Selected:
				break;
			}
		}

		private void ShowUnlockItemMessage(IRoomItemDefinition roomItem)
		{
			NotificationDynamicMessage unlockMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions._unlockSilverMessage.Instance, delegate(int response)
			{
				if (response == 0)
				{
					_level.Metagame.UnlockItem(roomItem, spendSilver: true, showMessage: false);
					_level.BuildEvents.OnStopRoomAutoFlow.InvokeSafe();
					_level.BuildEvents.OnBeginItemPlacement.InvokeSafe(roomItem, _activeFloorPlan, param3: false);
					_ribbonMenuView.PlayUnlockItemSFX();
				}
			}, _level);
			NotificationDynamicMessage notificationDynamicMessage = unlockMessage;
			notificationDynamicMessage.FuncGetMessage = (Func<string>)Delegate.Combine(notificationDynamicMessage.FuncGetMessage, (Func<string>)(() => LocalisedString.Replace(unlockMessage.Definition.LocalisedText.Translation, new SubPair[4]
			{
				new SubPair("{[ITEM]}", roomItem.GetLocalisedName()),
				new SubPair("{[SILVER]}", StringUtils.FormatSilverCurrency(roomItem.SilverCost())),
				new SubPair("{[BALANCE]}", StringUtils.FormatSilverCurrency(_level.Metagame.TotalSilver())),
				new SubPair("{[COST]}", StringUtils.FormatCurrency(roomItem.GetCost()))
			})));
			_level.Notifications.Send(unlockMessage);
		}

		private void TrySetSelectedRow(RibbonItemRow row)
		{
			RibbonItemRow currentSelectedRow = _currentSelectedRow;
			_currentSelectedRow = row;
			RefreshRowMode(currentSelectedRow, placedThisFrame: false);
			RefreshRowMode(_currentSelectedRow, placedThisFrame: false);
		}

		private static int GetItemOrder(Level level, IRoomItemDefinition definition, RequiredItem[] requiredItems)
		{
			int num = level.WorldState.AvailableRoomItems.IndexOf(definition);
			if (!level.Metagame.HasUnlocked(definition))
			{
				return 10000 + num;
			}
			if (definition.ItemType == RoomItemDefinition.Type.Door)
			{
				return 0;
			}
			if (definition.ItemType == RoomItemDefinition.Type.Window)
			{
				return 1;
			}
			if (requiredItems != null)
			{
				for (int i = 0; i < requiredItems.Length; i++)
				{
					if (requiredItems[i].Contains(definition))
					{
						return 2;
					}
				}
			}
			return num + 3;
		}

		public override void Destroy()
		{
			RegisterLocalModsCallbacks(bRegister: false);
			if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
			{
				_level.BuildingLogic.TransitionToNullState(applyChanges: false);
			}
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnBeginItemPlacement = (Action<IRoomItemDefinition, FloorPlan, bool>)Delegate.Remove(buildEvents.OnBeginItemPlacement, new Action<IRoomItemDefinition, FloorPlan, bool>(OnBeginItemPlacement));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemCancel = (Action<RoomItem, bool>)Delegate.Remove(buildEvents3.OnRoomItemCancel, new Action<RoomItem, bool>(OnRoomItemCancel));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents4.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnBeginItemEdit = (Action<RoomItem, Room>)Delegate.Remove(buildEvents5.OnBeginItemEdit, new Action<RoomItem, Room>(OnBeginItemEdit));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Remove(buildEvents6.OnBeginItemEditBuildMode, new Action<RoomItem>(OnBeginItemEditBuildMode));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents7.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnEnterNullState = (Action<BuildingLogic.State, bool>)Delegate.Remove(buildEvents8.OnEnterNullState, new Action<BuildingLogic.State, bool>(OnEnterNullState));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnBuildModeChanged = (Action<CursorRoomBuild.RoomAreaDragOperation>)Delegate.Remove(buildEvents9.OnBuildModeChanged, new Action<CursorRoomBuild.RoomAreaDragOperation>(OnBuildModeChanged));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents10.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnEnterNewRoomState = (Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents11.OnEnterNewRoomState, new Action<BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterNewRoomState));
			BuildEvents buildEvents12 = _level.BuildEvents;
			buildEvents12.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents12.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			_level.Metagame.OnSilverAwarded.Remove(this);
			_level.Metagame.OnItemUnlocked.Remove(this);
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			_settings.FilterButton.onPrimaryDown.RemoveListener(OnFilterButtonDown);
			_settings.FilterButton.onSecondaryDown.RemoveListener(OnFilterButtonSecondaryDown);
			_settings.GridRowToggleButton.onPrimaryDown.RemoveListener(OnGridRowToggleButtonDown);
			_settings.ButtonUGC?.onPrimaryDown.RemoveListener(OnUGCButton);
			_settings.ClearTextFilterButton?.onPrimaryDown.RemoveListener(OnClearTextFilterButtonDown);
			if (_settings._inputControlTextFilter != null)
			{
				_settings._inputControlTextFilter.onEndEdit.RemoveListener(OnInputControlTextFilterEndEdit);
				_settings._inputControlTextFilter.onValueChanged.RemoveListener(OnInputControlTextFilterValueChanged);
				_settings._inputControlTextFilter.onSelect.RemoveListener(OnInputControlTextFilterSelect);
				_settings._inputControlTextFilter.onDeselect.RemoveListener(OnInputControlTextFilterDeselect);
				TMP_InputField inputControlTextFilter = _settings._inputControlTextFilter;
				inputControlTextFilter.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Remove(inputControlTextFilter.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnInputControlTextFilterValidateInput(addedChar)));
			}
			base.Destroy();
		}

		private void RefreshRowMode(RibbonItemRow ribbonItemRow, bool placedThisFrame)
		{
			if (!(ribbonItemRow == null))
			{
				IRoomItemDefinition roomItemDefinition = ribbonItemRow.RoomItemDefinition;
				bool num = _level.Metagame.IsBlacklisted(roomItemDefinition);
				bool flag = _level.Metagame.IsWhitelisted(roomItemDefinition);
				if (num || !flag)
				{
					ribbonItemRow.CurrentMode = RibbonItemRow.Mode.Banned;
					ribbonItemRow.Affordable = false;
				}
				else if (!_level.Metagame.HasUnlocked(ribbonItemRow.RoomItemDefinition))
				{
					ribbonItemRow.CurrentMode = RibbonItemRow.Mode.Locked;
					ribbonItemRow.Affordable = _level.Metagame.CanAffordSilver(ribbonItemRow.RoomItemDefinition);
				}
				else if (!CanPlaceItem(ribbonItemRow.RoomItemDefinition, placedThisFrame))
				{
					ribbonItemRow.CurrentMode = RibbonItemRow.Mode.Inactive;
				}
				else if (_currentSelectedRow == ribbonItemRow)
				{
					ribbonItemRow.CurrentMode = RibbonItemRow.Mode.Selected;
				}
				else
				{
					ribbonItemRow.CurrentMode = RibbonItemRow.Mode.Available;
				}
			}
		}

		private bool CanPlaceItem(IRoomItemDefinition roomItemDefinition, bool placedThisFrame)
		{
			if (!_level.Metagame.HasUnlocked(roomItemDefinition) && !_level.Metagame.CanAffordSilver(roomItemDefinition))
			{
				return false;
			}
			if (_activeFloorPlan == null)
			{
				return true;
			}
			if (_activeFloorPlan.Definition.IsHospitalOrBay)
			{
				return true;
			}
			if (placedThisFrame && roomItemDefinition.SinglePlace)
			{
				return false;
			}
			if (roomItemDefinition.SinglePlace)
			{
				foreach (RoomItem item in _activeFloorPlan.Items)
				{
					if (item.Definition == roomItemDefinition)
					{
						return false;
					}
				}
			}
			RoomItemDefinition.Type[] singlePlaceItems = _activeFloorPlan.Definition._singlePlaceItems;
			foreach (RoomItemDefinition.Type type in singlePlaceItems)
			{
				if (type == roomItemDefinition.ItemType && _activeFloorPlan.GetFirstItemOfType(type) != null)
				{
					return false;
				}
			}
			return true;
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			OnRoomItemDestroyed(roomItem);
		}

		private void OnRoomItemDestroyed(RoomItem roomItem)
		{
			if (!_enabled)
			{
				return;
			}
			RibbonItemRow ribbonItemRow = FindRow(roomItem.Definition);
			if (ribbonItemRow == null)
			{
				return;
			}
			TrySetSelectedRow(null);
			RefreshRowMode(ribbonItemRow, placedThisFrame: false);
			foreach (RibbonItemRow requiredRow in _requiredRows)
			{
				RefreshRequiredItemsState(requiredRow);
			}
		}

		private void OnRoomItemCancel(RoomItem roomItem, bool requestedByUser)
		{
			if (_enabled)
			{
				TrySetSelectedRow(null);
			}
		}

		private void OnBeginItemPlacement(IRoomItemDefinition definition, FloorPlan floorPlan, bool endOnPlace)
		{
			if (_enabled)
			{
				TrySetSelectedRow(FindRow(definition));
			}
		}

		private void OnBeginItemEditBuildMode(RoomItem roomItem)
		{
			if (!_enabled)
			{
				return;
			}
			RibbonItemRow row = FindRow(roomItem.Definition);
			TrySetSelectedRow(row);
			foreach (RibbonItemRow requiredRow in _requiredRows)
			{
				RefreshRequiredItemsState(requiredRow);
			}
		}

		private void OnBeginItemEdit(RoomItem roomItem, Room room)
		{
			if (!_enabled)
			{
				return;
			}
			RibbonItemRow row = FindRow(roomItem.Definition);
			TrySetSelectedRow(row);
			foreach (RibbonItemRow requiredRow in _requiredRows)
			{
				RefreshRequiredItemsState(requiredRow);
			}
		}

		private void OnEnterNullState(BuildingLogic.State previousState, bool applyChanges)
		{
			if (_enabled)
			{
				TrySetSelectedRow(null);
			}
		}

		private void OnBuildModeChanged(CursorRoomBuild.RoomAreaDragOperation operation)
		{
			if (_enabled)
			{
				TrySetSelectedRow(null);
				RefreshUGCButtonState();
			}
		}

		private void OnEnterNewRoomState(BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			RefreshUGCButtonState();
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			RefreshUGCButtonState();
		}

		private void OnRoomDeleted(Room room)
		{
			if (room.FloorPlan == _activeFloorPlan)
			{
				_level.HospitalHUDManager.TryHideRibbonMenu();
			}
		}

		private void OnRoomItemPlaced(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (!_enabled)
			{
				return;
			}
			RibbonItemRow ribbonItemRow = FindRow(roomItem.Definition);
			if (ribbonItemRow == null)
			{
				return;
			}
			RefreshRowMode(ribbonItemRow, placedThisFrame: true);
			foreach (RibbonItemRow requiredRow in _requiredRows)
			{
				RefreshRequiredItemsState(requiredRow);
			}
		}

		private void OnSeachValueChanged(string value)
		{
		}

		private void OnGridRowToggleButtonDown()
		{
			SetShowGridForItems(!_showGridForItems);
		}

		private void SetShowGridForItems(bool showGrid)
		{
			if (_showGridForItems == showGrid)
			{
				return;
			}
			_showGridForItems = showGrid;
			if (_enabled)
			{
				if (_showGridForItems)
				{
					_ribbonMenuView.SwapToggleToTableIcon();
				}
				else
				{
					_ribbonMenuView.SwapToggleToGridIcon();
				}
				if (!_showFilters)
				{
					SetItemList(_activeRoomType, _decorationOnly);
				}
			}
		}

		private void OnFilterButtonDown()
		{
			if (_enabled)
			{
				if (_showFilters)
				{
					SetItemList(_activeRoomType, _decorationOnly);
				}
				else
				{
					SetFiltersList();
				}
				ExitCursorModesOnSelectTextInput();
			}
		}

		private void OnFilterButtonSecondaryDown()
		{
			if (_enabled)
			{
				_itemFilter = null;
				_bundleFilter = null;
				ClearTextFilterText();
				SetItemList(_activeRoomType, _decorationOnly);
				ExitCursorModesOnSelectTextInput();
			}
		}

		void TH20.EventUnlockItem.Interface.OnItemUnlockedEvent(ISilverUnlockable item)
		{
			if (!_enabled)
			{
				return;
			}
			foreach (RibbonItemRow row in _rows)
			{
				RefreshRowMode(row, placedThisFrame: false);
			}
		}

		private void OnBalanceUpdated(int balance)
		{
			if (!_enabled)
			{
				return;
			}
			foreach (RibbonItemRow row in _rows)
			{
				if (row.CurrentMode != RibbonItemRow.Mode.Locked)
				{
					row.Affordable = balance >= row.RoomItemDefinition.GetCost();
				}
			}
		}

		void TH20.EventAwardSilver.Interface.OnSilverAwardedEvent(int amount)
		{
			foreach (RibbonItemRow row in _rows)
			{
				RefreshRowMode(row, placedThisFrame: false);
			}
		}

		public void RefreshUGCButtonState()
		{
			bool uGCButtonActive = false;
			if (_enabled && (_level.BuildingLogic.CurrentState == BuildingLogic.State.Null || _level.BuildingLogic.CurrentState == BuildingLogic.State.EditRoomObjects))
			{
				uGCButtonActive = true;
			}
			SetUGCButtonActive(uGCButtonActive);
		}

		public void SetUGCButtonActive(bool bActive)
		{
			_settings.ButtonUGC?.gameObject.SetActive(bActive);
		}

		public void OnUGCButton()
		{
			List<EContentType> list = new List<EContentType>();
			list.Add(EContentType.Picture);
			list.Add(EContentType.Rug);
			ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
			_ = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
			gameItemUIScreen.Configure(bCreateNewItem: true, bAllowAmendContentType: true, EContentType.Picture, list, null);
			_prevScrollBarVerticalPosition = _ribbonMenuView.GetScrollVerticalPosition();
			RegisterLocalModsCallbacks(bRegister: true);
			gameItemUIScreen.Show();
		}

		private void OnRowUGCButton(RibbonItemRow ribbonItemRow)
		{
			if (ribbonItemRow.RoomItemDefinition is RoomItemDefinitionUGC { ExtContentGameItem: var extContentGameItem } && !ExtContentUtils.CheckShowGameItemDevInfoPanel(extContentGameItem) && extContentGameItem != null)
			{
				switch (extContentGameItem.ContentSource)
				{
				case EContentSourceType.LocalMods:
				{
					ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
					_ = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
					gameItemUIScreen.Configure(bCreateNewItem: false, bAllowAmendContentType: false, extContentGameItem.ContentType, null, extContentGameItem);
					_prevScrollBarVerticalPosition = _ribbonMenuView.GetScrollVerticalPosition();
					RegisterLocalModsCallbacks(bRegister: true);
					gameItemUIScreen.Show();
					break;
				}
				case EContentSourceType.Workshop:
				{
					string steamURL = string.Empty;
					string browserURL = string.Empty;
					ExtContentUtils.ExtContentManager.ContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForGameItem(extContentGameItem, ref steamURL, ref browserURL);
					WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
					break;
				}
				}
			}
		}

		private void RegisterLocalModsCallbacks(bool bRegister)
		{
			ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
			ExtContentSourceLocalMods contentSourceLocalMods = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
			if (bRegister)
			{
				gameItemUIScreen.OnUIScreenClosed += OnLocalModUIScreenClosed;
				contentSourceLocalMods.OnGameItemCreated += OnLocalModGameItemCreated;
				contentSourceLocalMods.OnGameItemUpdated += OnLocalModGameItemUpdated;
				contentSourceLocalMods.OnGameItemDeleted += OnLocalModGameItemDeleted;
			}
			else
			{
				gameItemUIScreen.OnUIScreenClosed -= OnLocalModUIScreenClosed;
				contentSourceLocalMods.OnGameItemCreated -= OnLocalModGameItemCreated;
				contentSourceLocalMods.OnGameItemUpdated -= OnLocalModGameItemUpdated;
				contentSourceLocalMods.OnGameItemDeleted -= OnLocalModGameItemDeleted;
			}
		}

		private void OnLocalModUIScreenClosed(GameItemBase gameItem)
		{
			RegisterLocalModsCallbacks(bRegister: false);
		}

		private void OnLocalModGameItemCreated(GameItemBase gameItem)
		{
			_prevScrollBarVerticalPosition = 0f;
			OnLocalModGameItemAmendedGeneral(gameItem);
		}

		private void OnLocalModGameItemUpdated(GameItemBase gameItem)
		{
			OnLocalModGameItemAmendedGeneral(gameItem, bShouldCloseUI: false);
		}

		private void OnLocalModGameItemDeleted(GameItemBase gameItem)
		{
			OnLocalModGameItemAmendedGeneral(gameItem, bShouldCloseUI: false);
		}

		private void OnLocalModGameItemAmendedGeneral(GameItemBase gameItem, bool bShouldCloseUI = true)
		{
			if (gameItem != null && (gameItem.ContentType == EContentType.Picture || gameItem.ContentType == EContentType.Rug) && bShouldCloseUI)
			{
				ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen.Hide();
			}
		}

		public void OnGameItemEditMenusRestored()
		{
			if (_ribbonMenuView != null)
			{
				TransitionOut();
				if (_level.BuildingLogic.CurrentState == BuildingLogic.State.Null)
				{
					TransitionInto(RoomDefinition.Type.Hospital, null, decorationOnly: true);
				}
				else
				{
					TransitionInto(_level.BuildingLogic.CurrentFloorPlan.Definition._type, _level.BuildingLogic.CurrentFloorPlan, decorationOnly: true);
				}
				_ribbonMenuView.ResetScrollVerticalPosition(_prevScrollBarVerticalPosition);
			}
		}

		public RibbonItemRow FindRow(IRoomItemDefinition definition)
		{
			if (definition == null)
			{
				return null;
			}
			foreach (RibbonItemRow row in _rows)
			{
				if (row.RoomItemDefinition == definition)
				{
					return row;
				}
			}
			return null;
		}

		private bool ItemFilter(IRoomItemDefinition definition)
		{
			if (_bInputControlTextFilterActive)
			{
				bool result = true;
				if (!_textFilterTextLive.IsNullOrEmpty())
				{
					result = definition.GetLocalisedName().ToLower().Contains(_textFilterTextLive, StringComparison.CurrentCulture);
				}
				return result;
			}
			if (_itemFilter == null && _bundleFilter == null)
			{
				return true;
			}
			if (_itemFilter == _settings.RoomItemFilterDatabase.LockedFilter)
			{
				return !_level.Metagame.HasUnlocked(definition);
			}
			if (_itemFilter != null)
			{
				RoomItemFilter[] filters = definition.Filters;
				if (filters == null)
				{
					return false;
				}
				for (int i = 0; i < filters.Length; i++)
				{
					if (filters[i] == _itemFilter)
					{
						return true;
					}
				}
				return false;
			}
			if (_bundleFilter != null)
			{
				if (!(definition is RoomItemDefinitionUGC roomItemDefinitionUGC))
				{
					return false;
				}
				foreach (GameItemBase bunldeGameItem in _bundleFilter._bunldeGameItems)
				{
					if (bunldeGameItem.ContentID == roomItemDefinitionUGC.ContentID)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		private bool TutorialFilter(IRoomItemDefinition definition)
		{
			if (_tutorialItem != null)
			{
				return definition == _tutorialItem;
			}
			return true;
		}

		private bool FilterRow(RibbonItemRow row)
		{
			if (row == null)
			{
				return true;
			}
			if (ItemFilter(row.RoomItemDefinition))
			{
				return TutorialFilter(row.RoomItemDefinition);
			}
			return false;
		}

		private void ClearTextFilterText()
		{
			_textFilterText = string.Empty;
			_textFilterTextLive = string.Empty;
		}

		private void SetTextFilterText(string inText)
		{
			_textFilterText = inText;
		}

		private void SetTemporaryInputControlTextFilterText(string inText)
		{
			_bInputControlTextFilterActive = false;
			SetInputControlTextFilterText(inText);
		}

		private void UpdateInputControlColorAndClearButton()
		{
			bool flag = !_settings._inputControlTextFilter.text.IsNullOrEmpty();
			if (_settings._imageControlTextFilterBG != null)
			{
				Color color = _settings._colorFilterNone;
				if (flag)
				{
					color = (_bInputControlTextFilterActive ? _settings._colorFilterTextActive : _settings._colorFilterActive);
				}
				_settings._imageControlTextFilterBG.color = color;
			}
			_settings.ClearTextFilterButton.gameObject.SetActive(flag);
		}

		private void SetInputControlTextFilterText(string inText, bool bDisableCallbacks = true)
		{
			if (_settings._inputControlTextFilter != null)
			{
				_bInputControlTextFilterCallbacksDisabled = bDisableCallbacks;
				_settings._inputControlTextFilter.text = inText;
				_bInputControlTextFilterCallbacksDisabled = false;
				UpdateInputControlColorAndClearButton();
			}
		}

		private void OnInputControlTextFilterEndEdit(string str)
		{
			if (_enabled && !_bInputControlTextFilterCallbacksDisabled && _textFilterTextLive != _textFilterText)
			{
				ApplyInputFilterTextChange();
				SetItemsListUpdatePendingTimer(0f);
			}
		}

		private void OnInputControlTextFilterValueChanged(string str)
		{
			if (_enabled && !_bInputControlTextFilterCallbacksDisabled)
			{
				ApplyInputFilterTextChange();
			}
		}

		private char OnInputControlTextFilterValidateInput(char inChar)
		{
			if (!_enabled)
			{
				return inChar;
			}
			char c = inChar;
			if (!_bInputControlTextFilterCallbacksDisabled)
			{
				if (!_bInputControlTextFilterActive)
				{
					_bInputControlTextFilterActive = true;
					UpdateInputControlColorAndClearButton();
				}
				c = char.ToLower(c);
			}
			return c;
		}

		private void ApplyInputFilterTextChange()
		{
			_bInputControlTextFilterActive = true;
			SetTextFilterText(_settings._inputControlTextFilter.text.ToLower());
			UpdateInputControlColorAndClearButton();
			SetItemsListUpdatePendingTimer(_settings._textFilterUpdateDelaySecs);
		}

		private void SetItemsListUpdatePendingTimer(float duration)
		{
			if (duration > 0f)
			{
				_itemsListUpdatePendingTimer = duration;
			}
			else
			{
				OnItemsListUpdatePendingTimerExpired();
			}
		}

		private void StopItemsListUpdatePendingTimer()
		{
			_itemsListUpdatePendingTimer = 0f;
		}

		private void ProcessItemsListUpdatePendingTimer()
		{
			if (_itemsListUpdatePendingTimer > 0f)
			{
				_itemsListUpdatePendingTimer -= Time.unscaledDeltaTime;
				if (_itemsListUpdatePendingTimer <= 0f)
				{
					OnItemsListUpdatePendingTimerExpired();
				}
			}
		}

		private void OnItemsListUpdatePendingTimerExpired()
		{
			StopItemsListUpdatePendingTimer();
			if (_textFilterTextLive != _textFilterText)
			{
				UpdateItemsList();
			}
		}

		private void UpdateItemsList()
		{
			_itemFilter = null;
			_bundleFilter = null;
			_textFilterTextLive = _textFilterText;
			SetItemList(_activeRoomType, _decorationOnly);
		}

		private void OnClearTextFilterButtonDown()
		{
			if (_enabled)
			{
				_bInputControlTextFilterActive = true;
				ClearTextFilterText();
				SetInputControlTextFilterText(string.Empty);
				StopItemsListUpdatePendingTimer();
				UpdateItemsList();
				ExitCursorModesOnSelectTextInput();
				_settings._inputControlTextFilter.Select();
				_settings._inputControlTextFilter.ActivateInputField();
			}
		}

		private void OnInputControlTextFilterSelect(string str)
		{
			if (_enabled)
			{
				ExitCursorModesOnSelectTextInput();
			}
		}

		private void OnInputControlTextFilterDeselect(string str)
		{
			_ = _enabled;
		}

		private void ExitCursorModesOnSelectTextInput()
		{
			TrySetSelectedRow(null);
			_level.CursorManager.PopMode<CursorRoomItem>();
			_level.CursorManager.PopMode<CursorRoomMove>();
		}
	}
}
