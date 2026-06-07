using UnityEngine;

public class CytocreepLauncherEditor : UnitEditor
{
	private InspectorTime startTime;

	private InspectorTime productionInterval;

	private InspectorFloat payload;

	private InspectorInt count;

	private InspectorChoice targetBehavior;

	private CytocreepLauncher unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
