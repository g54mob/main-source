public interface IAffectedBySlime : ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation
{
	float SlimeDamageTimer { get; set; }

	void ApplySlimeSnare();
}
