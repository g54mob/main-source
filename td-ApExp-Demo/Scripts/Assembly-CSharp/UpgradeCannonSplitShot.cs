using UnityEngine;

[CreateAssetMenu(fileName = "CannonSplitShot", menuName = "Upgrade/Cannon/SplitShot")]
public class UpgradeCannonSplitShot : EnhancementUpgradeStats
{
	private ModuleCannon cannon;

	public float splitAngle;

	[SerializeField]
	private float splitShotDamageReduction;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
			moduleByType.cannon.splitShot = true;
			moduleByType.cannon.splitAngle = splitAngle;
			moduleByType.cannon.splitDamageReduction = splitShotDamageReduction;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
