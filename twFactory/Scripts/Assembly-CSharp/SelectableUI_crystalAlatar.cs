using UnityEngine;

public class SelectableUI_crystalAlatar : SelectableUI
{
	[SerializeField]
	private UIList rewardList;

	[SerializeField]
	private GameObject emptyTextObject;

	[SerializeField]
	private GameObject getRewardButtonObject;

	private CrystalAltar crystalAltar;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			crystalAltar = SelectedObject as CrystalAltar;
			LoadRewardList();
		}
	}

	private void LoadRewardList()
	{
		if (crystalAltar.AlreadyUsed)
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
			rewardList.LoadList(crystalAltar.Reward);
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void OnGetRewardButtonPressed()
	{
		crystalAltar.GetReward();
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
	}
}
