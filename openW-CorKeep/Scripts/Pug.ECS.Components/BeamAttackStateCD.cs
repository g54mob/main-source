using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct BeamAttackStateCD : IComponentData, IQueryTypeParameter
{
	public int damage;

	public float anticipationDuration;

	public float attackDuration;

	public float endDuration;

	public float spawnAtDistanceInfront;

	public float timeBetweenDamageTicks;

	public float minCooldown;

	public float maxCooldown;

	public float beamReachDistance;

	public float beamWidth;

	public int amountOfBeams;

	public float angleBetweenBeams;

	public float3 positionToShootFrom;

	public Entity targetEntity;

	public ThreadSafeTimerSimple internalTimer;

	public int internalState;

	public ThreadSafeTimerSimple damageTimer;

	public float3 targetDirection;
}
