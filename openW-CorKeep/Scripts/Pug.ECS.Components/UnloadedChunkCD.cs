using Unity.Entities;
using Unity.Mathematics;

public struct UnloadedChunkCD : IComponentData, IQueryTypeParameter
{
	public int ChunkListIndex;

	public int2 MinPosition;

	public int2 MaxPosition;
}
