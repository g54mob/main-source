namespace VoxelBusters.EssentialKit
{
	public class BillingProductOfferRedeemDetails
	{
		public class IosProperties
		{
			public string OfferId { get; private set; }

			public string KeyId { get; private set; }

			public string Nonce { get; private set; }

			public string Signature { get; private set; }

			public long Timestamp { get; private set; }

			internal IosProperties(string offerId, string keyId, string nonce, string signature, long timestamp)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class AndroidProperties
		{
			public string OfferId { get; private set; }

			internal AndroidProperties(string offerId)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class Builder
		{
			private BillingProductOfferRedeemDetails m_request;

			public Builder SetIosPlatformProperties(string offerId, string keyId, string nonce, string signature, long timestamp)
			{
				return null;
			}

			public Builder SetAndroidPlatformProperties(string offerId)
			{
				return null;
			}

			public BillingProductOfferRedeemDetails Build()
			{
				return null;
			}
		}

		public IosProperties IosPlatformProperties { get; private set; }

		public AndroidProperties AndroidPlatformProperties { get; private set; }

		private BillingProductOfferRedeemDetails()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
