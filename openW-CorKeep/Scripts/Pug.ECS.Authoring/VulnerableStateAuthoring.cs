using UnityEngine;

public class VulnerableStateAuthoring : MonoBehaviour
{
	public float preAnticipationDuration;

	public float anticipationDuration;

	public float vulnerableDuration;

	[Min(0.5f)]
	public float endDuration;

	public float destroyTilesWithinRadius;

	public float pushBackNearbyEntitiesForce;

	public float pushBackNearbyEntitiesForceRadius;

	public float maxHealthRatioLostToLeaveState = 0.25f;
}
