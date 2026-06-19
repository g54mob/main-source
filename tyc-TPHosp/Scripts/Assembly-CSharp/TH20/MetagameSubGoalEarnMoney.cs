using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalEarnMoney : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionEarnMoney _definition;

		[SerializeField]
		private int _earnedAmount;

		public MetagameSubGoalEarnMoney(Objective owner, MetagameSubGoalDefinitionEarnMoney definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnMoneyEarned = (Action<int>)Delegate.Combine(levelEventsIntermediary.OnMoneyEarned, new Action<int>(OnMoneyEarned));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnMoneyEarned = (Action<int>)Delegate.Remove(levelEventsIntermediary.OnMoneyEarned, new Action<int>(OnMoneyEarned));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnMoneyEarned = (Action<int>)Delegate.Combine(levelEventsIntermediary2.OnMoneyEarned, new Action<int>(OnMoneyEarned));
			}
		}

		protected override void OnEnd()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnMoneyEarned = (Action<int>)Delegate.Remove(levelEventsIntermediary.OnMoneyEarned, new Action<int>(OnMoneyEarned));
			}
			base.OnEnd();
		}

		private void OnMoneyEarned(int amount)
		{
			_earnedAmount += amount;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _earnedAmount >= _definition.TargetAmount;
		}

		public override float PercentComplete()
		{
			return (float)_earnedAmount / (float)_definition.TargetAmount;
		}

		public override int Score()
		{
			return _earnedAmount;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.EarnMoney_Progress_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(_definition.TargetAmount - _earnedAmount));
		}
	}
}
