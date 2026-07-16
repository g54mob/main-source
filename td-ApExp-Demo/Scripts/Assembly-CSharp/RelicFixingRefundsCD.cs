using UnityEngine;

[CreateAssetMenu(fileName = "RelicFixingRefundsCD", menuName = "Upgrade/Relic/FixingRefundsCD")]
public class RelicFixingRefundsCD : EnhancementUpgrade
{
	[SerializeField]
	private float cooldownPercentRefunded;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		CombatManager.Instance.HealthChanged += ChargeModule;
	}

	public void ChargeModule(HealthChangeInfo info)
	{
		if (!(info.HealthChange <= 0f))
		{
			Module component = info.Target.gameObject.GetComponent<Module>();
			if ((object)component != null && info.source is PlayerRepairDamage)
			{
				component.ChargeModuleBy(component.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) * (cooldownPercentRefunded / 100f) * info.HealthChange);
			}
		}
	}
}
