using System;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalEarnMoney : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionEarnMoney _definition;

		private int _earnedAmount;

		public SubGoalEarnMoney(Objective owner, SubGoalDefinitionEarnMoney definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionEarnMoney;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionEarnMoney)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				FinanceManager financeManager = Level.FinanceManager;
				financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Combine(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			}
		}

		protected override void OnStart()
		{
			FinanceManager financeManager = Level.FinanceManager;
			financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Combine(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			FinanceManager financeManager = Level.FinanceManager;
			financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Remove(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			base.OnEnd();
		}

		private void OnMoneyEarned(int amount, Vector3? inWorldPosition)
		{
			if (ShouldUpdate())
			{
				_earnedAmount += amount;
				UpdateProgress();
			}
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
