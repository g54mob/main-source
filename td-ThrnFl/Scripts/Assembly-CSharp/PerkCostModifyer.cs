using UnityEngine;

public class PerkCostModifyer : MonoBehaviour
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int[] upgradeCostChange;

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredPerk))
		{
			BuildSlot componentInParent = GetComponentInParent<BuildSlot>();
			for (int i = 0; i < componentInParent.Upgrades.Count; i++)
			{
				BuildSlot.Upgrade upgrade = componentInParent.Upgrades[i];
				if (!componentInParent.UpgradesWithCostsLoadedFromSave.Contains(upgrade) && upgradeCostChange.Length > i)
				{
					upgrade.cost += upgradeCostChange[i];
				}
			}
		}
		Object.Destroy(this);
	}
}
