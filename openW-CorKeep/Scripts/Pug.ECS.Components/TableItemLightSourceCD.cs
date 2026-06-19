using Unity.Entities;

public struct TableItemLightSourceCD : IComponentData, IQueryTypeParameter
{
	public SimpleConditionData Condition;
}
