using UnityEngine;

public class SelectableUI_chest : SelectableUI
{
	[SerializeField]
	private UIList rewardList;

	[SerializeField]
	private GameObject emptyTextObject;

	[SerializeField]
	private GameObject getRewardButtonObject;

	private Chest chest;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			chest = SelectedObject as Chest;
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
		if (chest.AlreadyUsed)
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
			rewardList.LoadList(chest.Reward);
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void OnGetRewardButtonPressed()
	{
		chest.GetReward();
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
	}
}
