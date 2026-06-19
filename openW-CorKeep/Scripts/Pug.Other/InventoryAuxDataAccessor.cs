using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

public struct InventoryAuxDataAccessor
{
	private InventoryAuxDataSystemDataCD _systemData;

	public InventoryAuxDataAccessor(InventoryAuxDataSystemDataCD systemData)
	{
		_systemData = systemData;
	}

	public bool HasComponent<T>(int index) where T : unmanaged, IComponentData
	{
		TypeIndex typeIndex = ComponentType.ReadOnly<T>().TypeIndex;
		Entity entity;
		uint typeHash;
		UnsafeList<Entity> lookup;
		return _systemData.TryGetEntity(index, typeIndex, out entity, out typeHash, out lookup);
	}

	public bool HasBuffer<T>(int index) where T : unmanaged, IBufferElementData
	{
		TypeIndex typeIndex = ComponentType.ReadOnly<T>().TypeIndex;
		Entity entity;
		uint typeHash;
		UnsafeList<Entity> lookup;
		return _systemData.TryGetEntity(index, typeIndex, out entity, out typeHash, out lookup);
	}

	public bool TryGetComponentData<T>(int index, ComponentLookup<T> dataFromEntity, out T data) where T : unmanaged, IComponentData
	{
		TypeIndex typeIndex = ComponentType.ReadOnly<T>().TypeIndex;
		if (!_systemData.TryGetEntity(index, typeIndex, out var entity, out var _, out var _))
		{
			data = default(T);
			return false;
		}
		return dataFromEntity.TryGetComponent(entity, out data);
	}

	public bool TryGetBuffer<T>(int index, BufferLookup<T> dataFromEntity, out DynamicBuffer<T> buffer) where T : unmanaged, IBufferElementData
	{
		TypeIndex typeIndex = TypeManager.GetTypeIndex<T>();
		if (!_systemData.TryGetEntity(index, typeIndex, out var entity, out var _, out var _))
		{
			buffer = default(DynamicBuffer<T>);
			return false;
		}
		return dataFromEntity.TryGetBuffer(entity, out buffer);
	}

	public void SetComponentData<T>(int index, EntityCommandBuffer ecb, T data) where T : unmanaged, IComponentData
	{
		TypeIndex typeIndex = TypeManager.GetTypeIndex<T>();
		if (_systemData.TryGetEntity(index, typeIndex, out var entity, out var _, out var _))
		{
			ecb.SetComponent(entity, data);
		}
	}

	public DynamicBuffer<T> SetBuffer<T>(int index, EntityCommandBuffer ecb) where T : unmanaged, IBufferElementData
	{
		TypeIndex typeIndex = ComponentType.ReadOnly<T>().TypeIndex;
		if (!_systemData.TryGetEntity(index, typeIndex, out var entity, out var _, out var _))
		{
			return default(DynamicBuffer<T>);
		}
		return ecb.SetBuffer<T>(entity);
	}
}
