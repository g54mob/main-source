using UnityEngine;

[CreateAssetMenu(fileName = "DeflectDamage", menuName = "Upgrade/Deflect/Damage")]
public class UpgradeDeflectDamage : EnhancementUpgrade
{
	[SerializeField]
	private float newDeflectDmgMult = 3f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.RicochetDmgMult = newDeflectDmgMult;
	}
}
