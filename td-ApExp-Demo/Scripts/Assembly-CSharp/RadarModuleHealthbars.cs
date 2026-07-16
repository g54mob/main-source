using UnityEngine;

[CreateAssetMenu(fileName = "28ModuleHealthbars", menuName = "Radar/28ModuleHealthbars")]
public class RadarModuleHealthbars : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.ModuleHealthbarsDisplay.enabled = true;
	}

	public override void OnRemoved()
	{
		UIManager.Instance.ModuleHealthbarsDisplay.enabled = false;
	}
}
