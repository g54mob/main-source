using System;
using I2.Loc;
using TH20.EventPlayableHospital;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalOrganisationValue : MetagameObjectiveSubGoal, Interface, IGameEventCallback
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionOrganisationValue _definition;

		[SerializeField]
		private int _foundationValue;

		public MetagameSubGoalOrganisationValue(Objective owner, MetagameSubGoalDefinitionOrganisationValue definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				Metagame.OnHospitalBecamePlayable.Add(this);
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiled));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				oldMetagame.OnHospitalBecamePlayable.Add(this);
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiled));
			}
			if (newMetagame != null)
			{
				newMetagame.OnHospitalBecamePlayable.Remove(this);
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelEventsIntermediary2.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiled));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				Metagame.OnHospitalBecamePlayable.Remove(this);
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiled));
			}
			base.Destroy();
		}

		public void OnHospitalBecamePlayableEvent(LevelConfig level)
		{
			_foundationValue = Metagame.TotalFoundationValue();
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.OrganisationValueReached, _foundationValue);
		}

		private void OnEndOfMonthStatsCompiled(LevelStatsDatabase.MonthStats stats)
		{
			_foundationValue = Metagame.TotalFoundationValue();
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.OrganisationValueReached, _foundationValue);
		}

		protected override bool HasCompleted()
		{
			return _foundationValue >= _definition.TargetAmount;
		}

		public override float PercentComplete()
		{
			return (float)_foundationValue / (float)_definition.TargetAmount;
		}

		public override int Score()
		{
			return _foundationValue;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.OrganisationValue_Progress_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(_definition.TargetAmount - _foundationValue));
		}
	}
}
