using UnityEngine;

[CreateAssetMenu(fileName = "HardenPlow", menuName = "Upgrade/Harden/Plow")]
public class UpgradeHardenPlow : EnhancementUpgrade
{
	[SerializeField]
	private int obstacleImmunitiesPerLevel = 1;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		Train.Instance.obstacleImmunitiesPerLevel = obstacleImmunitiesPerLevel;
		Train.Instance.ResetObstacleImmunitiesRemaining();
	}

	public override void OnRemove()
	{
		base.OnRemove();
		Train.Instance.obstacleImmunitiesPerLevel = 0;
		Train.Instance.ResetObstacleImmunitiesRemaining();
	}
}
