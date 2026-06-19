using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(5)]
public struct PathFindNodeBuffer : IBufferElementData
{
	public const int MINIMUM_NODE_COUNT = 3;

	public const int MAXIMUM_NODE_COUNT = 5;

	public int2 position;
}
