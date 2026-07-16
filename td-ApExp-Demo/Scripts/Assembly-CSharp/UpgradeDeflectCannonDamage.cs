using UnityEngine;

[CreateAssetMenu(fileName = "DeflectCannonDamage", menuName = "Upgrade/Deflect/DeflectCannonDamage")]
public class UpgradeDeflectCannonDamage : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectCannonDamage();
	}
}
