using System;
using System.Runtime.InteropServices;

namespace Coherence.Plugins.NativeLauncher
{
	internal static class InteropAPI
	{
		public enum NlError
		{
			InvalidVal = -100,
			TimedOut = -101,
			Pipe = -102,
			WouldBlock = -103
		}

		public enum NlStream
		{
			Out = 0,
			Err = 1
		}

		public struct NlStartupParams
		{
			public string executablePath;

			public IntPtr arguments;

			public uint argumentsCount;

			public IntPtr envVars;

			public uint envVarsCount;

			public byte nonBlocking;
		}

		private const string DLL_NAME = "native_utils";

		[PreserveSig]
		public static extern IntPtr Create(NlStartupParams startupParams);

		[PreserveSig]
		public static extern void Destroy(IntPtr processHandle);

		[PreserveSig]
		public static extern int Start(IntPtr processHandle, out int pid);

		[PreserveSig]
		public static extern int StopAndWait(IntPtr processHandle, int timeout);

		[PreserveSig]
		public static extern int Wait(IntPtr processHandle, int timeout);

		[PreserveSig]
		public static extern int ReadFromStream(IntPtr processHandle, NlStream stream, IntPtr buffer, uint bufferSize);

		public static string GetErrorString(int error)
		{
			return null;
		}
	}
}
