using Unity.Entities;

public struct ObjectTypeCD : IComponentData, IQueryTypeParameter
{
	public ObjectType Value;
}
