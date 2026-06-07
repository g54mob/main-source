using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace FrostweepGames.Plugins.DesktopRuntimeMonitorSwitch
{
	public class RuntimeMonitorSwitchLib
	{
		private static List<DisplayInfo> _availableDisplays;

		[DllImport("user32.dll")]
		private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

		[DllImport("user32.dll")]
		private static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo mi);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		[DllImport("user32.dll")]
		private static extern IntPtr GetActiveWindow();

		static RuntimeMonitorSwitchLib()
		{
			_availableDisplays = new List<DisplayInfo>();
		}

		public static List<DisplayInfo> GetDisplays()
		{
			if (EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnumDelegateHandler, IntPtr.Zero))
			{
				return _availableDisplays;
			}
			return new List<DisplayInfo>();
		}

		public static void SetDisplay(int x, int y, int width, int height, bool fullScreen, bool repaint = true)
		{
			MoveWindow(GetWindowHandle(), x, y, width, height, repaint);
			SetFullScreenMode(fullScreen);
		}

		public static void SetDisplay(int display, int width, int height, bool fullScreen, int x = -1, int y = -1, bool repaint = true)
		{
			if (display < 0 || display > _availableDisplays.Count)
			{
				display = 0;
			}
			DisplayInfo displayInfo = _availableDisplays[display];
			if (x == -1 && y == -1)
			{
				x = displayInfo.CenterX - width / 2;
				y = displayInfo.CenterY - height / 2;
			}
			MoveWindow(GetWindowHandle(), x, y, width, height, repaint);
			SetFullScreenMode(fullScreen);
		}

		private static void SetFullScreenMode(bool fullScreen)
		{
			Screen.fullScreen = fullScreen;
		}

		private static bool MonitorEnumDelegateHandler(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
		{
			MonitorInfo mi = default(MonitorInfo);
			mi.size = (uint)Marshal.SizeOf(mi);
			if (GetMonitorInfo(hMonitor, ref mi))
			{
				DisplayInfo displayInfo = new DisplayInfo();
				displayInfo.ScreenWidth = mi.monitor.right - mi.monitor.left;
				displayInfo.ScreenHeight = mi.monitor.bottom - mi.monitor.top;
				displayInfo.Right = mi.monitor.right;
				displayInfo.Left = mi.monitor.left;
				displayInfo.Top = mi.monitor.top;
				displayInfo.Top = mi.monitor.bottom;
				displayInfo.CenterX = (mi.monitor.left + mi.monitor.right) / 2;
				displayInfo.CenterY = (mi.monitor.top + mi.monitor.bottom) / 2;
				displayInfo.Availability = mi.flags.ToString();
				_availableDisplays.Add(displayInfo);
			}
			return true;
		}

		private static IntPtr GetWindowHandle()
		{
			return GetActiveWindow();
		}
	}
}
