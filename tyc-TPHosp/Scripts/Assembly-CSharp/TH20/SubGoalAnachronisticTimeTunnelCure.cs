using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalAnachronisticTimeTunnelCure : SubGoalAnachronisticTimeTunnel
	{
		public SubGoalAnachronisticTimeTunnelCure(Objective owner, SubGoalDefinitionAnachronisticTimeTunnelCure definition)
			: base(owner, definition)
		{
		}

		public override int Score()
		{
			return NumCured();
		}

		public override string ProgressText()
		{
			string text = ScriptLocalization.Challenges_SubGoals.AnachronisticCuredSentHome_Progress_CS;
			LocalisationParams.Set("COUNT_TIME_TRAVELLED", NumCured());
			LocalisationParams.Set("COUNT", Target());
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
