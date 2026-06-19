using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ExplosionCD : IComponentData, IQueryTypeParameter
{
	public const float PUSH_BACK_FORCE = 2f;

	[GhostField]
	public bool hasDealtDamage;

	[GhostField]
	public int damage;

	[GhostField]
	public int tileDamage;

	[GhostField]
	public float radius;

	[GhostField]
	public TickTimer delayTimer;

	[GhostField]
	public Entity triggerEntityToIgnoreExplosionDamage;

	public Entity nonSyncedTriggerEntityToIgnoreExplosionDamage;

	[GhostField]
	public int level;

	[GhostField]
	public ObjectID spawnNapalmObjectID;

	[GhostField]
	public int spawnNapalmVariation;

	[GhostField]
	public int napalmIncreasedBurningDamagePercentage;

	[GhostField]
	public bool cameFromExplosive;

	[GhostField]
	public bool cameFromBomb;

	[GhostField]
	public ExplosionPushbackLevel explosionPushback;
}
