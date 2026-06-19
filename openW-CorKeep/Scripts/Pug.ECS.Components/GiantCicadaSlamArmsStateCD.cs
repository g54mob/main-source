using Pug.UnityExtensions;
using Unity.Entities;

public struct GiantCicadaSlamArmsStateCD : IComponentData, IQueryTypeParameter
{
	public float minCooldown;

	public int armSlamDamage;

	public int armSlamCounter;

	public int amountOfValidPlayers;

	public int playerFarAwayCounter;

	public float armSlamAnticipation;

	public float armSlamAnimationDuration;

	public ArmSlamInternalState internalState;

	public GiantCicadaMeleeAttacks armSlamType;

	public ThreadSafeTimerSimple stateCooldownTimer;

	public ThreadSafeTimerSimple animationStageTimer;

	public ThreadSafeTimerSimple spawnNymphsTimer;
}
