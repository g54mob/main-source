using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceRewardUI : UIListElement
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private TextMeshProUGUI amountText;

	[SerializeField]
	private TooltipComponent_text resourceNameTooltip;

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
	}
}
