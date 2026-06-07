using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerManagerMember
	{
		public uint MemberId { get; private set; }

		public string TeamId { get; private set; }

		public string InitialTeam { get; private set; }

		public ulong Xuid { get; private set; }

		public string DebugGamertag { get; private set; }

		public bool IsLocal { get; private set; }

		public bool IsInLobby { get; private set; }

		public bool IsInGame { get; private set; }

		public XblMultiplayerSessionMemberStatus Status { get; private set; }

		public string ConnectionAddress { get; private set; }

		public string PropertiesJson { get; private set; }

		public string DeviceToken { get; private set; }

		internal XblMultiplayerManagerMember(XGamingRuntime.Interop.XblMultiplayerManagerMember interopStruct)
		{
		}
	}
}
