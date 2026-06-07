using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUpgradeBuildingOnStart : MonoBehaviour
{
	public List<int> upgradePaths = new List<int>();

	private void Start()
	{
		StartCoroutine(AutoUpgradeOnStart());
	}

	private IEnumerator AutoUpgradeOnStart()
	{
		BuildSlot bs = GetComponent<BuildSlot>();
		bs.Activate();
		bs.StartDeactivated = false;
		bs.Interactor.SetHarvested(_harvested: true);
		yield return null;
		for (int iUpgrade = 0; iUpgrade < upgradePaths.Count; iUpgrade++)
		{
			int index = upgradePaths[iUpgrade];
			if (bs.Level <= iUpgrade)
			{
				BuildSlot.UpgradeBranch upgBranch = bs.upgrades[bs.Level].upgradeBranches[index];
				bs.ForceManualUpgradeWithoutFeedbackEffects(upgBranch);
				yield return null;
			}
		}
		if (bs.AppliedUpgrades.Count < upgradePaths.Count)
		{
			bs.AppliedUpgrades.Clear();
			bs.AppliedUpgrades.AddRange(upgradePaths);
		}
	}
}
