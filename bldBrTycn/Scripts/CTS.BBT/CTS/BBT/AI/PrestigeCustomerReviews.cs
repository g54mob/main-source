using System;
using CTS.Core;
using CTS.Emotes;
using CTS.UI;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class PrestigeCustomerReviews : CTSBehaviour
	{
		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		private Prestige _prestige;

		[SerializeField]
		private CustomerReviewData _humanReviewData;

		[SerializeField]
		private CustomerReviewData _vampireReviewData;

		private static CustomerReviewData HumanReviewData;

		private static CustomerReviewData VampireReviewData;

		[SerializeField]
		private PaletteData _emoteContentColor;

		[SerializeField]
		private Sprite _emoteGoodBackground;

		[SerializeField]
		private PaletteData _emoteGoodColor;

		[SerializeField]
		private Sprite _emoteBadBackground;

		[SerializeField]
		private PaletteData _emoteBadColor;

		public static event Action<Customer, int> CustomerReviewed;

		protected override void OnAwake()
		{
			base.OnAwake();
			HumanReviewData = _humanReviewData;
			VampireReviewData = _vampireReviewData;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			AgentActionLeave.CustomerLeftBar += OnCustomerLeaveBar;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			AgentActionLeave.CustomerLeftBar -= OnCustomerLeaveBar;
		}

		private void OnCustomerLeaveBar(Customer customer)
		{
			if (customer.HasTag(BBTAgentTags.NoReview))
			{
				return;
			}
			int num = ((!customer.IsVampire) ? _humanReviewData.GetScoreFromSatisfactionWithDifficulty(customer.Statistics.GetStatisticUnitInterval(EAgentStatistics.Satisfaction)) : _vampireReviewData.GetScoreFromSatisfactionWithDifficulty(customer.Statistics.GetStatisticUnitInterval(EAgentStatistics.Satisfaction), Vampire: true));
			if (num != 0 && customer.SkeletonData.TryGetBone(EBone.HeadTop, out var boneTransform))
			{
				EmoteBBT emote;
				if (num > 0)
				{
					emote = EmoteManager.Play<EmoteBBT>(boneTransform.position, "<line-height=75%><size=150%><sprite=\"Emoji_Notifications_Overlay\" index=\"10\">\n</size>+" + num);
					emote.SetBackgroundSprite(_emoteGoodBackground);
					emote.SetBackgroundColor(_emoteGoodColor);
				}
				else
				{
					emote = EmoteManager.Play<EmoteBBT>(boneTransform.position, "<line-height=75%><size=150%><sprite=\"Emoji_Notifications_Overlay\" index=\"10\">\n</size>" + num);
					emote.SetBackgroundSprite(_emoteBadBackground);
					emote.SetBackgroundColor(_emoteBadColor);
				}
				emote.SetContentColor(_emoteContentColor);
				emote.SetPadding(75f);
			}
			_prestige.AddReviewScore(num);
			PrestigeCustomerReviews.CustomerReviewed?.Invoke(customer, num);
		}

		public static RangeValue<int> GetReviewIndex(Customer customer)
		{
			if (customer.IsVampire)
			{
				return VampireReviewData.GetSatisfactionStarCount(customer.Statistics.GetStatisticUnitInterval(EAgentStatistics.Satisfaction));
			}
			return HumanReviewData.GetSatisfactionStarCount(customer.Statistics.GetStatisticUnitInterval(EAgentStatistics.Satisfaction));
		}
	}
}
