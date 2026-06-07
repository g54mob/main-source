namespace XGamingRuntime.Interop
{
	internal struct XPackageInstallationProgress
	{
		internal readonly ulong totalBytes;

		internal readonly ulong installedBytes;

		internal readonly ulong launchBytes;

		internal readonly NativeBool launchable;

		internal readonly NativeBool completed;

		internal XPackageInstallationProgress(XGamingRuntime.XPackageInstallationProgress publicObject)
		{
			totalBytes = 0uL;
			installedBytes = 0uL;
			launchBytes = 0uL;
			launchable = default(NativeBool);
			completed = default(NativeBool);
		}
	}
}
