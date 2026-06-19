using Unity.Entities;
using Unity.Mathematics;

public struct ChangeVariationWhenPlayerHoldObjectNearbyCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectID;

	public float3 offset;

	public float radius;

	public int variationToChangeTo;

	public bool alsoRemoveCollider;
}
