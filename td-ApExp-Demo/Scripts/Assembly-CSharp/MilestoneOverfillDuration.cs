using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Overfill Duration/Create New")]
public class MilestoneOverfillDuration : Milestone
{
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.OverfillDuration;
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
