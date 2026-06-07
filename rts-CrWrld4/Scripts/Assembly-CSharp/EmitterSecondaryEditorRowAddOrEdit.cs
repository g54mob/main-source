using UnityEngine;

public class EmitterSecondaryEditorRowAddOrEdit : MonoBehaviour
{
	public EmitterSecondaryEditor editor;

	public InspectorChoice secondaryType;

	public InspectorInt count;

	public InspectorFloat creeper;

	public InspectorInt cost;

	public InspectorInt delay;

	public InspectorChoice targetType;

	private EmitterSecondaryRowEditor rowEditor;

	public void SetAddMode()
	{
	}

	public void SetEditMode(EmitterSecondaryRowEditor rowEditor)
	{
	}

	public void OnOK()
	{
	}

	private void AssignRow(Emitter.SecondaryEnemyRow row)
	{
	}

	public void OnCancel()
	{
	}
}
