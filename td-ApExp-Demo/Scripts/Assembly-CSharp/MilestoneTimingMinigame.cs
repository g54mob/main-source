using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Timing Minigame/Create New")]
public class MilestoneTimingMinigame : Milestone
{
	[field: SerializeField]
	public TimingBarTypes timingBarType { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.TimingMinigame;
	}

	public void AddProgress(float progressAmount, TimingBarTypes type)
	{
		if (type == timingBarType)
		{
			base.Progress += progressAmount;
			UpdateProgress();
			if (base.Progress == Goal)
			{
				Complete();
			}
		}
	}

	public override void ResetProgress()
	{
		base.ResetProgress();
	}
}
