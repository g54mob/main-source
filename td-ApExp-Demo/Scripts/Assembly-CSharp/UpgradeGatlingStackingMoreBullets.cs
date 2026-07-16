using UnityEngine;

[CreateAssetMenu(fileName = "GatlingStackingMoreBullets", menuName = "Upgrade/Gatling/StackingMoreBullets")]
public class UpgradeGatlingStackingMoreBullets : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	private ModuleGatling targetModule;

	public override void ApplyUpgrade()
	{
		ModuleGatling moduleByType = Train.Instance.GetModuleByType<ModuleGatling>();
		if ((object)moduleByType != null)
		{
			targetModule = moduleByType;
			targetModule.OnKill += Stack;
		}
	}

	public void Stack(HealthChangeInfo info)
	{
		targetModule.killCount++;
		if (targetModule.killCount == 4)
		{
			appliedStatusEffect = targetModule.StatsSO.ApplyStatusEffect(statusEffectSO);
			targetModule.killCount = 0;
		}
	}
}
