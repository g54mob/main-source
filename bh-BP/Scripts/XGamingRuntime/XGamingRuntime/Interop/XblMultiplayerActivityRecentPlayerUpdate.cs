namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerActivityRecentPlayerUpdate
	{
		internal readonly ulong xuid;

		internal readonly XblMultiplayerActivityEncounterType encounterType;

		internal XblMultiplayerActivityRecentPlayerUpdate(XGamingRuntime.XblMultiplayerActivityRecentPlayerUpdate publicObject)
		{
			xuid = 0uL;
			encounterType = default(XblMultiplayerActivityEncounterType);
		}
	}
}
