using System;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WaitForNextCharacter : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public bool _waiting;

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

		[Tooltip("Character")]
		public SharedCharacterRef _character;

		private bool _waiting;

		public override void OnStart()
		{
			base.OnStart();
			_character.Value = null;
			_waiting = true;
			CharacterEvents characterEvents = base.Character.Level.CharacterEvents;
			characterEvents.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Combine(characterEvents.OnPlanToEnterRoom, new Action<Character, Room>(OnEnterRoom));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_waiting)
			{
				CharacterEvents characterEvents = base.Character.Level.CharacterEvents;
				characterEvents.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Combine(characterEvents.OnPlanToEnterRoom, new Action<Character, Room>(OnEnterRoom));
			}
		}

		public override void OnEnd()
		{
			_waiting = false;
			CharacterEvents characterEvents = base.Character.Level.CharacterEvents;
			characterEvents.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Remove(characterEvents.OnPlanToEnterRoom, new Action<Character, Room>(OnEnterRoom));
			base.OnEnd();
		}

		private void OnEnterRoom(Character character, Room room)
		{
			_character.Value = new CharacterRef(character);
		}

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				if (_character.IsValid() && _character.Get.RoomUsing == _room.Get && _character.Get.Interaction == null)
				{
					return TaskStatus.Success;
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Failure;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_waiting = _waiting
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_waiting = saveState._waiting;
		}
	}
}
