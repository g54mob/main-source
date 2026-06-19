using I2.Loc;
using JetBrains.Annotations;
using TH20.EventStaffHired;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalHireStaff : LevelObjectiveSubGoal, Interface, IGameEventCallback
	{
		[DontSave]
		private SubGoalDefinitionHireStaff _definition;

		private int _numHired;

		public SubGoalHireStaff(Objective owner, SubGoalDefinitionHireStaff definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionHireStaff;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionHireStaff)base.Definition;
		}

		protected override void OnStart()
		{
			Level.CharacterEvents.OnStaffHired.Add(this);
			if (_definition.IncludeExisting)
			{
				_numHired = Level.CharacterManager.GetStaffOfType(_definition.GetStaffDefinition()).Count;
			}
			base.OnStart();
		}

		protected override void OnEnd()
		{
			Level.CharacterEvents.OnStaffHired.Remove(this);
			base.OnEnd();
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			StaffDefinition staffDefinition = _definition.GetStaffDefinition();
			if (staffDefinition == null || staff.Definition == staffDefinition)
			{
				_numHired++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numHired >= _definition.StaffCount;
		}

		public override float PercentComplete()
		{
			return (float)_numHired / (float)_definition.StaffCount;
		}

		public override int Score()
		{
			return _numHired;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numHired} / {_definition.StaffCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
