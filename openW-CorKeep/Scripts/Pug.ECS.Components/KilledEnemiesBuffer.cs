using Unity.Entities;

[InternalBufferCapacity(0)]
public struct KilledEnemiesBuffer : IBufferElementData
{
	public ObjectDataCD objectData;
}
