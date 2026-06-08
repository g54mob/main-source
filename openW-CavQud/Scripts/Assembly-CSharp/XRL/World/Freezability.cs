namespace XRL.World
{
	public enum Freezability
	{
		TooRecentlyActive = 0,
		InsideInterior = 1,
		IsWorldMap = 2,
		FormerPlayerObject = 3,
		CompanionWhilePlayerIsOnWorldMap = 4,
		CompanionTryingToJoinPartyLeader = 5,
		Freezable = 6
	}
}
