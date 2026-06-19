using Unity.Entities;

public struct InitializeRandomCD : IComponentData, IQueryTypeParameter
{
	public Entity EntityToInitialize;
}
