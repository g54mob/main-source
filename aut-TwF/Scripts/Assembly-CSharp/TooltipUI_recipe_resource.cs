using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class TooltipUI_recipe_resource : UIListElement
{
	[SerializeField]
	private Image resourceImage;

	[SerializeField]
	private TextMeshProUGUI resourceAmountAndName;

	[SerializeField]
	private TextMeshProUGUI resourceAmountPerMin;

	private ResourceData resourceData;

	public override void LoadData()
	{
		Dictionary<string, object> dictionary = base.Data as Dictionary<string, object>;
		Setup((Cost)dictionary["cost"], (float)dictionary["processingTime"]);
	}

	public void Setup(Cost cost, float processingTime)
	{
		resourceData = cost.Resource;
		resourceImage.sprite = resourceData.InventoryImage;
		resourceAmountAndName.text = cost.Amount + " " + resourceData.DisplayName;
		resourceAmountPerMin.text = Mathf.Round(60f / processingTime * (float)cost.Amount * 100f) / 100f + "/" + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_minute_short").Entry.GetLocalizedString();
	}
}
