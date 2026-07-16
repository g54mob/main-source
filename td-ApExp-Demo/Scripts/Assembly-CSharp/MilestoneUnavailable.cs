using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Unavailable/Create New")]
public class MilestoneUnavailable : Milestone
{
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.Unavailable;
	}

	public override void AddProgress()
	{
	}

	public override void ResetProgress()
	{
		base.ResetProgress();
	}
}
