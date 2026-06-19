using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct NearbyEntitiesTrackerCD : IComponentData, IQueryTypeParameter
{
	public uint detectsLayer;

	public float radius;

	public float cooldownTimer;

	public float radiusGrowthRate;

	public float radiusAfterGrowth;

	public bool ignoreCooldown;

	public bool grow;
}
