using UnityEngine;

public class PerkIncomeModifyer : MonoBehaviour, ISaveLoad
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int[] upgradeIncomeChange;

	private bool executed;

	public void OnBeforeMainLoadPass(string guid)
	{
		Execute();
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
	}

	public void OnSave(string guid)
	{
	}

	private void Start()
	{
		Execute();
	}

	private void Execute()
	{
		if (executed)
		{
			return;
		}
		executed = true;
		if (PerkManager.IsEquipped(requiredPerk))
		{
			BuildSlot component = GetComponent<BuildSlot>();
			for (int i = 0; i < component.Upgrades.Count; i++)
			{
				foreach (BuildSlot.UpgradeBranch upgradeBranch in component.Upgrades[i].upgradeBranches)
				{
					if (upgradeIncomeChange.Length > i)
					{
						upgradeBranch.goldIncomeChange += upgradeIncomeChange[i];
					}
				}
			}
		}
		Object.Destroy(this);
	}
}
