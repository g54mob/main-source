using System;
using UnityEngine;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class BillingProductPayoutDefinition
	{
		[SerializeField]
		private BillingProductPayoutCategory m_category;

		[SerializeField]
		private string m_variant;

		[SerializeField]
		private double m_quantity;

		[SerializeField]
		private string m_data;

		[SerializeField]
		private string m_description;

		public BillingProductPayoutCategory Category => default(BillingProductPayoutCategory);

		public string Variant => null;

		public double Quantity => 0.0;

		public string Data => null;

		public string Description => null;

		public BillingProductPayoutDefinition(BillingProductPayoutCategory payoutType, string subtype = null, double quantity = 1.0, string data = null, string description = null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
