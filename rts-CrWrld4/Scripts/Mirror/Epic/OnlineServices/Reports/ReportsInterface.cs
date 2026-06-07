using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Reports
{
	public sealed class ReportsInterface : Handle
	{
		public const int ReportdescriptionMaxLength = 512;

		public const int SendplayerbehaviorreportApiLatest = 1;

		public ReportsInterface()
		{
		}

		public ReportsInterface(IntPtr innerHandle)
		{
		}

		public void SendPlayerBehaviorReport(SendPlayerBehaviorReportOptions options, object clientData, OnSendPlayerBehaviorReportCompleteCallback completionDelegate)
		{
		}

		internal static void OnSendPlayerBehaviorReportCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern void EOS_Reports_SendPlayerBehaviorReport(IntPtr handle, IntPtr options, IntPtr clientData, OnSendPlayerBehaviorReportCompleteCallbackInternal completionDelegate);
	}
}
