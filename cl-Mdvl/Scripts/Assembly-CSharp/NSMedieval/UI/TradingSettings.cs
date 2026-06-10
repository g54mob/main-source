using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class TradingSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private float giftingWealthPointsFriendliness;

		[SerializeField]
		private float tradingWealthPointsFriendliness;

		public float GiftingWealthPointsFriendliness => giftingWealthPointsFriendliness;

		public float TradingWealthPointsFriendliness => tradingWealthPointsFriendliness;

		public override string GetID()
		{
			return "TradingSettings";
		}
	}
}
