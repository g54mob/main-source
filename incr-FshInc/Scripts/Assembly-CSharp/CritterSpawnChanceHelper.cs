public static class CritterSpawnChanceHelper
{
	public static float GetValue(CritterSpawnChance chance)
	{
		return chance switch
		{
			CritterSpawnChance.Always => 1f, 
			CritterSpawnChance.VeryLikely => 0.8f, 
			CritterSpawnChance.Likely => 0.6f, 
			CritterSpawnChance.Sometimes => 0.4f, 
			CritterSpawnChance.Rare => 0.2f, 
			CritterSpawnChance.VeryRare => 0.1f, 
			_ => 1f, 
		};
	}
}
