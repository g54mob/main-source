namespace XGamingRuntime.Interop
{
	internal struct XStoreCanAcquireLicenseResult
	{
		private unsafe fixed byte licensableSku[5];

		internal readonly XStoreCanLicenseStatus status;

		internal unsafe string GetLicensableSku()
		{
			fixed (byte* bytePointer = licensableSku)
			{
				return Converters.BytePointerToString(bytePointer, 5);
			}
		}

		internal unsafe XStoreCanAcquireLicenseResult(XGamingRuntime.XStoreCanAcquireLicenseResult publicObject)
		{
			fixed (byte* bytePointer = licensableSku)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.LicensableSku, bytePointer, 5);
			}
			status = publicObject.Status;
		}
	}
}
