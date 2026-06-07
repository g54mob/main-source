using UnityEngine;

public class EmitterEditor : UnitEditor
{
	private InspectorFloat emitAmt;

	private InspectorTime emitDelay;

	private InspectorTime startDelay;

	private InspectorFloat grapeCreeperMax;

	private InspectorFloat grapeCreeperMin;

	private EmitterSecondaryEditor secondaryEditor;

	private Emitter unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
