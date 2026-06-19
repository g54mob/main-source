using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionHospitalAttractiveness : SubGoalDefinition
	{
		public int TargetAttractiveness;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalHospitalAttractiveness(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.HospitalAttractiveness_Goal_CS.Replace("{[TARGET]}", StringUtils.FormatPercentageValue((float)TargetAttractiveness / 100f));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness) >= TargetAttractiveness;
		}
	}
}
