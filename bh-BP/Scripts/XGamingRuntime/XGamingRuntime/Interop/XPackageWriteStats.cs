namespace XGamingRuntime.Interop
{
	internal struct XPackageWriteStats
	{
		internal readonly ulong interval;

		internal readonly ulong budget;

		internal readonly ulong elapsed;

		internal readonly ulong bytesWritten;

		internal XPackageWriteStats(XGamingRuntime.XPackageWriteStats publicObject)
		{
			interval = 0uL;
			budget = 0uL;
			elapsed = 0uL;
			bytesWritten = 0uL;
		}
	}
}
