using System;

namespace FrostweepGames.Plugins.DesktopRuntimeMonitorSwitch
{
	public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);
}
