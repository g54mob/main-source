using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalAnachronisticTimeTunnelCount : SubGoalAnachronisticTimeTunnel
	{
		public SubGoalAnachronisticTimeTunnelCount(Objective owner, SubGoalDefinitionAnachronisticTimeTunnelCount definition)
			: base(owner, definition)
		{
		}

		public override int Score()
		{
			return Count();
		}

		public override string ProgressText()
		{
			string text = ScriptLocalization.Challenges_SubGoals.AnachronisticSentHome_Progress_CS;
			LocalisationParams.Set("COUNT_TIME_TRAVELLED", Count());
			LocalisationParams.Set("COUNT", Target());
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
