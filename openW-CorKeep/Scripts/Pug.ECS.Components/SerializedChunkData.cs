using Unity.Entities;

public struct SerializedChunkData : IComponentData, IQueryTypeParameter
{
	public int StartIndex;

	public int Capacity;

	public int Count;

	public uint ChangeVersion;

	public int ChunkListIndex;
}
