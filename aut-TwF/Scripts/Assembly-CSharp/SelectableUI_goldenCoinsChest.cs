using TMPro;
using UnityEngine;

public class SelectableUI_goldenCoinsChest : SelectableUI
{
	[SerializeField]
	private TextMeshProUGUI moneyAmountText;

	[SerializeField]
	private GameObject rewardObject;

	[SerializeField]
	private GameObject emptyTextObject;

	[SerializeField]
	private GameObject getRewardButtonObject;

	private GoldenCoinsChest chest;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			chest = SelectedObject as GoldenCoinsChest;
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
			rewardObject.gameObject.SetActive(value: false);
			getRewardButtonObject.SetActive(value: false);
		}
		else
		{
			emptyTextObject.SetActive(value: false);
			rewardObject.gameObject.SetActive(value: true);
			getRewardButtonObject.SetActive(value: true);
			moneyAmountText.text = chest.Money.ToString();
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void OnGetRewardButtonPressed()
	{
		chest.GetReward();
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
	}
}
