using Unity.Entities;
using Unity.Mathematics;

public struct ChangeVariationWhenObjectNearbyCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectID;

	public bool objectNearbySpecificVariation;

	public int objectNearbyVariation;

	public float3 offset;

	public float radius;

	public int variationToChangeTo;

	public bool dontRevertToOriginalVariation;

	public bool triggerActivateAnimation;

	public bool ignorePlayerFaction;
}
