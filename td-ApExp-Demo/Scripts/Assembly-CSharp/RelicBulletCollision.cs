using UnityEngine;

[CreateAssetMenu(fileName = "RelicBulletCollision", menuName = "Upgrade/Relic/BulletCollision")]
public class RelicBulletCollision : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		GameManager.Instance.bulletCollisionOn = true;
	}
}
