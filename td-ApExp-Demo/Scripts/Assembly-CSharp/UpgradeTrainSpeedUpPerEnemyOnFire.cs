using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeTrainSpeedUpPerEnemyOnFire", menuName = "Upgrade/Overdrive/TrainSpeedUpPerEnemyOnFire")]
public class UpgradeTrainSpeedUpPerEnemyOnFire : EnhancementUpgrade
{
	[SerializeField]
	private float newSpeedPerEnemyOnFire = 0.05f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.SpeedPerEnemyOnFire = newSpeedPerEnemyOnFire;
	}
}
