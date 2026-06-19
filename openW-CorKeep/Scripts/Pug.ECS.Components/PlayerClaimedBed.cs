using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlayerClaimedBed : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity claimedBedEntity;

	[GhostField]
	public float2 position;

	[GhostField]
	public bool canAttemptSleep;
}
