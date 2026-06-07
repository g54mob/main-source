using System;

namespace XGamingRuntime.Interop
{
	internal struct XblPermissionCheckResult
	{
		internal readonly NativeBool isAllowed;

		internal readonly ulong targetXuid;

		internal readonly XblAnonymousUserType targetUserType;

		internal readonly XblPermission permissionRequested;

		private unsafe readonly XblPermissionDenyReasonDetails* reasons;

		internal readonly SizeT reasonsCount;

		internal T[] GetReasons<T>(Func<XblPermissionDenyReasonDetails, T> ctor)
		{
			return null;
		}
	}
}
