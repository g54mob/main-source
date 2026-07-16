using UnityEngine;

[CreateAssetMenu(fileName = "26MapDiscovery", menuName = "Radar/26MapDiscovery")]
public class RadarMapDiscovery : EnhancementRadar
{
	[SerializeField]
	private int mapDiscoveryDstIncrease = 1;

	public override void OnApplied()
	{
		LevelManager.Instance.Config.DiscoveryDst += mapDiscoveryDstIncrease;
	}

	public override void OnRemoved()
	{
		LevelManager.Instance.Config.DiscoveryDst -= mapDiscoveryDstIncrease;
	}
}
