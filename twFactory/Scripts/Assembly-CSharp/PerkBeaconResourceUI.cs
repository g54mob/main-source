using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class PerkBeaconResourceUI : MonoBehaviour
{
	[SerializeField]
	private Image resourceImage;

	[SerializeField]
	private TextMeshProUGUI resourceAmountAndName;

	[SerializeField]
	private TextMeshProUGUI resourceAmountPerMin;

	[SerializeField]
	private TextMeshProUGUI resourceStorageAmount;

	private Storage_ResourceData storage;

	private ResourceActivatedGEData RAGEData;

	private void OnDestroy()
	{
		if ((bool)storage)
		{
			storage.onStoreObject -= OnObjectStored;
			storage.onRemoveObject -= OnStorageChanged;
		}
	}

	public void Setup(PerkBeacon perkBeacon)
	{
		if ((bool)storage)
		{
			storage.onStoreObject -= OnObjectStored;
			storage.onRemoveObject -= OnStorageChanged;
		}
		RAGEData = perkBeacon.SelectedRecipe;
		ResourceData resource = RAGEData.Input[0].Resource;
		resourceImage.sprite = resource.InventoryImage;
		resourceAmountAndName.text = RAGEData.Input[0].Amount + " " + resource.DisplayName;
		if (RAGEData.Duration > 0f)
		{
			float f = 60f / RAGEData.Duration * (float)RAGEData.Input[0].Amount;
			resourceAmountPerMin.text = Mathf.RoundToInt(f) + "/" + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_minute_short").Entry.GetLocalizedString();
		}
		else
		{
			resourceAmountPerMin.gameObject.SetActive(value: false);
		}
		storage = perkBeacon.InputStorage;
		storage.onStoreObject += OnObjectStored;
		storage.onRemoveObject += OnStorageChanged;
		OnStorageChanged(null, 0);
	}

	private void OnObjectStored(Storage<ResourceData>.StoredObjectData storedObject, int storedAmount, string storeSourceID)
	{
		OnStorageChanged(storedObject, storedAmount);
	}

	private void OnStorageChanged(Storage<ResourceData>.StoredObjectData storedObject, int storedAmount)
	{
		resourceStorageAmount.text = storage.GetStoredObjectAmount(RAGEData.Input[0].Resource.Id).ToString();
	}
}
