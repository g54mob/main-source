using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPermissionCheckResult
	{
		public bool IsAllowed { get; }

		public ulong TargetXuid { get; }

		public XblPermission PermissionRequested { get; }

		public XblPermissionDenyReasonDetails[] Reasons { get; }

		internal XblPermissionCheckResult(XGamingRuntime.Interop.XblPermissionCheckResult interopStruct)
		{
			IsAllowed = interopStruct.isAllowed.Value;
			TargetXuid = interopStruct.targetXuid;
			PermissionRequested = interopStruct.permissionRequested;
			Reasons = interopStruct.GetReasons((XGamingRuntime.Interop.XblPermissionDenyReasonDetails x) => new XblPermissionDenyReasonDetails(x));
		}
	}
}
