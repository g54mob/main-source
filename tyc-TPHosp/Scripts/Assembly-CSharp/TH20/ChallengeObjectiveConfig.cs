using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeObjectiveConfig : ChallengeConfig
	{
		[InspectorHeader("Challenge Objective")]
		public bool CanAbandon;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeObjective(this, level);
		}
	}
}
