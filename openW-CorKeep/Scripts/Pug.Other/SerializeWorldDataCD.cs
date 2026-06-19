using Unity.Collections;
using Unity.Entities;

public struct SerializeWorldDataCD : IComponentData, IQueryTypeParameter
{
	public struct FreeEntityRange
	{
		public int StartIndex;

		public int Capacity;
	}

	public NativeList<Entity> serializedEntities;

	public NativeList<FreeEntityRange> freeRangeList;

	public NativeList<SerializedChunkData> chunks;

	public NativeList<int> freeChunks;

	public EntityManager entityManager;

	public SerializeWorldState State;
}
