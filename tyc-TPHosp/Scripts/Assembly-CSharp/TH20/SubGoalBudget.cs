using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalBudget : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionBudget _definition;

		private int _currentScore;

		private ChallengeBudget _budgetChallenge;

		public SubGoalBudget(Objective owner, SubGoalDefinitionBudget definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionBudget;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_ = _budgetChallenge;
			_definition = (SubGoalDefinitionBudget)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterCallbacks();
			}
		}

		protected override void OnStart()
		{
			List<ChallengeBudget> activeChallengesOfType = Level.ChallengeManager.GetActiveChallengesOfType<ChallengeBudget>();
			if (activeChallengesOfType.Count > 0)
			{
				using List<ChallengeBudget>.Enumerator enumerator = activeChallengesOfType.GetEnumerator();
				if (enumerator.MoveNext())
				{
					ChallengeBudget current = enumerator.Current;
					_budgetChallenge = current;
				}
			}
			_ = _budgetChallenge;
			RegisterCallbacks();
			OnBudgetScoreChanged();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			UnregisterCallbacks();
			base.OnEnd();
		}

		private void RegisterCallbacks()
		{
			if (_budgetChallenge != null)
			{
				_budgetChallenge.OnCurrentScoreUpdated.AddListener(OnBudgetScoreChanged);
			}
		}

		private void UnregisterCallbacks()
		{
			if (_budgetChallenge != null)
			{
				_budgetChallenge.OnCurrentScoreUpdated.RemoveListener(OnBudgetScoreChanged);
			}
		}

		private void OnBudgetScoreChanged()
		{
			if (_budgetChallenge != null)
			{
				_currentScore = _budgetChallenge.CurrentScore;
				Level.ObjectiveEvents.OnSubGoalUpdated(this);
			}
		}

		protected override bool HasCompleted()
		{
			return _currentScore >= _definition.TargetBudgetScore;
		}

		public override float PercentComplete()
		{
			return (float)_currentScore / (float)_definition.TargetBudgetScore;
		}

		public override int Score()
		{
			return _currentScore;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentScore} / {_definition.TargetBudgetScore}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
