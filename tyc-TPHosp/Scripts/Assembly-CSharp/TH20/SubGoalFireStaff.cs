using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalFireStaff : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionFireStaff _definition;

		private int _numFired;

		public SubGoalFireStaff(Objective owner, SubGoalDefinitionFireStaff definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionFireStaff;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionFireStaff)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			base.OnEnd();
		}

		private void OnStaffFired(Staff firedStaff)
		{
			_numFired++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numFired >= _definition.NumStaffToFire;
		}

		public override float PercentComplete()
		{
			return (float)_numFired / (float)_definition.NumStaffToFire;
		}

		public override int Score()
		{
			return _numFired;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numFired} / {_definition.NumStaffToFire}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
