using UnityEngine;

[CreateAssetMenu(fileName = "RelicOverfillLowerCD", menuName = "Upgrade/Relic/OverfillLowerCD")]
public class RelicOverfillLowerCD : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		Train.Instance.OnOverfillStatusChanged += LowerCooldown;
	}

	public void LowerCooldown(bool add)
	{
		if (add)
		{
			foreach (Module module in Train.Instance.Modules)
			{
				StatUtils.ReduceCooldown(module, statusEffectSO);
			}
			return;
		}
		foreach (Module module2 in Train.Instance.Modules)
		{
			StatUtils.RemoveBuff(module2, statusEffectSO);
		}
	}
}
