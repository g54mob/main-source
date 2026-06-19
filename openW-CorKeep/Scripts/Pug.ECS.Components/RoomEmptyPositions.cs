using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(0)]
public struct RoomEmptyPositions : IBufferElementData
{
	public int2 Value;
}
