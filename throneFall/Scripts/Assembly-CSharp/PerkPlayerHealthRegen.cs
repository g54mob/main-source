using UnityEngine;

public class PerkPlayerHealthRegen : MonoBehaviour, ISaveLoad
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float hpRegenMultiplyer;

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
		if (!executed)
		{
			executed = true;
			if (PerkManager.IsEquipped(requiredPerk))
			{
				PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer *= hpRegenMultiplyer;
				Object.Destroy(this);
			}
		}
	}
}
