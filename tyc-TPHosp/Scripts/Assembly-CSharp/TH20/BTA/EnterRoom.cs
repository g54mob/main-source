#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class EnterRoom : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public int _interactionControllerID;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Reason entering")]
		public ReasonUseRoom _reason;

		[Tooltip("Reason entering")]
		public SharedReasonUseRoomRef _reasonRef;

		[Tooltip("Was no door?")]
		public SharedBool _outNoDoor;

		private int _interactionControllerID;

		private static List<ObjectInteraction> _interactionsCache = new List<ObjectInteraction>(32);

		private static string _interactionEnterName = "Enter";

		private bool IsInRoom()
		{
			if (_room.Get != base.Character.RoomUsing)
			{
				return _room.Get.Definition.IsHospitalOrBay;
			}
			return true;
		}

		private ReasonUseRoom GetReasonUsingRoom()
		{
			if (_reasonRef.IsValid())
			{
				return _reasonRef.Get;
			}
			return _reason;
		}

		public override void OnStart()
		{
			_interactionControllerID = -1;
			if (!_room.IsValid())
			{
				return;
			}
			if (IsInRoom())
			{
				if (!_room.Get.Definition.IsHospitalOrBay)
				{
					_room.Get.EnterRoom(base.Character, GetReasonUsingRoom());
				}
				return;
			}
			RoomItem door = _room.Get.FloorPlan.Door;
			_outNoDoor.Value = true;
			if (door != null)
			{
				_interactionsCache.Clear();
				door.GetInterationsByName(_interactionEnterName, _interactionsCache);
				if (_interactionsCache.Count != 0)
				{
					_interactionControllerID = base.Character.InteractionControllers.Add(new InteractionController(base.Character, _interactionsCache.RandomItem(), autoEnd: true));
					_outNoDoor.Value = false;
				}
				else
				{
					_room.Get.EnterRoom(base.Character, GetReasonUsingRoom());
				}
				_interactionsCache.Clear();
			}
			else if (_room.Get.Definition.IsAmbulanceBayOnly)
			{
				_room.Get.EnterRoom(base.Character, GetReasonUsingRoom());
				_interactionsCache.Clear();
			}
		}

		public override void OnEnd()
		{
			base.Character.InteractionControllers.Destroy(_interactionControllerID);
			_interactionControllerID = -1;
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			if (!_room.IsValid())
			{
				return TaskStatus.Failure;
			}
			Character character = base.Character;
			if (!character.InteractionControllers.Contains(_interactionControllerID))
			{
				return TaskStatus.Success;
			}
			InteractionController interactionController = character.InteractionControllers.Get(_interactionControllerID);
			if (character.Interaction != null && interactionController.Interaction != character.Interaction)
			{
				Logging.Warning(LogChannels.AI, "EnterRoom: {0} interacting with {1} while entering room {2} - ending interaction", base.Character, character.Interaction, _room.Get);
				character.Interaction.EndInteraction(character);
			}
			TaskStatus taskStatus = interactionController.OnUpdate();
			if (taskStatus == TaskStatus.Success && !_room.Get.EnterRoom(character, GetReasonUsingRoom()))
			{
				taskStatus = TaskStatus.Failure;
			}
			return taskStatus;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_interactionControllerID = _interactionControllerID
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_interactionControllerID = saveState._interactionControllerID;
		}
	}
}
