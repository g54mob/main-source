using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class BillingProductDefinition
	{
		[SerializeField]
		private string m_id;

		[SerializeField]
		private BillingProductType m_productType;

		[SerializeField]
		private string m_title;

		[SerializeField]
		private string m_description;

		[SerializeField]
		private bool m_isInactive;

		[SerializeField]
		private BillingProductPayoutDefinition[] m_payouts;

		[Header("Platform Specific")]
		[SerializeField]
		private string m_platformId;

		[SerializeField]
		private RuntimePlatformConstantSet m_platformIdOverrides;

		public string Id => null;

		public BillingProductType ProductType => default(BillingProductType);

		public string Title => null;

		public string Description => null;

		public bool IsInactive => false;

		public BillingProductPayoutDefinition[] Payouts => null;

		[Obsolete("This property is deprecated. Use Payouts instead.", true)]
		public object Tag { get; set; }

		public BillingProductDefinition(string id = null, string platformId = null, RuntimePlatformConstantSet platformIdOverrides = null, BillingProductType productType = BillingProductType.Consumable, string title = null, string description = null, bool isInactive = false, BillingProductPayoutDefinition[] payouts = null)
		{
		}

		public string GetPlatformIdForActivePlatform()
		{
			return null;
		}
	}
}
