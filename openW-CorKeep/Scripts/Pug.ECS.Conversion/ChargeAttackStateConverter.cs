using Pug.Conversion;
using Unity.Mathematics;

public class ChargeAttackStateConverter : SingleAuthoringComponentConverter<ChargeAttackStateAuthoring>
{
	protected override void Convert(ChargeAttackStateAuthoring authoring)
	{
		EnemyAuthoring component;
		bool isEnemy = TryGetActiveComponent<EnemyAuthoring>(authoring, out component);
		int num = authoring.damage;
		int num2 = authoring.tileDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component2))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component2.level, authoring.damageMultiplier);
			num2 = DamageObjectStateAuthoring.LevelToTileDamage(component2.level, authoring.tileDamageMultiplier, isEnemy);
		}
		if (TryGetActiveComponent<EnemyAuthoring>(authoring, out component))
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
		EnsureHasComponent<DetectCollisionCD>();
		EnsureHasComponent<IsInCombatCD>();
		EnsureHasComponent<ChargeAttackStateCD>();
		SetProperty("ChargeAttack/moveSpeedMultiplier", authoring.moveSpeedMultiplier);
		SetProperty("ChargeAttack/anticipationDuration", authoring.anticipationDuration);
		SetProperty("ChargeAttack/chargeAttackAnticipationDuration", authoring.chargeAttackAnticipationDuration);
		SetProperty("ChargeAttack/chargeDuration", authoring.chargeDuration);
		SetProperty("ChargeAttack/collideDuration", authoring.collideDuration);
		SetProperty("ChargeAttack/vulnerabilityDuration", authoring.vulnerabilityDuration);
		SetProperty("ChargeAttack/endDuration", authoring.endDuration);
		SetProperty("ChargeAttack/damage", num);
		SetProperty("ChargeAttack/minCooldown", authoring.minCooldown);
		SetProperty("ChargeAttack/maxCooldown", authoring.maxCooldown);
		SetProperty("ChargeAttack/hitRadius", authoring.hitRadius);
		SetProperty("ChargeAttack/hitBoxHalfWidth", authoring.hitBoxHalfWidth);
		SetProperty("ChargeAttack/hitBoxHalfLength", authoring.hitBoxHalfLength);
		SetProperty("ChargeAttack/hitDistanceInfront", authoring.hitDistanceInfront);
		if (authoring.hitInDiscreteDirections)
		{
			SetProperty("ChargeAttack/hitInDiscreteDirections");
		}
		SetProperty("ChargeAttack/pushback", authoring.pushback);
		SetProperty("ChargeAttack/reversePushback", authoring.reversePushback);
		if (authoring.ignoreLowColliders)
		{
			SetProperty("ChargeAttack/ignoreLowColliders");
		}
		SetProperty("ChargeAttack/distanceToProvokeCharge", authoring.distanceToProvokeCharge);
		if (authoring.dontCollideWithObjects)
		{
			SetProperty("ChargeAttack/dontCollideWithObjects");
		}
		if (authoring.triggerAnimationIfNotCollided)
		{
			SetProperty("ChargeAttack/triggerAnimationIfNotCollided");
		}
		if (authoring.steerTowardsTargetDuringCharge)
		{
			SetProperty("ChargeAttack/steerTowardsTargetDuringCharge");
			SetProperty("ChargeAttack/steerTowardsTargetRotateToTargetData_rotateToTargetType", authoring.steerTowardsTargetChargeAttackRotateToTargetData.chargeAttackRotateToTargetType);
			SetProperty("ChargeAttack/steerTowardsTargetRotateToTargetData_radiansPerSecond", math.radians(authoring.steerTowardsTargetChargeAttackRotateToTargetData.degreesPerSecond));
			SetProperty("ChargeAttack/steerTowardsTargetMinDistance", authoring.steerTowardsTargetMinDistance);
			SetProperty("ChargeAttack/steerTowardsTargetMinDot", math.cos(math.radians(authoring.steerTowardsTargetMaxAngleDeg)));
		}
		SetProperty("ChargeAttack/lockOrientationAtMultiplier", authoring.lockOrientationAtMultiplier);
		SetProperty("ChargeAttack/lockOrientationRotateToTargetData_rotateToTargetType", authoring.lockOrientationChargeAttackRotateToTargetData.chargeAttackRotateToTargetType);
		SetProperty("ChargeAttack/lockOrientationRotateToTargetData_radiansPerSecond", math.radians(authoring.lockOrientationChargeAttackRotateToTargetData.degreesPerSecond));
		if (authoring.hitTiles)
		{
			SetProperty("ChargeAttack/hitTiles");
		}
		if (authoring.endOfChargeAttackHitTiles)
		{
			SetProperty("ChargeAttack/endOfChargeHitTiles");
		}
		SetProperty("ChargeAttack/tileDamage", (authoring.hitTiles || authoring.endOfChargeAttackHitTiles) ? num2 : 0);
		if (authoring.endChargeWithAttack)
		{
			SetProperty("ChargeAttack/endChargeWithAttack");
		}
		if (authoring.endChargeWithAttack && authoring.alwaysEndChargeWithAttack)
		{
			SetProperty("ChargeAttack/alwaysEndChargeWithAttack");
		}
		SetProperty("ChargeAttack/endChargeDistanceToAttemptAttack", authoring.endChargeDistanceToAttemptAttack);
		SetProperty("ChargeAttack/hitOffset", authoring.hitOffset);
		SetProperty("ChargeAttack/endChargeMoveForceForward", authoring.endChargeMoveForceForward);
		SetProperty("ChargeAttack/endChargeAttackDuration", authoring.endChargeAttackDuration);
	}
}
