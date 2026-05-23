namespace Battle
{
	public enum eSearchType
	{
		None = 0,
		SearchMostNearDistance = 1,
		SearchMostFarDistance = 2,
		SearchMostHighHp = 3,
		SearchMostLowHp = 4,
		FirstHit = 5,
		OneHitDown = 6,
		IgnoreSlow = 7,
		SearchEnemy = 8,
		FilterEffect = 9,
		FewestTargetCount = 10,
		ExceptOverKill = 11,
		RandomOne = 12,
		SearchMostHighMaxHp = 13,
		RemoveTargetedAll = 101,
		RemoveTargetedSameHero = 102,
		RemoveDistanceGate = 111,
		RemovePriorityIsLarge = 121,
		RemoveEnemyType = 131
	}
}
