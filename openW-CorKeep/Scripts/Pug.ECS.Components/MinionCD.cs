using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct MinionCD : IComponentData, IQueryTypeParameter
{
	public bool isFlying;

	public float damageMultiplier;

	public bool hasStartedLifeSpanTimer;

	[GhostField]
	public float lifespanTimer;

	[GhostField]
	public float lifespan;

	public bool skipTriggeringDeathEffects;

	public bool hasTriggeredDeathEffects;

	public bool willDetonate;

	public bool detonatedByOffhand;

	public float normalizedLifespanTimer
	{
		get
		{
			if (!(lifespan > 0f))
			{
				return 1f;
			}
			return lifespanTimer / lifespan;
		}
	}
}
