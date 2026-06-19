using Unity.Entities;

[InternalBufferCapacity(0)]
public struct TileEffectPuffsBuffer : IBufferElementData
{
	public PuffParams destroyPuff;
}
