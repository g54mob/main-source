using System;

namespace XGamingRuntime.Interop
{
	internal struct XblSocialManagerEvent
	{
		internal readonly XUserHandle user;

		internal readonly XblSocialManagerEventType eventType;

		internal readonly int hr;

		internal readonly XblSocialManagerUserGroupHandle loadedGroup;

		internal readonly IntPtr[] usersAffected;

		internal XblSocialManagerUser[] GetUserArray()
		{
			return null;
		}
	}
}
