using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(NearbyEntitiesTrackerAuthoring))]
public class AddForceToNearbyEntitiesAuthoring : MonoBehaviour
{
	public float radius;

	public float force;

	public bool checkLineOfSight;

	[Header("Force applied during a set duration, useful to create a pulse")]
	public float forceDuringActivation;

	public AnimationCurve activeForceMultiplierCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	public float activationDelay;

	public float activeDuration;

	public float inactiveDuration;
}
