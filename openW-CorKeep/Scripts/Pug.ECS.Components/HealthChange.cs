using Unity.Entities;
using Unity.Mathematics;

public struct HealthChange
{
	public Entity entity;

	public Entity causedByEntity;

	public float2 optionalPositionToDropLootWhenDamaged;

	public int amount;

	public bool bypassMaxDamagePerHit;

	public bool skipWallAndRootsLootDropOnDestroy;

	public bool skipLootDropOnDestroy;

	public bool skipLootDropIfDestroyPlants;

	public bool wasKnockedBack;

	public bool bypassDamageReduction;

	public bool pullLootToPlayer;

	public bool wasKilled;

	public bool damagedByExplosion;

	public bool applyToNonPredicted;
}
