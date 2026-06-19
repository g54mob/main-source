using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeGhostsConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Ghosts Config")]
		public int NumGhostsToSpawn;

		public SharedInstance<GhostDefinition> GhostDefinition;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeGhosts(this, level);
		}
	}
}
