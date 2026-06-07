using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Assets.Scripts.OperatingSystem
{
	internal static class SystemUtils
	{
		private static class NativeMethods
		{
			[DllImport("user32.dll")]
			public static extern IntPtr GetActiveWindow();

			[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
			public static extern int GetLongPathName(string path, StringBuilder longPath, int longPathLength);

			[DllImport("user32.dll")]
			public static extern bool ShowWindow(IntPtr windowHandle, int showCommand);

			[DllImport("user32.dll")]
			public static extern bool SetWindowText(IntPtr hwnd, string lpString);

			[DllImport("user32.dll")]
			public static extern IntPtr FindWindow(string className, string windowName);
		}

		private static IntPtr _windowHandle;

		public static void ChangeWindowName(string name)
		{
			NativeMethods.SetWindowText(NativeMethods.FindWindow(null, "SimpleRockets 2"), name);
		}

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
