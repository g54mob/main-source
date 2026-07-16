using UnityEngine;

[CreateAssetMenu(fileName = "CannonScrapDamage", menuName = "Upgrade/Cannon/ScrapDamage")]
public class UpgradeCannonScrapDamage : EnhancementUpgrade
{
	[SerializeField]
	[Tooltip("How much scrap the player needs to have stored to increase cannon damage by 1.")]
	private float scrapPerDamage = 200f;

	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	private ModuleCannon cannon;

	private float dmgIncrementPerStack;

	public override void ApplyUpgrade()
	{
		dmgIncrementPerStack = (statusEffectSO as StatusEffectStats).statUpgrades[0].stat.statValue;
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
			cannon.cannon.OnUpgraded();
		}
		ResourceManager.Instance.Scrap.OnValueChangedTo.AddListener(OnScrapChange);
		OnScrapChange(ResourceManager.Instance.Scrap.Value);
	}

	private void OnScrapChange(float newScrap)
	{
		int num = Mathf.CeilToInt(newScrap / scrapPerDamage / dmgIncrementPerStack);
		if (num == 0)
		{
			cannon.StatsSO.RemoveStatusEffect(appliedStatusEffect);
			return;
		}
		appliedStatusEffect = cannon.StatsSO.ApplyStatusEffect(statusEffectSO);
		appliedStatusEffect.SetStacks(num);
	}
}
