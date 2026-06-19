using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionReachHordeWave : SubGoalDefinition
	{
		public int Wave;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalReachHordeWave(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.ReachHordeWave_Goal_CS.Replace("{[WAVE]}", Wave.ToString());
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
