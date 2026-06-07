using System.Collections.Generic;
using UnityEngine;

public class TooltipUI_chest : TooltipUI
{
	[SerializeField]
	private UIList rewardList;

	private Chest chest;

	public override void Setup(Dictionary<string, object> data)
	{
		chest = (Chest)data["chest"];
		LoadRewardList();
	}

	private void LoadRewardList()
	{
		rewardList.gameObject.SetActive(value: true);
		rewardList.LoadList(chest.Reward);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
