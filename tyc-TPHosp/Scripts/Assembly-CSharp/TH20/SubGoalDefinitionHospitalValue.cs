using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionHospitalValue : SubGoalDefinition
	{
		public int TargetValue;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalHospitalValue(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.HospitalValue_Goal_CS.Replace("{[TARGET]}", StringUtils.FormatCurrency(TargetValue));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.LevelStatsDatabase.HospitalValue >= TargetValue;
		}
	}
}
