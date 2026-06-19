using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalPatientDeaths : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionPatientDeaths _definition;

		private int _numDeaths;

		public SubGoalPatientDeaths(Objective owner, SubGoalDefinitionPatientDeaths definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionPatientDeaths;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionPatientDeaths)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			base.OnEnd();
		}

		private void OnPatientDied(Patient patient)
		{
			_numDeaths++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numDeaths >= _definition.Deaths;
		}

		public override float PercentComplete()
		{
			return (float)_numDeaths / (float)_definition.Deaths;
		}

		public override int Score()
		{
			return _numDeaths;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numDeaths} / {_definition.Deaths}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
