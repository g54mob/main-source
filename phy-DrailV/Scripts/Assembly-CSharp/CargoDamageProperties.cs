public struct CargoDamageProperties
{
	public float maxHealth;

	public float damageTolerance;

	public float damageMultiplier;

	public float damageResistance;

	public float fireDamageMultiplier;

	public float fireResistance;

	public CargoDamageProperties(float maxHealth = 100f, float damageTolerance = 0.05f, float damageMultiplier = 1f, float damageResistance = 2f, float fireDamageMultiplier = 1f, float fireResistance = 1f)
	{
		this.maxHealth = maxHealth;
		this.damageTolerance = damageTolerance;
		this.damageMultiplier = damageMultiplier;
		this.damageResistance = damageResistance;
		this.fireDamageMultiplier = fireDamageMultiplier;
		this.fireResistance = fireResistance;
	}
}
