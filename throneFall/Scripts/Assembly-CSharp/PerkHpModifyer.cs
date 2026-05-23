using UnityEngine;

public class PerkHpModifyer : MonoBehaviour, ISaveLoad
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float hpMultiplyer;

	public Hp hp;

	[SerializeField]
	private bool isUnit;

	private bool executed;

	public void OnBeforeMainLoadPass(string guid)
	{
		Execute(heal: false);
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
		Execute(heal: true);
	}

	private void Execute(bool heal)
	{
		if (executed)
		{
			return;
		}
		executed = true;
		if (PerkManager.IsEquipped(requiredPerk))
		{
			if (!isUnit)
			{
				BuildSlot buildSlot = GetComponent<BuildSlot>();
				if (!buildSlot)
				{
					buildSlot = GetComponentInParent<BuildSlot>();
				}
				if ((bool)buildSlot)
				{
					foreach (BuildSlot.Upgrade ownUpgrade in buildSlot.OwnUpgrades)
					{
						foreach (BuildSlot.UpgradeBranch upgradeBranch in ownUpgrade.upgradeBranches)
						{
							upgradeBranch.hpChange = Mathf.RoundToInt((float)upgradeBranch.hpChange * hpMultiplyer);
						}
					}
				}
			}
			hp.maxHp *= hpMultiplyer;
			if (heal)
			{
				hp.Heal(float.MaxValue);
			}
		}
		Object.Destroy(this);
	}
}
