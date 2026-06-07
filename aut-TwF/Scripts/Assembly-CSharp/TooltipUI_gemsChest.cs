using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TooltipUI_gemsChest : TooltipUI
{
	[SerializeField]
	private UIList rewardList;

	private GemsChest chest;

	public override void Setup(Dictionary<string, object> data)
	{
		chest = (GemsChest)data["chest"];
		LoadRewardList();
	}

	private void LoadRewardList()
	{
		rewardList.gameObject.SetActive(value: true);
		rewardList.LoadList(from g in chest.Reward
			orderby g.Value descending, g.Id
			select g);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
