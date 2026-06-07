using System.Collections.Generic;

namespace Gh
{
	public static class CrashHelper
	{
		public class CrashInfo
		{
			public string AppVersion { get; set; }

			public string GpuModule { get; set; }

			public string[] CrashLines { get; set; }

			public string[] PriorToCrashLines { get; set; }

			public Dictionary<string, object> SystemInfo { get; set; }

			public string GetCrashReportTextContent()
			{
				return null;
			}
		}

		private static readonly string[] _gpuDriverLibs;

		private const string CrashIndicatorLine = "OUTPUTTING STACK TRACE";

		public static void ShowCrashWarningIfPreviousCashWasDetected()
		{
		}
	}
}
