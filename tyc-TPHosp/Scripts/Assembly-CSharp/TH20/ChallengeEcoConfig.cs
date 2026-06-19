using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeEcoConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Eco Config")]
		public float EcoRatingMinValue = -3f;

		public float EcoRatingMaxValue = 3f;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeEco(this, level);
		}
	}
}
