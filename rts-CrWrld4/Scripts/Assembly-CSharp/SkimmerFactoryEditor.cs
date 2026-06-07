using UnityEngine;

public class SkimmerFactoryEditor : UnitEditor
{
	private InspectorTime startTime;

	private InspectorTime productionInterval;

	private InspectorFloat payload;

	private InspectorInt count;

	private InspectorTime lifetime;

	private InspectorChoice targetBehavior;

	private InspectorVector2 targetBehaviorLocation;

	private InspectorBool disableMinimapWarning;

	private InspectorTime forbStartTime;

	private InspectorTime forbProductionInterval;

	private InspectorFloat forbPayload;

	private InspectorInt forbCount;

	private SkimmerFactory unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
