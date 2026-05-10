using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ProcessorResourceUI : MonoBehaviour
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

	public void Setup(Processor processor, bool isOutputResource, int costIdx)
	{
		if ((bool)storage)
		{
			storage.onStoreObject -= OnObjectStored;
			storage.onRemoveObject -= OnStorageChanged;
		}
		if (isOutputResource)
		{
			resourceData = processor.SelectedRecipe.Output.Resource;
			resourceImage.sprite = resourceData.InventoryImage;
			resourceAmountAndName.text = processor.SelectedRecipe.Output.Amount + " " + resourceData.DisplayName;
			resourceAmountPerMin.text = Mathf.Round(60f / processor.SelectedRecipe.ProcessingTime * processor.ProcessingSpeed * (float)processor.SelectedRecipe.Output.Amount * 100f) / 100f + "/" + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_minute_short").Entry.GetLocalizedString();
			storage = processor.OutputStorage;
		}
		else
		{
			resourceData = processor.SelectedRecipe.Input[costIdx].Resource;
			resourceImage.sprite = resourceData.InventoryImage;
			resourceAmountAndName.text = processor.SelectedRecipe.Input[costIdx].Amount + " " + resourceData.DisplayName;
			resourceAmountPerMin.text = FunctionLibrary.RoundToDecimals(60f / processor.SelectedRecipe.ProcessingTime * processor.ProcessingSpeed * (float)processor.SelectedRecipe.Input[costIdx].Amount, 1) + "/" + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_minute_short").Entry.GetLocalizedString();
			storage = processor.InputStorage;
		}
		if ((bool)storage)
		{
			storage.onStoreObject += OnObjectStored;
			storage.onRemoveObject += OnStorageChanged;
			OnStorageChanged(null, 0);
		}
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
