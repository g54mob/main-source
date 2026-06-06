using UnityEngine;

public class SwimmingMarker : Marker
{
	protected override float _range => GameManager.Settings.GameplaySettings.SwimmingRadius;

	protected override void ShowPlacementRange()
	{
		GameManager.WorldManager.ShowSwimmingRange();
	}

	protected override void HidePlacementRange()
	{
		GameManager.WorldManager.HideSwimmingRange();
	}

	protected override bool ReturnIsInWorldManagerRadius(Vector3 position)
	{
		return GameManager.WorldManager.IsInSwimmingRadius(position);
	}

	protected override bool ReturnItemHasStorageSpace(Item item)
	{
		return Community.PlayerCommunity.Inventory.FitsItem(item);
	}
}
