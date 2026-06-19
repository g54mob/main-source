using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct WayPointCD : IComponentData, IQueryTypeParameter
{
	public float distanceToActivateSQ;

	[GhostField]
	public bool isCoreWaypoint;
}
