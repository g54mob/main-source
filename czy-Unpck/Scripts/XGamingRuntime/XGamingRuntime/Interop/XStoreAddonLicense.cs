namespace XGamingRuntime.Interop
{
	internal struct XStoreAddonLicense
	{
		private unsafe fixed byte skuStoreId[18];

		private unsafe fixed byte inAppOfferToken[64];

		internal readonly NativeBool isActive;

		internal readonly TimeT expirationDate;

		internal unsafe string GetSkuStoreId()
		{
			fixed (byte* bytePointer = skuStoreId)
			{
				return Converters.BytePointerToString(bytePointer, 18);
			}
		}

		internal unsafe string GetInAppOfferToken()
		{
			fixed (byte* bytePointer = inAppOfferToken)
			{
				return Converters.BytePointerToString(bytePointer, 64);
			}
		}

		internal unsafe XStoreAddonLicense(XGamingRuntime.XStoreAddonLicense publicObject)
		{
			fixed (byte* bytePointer = skuStoreId)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SkuStoreId, bytePointer, 18);
			}
			fixed (byte* bytePointer2 = inAppOfferToken)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.InAppOfferToken, bytePointer2, 64);
			}
			isActive = new NativeBool(publicObject.IsActive);
			expirationDate = new TimeT(publicObject.ExpirationDate);
		}
	}
}
