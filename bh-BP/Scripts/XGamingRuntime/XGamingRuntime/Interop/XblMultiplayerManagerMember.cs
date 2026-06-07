namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerManagerMember
	{
		internal readonly uint MemberId;

		internal readonly UTF8StringPtr TeamId;

		internal readonly UTF8StringPtr InitialTeam;

		internal readonly ulong Xuid;

		internal readonly UTF8StringPtr DebugGamertag;

		internal readonly NativeBool IsLocal;

		internal readonly NativeBool IsInLobby;

		internal readonly NativeBool IsInGame;

		internal readonly XblMultiplayerSessionMemberStatus Status;

		internal readonly UTF8StringPtr ConnectionAddress;

		internal readonly UTF8StringPtr PropertiesJson;

		internal readonly UTF8StringPtr DeviceToken;

		internal XblMultiplayerManagerMember(XGamingRuntime.XblMultiplayerManagerMember publicObject, DisposableCollection disposableCollection)
		{
			MemberId = 0u;
			TeamId = default(UTF8StringPtr);
			InitialTeam = default(UTF8StringPtr);
			Xuid = 0uL;
			DebugGamertag = default(UTF8StringPtr);
			IsLocal = default(NativeBool);
			IsInLobby = default(NativeBool);
			IsInGame = default(NativeBool);
			Status = default(XblMultiplayerSessionMemberStatus);
			ConnectionAddress = default(UTF8StringPtr);
			PropertiesJson = default(UTF8StringPtr);
			DeviceToken = default(UTF8StringPtr);
		}
	}
}
