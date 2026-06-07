using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Reports
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct SendPlayerBehaviorReportOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_ReporterUserId;

		private IntPtr m_ReportedUserId;

		private PlayerReportsCategory m_ReportCategory;

		private IntPtr m_ReportDescription;

		public ProductUserId ReporterUserId
		{
			set
			{
			}
		}

		public ProductUserId ReportedUserId
		{
			set
			{
			}
		}

		public PlayerReportsCategory ReportCategory
		{
			set
			{
			}
		}

		public string ReportDescription
		{
			set
			{
			}
		}

		public void Set(SendPlayerBehaviorReportOptions other)
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
