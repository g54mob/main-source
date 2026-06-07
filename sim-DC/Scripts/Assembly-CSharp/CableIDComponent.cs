using Unity.Entities;

public struct CableIDComponent : IComponentData, IQueryTypeParameter
{
	public int CableId;

	public int SwitchId;
}
