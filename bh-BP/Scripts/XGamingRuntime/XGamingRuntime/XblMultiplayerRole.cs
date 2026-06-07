using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerRole
	{
		public XblMultiplayerRoleType RoleType { get; private set; }

		public string Name { get; private set; }

		public ulong[] MemberXuids { get; private set; }

		public uint TargetCount { get; private set; }

		public uint MaxMemberCount { get; private set; }

		internal XblMultiplayerRole(XGamingRuntime.Interop.XblMultiplayerRole interopStruct)
		{
		}
	}
}
