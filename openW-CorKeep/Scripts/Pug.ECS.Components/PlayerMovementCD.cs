using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct PlayerMovementCD : IComponentData, IQueryTypeParameter
{
	[GhostField(Composite = true)]
	public float2 targetMovementVelocity;

	public float2 adjustedMovementVelocity;

	public float2 anyVelocityAffectorForce;

	public float movementSpeed;

	public float noClipMovementSpeedMultipler;
}
