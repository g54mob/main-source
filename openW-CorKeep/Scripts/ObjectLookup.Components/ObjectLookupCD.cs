using Unity.Entities;

public struct ObjectLookupCD : IComponentData, IQueryTypeParameter
{
	public ObjectLookup lookup;
}
