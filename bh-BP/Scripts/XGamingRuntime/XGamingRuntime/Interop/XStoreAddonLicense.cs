namespace XGamingRuntime.Interop
{
	internal struct XStoreAddonLicense
	{
		private unsafe fixed byte skuStoreId[18];

		private unsafe fixed byte inAppOfferToken[64];

		internal readonly NativeBool isActive;

		internal readonly TimeT expirationDate;

		internal string GetSkuStoreId()
		{
			return null;
		}

		internal string GetInAppOfferToken()
		{
			return null;
		}

		internal XStoreAddonLicense(XGamingRuntime.XStoreAddonLicense publicObject)
		{
			isActive = default(NativeBool);
			expirationDate = default(TimeT);
		}
	}
}
