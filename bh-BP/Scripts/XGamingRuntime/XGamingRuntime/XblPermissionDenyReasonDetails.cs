using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPermissionDenyReasonDetails
	{
		public XblPermissionDenyReason Reason { get; private set; }

		public XblPrivilege RestrictedPrivilege { get; private set; }

		public XblPrivacySetting RestrictedPrivacySetting { get; private set; }

		internal XblPermissionDenyReasonDetails(XGamingRuntime.Interop.XblPermissionDenyReasonDetails interopStruct)
		{
		}
	}
}
