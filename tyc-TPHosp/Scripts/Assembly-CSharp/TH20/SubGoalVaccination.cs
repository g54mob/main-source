using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalVaccination : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionVaccination _definition;

		private int _numVaccinated;

		public SubGoalVaccination(Objective owner, SubGoalDefinitionVaccination definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionVaccination;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionVaccination)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnCharacterVaccinated = (Action)Delegate.Combine(characterEvents.OnCharacterVaccinated, new Action(OnCharacterVaccinated));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterVaccinated = (Action)Delegate.Combine(characterEvents.OnCharacterVaccinated, new Action(OnCharacterVaccinated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterVaccinated = (Action)Delegate.Remove(characterEvents.OnCharacterVaccinated, new Action(OnCharacterVaccinated));
			base.OnEnd();
		}

		private void OnCharacterVaccinated()
		{
			_numVaccinated++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numVaccinated >= _definition.Target;
		}

		public override float PercentComplete()
		{
			return (float)_numVaccinated / (float)_definition.Target;
		}

		public override int Score()
		{
			return _numVaccinated;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numVaccinated} / {_definition.Target}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
