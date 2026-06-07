using System;

[Serializable]
public class Stats
{
	public long rebirthNumber;

	public long highestBoss;

	public long lifeTimeEnergy;

	public long advBossesKilled;

	public float highestDamageDealt;

	public float highestDamageTaken;

	public long totalExp;

	public double totalGold;

	public long titansDefeated;

	public long bossesDefeated;

	public double lastBloodMagic;

	public long poopUsed;

	public Stats()
	{
		rebirthNumber = 0L;
		highestBoss = 0L;
		lifeTimeEnergy = 0L;
		advBossesKilled = 0L;
		highestDamageDealt = 0f;
		highestDamageTaken = 0f;
		totalExp = 0L;
		totalGold = 0.0;
		titansDefeated = 0L;
		bossesDefeated = 0L;
		lastBloodMagic = 0.0;
		poopUsed = 0L;
	}

	public void validateStats()
	{
		if (double.IsInfinity(totalGold))
		{
			totalGold = double.MaxValue;
		}
	}
}
