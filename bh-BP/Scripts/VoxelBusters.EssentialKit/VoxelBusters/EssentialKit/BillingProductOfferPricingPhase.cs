namespace VoxelBusters.EssentialKit
{
	public class BillingProductOfferPricingPhase
	{
		public BillingProductOfferPaymentMode PaymentMode { get; private set; }

		public BillingPrice Price { get; private set; }

		public BillingPeriod Period { get; private set; }

		public int RepeatCount { get; private set; }

		public BillingProductOfferPricingPhase(BillingProductOfferPaymentMode paymentMode, BillingPrice price, BillingPeriod period, int repeatCount)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
