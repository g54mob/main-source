using Pug.Conversion;
using Unity.Mathematics;

public class SnakeMovementStateConverter : SingleAuthoringComponentConverter<SnakeMovementStateAuthoring>
{
	protected override void Convert(SnakeMovementStateAuthoring authoring)
	{
		int num = authoring.damage;
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
		AddComponentData(new SnakeSegmentCD
		{
			index = -1,
			groupIndex = -1
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		AddComponentData(new SnakeMovementStateCD
		{
			damage = num,
			attackOffset = authoring.attackOffset,
			spread = authoring.spread,
			additionalHorizontalSpread = authoring.additionalHorizontalSpread,
			turnDuration = authoring.turnDuration,
			distanceToTargetToChangeTarget = authoring.distanceToTargetToChangeTarget,
			tilePlacementType = authoring.tilePlacementType,
			wavinessTurnTime = authoring.wavinessTurnTime,
			wavinessAmplitude = authoring.wavinessAmplitude,
			initialLength = authoring.initialLength,
			movementSpeedMultiplier = 1f,
			externallyRequestedPhase = SnakeMovementPhaseType.NONE,
			distanceSqToAttackPlayer = authoring.distanceToAttackPlayer * authoring.distanceToAttackPlayer,
			distanceSqAllowedToMoveAwayFromCombatStartPosition = authoring.distanceAllowedToMoveAwayFromCombatStartPosition * authoring.distanceAllowedToMoveAwayFromCombatStartPosition,
			tooCloseDistanceForAttack = authoring.tooCloseDistanceForAttack * authoring.tooCloseDistanceForAttack,
			attackRadius = authoring.attackRadius,
			dontDropLootFromObjectsBeingDestroyed = authoring.dontDropLootFromObjectsBeingDestroyed,
			cantHitSpecificObject = authoring.cantHitSpecificObject,
			targetingType = authoring.targetingType,
			disableDamage = authoring.disableDamage,
			tailObjectId = authoring.tailObjectId,
			tilePlacementRadiusMultiplier = authoring.tilePlacementRadiusMultiplier,
			pushbackForce = authoring.pushbackForce,
			usePhysVelocity = authoring.usePhysVelocity,
			playerTargetCooldownMin = authoring.playerTargetCooldownMin,
			playerTargetCooldownMax = authoring.playerTargetCooldownMax,
			currentRotation = quaternion.identity,
			slowDownForWalls = authoring.slowDownForWalls,
			useCaterpillarMovement = authoring.useCaterpillarMovement,
			stretchOutStrength = authoring.stretchOutStrength,
			stretchBackStrength = authoring.stretchBackStrength,
			stretchFrequency = authoring.stretchFrequency,
			stretchSpread = authoring.stretchSpread,
			chaoticMovement = authoring.chaoticMovement
		});
		if (authoring.playMoveAnimation)
		{
			EnsureHasComponent<SnakeMovementAnimationCD>();
		}
		EnsureHasComponent<SnakeMovementAttackCooldownCD>();
		if (!authoring.treatSegmentsAsIndividualParts)
		{
			EnsureHasComponent<EntityPartCD>();
		}
		EnsureHasBuffer<SnakeSegmentsBuffer>();
		EnsureHasBuffer<TargetPointsBuffer>();
		if (TryGetActiveComponent<BossLarvaAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<SkipSnakeSegmentInitializationCD>();
		}
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
