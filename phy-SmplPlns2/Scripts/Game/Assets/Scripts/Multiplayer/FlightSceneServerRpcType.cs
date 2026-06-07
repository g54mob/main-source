namespace Assets.Scripts.Multiplayer
{
	public enum FlightSceneServerRpcType : byte
	{
		StartLocations_GetDynamicLocation = 0,
		StartLocations_SetDynamicLocationUnavailable = 1,
		FlightObjectManager_SetObjectSpawnEnabledState = 2,
		TeamAggressionManager_Sync = 3,
		NetworkedActivityManager_CreateActivity = 4
	}
}
