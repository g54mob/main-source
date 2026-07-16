using UnityEngine;

[CreateAssetMenu(fileName = "AutocannonKillDamage", menuName = "Upgrade/Autocannon/KillDamage")]
public class UpgradeAutocannonKillDamage : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	private ModuleAutocannon autocannon;

	public override void ApplyUpgrade()
	{
		ModuleAutocannon moduleByType = Train.Instance.GetModuleByType<ModuleAutocannon>();
		if ((object)moduleByType != null)
		{
			autocannon = moduleByType;
			autocannon.OnKill += OnAutocannonKill;
		}
	}

	private void OnAutocannonKill(HealthChangeInfo info)
	{
		appliedStatusEffect = autocannon.StatsSO.ApplyStatusEffect(statusEffectSO);
	}
}
