using Unity.Entities;
using Unity.Mathematics;

[MaximumChunkCapacity(4)]
public struct FishingNetSlotVisualBuffer : IBufferElementData
{
	public bool hasFish;

	public bool hasBait;

	public float2 visualOffset;
}
