using System;
using System.Collections.Generic;
using TH20.EventAwardSilver;
using TH20.ExtContent;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[DontSave]
	public class RoomCustomisationMenu : AnimatedMenuBase, Interface, IGameEventCallback
	{
		private enum Mode
		{
			InternalFloor = 0,
			InternalWall = 1
		}

		private Level _level;

		private Table _table;

		private Room _inspectedRoom;

		private Mode _currentMode;

		private bool _bAllowUGCButtonFunctions = true;

		private IFloorVisualOverrideDefinition _currentFloorCustomisationOption;

		private IWallVisualOverrideDefinition _currentWallCustomisationOption;

		private List<RoomCustomisationRow> _rows = new List<RoomCustomisationRow>(32);

		[SerializeField]
		private RoomCustomisationMenuData _data;

		public Room InspectedRoom
		{
			get
			{
				return _inspectedRoom;
			}
			set
			{
				if (_inspectedRoom == value)
				{
					return;
				}
				_inspectedRoom = value;
				if (_inspectedRoom != null)
				{
					_data.RoomNameText.text = _inspectedRoom.GetRoomName();
					RebuildRows();
					RefreshRowsMode();
					if (_inspectedRoom.Definition.IsLowWallRoom() && _currentMode == Mode.InternalWall)
					{
						SetMode(Mode.InternalFloor);
					}
					RefreshModeButtons();
				}
				else
				{
					_data.RoomNameText.text = null;
					_rows.Clear();
					_currentFloorCustomisationOption = null;
					_currentWallCustomisationOption = null;
					foreach (Transform row in _table.Rows)
					{
						UnityEngine.Object.Destroy(row.gameObject);
					}
					_data.FloorButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
					_data.WallButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				}
				RefreshApplyAllButton();
			}
		}

		public void Initialise(Level level)
		{
			_level = level;
			_level.InputManager.AddGraphicRayCaster(_data.GraphicRaycaster);
			_table = _data.Table;
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpenRoom = (Action<InspectorMenu, Room>)Delegate.Combine(hUDEvents.OnInspectorOpenRoom, new Action<InspectorMenu, Room>(OnInspectorOpenRoom));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			_level.Metagame.OnSilverAwarded.Add(this);
			RegisterWorkshopCallbacks(bRegister: true);
			if (_data.CloseButton != null)
			{
				_data.CloseButton.onPrimaryDown.AddListener(CloseMenu);
			}
			if (_data.ApplyToAllButton != null)
			{
				_data.ApplyToAllButton.onPrimaryDown.AddListener(ApplyToAllRoomType);
			}
			_data.WallButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
			_data.FloorButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
			_data.WallButton.onPrimaryDown.AddListener(delegate
			{
				SetMode(Mode.InternalWall);
			});
			_data.FloorButton.onPrimaryDown.AddListener(delegate
			{
				SetMode(Mode.InternalFloor);
			});
			_data.LeftCycleButton.onClick.AddListener(delegate
			{
				SelectNextRoom(-1);
			});
			_data.RightCycleButton.onClick.AddListener(delegate
			{
				SelectNextRoom(1);
			});
			_data.UGCButton.onPrimaryDown.AddListener(delegate
			{
				OnUGCButtonClick();
			});
			SetMode(Mode.InternalWall);
		}

		public void Setup()
		{
		}

		private void SetMode(Mode mode)
		{
			if (_currentMode != mode)
			{
				_currentMode = mode;
				RefreshModeButtons();
				RebuildRows();
				RefreshRowsMode();
				RefreshApplyAllButton();
			}
		}

		private void RefreshModeButtons()
		{
			switch (_currentMode)
			{
			case Mode.InternalFloor:
				_data.WallButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_data.FloorButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				break;
			case Mode.InternalWall:
				_data.WallButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				_data.FloorButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				break;
			}
			if (_inspectedRoom != null && _inspectedRoom.Definition.IsLowWallRoom())
			{
				_data.WallButtonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
			}
		}

		private void SelectNextRoom(int direction)
		{
			if (_inspectedRoom != null)
			{
				SelectNextRoomOfType(direction);
			}
		}

		private void SelectNextRoomOfType(int direction)
		{
			List<Room> list = new List<Room>(_level.WorldState.AllRooms);
			list.Sort((Room a, Room b) => a.Definition._type.CompareTo(b.Definition._type));
			list.RemoveAll((Room x) => x.Definition.IsHospitalUnbuilt || x.Definition.IsHospitalOrBay);
			if (list.Count != 0)
			{
				int num;
				if (_inspectedRoom != null)
				{
					num = list.IndexOf(_inspectedRoom);
					num = (num + direction) % list.Count;
					num = (list.Count + num) % list.Count;
				}
				else
				{
					num = 0;
				}
				_level.BuildEvents.OnCursorSelectObject.InvokeSafe(list[num]);
			}
		}

		private void SelectRow(RoomCustomisationRow row)
		{
			if (_inspectedRoom == null)
			{
				RefreshRowsMode();
				return;
			}
			if (row.FloorOption is FloorVisualOverrideDefinitionUGC)
			{
				((FloorVisualOverrideDefinitionUGC)row.FloorOption).RestoreFromSave(_level.App.UGCFloorVisualOverrideDefinitionDatabase);
			}
			if (row.WallOption is WallVisualOverrideDefinitionUGC)
			{
				((WallVisualOverrideDefinitionUGC)row.WallOption).RestoreFromSave(_level.App.UGCWallVisualOverrideDefinitionDatabase);
			}
			switch (_currentMode)
			{
			case Mode.InternalFloor:
				if (row.FloorOption != null && !_level.Metagame.HasUnlocked(row.FloorOption))
				{
					if (_level.Metagame.CanAffordSilver(row.FloorOption))
					{
						ShowUnlockItemMessage(row);
					}
					return;
				}
				if (row.FloorOption == null)
				{
					_inspectedRoom.FloorPlanVisual.FloorVisualOverride = null;
					RefreshRowsMode();
					RefreshApplyAllButton();
					return;
				}
				_inspectedRoom.FloorPlanVisual.FloorVisualOverride = row.FloorOption;
				break;
			case Mode.InternalWall:
				if (row.WallOption != null && !_level.Metagame.HasUnlocked(row.WallOption))
				{
					if (_level.Metagame.CanAffordSilver(row.WallOption))
					{
						ShowUnlockItemMessage(row);
					}
					return;
				}
				if (row.WallOption == null)
				{
					_inspectedRoom.FloorPlanVisual.WallVisualOverride = null;
					RefreshRowsMode();
					RefreshApplyAllButton();
					return;
				}
				_inspectedRoom.FloorPlanVisual.WallVisualOverride = row.WallOption;
				break;
			}
			RefreshRowsMode();
			RefreshApplyAllButton();
		}

		private void ShowUnlockItemMessage(RoomCustomisationRow row)
		{
			ISilverUnlockable silverUnlockable;
			string unlockableName;
			switch (_currentMode)
			{
			case Mode.InternalFloor:
				silverUnlockable = row.FloorOption;
				unlockableName = row.FloorOption.Name;
				break;
			case Mode.InternalWall:
				silverUnlockable = row.WallOption;
				unlockableName = row.WallOption.Name;
				break;
			default:
				silverUnlockable = null;
				unlockableName = string.Empty;
				break;
			}
			NotificationDynamicMessage unlockMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions.UnlockRoomCustomisationSilverMessage.Instance, delegate(int response)
			{
				if (response == 0)
				{
					_level.Metagame.UnlockItem(silverUnlockable, spendSilver: true, showMessage: false);
					SelectRow(row);
					RefreshRowsMode();
				}
			}, _level);
			NotificationDynamicMessage notificationDynamicMessage = unlockMessage;
			notificationDynamicMessage.FuncGetMessage = (Func<string>)Delegate.Combine(notificationDynamicMessage.FuncGetMessage, (Func<string>)(() => LocalisedString.Replace(unlockMessage.Definition.LocalisedText.Translation, new SubPair[3]
			{
				new SubPair("{[ITEM]}", unlockableName),
				new SubPair("{[SILVER]}", StringUtils.FormatSilverCurrency(silverUnlockable.SilverCost())),
				new SubPair("{[BALANCE]}", StringUtils.FormatSilverCurrency(_level.Metagame.TotalSilver()))
			})));
			_level.Notifications.Send(unlockMessage);
		}

		private void RefreshApplyAllButton()
		{
			if (_inspectedRoom == null)
			{
				_data.ApplyToAllButton.gameObject.SetActive(value: false);
				return;
			}
			_data.ApplyToAllButton.gameObject.SetActive(value: true);
			List<Room> list = new List<Room>();
			_level.WorldState.GetRoomsOfType(InspectedRoom.Definition._type, includeClosed: true, list);
			bool flag = true;
			switch (_currentMode)
			{
			case Mode.InternalFloor:
			{
				_level.RoomCustomisations.GetDefaultFloorVisualOverride(_inspectedRoom.Definition._type, out var definition2);
				if (_currentFloorCustomisationOption != definition2)
				{
					flag = false;
					break;
				}
				foreach (Room item in list)
				{
					bool flag3 = _currentFloorCustomisationOption == item.FloorPlanVisual.FloorVisualOverride;
					if (_currentFloorCustomisationOption != null)
					{
						flag3 = flag3 || _currentFloorCustomisationOption.Equals(item.FloorPlanVisual.FloorVisualOverride);
					}
					if (!flag3)
					{
						flag = false;
						break;
					}
				}
				break;
			}
			case Mode.InternalWall:
			{
				_level.RoomCustomisations.GetDefaultWallVisualOverride(_inspectedRoom.Definition._type, out var definition);
				if (_currentWallCustomisationOption != definition)
				{
					flag = false;
					break;
				}
				foreach (Room item2 in list)
				{
					bool flag2 = _currentWallCustomisationOption == item2.FloorPlanVisual.WallVisualOverride;
					if (_currentWallCustomisationOption != null)
					{
						flag2 = flag2 || _currentWallCustomisationOption.Equals(item2.FloorPlanVisual.WallVisualOverride);
					}
					if (!flag2)
					{
						flag = false;
						break;
					}
				}
				break;
			}
			}
			_data.ApplyToAllButtonAnimator.CurrentState = (flag ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
		}

		private void RefreshRowsMode()
		{
			foreach (RoomCustomisationRow row in _rows)
			{
				if (_inspectedRoom == null)
				{
					continue;
				}
				switch (_currentMode)
				{
				case Mode.InternalFloor:
				{
					IFloorVisualOverrideDefinition floorVisualOverride = _inspectedRoom.FloorPlanVisual.FloorVisualOverride;
					IFloorVisualOverrideDefinition floorOption = row.FloorOption;
					bool num2 = floorOption != null && !_level.Metagame.HasUnlocked(floorOption);
					bool flag2 = floorVisualOverride == floorOption;
					if (floorVisualOverride != null)
					{
						flag2 = flag2 || floorVisualOverride.Equals(floorOption);
					}
					if (num2)
					{
						if (_level.Metagame.CanAffordSilver(floorOption))
						{
							row.CurrentMode = RoomCustomisationRow.Mode.LockedAffordable;
						}
						else
						{
							row.CurrentMode = RoomCustomisationRow.Mode.LockedUnaffordable;
						}
					}
					else if (flag2)
					{
						row.CurrentMode = RoomCustomisationRow.Mode.Selected;
						_currentFloorCustomisationOption = row.FloorOption;
						_currentWallCustomisationOption = null;
					}
					else
					{
						row.CurrentMode = RoomCustomisationRow.Mode.Available;
					}
					break;
				}
				case Mode.InternalWall:
				{
					IWallVisualOverrideDefinition wallVisualOverride = _inspectedRoom.FloorPlanVisual.WallVisualOverride;
					IWallVisualOverrideDefinition wallOption = row.WallOption;
					bool num = wallOption != null && !_level.Metagame.HasUnlocked(wallOption);
					bool flag = wallVisualOverride == wallOption;
					if (wallVisualOverride != null)
					{
						flag = flag || wallVisualOverride.Equals(wallOption);
					}
					if (num)
					{
						if (_level.Metagame.CanAffordSilver(wallOption))
						{
							row.CurrentMode = RoomCustomisationRow.Mode.LockedAffordable;
						}
						else
						{
							row.CurrentMode = RoomCustomisationRow.Mode.LockedUnaffordable;
						}
					}
					else if (flag)
					{
						row.CurrentMode = RoomCustomisationRow.Mode.Selected;
						_currentFloorCustomisationOption = null;
						_currentWallCustomisationOption = row.WallOption;
					}
					else
					{
						row.CurrentMode = RoomCustomisationRow.Mode.Available;
					}
					break;
				}
				}
			}
		}

		private void RebuildRows()
		{
			foreach (Transform row2 in _table.Rows)
			{
				UnityEngine.Object.Destroy(row2.gameObject);
			}
			_rows.Clear();
			GameObject gameObject = _table.InstantiateAsRow(_data.RowPrefab);
			RoomCustomisationRow row = gameObject.GetComponent<RoomCustomisationRow>();
			Sprite icon = _currentMode switch
			{
				Mode.InternalWall => _data.DefaultWallIcon, 
				Mode.InternalFloor => _data.DefaultFloorIcon, 
				_ => null, 
			};
			row.SetupDefault(_data.DefaultRowName, icon);
			row.Button.onPrimaryDown.AddListener(delegate
			{
				SelectRow(row);
			});
			_rows.Add(row);
			switch (_currentMode)
			{
			case Mode.InternalFloor:
			{
				List<FloorVisualOverrideDefinitionUGC> floorVisualOverrideDefinitionUGCs = _level.FloorVisualOverrideDefinitionUGCs;
				FloorVisualOverrideDefinition[] floorVisualOverrideDefinitions = _level.Config.GetRoomVisualOverridesDatabase().FloorVisualOverrideDefinitions;
				if (floorVisualOverrideDefinitions != null)
				{
					FloorVisualOverrideDefinition[] array2 = floorVisualOverrideDefinitions;
					foreach (FloorVisualOverrideDefinition floorVisualOverrideDefinition in array2)
					{
						if (_level.Metagame.HasUnlocked(floorVisualOverrideDefinition))
						{
							AddFloorRow(floorVisualOverrideDefinition);
						}
					}
				}
				if (floorVisualOverrideDefinitionUGCs != null)
				{
					foreach (FloorVisualOverrideDefinitionUGC item in floorVisualOverrideDefinitionUGCs)
					{
						if (_level.Metagame.HasUnlocked(item))
						{
							AddFloorRow(item);
						}
					}
				}
				if (floorVisualOverrideDefinitions != null)
				{
					FloorVisualOverrideDefinition[] array2 = floorVisualOverrideDefinitions;
					foreach (FloorVisualOverrideDefinition floorVisualOverrideDefinition2 in array2)
					{
						if (!_level.Metagame.HasUnlocked(floorVisualOverrideDefinition2))
						{
							AddFloorRow(floorVisualOverrideDefinition2);
						}
					}
				}
				if (floorVisualOverrideDefinitionUGCs == null)
				{
					break;
				}
				{
					foreach (FloorVisualOverrideDefinitionUGC item2 in floorVisualOverrideDefinitionUGCs)
					{
						if (!_level.Metagame.HasUnlocked(item2))
						{
							AddFloorRow(item2);
						}
					}
					break;
				}
			}
			case Mode.InternalWall:
			{
				List<WallVisualOverrideDefinitionUGC> wallVisualOverrideDefinitionUGCs = _level.WallVisualOverrideDefinitionUGCs;
				WallVisualOverrideDefinition[] wallVisualOverrideDefinitions = _level.Config.GetRoomVisualOverridesDatabase().WallVisualOverrideDefinitions;
				if (wallVisualOverrideDefinitions != null)
				{
					WallVisualOverrideDefinition[] array = wallVisualOverrideDefinitions;
					foreach (WallVisualOverrideDefinition wallVisualOverrideDefinition in array)
					{
						if (_level.Metagame.HasUnlocked(wallVisualOverrideDefinition))
						{
							AddWallRow(wallVisualOverrideDefinition);
						}
					}
				}
				if (wallVisualOverrideDefinitionUGCs != null)
				{
					foreach (WallVisualOverrideDefinitionUGC item3 in wallVisualOverrideDefinitionUGCs)
					{
						if (_level.Metagame.HasUnlocked(item3))
						{
							AddWallRow(item3);
						}
					}
				}
				if (wallVisualOverrideDefinitions != null)
				{
					WallVisualOverrideDefinition[] array = wallVisualOverrideDefinitions;
					foreach (WallVisualOverrideDefinition wallVisualOverrideDefinition2 in array)
					{
						if (!_level.Metagame.HasUnlocked(wallVisualOverrideDefinition2))
						{
							AddWallRow(wallVisualOverrideDefinition2);
						}
					}
				}
				if (wallVisualOverrideDefinitionUGCs == null)
				{
					break;
				}
				{
					foreach (WallVisualOverrideDefinitionUGC item4 in wallVisualOverrideDefinitionUGCs)
					{
						if (!_level.Metagame.HasUnlocked(item4))
						{
							AddWallRow(item4);
						}
					}
					break;
				}
			}
			}
		}

		private void AddFloorRow(IFloorVisualOverrideDefinition floorOption)
		{
			GameObject gameObject = _table.InstantiateAsRow(_data.RowPrefab);
			RoomCustomisationRow row = gameObject.GetComponent<RoomCustomisationRow>();
			row.SetupFloorOption(floorOption);
			_rows.Add(row);
			row.ButtonExtContent?.onPrimaryDown.AddListener(delegate
			{
				OnRowUGCButton(row);
			});
			row.Button.onPrimaryDown.AddListener(delegate
			{
				SelectRow(row);
			});
		}

		private void AddWallRow(IWallVisualOverrideDefinition wallOption)
		{
			GameObject gameObject = _table.InstantiateAsRow(_data.RowPrefab);
			RoomCustomisationRow row = gameObject.GetComponent<RoomCustomisationRow>();
			row.SetupWallOption(wallOption);
			_rows.Add(row);
			row.ButtonExtContent?.onPrimaryDown.AddListener(delegate
			{
				OnRowUGCButton(row);
			});
			row.Button.onPrimaryDown.AddListener(delegate
			{
				SelectRow(row);
			});
		}

		private void OnInspectorOpenRoom(InspectorMenu menuRef, Room room)
		{
			if (!IsClosed() && !IsClosing())
			{
				InspectedRoom = room;
			}
		}

		private void OnUGCButtonClick()
		{
			if (_bAllowUGCButtonFunctions)
			{
				ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
				_ = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
				EContentType eContentType = EContentType.None;
				switch (_currentMode)
				{
				case Mode.InternalFloor:
					eContentType = EContentType.Floor;
					break;
				case Mode.InternalWall:
					eContentType = EContentType.Wall;
					break;
				}
				List<EContentType> list = new List<EContentType>();
				list.Add(EContentType.Floor);
				list.Add(EContentType.Wall);
				if (eContentType != EContentType.None)
				{
					gameItemUIScreen.Configure(bCreateNewItem: true, bAllowAmendContentType: true, eContentType, list, null);
					RegisterLocalModsCallbacks(bRegister: true);
					gameItemUIScreen.Show();
				}
			}
		}

		private void OnRowUGCButton(RoomCustomisationRow row)
		{
			GameItemBase gameItem = row.GameItem;
			if (!ExtContentUtils.CheckShowGameItemDevInfoPanel(gameItem) && gameItem != null)
			{
				switch (gameItem.ContentSource)
				{
				case EContentSourceType.LocalMods:
				{
					ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
					_ = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
					gameItemUIScreen.Configure(bCreateNewItem: false, bAllowAmendContentType: false, gameItem.ContentType, null, gameItem);
					RegisterLocalModsCallbacks(bRegister: true);
					gameItemUIScreen.Show();
					break;
				}
				case EContentSourceType.Workshop:
				{
					string steamURL = string.Empty;
					string browserURL = string.Empty;
					ExtContentUtils.ExtContentManager.ContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForGameItem(gameItem, ref steamURL, ref browserURL);
					WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
					break;
				}
				}
			}
		}

		private void RegisterWorkshopCallbacks(bool bRegister)
		{
			ExtContentSourceWorkshop contentSourceWorkshop = ExtContentUtils.ExtContentManager.ContentSourceWorkshop;
			if (bRegister)
			{
				contentSourceWorkshop.OnGameItemCreated += OnWorkshopGameItemCreated;
				contentSourceWorkshop.OnGameItemUpdated += OnWorkshopGameItemUpdated;
				contentSourceWorkshop.OnGameItemDeleted += OnWorkshopGameItemDeleted;
			}
			else
			{
				contentSourceWorkshop.OnGameItemCreated -= OnWorkshopGameItemCreated;
				contentSourceWorkshop.OnGameItemUpdated -= OnWorkshopGameItemDeleted;
				contentSourceWorkshop.OnGameItemDeleted -= OnWorkshopGameItemDeleted;
			}
		}

		private void RegisterLocalModsCallbacks(bool bRegister)
		{
			ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
			ExtContentSourceLocalMods contentSourceLocalMods = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
			if (bRegister)
			{
				gameItemUIScreen.OnUIScreenClosed -= OnLocalModUIScreenClosed;
				contentSourceLocalMods.OnGameItemCreated -= OnLocalModGameItemCreated;
				contentSourceLocalMods.OnGameItemUpdated -= OnLocalModGameItemUpdated;
				contentSourceLocalMods.OnGameItemDeleted -= OnLocalModGameItemDeleted;
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
			if (!IsClosed() && !IsClosing())
			{
				if (gameItem.ContentType == EContentType.Floor)
				{
					SetMode(Mode.InternalFloor);
				}
				else if (gameItem.ContentType == EContentType.Wall)
				{
					SetMode(Mode.InternalWall);
				}
			}
			OnGameItemUpdatedGeneral(gameItem);
		}

		private void OnLocalModGameItemUpdated(GameItemBase gameItem)
		{
			OnGameItemUpdatedGeneral(gameItem, bShouldCloseUI: false);
		}

		private void OnLocalModGameItemDeleted(GameItemBase gameItem)
		{
			if (IsClosed() || IsClosing())
			{
				return;
			}
			bool flag = false;
			foreach (RoomCustomisationRow row in _rows)
			{
				if (row.CurrentMode == RoomCustomisationRow.Mode.Selected)
				{
					if (row.GameItem == gameItem)
					{
						flag = true;
					}
					break;
				}
			}
			OnGameItemUpdatedGeneral(gameItem);
			if (flag)
			{
				SelectRow(_rows[0]);
			}
		}

		private void OnWorkshopGameItemCreated(GameItemBase gameItem)
		{
			OnGameItemUpdatedGeneral(gameItem);
		}

		private void OnWorkshopGameItemUpdated(GameItemBase gameItem)
		{
			OnGameItemUpdatedGeneral(gameItem);
		}

		private void OnWorkshopGameItemDeleted(GameItemBase gameItem)
		{
			OnGameItemUpdatedGeneral(gameItem);
		}

		private void OnGameItemUpdatedGeneral(GameItemBase gameItem, bool bShouldCloseUI = true)
		{
			if (!IsClosed() && !IsClosing())
			{
				RebuildRowsOnGameItemModified(gameItem);
			}
			if (bShouldCloseUI)
			{
				ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen.Hide();
			}
		}

		private void RebuildRowsOnGameItemModified(GameItemBase gameItem)
		{
			if (gameItem == null || (gameItem.ContentType != EContentType.Floor && gameItem.ContentType != EContentType.Wall))
			{
				return;
			}
			RebuildRows();
			foreach (RoomCustomisationRow row in _rows)
			{
				if (row.GameItem != gameItem)
				{
					continue;
				}
				row.OnGameItemDataChanged();
				switch (_currentMode)
				{
				case Mode.InternalWall:
					if (_level.Metagame.HasUnlocked(row.WallOption))
					{
						_inspectedRoom.FloorPlanVisual.WallVisualOverride = row.WallOption;
					}
					break;
				case Mode.InternalFloor:
					if (_level.Metagame.HasUnlocked(row.FloorOption))
					{
						_inspectedRoom.FloorPlanVisual.FloorVisualOverride = row.FloorOption;
					}
					break;
				}
				break;
			}
			RefreshRowsMode();
		}

		private void ApplyToAllRoomType()
		{
			if (InspectedRoom == null)
			{
				return;
			}
			List<Room> list = new List<Room>();
			_level.WorldState.GetRoomsOfType(InspectedRoom.Definition._type, includeClosed: true, list);
			switch (_currentMode)
			{
			case Mode.InternalWall:
				foreach (Room item in list)
				{
					item.FloorPlanVisual.WallVisualOverride = _currentWallCustomisationOption;
				}
				_level.RoomCustomisations.SetDefaultWallVisualOverride(InspectedRoom.Definition._type, _currentWallCustomisationOption);
				break;
			case Mode.InternalFloor:
				foreach (Room item2 in list)
				{
					item2.FloorPlanVisual.FloorVisualOverride = _currentFloorCustomisationOption;
				}
				_level.RoomCustomisations.SetDefaultFloorVisualOverride(InspectedRoom.Definition._type, _currentFloorCustomisationOption);
				break;
			}
			RefreshApplyAllButton();
		}

		public override void Destroy()
		{
			_level.InputManager.RemoveGraphicRayCaster(_data.GraphicRaycaster);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpenRoom = (Action<InspectorMenu, Room>)Delegate.Remove(hUDEvents.OnInspectorOpenRoom, new Action<InspectorMenu, Room>(OnInspectorOpenRoom));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			_level.Metagame.OnSilverAwarded.Remove(this);
			RegisterLocalModsCallbacks(bRegister: false);
			RegisterWorkshopCallbacks(bRegister: false);
		}

		private void OnRoomDeleted(Room room)
		{
			if (room == _inspectedRoom)
			{
				InspectedRoom = null;
				CloseMenu();
			}
		}

		void Interface.OnSilverAwardedEvent(int amount)
		{
			if (!(base.gameObject == null) && base.gameObject.activeInHierarchy && !IsClosed() && !IsClosing())
			{
				RefreshRowsMode();
			}
		}
	}
}
