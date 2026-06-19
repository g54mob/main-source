using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalTrainStaff : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionTrainStaff _definition;

		[SerializeField]
		private int _currentTrainingCount;

		public MetagameSubGoalTrainStaff(Objective owner, MetagameSubGoalDefinitionTrainStaff definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(levelEventsIntermediary.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(levelEventsIntermediary.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(levelEventsIntermediary2.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(levelEventsIntermediary.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}
			base.Destroy();
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
