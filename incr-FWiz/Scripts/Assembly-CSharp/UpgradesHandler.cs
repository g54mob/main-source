using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class UpgradesHandler : MonoBehaviour
{
	[SerializeField]
	private UpgradeDef _rootUpgrade;

	[SerializeField]
	private List<UpgradeInstance> _upgradeInstances;

	public Dictionary<string, UpgradeDef> UpgradeDefs;

	private Dictionary<string, UpgradeInstance> _upgradeInstancesDict;

	private HashSet<UpgradeInstance> _upgradesVisible;

	private Dictionary<UpgradeDef, Action<int>> _increaseUpgradeLevelsTrackerDict;

	public static Action<UpgradesHandler> AnnounceInstance;

	private Dictionary<UpgradeDef, List<UpgradeDef>> _upgradeChildrenDictionary;

	public BoolContainer TreeCompleted;

	public static UpgradesHandler Instance { get; private set; }

	public int MaxUpgradesCount { get; private set; }

	public int UpgradesUnlockedCount { get; private set; }

	public UpgradeStation UpgradeStation { get; private set; }

	public event Action<UpgradeInstance> AnnounceUpgradeCompleted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate()
	{
	}

	public UpgradeDef GetUpgradeDef(string ID)
	{
		return null;
	}

	public List<UpgradeDef> GetChildrenDefs(UpgradeDef upgradeDef)
	{
		return null;
	}

	public void CallOnUpgradeAchieved(UpgradeDef upgradeDef, Action<int> callback, bool onlyCallOnInitialUpgrade = false)
	{
	}

	public void CancelCallOnUpgradeAchieved(UpgradeDef upgradeDef, Action<int> callback)
	{
	}

	public void SetUpgradeToMaximumLevel(UpgradeInstance upgrade)
	{
	}

	public void EvaluatedCompletedness()
	{
	}

	public void IncrementUpgradeLevel(UpgradeInstance existingUpgrade)
	{
	}

	public UpgradeInstance GetUpgradeInstance(string ID)
	{
		return null;
	}

	public UpgradeInstance GetUpgradeInstance(UpgradeDef upgradeDef)
	{
		return null;
	}

	public int GetLevelAchieved(UpgradeDef upgradeDef)
	{
		return 0;
	}

	public bool HasUpgrade(UpgradeDef upgradeDef)
	{
		return false;
	}

	public bool CanLevelUp(UpgradeDef upgradeDef)
	{
		return false;
	}

	public List<UpgradeInstance> GetVisibleUpgrades()
	{
		return null;
	}

	public bool IsUpgradeVisible(UpgradeInstance upgradeInstance)
	{
		return false;
	}

	public UpgradeInstance GetRoot()
	{
		return null;
	}

	public void SetUpgradeStation(UpgradeStation upgradeStation)
	{
	}
}
