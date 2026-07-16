using UnityEngine;

[CreateAssetMenu(fileName = "DeflectSplitBullet", menuName = "Upgrade/Deflect/SplitBullet")]
public class UpgradeDeflectSplitBullet : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectSplitBullet();
	}
}
