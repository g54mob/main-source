using UnityEngine;

public class BlobNestEditor : UnitEditor
{
	private InspectorTime startTime;

	private InspectorTime productionInterval;

	private InspectorFloat payload;

	private InspectorInt count;

	private InspectorTime lifetime;

	private InspectorChoice targetBehavior;

	private InspectorVector2 targetBehaviorLocation;

	private InspectorFloat carryEggProb;

	private InspectorBool disableMinimapWarning;

	private BlobNest unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
