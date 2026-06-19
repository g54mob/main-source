using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalReputation : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionReputation _definition;

		private float _currentReputation;

		public SubGoalReputation(Objective owner, SubGoalDefinitionReputation definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionReputation;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionReputation)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				ReputationTracker reputationTracker = Level.ReputationTracker;
				reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Combine(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
			}
		}

		protected override void OnStart()
		{
			_currentReputation = Level.ReputationTracker.OverallReputation * 100f;
			ReputationTracker reputationTracker = Level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Combine(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			base.OnEnd();
			ReputationTracker reputationTracker = Level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Remove(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
		}

		private void OnReputationChangedEvent(float newReputation)
		{
			if (ShouldUpdate())
			{
				_currentReputation = newReputation * 100f;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentReputation >= (float)_definition.Target;
		}

		public override float PercentComplete()
		{
			return _currentReputation / (float)_definition.Target;
		}

		public override int Score()
		{
			return (int)_currentReputation;
		}

		public override string ProgressText()
		{
			return ScriptLocalization.Challenges_SubGoals.Reputation_Progress_CS.Replace("{[SCORE]}", StringUtils.FormatPercentageValue((float)Score() / 100f));
		}
	}
}
