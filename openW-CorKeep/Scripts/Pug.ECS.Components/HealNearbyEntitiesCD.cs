using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HealNearbyEntitiesCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool isActive;

	public FactionID healsTargetsOfFaction;

	public int healthPerSecond;

	public float radius;
}
