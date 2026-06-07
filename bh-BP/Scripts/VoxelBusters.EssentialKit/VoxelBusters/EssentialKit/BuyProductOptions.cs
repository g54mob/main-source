namespace VoxelBusters.EssentialKit
{
	public sealed class BuyProductOptions
	{
		public class Builder
		{
			private BuyProductOptions m_options;

			public Builder SetTag(string tag)
			{
				return null;
			}

			public Builder SetQuantity(int quantity)
			{
				return null;
			}

			public Builder SetOfferRedeemDetails(BillingProductOfferRedeemDetails offerRedeemDetails)
			{
				return null;
			}

			public BuyProductOptions Build()
			{
				return null;
			}
		}

		public static BuyProductOptions Default { get; }

		public string Tag { get; private set; }

		public int Quantity { get; private set; }

		public BillingProductOfferRedeemDetails OfferRedeemDetails { get; private set; }

		private BuyProductOptions()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
