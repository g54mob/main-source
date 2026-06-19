using Unity.Entities;

public struct DisplayConditionAsBarWhenEquippedCD : IComponentData, IQueryTypeParameter
{
	public ConditionID conditionID;
}
