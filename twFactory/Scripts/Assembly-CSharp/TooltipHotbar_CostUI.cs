using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHotbar_CostUI : UIListElement
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private TextMeshProUGUI amountText;

	[SerializeField]
	private Color cantAffordTextColor = Color.white;

	private Color defaultTextColor;

	private void Awake()
	{
		defaultTextColor = amountText?.color ?? Color.white;
	}

	private void Update()
	{
		UpdateCostText();
	}

	public override void LoadData()
	{
		Cost cost = base.Data as Cost;
		image.sprite = cost.Resource.InventoryImage;
		UpdateCostText();
	}

	private void UpdateCostText()
	{
		int amount = (base.Data as Cost).Amount;
		amountText.text = amount.ToString();
		amountText.color = defaultTextColor;
		if ((bool)LTFunctionLibrary.GetPlayerData()?.Inventory)
		{
			int storedObjectAmount = LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount((base.Data as Cost).Resource.Id);
			amountText.text = storedObjectAmount + "/" + amount;
			if (storedObjectAmount < amount)
			{
				amountText.color = cantAffordTextColor;
			}
		}
	}
}
