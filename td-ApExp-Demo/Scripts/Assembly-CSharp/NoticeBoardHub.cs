using UnityEngine;

public class NoticeBoardHub : BrokenHubStation, ISaveable
{
	[SerializeField]
	private Animator bobbyFixerAnimator;

	protected override void SetupBrokenStation()
	{
		base.SetupBrokenStation();
		bobbyFixerAnimator.Play("Repair");
	}

	protected override void SetupFixedStation()
	{
		base.SetupFixedStation();
		bobbyFixerAnimator.gameObject.SetActive(value: false);
		if (!GameManager.Instance.isDemo)
		{
			MilestoneManager.Instance.canUpdateProgress = true;
		}
	}

	public void Save(SaveDataContext context)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			metaSave.isNoticeBoardFixed = isFixed;
			metaSave.isNoticeBoardReadyToUnlock = canBeBought;
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			isFixed = metaSave.isNoticeBoardFixed;
			canBeBought = metaSave.isNoticeBoardReadyToUnlock;
			if (isFixed && !GameManager.Instance.isDemo)
			{
				MilestoneManager.Instance.canUpdateProgress = true;
			}
			else
			{
				MilestoneManager.Instance.canUpdateProgress = false;
			}
			Debug.Log("Loaded Notice Board");
		}
	}
}
