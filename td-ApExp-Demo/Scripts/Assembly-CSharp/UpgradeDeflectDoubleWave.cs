using UnityEngine;

[CreateAssetMenu(fileName = "DeflectDoubleWave", menuName = "Upgrade/Deflect/DoubleWave")]
public class UpgradeDeflectDoubleWave : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyDeflectDoubleWave();
	}
}
