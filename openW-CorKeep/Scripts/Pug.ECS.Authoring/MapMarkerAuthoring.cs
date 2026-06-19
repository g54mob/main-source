using UnityEngine;

[DisallowMultipleComponent]
public class MapMarkerAuthoring : MonoBehaviour
{
	public MapMarkerType mapMarkerType;

	public UserMapMarkerType userMapMarkerType;

	public ObjectID uniqueMarkerId;

	public bool hideWhenDiscovered;
}
