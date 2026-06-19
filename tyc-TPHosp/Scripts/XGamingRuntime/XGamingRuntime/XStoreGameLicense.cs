using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreGameLicense
	{
		public string SkuStoreId { get; }

		public bool IsActive { get; }

		public bool IsTrialOwnedByThisUser { get; }

		public bool IsDiscLicense { get; }

		public bool IsTrial { get; }

		public uint TrialTimeRemainingInSeconds { get; }

		public string TrialUniqueId { get; }

		public DateTime ExpirationDate { get; }

		internal XStoreGameLicense(XGamingRuntime.Interop.XStoreGameLicense interopLicense)
		{
			SkuStoreId = Converters.ByteArrayToString(interopLicense.skuStoreId);
			IsActive = interopLicense.isActive;
			IsTrialOwnedByThisUser = interopLicense.isTrialOwnedByThisUser;
			IsDiscLicense = interopLicense.isDiscLicense;
			IsTrial = interopLicense.isTrial;
			TrialTimeRemainingInSeconds = interopLicense.trialTimeRemainingInSeconds;
			TrialUniqueId = Converters.ByteArrayToString(interopLicense.trialUniqueId);
			ExpirationDate = interopLicense.expirationDate.DateTime;
		}
	}
}
