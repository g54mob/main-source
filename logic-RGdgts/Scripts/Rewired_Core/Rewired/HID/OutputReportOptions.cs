using System;

namespace Rewired.HID
{
	[CustomObfuscation]
	[Flags]
	internal enum OutputReportOptions
	{
		None = 0,
		WriteDirect = 1,
		IgnoreExpectedReportSize = 2
	}
}
