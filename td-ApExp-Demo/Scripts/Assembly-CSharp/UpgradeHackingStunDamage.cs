using UnityEngine;

[CreateAssetMenu(fileName = "HackingStunDamage", menuName = "Upgrade/Hacking/StunDamage")]
public class UpgradeHackingStunDamage : EnhancementUpgrade
{
	[SerializeField]
	private float hackExpiryStunDurationAndDamage = 1f;

	public override void ApplyUpgrade()
	{
		Train.Instance.hackExpiryStunDurationAndDamage = hackExpiryStunDurationAndDamage;
	}
}
