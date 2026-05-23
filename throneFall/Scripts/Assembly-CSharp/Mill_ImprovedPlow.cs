using UnityEngine;

public class Mill_ImprovedPlow : MonoBehaviour
{
	[SerializeField]
	private BuildSlot buildSlot;

	public Mesh lvl2Mesh;

	public Mesh lvl3Mesh;

	private void OnEnable()
	{
		buildSlot.upgrades[1].upgradeBranches[0].replacementMesh = lvl2Mesh;
		buildSlot.upgrades[2].upgradeBranches[0].replacementMesh = lvl3Mesh;
		foreach (BuildSlot.UpgradeBranch upgradeBranch in buildSlot.Upgrades[1].upgradeBranches)
		{
			upgradeBranch.goldIncomeChange++;
		}
		foreach (BuildSlot.UpgradeBranch upgradeBranch2 in buildSlot.Upgrades[2].upgradeBranches)
		{
			upgradeBranch2.goldIncomeChange++;
		}
		Object.Destroy(base.gameObject);
	}
}
