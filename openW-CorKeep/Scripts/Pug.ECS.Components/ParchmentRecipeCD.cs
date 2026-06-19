using Unity.Entities;

public struct ParchmentRecipeCD : IComponentData, IQueryTypeParameter
{
	public ObjectDataCD objectToCraft;

	public ObjectID requiresNearbyObject;
}
