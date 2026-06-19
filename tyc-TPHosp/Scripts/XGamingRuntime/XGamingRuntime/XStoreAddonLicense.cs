using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreAddonLicense
	{
		public string SkuStoreId { get; }

		public string InAppOfferToken { get; }

		public bool IsActive { get; }

		public DateTime ExpirationDate { get; }

		internal XStoreAddonLicense(XGamingRuntime.Interop.XStoreAddonLicense interopLicense)
		{
			SkuStoreId = Converters.ByteArrayToString(interopLicense.skuStoreId);
			InAppOfferToken = Converters.ByteArrayToString(interopLicense.inAppOfferToken);
			IsActive = interopLicense.isActive;
			ExpirationDate = interopLicense.expirationDate.DateTime;
		}
	}
}
