using System;

namespace Amazon
{
	[Flags]
	public enum LoggingOptions
	{
		None = 0,
		SystemDiagnostics = 2,
		Console = 0x10
	}
}
