using Unity.Entities;

public struct InventoryAuxDataPrefabBuffer : IBufferElementData
{
	public Entity Entity;

	public uint TypeHash;
}
