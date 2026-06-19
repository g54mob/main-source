using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(NearbyEntitiesTrackerAuthoring))]
public class ChangeVariationWhenPlayerHoldObjectNearbyAuthoring : MonoBehaviour
{
	public ObjectID objectID;

	public float3 offset;

	public float radius;

	public int variationToChangeTo;

	public bool alsoRemoveCollider;
}
