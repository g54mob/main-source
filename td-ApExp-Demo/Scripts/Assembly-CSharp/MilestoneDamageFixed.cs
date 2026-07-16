using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Damage Fixed/Create New")]
public class MilestoneDamageFixed : Milestone
{
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.DamageFixed;
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
