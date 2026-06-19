using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XPackageInstallationProgress
	{
		public ulong TotalBytes { get; }

		public ulong InstalledBytes { get; }

		public ulong LaunchBytes { get; }

		public bool Launchable { get; }

		public bool Completed { get; }

		internal XPackageInstallationProgress(XGamingRuntime.Interop.XPackageInstallationProgress rawProgress)
		{
			TotalBytes = rawProgress.totalBytes;
			InstalledBytes = rawProgress.installedBytes;
			LaunchBytes = rawProgress.launchBytes;
			Launchable = rawProgress.launchable;
			Completed = rawProgress.completed;
		}
	}
}
