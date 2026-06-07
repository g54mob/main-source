using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Market Store", Scope.Project)]
	public class MarketStoreSettings : CustomSettings<MarketStoreSettings>
	{
		[Header("Delivery Fees")]
		[SerializeField]
		private float m_deliveryFeeFormulaA = 5f;

		[SerializeField]
		private float m_deliveryFeeFormulaB;

		[SerializeField]
		private float m_deliveryFeeFormulaC = 1f;

		[Header("Cheats")]
		[SerializeField]
		private bool m_needToPayLicenses;

		[SerializeField]
		private bool m_unlockAll;

		[SerializeField]
		private bool m_everythingFree;

		public static bool NeedToPayLicenses => CustomSettings<MarketStoreSettings>.I.m_needToPayLicenses;

		public static bool UnlockAll => false;

		public static bool EverythingFree => false;

		public static float ComputeDeliveryFees(int productCount)
		{
			if (productCount <= 0)
			{
				return 0f;
			}
			return CustomSettings<MarketStoreSettings>.I.m_deliveryFeeFormulaA + Mathf.Pow(CustomSettings<MarketStoreSettings>.I.m_deliveryFeeFormulaB * (float)productCount, CustomSettings<MarketStoreSettings>.I.m_deliveryFeeFormulaC);
		}
	}
}
