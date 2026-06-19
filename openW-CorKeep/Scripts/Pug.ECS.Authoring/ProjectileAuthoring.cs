using System.Collections.Generic;
using NaughtyAttributes;
using PugTilemap;
using UnityEngine;

[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class ProjectileAuthoring : MonoBehaviour
{
	public float damageRadius;

	public float damageRadiusClient;

	public float tileDamageRadius;

	public bool piercesEnemies;

	public List<Tileset> piercesWallTypes;

	public bool damagesTiles;

	public bool dontDestroyOnCollision;

	public bool isDamageable;

	public bool shatterOnCollision;

	public float pingPongDuration;

	[ShowIf("shatterOnCollision")]
	public int shards;

	[ShowIf("shatterOnCollision")]
	public ObjectID shardObjectID;

	[Header("A projectile will get a random blend between the 2 speed curves.")]
	public bool useSpeedCurve;

	[ShowIf("useSpeedCurve")]
	public AnimationCurve speedCurve1;

	[ShowIf("useSpeedCurve")]
	public AnimationCurve speedCurve2;

	public bool mayExplodeWithWindup;

	public bool treatDodgeAsHit;

	public bool zigZag;

	public bool ExplodeOnEnemyCollision;

	public bool collideWithNonWalkableTiles;

	public int maxBounceCount;

	public float onlyAttackEveryXSecond;

	public static int LevelToProjectileDamage(int level, float multiplier)
	{
		return MeleeAttackStateAuthoring.LevelToDamage(level, multiplier * 3.9f, 10);
	}

	public static int LevelToMiningDamage(int level, float multiplier, bool isEnemyOrProjectile)
	{
		float num = (isEnemyOrProjectile ? 3.9f : 7f);
		return ConditionExtensions.GetConditionValueFromLevel(ConditionEffect.Mining, isNegative: false, level, multiplier * num, 1f, 1f, isTemporary: false, isHeldInHand: true, isArmor: false, isEnemyOrProjectile);
	}
}
