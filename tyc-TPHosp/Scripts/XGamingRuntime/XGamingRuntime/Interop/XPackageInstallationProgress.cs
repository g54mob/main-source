using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XPackageInstallationProgress
	{
		internal ulong totalBytes;

		internal ulong installedBytes;

		internal ulong launchBytes;

		[MarshalAs(UnmanagedType.U1)]
		internal bool launchable;

		[MarshalAs(UnmanagedType.U1)]
		internal bool completed;
	}
}
