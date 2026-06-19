using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct ChargeAttackStateCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float3 targetDirection;

	public float3 hitDirection;

	public Entity targetEntity;

	public ChargeAttackInternalState internalState;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple internalTimer;

	public ThreadSafeTimerSimple attackTimer;

	public ThreadSafeTimerSimple vulnerableTimer;

	public bool endChargeAlreadyAttacked;

	public bool chargeConnected;
}
