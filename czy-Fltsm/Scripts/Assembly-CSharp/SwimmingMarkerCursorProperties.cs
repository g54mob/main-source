using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Swimming Marker")]
public class SwimmingMarkerCursorProperties : MarkerCursorProperties
{
	protected override float Range => GameManager.Settings.GameplaySettings.SwimmingRadius;

	protected override void ShowPlacementRange()
	{
		_worldManager.ShowSwimmingRange();
	}

	protected override void HidePlacementRange()
	{
		_worldManager.HideSwimmingRange();
	}

	protected override bool ReturnIsInWorldManagerRadius(Vector3 position)
	{
		return _worldManager.IsInSwimmingRadius(position);
	}
}
