using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Challenges")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeStart : ExpiringLevelAction
	{
		public SharedInstance_TH20TH20_ChallengeConfig _challengeConfig;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.ChallengeManager.CreateNewChallenge(_challengeConfig.Instance);
			return TaskStatus.Success;
		}
	}
}
