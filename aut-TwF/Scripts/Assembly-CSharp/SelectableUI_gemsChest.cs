using System.Linq;
using UnityEngine;

public class SelectableUI_gemsChest : SelectableUI
{
	[SerializeField]
	private UIList rewardList;

	[SerializeField]
	private GameObject emptyTextObject;

	[SerializeField]
	private GameObject getRewardButtonObject;

	private GemsChest gemsChest;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			gemsChest = SelectedObject as GemsChest;
			if (SettingsController.instance.AutoLootChests)
			{
				OnGetRewardButtonPressed();
			}
			else
			{
				LoadRewardList();
			}
		}
	}

	private void LoadRewardList()
	{
		if (gemsChest.AlreadyUsed)
		{
			emptyTextObject.SetActive(value: true);
			rewardList.gameObject.SetActive(value: false);
			getRewardButtonObject.SetActive(value: false);
		}
		else
		{
			emptyTextObject.SetActive(value: false);
			rewardList.gameObject.SetActive(value: true);
			getRewardButtonObject.SetActive(value: true);
			rewardList.LoadList(from g in gemsChest.Reward
				orderby g.Value descending, g.Id
				select g);
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void OnGetRewardButtonPressed()
	{
		gemsChest.GetReward();
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
	}
}
