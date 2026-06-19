#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ExitRoom : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public int _roomExitingPtrID;

			public bool _roomWasEdited;

			public int _interactionControllerID;

			public bool _waiting;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		private EntityPtr<Room> _roomExitingPtr = new EntityPtr<Room>();

		private bool _roomWasEdited;

		private int _interactionControllerID;

		private bool _waiting;

		private static readonly List<ObjectInteraction> _interactionsCache = new List<ObjectInteraction>(32);

		private static readonly string _exitObjectInteractionName = "Exit";

		public override void OnStart()
		{
			Character character = base.Character;
			character.Interruptable = false;
			_waiting = true;
			_roomWasEdited = false;
			_interactionControllerID = -1;
			BuildEvents buildEvents = character.Level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			Room room = character.RoomUsing;
			if (room == null || !room.IsCharacterInRoom(base.Character))
			{
				room = GetPotentialRoomExitingFrom(character);
			}
			if (!character.ShouldBehaviourAllowExitingOfRoom(room))
			{
				room = null;
			}
			if (room != null)
			{
				RoomItem door = room.FloorPlan.Door;
				if (door != null)
				{
					_interactionsCache.Clear();
					door.GetInterationsByName(_exitObjectInteractionName, _interactionsCache);
					if (_interactionsCache.Count != 0)
					{
						_interactionControllerID = character.InteractionControllers.Add(new InteractionController(character, _interactionsCache.RandomItem(), autoEnd: true));
						base.OnStart();
					}
					else
					{
						room.ExitRoom(character);
						room = null;
					}
					_interactionsCache.Clear();
				}
				else if (room.Definition.IsAmbulanceBayOnly)
				{
					room.ExitRoom(character);
					_interactionsCache.Clear();
					room = null;
				}
			}
			_roomExitingPtr.Set(room);
		}

		private static Room GetPotentialRoomExitingFrom(Character character)
		{
			foreach (Room allRoom in character.Level.WorldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay && !allRoom.Definition.IsHospitalUnbuilt && allRoom.IsCharacterInRoom(character))
				{
					return allRoom;
				}
			}
			return character.RoomUsing;
		}

		public override void OnEnd()
		{
			base.Character.Interruptable = true;
			_waiting = false;
			BuildEvents buildEvents = base.Character.Level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			Room room = _roomExitingPtr.Get(base.Character.Level);
			if (!base.Character.ShouldBehaviourAllowExitingOfRoom(room))
			{
				room = null;
			}
			if (room != null)
			{
				if (base.Character.RoomUsing == room && base.Character.InteractionControllers.Contains(_interactionControllerID) && base.Character.InteractionControllers.Get(_interactionControllerID).InteractionStarted)
				{
					TeleportToRoomEntrance(room);
				}
				if (room.IsCharacterInRoom(base.Character))
				{
					room.ExitRoom(base.Character);
				}
			}
			base.Character.InteractionControllers.Destroy(_interactionControllerID);
			_interactionControllerID = -1;
			_roomExitingPtr.Set(null);
			base.OnEnd();
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			if (roomBeingEdited == _roomExitingPtr.Get(base.Character.Level))
			{
				_roomWasEdited = true;
			}
		}

		public override TaskStatus OnUpdate()
		{
			Room room = _roomExitingPtr.Get(base.Character.Level);
			if (room == null || room.Definition.IsHospitalOrBay || room.HasBeenDestroyed() || _roomWasEdited)
			{
				return TaskStatus.Success;
			}
			if (base.Character.InteractionControllers.Contains(_interactionControllerID))
			{
				InteractionController interactionController = base.Character.InteractionControllers.Get(_interactionControllerID);
				if (!interactionController.InteractionStarted && base.Character.RoomUsing != room)
				{
					Logging.Warning(LogChannels.AI, "ExitRoom: {0} is in {1} and hasn't started {2} door interaction", base.Character, base.Character.RoomUsing, room);
					return TaskStatus.Success;
				}
				TaskStatus num = interactionController.OnUpdate();
				if (num == TaskStatus.Failure)
				{
					TeleportToRoomEntrance(room);
					room.ExitRoom(base.Character);
				}
				return num;
			}
			return TaskStatus.Failure;
		}

		private void TeleportToRoomEntrance(Room room)
		{
			if (!room.Definition.IsHospitalOrBay)
			{
				RoomItem door = room.FloorPlan.Door;
				if (door != null)
				{
					Vector3 vector = RoomItemAlgorithms.CalculateDoorEnter(door);
					Logging.Warning(LogChannels.AI, "ExitRoom: Teleported {0} as they failed to exit room {1}. Current behavior: {2}. Teleport distance: {3}", base.Character, room, base.Character.BehaviorTree ? base.Character.BehaviorTree.ToString() : "none", Mathf.Sqrt(base.Character.Position.SquareDistance2D(vector)));
					base.Character.Position = vector;
					base.Character.NavPath.Warp(vector);
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_waiting)
			{
				BuildEvents buildEvents = base.Character.Level.BuildEvents;
				buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			}
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_roomExitingPtrID = _roomExitingPtr.ID,
				_roomWasEdited = _roomWasEdited,
				_interactionControllerID = _interactionControllerID,
				_waiting = _waiting
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_roomExitingPtr.ID = saveState._roomExitingPtrID;
			_roomWasEdited = saveState._roomWasEdited;
			_interactionControllerID = saveState._interactionControllerID;
			_waiting = saveState._waiting;
		}
	}
}
