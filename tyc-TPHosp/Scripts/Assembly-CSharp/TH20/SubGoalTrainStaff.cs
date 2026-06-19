using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalTrainStaff : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionTrainStaff _definition;

		private int _currentTrainingCount;

		public SubGoalTrainStaff(Objective owner, SubGoalDefinitionTrainStaff definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionTrainStaff;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionTrainStaff)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			base.OnEnd();
		}

		private void OnStaffQualificationComplete(Staff staff, QualificationDefinition qualification, Staff trainer)
		{
			if ((_definition.StaffType == null || staff.Definition == _definition.StaffType.Instance) && (_definition.QualificationType == null || qualification == _definition.QualificationType.Instance))
			{
				_currentTrainingCount++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentTrainingCount >= _definition.TargetTrainingCount;
		}

		public override float PercentComplete()
		{
			return (float)_currentTrainingCount / (float)_definition.TargetTrainingCount;
		}

		public override int Score()
		{
			return _currentTrainingCount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentTrainingCount} / {_definition.TargetTrainingCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
