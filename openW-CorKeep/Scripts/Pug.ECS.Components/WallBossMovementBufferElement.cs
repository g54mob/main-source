using Unity.Entities;

[InternalBufferCapacity(4)]
public struct WallBossMovementBufferElement : IBufferElementData
{
	public int onTotalAliveTargets;

	public float decelerationSpeed;

	public float decelerationDurationOnEnter;

	public float accelerationSpeed;

	public float maxSpeed;
}
