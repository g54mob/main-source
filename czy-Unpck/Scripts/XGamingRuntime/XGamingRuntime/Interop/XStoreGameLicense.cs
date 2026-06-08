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

		internal unsafe string GetSkuStoreId()
		{
			fixed (byte* bytePointer = skuStoreId)
			{
				return Converters.BytePointerToString(bytePointer, 18);
			}
		}

		internal unsafe string GetTrialUniqueId()
		{
			fixed (byte* bytePointer = trialUniqueId)
			{
				return Converters.BytePointerToString(bytePointer, 64);
			}
		}

		internal unsafe XStoreGameLicense(XGamingRuntime.XStoreGameLicense publicObject)
		{
			fixed (byte* bytePointer = skuStoreId)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SkuStoreId, bytePointer, 18);
			}
			isActive = new NativeBool(publicObject.IsActive);
			isTrialOwnedByThisUser = new NativeBool(publicObject.IsTrialOwnedByThisUser);
			isDiscLicense = new NativeBool(publicObject.IsDiscLicense);
			isTrial = new NativeBool(publicObject.IsTrial);
			trialTimeRemainingInSeconds = publicObject.TrialTimeRemainingInSeconds;
			fixed (byte* bytePointer2 = trialUniqueId)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.TrialUniqueId, bytePointer2, 64);
			}
			expirationDate = new TimeT(publicObject.ExpirationDate);
		}
	}
}
