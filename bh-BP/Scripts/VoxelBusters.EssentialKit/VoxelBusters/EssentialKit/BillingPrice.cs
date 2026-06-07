using System;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class BillingPrice
	{
		public double Value { get; private set; }

		public string Code { get; private set; }

		public string Symbol { get; private set; }

		public string LocalizedText { get; private set; }

		public BillingPrice(double value, string currencyCode, string currencySymbol, string localizedText)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
