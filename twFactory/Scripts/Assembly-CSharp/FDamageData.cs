public class FDamageData
{
	public float damage;

	public EDamageMultiplier healthMultiplier;

	public EDamageMultiplier armorMultiplier;

	public EDamageMultiplier shieldMultiplier;

	public FDamageData(float damage, EDamageMultiplier healthMultiplier, EDamageMultiplier armorMultiplier, EDamageMultiplier shieldMultiplier)
	{
		this.damage = damage;
		this.healthMultiplier = healthMultiplier;
		this.armorMultiplier = armorMultiplier;
		this.shieldMultiplier = shieldMultiplier;
	}

	public FDamageData(FDamageData damageData)
	{
		damage = damageData.damage;
		healthMultiplier = damageData.healthMultiplier;
		armorMultiplier = damageData.armorMultiplier;
		shieldMultiplier = damageData.shieldMultiplier;
	}
}
