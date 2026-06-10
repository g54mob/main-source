using System;
using System.Runtime.InteropServices;

namespace ZLogger
{
	internal static class WindowsConsoleMode
	{
		private const string Kernel32 = "kernel32.dll";

		private const int STD_OUTPUT_HANDLE = -11;

		private const int ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;

		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool GetConsoleMode(IntPtr handle, out int mode);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool SetConsoleMode(IntPtr handle, int mode);

		internal static bool TryEnableVirtualTerminalProcessing()
		{
			IntPtr stdHandle = GetStdHandle(-11);
			if (GetConsoleMode(stdHandle, out var mode) && SetConsoleMode(stdHandle, mode | 4))
			{
				return true;
			}
			return false;
		}
	}
}
