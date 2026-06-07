namespace Motorways
{
	public enum TileEditResultCode
	{
		Success = 0,
		NotInitialized = 1,
		InvalidTileCoordinate = 2,
		CannotConnectToCarpark = 3,
		CannotConnectHouseToBridge = 4,
		NotEnoughUpgrades = 5,
		NotEnoughConcrete = 6,
		NotEnoughConcreteForMotorway = 7,
		CannotClearTile = 8,
		MotorwayTooShort = 9,
		MotorwayBlockedByMountain = 10,
		CannotConnectHouseToTunnel = 11,
		ClearForSpecificTypeNotNeeded = 12,
		EditAlreadyExists = 13,
		CannotCreateBridge = 14,
		CannotCreateTunnel = 15,
		NoDeletableRoads = 16,
		NoDeletableUpgrade = 17,
		CannotConnectHouseToRail = 18,
		CannotCreateCrossing = 19
	}
}
