using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class BuildEvents : MustCallDestroy, IGameEventsBase
	{
		public Action<BlueprintFloorPlan, BlueprintFloorPlanVisual> OnEnterNewRoomState;

		public Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual> OnEnterEditFloorPlanState;

		public Action<Room> OnRoomEditRoomObjectsState;

		public Action<BuildingLogic.State, bool> OnEnterNullState;

		public Action<RoomDefinition> OnBeginNewRoom;

		public Action<CursorRoomBuild.RoomAreaDragOperation> OnBuildModeChanged;

		public Action<BlueprintFloorPlan> OnRoomValidityChanged;

		public Action OnAcceptRoom;

		public Action OnCancelRoom;

		public Action OnMoveRoom;

		public Action<Room> OnRoomAdded;

		public Action<Room> OnRoomRemoved;

		public Action<Room> OnRoomDeleted;

		public Action<Room> OnRoomOpened;

		public Action<Room> OnRoomClosed;

		public Action<Room> OnRoomMissingRequiredItem;

		public Action<Room, int> OnRoomCancelled;

		public Action<Room, int> OnRoomBuiltEvent;

		public Action<Room> OnNewRoomBuiltEvent;

		public Action<BlueprintFloorPlan> OnFloorPlanUpdated;

		public Action<FloorPlan, RoomPrestige, RoomPrestige> OnFloorPlanPrestigeUpdated;

		public Action OnStopRoomAutoFlow;

		public Action<FloorPlan> OnRoomDragStart;

		public Action OnRoomDragEnd;

		public Action<bool, Vector3> OnMoveRoomEnd;

		public Action OnMoveRoomStart;

		public Action<Room, bool> OnRoomVisibilityChanged;

		public Action<Room> OnRoomLightingChanged;

		public Action<IRoomItemDefinition, FloorPlan, bool> OnBeginItemPlacement;

		public Action<RoomItem, Room> OnBeginItemEdit;

		public Action<RoomItem> OnBeginItemEditBuildMode;

		public Action<RoomItem, FloorPlan> OnRoomItemPlacementDenied;

		public Action<RoomItem, FloorPlan> OnRoomItemPlaced;

		public Action<RoomItem, FloorPlan> OnRoomItemAdded;

		public Action<RoomItem, FloorPlan> OnRoomItemRemoved;

		public Action<RoomItem, bool> OnRoomItemCancel;

		public Action<RoomItem> OnRoomItemPurchased;

		public Action<RoomItem> OnRoomItemSold;

		public Action<RoomItem> OnRoomItemMaintenanceRequired;

		public Action<RoomItem, Staff, JobMaintenance> OnRoomItemMaintenanceComplete;

		public Action<RoomItem> OnRoomItemBrokenDown;

		public Action<RoomItem> OnRoomItemMaintained;

		public Action<RoomItem> OnRoomItemDestroy;

		public Action<RoomItem> OnRoomItemDestroyed;

		public Action<RoomItem> OnRoomItemRequestRepair;

		public Action<RoomItem> OnRoomItemCancelRepair;

		public Action<RoomItem> OnRoomItemRequestUpgrade;

		public Action<RoomItem> OnRoomItemCancelUpgrade;

		public Action<RoomItem, Staff> OnRoomItemUpgradeComplete;

		public Action<RoomItem, RoomItemFlammableComponent> OnRoomItemOnFire;

		public Action<RoomItem> OnRoomItemExtinguished;

		public Action<RoomItem, RoomItemFlammableComponent> OnRoomItemExploded;

		public Action<RoomItem> OnRoomItemRotated;

		public Action<RoomItemVisual> OnRoomItemVisualCreated;

		public Action<RoomItemVisual> OnRoomItemVisualDestroyed;

		public Action<RoomItem> OnRoomItemInvalid;

		public Action<RoomItemMaintenanceChallengeComponent> OnRoomItemMaintenanceChallengeThresholdEntered;

		public Action<RoomItemMaintenanceChallengeComponent> OnRoomItemMaintenanceChallengeThresholdExited;

		public Action<RoomDefinition, bool, bool, bool> OnAddRoomDefinition;

		public Action<RoomDefinition> OnRemoveRoomDefinition;

		public Action<RoomItemDefinition, bool, bool, bool> OnAddRoomItemDefinition;

		public Action<RoomItemDefinition> OnRemoveRoomItemDefinition;

		public Action<HospitalPlot> OnHospitalPlotBought;

		public Action<HospitalPlot> OnHospitalPlotBuilt;

		public Action<ICursorSelectable> OnCursorHighlight;

		public Action<ICursorSelectable> OnCursorHoverStart;

		public Action<ICursorSelectable> OnCursorHoverOut;

		public Action<ICursorSelectable> OnCursorHoverStop;

		public Action<ICursorSelectable> OnCursorSelectObject;

		public Action<ICursorSelectable, float> OnCursorHoldUpdated;

		public Action<ICursorSelectable> OnCursorHoldCancel;

		public Action<ICursorSelectable> OnCursorDragSelect;

		public Action<ICursorSelectable> OnCursorDeleteObject;

		[DontSave]
		private HUD _hud;

		private Level _level;

		private BuildingLogic _buildingLogic;

		[DontSave]
		private CursorManager _cursorManager;

		private WorldState _worldState;

		private RoomItem _itemBeingEdited;

		[DontSave]
		private RoomItem _itemBeingDestroyed;

		public void Initialise(Level level)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			_hud = _level.HUD;
			_buildingLogic = _level.BuildingLogic;
			_cursorManager = _level.CursorManager;
			_worldState = _level.WorldState;
			OnBeginItemPlacement = (Action<IRoomItemDefinition, FloorPlan, bool>)Delegate.Combine(OnBeginItemPlacement, new Action<IRoomItemDefinition, FloorPlan, bool>(StartItemPlacement));
			OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Combine(OnBeginItemEditBuildMode, new Action<RoomItem>(BeginItemEditBuildMode));
			OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(OnRoomItemAdded, new Action<RoomItem, FloorPlan>(RoomItemAdded));
			OnRoomItemCancel = (Action<RoomItem, bool>)Delegate.Combine(OnRoomItemCancel, new Action<RoomItem, bool>(RoomItemCancel));
			OnRoomOpened = (Action<Room>)Delegate.Combine(OnRoomOpened, new Action<Room>(RoomOpened));
			OnRoomClosed = (Action<Room>)Delegate.Combine(OnRoomClosed, new Action<Room>(RoomClosed));
			OnMoveRoom = (Action)Delegate.Combine(OnMoveRoom, new Action(MoveRoom));
			OnRoomItemDestroy = (Action<RoomItem>)Delegate.Combine(OnRoomItemDestroy, new Action<RoomItem>(RoomItemDestroy));
			OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Combine(OnCursorHoverStart, new Action<ICursorSelectable>(CursorHoverStart));
			OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Combine(OnCursorSelectObject, new Action<ICursorSelectable>(CursorSelectObject));
			OnCursorHoldCancel = (Action<ICursorSelectable>)Delegate.Combine(OnCursorHoldCancel, new Action<ICursorSelectable>(CursorHoldCancel));
			OnCursorHoldUpdated = (Action<ICursorSelectable, float>)Delegate.Combine(OnCursorHoldUpdated, new Action<ICursorSelectable, float>(CursorHoldUpdated));
			OnCursorDragSelect = (Action<ICursorSelectable>)Delegate.Combine(OnCursorDragSelect, new Action<ICursorSelectable>(CursorDragSelect));
			OnCursorDeleteObject = (Action<ICursorSelectable>)Delegate.Combine(OnCursorDeleteObject, new Action<ICursorSelectable>(CursorDeleteObject));
			OnFloorPlanPrestigeUpdated = (Action<FloorPlan, RoomPrestige, RoomPrestige>)Delegate.Combine(OnFloorPlanPrestigeUpdated, new Action<FloorPlan, RoomPrestige, RoomPrestige>(FloorPlanPrestigeUpdated));
			if (_itemBeingEdited != null)
			{
				RoomItem itemBeingEdited = _itemBeingEdited;
				_itemBeingEdited = null;
				if (itemBeingEdited.HasBeenPurchased)
				{
					OnRoomItemSold.InvokeSafe(itemBeingEdited);
				}
				if (itemBeingEdited.Visual != null)
				{
					itemBeingEdited.Visual.Destroy();
				}
				FloorPlan floorPlan = itemBeingEdited.FloorPlan;
				if (floorPlan != null && floorPlan.Items.Contains(itemBeingEdited))
				{
					itemBeingEdited.RemoveFromWorld(updateNavigation: true);
					floorPlan.RemoveItem(itemBeingEdited);
				}
				itemBeingEdited.Destroy();
			}
		}

		public override void Destroy()
		{
			OnBeginItemPlacement = (Action<IRoomItemDefinition, FloorPlan, bool>)Delegate.Remove(OnBeginItemPlacement, new Action<IRoomItemDefinition, FloorPlan, bool>(StartItemPlacement));
			OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Remove(OnBeginItemEditBuildMode, new Action<RoomItem>(BeginItemEditBuildMode));
			OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(OnRoomItemAdded, new Action<RoomItem, FloorPlan>(RoomItemAdded));
			OnRoomItemCancel = (Action<RoomItem, bool>)Delegate.Remove(OnRoomItemCancel, new Action<RoomItem, bool>(RoomItemCancel));
			OnRoomOpened = (Action<Room>)Delegate.Remove(OnRoomOpened, new Action<Room>(RoomOpened));
			OnRoomClosed = (Action<Room>)Delegate.Remove(OnRoomClosed, new Action<Room>(RoomClosed));
			OnMoveRoom = (Action)Delegate.Remove(OnMoveRoom, new Action(MoveRoom));
			OnRoomItemDestroy = (Action<RoomItem>)Delegate.Remove(OnRoomItemDestroy, new Action<RoomItem>(RoomItemDestroy));
			OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Remove(OnCursorHoverStart, new Action<ICursorSelectable>(CursorHoverStart));
			OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Remove(OnCursorSelectObject, new Action<ICursorSelectable>(CursorSelectObject));
			OnCursorHoldCancel = (Action<ICursorSelectable>)Delegate.Remove(OnCursorHoldCancel, new Action<ICursorSelectable>(CursorHoldCancel));
			OnCursorHoldUpdated = (Action<ICursorSelectable, float>)Delegate.Remove(OnCursorHoldUpdated, new Action<ICursorSelectable, float>(CursorHoldUpdated));
			OnCursorDragSelect = (Action<ICursorSelectable>)Delegate.Remove(OnCursorDragSelect, new Action<ICursorSelectable>(CursorDragSelect));
			OnCursorDeleteObject = (Action<ICursorSelectable>)Delegate.Remove(OnCursorDeleteObject, new Action<ICursorSelectable>(CursorDeleteObject));
			OnFloorPlanPrestigeUpdated = (Action<FloorPlan, RoomPrestige, RoomPrestige>)Delegate.Remove(OnFloorPlanPrestigeUpdated, new Action<FloorPlan, RoomPrestige, RoomPrestige>(FloorPlanPrestigeUpdated));
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnBeginNewRoom.VerifyIsNull();
			OnBuildModeChanged.VerifyIsNull();
			OnRoomValidityChanged.VerifyIsNull();
			OnAcceptRoom.VerifyIsNull();
			OnCancelRoom.VerifyIsNull();
			OnMoveRoom.VerifyIsNull();
			OnRoomAdded.VerifyIsNull();
			OnRoomRemoved.VerifyIsNull();
			OnRoomDeleted.VerifyIsNull();
			OnRoomOpened.VerifyIsNull();
			OnRoomClosed.VerifyIsNull();
			OnRoomMissingRequiredItem.VerifyIsNull();
			OnRoomCancelled.VerifyIsNull();
			OnRoomBuiltEvent.VerifyIsNull();
			OnNewRoomBuiltEvent.VerifyIsNull();
			OnFloorPlanUpdated.VerifyIsNull();
			OnFloorPlanPrestigeUpdated.VerifyIsNull();
			OnStopRoomAutoFlow.VerifyIsNull();
			OnBeginItemPlacement.VerifyIsNull();
			OnBeginItemEdit.VerifyIsNull();
			OnBeginItemEditBuildMode.VerifyIsNull();
			OnRoomItemPlaced.VerifyIsNull();
			OnRoomItemAdded.VerifyIsNull();
			OnRoomItemRemoved.VerifyIsNull();
			OnRoomItemDestroy.VerifyIsNull();
			OnRoomItemDestroyed.VerifyIsNull();
			OnRoomItemRequestRepair.VerifyIsNull();
			OnRoomItemCancelRepair.VerifyIsNull();
			OnRoomItemRequestUpgrade.VerifyIsNull();
			OnRoomItemCancelUpgrade.VerifyIsNull();
			OnRoomItemUpgradeComplete.VerifyIsNull();
			OnRoomItemOnFire.VerifyIsNull();
			OnRoomItemExtinguished.VerifyIsNull();
			OnRoomItemExploded.VerifyIsNull();
			OnRoomItemPurchased.VerifyIsNull();
			OnRoomItemSold.VerifyIsNull();
			OnRoomItemCancel.VerifyIsNull();
			OnRoomItemMaintenanceRequired.VerifyIsNull();
			OnRoomItemMaintenanceComplete.VerifyIsNull();
			OnRoomItemBrokenDown.VerifyIsNull();
			OnRoomItemMaintained.VerifyIsNull();
			OnRoomItemRotated.VerifyIsNull();
			OnRoomItemInvalid.VerifyIsNull();
			OnAddRoomDefinition.VerifyIsNull();
			OnRemoveRoomDefinition.VerifyIsNull();
			OnAddRoomItemDefinition.VerifyIsNull();
			OnRemoveRoomItemDefinition.VerifyIsNull();
			OnHospitalPlotBought.VerifyIsNull();
			OnHospitalPlotBuilt.VerifyIsNull();
			OnCursorHighlight.VerifyIsNull();
			OnCursorHoverStart.VerifyIsNull();
			OnCursorHoverOut.VerifyIsNull();
			OnCursorHoverStop.VerifyIsNull();
			OnCursorSelectObject.VerifyIsNull();
			OnCursorHoldCancel.VerifyIsNull();
			OnCursorHoldUpdated.VerifyIsNull();
			OnRoomDragStart.VerifyIsNull();
			OnRoomDragEnd.VerifyIsNull();
			OnMoveRoomEnd.VerifyIsNull();
			OnMoveRoomStart.VerifyIsNull();
			OnRoomVisibilityChanged.VerifyIsNull();
			OnRoomLightingChanged.VerifyIsNull();
			OnCursorDragSelect.VerifyIsNull();
			OnCursorDeleteObject.VerifyIsNull();
		}

		private void StartItemPlacement(IRoomItemDefinition roomItemDefinition, FloorPlan floorPlan, bool endOnPlace)
		{
			if (floorPlan == null)
			{
				floorPlan = _worldState.HospitalMaps[0].FloorPlan;
			}
			if (_hud.FindMenu<LandscapeObjectsMenu>() == null)
			{
				if (_level.BuildingLogic.CurrentState == BuildingLogic.State.Null && roomItemDefinition.ItemType != RoomItemDefinition.Type.Ambulance)
				{
					_level.HospitalHUDManager.ShowItemsList(RoomDefinition.Type.Hospital, null, playSFX: true);
				}
				else
				{
					_level.HospitalHUDManager.ShowItemsList(floorPlan.Definition._type, floorPlan, playSFX: false);
				}
			}
			RoomFloorPlanVisual roomFloorPlanVisual = ((floorPlan is BlueprintFloorPlan) ? _buildingLogic.CurrentBlueprintFloorPlanVisual : floorPlan.OwningRoom.FloorPlanVisual);
			_cursorManager.PopMode<CursorRoomItem>();
			_cursorManager.PushMode(new CursorRoomItem(_cursorManager, _level, _buildingLogic.Configuration.RoomItemEditConfig, roomItemDefinition, roomItemDefinition.DefaultRotation, floorPlan, roomFloorPlanVisual, null, endOnPlace));
		}

		private void BeginItemEditBuildMode(RoomItem roomItem)
		{
			BlueprintFloorPlan currentBlueprintFloorPlan = _buildingLogic.CurrentBlueprintFloorPlan;
			if (currentBlueprintFloorPlan != null)
			{
				_level.HospitalHUDManager.HideRoomsList();
				_level.HospitalHUDManager.ShowItemsList(currentBlueprintFloorPlan.Definition._type, currentBlueprintFloorPlan, playSFX: false);
				currentBlueprintFloorPlan.RemoveItem(roomItem);
				currentBlueprintFloorPlan.RecalculateWalls();
				currentBlueprintFloorPlan.RebuildNavMesh();
				currentBlueprintFloorPlan.Validate();
				_buildingLogic.CurrentBlueprintFloorPlanVisual.UpdateFromRoom(currentBlueprintFloorPlan);
				OnRoomValidityChanged.InvokeSafe(currentBlueprintFloorPlan);
				_cursorManager.PopMode<CursorRoomItem>();
				_cursorManager.PushMode(new CursorRoomItem(_cursorManager, _level, _buildingLogic.Configuration.RoomItemEditConfig, roomItem.Definition, roomItem.Rotation, currentBlueprintFloorPlan, _buildingLogic.CurrentBlueprintFloorPlanVisual, roomItem, endOnPlace: false));
			}
		}

		public void StartItemEdit(RoomItem roomItem, Room room)
		{
			if (roomItem.Definition.ItemType == RoomItemDefinition.Type.PlotObject)
			{
				return;
			}
			if (room.Definition.UseBlueprintEditMode(roomItem.Definition))
			{
				room.FloorPlan.RemoveItem(roomItem);
				_buildingLogic.TransitionToEditRoomBlueprintState(room);
				room.FloorPlan.AddItem(roomItem);
				roomItem.RemoveFromWorld(updateNavigation: false);
				BlueprintFloorPlan currentBlueprintFloorPlan = _buildingLogic.CurrentBlueprintFloorPlan;
				if (currentBlueprintFloorPlan != null)
				{
					RoomItem roomItem2 = new RoomItem(roomItem, currentBlueprintFloorPlan);
					currentBlueprintFloorPlan.AddItem(roomItem2);
					BeginItemEditBuildMode(roomItem2);
				}
			}
			else
			{
				room.FloorPlan.RemoveItem(roomItem);
				room.FloorPlanVisual.CreateRoomItems();
				_cursorManager.PopMode<CursorRoomItem>();
				_cursorManager.PushMode(new CursorRoomItem(_cursorManager, _level, _buildingLogic.Configuration.RoomItemEditConfig, roomItem.Definition, roomItem.Rotation, room.FloorPlan, room.FloorPlanVisual, roomItem, endOnPlace: false));
				roomItem.RemoveFromWorld(updateNavigation: true);
				_worldState.RemoveNeedSatisfyingRoomItem(roomItem);
				RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, roomItem.MapTileBound, room.FloorPlan, _worldState, null, null);
				_itemBeingEdited = roomItem;
			}
			OnBeginItemEdit.InvokeSafe(roomItem, room);
		}

		public void DeleteRoom(Room room)
		{
			if (room.Definition.IsHospitalOrBay || room.Definition.IsHospitalUnbuilt)
			{
				DeleteRoomInternal(room);
				return;
			}
			string newValue = StringUtils.FormatCurrency(GameAlgorithms.CalculateSellCostOfRoom(room.FloorPlan));
			NotificationMessages.Definition definition = new NotificationMessages.Definition();
			definition.LocalisedTitle = new LocalisedString("Notification/SellRoom_Title_CS");
			definition.Text = ScriptLocalization.Notification.SellRoom_Message_CS.Replace("{[COST]}", newValue);
			definition.DefaultChoice = 1;
			definition.Choices = new LocalisedString[2]
			{
				new LocalisedString("Menu/Yes"),
				new LocalisedString("Menu/No")
			};
			NotificationGenericDecision message = new NotificationGenericDecision(definition, delegate(int response)
			{
				if (response == 0)
				{
					DeleteRoomInternal(room);
				}
			}, _level);
			_level.Notifications.OpenPopup(message);
		}

		private void DeleteRoomInternal(Room room)
		{
			room.Close();
			_worldState.RemoveRoom(room, affectNavigation: true);
			room.FloorPlan.RemoveItemsFromWorld();
			OnRoomDeleted.InvokeSafe(room);
			room.Destroy();
			List<RoomItem> list = new List<RoomItem>();
			RoomAlgorithms.FindInvalidWallItems(room.FloorPlan.HospitalMap.FloorPlan, list);
			foreach (RoomItem item in list)
			{
				OnRoomItemSold.InvokeSafe(item);
				OnRoomItemDestroy.InvokeSafe(item);
			}
			if (!room.Definition.IsHospitalOrBay && !room.Definition.IsHospitalUnbuilt)
			{
				RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, null, room.FloorPlan.HospitalMap.FloorPlan, _worldState, null, null);
			}
		}

		private void MoveRoom()
		{
			_cursorManager.PopMode<CursorRoomMove>();
			_cursorManager.PushMode(new CursorRoomMove(_cursorManager, _level, _worldState, this, _buildingLogic.CurrentBlueprintFloorPlan, _buildingLogic.CurrentBlueprintFloorPlanVisual, landscapeEdit: false));
		}

		private void RoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			_itemBeingEdited = null;
			RoomAlgorithms.MoveOverlappingItemsWithItem(roomItem);
		}

		private void RoomItemCancel(RoomItem roomItem, bool requestedByUser)
		{
			_itemBeingEdited = null;
			_cursorManager.PopMode<CursorRoomItem>();
		}

		private void RoomOpened(Room room)
		{
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				_worldState.AddNeedSatisfyingRoomItem(item);
			}
		}

		private void RoomClosed(Room room)
		{
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				_worldState.RemoveNeedSatisfyingRoomItem(item);
			}
		}

		private void RoomItemDestroy(RoomItem roomItem)
		{
			if (roomItem != null && !roomItem.HasBeenDestroyed() && (object)roomItem.Visual.GameObject != null && (_itemBeingDestroyed == null || roomItem != _itemBeingDestroyed))
			{
				_itemBeingDestroyed = roomItem;
				FloorPlan floorPlan = roomItem.FloorPlan;
				Room owningRoom = floorPlan.OwningRoom;
				floorPlan.RemoveItem(roomItem);
				if (!(floorPlan is BlueprintFloorPlan))
				{
					roomItem.RemoveFromWorld(updateNavigation: true);
					_worldState.RemoveNeedSatisfyingRoomItem(roomItem);
				}
				owningRoom?.FloorPlanVisual.CreateRoomItems();
				roomItem.Visual.Destroy();
				roomItem.Destroy();
				_itemBeingEdited = null;
				_itemBeingDestroyed = null;
			}
		}

		private void CursorHoverStart(ICursorSelectable selected)
		{
			if (selected == null)
			{
				return;
			}
			InWorldMenuObject activeMenu = selected.GetActiveMenu();
			if (activeMenu != null)
			{
				activeMenu.OpenMenu();
			}
			else if (selected is Room)
			{
				if (_hud.MenusTransform.gameObject.activeInHierarchy && _level.DataViewManager.CanShowRoomHoverMenu)
				{
					Room room = (Room)selected;
					if (room.Definition._hoverMenuPrefab == null)
					{
						_hud.CreateMenu<HoverMenuRoom>().Setup(room, _level);
					}
					else if (!room.Definition.IsAmbulanceBayOnly || !room.IsOpen)
					{
						_hud.CreateMenu<HoverMenuRoomBase>(room.Definition._hoverMenuPrefab).Setup(room, _level);
					}
				}
			}
			else if (selected is RoomItem)
			{
				if (_hud.MenusTransform.gameObject.activeInHierarchy)
				{
					RoomItem roomItem = (RoomItem)selected;
					if (roomItem.Definition.HoverMenuPrefab == null)
					{
						_hud.CreateMenu<HoverMenuRoomItem>().Setup(roomItem, _level);
					}
					else
					{
						_hud.CreateMenu<HoverMenuRoomItemBase>(roomItem.Definition.HoverMenuPrefab).Setup(roomItem, _level);
					}
				}
			}
			else if (selected is Character && _hud.MenusTransform.gameObject.activeInHierarchy)
			{
				Character character = (Character)selected;
				if (character.Definition._hoverMenuPrefab != null)
				{
					_hud.CreateMenu<HoverMenuCharacter>(character.Definition._hoverMenuPrefab).Setup(character, _level);
				}
			}
		}

		private void CursorSelectObject(ICursorSelectable selected)
		{
			if (selected == null || !selected.IsSelectable())
			{
				return;
			}
			InWorldMenuObject activeMenu = selected.GetActiveMenu();
			if (activeMenu is SelectMenuBase)
			{
				return;
			}
			if (activeMenu is HoverMenuBase)
			{
				activeMenu.CloseMenu();
			}
			if (HospitalHUDManager.DEBUG_UseOldInspectorMenu)
			{
				if (selected is Room)
				{
					Room room = (Room)selected;
					if (room.Definition._selectMenuPrefab == null)
					{
						_hud.CreateMenu<SelectMenuRoomBase>().Setup(room, _level);
					}
					else
					{
						_hud.CreateMenu<SelectMenuRoomBase>(room.Definition._selectMenuPrefab).Setup(room, _level);
					}
				}
				else if (selected is RoomItem)
				{
					RoomItem roomItem = (RoomItem)selected;
					if (roomItem.Definition.SelectMenuPrefab == null)
					{
						_hud.CreateMenu<SelectMenuRoomItemBase>().Setup(roomItem, _level);
					}
					else
					{
						_hud.CreateMenu<SelectMenuRoomItemBase>(roomItem.Definition.SelectMenuPrefab).Setup(roomItem, _level);
					}
				}
				else if (selected is Character)
				{
					Character character = (Character)selected;
					if (character.Definition._selectMenuPrefab != null)
					{
						_hud.CreateMenu<SelectMenuCharacter>(character.Definition._selectMenuPrefab).Setup(character, _level);
					}
				}
			}
			else if (selected is Room)
			{
				Room room2 = (Room)selected;
				if (!room2.FloorPlan.HospitalMap.Plot.Bought)
				{
					if (room2.Definition._selectMenuPrefab == null)
					{
						_hud.CreateMenu<SelectMenuRoomBase>().Setup(room2, _level);
					}
					else
					{
						_hud.CreateMenu<SelectMenuRoomBase>(room2.Definition._selectMenuPrefab).Setup(room2, _level);
					}
				}
			}
			else if (selected is RoomItem)
			{
				RoomItem roomItem2 = (RoomItem)selected;
				if (roomItem2.Definition.ItemType == RoomItemDefinition.Type.Door)
				{
					return;
				}
				if (_level.InputManager.GetKey(KeyCode.LeftControl) || _level.InputManager.GetKey(KeyCode.RightControl))
				{
					if (roomItem2.Definition.ItemType != RoomItemDefinition.Type.Special && roomItem2.Definition.ItemType != RoomItemDefinition.Type.PlotObject)
					{
						OnBeginItemPlacement.InvokeSafe(roomItem2.Definition, roomItem2.FloorPlan, param3: false);
						if (_cursorManager.TryGetActiveMode<CursorRoomItem>(out var activeMode))
						{
							activeMode.SetRoomItemTransform(roomItem2.WorldPosition, roomItem2.Rotation);
						}
					}
				}
				else if (roomItem2.Definition.SelectMenuPrefab == null)
				{
					_hud.CreateMenu<SelectMenuRoomItemBase>().Setup(roomItem2, _level);
				}
				else
				{
					_hud.CreateMenu<SelectMenuRoomItemBase>(roomItem2.Definition.SelectMenuPrefab).Setup(roomItem2, _level);
				}
			}
			else if (selected is Character && selected.GetCameraTrackObject() != null)
			{
				_level.CameraLogic.TrackObject(selected.GetCameraTrackObject().transform);
			}
		}

		private void CursorHoldUpdated(ICursorSelectable cursorSelectable, float holdTime)
		{
			PickUpItemMenu pickUpItemMenu = _level.HUD.FindMenu<PickUpItemMenu>();
			if (pickUpItemMenu == null)
			{
				pickUpItemMenu = _level.HUD.CreateMenu<PickUpItemMenu>();
				pickUpItemMenu.Setup(cursorSelectable, _level);
			}
			pickUpItemMenu.SetProgress(holdTime);
		}

		private void CursorHoldCancel(ICursorSelectable cursorSelectable)
		{
			PickUpItemMenu pickUpItemMenu = _level.HUD.FindMenu<PickUpItemMenu>();
			if (pickUpItemMenu != null)
			{
				pickUpItemMenu.CloseMenu();
			}
		}

		private void CursorDragSelect(ICursorSelectable item)
		{
			Staff staff = item as Staff;
			RoomItem roomItem = item as RoomItem;
			if (staff != null)
			{
				_level.CharacterEvents.OnStaffPickup.InvokeSafe(staff, null);
			}
			else if (roomItem != null)
			{
				StartItemEdit(roomItem, roomItem.OwningRoom);
			}
		}

		private void CursorDeleteObject(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable is Room)
			{
				Room room = (Room)cursorSelectable;
				if (!room.Definition.IsHospitalOrBay && !room.Definition.IsHospitalUnbuilt)
				{
					DeleteRoom(room);
				}
			}
			else
			{
				if (!(cursorSelectable is RoomItem))
				{
					return;
				}
				RoomItem roomItem = (RoomItem)cursorSelectable;
				Room owningRoom = roomItem.OwningRoom;
				if (owningRoom != null)
				{
					if (!owningRoom.Definition.UseBlueprintEditMode(roomItem.Definition) && roomItem.Definition.CanBeSold())
					{
						if (roomItem.HasBeenPurchased)
						{
							OnRoomItemSold.InvokeSafe(roomItem);
						}
						OnRoomItemDestroy.InvokeSafe(roomItem);
						FloorPlan floorPlan = owningRoom.FloorPlan;
						List<RoomItem> currentItems = RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, roomItem.MapTileBound, floorPlan, _worldState, null, null);
						RoomItemAlgorithms.RefreshBoundVisualsOnItems(floorPlan.Items, currentItems);
					}
				}
				else
				{
					if (roomItem.HasBeenPurchased)
					{
						OnRoomItemSold.InvokeSafe(roomItem);
					}
					OnRoomItemDestroy.InvokeSafe(roomItem);
				}
			}
		}

		private void FloorPlanPrestigeUpdated(FloorPlan floorPlan, RoomPrestige oldPrestige, RoomPrestige newPrestige)
		{
			if (oldPrestige.Level < newPrestige.Level)
			{
				string text = string.Format("{0} - {1}", floorPlan.Definition.ToLocalisedString(), ScriptLocalization.Menu.Hover_Room_Prestige_CS.Replace("{[LEVEL]}", newPrestige.Level.ToString()));
				text = text.Replace(":", "");
				_level.InWorldMessages.ShowMessage(text, floorPlan.WorldBounds.Center.ToWorldPosition(), 3f, InWorldMessages.MessageType.Info);
			}
		}
	}
}
