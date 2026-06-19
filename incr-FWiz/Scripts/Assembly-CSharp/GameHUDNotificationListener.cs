using UnityEngine;

public class GameHUDNotificationListener : MonoBehaviour
{
	[SerializeField]
	private GameHUDNotificationHandler _notificationHandler;

	[SerializeField]
	private UpgradeGameHUDNotification _upgradeNotification;

	[SerializeField]
	private BuildingUnlockedGameHUDNotification _buildingUnlockNotification;

	[SerializeField]
	private ItemDiscoveredGameHUDNotification _itemDiscoveredNotification;

	[SerializeField]
	private Transform _queueParent;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpgrade(UpgradeInstance upgradeInstance)
	{
	}

	public void OnBuildingUnlock(BuildingAsset buildingAsset)
	{
	}

	public void OnItemDiscovered(ItemType itemType)
	{
	}
}
