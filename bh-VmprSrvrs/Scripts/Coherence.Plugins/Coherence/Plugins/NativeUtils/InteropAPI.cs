using System.Runtime.InteropServices;

namespace Coherence.Plugins.NativeUtils
{
	internal static class InteropAPI
	{
		private const string DLL_NAME = "native_utils";

		[PreserveSig]
		public static extern int TRFindSuspendedThreads(int pid, ulong[] buff, uint len, bool verbose, out ulong timeMs);

		[PreserveSig]
		public static extern bool TRResumeThread(ulong threadID);

		[PreserveSig]
		public static extern bool TRSuspendThread(ulong threadID);

		[PreserveSig]
		public static extern ulong TRGetCurrentThreadId();
	}
}
