using Unity.Entities;

public struct InitializeRandomConditionsCD : IComponentData, IQueryTypeParameter
{
	public Entity EntityToInitialize;
}
