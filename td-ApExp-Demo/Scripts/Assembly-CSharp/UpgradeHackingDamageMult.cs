using UnityEngine;

[CreateAssetMenu(fileName = "HackingDamageMult", menuName = "Upgrade/Hacking/DamageMult")]
public class UpgradeHackingDamageMult : EnhancementUpgrade
{
	[SerializeField]
	private float hackDamageMult = 2f;

	public override void ApplyUpgrade()
	{
		Train.Instance.hackDamageMult = hackDamageMult;
	}
}
