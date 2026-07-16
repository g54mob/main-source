public static class Delegates
{
	public delegate void HealthChangeHandler(HealthChangeInfo info);

	public delegate void HealthChangeRefHandler(ref HealthChangeInfo info);

	public delegate void ProjectileSpawnHandler(ProjectileSpawnEventArgs args);

	public delegate void EnemyDestroyedHandler(EnemyBase enemy, HealthChangeInfo info);

	public delegate void StatusEffectHandler(Unit unit, StatusEffect statusEffect);
}
