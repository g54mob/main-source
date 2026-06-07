using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Logging
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LogMessageInternal
	{
		private IntPtr m_Category;

		private IntPtr m_Message;

		private LogLevel m_Level;

		public string Category => null;

		public string Message => null;

		public LogLevel Level => default(LogLevel);
	}
}
