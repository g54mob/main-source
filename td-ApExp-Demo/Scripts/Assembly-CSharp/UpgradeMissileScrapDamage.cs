using UnityEngine;

[CreateAssetMenu(fileName = "MissileScrapDamage", menuName = "Upgrade/Missile/ScrapDamage")]
public class UpgradeMissileScrapDamage : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	private ModuleMissile missile;

	[SerializeField]
	private float stackScrapAmount;

	private float currentScrap;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			missile = moduleByType;
			missile.PreMissileSpawn += IncreaseDamage;
		}
	}

	public void IncreaseDamage()
	{
		float num = ResourceManager.Instance.Scrap.Value;
		if (num != currentScrap)
		{
			currentScrap = num;
			if (appliedStatusEffect != null)
			{
				missile.StatsSO.RemoveStatusEffect(appliedStatusEffect);
			}
			while (num >= stackScrapAmount)
			{
				num -= stackScrapAmount;
				appliedStatusEffect = missile.StatsSO.ApplyStatusEffect(statusEffectSO);
			}
		}
	}
}
