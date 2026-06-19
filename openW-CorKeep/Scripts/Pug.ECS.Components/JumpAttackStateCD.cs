using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct JumpAttackStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple internalTimer;

	public Entity target;

	public float3 jumpDirection;

	public int internalState;

	public int jumpDamage;

	public bool stopJumpAttack;
}
