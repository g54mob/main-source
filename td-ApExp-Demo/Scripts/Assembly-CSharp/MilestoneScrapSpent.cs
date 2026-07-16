using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Scrap Spent/Create New")]
public class MilestoneScrapSpent : Milestone
{
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.ScrapSpent;
	}

	public void AddProgress(float progressAmount)
	{
		base.Progress += progressAmount;
		UpdateProgress();
		if (base.Progress == Goal)
		{
			Complete();
		}
	}

	public override void ResetProgress()
	{
		base.ResetProgress();
	}
}
