using Unity.Physics.Authoring;
using UnityEngine;

[DisallowMultipleComponent]
public class NearbyEntitiesTrackerAuthoring : MonoBehaviour
{
	public PhysicsCategoryTags detectsLayer;

	public float radius;

	public bool ignoreCooldown;
}
