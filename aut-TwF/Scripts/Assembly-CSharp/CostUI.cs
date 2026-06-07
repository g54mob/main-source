using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostUI : UIListElement
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private Image frame;

	[SerializeField]
	private TextMeshProUGUI amountText;

	[SerializeField]
	private bool onlyShowCost;

	[SerializeField]
	private Color cantAffordFrameColor = Color.white;

	[SerializeField]
	private Color cantAffordTextColor = Color.white;

	[SerializeField]
	private Color cantAffordImageColor = Color.white;

	[SerializeField]
	private TooltipComponent_text resourceNameTooltip;

	private Color defaultFrameColor;

	private Color defaultTextColor;

	private Color defaultImageColor;

	private void Awake()
	{
		defaultFrameColor = frame?.color ?? Color.white;
		defaultTextColor = amountText?.color ?? Color.white;
		defaultImageColor = image?.color ?? Color.white;
	}

	private void Update()
	{
		UpdateCostText();
	}

	public override void LoadData()
	{
		Cost cost = base.Data as Cost;
		image.sprite = cost.Resource.Image;
		UpdateCostText();
		resourceNameTooltip.TooltipText = cost.Resource.DisplayName;
	}

	private void UpdateCostText()
	{
		int amount = (base.Data as Cost).Amount;
		amountText.text = amount.ToString();
		SetFrameColor(defaultFrameColor);
		SetImageColor(defaultImageColor);
		amountText.color = defaultTextColor;
		if (!onlyShowCost && (bool)LTFunctionLibrary.GetPlayerData()?.Inventory)
		{
			int storedObjectAmount = LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount((base.Data as Cost).Resource.Id);
			amountText.text = storedObjectAmount + "/" + amount;
			if (storedObjectAmount < amount)
			{
				amountText.color = cantAffordTextColor;
				SetFrameColor(cantAffordFrameColor);
				SetImageColor(cantAffordImageColor);
			}
		}
	}

	private void SetImageColor(Color colorToSet)
	{
		if ((bool)image)
		{
			image.color = colorToSet;
		}
	}

	private void SetFrameColor(Color colorToSet)
	{
		if ((bool)frame)
		{
			frame.color = colorToSet;
		}
	}
}
