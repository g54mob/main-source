using System.Reflection;

namespace GUPS.EasyPerformanceMonitor.Window
{
	[Obfuscation(Exclude = true)]
	public enum EMonitorWindowPosition : byte
	{
		Top = 0,
		Top_Left = 1,
		Top_Right = 2,
		Bottom = 3,
		Bottom_Left = 4,
		Bottom_Right = 5,
		Free = 10
	}
}
