using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(NearbyEntitiesTrackerAuthoring))]
public class HealNearbyEntitiesAuthoring : MonoBehaviour
{
	public bool isActive;

	public FactionID healsTargetsOfFaction;

	public int healthPerSecond;

	public float radius;
}
