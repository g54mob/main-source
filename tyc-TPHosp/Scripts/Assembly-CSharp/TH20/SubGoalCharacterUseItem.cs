using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalCharacterUseItem : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionCharacterUseItem _definition;

		private int _currentAmount;

		public SubGoalCharacterUseItem(Objective owner, SubGoalDefinitionCharacterUseItem definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionCharacterUseItem;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionCharacterUseItem)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterCallbacks();
			}
		}

		protected override void OnStart()
		{
			RegisterCallbacks();
			_currentAmount = 0;
			base.OnStart();
		}

		protected override void OnEnd()
		{
			UnregisterCallbacks();
			base.OnEnd();
		}

		private void RegisterCallbacks()
		{
			if (_definition.CharacterType == CharacterType.Staff || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffUsedItem = (Action<Staff, RoomItem>)Delegate.Combine(characterEvents.OnStaffUsedItem, new Action<Staff, RoomItem>(OnCharacterUsedItem));
			}
			if (_definition.CharacterType == CharacterType.Patient || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientUsedItem = (Action<Patient, RoomItem>)Delegate.Combine(characterEvents2.OnPatientUsedItem, new Action<Patient, RoomItem>(OnCharacterUsedItem));
			}
		}

		private void UnregisterCallbacks()
		{
			if (_definition.CharacterType == CharacterType.Staff || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffUsedItem = (Action<Staff, RoomItem>)Delegate.Remove(characterEvents.OnStaffUsedItem, new Action<Staff, RoomItem>(OnCharacterUsedItem));
			}
			if (_definition.CharacterType == CharacterType.Patient || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientUsedItem = (Action<Patient, RoomItem>)Delegate.Remove(characterEvents2.OnPatientUsedItem, new Action<Patient, RoomItem>(OnCharacterUsedItem));
			}
		}

		private void OnCharacterUsedItem(Character character, RoomItem item)
		{
			if ((_definition.Item != null && item.Definition == _definition.Item.Instance) || ItemExistsInList(item))
			{
				_currentAmount++;
				Level.ObjectiveEvents.OnSubGoalUpdated(this);
			}
		}

		private bool ItemExistsInList(RoomItem item)
		{
			if (_definition.ItemList != null)
			{
				foreach (SharedInstance<RoomItemDefinition> item2 in _definition.ItemList)
				{
					if (item.Definition == item2.Instance)
					{
						return true;
					}
				}
			}
			return false;
		}

		protected override bool HasCompleted()
		{
			return _currentAmount >= _definition.ItemCount;
		}

		public override float PercentComplete()
		{
			return (float)_currentAmount / (float)_definition.ItemCount;
		}

		public override int Score()
		{
			return _currentAmount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentAmount} / {_definition.ItemCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
