using UnityEngine;

[CreateAssetMenu(fileName = "NeedlerStackingAttackSpeed", menuName = "Upgrade/Needler/StackingAttackSpeed")]
public class UpgradeNeedlerStackingAttackSpeed : EnhancementUpgrade
{
	private ModuleNeedler needler;

	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	public override void ApplyUpgrade()
	{
		needler = Train.Instance.GetModuleByType<ModuleNeedler>();
		needler.OnBurstCountReached += IncreaseAttackSpeed;
	}

	public void IncreaseAttackSpeed()
	{
		appliedStatusEffect = needler.StatsSO.ApplyStatusEffect(statusEffectSO);
	}
}
