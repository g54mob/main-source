using Pug.Conversion;
using Unity.Mathematics;
using UnityEngine;

public class ShootMortarProjectileStateConverter : SingleAuthoringComponentConverter<ShootMortarProjectileStateAuthoring>
{
	protected override void Convert(ShootMortarProjectileStateAuthoring authoring)
	{
		int num = authoring.mortarDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = ShootMortarProjectileStateAuthoring.LevelToDamage(component.level, authoring.damageMultiplier);
			authoring.mortarTileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(component.level, authoring.tileDamageMultiplier, isEnemy: true);
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
		AddComponentData(new ShootMortarProjectileStateCD
		{
			mortarProjectileID = authoring.mortarProjectileID,
			onlyShootWhenInCombat = authoring.onlyShootWhenInCombat,
			shootAtSelf = authoring.shootAtSelf,
			skipVisibilityCheck = authoring.skipVisibilityCheck,
			anticipationDuration = authoring.anticipationDuration,
			attackDuration = authoring.attackDuration,
			minMaxDistanceToTargetToShootSqr = new float2(authoring.minDistanceToShoot * authoring.minDistanceToShoot, authoring.maxDistanceToTargetToShoot * authoring.maxDistanceToTargetToShoot),
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown,
			goUpTime = authoring.goUpTime,
			airTime = authoring.airTime,
			goDownTime = authoring.goDownTime,
			explodeTime = authoring.explodeTime,
			mortarDamage = num,
			hitTiles = authoring.hitTiles,
			mortarTileDamage = authoring.mortarTileDamage,
			minAmountOfProjectiles = authoring.minAmountOfProjectiles,
			maxAmountOfProjectiles = authoring.maxAmountOfProjectiles,
			maxProjectilesShotPerWave = authoring.maxProjectilesShotPerWave,
			maxProjectilesShotPerWaveMultiplier = authoring.maxProjectilesShotPerWaveMultiplier,
			timeBetweenProjectiles = authoring.timeBetweenProjectiles,
			minRandomSpreadDistance = authoring.minRandomSpreadDistance,
			maxRandomSpreadDistance = authoring.maxRandomSpreadDistance,
			keepShootingUntilTakingDamageXTimes = authoring.keepShootingUntilTakingDamageXTimes,
			maxHealthRatioToShoot = authoring.maxHealthRatioToShoot,
			dontAllowOverlappingShots = authoring.dontAllowOverlappingShots,
			lineFromShooterToTarget = authoring.lineFromShooterToTarget,
			lineLengthMultiplier = authoring.lineLengthMultiplier,
			lineBendTowardTarget = authoring.lineBendTowardTarget,
			dontInterruptOtherAttackStates = authoring.dontInterruptOtherAttackStates,
			overrideAnimID = Animator.StringToHash(authoring.overrideAnimID),
			playAttackFireAnimation = authoring.playAttackFireAnimation
		});
		EnsureHasBuffer<MortarShotsBuffer>();
		EnsureHasComponent<AmountOfTimesTakingDamageCounterCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
