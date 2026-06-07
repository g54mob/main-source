using DV.Teleporters;

public class DynamicFastTravelDestination : FastTravelDestination
{
	private string markerName;

	public override string MarkerName => markerName;

	public override bool IsDynamic => true;

	private void Awake()
	{
		if (!mapMarkerAnchor)
		{
			mapMarkerAnchor = base.transform;
		}
		if (!playerTeleportAnchor)
		{
			playerTeleportAnchor = base.transform;
		}
	}

	public void SetMarkerName(string name)
	{
		markerName = name;
	}
}
