using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.EventUnlockItem;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RibbonMenuRoomsState : MustCallDestroy, Interface, IGameEventCallback
	{
		[Serializable]
		public class Settings
		{
			public GameObject RibbonRoomRowPrefab;

			public GameObject RibbonFilterRowPrefab;

			public RoomFilterDatabase RoomFilterDatabase;

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

			[Header("Ribbon Body")]
			public RibbonMenuBodyAnimator.Target BodyAnimatorTarget;

			public int BodyBackgroundWidth;

			public int BodyScrollViewWidth;

			public int BodyHeight;

			public GameObject[] BodyGameObjects;
		}

		private readonly List<RibbonRoomRow> _rows = new List<RibbonRoomRow>(64);

		private readonly List<RoomDefinition> _rooms = new List<RoomDefinition>(64);

		private readonly List<RoomTemplate> _roomTemplates = new List<RoomTemplate>();

		private readonly Settings _settings;

		private readonly Level _level;

		private readonly IRibbonMenuView _ribbonMenuView;

		private bool _showFilters;

		private bool _enabled;

		private bool _templatesEnabled;

		private RibbonRoomRow _currentSelectedRow;

		private float _itemsListUpdatePendingTimer;

		private bool _bInputControlTextFilterCallbacksDisabled;

		private bool _bInputControlTextFilterActive;

		private string _textFilterTextLive;

		private string _textFilterText;

		private RoomFilter _roomFilter;

		private RoomDefinition _tutorialRoom;

		public bool Enabled => _enabled;

		public bool TemplatesEnabled => _templatesEnabled;

		public RibbonMenuRoomsState(Level level, IRibbonMenuView ribbonMenuView, Settings settings)
		{
			_settings = settings;
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
			_level = level;
			_ribbonMenuView = ribbonMenuView;
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Combine(buildEvents.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomCancelled = (Action<Room, int>)Delegate.Combine(buildEvents2.OnRoomCancelled, new Action<Room, int>(OnRoomCancelled));
			_level.Metagame.OnItemUnlocked.Add(this);
			_settings.FilterButton.onPrimaryDown.AddListener(OnFilterButtonDown);
			_settings.FilterButton.onSecondaryDown.AddListener(OnFilterButtonSecondaryDown);
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
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Remove(buildEvents.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomCancelled = (Action<Room, int>)Delegate.Remove(buildEvents2.OnRoomCancelled, new Action<Room, int>(OnRoomCancelled));
			_level.Metagame.OnItemUnlocked.Remove(this);
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
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

		public void TransitionInto()
		{
			if (!_enabled)
			{
				TransitionIntoRoomsList();
				_enabled = true;
			}
		}

		private void TransitionIntoRoomsList()
		{
			_ribbonMenuView.TransitionBody(ref _settings.BodyAnimatorTarget, _settings.BodyGameObjects);
			_currentSelectedRow = null;
			_ribbonMenuView.SetStaffTypeButtonsActive(active: false);
			_ribbonMenuView.SetTableHeadersActive(active: false);
			_ribbonMenuView.SetTableRowFilter(null);
			_ribbonMenuView.SetTableColumnHeaders(_settings.TableHeader);
			_ribbonMenuView.SetTableColumnDefinitions(_settings.ColumnDefinitions);
			_ribbonMenuView.SetTableRowHeight(_settings.RowHeight);
			_ribbonMenuView.SetTableDirtyLayout();
			_ribbonMenuView.SetToggleGridButtonActive(active: false);
			_settings.CurrentFilterNameLocalize.gameObject.SetActive(value: false);
			_settings._inputControlTextFilter.gameObject.SetActive(value: true);
			_settings.ClearTextFilterButton.gameObject.SetActive(value: false);
			_roomFilter = null;
			ClearTextFilterText();
			SetRoomsList();
			_ribbonMenuView.ResetScrollVerticalPosition();
			UpdateInputControlColorAndClearButton();
		}

		public void TransitionOut()
		{
			if (_enabled)
			{
				_currentSelectedRow = null;
				_rows.Clear();
				_rooms.Clear();
				_roomTemplates.Clear();
				_settings._inputControlTextFilter.gameObject.SetActive(value: false);
				_settings.ClearTextFilterButton.gameObject.SetActive(value: false);
				_ribbonMenuView.DestroyAllListItems();
				_enabled = false;
				if (_templatesEnabled)
				{
					TransitionOutTemplates();
				}
			}
		}

		public void TransitionIntoTemplates()
		{
			if (!_templatesEnabled)
			{
				_currentSelectedRow = null;
				_ribbonMenuView.SetStaffTypeButtonsActive(active: false);
				_ribbonMenuView.SetTableHeadersActive(active: false);
				_ribbonMenuView.SetTableRowFilter(null);
				_ribbonMenuView.SetTableColumnHeaders(_settings.TableHeader);
				_ribbonMenuView.SetTableColumnDefinitions(_settings.ColumnDefinitions);
				_ribbonMenuView.SetTableRowHeight(_settings.RowHeight);
				_ribbonMenuView.SetTableDirtyLayout();
				_ribbonMenuView.SetToggleGridButtonActive(active: false);
				_settings.CurrentFilterNameLocalize.gameObject.SetActive(value: false);
				_settings._inputControlTextFilter.gameObject.SetActive(value: true);
				_settings.ClearTextFilterButton.gameObject.SetActive(value: false);
				_roomFilter = null;
				ClearTextFilterText();
				SetRoomTemplatesList();
				_ribbonMenuView.ResetScrollVerticalPosition();
				UpdateInputControlColorAndClearButton();
				_templatesEnabled = true;
				RibbonMenu ribbonMenu = _ribbonMenuView as RibbonMenu;
				if (ribbonMenu != null)
				{
					ribbonMenu.RefreshHeaderText();
				}
			}
		}

		public void TransitionOutTemplates()
		{
			if (_templatesEnabled)
			{
				_currentSelectedRow = null;
				_roomTemplates.Clear();
				_ribbonMenuView.DestroyAllListItems();
				_templatesEnabled = false;
				TransitionIntoRoomsList();
				RibbonMenu ribbonMenu = _ribbonMenuView as RibbonMenu;
				if (ribbonMenu != null)
				{
					ribbonMenu.RefreshHeaderText();
				}
			}
		}

		public void ToggleTemplatesList()
		{
			if (!_templatesEnabled)
			{
				TransitionIntoTemplates();
			}
			else
			{
				TransitionOutTemplates();
			}
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
			_ribbonMenuView.EnableTable();
			_ribbonMenuView.SetTableRowFilter(null);
			_settings.FilterButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
			_showFilters = true;
			_ribbonMenuView.SetTableRowHeight(_settings.FilterRowHeight);
			SetInputControlTextFilterText(string.Empty);
			ClearTextFilterText();
			StopItemsListUpdatePendingTimer();
			_ribbonMenuView.DestroyAllListItems();
			List<RoomDefinition> availableRooms = _level.WorldState.AvailableRooms;
			RoomFilter[] filters = _settings.RoomFilterDatabase.Filters;
			int[] array = new int[filters.Length];
			if (_templatesEnabled)
			{
				foreach (RoomTemplate roomTemplate in _roomTemplates)
				{
					if (roomTemplate == null || roomTemplate.TemplateFloorPlan.Definition.Filters == null || roomTemplate.TemplateFloorPlan.Definition.IsHospitalOrBay)
					{
						continue;
					}
					for (int i = 0; i < array.Length; i++)
					{
						for (int j = 0; j < roomTemplate.TemplateFloorPlan.Definition.Filters.Length; j++)
						{
							if (roomTemplate.TemplateFloorPlan.Definition.Filters[j] == filters[i])
							{
								array[i]++;
							}
						}
					}
				}
			}
			else
			{
				foreach (RoomDefinition item in availableRooms)
				{
					if (item.Filters == null || item.IsHospitalOrBay)
					{
						continue;
					}
					for (int k = 0; k < array.Length; k++)
					{
						for (int l = 0; l < item.Filters.Length; l++)
						{
							if (item.Filters[l] == filters[k])
							{
								array[k]++;
							}
						}
					}
				}
			}
			RibbonFilterRow component = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonFilterRowPrefab).GetComponent<RibbonFilterRow>();
			component.FilterNameLocalize.Term = _settings.AllFilterName.Term;
			if (_templatesEnabled)
			{
				component.CountText.text = _roomTemplates.Count.ToString("0");
			}
			else
			{
				component.CountText.text = availableRooms.Count.ToString("0");
			}
			component.Button.onPrimaryDown.AddListener(delegate
			{
				_roomFilter = null;
				ClearTextFilterText();
				if (_templatesEnabled)
				{
					SetRoomTemplatesList();
				}
				else
				{
					SetRoomsList();
				}
			});
			for (int num = 0; num < filters.Length; num++)
			{
				RoomFilter filter = filters[num];
				RibbonFilterRow component2 = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonFilterRowPrefab).GetComponent<RibbonFilterRow>();
				component2.FilterNameLocalize.Term = filter.LocalisedName.Term;
				component2.CountText.text = array[num].ToString("0");
				component2.Button.onPrimaryDown.AddListener(delegate
				{
					_roomFilter = filter;
					ClearTextFilterText();
					if (_templatesEnabled)
					{
						SetRoomTemplatesList();
					}
					else
					{
						SetRoomsList();
					}
				});
			}
			_ribbonMenuView.ResetScrollVerticalPosition();
		}

		private void SetRoomsList()
		{
			_ribbonMenuView.EnableTable();
			_ribbonMenuView.SetTableRowFilter((RectTransform rect) => FilterRow(rect.GetComponent<RibbonRoomRow>()));
			if (_textFilterTextLive.IsNullOrEmpty())
			{
				if (_roomFilter == null)
				{
					SetTemporaryInputControlTextFilterText(string.Empty);
				}
				else
				{
					SetTemporaryInputControlTextFilterText(_roomFilter.LocalisedName.Translation);
				}
			}
			_settings.FilterButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
			_showFilters = false;
			_ribbonMenuView.SetTableRowHeight(_settings.RowHeight);
			_ribbonMenuView.DestroyAllListItems();
			_rooms.Clear();
			foreach (RoomDefinition availableRoom in _level.WorldState.AvailableRooms)
			{
				if (!availableRoom.IsHospitalOrBay)
				{
					_rooms.Add(availableRoom);
				}
			}
			_rooms.Sort(delegate(RoomDefinition definition1, RoomDefinition definition2)
			{
				int itemOrder = GetItemOrder(_level.WorldState, _level.Metagame, definition1);
				int itemOrder2 = GetItemOrder(_level.WorldState, _level.Metagame, definition2);
				return itemOrder.CompareTo(itemOrder2);
			});
			_rows.Clear();
			foreach (RoomDefinition room in _rooms)
			{
				AddRoomRow(room);
			}
		}

		private void SetRoomTemplatesList()
		{
			_ribbonMenuView.EnableTable();
			_ribbonMenuView.SetTableRowFilter((RectTransform rect) => FilterRow(rect.GetComponent<RibbonRoomRow>()));
			if (_textFilterTextLive.IsNullOrEmpty())
			{
				if (_roomFilter == null)
				{
					SetTemporaryInputControlTextFilterText(string.Empty);
				}
				else
				{
					SetTemporaryInputControlTextFilterText(_roomFilter.LocalisedName.Translation);
				}
			}
			_settings.FilterButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
			_showFilters = false;
			_ribbonMenuView.SetTableRowHeight(_settings.RowHeight);
			_ribbonMenuView.DestroyAllListItems();
			_rooms.Clear();
			foreach (RoomDefinition availableRoom in _level.WorldState.AvailableRooms)
			{
				if (!availableRoom.IsHospitalOrBay)
				{
					_rooms.Add(availableRoom);
				}
			}
			_rooms.Sort(delegate(RoomDefinition definition1, RoomDefinition definition2)
			{
				int itemOrder = GetItemOrder(_level.WorldState, _level.Metagame, definition1);
				int itemOrder2 = GetItemOrder(_level.WorldState, _level.Metagame, definition2);
				return itemOrder.CompareTo(itemOrder2);
			});
			_rows.Clear();
			_roomTemplates.Clear();
			foreach (RoomDefinition room in _rooms)
			{
				foreach (RoomTemplate item in _level.App.RoomTemplatesManager.GetTemplatesForRoom(room._type))
				{
					_roomTemplates.Add(item);
				}
			}
			foreach (RoomTemplate roomTemplate in _roomTemplates)
			{
				if (roomTemplate != null)
				{
					AddRoomTemplateRow(roomTemplate);
				}
			}
		}

		private void AddRoomTemplateRow(RoomTemplate template)
		{
			GameObject gameObject = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonRoomRowPrefab);
			RibbonRoomRow ribbonRoomRow = gameObject.GetComponent<RibbonRoomRow>();
			ribbonRoomRow.Setup(template.TemplateFloorPlan.Definition, _level.Metagame, _level.GameplayStatsTracker, template);
			ribbonRoomRow.IsRequired = false;
			ribbonRoomRow.Button.onPrimaryDown.AddListener(delegate
			{
				SelectItem(ribbonRoomRow);
			});
			ribbonRoomRow.Affordable = _level.FinanceManager.Balance >= ribbonRoomRow.RoomDefinition.GetCostWithRequiredItems();
			RefreshRowMode(ribbonRoomRow);
			_rows.Add(ribbonRoomRow);
		}

		private void AddRoomRow(RoomDefinition room)
		{
			GameObject gameObject = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonRoomRowPrefab);
			RibbonRoomRow ribbonRoomRow = gameObject.GetComponent<RibbonRoomRow>();
			ribbonRoomRow.Setup(room, _level.Metagame, _level.GameplayStatsTracker);
			ribbonRoomRow.IsRequired = false;
			ribbonRoomRow.Button.onPrimaryDown.AddListener(delegate
			{
				SelectItem(ribbonRoomRow);
			});
			ribbonRoomRow.Affordable = _level.FinanceManager.Balance >= ribbonRoomRow.RoomDefinition.GetCostWithRequiredItems();
			RefreshRowMode(ribbonRoomRow);
			_rows.Add(ribbonRoomRow);
		}

		private void SelectItem(RibbonRoomRow ribbonRoomRow)
		{
			switch (ribbonRoomRow.CurrentMode)
			{
			case RibbonRoomRow.Mode.Available:
			case RibbonRoomRow.Mode.ContainsInvalidItems:
				if (_templatesEnabled)
				{
					_level.BuildingLogic.TransitionToCopyRoomTemplateBlueprintState(ribbonRoomRow.RoomTemplate);
					break;
				}
				_level.BuildingLogic.TransitionToNewRoomState(ribbonRoomRow.RoomDefinition);
				_ribbonMenuView.PlaySelectItemSFX();
				break;
			case RibbonRoomRow.Mode.Locked:
				_ribbonMenuView.PlayFailUnlockingItemSFX();
				break;
			case RibbonRoomRow.Mode.LockedAffordable:
				ShowUnlockItemMessage(ribbonRoomRow.RoomDefinition);
				break;
			case RibbonRoomRow.Mode.Inactive:
				_ribbonMenuView.PlaySelectInactiveItemSFX();
				break;
			case RibbonRoomRow.Mode.Selected:
				break;
			}
		}

		private void ShowUnlockItemMessage(RoomDefinition room)
		{
			NotificationDynamicMessage unlockMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions._unlockSilverMessage.Instance, delegate(int response)
			{
				if (response == 0)
				{
					_level.Metagame.UnlockItem(room, spendSilver: true, showMessage: false);
					_ribbonMenuView.PlayUnlockItemSFX();
				}
			}, _level);
			NotificationDynamicMessage notificationDynamicMessage = unlockMessage;
			notificationDynamicMessage.FuncGetMessage = (Func<string>)Delegate.Combine(notificationDynamicMessage.FuncGetMessage, (Func<string>)(() => LocalisedString.Replace(unlockMessage.Definition.LocalisedText.Translation, new SubPair[4]
			{
				new SubPair("{[ITEM]}", room.GetLocalisedName()),
				new SubPair("{[SILVER]}", StringUtils.FormatSilverCurrency(room.SilverCost())),
				new SubPair("{[BALANCE]}", StringUtils.FormatSilverCurrency(_level.Metagame.TotalSilver())),
				new SubPair("{[COST]}", StringUtils.FormatCurrency(room.GetCostWithRequiredItems()))
			})));
			_level.Notifications.Send(unlockMessage);
		}

		private int GetItemOrder(WorldState worldState, Metagame metagame, RoomDefinition definition)
		{
			int num = worldState.AvailableRooms.IndexOf(definition);
			if (!metagame.HasUnlocked(definition))
			{
				return 10000 + num;
			}
			return num;
		}

		private void RefreshRowMode(RibbonRoomRow ribbonRoomRow)
		{
			if (ribbonRoomRow == null)
			{
				return;
			}
			if (!_level.Metagame.HasUnlocked(ribbonRoomRow.RoomDefinition))
			{
				ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.Locked;
				ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.LockedRoom;
				return;
			}
			if (ribbonRoomRow.RoomTemplate != null)
			{
				bool flag = false;
				foreach (uint usedDLCAppID in ribbonRoomRow.RoomTemplate.UsedDLCAppIDs)
				{
					if (!DLCUtils.IsDLCInstalled(usedDLCAppID))
					{
						flag = true;
						ribbonRoomRow.MissingDLC.AddUnique(usedDLCAppID);
					}
				}
				if (flag)
				{
					ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.ContainsInvalidItems;
					ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.MissingDLC;
				}
				bool flag2 = false;
				if (ribbonRoomRow.RoomTemplate.FloorVisualOverride != null && ribbonRoomRow.RoomTemplate.FloorVisualOverride is FloorVisualOverrideDefinitionUGC && _level.App.ExtContentManager.FindGameItemByContentID(((FloorVisualOverrideDefinitionUGC)ribbonRoomRow.RoomTemplate.FloorVisualOverride).GetContentID().ToString()) == null)
				{
					flag2 = true;
				}
				if (ribbonRoomRow.RoomTemplate.WallVisualOverride != null && ribbonRoomRow.RoomTemplate.WallVisualOverride is WallVisualOverrideDefinitionUGC && _level.App.ExtContentManager.FindGameItemByContentID(((WallVisualOverrideDefinitionUGC)ribbonRoomRow.RoomTemplate.WallVisualOverride).GetContentID()) == null)
				{
					flag2 = true;
				}
				if (!flag2)
				{
					foreach (RoomItemDefinitionUGC uGCItem in ribbonRoomRow.RoomTemplate.UGCItems)
					{
						if (_level.App.ExtContentManager.FindGameItemByContentID(uGCItem.ContentID) == null)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.ContainsInvalidItems;
					ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.MissingUGC;
				}
				bool flag3 = false;
				if (ribbonRoomRow.RoomTemplate.FloorVisualOverride != null && !_level.Metagame.HasUnlocked(ribbonRoomRow.RoomTemplate.FloorVisualOverride))
				{
					ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.ContainsInvalidItems;
					ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.LockedItems;
					ribbonRoomRow.RoomTemplate.DisableFloorVisualOverride = true;
					flag3 = true;
				}
				else
				{
					ribbonRoomRow.RoomTemplate.DisableFloorVisualOverride = false;
				}
				if (ribbonRoomRow.RoomTemplate.WallVisualOverride != null && !_level.Metagame.HasUnlocked(ribbonRoomRow.RoomTemplate.WallVisualOverride))
				{
					ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.ContainsInvalidItems;
					ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.LockedItems;
					ribbonRoomRow.RoomTemplate.DisableWallVisualOverride = true;
					flag3 = true;
				}
				else
				{
					ribbonRoomRow.RoomTemplate.DisableWallVisualOverride = false;
				}
				ribbonRoomRow.RoomTemplate.TemplateFloorPlan.InLevelItemsToRemove.Clear();
				foreach (RoomTemplateItem item in ribbonRoomRow.RoomTemplate.TemplateFloorPlan.Items)
				{
					if (item.Definition == null)
					{
						continue;
					}
					RoomItemDefinition instance = item.Definition.Instance;
					if (!_level.Metagame.HasUnlocked(instance))
					{
						ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.ContainsInvalidItems;
						ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.LockedItems;
						flag3 = true;
						ribbonRoomRow.RoomTemplate.TemplateFloorPlan.InLevelItemsToRemove.AddUnique(item);
						continue;
					}
					bool num = _level.Metagame.IsBlacklisted(instance);
					bool flag4 = _level.Metagame.IsWhitelisted(instance);
					if (num || !flag4)
					{
						ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.ContainsInvalidItems;
						ribbonRoomRow.InvalidReason |= RibbonRoomRow.TemplateInvalidReason.BannedItems;
						flag3 = true;
						ribbonRoomRow.RoomTemplate.TemplateFloorPlan.InLevelItemsToRemove.AddUnique(item);
					}
				}
				if (flag3 || flag || flag2)
				{
					return;
				}
				ribbonRoomRow.InvalidReason = RibbonRoomRow.TemplateInvalidReason.None;
			}
			if (_currentSelectedRow == ribbonRoomRow)
			{
				ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.Selected;
			}
			else
			{
				ribbonRoomRow.CurrentMode = RibbonRoomRow.Mode.Available;
			}
		}

		private void SetSelectedRow(RibbonRoomRow row)
		{
			RibbonRoomRow currentSelectedRow = _currentSelectedRow;
			_currentSelectedRow = row;
			RefreshRowMode(currentSelectedRow);
			RefreshRowMode(_currentSelectedRow);
		}

		public void ShowTutorialItemOnly(RoomDefinition roomItem)
		{
			if (_tutorialRoom != roomItem)
			{
				_tutorialRoom = roomItem;
				if (Enabled && !_showFilters)
				{
					SetRoomsList();
				}
			}
		}

		private void OnFilterButtonDown()
		{
			if (!_enabled)
			{
				return;
			}
			if (_showFilters)
			{
				if (_templatesEnabled)
				{
					SetRoomTemplatesList();
				}
				else
				{
					SetRoomsList();
				}
			}
			else
			{
				SetFiltersList();
			}
			ExitCursorModesOnSelectTextInput();
		}

		private void OnFilterButtonSecondaryDown()
		{
			if (_enabled)
			{
				_roomFilter = null;
				ClearTextFilterText();
				if (_templatesEnabled)
				{
					SetRoomTemplatesList();
				}
				else
				{
					SetRoomsList();
				}
				ExitCursorModesOnSelectTextInput();
			}
		}

		private void OnBeginNewRoom(RoomDefinition roomDefinition)
		{
			if (_enabled)
			{
				RibbonRoomRow selectedRow = FindRow(roomDefinition);
				SetSelectedRow(selectedRow);
			}
		}

		private void OnRoomCancelled(Room room, int cost)
		{
			if (_enabled)
			{
				SetSelectedRow(null);
			}
		}

		void Interface.OnItemUnlockedEvent(ISilverUnlockable item)
		{
			if (_enabled && item is RoomDefinition roomDefinition)
			{
				RibbonRoomRow ribbonRoomRow = FindRow(roomDefinition);
				if (ribbonRoomRow != null)
				{
					RefreshRowMode(ribbonRoomRow);
				}
				else
				{
					AddRoomRow(roomDefinition);
				}
			}
		}

		private void OnBalanceUpdated(int balance)
		{
			if (!_enabled)
			{
				return;
			}
			foreach (RibbonRoomRow row in _rows)
			{
				row.Affordable = balance >= row.RoomDefinition.GetCostWithRequiredItems();
			}
		}

		public RibbonRoomRow FindRow(RoomDefinition definition)
		{
			if (definition == null)
			{
				return null;
			}
			foreach (RibbonRoomRow row in _rows)
			{
				if (row.RoomDefinition == definition)
				{
					return row;
				}
			}
			return null;
		}

		private bool FilterRow(RibbonRoomRow row)
		{
			if (row == null)
			{
				return true;
			}
			if (RoomFilter(row.RoomDefinition, row.RoomTemplate))
			{
				return TutorialFilter(row.RoomDefinition);
			}
			return false;
		}

		private bool TutorialFilter(RoomDefinition definition)
		{
			if (_tutorialRoom != null)
			{
				return definition == _tutorialRoom;
			}
			return true;
		}

		private bool RoomFilter(RoomDefinition definition, RoomTemplate template = null)
		{
			if (_bInputControlTextFilterActive)
			{
				bool result = true;
				if (!_textFilterTextLive.IsNullOrEmpty())
				{
					result = ((!_templatesEnabled || template == null) ? definition.GetLocalisedName().ToLower().Contains(_textFilterTextLive, StringComparison.CurrentCulture) : template.UserDefinedName.ToLower().Contains(_textFilterTextLive));
				}
				return result;
			}
			if (_roomFilter == null)
			{
				return true;
			}
			RoomFilter[] filters = definition.Filters;
			if (filters == null)
			{
				return false;
			}
			for (int i = 0; i < filters.Length; i++)
			{
				if (filters[i] == _roomFilter)
				{
					return true;
				}
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
				UpdateRoomsList();
			}
		}

		private void UpdateRoomsList()
		{
			_roomFilter = null;
			_textFilterTextLive = _textFilterText;
			if (_templatesEnabled)
			{
				SetRoomTemplatesList();
			}
			else
			{
				SetRoomsList();
			}
		}

		private void OnClearTextFilterButtonDown()
		{
			if (_enabled)
			{
				_bInputControlTextFilterActive = true;
				ClearTextFilterText();
				SetInputControlTextFilterText(string.Empty);
				StopItemsListUpdatePendingTimer();
				UpdateRoomsList();
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
			SetSelectedRow(null);
			_level.CursorManager.PopMode<CursorRoomItem>();
			_level.CursorManager.PopMode<CursorRoomMove>();
			_level.CursorManager.PopMode<CursorRoomBuild>();
			if (_level.BuildingLogic.CurrentState == BuildingLogic.State.EditRoomBlueprint || _level.BuildingLogic.CurrentState == BuildingLogic.State.NewRoom)
			{
				_level.BuildingLogic.TransitionToNullState(applyChanges: false);
			}
		}
	}
}
