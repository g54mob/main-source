using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Jundroo.Common.Platform
{
	public static class SystemUtils
	{
		private static class NativeMethods
		{
			[DllImport("user32.dll")]
			public static extern IntPtr GetActiveWindow();

			[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
			public static extern int GetLongPathName(string path, StringBuilder longPath, int longPathLength);

			[DllImport("user32.dll")]
			public static extern bool ShowWindow(IntPtr windowHandle, int showCommand);
		}

		private static IntPtr _windowHandle;

		public static string GetLongPathName(string shortPath)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			NativeMethods.GetLongPathName(shortPath, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		public static void SwitchToThisWindow()
		{
			if (_windowHandle != IntPtr.Zero)
			{
				NativeMethods.ShowWindow(_windowHandle, 3);
			}
		}

		public static void SaveWindowHandle()
		{
			_windowHandle = NativeMethods.GetActiveWindow();
		}
	}
}
