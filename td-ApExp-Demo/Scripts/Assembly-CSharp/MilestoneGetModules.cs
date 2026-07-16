using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Get Modules/Create New")]
public class MilestoneGetModules : Milestone
{
	[field: SerializeField]
	[field: Tooltip("If you leave this field empty (Set to None), this milestone will count every Module added.")]
	public EnhancementModule ModuleSO { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.GetRelics;
		UpgradeManager.Instance.OnAddEnhancementModule += AddProgress;
	}

	public void AddProgress(EnhancementModule module)
	{
		if ((ModuleSO == null || module == ModuleSO) && GameManager.Instance.RunStarted)
		{
			base.AddProgress();
		}
	}
}
