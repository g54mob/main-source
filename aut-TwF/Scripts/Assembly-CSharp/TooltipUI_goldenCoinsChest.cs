using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI_goldenCoinsChest : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI moneyAmountText;

	private GoldenCoinsChest chest;

	public override void Setup(Dictionary<string, object> data)
	{
		chest = (GoldenCoinsChest)data["chest"];
		LoadRewardList();
	}

	private void LoadRewardList()
	{
		moneyAmountText.text = chest.Money.ToString();
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
