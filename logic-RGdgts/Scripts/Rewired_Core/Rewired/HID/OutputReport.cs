using System;

namespace Rewired.HID
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal struct OutputReport
	{
		public IntPtr buffer;

		public int bufferLength;

		public int reportLength;

		public OutputReportOptions options;

		public bool IsValid => false;

		public OutputReport(IntPtr P_0, int P_1, int P_2)
		{
			buffer = (IntPtr)0;
			bufferLength = 0;
			reportLength = 0;
			options = default(OutputReportOptions);
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
