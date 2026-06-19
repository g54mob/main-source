using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionAnachronisticTimeTunnelCount : SubGoalDefinitionAnachronisticTimeTunnel
	{
		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalAnachronisticTimeTunnelCount(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.AnachronisticSentHome_Goal_CS;
			LocalisationParams.Set("COUNT", Target);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
