using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7DaysSinceLastDeath : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7DaysSinceLastDeath _definition;

		private int _numDays;

		public SubGoalD7DaysSinceLastDeath(Objective owner, SubGoalDefinitionD7DaysSinceLastDeath definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7DaysSinceLastDeath;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7DaysSinceLastDeath)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
				TimelineManager timelineManager = Level.TimelineManager;
				timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			TimelineManager timelineManager = Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			TimelineManager timelineManager = Level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			base.OnEnd();
		}

		private void OnPatientDied(Patient patient)
		{
			if (patient.IsAEPatient && ShouldUpdate())
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
