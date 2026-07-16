using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Get Upgrades/Create New")]
public class MilestoneGetUpgrades : Milestone
{
	private Stats moduleStats;

	private int upgradesCount;

	[field: SerializeField]
	[field: Tooltip("If you leave this field empty (Set to None), this milestone will count every upgrade regardles of what module is it for.")]
	public EnhancementModule ModuleSO { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Select this ONLY if you set a specific module for unlocking. Do not worry about the goal it will be automatically adjusted during the game.")]
	public bool GetAllUpgrades { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.GetUpgrades;
		if (GetAllUpgrades && ModuleSO == null)
		{
			Debug.LogError("You have to select a module if GetAllUpgrades is true.");
		}
		upgradesCount = 0;
		if (ModuleSO == null)
		{
			Stats[] allStatsSOs = UpgradeManager.Instance.AllStatsSOs;
			for (int i = 0; i < allStatsSOs.Length; i++)
			{
				allStatsSOs[i].upgradeEvent += AddProgress;
			}
		}
		else
		{
			moduleStats = ModuleSO.ModulePrefab.GetComponent<Module>().StatsSO;
			moduleStats.upgradeEvent += AddProgress;
		}
	}

	public void AddProgress(Stats stats, EnhancementUpgrade upgrade)
	{
		if (upgrade.IsRelic || !GameManager.Instance.RunStarted)
		{
			return;
		}
		if (ModuleSO == null)
		{
			base.Progress++;
		}
		else
		{
			base.Progress++;
			if (GetAllUpgrades)
			{
				upgradesCount = 0;
				EnhancementUpgrade[] upgrades = UpgradeManager.Instance.Upgrades;
				foreach (EnhancementUpgrade enhancementUpgrade in upgrades)
				{
					if (enhancementUpgrade.IsRelic)
					{
						continue;
					}
					Stats[] statsObjectsToUpgrade = enhancementUpgrade.StatsObjectsToUpgrade;
					for (int j = 0; j < statsObjectsToUpgrade.Length; j++)
					{
						if (statsObjectsToUpgrade[j] == moduleStats)
						{
							if (enhancementUpgrade.UpgradesExclusiveTo == null)
							{
								upgradesCount++;
							}
							else if (!LootUtils.UpgradeExclusiveMet(enhancementUpgrade))
							{
								upgradesCount++;
							}
							break;
						}
					}
				}
				Goal = upgradesCount;
			}
		}
		UpdateProgress();
		if (base.Progress == Goal)
		{
			Complete();
		}
	}

	public override void Complete()
	{
		base.Complete();
		if (ModuleSO == null)
		{
			Stats[] allStatsSOs = UpgradeManager.Instance.AllStatsSOs;
			for (int i = 0; i < allStatsSOs.Length; i++)
			{
				allStatsSOs[i].upgradeEvent -= AddProgress;
			}
		}
		else
		{
			moduleStats = ModuleSO.ModulePrefab.GetComponent<Module>().StatsSO;
			moduleStats.upgradeEvent -= AddProgress;
		}
	}

	public override void ResetProgress()
	{
		base.ResetProgress();
		upgradesCount = 0;
	}
}
