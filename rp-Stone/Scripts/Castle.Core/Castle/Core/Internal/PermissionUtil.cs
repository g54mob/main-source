using System;
using System.Security;
using System.Security.Permissions;

namespace Castle.Core.Internal
{
	public static class PermissionUtil
	{
		[SecuritySafeCritical]
		public static bool IsGranted(this IPermission permission)
		{
			PermissionSet permissionSet = new PermissionSet(PermissionState.None);
			permissionSet.AddPermission(permission);
			return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
		}
	}
}
