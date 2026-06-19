using Pug.Conversion;
using UnityEngine;

public class AttackContinuouslyConverter : SingleAuthoringComponentConverter<AttackContinuouslyAuthoring>
{
	protected override void Convert(AttackContinuouslyAuthoring authoring)
	{
		int damage = authoring.damage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			damage = AttackContinuouslyAuthoring.LevelToDamage(component.level, authoring.damageMultiplier);
		}
		if (authoring.ignoreDamageReduction)
		{
			SetProperty("AttackContinuously/ignoreDamageReduction");
		}
		SetProperty("AttackContinuously/canHitLowTriggers", authoring.canHitLowTriggers);
		SetProperty("AttackContinuously/pushback", authoring.pushback);
		SetProperty("AttackContinuously/hitRadius", authoring.hitRadius);
		SetProperty("AttackContinuously/attackTime", authoring.attackTime);
		SetProperty("AttackContinuously/cooldown", authoring.cooldownAfterHit);
		SetProperty("AttackContinuously/triggerAnimation", Animator.StringToHash(authoring.triggerAnimationOnHit));
		SetProperty("AttackContinuously/damageMultiplier", authoring.damageMultiplier);
		if (authoring.triggerIdleAnimationOnEnteringState)
		{
			SetProperty("AttackContinuously/triggerIdleAnimationOnEnteringState");
		}
		if (authoring.requiresElectricity)
		{
			SetProperty("AttackContinuously/requiresElectricity");
		}
		if (authoring.breakAfterSuccessfulHit)
		{
			SetProperty("AttackContinuously/breakAfterSuccessfulHit");
		}
		if (authoring.breakAfterSuccessfulHit)
		{
			SetProperty("AttackContinuously/breakDelay", authoring.breakDelay);
		}
		if (authoring.cantDamageObjectsHangingOnWalls)
		{
			SetProperty("AttackContinuously/cantDamageObjectsHangingOnWalls");
		}
		if (authoring.canDamageOnlyEnemyAndPlayer)
		{
			SetProperty("AttackContinuously/canDamageOnlyEnemyAndPlayer");
		}
		if (authoring.isStatic)
		{
			SetProperty("AttackContinuously/isStatic");
		}
		if (authoring.canOnlyHitCertainNonEnemyObjects)
		{
			SetProperty("AttackContinuously/canOnlyHitCertainNonEnemyObjects");
		}
		if (authoring.skipLootDropIfDestroyPlants)
		{
			SetProperty("AttackContinuously/skipLootDropIfDestroyPlants");
		}
		AddComponentData(new AttackContinuouslyCD
		{
			damage = damage,
			damageEffectType = authoring.damageEffectType,
			attackTime = authoring.attackTime,
			cooldown = authoring.cooldownAfterHit
		});
		AddComponentData(new NearbyEntitiesTrackerCD
		{
			radius = authoring.hitRadius + 1f,
			grow = authoring.hitRadiusGrowOverTime,
			radiusAfterGrowth = authoring.hitRadiusAfterGrowth,
			radiusGrowthRate = authoring.hitRadiusGrowthRate,
			detectsLayer = 10u
		});
		EnsureHasBuffer<NearbyEntitiesBufferCD>();
	}
}
