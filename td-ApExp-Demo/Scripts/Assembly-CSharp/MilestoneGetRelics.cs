using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Get Relics/Create New")]
public class MilestoneGetRelics : Milestone
{
	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.GetRelics;
		UpgradeManager.Instance.OnAddRelic += AddProgress;
	}

	public override void AddProgress()
	{
		if (GameManager.Instance.RunStarted)
		{
			base.AddProgress();
		}
	}
}
