using System;

namespace Oculus.Platform
{
	public class AdvancedAbuseReportOptions
	{
		private IntPtr Handle;

		public AdvancedAbuseReportOptions()
		{
			Handle = CAPI.ovr_AdvancedAbuseReportOptions_Create();
		}

		public void SetObjectType(string value)
		{
			CAPI.ovr_AdvancedAbuseReportOptions_SetObjectType(Handle, value);
		}

		public void SetReportType(AbuseReportType value)
		{
			CAPI.ovr_AdvancedAbuseReportOptions_SetReportType(Handle, value);
		}

		public void SetVideoMode(AbuseReportVideoMode value)
		{
			CAPI.ovr_AdvancedAbuseReportOptions_SetVideoMode(Handle, value);
		}

		public static explicit operator IntPtr(AdvancedAbuseReportOptions options)
		{
			return options?.Handle ?? IntPtr.Zero;
		}

		~AdvancedAbuseReportOptions()
		{
			CAPI.ovr_AdvancedAbuseReportOptions_Destroy(Handle);
		}
	}
}
