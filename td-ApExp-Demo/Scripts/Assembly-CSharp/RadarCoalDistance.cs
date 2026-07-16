using UnityEngine;

[CreateAssetMenu(fileName = "32CoalDistance", menuName = "Radar/32CoalDistance")]
public class RadarCoalDistance : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.HUD.CoalFill.gameObject.SetActive(value: true);
	}

	public override void OnRemoved()
	{
		UIManager.Instance.HUD.CoalFill.gameObject.SetActive(value: false);
	}
}
