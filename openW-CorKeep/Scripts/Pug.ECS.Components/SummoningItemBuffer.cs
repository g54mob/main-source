using Unity.Entities;

[InternalBufferCapacity(0)]
public struct SummoningItemBuffer : IBufferElementData
{
	public ObjectID bossToSummon;
}
