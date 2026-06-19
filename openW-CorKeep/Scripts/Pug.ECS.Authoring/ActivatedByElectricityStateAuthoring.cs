using Unity.Physics.Authoring;
using UnityEngine;

public class ActivatedByElectricityStateAuthoring : MonoBehaviour
{
	public float activationTime;

	public float deactivationTime;

	public bool changeColliderToTriggerWhenActivated;

	public PhysicsCategoryTags triggerBelongsTo;

	public PhysicsCategoryTags triggerCollidesWith;

	public bool changeVariationOnActivate;

	public int variationToChangeTo;
}
