using UnityEngine;

[CreateAssetMenu(fileName = "22HullText", menuName = "Radar/22HullText")]
public class RadarHullText : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.HUD.SetHullTextActive(isActive: true);
	}

	public override void OnRemoved()
	{
		UIManager.Instance.HUD.SetHullTextActive(isActive: false);
	}
}
