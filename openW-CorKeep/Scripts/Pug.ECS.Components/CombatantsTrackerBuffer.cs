using Unity.Entities;

[InternalBufferCapacity(0)]
public struct CombatantsTrackerBuffer : IBufferElementData
{
	public Entity Target;

	public float RemovalTimer;
}
