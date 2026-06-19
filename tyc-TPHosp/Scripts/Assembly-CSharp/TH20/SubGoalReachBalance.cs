using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalReachBalance : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionReachBalance _definition;

		private int _currentBalance;

		public SubGoalReachBalance(Objective owner, SubGoalDefinitionReachBalance definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionReachBalance;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionReachBalance)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				FinanceManager financeManager = Level.FinanceManager;
				financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			}
		}

		protected override void OnStart()
		{
			_currentBalance = Level.FinanceManager.Balance;
			FinanceManager financeManager = Level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			FinanceManager financeManager = Level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			base.OnEnd();
		}

		private void OnBalanceUpdated(int newBalance)
		{
			_currentBalance = newBalance;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _currentBalance >= _definition.Target;
		}

		public override float PercentComplete()
		{
			return (float)_currentBalance / (float)_definition.Target;
		}

		public override int Score()
		{
			return _currentBalance;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.ReachBalance_Progress_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(_definition.Target - _currentBalance));
		}
	}
}
