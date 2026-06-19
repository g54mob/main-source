using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HealOtherEntityStateCD : IComponentData, IQueryTypeParameter
{
	public int internalState;

	[GhostField]
	public Entity targetEntity;

	public float maxReachDistance;

	public float anticipationDuration;

	public float healDuration;

	public int healPerSecond;

	public ThreadSafeTimerSimple internalTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public float minCooldown;

	public float maxCooldown;

	public bool skipVisibilityCheck;

	public int keepHealingUntilTakingDamageXTimes;

	public int damageTakenCountOnStartingToShoot;

	public bool healPercentageOfHp;

	public bool isDisabled;
}
