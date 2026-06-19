using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeLevelObjectiveCompleteMaintenanceJobs : StaffChallengeLevelObjective
	{
		private int _numberOfJobsComplete;

		private readonly StaffChallengeSubGoalDefinitionCompleteMaintenanceJobs _definition;

		public StaffChallengeLevelObjectiveCompleteMaintenanceJobs(Objective owner, StaffChallengeSubGoalDefinitionCompleteMaintenanceJobs definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			base.OnStart();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			base.OnEnd();
		}

		private void OnStaffCompletedJob(Staff staff, Job job, bool success)
		{
			if (success && staff == _challenge.Staff && job is JobMaintenance jobMaintenance && jobMaintenance.Item.Definition.MaintenanceDescription == _definition.JobType)
			{
				_numberOfJobsComplete++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numberOfJobsComplete >= _definition.NumOfJobs;
		}

		public override float PercentComplete()
		{
			return (float)_numberOfJobsComplete / (float)_definition.NumOfJobs;
		}

		public override int Score()
		{
			return _numberOfJobsComplete;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numberOfJobsComplete} / {_definition.NumOfJobs}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
