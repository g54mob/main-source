using Pug.Conversion;
using Unity.Mathematics;
using UnityEngine;

public class RangeAttackStateConverter : SingleAuthoringComponentConverter<RangeAttackStateAuthoring>
{
	protected override void Convert(RangeAttackStateAuthoring authoring)
	{
		int num = authoring.rangeDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.damageMultiplier);
		}
		if (TryGetActiveComponent<EnemyAuthoring>(authoring, out var _))
		{
			if (base.UseHardModeSettings)
			{
				num = (int)math.round((float)num * 2f);
			}
			else if (base.UseCasualModeSettings)
			{
				num = (int)math.round((float)num * 0.5f);
			}
		}
		EnsureHasComponent<StateInfoCD>();
		AddComponentData(new RangeAttackStateCD
		{
			isDisabled = authoring.disabled,
			projectileID = authoring.projectileID,
			projectileVariation = authoring.projectileVariation,
			speedMultiplier = authoring.speedMultiplier,
			anticipationDuration = authoring.anticipationDuration,
			attackDuration = authoring.attackDuration,
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown,
			spawnAtDistanceInfront = authoring.spawnAtDistanceInfront,
			spawnAtDistanceInfrontDeviation = authoring.spawnAtDistanceInfrontDeviation,
			spawnOffset = authoring.spawnOffset,
			spawnDirectionType = authoring.spawnDirectionType,
			minDistanceFromTargetToAllowAttack = authoring.minDistanceFromTargetToAllowAttack,
			rangeDamage = num,
			sameFactionHealingPercentage = authoring.sameFactionHealingPercentage,
			onlyAttackTargetsWeWantToAttack = authoring.onlyAttackTargetsWeWantToAttack,
			maxDistanceFromTargetToAllowAttack = authoring.maxDistanceFromTargetToAllowAttack,
			meleeDamageRadiusAtEntity = authoring.meleeDamageRadiusAtEntity,
			timeBetweenShots = authoring.timeBetweenShots,
			allowReAimingWhileShooting = authoring.allowReAimingWhileShooting,
			dontAllowReAimingDuringAntipation = authoring.dontAllowReAimingDuringAntipation,
			spreadAngle = authoring.spreadAngle,
			startSpreadAngleOffset = authoring.startSpreadAngleOffset,
			maxSpreadAngle = authoring.maxSpreadAngle,
			endDuration = authoring.endDuration,
			projectilesPerShot = authoring.projectilesPerShot,
			spreadType = authoring.spreadType,
			onlyAttackWhenInCombat = authoring.onlyAttackWhenInCombat,
			projectileFollowsTarget = authoring.projectileFollowsTarget,
			projectileTargetsSelf = authoring.projectileTargetsSelf,
			skipVisibilityCheck = authoring.skipVisibilityCheck,
			shootNewRandomTargetsPerProjectile = authoring.shootNewRandomTargetsPerProjectile,
			interruptOnDamageTaken = authoring.interruptOnDamageTaken,
			aimDegreesMax = authoring.aimDegreesMax,
			minExtrapolatedAimDistanceSq = authoring.minExtrapolatedAimDistance * authoring.minExtrapolatedAimDistance,
			maxExtrapolatedAimDistanceSq = authoring.maxExtrapolatedAimDistance * authoring.maxExtrapolatedAimDistance,
			modifyBaseSpeedByTargetDistance = authoring.modifyBaseSpeedByTargetDistance,
			minMaxBaseSpeedMultiplierByTargetDistance = authoring.minMaxBaseSpeedMultiplierByTargetDistance,
			minMaxDistanceForBaseSpeedMultiplier = authoring.minMaxDistanceForBaseSpeedMultiplier,
			animOverride = ((!string.IsNullOrEmpty(authoring.animOverride)) ? Animator.StringToHash(authoring.animOverride) : 0),
			animPerShotID = ((!string.IsNullOrEmpty(authoring.animPerShot)) ? Animator.StringToHash(authoring.animPerShot) : 0),
			ceasingToShootID = ((!string.IsNullOrEmpty(authoring.ceasingToShoot)) ? Animator.StringToHash(authoring.ceasingToShoot) : 0)
		});
		EnsureHasComponent<AttackCooldownTimerCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
