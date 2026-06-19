using Pug.Conversion;

public class SleepStateConverter : SingleAuthoringComponentConverter<SleepStateAuthoring>
{
	protected override void Convert(SleepStateAuthoring authoring)
	{
		AddComponentData(new SleepStateCD
		{
			minSleepCooldown = authoring.minSleepCooldown,
			maxSleepCooldown = authoring.maxSleepCooldown,
			minPreFallAsleepDuration = authoring.minPreFallAsleepDuration,
			maxPreFallAsleepDuration = authoring.maxPreFallAsleepDuration,
			minSleepDuration = authoring.minSleepDuration,
			maxSleepDuration = authoring.maxSleepDuration,
			wakeUpDuration = authoring.wakeUpDuration,
			radiusSqFromVisiblePlayerToAwake = authoring.radiusFromVisiblePlayerToAwake * authoring.radiusFromVisiblePlayerToAwake,
			minSqRadiusFromOwnerToWakeUp = authoring.minRadiusFromOwnerToWakeUp * authoring.minRadiusFromOwnerToWakeUp,
			stayAwakeUntilNoVisiblePlayer = authoring.stayAwakeUntilNoVisiblePlayer,
			sleepCooldown = float.NaN
		});
	}
}
