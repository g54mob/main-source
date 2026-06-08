public interface ICraftableItem
{
	string DisplayName { get; }

	string guiScrap { get; }

	int ScrapCost { get; }

	DroneUpgradeType UpgradeType { get; }
}
