using UnityEngine;

[CreateAssetMenu(fileName = "ShieldRicochet", menuName = "Upgrade/Shield/Ricochet")]
public class UpgradeShieldRicochet : EnhancementUpgrade
{
	[SerializeField]
	private float ricochetChance = 50f;

	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyShieldRicochet(ricochetChance);
	}

	public override void OnRemove()
	{
		base.OnRemove();
		Train.Instance.ApplyShieldRicochet(0f - ricochetChance);
	}
}
