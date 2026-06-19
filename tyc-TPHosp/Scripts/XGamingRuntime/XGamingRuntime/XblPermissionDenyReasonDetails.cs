using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPermissionDenyReasonDetails
	{
		public XblPermissionDenyReason Reason { get; }

		public XblPrivilege RestrictedPrivilege { get; }

		public XblPrivacySetting RestrictedPrivacySetting { get; }

		internal XblPermissionDenyReasonDetails(XGamingRuntime.Interop.XblPermissionDenyReasonDetails interopStruct)
		{
			Reason = interopStruct.reason;
			RestrictedPrivilege = interopStruct.restrictedPrivilege;
			RestrictedPrivacySetting = interopStruct.restrictedPrivacySetting;
		}
	}
}
