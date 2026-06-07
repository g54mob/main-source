namespace XGamingRuntime.Interop
{
	internal struct XblPermissionDenyReasonDetails
	{
		internal readonly XblPermissionDenyReason reason;

		internal readonly XblPrivilege restrictedPrivilege;

		internal readonly XblPrivacySetting restrictedPrivacySetting;

		internal XblPermissionDenyReasonDetails(XGamingRuntime.XblPermissionDenyReasonDetails publicObject)
		{
			reason = default(XblPermissionDenyReason);
			restrictedPrivilege = default(XblPrivilege);
			restrictedPrivacySetting = default(XblPrivacySetting);
		}
	}
}
