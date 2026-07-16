using UnityEngine;

[CreateAssetMenu(fileName = "CannonExplosive", menuName = "Upgrade/Cannon/Explosive")]
public class UpgradeCannonExplosive : EnhancementUpgradeStats
{
	private ModuleCannon cannon;

	[SerializeField]
	private GameObject explosionGo;

	[SerializeField]
	private float explosionSize = 0.125f;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
			moduleByType.cannon.HasExplosiveShots = true;
			moduleByType.cannon.explosionGo = explosionGo;
			moduleByType.cannon.explosionSize = explosionSize;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
