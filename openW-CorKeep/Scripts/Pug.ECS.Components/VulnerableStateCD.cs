using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct VulnerableStateCD : IComponentData, IQueryTypeParameter
{
	public int internalState;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple internalTimer;

	public float destroyTilesWithinRadius;

	public float pushBackNearbyEntitiesForce;

	public float pushBackNearbyEntitiesForceRadius;

	public float preAnticipationDuration;

	public float anticipationDuration;

	public float vulnerableDuration;

	public float endDuration;

	public float maxHealthRatioLostToLeaveState;

	public float healthRatioOnEnterState;

	[GhostField]
	public bool isInVulnerableState;

	public bool isVulnerable;
}
