namespace XRL.World
{
	public enum Suspendability
	{
		Active = 0,
		Pinned = 1,
		TooRecentlyActive = 2,
		InsideInterior = 3,
		CompanionWhilePlayerIsOnWorldMap = 4,
		CompanionTryingToJoinPartyLeader = 5,
		Suspendable = 6
	}
}
