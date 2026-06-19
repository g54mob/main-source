using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalCharacterModifier : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionCharacterModifier _definition;

		private int _currentAmount;

		public SubGoalCharacterModifier(Objective owner, SubGoalDefinitionCharacterModifier definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionCharacterModifier;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionCharacterModifier)base.Definition;
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
				characterEvents.OnStaffAttributeModified = (Action<Staff, CharacterAttributes.Type>)Delegate.Combine(characterEvents.OnStaffAttributeModified, new Action<Staff, CharacterAttributes.Type>(OnCharacterAttributeModified));
			}
			if (_definition.CharacterType == CharacterType.Patient || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientAttributeModified = (Action<Patient, CharacterAttributes.Type>)Delegate.Combine(characterEvents2.OnPatientAttributeModified, new Action<Patient, CharacterAttributes.Type>(OnCharacterAttributeModified));
			}
		}

		private void UnregisterCallbacks()
		{
			if (_definition.CharacterType == CharacterType.Staff || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffAttributeModified = (Action<Staff, CharacterAttributes.Type>)Delegate.Remove(characterEvents.OnStaffAttributeModified, new Action<Staff, CharacterAttributes.Type>(OnCharacterAttributeModified));
			}
			if (_definition.CharacterType == CharacterType.Patient || _definition.CharacterType == CharacterType.Any)
			{
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientAttributeModified = (Action<Patient, CharacterAttributes.Type>)Delegate.Remove(characterEvents2.OnPatientAttributeModified, new Action<Patient, CharacterAttributes.Type>(OnCharacterAttributeModified));
			}
		}

		private void OnCharacterAttributeModified(Character character, CharacterAttributes.Type modifierType)
		{
			if (modifierType == _definition.ModifierType)
			{
				_currentAmount++;
				Level.ObjectiveEvents.OnSubGoalUpdated(this);
			}
		}

		protected override bool HasCompleted()
		{
			return _currentAmount >= _definition.TargetAmount;
		}

		public override float PercentComplete()
		{
			return (float)_currentAmount / (float)_definition.TargetAmount;
		}

		public override int Score()
		{
			return _currentAmount;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			if (_definition.ProgressLocText.Term != null)
			{
				return _definition.ProgressLocText.Translation.Replace("{[COUNT]}", StringUtils.FormatNumber(_definition.TargetAmount - _currentAmount));
			}
			return null;
		}
	}
}
