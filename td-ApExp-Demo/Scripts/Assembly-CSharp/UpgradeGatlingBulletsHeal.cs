using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GatlingBulletsHeal", menuName = "Upgrade/Gatling/BulletsHeal")]
public class UpgradeGatlingBulletsHeal : EnhancementUpgrade
{
	[SerializeField]
	private float chanceToHeal;

	[SerializeField]
	private float healAmount;

	public override void ApplyUpgrade()
	{
		ModuleGatling moduleByType = Train.Instance.GetModuleByType<ModuleGatling>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnProjectileHitEvent += TryHeal;
		}
	}

	public void TryHeal(HealthChangeInfo info)
	{
		if (ProbUtils.CheckWithLuck(chanceToHeal))
		{
			(from module in Train.Instance.Modules
				where (bool)module && (bool)module.HealthComponent
				orderby module.HealthComponent.HealthCurrent
				select module).FirstOrDefault().HealthComponent.Heal(healAmount, Train.Instance.GetModuleByType<ModuleGatling>());
		}
	}
}
