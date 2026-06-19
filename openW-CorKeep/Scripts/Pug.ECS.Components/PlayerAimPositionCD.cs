using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlayerAimPositionCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float3 position;

	[GhostField]
	public bool isHittingSomething;

	[GhostField]
	public float beamStrength;
}
