using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalMonobeastsKill : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionMonobeastsKill _definition;

		[SerializeField]
		private int _killCount;

		public MetagameSubGoalMonobeastsKill(Objective owner, MetagameSubGoalDefinitionMonobeastsKill definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Combine(levelEventsIntermediary.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Remove(levelEventsIntermediary.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Combine(levelEventsIntermediary2.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Remove(levelEventsIntermediary.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			}
			base.Destroy();
		}

		private void OnMonoBeastShot(MonoBeast monoBeast, int killStreak)
		{
			_killCount++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _killCount >= _definition.TargetKills;
		}

		public override float PercentComplete()
		{
			return (float)_killCount / (float)_definition.TargetKills;
		}

		public override int Score()
		{
			return _killCount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_killCount} / {_definition.TargetKills}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
