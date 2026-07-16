using UnityEngine;

[CreateAssetMenu(fileName = "DeflectAutowave", menuName = "Upgrade/Deflect/Autowave")]
public class UpgradeDeflectAutowave : EnhancementUpgrade
{
	[SerializeField]
	private float autowaveCooldown;

	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectAutowave(autowaveCooldown);
	}
}
