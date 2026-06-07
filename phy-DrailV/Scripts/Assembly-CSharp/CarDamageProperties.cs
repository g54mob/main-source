public struct CarDamageProperties
{
	public float maxHealth;

	public float damageResistance;

	public float damageMultiplier;

	public float fireResistance;

	public float fireDamageMultiplier;

	public float damageTolerance;

	public bool ignoreDamage;

	public CarDamageProperties(float maxHealth, float damageResistance, float damageMultiplier, float fireResistance, float fireDamageMultiplier, float damageTolerance, bool ignoreDamage = false)
	{
		this.maxHealth = maxHealth;
		this.damageResistance = damageResistance;
		this.damageMultiplier = damageMultiplier;
		this.fireResistance = fireResistance;
		this.fireDamageMultiplier = fireDamageMultiplier;
		this.damageTolerance = damageTolerance;
		this.ignoreDamage = ignoreDamage;
	}
}
