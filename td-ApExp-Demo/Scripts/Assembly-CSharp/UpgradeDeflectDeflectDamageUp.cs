using UnityEngine;

[CreateAssetMenu(fileName = "DeflectBulletDamageUp", menuName = "Upgrade/Deflect/BulletDamageUp")]
public class UpgradeDeflectDeflectDamageUp : EnhancementUpgrade
{
	[SerializeField]
	private float deflectBulletDamageIncreasePercent;

	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectBulletDamageUp(deflectBulletDamageIncreasePercent);
	}
}
