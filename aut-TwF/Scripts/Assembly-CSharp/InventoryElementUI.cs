using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElementUI : UIListElement
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private TextMeshProUGUI amountText;

	private TooltipComponent_text tooltipText;

	private void Awake()
	{
		tooltipText = GetComponent<TooltipComponent_text>();
	}

	public override void LoadData()
	{
		image.sprite = (base.Data as ResourceData).InventoryImage;
		UpdateCostText();
		tooltipText.TooltipText = (base.Data as ResourceData).DisplayName;
	}

	public void UpdateCostText()
	{
		amountText.text = LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount((base.Data as ResourceData).Id).ToString();
	}
}
