using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7DaysSinceLastDeathAtScene : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7DaysSinceLastDeathAtScene _definition;

		private int _numDays;

		public SubGoalD7DaysSinceLastDeathAtScene(Objective owner, SubGoalDefinitionD7DaysSinceLastDeathAtScene definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7DaysSinceLastDeathAtScene;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7DaysSinceLastDeathAtScene)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Combine(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
				TimelineManager timelineManager = Level.TimelineManager;
				timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Combine(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
			TimelineManager timelineManager = Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Remove(characterEvents.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
			TimelineManager timelineManager = Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			base.OnEnd();
		}

		private void OnPatientDiedAtScene(bool playerHasDispatched, string ID)
		{
			if ((!_definition.TrackOnlyWhenAssigned || playerHasDispatched) && ShouldUpdate())
			{
				_numDays = 0;
				UpdateProgress();
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (ShouldUpdate())
			{
				_numDays++;
				UpdateProgress();
			}
		}

		public override bool Failed()
		{
			if (!Owner.Definition.IsTimed)
			{
				return false;
			}
			return Owner.Definition.TimeLength - Owner.DaysElapsed < _definition.Days;
		}

		protected override bool HasCompleted()
		{
			return _numDays >= _definition.Days;
		}

		public override float PercentComplete()
		{
			return (float)_numDays / (float)_definition.Days;
		}

		public override int Score()
		{
			return _numDays;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numDays} / {_definition.Days}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
