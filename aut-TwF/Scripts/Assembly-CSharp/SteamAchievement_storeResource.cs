using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_storeResource_default", menuName = "Tower Factory/Steam Achievements/Store Resource")]
public class SteamAchievement_storeResource : SteamAchievement
{
	[Header("Store Resource")]
	[SerializeField]
	[Tooltip("None = any")]
	private ResourceData resourceToStore;

	[SerializeField]
	private int amount;

	public override void StartAchievement()
	{
		base.StartAchievement();
	}

	protected override void OnStartGame()
	{
		base.OnStartGame();
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		if ((bool)lTGameManager)
		{
			lTGameManager.PlayerData.Inventory.onStoreObject += OnStoreResource;
		}
	}

	private void OnStoreResource(Storage<ResourceData>.StoredObjectData storedObject, int storedAmount, string storeSourceID)
	{
		if ((!resourceToStore || storedObject.id == resourceToStore.Id) && LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount(storedObject.id) >= amount)
		{
			UnlockAchievement();
			LTFunctionLibrary.GetLTGameManager().PlayerData.Inventory.onStoreObject -= OnStoreResource;
		}
	}
}
