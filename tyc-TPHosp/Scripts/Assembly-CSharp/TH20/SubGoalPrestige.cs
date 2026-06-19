using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalPrestige : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionPrestige _definition;

		private int _currentPrestige;

		private int _requiredPrestige;

		public SubGoalPrestige(Objective owner, SubGoalDefinitionPrestige definition)
			: base(owner, definition)
		{
			_definition = definition;
			_requiredPrestige = Level.PrestigeTracker.GetPointsRequired(_definition.PrestigeTarget - 2);
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionPrestige;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionPrestige)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				PrestigeTracker prestigeTracker = Level.PrestigeTracker;
				prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Combine(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			}
		}

		protected override void OnStart()
		{
			_currentPrestige = Level.PrestigeTracker.Points;
			PrestigeTracker prestigeTracker = Level.PrestigeTracker;
			prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Combine(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			PrestigeTracker prestigeTracker = Level.PrestigeTracker;
			prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Remove(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			base.OnEnd();
		}

		private void OnPrestigeChangedEvent(PrestigeTracker prestigeTracker)
		{
			_currentPrestige = prestigeTracker.Points;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _currentPrestige >= _requiredPrestige;
		}

		public override float PercentComplete()
		{
			return (float)_currentPrestige / (float)_requiredPrestige;
		}

		public override int Score()
		{
			return _currentPrestige;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.HospitalPrestige_Progress_CS.Replace("{[SCORE]}", Level.PrestigeTracker.Level.ToString());
		}
	}
}
