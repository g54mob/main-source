using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalMaintenanceJob : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionMaintenanceJob _definition;

		[SerializeField]
		private int _numberOfJobsComplete;

		[SerializeField]
		private int _numGhostsCaptured;

		public MetagameSubGoalMaintenanceJob(Objective owner, MetagameSubGoalDefinitionMaintenanceJob definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			base.OnStart();
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(levelEventsIntermediary.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(levelEventsIntermediary.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(levelEventsIntermediary2.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(levelEventsIntermediary.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}
			base.Destroy();
		}

		private void OnStaffCompletedJob(Staff staff, Job job, bool success)
		{
			if (job is JobMaintenance jobMaintenance && jobMaintenance.Item.Definition.MaintenanceDescription == _definition.JobType && success)
			{
				_numberOfJobsComplete++;
				UpdateProgress();
			}
			if (job is JobGhost && _definition.JobType == JobMaintenance.JobDescription.Ghost)
			{
				_numberOfJobsComplete++;
				_numGhostsCaptured++;
				UpdateProgress();
				PlatformStatsAndAchievements.SetStatValue(Stat.GhostsCaptured, _numGhostsCaptured);
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
