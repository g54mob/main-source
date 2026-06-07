using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Price", Scope.Project)]
	public class PriceSettings : CustomSettings<PriceSettings>
	{
		[Header("Prices Limits")]
		[SerializeField]
		private EnabledValue<float> m_minPriceMultiplier;

		[SerializeField]
		private EnabledValue<float> m_maxPriceMultiplier;

		[Header("Market History")]
		[SerializeField]
		private int m_pastDaysToDisplay = 14;

		[SerializeField]
		private Vector2 m_marketFluctuationExtremes = new Vector2(-20f, 20f);

		[SerializeField]
		private Vector2 m_marketFluctuationPerDay = new Vector2(-5f, 5f);

		public static int MarketHistoryPastDaysToDisplay => CustomSettings<PriceSettings>.I.m_pastDaysToDisplay;

		public static Vector2 MarketFluctuationExtremes => CustomSettings<PriceSettings>.I.m_marketFluctuationExtremes;

		public static Vector2 MarketFluctuationPerDay => CustomSettings<PriceSettings>.I.m_marketFluctuationPerDay;

		public static float GetMinPriceMultiplier()
		{
			if (CustomSettings<PriceSettings>.I.m_minPriceMultiplier.IsEnabled(out var value))
			{
				return value;
			}
			return float.MinValue;
		}

		public static float GetMaxPriceMultiplier()
		{
			if (CustomSettings<PriceSettings>.I.m_maxPriceMultiplier.IsEnabled(out var value))
			{
				return value;
			}
			return float.MaxValue;
		}
	}
}
