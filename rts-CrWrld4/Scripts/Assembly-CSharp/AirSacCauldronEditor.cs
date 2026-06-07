using UnityEngine;

public class AirSacCauldronEditor : UnitEditor
{
	private InspectorTime startTime;

	private InspectorTime productionInterval;

	private InspectorFloat payload;

	private InspectorInt count;

	private InspectorChoice targetBehavior;

	private InspectorVector2 targetBehaviorLocation;

	private InspectorBool disableMinimapWarning;

	private AirSacCauldron unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
