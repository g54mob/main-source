using Pug.Conversion;

public class CanBeDiscoveredConverter : SingleAuthoringComponentConverter<CanBeDiscoveredAuthoring>
{
	protected override void Convert(CanBeDiscoveredAuthoring authoring)
	{
		AddComponentData(new CanBeDiscoveredCD
		{
			DistanceToDiscoverSq = authoring.distanceToDiscover * authoring.distanceToDiscover
		});
		EnsureHasComponent<DistanceToPlayerCD>();
	}
}
