using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct AttackPlayerRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public SpawnedGhost attackerGhost;

	public NetworkTick startServerTick;

	public NetworkTick endServerTick;

	public float3 startPosition;

	public float3 attackOffset;

	public float3 direction;

	public float radius;

	public float boxHorizontalWidth;

	public float boxVerticalWidth;

	public quaternion rotation;

	public int damage;

	public DamageEffectType damageEffectType;

	public int reverseDamage;

	public float pushback;

	public float reversePushback;

	public int triggerAnimationOnHit;

	public float castDistance;

	public bool checkVisibility;

	public bool isRanged;

	public bool isBoss;

	public bool isMinion;

	public bool isPet;

	public bool isExplosive;

	public bool isExplosiveDamageFromBomb;
}
