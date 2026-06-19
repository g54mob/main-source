using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct PickUpItemCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity targetEntity;

	[GhostField]
	public float2 targetPrevPos;

	public float2 targetPrevPosVisually;

	[GhostField]
	public float additionalDistanceMoved;

	public float additionalDistanceMovedVisually;

	[GhostField]
	public float distanceWhenStartingPickUp;

	public float distanceWhenStartingPickUpVisually;

	[GhostField]
	public NetworkTick tickWhenStartingPickUp;

	[GhostField]
	public PickUpItemState state;

	[GhostField]
	public bool ignoreRayChecksForPickup;
}
