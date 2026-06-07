using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UI
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct ReportKeyEventOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_PlatformSpecificInputData;

		public IntPtr PlatformSpecificInputData
		{
			set
			{
			}
		}

		public void Set(ReportKeyEventOptions other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
