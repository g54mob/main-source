using Pug.Conversion;

public class BushStateConverter : SingleAuthoringComponentConverter<BushStateAuthoring>
{
	protected override void Convert(BushStateAuthoring authoring)
	{
		SetProperty("BushState/randomlyLeaveStateMinDuration", authoring.randomlyLeaveStateMinDuration);
		SetProperty("BushState/randomlyLeaveStateMaxDuration", authoring.randomlyLeaveStateMaxDuration);
		SetProperty("BushState/goToBushDuration", authoring.goToBushDuration);
		SetProperty("BushState/peakDuration", authoring.peakDuration);
		SetProperty("BushState/leaveDuration", authoring.leaveDuration);
		SetProperty("BushState/burrowWhenOutOfCombatDelay", authoring.burrowWhenOutOfCombatDelay);
		float distanceToTargetToLeaveStateSq = authoring.distanceToTargetToLeaveState * authoring.distanceToTargetToLeaveState;
		AddComponentData(new BushStateCD
		{
			distanceToTargetToLeaveStateSq = distanceToTargetToLeaveStateSq
		});
	}
}
