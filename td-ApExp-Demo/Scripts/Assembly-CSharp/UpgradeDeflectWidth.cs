using UnityEngine;

[CreateAssetMenu(fileName = "DeflectWidth", menuName = "Upgrade/Deflect/Width")]
public class UpgradeDeflectWidth : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectWidth();
	}
}
