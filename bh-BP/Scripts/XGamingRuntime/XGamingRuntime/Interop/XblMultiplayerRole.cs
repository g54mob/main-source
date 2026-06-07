using System;

namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerRole
	{
		private unsafe readonly XblMultiplayerRoleType* RoleType;

		internal readonly UTF8StringPtr Name;

		private unsafe readonly ulong* MemberXuids;

		internal readonly uint MemberCount;

		internal readonly uint TargetCount;

		internal readonly uint MaxMemberCount;

		internal T GetRoleType<T>(Func<XblMultiplayerRoleType, T> ctor) where T : class
		{
			return null;
		}

		internal T[] GetMemberXuids<T>(Func<ulong, T> ctor)
		{
			return null;
		}
	}
}
