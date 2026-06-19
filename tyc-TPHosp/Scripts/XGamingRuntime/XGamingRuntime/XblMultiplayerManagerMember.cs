using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerManagerMember
	{
		public uint MemberId { get; }

		public string TeamId { get; }

		public ulong Xuid { get; }

		public string DebugGamertag { get; }

		public bool IsLocal { get; }

		public bool IsInLobby { get; }

		public bool IsInGame { get; }

		public XblMultiplayerSessionMemberStatus Status { get; }

		public string ConnectionAddress { get; }

		public string PropertiesJson { get; }

		public string DeviceToken { get; }

		internal XblMultiplayerManagerMember(XGamingRuntime.Interop.XblMultiplayerManagerMember interopStruct)
		{
			MemberId = interopStruct.MemberId;
			TeamId = interopStruct.TeamId.GetString();
			Xuid = interopStruct.Xuid;
			DebugGamertag = interopStruct.DebugGamertag.GetString();
			IsLocal = interopStruct.IsLocal.Value;
			IsInLobby = interopStruct.IsInLobby.Value;
			IsInGame = interopStruct.IsInGame.Value;
			Status = interopStruct.Status;
			ConnectionAddress = interopStruct.ConnectionAddress.GetString();
			PropertiesJson = interopStruct.PropertiesJson.GetString();
			DeviceToken = interopStruct.DeviceToken.GetString();
		}
	}
}
