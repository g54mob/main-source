using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionReachWaveObjectivesHordeWave : SubGoalDefinition
	{
		public int WaveToReach;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalReachWaveObjectivesHordeWave(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.ReachHordeWave_Goal_CS.Replace("{[WAVE]}", WaveToReach.ToString());
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
