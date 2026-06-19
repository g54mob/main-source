using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeRewardOption
	{
		[SerializeField]
		private ChallengeRewardComparator _comparator;

		[SerializeField]
		private IReward[] _rewards;

		public NotificationMessages.Definition RewardNotificationDef;

		public LocalisedString AdvisorMessage;

		public Sprite AdvisorIcon;

		public IReward[] Rewards => _rewards;

		public bool IsOptionValidForScore(int score)
		{
			return _comparator.PassComparator(score);
		}
	}
}
