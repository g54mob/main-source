using Unity.Entities;

public struct OverrideTimeBeforeDestroy : IComponentData, IQueryTypeParameter
{
	public float timeBeforeDestroy;
}
