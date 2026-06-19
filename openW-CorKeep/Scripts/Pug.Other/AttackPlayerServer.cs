using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public class AttackPlayerServer
{
	public static void Attack(EntityCommandBuffer ecb, SpawnedGhost spawnedGhost, NetworkTick startServerTick, NetworkTick endServerTick, float3 position, Entity attacker, float3 attackOffset, bool isRanged, bool isBoss, bool isMinion, bool isPet, bool isStatic, float radius, float boxHorizontalWidth, float boxVerticalWidth, quaternion rotation, int damage, DamageEffectType damageEffectType, float3 direction, float distance, int reverseDamage = 0, float pushback = 0f, float reversePushback = 0f, int triggerAnimationOnHit = 0, bool checkVisibility = false, bool isExplosive = false, bool isExplosiveDamageFromBomb = false)
	{
		AttackPlayerRPC component = CreateRpc(spawnedGhost, startServerTick, endServerTick, attacker, position, attackOffset, isRanged, isBoss, isMinion, isPet, radius, boxHorizontalWidth, boxVerticalWidth, rotation, damage, damageEffectType, reverseDamage, pushback, reversePushback, triggerAnimationOnHit, distance, direction, checkVisibility, isExplosive, isExplosiveDamageFromBomb);
		Entity e = ecb.CreateEntity();
		ecb.AddComponent(e, component);
		ecb.AddComponent(e, new SendRpcToNearbyPlayers
		{
			position = position,
			distance = ((!isStatic) ? 24f : ((distance > 1f) ? (distance + 5f) : 5f)),
			alsoCreateForServer = true
		});
		ecb.AddComponent(e, new AttackPlayerRPCTempEntityRef
		{
			Entity = attacker
		});
	}

	private static AttackPlayerRPC CreateRpc(SpawnedGhost spawnedGhost, NetworkTick startServerTick, NetworkTick endServerTick, Entity attacker, float3 position, float3 attackOffset, bool isRanged, bool isBoss, bool isMinion, bool isPet, float radius, float boxHorizontalWidth, float boxVerticalWidth, quaternion rotation, int damage, DamageEffectType damageEffectType, int reverseDamage, float pushback, float reversePushback, int triggerAnimationOnHit, float castDistance, float3 direction, bool checkVisibility = false, bool isExplosive = false, bool isExplosiveDamageFromBomb = false)
	{
		return new AttackPlayerRPC
		{
			attackerGhost = spawnedGhost,
			startServerTick = startServerTick,
			endServerTick = endServerTick,
			attackOffset = attackOffset,
			startPosition = position,
			isRanged = isRanged,
			isBoss = isBoss,
			isPet = isPet,
			isMinion = isMinion,
			radius = radius,
			boxHorizontalWidth = boxHorizontalWidth,
			boxVerticalWidth = boxVerticalWidth,
			rotation = rotation,
			damage = damage,
			damageEffectType = damageEffectType,
			reverseDamage = reverseDamage,
			pushback = pushback,
			reversePushback = reversePushback,
			triggerAnimationOnHit = triggerAnimationOnHit,
			castDistance = castDistance,
			direction = direction,
			checkVisibility = checkVisibility,
			isExplosive = isExplosive,
			isExplosiveDamageFromBomb = isExplosiveDamageFromBomb
		};
	}
}
