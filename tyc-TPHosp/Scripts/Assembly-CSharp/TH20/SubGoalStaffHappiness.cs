using I2.Loc;

namespace TH20
{
	public class SubGoalStaffHappiness : LevelObjectiveSubGoal
	{
		private readonly Staff _staff;

		[DontSave]
		private SubGoalDefinitionStaffHappiness _definition;

		private float _happiness;

		public SubGoalStaffHappiness(Objective owner, SubGoalDefinitionStaffHappiness definition)
			: base(owner, definition)
		{
			_staff = ((StaffChallengeResignation)owner).Staff;
			if (_staff.Happiness != null)
			{
				_staff.Happiness.Changed(HappinessChanged);
			}
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionStaffHappiness;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionStaffHappiness)base.Definition;
			if (_staff.Happiness != null)
			{
				_staff.Happiness.Changed(HappinessChanged);
			}
		}

		private void HappinessChanged(float happiness)
		{
			_happiness = happiness;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _happiness >= _definition._targetHappiness;
		}

		public override float PercentComplete()
		{
			return _happiness / _definition._targetHappiness;
		}

		public override int Score()
		{
			return (int)_happiness;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return LocalisedString.Replace(ScriptLocalization.Challenges_SubGoals.StaffHappiness_Progress_CS, "{[PERCENT]}", StringUtils.FormatPercentageValue(_happiness / 100f));
		}
	}
}
