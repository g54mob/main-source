using UnityEngine;

[CreateAssetMenu(fileName = "19EventInfo", menuName = "Radar/19EventInfo")]
public class RadarEventInfo : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.radarLevel = 2;
	}

	public override void OnRemoved()
	{
		UIManager.Instance.radarLevel = 0;
	}
}
