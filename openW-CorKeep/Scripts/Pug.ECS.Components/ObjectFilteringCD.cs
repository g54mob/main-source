using Unity.Entities;
using Unity.NetCode;

public struct ObjectFilteringCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public FilterType filterType;

	[GhostField]
	public ObjectID filterObject;

	[GhostField]
	public int filterVariation;
}
