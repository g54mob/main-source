using UnityEngine;

[CreateAssetMenu(fileName = "NeedlerDirectHitChance", menuName = "Upgrade/Needler/DirectHitChance")]
public class UpgradeNeedlerDirectHitChance : EnhancementUpgrade
{
	[SerializeField]
	private float percentChanceForDirectHit;

	private ModuleNeedler needler;

	public override void ApplyUpgrade()
	{
		needler = Train.Instance.GetModuleByType<ModuleNeedler>();
		needler.chanceForDirectHit = percentChanceForDirectHit;
	}
}
