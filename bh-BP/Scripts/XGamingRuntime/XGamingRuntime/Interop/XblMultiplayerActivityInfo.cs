namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerActivityInfo
	{
		internal readonly ulong xuid;

		internal readonly UTF8StringPtr connectionString;

		internal readonly XblMultiplayerActivityJoinRestriction joinRestriction;

		internal readonly SizeT maxPlayers;

		internal readonly SizeT currentPlayers;

		internal readonly UTF8StringPtr groupId;

		internal readonly XblMultiplayerActivityPlatform platform;

		internal XblMultiplayerActivityInfo(XGamingRuntime.XblMultiplayerActivityInfo publicObject, DisposableCollection disposableCollection)
		{
			xuid = 0uL;
			connectionString = default(UTF8StringPtr);
			joinRestriction = default(XblMultiplayerActivityJoinRestriction);
			maxPlayers = default(SizeT);
			currentPlayers = default(SizeT);
			groupId = default(UTF8StringPtr);
			platform = default(XblMultiplayerActivityPlatform);
		}
	}
}
