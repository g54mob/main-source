using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeLevelObjectiveQualification : StaffChallengeLevelObjective
	{
		private bool _qualificationLearnt;

		private readonly StaffChallengeSubGoalDefinitionQualification _definition;

		public StaffChallengeLevelObjectiveQualification(Objective owner, StaffChallengeSubGoalDefinitionQualification definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			base.OnStart();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			base.OnEnd();
		}

		private void OnStaffQualificationComplete(Staff staff, QualificationDefinition qualification, Staff trainer)
		{
			if (staff == _challenge.Staff && (_definition.Qualification == null || _definition.Qualification.Instance == qualification))
			{
				_qualificationLearnt = true;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _qualificationLearnt;
		}

		public override float PercentComplete()
		{
			return Completed() ? 1 : 0;
		}

		public override int Score()
		{
			if (!Completed())
			{
				return 0;
			}
			return 1;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return "";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
