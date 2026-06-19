using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ScarabBossChargeStateCD : IComponentData, IQueryTypeParameter
{
	public float buryDuration;

	public float unearthDuration;

	public float minCooldown;

	public float maxCooldown;

	public int damage;

	public float3 positionToStayWithin;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple timer;

	[GhostField]
	public int internalState;

	public float3 targetLocation;

	public int chargeCounter;

	public bool disabled;
}
