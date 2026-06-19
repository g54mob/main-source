using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalVIPSatisfied : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionVIPSatisfied _definition;

		private int _currentScore;

		public SubGoalVIPSatisfied(Objective owner, SubGoalDefinitionVIPSatisfied definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionVIPSatisfied;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionVIPSatisfied)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterCallbacks();
			}
		}

		protected override void OnStart()
		{
			RegisterCallbacks();
			_currentScore = 0;
			base.OnStart();
		}

		protected override void OnEnd()
		{
			UnregisterCallbacks();
			base.OnEnd();
		}

		private void RegisterCallbacks()
		{
			ChallengeEvents challengeEvents = Level.ChallengeEvents;
			challengeEvents.OnChallengeVIPCompleted = (Action<ChallengeVIP>)Delegate.Combine(challengeEvents.OnChallengeVIPCompleted, new Action<ChallengeVIP>(OnVIPSatisfied));
		}

		private void UnregisterCallbacks()
		{
			ChallengeEvents challengeEvents = Level.ChallengeEvents;
			challengeEvents.OnChallengeVIPCompleted = (Action<ChallengeVIP>)Delegate.Remove(challengeEvents.OnChallengeVIPCompleted, new Action<ChallengeVIP>(OnVIPSatisfied));
		}

		private void OnVIPSatisfied(ChallengeVIP challenge)
		{
			if (challenge.CompletionResult == Objective.CompletionType.Successful)
			{
				_currentScore++;
				Level.ObjectiveEvents.OnSubGoalUpdated(this);
			}
		}

		protected override bool HasCompleted()
		{
			return _currentScore >= _definition.VIPSatisfiedTarget;
		}

		public override float PercentComplete()
		{
			return (float)_currentScore / (float)_definition.VIPSatisfiedTarget;
		}

		public override int Score()
		{
			return _currentScore;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentScore} / {_definition.VIPSatisfiedTarget}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
