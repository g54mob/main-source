namespace XGamingRuntime.Interop
{
	internal struct XStoreGameLicense
	{
		private unsafe fixed byte skuStoreId[18];

		internal readonly NativeBool isActive;

		internal readonly NativeBool isTrialOwnedByThisUser;

		internal readonly NativeBool isDiscLicense;

		internal readonly NativeBool isTrial;

		internal readonly uint trialTimeRemainingInSeconds;

		private unsafe fixed byte trialUniqueId[64];

		internal readonly TimeT expirationDate;

		internal string GetSkuStoreId()
		{
			return null;
		}

		internal string GetTrialUniqueId()
		{
			return null;
		}

		internal XStoreGameLicense(XGamingRuntime.XStoreGameLicense publicObject)
		{
			isActive = default(NativeBool);
			isTrialOwnedByThisUser = default(NativeBool);
			isDiscLicense = default(NativeBool);
			isTrial = default(NativeBool);
			trialTimeRemainingInSeconds = 0u;
			expirationDate = default(TimeT);
		}
	}
}
