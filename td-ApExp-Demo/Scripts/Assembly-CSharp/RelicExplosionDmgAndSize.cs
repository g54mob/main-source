using UnityEngine;

[CreateAssetMenu(fileName = "RelicExplosionDmgAndSize", menuName = "Upgrade/Relic/ExplosionDmgAndSize")]
public class RelicExplosionDmgAndSize : EnhancementUpgrade
{
	[SerializeField]
	private float explosionDmgMult;

	[SerializeField]
	private float explosionSizeMult;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.ExplosionDamageMult += explosionDmgMult;
		GlobalFields.Instance.ExplosionRadiusMult += explosionSizeMult;
	}
}
