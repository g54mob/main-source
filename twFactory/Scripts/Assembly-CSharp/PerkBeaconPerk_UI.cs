using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class PerkBeaconPerk_UI : UIListElement
{
	[SerializeField]
	private TextMeshProUGUI description;

	[SerializeField]
	private Image resourceIcon;

	[SerializeField]
	private TextMeshProUGUI resourceAmountPerMinText;

	private ResourceActivatedGEData currentRAGEData;

	public event Action<ResourceActivatedGEData> onPerkSelected;

	public override void LoadData()
	{
		currentRAGEData = base.Data as ResourceActivatedGEData;
		description.text = currentRAGEData.Description;
		resourceIcon.sprite = currentRAGEData.Input[0].Resource.InventoryImage;
		if (currentRAGEData.Duration > 0f)
		{
			float number = 60f / currentRAGEData.Duration * (float)currentRAGEData.Input[0].Amount;
			resourceAmountPerMinText.text = FunctionLibrary.RoundToDecimals(number, 1) + "/" + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_minute_short").Entry.GetLocalizedString();
		}
		else
		{
			resourceAmountPerMinText.text = currentRAGEData.Input[0].Amount + " (∞)";
		}
	}

	public void OnButtonPressed()
	{
		this.onPerkSelected?.Invoke(currentRAGEData);
	}
}
