using Pug.Conversion;

public class VulnerableStateConverter : SingleAuthoringComponentConverter<VulnerableStateAuthoring>
{
	protected override void Convert(VulnerableStateAuthoring authoring)
	{
		AddComponentData(new VulnerableStateCD
		{
			destroyTilesWithinRadius = authoring.destroyTilesWithinRadius,
			pushBackNearbyEntitiesForce = authoring.pushBackNearbyEntitiesForce,
			pushBackNearbyEntitiesForceRadius = authoring.pushBackNearbyEntitiesForceRadius,
			preAnticipationDuration = authoring.preAnticipationDuration,
			anticipationDuration = authoring.anticipationDuration,
			vulnerableDuration = authoring.vulnerableDuration,
			endDuration = authoring.endDuration,
			maxHealthRatioLostToLeaveState = authoring.maxHealthRatioLostToLeaveState
		});
	}
}
