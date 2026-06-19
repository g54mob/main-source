using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class ChargeAttackStateAuthoring : MonoBehaviour
{
	public float distanceToProvokeCharge;

	public float moveSpeedMultiplier;

	[Header("End Charge With Attack")]
	public bool endChargeWithAttack;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public bool alwaysEndChargeWithAttack;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public float endChargeDistanceToAttemptAttack;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public float endChargeMoveForceForward;

	[Header("Durations")]
	public float anticipationDuration;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public float chargeAttackAnticipationDuration;

	public float chargeDuration;

	public float collideDuration;

	public float vulnerabilityDuration;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public float endChargeAttackDuration;

	public float endDuration;

	[Header("Cooldown")]
	public float minCooldown;

	public float maxCooldown;

	[Header("Misc")]
	public float pushback;

	public float reversePushback;

	public bool ignoreLowColliders;

	public bool dontCollideWithObjects;

	public bool triggerAnimationIfNotCollided;

	[Header("Steering")]
	public bool steerTowardsTargetDuringCharge;

	[ShowIf("steerTowardsTargetDuringCharge")]
	public ChargeAttackRotateToTargetData steerTowardsTargetChargeAttackRotateToTargetData;

	public float steerTowardsTargetMinDistance = 1.5f;

	[Range(0f, 180f)]
	public float steerTowardsTargetMaxAngleDeg = 180f;

	public float lockOrientationAtMultiplier = 1f;

	public ChargeAttackRotateToTargetData lockOrientationChargeAttackRotateToTargetData;

	[Header("Hitbox")]
	public float hitRadius;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public float hitBoxHalfWidth;

	[AllowNesting]
	[ShowIf("endChargeWithAttack")]
	public float hitBoxHalfLength;

	public float hitDistanceInfront;

	public bool hitInDiscreteDirections;

	public float3 hitOffset;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

	[Header("Tiles")]
	public bool hitTiles;

	public bool endOfChargeAttackHitTiles;

	public int tileDamage;

	public float tileDamageMultiplier = 1f;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (level == null || level.gameObject != base.gameObject)
		{
			level = GetComponent<AreaLevelAuthoring>();
		}
		if (level != null)
		{
			int num = level.CalculateLevel();
			damage = MeleeAttackStateAuthoring.LevelToDamage(num, damageMultiplier);
			if (hitTiles || endOfChargeAttackHitTiles)
			{
				bool isEnemy = GetComponent<EnemyAuthoring>() != null;
				tileDamage = DamageObjectStateAuthoring.LevelToTileDamage(num, tileDamageMultiplier, isEnemy);
			}
			else
			{
				tileDamage = 0;
			}
		}
	}
}
