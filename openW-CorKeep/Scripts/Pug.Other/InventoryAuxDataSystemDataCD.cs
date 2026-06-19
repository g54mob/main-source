using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

public struct InventoryAuxDataSystemDataCD : IComponentData, IQueryTypeParameter
{
	public NativeParallelHashMap<int, uint> _typeIndexToTypeHash;

	public NativeParallelHashMap<uint, UnsafeList<Entity>> _typeHashToLookup;

	public NativeParallelHashMap<uint, Entity> _typeHashToPrefabEntity;

	public NativeList<int> _freeIndicesList;

	public NativeReference<int> _indexCounter;
}
