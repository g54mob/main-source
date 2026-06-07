using System;

namespace Rewired.HID
{
	[Flags]
	[CustomObfuscation(rename = false)]
	internal enum OutputReportOptions
	{
		None = 0,
		WriteDirect = 1,
		IgnoreExpectedReportSize = 2
	}
}
