using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Distance Traveled/Create New")]
public class MilestoneDistanceTraveled : Milestone
{
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.DistanceTraveled;
		Train.Instance.DistanceTraveled += HandleDistanceTraveled;
	}

	public void HandleDistanceTraveled(float distance)
	{
		base.Progress += distance;
		UpdateProgress();
		if (base.Progress >= Goal)
		{
			Complete();
		}
	}

	public override void ResetProgress()
	{
		base.ResetProgress();
	}
}
