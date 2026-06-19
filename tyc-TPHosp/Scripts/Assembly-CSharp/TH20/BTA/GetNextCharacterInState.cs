using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[TaskDescription("Searches for a character using the room in the specified state.\nReturns failure if there's no results")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetNextCharacterInState : CharacterAction
	{
		[SerializeField]
		private string _state;

		[SerializeField]
		private string[] _states;

		[SerializeField]
		private SharedRoomRef _room;

		[SerializeField]
		private SharedCharacterRef _nextCharacter;

		public override void OnStart()
		{
			base.OnStart();
			_nextCharacter.Value = new CharacterRef(null);
		}

		private bool IsInState(Character character)
		{
			if (character is Patient patient && patient.IsLeavingHospital())
			{
				return false;
			}
			if (character.IsInState(_state))
			{
				return true;
			}
			if (_states != null)
			{
				string[] states = _states;
				foreach (string state in states)
				{
					if (character.IsInState(state))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				List<Character> list = new List<Character>();
				List<Character> list2 = new List<Character>();
				foreach (Character item in _room.Get.CharactersUsing)
				{
					if (IsInState(item))
					{
						list.Add(item);
						if (item.Interaction != null)
						{
							list2.Add(item);
						}
					}
				}
				if (list.Count != 0)
				{
					Character character = ((list2.Count != 0) ? list2.RandomItem() : list.RandomItem());
					_nextCharacter.Value = new CharacterRef(character);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
