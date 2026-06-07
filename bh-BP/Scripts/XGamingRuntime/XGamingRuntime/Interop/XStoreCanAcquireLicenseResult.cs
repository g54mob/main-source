namespace XGamingRuntime.Interop
{
	internal struct XStoreCanAcquireLicenseResult
	{
		private unsafe fixed byte licensableSku[5];

		internal readonly XStoreCanLicenseStatus status;

		internal string GetLicensableSku()
		{
			return null;
		}

		internal XStoreCanAcquireLicenseResult(XGamingRuntime.XStoreCanAcquireLicenseResult publicObject)
		{
			status = default(XStoreCanLicenseStatus);
		}
	}
}
