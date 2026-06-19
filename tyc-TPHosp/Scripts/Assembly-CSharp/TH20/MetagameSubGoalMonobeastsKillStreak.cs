using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalMonobeastsKillStreak : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionMonobeastsKillStreak _definition;

		[SerializeField]
		private int _highestKillStreak;

		public MetagameSubGoalMonobeastsKillStreak(Objective owner, MetagameSubGoalDefinitionMonobeastsKillStreak definition)
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
			_highestKillStreak = Mathf.Max(_highestKillStreak, killStreak);
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _highestKillStreak >= _definition.TargetKillstreak;
		}

		public override float PercentComplete()
		{
			return (float)_highestKillStreak / (float)_definition.TargetKillstreak;
		}

		public override int Score()
		{
			return _highestKillStreak;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_highestKillStreak} / {_definition.TargetKillstreak}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
