using Pug.Conversion;

public class MapMarkerConverter : SingleAuthoringComponentConverter<MapMarkerAuthoring>
{
	protected override void Convert(MapMarkerAuthoring authoring)
	{
		AddComponentData(new MapMarkerCD
		{
			mapMarkerType = authoring.mapMarkerType,
			userMapMarkerType = authoring.userMapMarkerType,
			uniqueMarkerId = authoring.uniqueMarkerId
		});
		if (authoring.mapMarkerType == MapMarkerType.Portal || authoring.mapMarkerType == MapMarkerType.Waypoint)
		{
			EnsureHasComponent<MapMarkerActivatedCD>();
		}
		if (authoring.hideWhenDiscovered)
		{
			EnsureHasComponent<HideFromClientsIfDiscoveredCD>();
		}
	}
}
