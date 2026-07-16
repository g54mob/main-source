using UnityEngine;

[CreateAssetMenu(fileName = "DeflectCanHack", menuName = "Upgrade/Deflect/DeflectCanHack")]
public class UpgradeDeflectCanHack : EnhancementUpgrade
{
	[SerializeField]
	private float probability;

	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectCanHack(probability);
	}
}
