using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ExtractorResourceUI : MonoBehaviour
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

	private ResourceData resourceData;

	private void OnDestroy()
	{
		if ((bool)storage)
		{
			storage.onStoreObject -= OnObjectStored;
			storage.onRemoveObject -= OnStorageChanged;
		}
	}

	public void Setup(Extractor extractor)
	{
		if ((bool)storage)
		{
			storage.onStoreObject -= OnObjectStored;
			storage.onRemoveObject -= OnStorageChanged;
		}
		resourceData = (extractor.ValidSources[0].Obj as Source).Resource;
		resourceImage.sprite = resourceData.InventoryImage;
		resourceAmountAndName.text = "1 " + resourceData.DisplayName;
		resourceAmountPerMin.text = Mathf.Round(60f / extractor.ExtractionTime * 100f) / 100f + "/" + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_minute_short").Entry.GetLocalizedString();
		storage = extractor.Storage;
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
		resourceStorageAmount.text = storage.GetStoredObjectAmount(resourceData.Id).ToString();
	}
}
