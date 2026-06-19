using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

public class RangeAttackStateAuthoring : MonoBehaviour
{
	public bool disabled;

	public ObjectID projectileID;

	public int projectileVariation;

	public float speedMultiplier = 1f;

	[Header("Animations")]
	public string animOverride;

	public string animPerShot;

	public string ceasingToShoot;

	[Header("State Timings")]
	public float anticipationDuration;

	public float attackDuration;

	public float endDuration;

	[Header("Fire Conditions")]
	public float minDistanceFromTargetToAllowAttack;

	public float maxDistanceFromTargetToAllowAttack;

	public float minCooldown;

	public float maxCooldown;

	public bool skipVisibilityCheck;

	public bool shootNewRandomTargetsPerProjectile;

	public bool onlyAttackTargetsWeWantToAttack;

	public bool interruptOnDamageTaken;

	public bool onlyAttackWhenInCombat;

	[Header("Spawn Pattern")]
	public float spawnAtDistanceInfront;

	public float spawnAtDistanceInfrontDeviation;

	public ProjectileSpawnDirectionType spawnDirectionType;

	public float3 spawnOffset;

	public float timeBetweenShots;

	public bool allowReAimingWhileShooting;

	public bool dontAllowReAimingDuringAntipation;

	public float startSpreadAngleOffset;

	public float spreadAngle;

	[ShowIf("spreadType", ProjectileSpreadType.SpiralPingPong)]
	public float maxSpreadAngle;

	public ProjectileSpreadType spreadType;

	public int projectilesPerShot = 1;

	public bool projectileFollowsTarget;

	public bool projectileTargetsSelf;

	public float sameFactionHealingPercentage;

	public float meleeDamageRadiusAtEntity;

	public bool modifyBaseSpeedByTargetDistance;

	public float2 minMaxBaseSpeedMultiplierByTargetDistance;

	public float2 minMaxDistanceForBaseSpeedMultiplier;

	[Header("Aim extrapolation")]
	[InfoBox("The distance at which the aim will start extrapolating.", EInfoBoxType.Normal)]
	public float minExtrapolatedAimDistance;

	[InfoBox("The distance at which the aim will be fully extrapolated.", EInfoBoxType.Normal)]
	public float maxExtrapolatedAimDistance;

	[Header("Only used if the object has a DirectionBasedOnVariationCD where it shoots in discrete directions.")]
	public float aimDegreesMax;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int rangeDamage;

	public float damageMultiplier = 1f;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (level != null)
			{
				int num = level.CalculateLevel();
				rangeDamage = MeleeAttackStateAuthoring.LevelToDamage(num, damageMultiplier);
			}
		}
	}
}
