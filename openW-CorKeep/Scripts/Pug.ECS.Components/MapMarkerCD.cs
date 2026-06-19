using Unity.Entities;

public struct MapMarkerCD : IComponentData, IQueryTypeParameter
{
	public MapMarkerType mapMarkerType;

	public UserMapMarkerType userMapMarkerType;

	public ObjectID uniqueMarkerId;
}
