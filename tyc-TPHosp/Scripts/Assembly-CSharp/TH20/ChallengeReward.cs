using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeReward
	{
		[SerializeField]
		private ChallengeRewardOption[] _rewardOptions;

		public ChallengeRewardOption FindRewardForScore(int score)
		{
			ChallengeRewardOption[] rewardOptions = _rewardOptions;
			foreach (ChallengeRewardOption challengeRewardOption in rewardOptions)
			{
				if (challengeRewardOption.IsOptionValidForScore(score))
				{
					return challengeRewardOption;
				}
			}
			return null;
		}
	}
}
