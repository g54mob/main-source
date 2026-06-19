using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HydraBossBuriedCombatStateCD : IComponentData, IQueryTypeParameter
{
	public float buryDuration;

	public float unearthDuration;

	public float minCooldown;

	public float maxCooldown;

	public int buriedAppearDamage;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple timer;

	[GhostField]
	public int internalState;

	public float3 midLocation;

	public float3 startLocation;

	public float3 targetLocation;

	public int currentLocationIndex;

	public bool disabled;
}
