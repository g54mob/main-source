using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilesWrapDamage", menuName = "Upgrade/Player/WrapDamage")]
public class UpgradeProjectileWrapDamage : EnhancementUpgrade
{
	[SerializeField]
	private float wrapDamageMultiplierIncrease;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.WrapDamageMult += wrapDamageMultiplierIncrease;
	}

	public override void OnRemove()
	{
		base.OnRemove();
		GlobalFields.Instance.WrapDamageMult -= wrapDamageMultiplierIncrease;
	}
}
