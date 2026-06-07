using UnityEngine;

public class SporeLauncherEditor : UnitEditor
{
	private InspectorTime startTime;

	private InspectorTime productionInterval;

	private InspectorFloat payload;

	private InspectorInt count;

	private InspectorChoice targetBehavior;

	private InspectorVector2 targetBehaviorLocation;

	private InspectorBool disableMinimapWarning;

	private InspectorTime eggStartTime;

	private InspectorTime eggProductionInterval;

	private InspectorBool eggOnlyDuringCutoff;

	private InspectorInt eggCount;

	private InspectorFloat eggDefensiveRatio;

	private SporeLauncher unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
