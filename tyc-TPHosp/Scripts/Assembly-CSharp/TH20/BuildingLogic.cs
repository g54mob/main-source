#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.Analytics;
using UnityEngine;

namespace TH20
{
	public class BuildingLogic : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public GameObject BlueprintFloorTilePrefab;

			public Material BlueprintFloorMaterialValid;

			public Material BlueprintFloorMaterialInvalid;

			public Material BlueprintFloorMaterialInvalidSize;

			public RoomItemVisualEdit.Config RoomItemEditConfig;
		}

		public enum State
		{
			Transitioning = -1,
			Null = 0,
			NewRoom = 1,
			EditRoomBlueprint = 2,
			EditRoomObjects = 3
		}

		private struct NewRoomState
		{
			public BlueprintFloorPlan BlueprintFloorPlan;

			public BlueprintFloorPlanVisual BlueprintFloorPlanVisual;

			[DontSave]
			public IFloorVisualOverrideDefinition FloorVisualOverride;

			[DontSave]
			public IWallVisualOverrideDefinition WallVisualOverride;
		}

		private struct EditRoomBlueprintState
		{
			public Room RoomBeingEdited;

			public BlueprintFloorPlan BlueprintFloorPlan;

			public BlueprintFloorPlanVisual BlueprintFloorPlanVisual;

			[DontSave]
			public IFloorVisualOverrideDefinition FloorVisualOverride;

			[DontSave]
			public IWallVisualOverrideDefinition WallVisualOverride;
		}

		private struct EditRoomObjectsState
		{
			public FloorPlan FloorPlan;

			public RoomItem ItemBeingEdited;

			public BlueprintFloorPlanVisual BlueprintFloorPlanVisual;
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly VisualManager _visualManager;

		private readonly BuildEvents _buildEvents;

		[DontSave]
		private DataViewManager _dataViewManager;

		private State _currentState;

		private NewRoomState _newRoomState;

		private EditRoomBlueprintState _editRoomBlueprintState;

		private EditRoomObjectsState _editRoomObjectsState;

		[DontSave]
		private RoomBuildingNavMesh _roomBuildingNavMesh;

		[DontSave]
		private int _roomBuildingNavMeshRefCount;

		public State CurrentState => _currentState;

		public FloorPlan CurrentFloorPlan => _currentState switch
		{
			State.NewRoom => _newRoomState.BlueprintFloorPlan, 
			State.EditRoomBlueprint => _editRoomBlueprintState.BlueprintFloorPlan, 
			State.EditRoomObjects => _editRoomObjectsState.FloorPlan, 
			_ => null, 
		};

		public BlueprintFloorPlanVisual CurrentBlueprintFloorPlanVisual => _currentState switch
		{
			State.NewRoom => _newRoomState.BlueprintFloorPlanVisual, 
			State.EditRoomBlueprint => _editRoomBlueprintState.BlueprintFloorPlanVisual, 
			State.EditRoomObjects => _editRoomObjectsState.BlueprintFloorPlanVisual, 
			_ => null, 
		};

		public BlueprintFloorPlan CurrentBlueprintFloorPlan => CurrentFloorPlan as BlueprintFloorPlan;

		public bool CanApplyEditedRoomChanges
		{
			get
			{
				if (_currentState == State.Null)
				{
					return false;
				}
				return CurrentBlueprintFloorPlan?.CanBeBuilt ?? false;
			}
		}

		public Config Configuration => _config;

		public BuildingLogic(Config config, Level level, WorldState worldState, VisualManager visualManager, DataViewManager dataViewManager, BuildEvents buildEvents)
		{
			_config = config;
			_level = level;
			_worldState = worldState;
			_visualManager = visualManager;
			_dataViewManager = dataViewManager;
			_buildEvents = buildEvents;
		}

		public void RestoreFromSave(DataViewManager dataViewManager)
		{
			_dataViewManager = dataViewManager;
			Level level = _level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
			{
				if (_currentState != State.Null)
				{
					TransitionToNullState(applyChanges: false);
				}
				if (_editRoomObjectsState.ItemBeingEdited != null)
				{
					_editRoomObjectsState.ItemBeingEdited.Destroy();
					_editRoomObjectsState.ItemBeingEdited = null;
				}
				if (_newRoomState.BlueprintFloorPlan != null)
				{
					_newRoomState.BlueprintFloorPlan.Destroy();
					_newRoomState.BlueprintFloorPlan = null;
				}
				if (_newRoomState.BlueprintFloorPlanVisual != null)
				{
					_newRoomState.BlueprintFloorPlanVisual.Destroy();
					_newRoomState.BlueprintFloorPlanVisual = null;
				}
				_editRoomBlueprintState.RoomBeingEdited = null;
				if (_editRoomBlueprintState.BlueprintFloorPlan != null)
				{
					_editRoomBlueprintState.BlueprintFloorPlan.Destroy();
					_editRoomBlueprintState.BlueprintFloorPlan = null;
				}
				if (_editRoomBlueprintState.BlueprintFloorPlanVisual != null)
				{
					_editRoomBlueprintState.BlueprintFloorPlanVisual.Destroy();
					_editRoomBlueprintState.BlueprintFloorPlanVisual = null;
				}
			});
		}

		public override void Destroy()
		{
			if (_currentState != State.Null)
			{
				TransitionToNullState(applyChanges: false);
			}
			base.Destroy();
		}

		public void TransitionToNewRoomState(RoomDefinition roomDefinition)
		{
			LeaveCurrentState(applyChanges: false);
			_newRoomState.BlueprintFloorPlan = new BlueprintFloorPlan(roomDefinition, _level, null)
			{
				AutoFlowActive = true
			};
			_newRoomState.BlueprintFloorPlanVisual = new BlueprintFloorPlanVisual(_worldState, _visualManager, _dataViewManager, _config.RoomItemEditConfig, _level.BuildEvents, "Blueprint", _config.BlueprintFloorTilePrefab, roomDefinition._blueprintWallDefinition.Instance, _config.BlueprintFloorMaterialValid, _config.BlueprintFloorMaterialInvalid, _config.BlueprintFloorMaterialInvalidSize);
			if (_level.RoomCustomisations.GetDefaultWallVisualOverride(roomDefinition._type, out var definition))
			{
				_newRoomState.WallVisualOverride = definition;
			}
			if (_level.RoomCustomisations.GetDefaultFloorVisualOverride(roomDefinition._type, out var definition2))
			{
				_newRoomState.FloorVisualOverride = definition2;
			}
			_buildEvents.OnBeginNewRoom.InvokeSafe(roomDefinition);
			_level.CursorManager.PopMode<CursorRoomBuild>();
			_level.CursorManager.PushMode(new CursorRoomBuild(_level.CursorManager, _level, _level.Config.GetCursorRoomBuildConfig(), _newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual));
			_currentState = State.NewRoom;
			_buildEvents.OnEnterNewRoomState.InvokeSafe(_newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual);
		}

		public void TransitionToEditRoomBlueprintState(Room room)
		{
			LeaveCurrentState(applyChanges: false);
			_worldState.RemoveRoom(room, affectNavigation: false);
			_editRoomBlueprintState.RoomBeingEdited = room;
			_editRoomBlueprintState.RoomBeingEdited.Close();
			_editRoomBlueprintState.RoomBeingEdited.FloorPlan.RemoveItemsFromWorld();
			_editRoomBlueprintState.BlueprintFloorPlan = new BlueprintFloorPlan(_editRoomBlueprintState.RoomBeingEdited.FloorPlan)
			{
				AutoFlowActive = false
			};
			_editRoomBlueprintState.WallVisualOverride = room.FloorPlanVisual.WallVisualOverride;
			_editRoomBlueprintState.FloorVisualOverride = room.FloorPlanVisual.FloorVisualOverride;
			_editRoomBlueprintState.BlueprintFloorPlanVisual = new BlueprintFloorPlanVisual(_worldState, _visualManager, _dataViewManager, _config.RoomItemEditConfig, _level.BuildEvents, "Blueprint", _config.BlueprintFloorTilePrefab, room.Definition._blueprintWallDefinition.Instance, _config.BlueprintFloorMaterialValid, _config.BlueprintFloorMaterialInvalid, _config.BlueprintFloorMaterialInvalidSize);
			_editRoomBlueprintState.BlueprintFloorPlanVisual.UpdateFromRoom(_editRoomBlueprintState.BlueprintFloorPlan);
			RoomItem[] array = _editRoomBlueprintState.RoomBeingEdited.FloorPlan.Items.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].EndAllInteractions(immediately: true);
			}
			_editRoomBlueprintState.BlueprintFloorPlan.DisableItemEffects();
			List<RoomItem> list = new List<RoomItem>(_editRoomBlueprintState.RoomBeingEdited.FloorPlan.Items);
			List<RoomItem> list2 = new List<RoomItem>(_editRoomBlueprintState.BlueprintFloorPlan.Items);
			list.RemoveAll((RoomItem item) => item.Definition.ItemType == RoomItemDefinition.Type.Window);
			list2.RemoveAll((RoomItem item) => item.Definition.ItemType == RoomItemDefinition.Type.Window);
			int count = list.Count;
			int count2 = list2.Count;
			if (count != count2)
			{
				string text = string.Empty;
				foreach (RoomItem item in list)
				{
					text = text + item.Definition.GetName() + ",";
				}
				string text2 = string.Empty;
				foreach (RoomItem item2 in list2)
				{
					text2 = text2 + item2.Definition.GetName() + ",";
				}
				Logging.Error("\"editedItemCount\" is different to \"blueprintItemCount\", possibly due to items in the floor plan not passing validation.As a result, some items may not have their animation state transferred to the blueprint items\neditedRoomItems = {0}\nblueprintRoomItems = {1}\n", text, text2);
			}
			for (int num = 0; num < count && num < count2; num++)
			{
				RoomItem roomItem = list[num];
				RoomItem roomItem2 = list2[num];
				if (roomItem.Definition == roomItem2.Definition)
				{
					RoomItemVisual visual = roomItem.Visual;
					RoomItemVisual visual2 = roomItem2.Visual;
					if (visual != null && visual2 != null && !(visual2.Animator == null))
					{
						visual2.CopyAnimatorStateFrom(visual);
						visual2.Animator.Pause();
					}
				}
			}
			_editRoomBlueprintState.RoomBeingEdited.SetVisible(visible: false);
			_currentState = State.EditRoomBlueprint;
			_level.CursorManager.PopMode<CursorRoomBuild>();
			_level.CursorManager.PushMode(new CursorRoomBuild(_level.CursorManager, _level, _level.Config.GetCursorRoomBuildConfig(), CurrentBlueprintFloorPlan, CurrentBlueprintFloorPlanVisual));
			_buildEvents.OnEnterEditFloorPlanState.InvokeSafe(_editRoomBlueprintState.RoomBeingEdited, _editRoomBlueprintState.BlueprintFloorPlan, _editRoomBlueprintState.BlueprintFloorPlanVisual);
		}

		public void TransitionToCopyRoomBlueprintState(Room room)
		{
			RoomDefinition definition = room.Definition;
			LeaveCurrentState(applyChanges: false);
			_newRoomState.BlueprintFloorPlan = new BlueprintFloorPlan(room.FloorPlan)
			{
				AutoFlowActive = false
			};
			PrepareDuplicatedFloorPlan(_newRoomState.BlueprintFloorPlan);
			_newRoomState.BlueprintFloorPlanVisual = new BlueprintFloorPlanVisual(_worldState, _visualManager, _dataViewManager, _config.RoomItemEditConfig, _level.BuildEvents, "Blueprint", _config.BlueprintFloorTilePrefab, definition._blueprintWallDefinition.Instance, _config.BlueprintFloorMaterialValid, _config.BlueprintFloorMaterialInvalid, _config.BlueprintFloorMaterialInvalidSize);
			_newRoomState.WallVisualOverride = room.FloorPlanVisual.WallVisualOverride;
			_newRoomState.FloorVisualOverride = room.FloorPlanVisual.FloorVisualOverride;
			_buildEvents.OnBeginNewRoom.InvokeSafe(definition);
			_level.CursorManager.PopMode<CursorRoomBuild>();
			CursorRoomBuild cursorRoomBuild = new CursorRoomBuild(_level.CursorManager, _level, _level.Config.GetCursorRoomBuildConfig(), _newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual);
			_level.CursorManager.PushMode(cursorRoomBuild);
			cursorRoomBuild.HideInvalidItemBounds();
			CursorRoomMove cursorRoomMove = new CursorRoomMove(_level.CursorManager, _level, _worldState, _buildEvents, _newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual, landscapeEdit: false);
			_level.CursorManager.PushMode(cursorRoomMove);
			cursorRoomMove.InitializeForCopy();
			_currentState = State.NewRoom;
			_newRoomState.BlueprintFloorPlan.DisableItemEffects();
			_buildEvents.OnEnterNewRoomState.InvokeSafe(_newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual);
			_level.HospitalHUDManager.InitializeForRoomCopy(definition._type, _newRoomState.BlueprintFloorPlan, playSFX: false);
		}

		public void TransitionToEditRoomObjectsState(Room room)
		{
			LeaveCurrentState(applyChanges: false);
			_editRoomObjectsState.FloorPlan = room.FloorPlan;
			_editRoomObjectsState.ItemBeingEdited = null;
			_editRoomObjectsState.BlueprintFloorPlanVisual = room.FloorPlanVisual as BlueprintFloorPlanVisual;
			_currentState = State.EditRoomObjects;
			_buildEvents.OnRoomEditRoomObjectsState(room);
		}

		public void StartEditingRoomObject(RoomItem roomItem)
		{
			_editRoomObjectsState.ItemBeingEdited = roomItem;
		}

		public void StopEditingRoomObject(RoomItem roomItem)
		{
			_editRoomObjectsState.ItemBeingEdited = null;
		}

		private void LeaveCurrentState(bool applyChanges)
		{
			State currentState = _currentState;
			_currentState = State.Transitioning;
			_level.CursorManager.PopMode<CursorRoomItem>();
			_level.CursorManager.PopMode<CursorRoomMove>();
			_level.CursorManager.PopMode<CursorRoomBuild>();
			switch (currentState)
			{
			case State.NewRoom:
				if (!applyChanges)
				{
					int param = GameAlgorithms.CalculateRoomItemsRefund(_newRoomState.BlueprintFloorPlan);
					_buildEvents.OnRoomCancelled.InvokeSafe(null, param);
				}
				else
				{
					Room room = new Room(_newRoomState.BlueprintFloorPlan.Definition, _level);
					ApplyRoomChanges(room, new FloorPlan(_newRoomState.BlueprintFloorPlan, room), _newRoomState.WallVisualOverride, _newRoomState.FloorVisualOverride);
					_buildEvents.OnNewRoomBuiltEvent.InvokeSafe(room);
				}
				_newRoomState.FloorVisualOverride = null;
				_newRoomState.WallVisualOverride = null;
				if (_newRoomState.BlueprintFloorPlan != null)
				{
					_newRoomState.BlueprintFloorPlan.Destroy();
					_newRoomState.BlueprintFloorPlan = null;
				}
				if (_newRoomState.BlueprintFloorPlanVisual != null)
				{
					_newRoomState.BlueprintFloorPlanVisual.Destroy();
					_newRoomState.BlueprintFloorPlanVisual = null;
				}
				break;
			case State.EditRoomBlueprint:
				if (applyChanges)
				{
					Room roomBeingEdited = _editRoomBlueprintState.RoomBeingEdited;
					ApplyRoomChanges(roomBeingEdited, new FloorPlan(_editRoomBlueprintState.BlueprintFloorPlan, roomBeingEdited), _editRoomBlueprintState.WallVisualOverride, _editRoomBlueprintState.FloorVisualOverride);
				}
				else
				{
					int num = GameAlgorithms.CalculateRoomItemsRefund(_editRoomBlueprintState.BlueprintFloorPlan);
					num -= GameAlgorithms.CalculateRoomItemsRefund(_editRoomBlueprintState.RoomBeingEdited.FloorPlan);
					_buildEvents.OnRoomCancelled.InvokeSafe(_editRoomBlueprintState.RoomBeingEdited, num);
					_worldState.AddRoom(_editRoomBlueprintState.RoomBeingEdited, animateWalls: false);
					_editRoomBlueprintState.RoomBeingEdited.SetVisible(visible: true);
					_editRoomBlueprintState.RoomBeingEdited.FloorPlan.AddItemsToWorld();
					_editRoomBlueprintState.RoomBeingEdited.Open();
					_level.WorldState.BuildRoom(_editRoomBlueprintState.RoomBeingEdited, 0);
				}
				_editRoomBlueprintState.RoomBeingEdited = null;
				if (_editRoomBlueprintState.BlueprintFloorPlan != null)
				{
					_editRoomBlueprintState.BlueprintFloorPlan.Destroy();
					_editRoomBlueprintState.BlueprintFloorPlan = null;
				}
				if (_editRoomBlueprintState.BlueprintFloorPlanVisual != null)
				{
					_editRoomBlueprintState.BlueprintFloorPlanVisual.Destroy();
					_editRoomBlueprintState.BlueprintFloorPlanVisual = null;
				}
				break;
			case State.EditRoomObjects:
				_editRoomObjectsState.FloorPlan = null;
				if (_editRoomObjectsState.ItemBeingEdited != null)
				{
					_editRoomObjectsState.ItemBeingEdited.Destroy();
					_editRoomObjectsState.ItemBeingEdited = null;
				}
				_editRoomObjectsState.BlueprintFloorPlanVisual = null;
				break;
			}
			if (_editRoomObjectsState.ItemBeingEdited != null)
			{
				_editRoomObjectsState.ItemBeingEdited.Destroy();
				_editRoomObjectsState.ItemBeingEdited = null;
			}
		}

		public void TransitionToCopyRoomTemplateBlueprintState(RoomTemplate template)
		{
			RoomDefinition definition = template.TemplateFloorPlan.Definition;
			LeaveCurrentState(applyChanges: false);
			_newRoomState.BlueprintFloorPlan = new BlueprintFloorPlan(template.TemplateFloorPlan, _level, _level.WorldState.HospitalMaps[0]);
			PrepareDuplicatedFloorPlan(_newRoomState.BlueprintFloorPlan);
			_newRoomState.BlueprintFloorPlanVisual = new BlueprintFloorPlanVisual(_worldState, _visualManager, _dataViewManager, _config.RoomItemEditConfig, _level.BuildEvents, "Blueprint", _config.BlueprintFloorTilePrefab, definition._blueprintWallDefinition.Instance, _config.BlueprintFloorMaterialValid, _config.BlueprintFloorMaterialInvalid, _config.BlueprintFloorMaterialInvalidSize);
			if (template.FloorVisualOverride != null && !template.DisableFloorVisualOverride)
			{
				_newRoomState.FloorVisualOverride = template.FloorVisualOverride;
			}
			if (template.WallVisualOverride != null && !template.DisableWallVisualOverride)
			{
				_newRoomState.WallVisualOverride = template.WallVisualOverride;
			}
			_buildEvents.OnBeginNewRoom.InvokeSafe(definition);
			_level.CursorManager.PopMode<CursorRoomBuild>();
			CursorRoomBuild cursorRoomBuild = new CursorRoomBuild(_level.CursorManager, _level, _level.Config.GetCursorRoomBuildConfig(), _newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual);
			_level.CursorManager.PushMode(cursorRoomBuild);
			cursorRoomBuild.HideInvalidItemBounds();
			CursorRoomMove cursorRoomMove = new CursorRoomMove(_level.CursorManager, _level, _worldState, _buildEvents, _newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual, landscapeEdit: false);
			_level.CursorManager.PushMode(cursorRoomMove);
			cursorRoomMove.InitializeForCopy();
			_currentState = State.NewRoom;
			_newRoomState.BlueprintFloorPlan.DisableItemEffects();
			_buildEvents.OnEnterNewRoomState.InvokeSafe(_newRoomState.BlueprintFloorPlan, _newRoomState.BlueprintFloorPlanVisual);
			_level.HospitalHUDManager.InitializeForRoomCopy(definition._type, _newRoomState.BlueprintFloorPlan, playSFX: false);
			GameEvent gameEvent = new GameEvent(_level.App.AnalyticsManager.Config.RoomTemplatePlaced).AddLevelHeader(_level).AddParam("roomType", template.RoomType.ToString()).AddParam("numItems", template.TemplateFloorPlan.Items.Count)
				.AddParam("numRemovedItems", template.TemplateFloorPlan.InLevelItemsToRemove.Count + template.TemplateFloorPlan.DLCItemsToRemove.Count)
				.AddParam("hasDisabledVisualOverrides", template.DisableFloorVisualOverride || template.DisableWallVisualOverride);
			_level.App.AnalyticsManager.RecordEvent(gameEvent);
		}

		public void TransitionToNullState(bool applyChanges)
		{
			State currentState = _currentState;
			LeaveCurrentState(applyChanges);
			_currentState = State.Null;
			_buildEvents.OnEnterNullState.InvokeSafe(currentState, applyChanges);
			if (currentState == State.NewRoom || currentState == State.EditRoomObjects || currentState == State.EditRoomBlueprint)
			{
				if (applyChanges)
				{
					_buildEvents.OnAcceptRoom.InvokeSafe();
				}
				else
				{
					_buildEvents.OnCancelRoom.InvokeSafe();
				}
			}
		}

		private void ApplyRoomChanges(Room roomBeingEdited, FloorPlan newFloorPlan, IWallVisualOverrideDefinition wallVisualOverride, IFloorVisualOverrideDefinition floorVisualOverride)
		{
			RoomDefinition definition = newFloorPlan.Definition;
			FloorPlan floorPlan = roomBeingEdited.FloorPlan;
			RoomFloorPlanVisual roomFloorPlanVisual = new RoomFloorPlanVisual(_worldState, _visualManager, definition.ToString(), definition.GetFloorTile(_worldState), _dataViewManager.ValueMaterial, _config.RoomItemEditConfig, definition._wallsInterior, _level.BuildEvents)
			{
				FloorVisualOverride = floorVisualOverride,
				WallVisualOverride = wallVisualOverride
			};
			int num = ((floorPlan == null) ? newFloorPlan.Definition._cost : 0);
			foreach (RoomItem item in newFloorPlan.Items)
			{
				if (!item.HasBeenPurchased)
				{
					num += item.Cost;
				}
			}
			roomBeingEdited.Initialise(newFloorPlan, roomFloorPlanVisual);
			newFloorPlan.AddItemsToWorld(updateNavigation: false);
			foreach (RoomItem item2 in newFloorPlan.Items)
			{
				item2.HasBeenPurchased = true;
			}
			_worldState.AddRoom(roomBeingEdited, animateWalls: true);
			roomFloorPlanVisual.UpdateFromRoom(newFloorPlan);
			roomFloorPlanVisual.TriggerConstructionAnimations(newFloorPlan.Anchor);
			roomFloorPlanVisual.DisableParticleEffects();
			newFloorPlan.DisableItemEffects();
			RoomAlgorithms.IterateRoomItemsWithComponent(roomBeingEdited, delegate(DebrisEffectComponent component)
			{
				component.Destroy();
			});
			roomBeingEdited.Close();
			roomBeingEdited.Open();
			_level.WorldState.BuildRoom(roomBeingEdited, num);
			RoomAlgorithms.MoveOverlappingItemsOutOfRoom(newFloorPlan, _worldState);
			RoomItemAlgorithms.RefreshInvalidItemBounds(newFloorPlan);
			RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, null, newFloorPlan.HospitalMap.FloorPlan, _worldState, null, null);
		}

		public void ChangeRoomBuildMode(CursorRoomBuild.RoomAreaDragOperation operation)
		{
			FloorPlan floorPlan = null;
			BlueprintFloorPlanVisual floorPlanVisual = null;
			switch (_currentState)
			{
			case State.EditRoomBlueprint:
				floorPlan = _editRoomBlueprintState.BlueprintFloorPlan;
				floorPlanVisual = _editRoomBlueprintState.BlueprintFloorPlanVisual;
				break;
			case State.NewRoom:
				floorPlan = _newRoomState.BlueprintFloorPlan;
				floorPlanVisual = _newRoomState.BlueprintFloorPlanVisual;
				break;
			}
			if (_level.CursorManager.IsModeActive<CursorRoomItem>())
			{
				if (floorPlan is BlueprintFloorPlan blueprintFloorPlan)
				{
					blueprintFloorPlan.AutoFlowActive = false;
				}
				_level.CursorManager.PopMode<CursorRoomItem>();
			}
			if (!_level.CursorManager.TryGetActiveMode<CursorRoomBuild>(out var activeMode))
			{
				_level.CursorManager.PopMode<CursorRoomItem>();
				activeMode = new CursorRoomBuild(_level.CursorManager, _level, _level.Config.GetCursorRoomBuildConfig(), floorPlan as BlueprintFloorPlan, floorPlanVisual);
				_level.CursorManager.PushMode(activeMode);
			}
			activeMode.DragOperation = operation;
			_level.BuildEvents.OnBuildModeChanged.InvokeSafe(operation);
		}

		public void TryAcceptRoomChanges()
		{
			BlueprintFloorPlan blueprintFloorPlan = CurrentFloorPlan as BlueprintFloorPlan;
			if (blueprintFloorPlan == null || blueprintFloorPlan.ItemsToSell.Count == 0)
			{
				AcceptRoomChanges();
				return;
			}
			int sellCost = 0;
			int numItems = 0;
			foreach (RoomItem item in blueprintFloorPlan.ItemsToSell)
			{
				if (item.Cost != 0)
				{
					numItems++;
					if (item.FloorPlan != blueprintFloorPlan || item.HasBeenPurchased)
					{
						sellCost += item.SellValue();
					}
				}
			}
			if (numItems == 0)
			{
				AcceptRoomChanges();
				return;
			}
			NotificationDynamicMessage sellItemsMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions._sellInvalidItemsMessage.Instance, delegate(int response)
			{
				if (response == 0)
				{
					SellInvalidItems(blueprintFloorPlan);
					AcceptRoomChanges();
				}
			}, _level);
			sellItemsMessage.FuncGetMessage = () => LocalisedString.Replace(sellItemsMessage.Definition.LocalisedText.Translation, new SubPair[2]
			{
				new SubPair("{[COUNT]}", numItems),
				new SubPair("{[COST]}", StringUtils.FormatCurrency(sellCost))
			});
			_level.Notifications.OpenPopup(sellItemsMessage);
		}

		private void AcceptRoomChanges()
		{
			if (_currentState != State.Null)
			{
				TransitionToNullState(applyChanges: true);
			}
			_level.HospitalHUDManager.TryHideRibbonMenu();
		}

		private void SellInvalidItems(BlueprintFloorPlan floorPlan)
		{
			RoomItem[] array = floorPlan.ItemsToSell.ToArray();
			foreach (RoomItem roomItem in array)
			{
				if (roomItem.Cost != 0)
				{
					if (roomItem.FloorPlan != floorPlan || roomItem.HasBeenPurchased)
					{
						_level.BuildEvents.OnRoomItemSold.InvokeSafe(roomItem);
					}
					_level.BuildEvents.OnRoomItemDestroy.InvokeSafe(roomItem);
				}
			}
			floorPlan.ValidateWindows();
			floorPlan.RecalculateWalls();
		}

		public RoomBuildingNavMesh GetRoomBuildingNavMesh(HospitalMap hospitalMap)
		{
			_roomBuildingNavMeshRefCount++;
			if (_roomBuildingNavMesh == null)
			{
				_roomBuildingNavMesh = new RoomBuildingNavMesh(hospitalMap, _worldState.Anchor, 255);
			}
			else if (_roomBuildingNavMesh.HospitalMap != hospitalMap)
			{
				_roomBuildingNavMesh.Destroy();
				_roomBuildingNavMesh = new RoomBuildingNavMesh(hospitalMap, _worldState.Anchor, 255);
			}
			return _roomBuildingNavMesh;
		}

		public void ReleaseRoomBuildingNavMesh()
		{
			_roomBuildingNavMeshRefCount--;
			if (_roomBuildingNavMeshRefCount == 0)
			{
				_roomBuildingNavMesh.Destroy();
				_roomBuildingNavMesh = null;
			}
		}

		private static void ResetInvalidAndToSellItems(BlueprintFloorPlan floorPlan)
		{
			floorPlan.InvalidItems.Clear();
			floorPlan.ItemsToSell.Clear();
		}

		public static void PrepareDuplicatedFloorPlan(BlueprintFloorPlan floorPlan)
		{
			ResetInvalidAndToSellItems(floorPlan);
			for (int num = floorPlan.Items.Count - 1; num >= 0; num--)
			{
				RoomItem roomItem = floorPlan.Items[num];
				if (roomItem.Definition.ItemType == RoomItemDefinition.Type.Special || roomItem.Definition.ItemType == RoomItemDefinition.Type.PlotObject)
				{
					roomItem.Destroy();
					floorPlan.Items.Remove(roomItem);
				}
				else
				{
					roomItem.HasBeenPurchased = false;
					if (roomItem.UpgradeLevel != 0)
					{
						roomItem.Downgrade();
					}
					if (roomItem.MaintenanceLevel != null)
					{
						roomItem.MaintenanceLevel.SetValue(0f, callCallbacks: false);
					}
					roomItem.RemoveComponents<RoomItemUpgradeComponent>();
					roomItem.GetComponent<ResearchProjectComponent>()?.ClearProject();
				}
			}
		}

		public void GetInvalidItemsOnRoomEditCancel(ref List<RoomItem> invalidItems)
		{
			invalidItems.Clear();
			if (_currentState != State.EditRoomBlueprint)
			{
				return;
			}
			FloorPlan floorPlan = _editRoomBlueprintState.RoomBeingEdited.FloorPlan;
			FloorPlan floorPlan2 = floorPlan.HospitalMap.FloorPlan;
			for (int i = 0; i < floorPlan.Height(); i++)
			{
				for (int j = 0; j < floorPlan.Width(); j++)
				{
					if (!floorPlan[j, i])
					{
						continue;
					}
					GridCoord gridCoord = floorPlan.Anchor + new GridCoord(j, i);
					List<RoomItem> itemsAtCoord = floorPlan2.GetItemsAtCoord(gridCoord - floorPlan2.Anchor);
					if (itemsAtCoord == null)
					{
						continue;
					}
					foreach (RoomItem item in itemsAtCoord)
					{
						if (item.Definition.CanBeSoldWhenBuiltOver())
						{
							invalidItems.AddUnique(item);
						}
					}
				}
			}
		}

		public bool IsRoomItemBeingEdited(RoomItem roomItem)
		{
			if (_currentState == State.EditRoomObjects && _editRoomObjectsState.ItemBeingEdited == roomItem)
			{
				return true;
			}
			if (CurrentFloorPlan == roomItem.FloorPlan)
			{
				return true;
			}
			if (_level.CursorManager.TryGetActiveMode<CursorRoomItem>(out var activeMode) && activeMode.RoomItem == roomItem)
			{
				return true;
			}
			return false;
		}
	}
}
