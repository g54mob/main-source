using UnityEngine;

public class StashEditor : UnitEditor
{
	private InspectorBool consumeCreeper;

	private InspectorFloat releaseThreshold;

	private InspectorFloat collectRatio;

	private InspectorTime coolDownTime;

	private InspectorTime unsupportedReleaseTime;

	private InspectorButton resetButton;

	private Stash unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	private void OnClick()
	{
	}

	public void Apply()
	{
	}
}
