using UnityEngine;

[CreateAssetMenu(fileName = "OverfillDamage", menuName = "Upgrade/Relic/OverfillDamage")]
public class RelicOverfillDamage : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		Train.Instance.OnOverfillStatusChanged += IncreaseDamage;
	}

	public void IncreaseDamage(bool add)
	{
		if (add)
		{
			foreach (Module module in Train.Instance.Modules)
			{
				StatUtils.IncreaseDamage(module, statusEffectSO);
			}
			return;
		}
		foreach (Module module2 in Train.Instance.Modules)
		{
			StatUtils.RemoveBuff(module2, statusEffectSO);
		}
	}
}
