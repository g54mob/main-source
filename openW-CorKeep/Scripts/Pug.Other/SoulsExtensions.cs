public static class SoulsExtensions
{
	public static ConditionData GetSoulConditionData(SoulID soulID)
	{
		return soulID switch
		{
			SoulID.SoulOfAzeos => new ConditionData
			{
				conditionID = ConditionID.ChanceOnCritToSpawnThunderBeam,
				value = 10
			}, 
			SoulID.SoulOfOmoroth => new ConditionData
			{
				conditionID = ConditionID.ChanceOnRangeHitToSpawnOctopusBossProjectile,
				value = 3
			}, 
			SoulID.SoulOfScarab => new ConditionData
			{
				conditionID = ConditionID.ChanceOnHitToSpawnScarabBossProjectile,
				value = 5
			}, 
			SoulID.SoulOfNatureHydra => new ConditionData
			{
				conditionID = ConditionID.IncreasedMaxHealthPercentage,
				value = 10
			}, 
			SoulID.SoulOfSeaHydra => new ConditionData
			{
				conditionID = ConditionID.ArmorPercentageIncrease,
				value = 100
			}, 
			SoulID.SoulOfDesertHydra => new ConditionData
			{
				conditionID = ConditionID.AllDamageIncrease,
				value = 100
			}, 
			_ => default(ConditionData), 
		};
	}
}
