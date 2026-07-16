using UnityEngine;

[CreateAssetMenu(fileName = "NeedlerRandomShots", menuName = "Upgrade/Needler/RandomShots")]
public class UpgradeNeedlerRandomShots : EnhancementUpgrade
{
	[SerializeField]
	private float percentChanceToFire;

	private ModuleNeedler needler;

	private ModuleGatling gatling;

	public override void ApplyUpgrade()
	{
		needler = Train.Instance.GetModuleByType<ModuleNeedler>();
		gatling = Train.Instance.GetModuleByType<ModuleGatling>();
		gatling.OnProjectileHitEvent += NeedlerShot;
	}

	public void NeedlerShot(HealthChangeInfo info)
	{
		if (ProbUtils.CheckWithLuck(percentChanceToFire))
		{
			float angle = Random.Range(0f, 360f);
			needler.SpawnProjectile(angle, -1);
		}
	}
}
