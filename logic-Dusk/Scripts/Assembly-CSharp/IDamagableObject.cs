public interface IDamagableObject : IHasHitpoints
{
	string guiStatus { get; }

	void TakeDamage(float damage, DamageType type, ICombatTarget attacker);
}
