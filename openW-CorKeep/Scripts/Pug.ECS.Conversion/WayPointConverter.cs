using Pug.Conversion;

public class WayPointConverter : SingleAuthoringComponentConverter<WayPointAuthoring>
{
	protected override void Convert(WayPointAuthoring authoring)
	{
		EnsureHasComponent<DistanceToPlayerCD>();
		AddComponentData(new WayPointCD
		{
			distanceToActivateSQ = authoring.distanceToActivate * authoring.distanceToActivate,
			isCoreWaypoint = authoring.isCoreWaypoint
		});
		EnsureHasComponent<DontOverrideInDungeonGenerationCD>();
	}
}
