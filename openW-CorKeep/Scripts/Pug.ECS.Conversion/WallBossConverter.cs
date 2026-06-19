using Pug.Conversion;
using Unity.Mathematics;

public class WallBossConverter : SingleAuthoringComponentConverter<WallBossAuthoring>
{
	protected override void Convert(WallBossAuthoring authoring)
	{
		EnsureHasBuffer<WallBossBufferElement>();
		EnsureHasBuffer<WallBossBulbBufferElement>();
		EnsureHasBuffer<WallBossMovementBufferElement>();
		float num = 0f;
		foreach (MovementParameters item in authoring.movement)
		{
			AddToBuffer(new WallBossMovementBufferElement
			{
				onTotalAliveTargets = item.onTotalAliveTargets,
				decelerationSpeed = item.decelerationSpeed,
				decelerationDurationOnEnter = item.decelerationDurationOnEnter,
				accelerationSpeed = item.accelerationSpeed,
				maxSpeed = item.maxSpeed
			});
			num = math.max(item.maxSpeed, num);
		}
		AddComponentData(new WallBossCD
		{
			distanceFromCore = authoring.distanceFromCore,
			segmentRadius = authoring.segmentRadius,
			totalSegments = authoring.totalSegments,
			totalWidth = authoring.totalWidth,
			attackDuration = authoring.attackDuration,
			attackCooldown = authoring.attackCooldown,
			slitheringFrequencyMultiplier = authoring.slitheringFrequencyMultiplier,
			slitheringWavelengthMultiplier = authoring.slitheringWavelengthMultiplier,
			slitheringWaveHeightMultiplier = authoring.slitheringWaveHeightMultiplier,
			pauseBeforeBulbsEmergeDuration = authoring.pauseBeforeBulbsEmergeDuration,
			pauseBeforeHeadEmergesDuration = authoring.pauseBeforeHeadEmergesDuration,
			vulnerableDuration = authoring.vulnerableDuration,
			vulnerableOnDamageMaxDuration = authoring.vulnerableOnDamageMaxDuration,
			headOffset = authoring.headOffset,
			bulbOffset = authoring.bulbOffset,
			attackTimer = 3f,
			baseSpeed = num,
			maxSpeed = 4f + num
		});
		EnsureHasComponent<EntityPartCD>();
		AddComponentData(new ImmuneToDamageCD
		{
			Value = ImmuneToDamageState.Immune,
			effectIDOverride = EffectID.FailedHit
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<WallBossHeadRefCD>();
	}
}
