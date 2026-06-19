using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionBuildReception : SubGoalDefinition
	{
		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalBuildReception(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.BuildReception_Goal_CS;
		}

		public override bool HasBeenAchieved(Level level)
		{
			bool waitingForReceptionist;
			return level.ReceptionManager.IsReceptionValid(out waitingForReceptionist);
		}
	}
}
