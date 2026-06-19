using Pug.Conversion;

public class RobotBossConverter : SingleAuthoringComponentConverter<RobotBossAuthoring>
{
	protected override void Convert(RobotBossAuthoring authoring)
	{
		AddComponentData(new RobotBossCD
		{
			stepHeightProgressMultiplier = authoring.stepHeightProgressMultiplier,
			distanceToTriggerLegMovement = authoring.distanceToTriggerLegMovement,
			legMovementSpeed = authoring.legMovementSpeed,
			maxStepHeight = authoring.maxStepHeight,
			startDistance = authoring.startDistance,
			stepForwardDistance = authoring.stepForwardDistance,
			legStepCooldownDuration = authoring.legStepCooldownDuration,
			legXOffset = authoring.legXOffset,
			legZOffset = authoring.legZOffset,
			legBrokenTime = authoring.legBrokenTime,
			chainedDelayBetweenAttacks = authoring.chainedDelayBetweenAttacks,
			numberOfAttacksInChain = authoring.numberOfAttacksInChain
		});
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<IsInCombatCD>();
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasBuffer<RobotBossLegsBuffer>();
	}
}
