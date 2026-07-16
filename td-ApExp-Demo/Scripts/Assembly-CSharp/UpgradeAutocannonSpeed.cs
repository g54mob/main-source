using UnityEngine;

[CreateAssetMenu(fileName = "AutocannonSpeed", menuName = "Upgrade/Autocannon/Speed")]
public class UpgradeAutocannonSpeed : EnhancementUpgrade
{
	[SerializeField]
	private float attackSpeedIncreasePercent;

	[SerializeField]
	private float buffDuration;

	private ModuleAutocannon moduleAutocannon;

	public override void ApplyUpgrade()
	{
		ModuleAutocannon moduleByType = Train.Instance.GetModuleByType<ModuleAutocannon>();
		if ((object)moduleByType != null)
		{
			moduleAutocannon = moduleByType;
			moduleAutocannon.frenzy = true;
			moduleAutocannon.frenzyAttackSpeedGain = attackSpeedIncreasePercent;
			moduleAutocannon.OnKill += OnAutocannonKill;
		}
	}

	private void OnAutocannonKill(HealthChangeInfo info)
	{
		moduleAutocannon.frenzyDuration = buffDuration;
	}
}
