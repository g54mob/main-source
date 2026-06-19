using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class ChangeVariationWhenObjectNearbyAuthoring : MonoBehaviour
{
	[Tooltip("If set to None, logic relies entirely on the nearby entities filter")]
	public ObjectID objectID;

	public bool objectNearbySpecificVariation;

	[ShowIf("objectNearbySpecificVariation")]
	public int objectNearbyVariation;

	public float3 offset;

	public float radius;

	public int variationToChangeTo;

	public bool dontRevertToOriginalVariation;

	public bool triggerActivateAnimation = true;

	public bool ignorePlayerFaction;
}
