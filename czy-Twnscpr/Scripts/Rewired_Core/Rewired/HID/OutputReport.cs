using System;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal struct OutputReport
	{
		public IntPtr buffer;

		public int bufferLength;

		public int reportLength;

		public OutputReportOptions options;

		public bool IsValid => false;

		public OutputReport(IntPtr buffer, int bufferLength, int reportLength)
		{
			this.buffer = (IntPtr)0;
			this.bufferLength = 0;
			this.reportLength = 0;
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
