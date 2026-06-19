using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalPromoteStaff : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private int _numPromoted;

		[SerializeField]
		private readonly MetagameSubGoalDefinitionPromoteStaff _definition;

		public MetagameSubGoalPromoteStaff(Objective owner, MetagameSubGoalDefinitionPromoteStaff definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffPromoted = (Action<Staff>)Delegate.Combine(levelEventsIntermediary.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffPromoted = (Action<Staff>)Delegate.Remove(levelEventsIntermediary.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnStaffPromoted = (Action<Staff>)Delegate.Combine(levelEventsIntermediary2.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}
		}

		protected override void OnEnd()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnStaffPromoted = (Action<Staff>)Delegate.Remove(levelEventsIntermediary.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}
			base.OnEnd();
		}

		private void OnStaffPromoted(Staff staff)
		{
			if (_definition.StaffType == null || staff.Definition == _definition.StaffType.Instance)
			{
				_numPromoted++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numPromoted >= _definition.TargetNumPromotions;
		}

		public override float PercentComplete()
		{
			return (float)_numPromoted / (float)_definition.TargetNumPromotions;
		}

		public override int Score()
		{
			return _numPromoted;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numPromoted} / {_definition.TargetNumPromotions}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
