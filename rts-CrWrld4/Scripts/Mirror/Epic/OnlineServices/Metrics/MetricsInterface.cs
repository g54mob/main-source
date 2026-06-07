using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Metrics
{
	public sealed class MetricsInterface : Handle
	{
		public const int BeginplayersessionApiLatest = 1;

		public const int EndplayersessionApiLatest = 1;

		public MetricsInterface()
		{
		}

		public MetricsInterface(IntPtr innerHandle)
		{
		}

		public Result BeginPlayerSession(BeginPlayerSessionOptions options)
		{
			return default(Result);
		}

		public Result EndPlayerSession(EndPlayerSessionOptions options)
		{
			return default(Result);
		}

		[PreserveSig]
		internal static extern Result EOS_Metrics_BeginPlayerSession(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_Metrics_EndPlayerSession(IntPtr handle, IntPtr options);
	}
}
