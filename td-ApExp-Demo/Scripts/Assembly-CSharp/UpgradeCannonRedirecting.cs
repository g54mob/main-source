using UnityEngine;

[CreateAssetMenu(fileName = "CannonRedirecting", menuName = "Upgrade/Cannon/Redirecting")]
public class UpgradeCannonRedirecting : EnhancementUpgradeStats
{
	[SerializeField]
	private float range;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			moduleByType.cannon.hasRedirectingProjectiles = true;
			moduleByType.cannon.redirectRange = range;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
