using UnityEngine;

[CreateAssetMenu(fileName = "ClawResourceAOE", menuName = "Upgrade/Claw/ResourceAOE")]
public class UpgradeClawResourceAOE : EnhancementUpgrade
{
	[SerializeField]
	private float collectExplosionDamage = 1f;

	public override void ApplyUpgrade()
	{
		ModuleClaw moduleByType = Train.Instance.GetModuleByType<ModuleClaw>();
		if ((object)moduleByType != null)
		{
			moduleByType.collectExplosionDamage = collectExplosionDamage;
		}
	}
}
