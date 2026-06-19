using Unity.Entities;

public struct EquipmentSkinCD : IComponentData, IQueryTypeParameter
{
	public DataBlockAddress skin;
}
