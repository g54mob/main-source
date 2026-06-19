using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionPrestige : SubGoalDefinition
	{
		public int PrestigeTarget;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalPrestige(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.HospitalPrestige_Goal_CS.Replace("{[TARGET]}", PrestigeTarget.ToString());
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.PrestigeTracker.Points >= PrestigeTarget;
		}
	}
}
