using UnityEngine;

[CreateAssetMenu(fileName = "FurnaceStationRefuelMax", menuName = "Upgrade/Furnace/StationRefuelMax")]
public class UpgradeFurnaceStationRefuelMax : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.CoalFillNormalizedOnLevelStart = 1f;
	}
}
