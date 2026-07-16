using UnityEngine;

[CreateAssetMenu(fileName = "DeflectRefundCooldown", menuName = "Upgrade/Deflect/RefundCooldown")]
public class UpgradeDeflectRefundCooldown : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectRefundCooldown();
	}
}
