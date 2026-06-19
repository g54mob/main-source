using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalMaintenanceJob : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalMaintenanceJobDefinition _definition;

		private int _numberOfJobsComplete;

		public SubGoalMaintenanceJob(Objective owner, SubGoalMaintenanceJobDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalMaintenanceJobDefinition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalMaintenanceJobDefinition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			base.OnEnd();
		}

		private void OnStaffCompletedJob(Staff staff, Job job, bool success)
		{
			if (success)
			{
				if (job is JobMaintenance jobMaintenance && jobMaintenance.Item.Definition.MaintenanceDescription == _definition.JobType)
				{
					_numberOfJobsComplete++;
					UpdateProgress();
				}
				if (job is JobGhost && _definition.JobType == JobMaintenance.JobDescription.Ghost)
				{
					_numberOfJobsComplete++;
					UpdateProgress();
				}
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
