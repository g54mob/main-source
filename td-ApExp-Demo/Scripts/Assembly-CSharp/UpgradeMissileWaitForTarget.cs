using UnityEngine;

[CreateAssetMenu(fileName = "MissileWaitForTarget", menuName = "Upgrade/Missile/WaitForTarget")]
public class UpgradeMissileWaitForTarget : EnhancementUpgrade
{
	[SerializeField]
	private float missileTimeToWaitForTargets = 10f;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			moduleByType.MissilesCanWaitForTargets = true;
			moduleByType.MissilesTimeToWaitForTargets = missileTimeToWaitForTargets;
		}
	}
}
