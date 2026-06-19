using Unity.Entities;

public struct RegisterTargetToObjectLookupCD : IComponentData, IQueryTypeParameter
{
	public Entity targetEntity;

	public ObjectID objectID;

	public int variation;
}
