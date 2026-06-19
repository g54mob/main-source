using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7PatientsCollected : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7PatientsCollected _definition;

		private int _numCollected;

		public SubGoalD7PatientsCollected(Objective owner, SubGoalDefinitionD7PatientsCollected definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7PatientsCollected;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7PatientsCollected)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollected));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollected));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Remove(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollected));
			base.OnEnd();
		}

		private void OnPatientsCollected(List<Patient> patients, string ID)
		{
			if (_definition != null)
			{
				_numCollected += patients.Count;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numCollected >= _definition.CollectionCountTarget;
		}

		public override float PercentComplete()
		{
			return (float)_numCollected / (float)_definition.CollectionCountTarget;
		}

		public override int Score()
		{
			return _numCollected;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numCollected} / {_definition.CollectionCountTarget}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
