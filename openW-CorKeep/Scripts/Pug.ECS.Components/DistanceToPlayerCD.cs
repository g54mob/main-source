using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct DistanceToPlayerCD : IComponentData, IQueryTypeParameter
{
	public bool isVisible;

	public float minDistanceSq;

	public float maxDistanceSq;

	public Entity closestPlayer;
}
