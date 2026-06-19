using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct WorldInfoCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool greatWallHasBeenLowered;

	[GhostField]
	public bool slimeMerchantExists;

	[GhostField]
	public bool coreIsActivated;

	[GhostField]
	public bool guestMode;

	[GhostField]
	public bool simulationDisabled;

	public bool larvaBossStatueIsActivated;

	public bool hiveBossStatueIsActivated;

	[GhostField]
	public bool coreBossHasBeenKilled;

	[GhostField]
	public bool wallBossHasBeenKilled;

	[GhostField]
	public bool birdBossBeenKilled;

	[GhostField]
	public bool octopusBossHasBeenKilled;

	[GhostField]
	public bool scarabHasBeenKilled;

	[GhostField]
	public bool hydraBossNatureHasBeenKilled;

	[GhostField]
	public bool hydraBossSeaHasBeenKilled;

	[GhostField]
	public bool hydraBossDesertHasBeenKilled;

	[GhostField]
	public bool giantCicadaBossHasBeenKilled;

	[GhostField]
	public bool robotBossHasBeenKilled;

	[GhostField]
	public int bossesKilled;

	[GhostField]
	public int numberPlayers;

	[GhostField]
	public WorldMode worldModeMask;

	[GhostField]
	public bool pvpEnabled;

	[GhostField]
	public bool hostConsoleEnabled;

	[GhostField]
	public bool consoleCommandUsedThisSession;

	public readonly bool IsWorldModeEnabled(WorldMode worldMode)
	{
		return (worldModeMask & worldMode) != 0;
	}
}
