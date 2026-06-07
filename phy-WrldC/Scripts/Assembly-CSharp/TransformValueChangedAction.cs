using RLD;
using UnityEngine;

public class TransformValueChangedAction : IUndoRedoAction
{
	private Transform transform;

	private int axisIndex;

	private float oldValue;

	private float newValue;

	public TransformValueChangedAction(Transform transform, int axisIndex, float oldValue, float newValue)
	{
		this.transform = transform;
		this.axisIndex = axisIndex;
		this.oldValue = oldValue;
		this.newValue = newValue;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (!(transform == null))
		{
			SetValueAtAxisIndex(axisIndex, oldValue);
		}
	}

	public void Redo()
	{
		if (!(transform == null))
		{
			SetValueAtAxisIndex(axisIndex, newValue);
		}
	}

	public void OnRemovedFromUndoRedoStack()
	{
	}

	private void SetValueAtAxisIndex(int axisIndex, float value)
	{
		switch (axisIndex)
		{
		case 0:
			transform.SetPositionX(value);
			break;
		case 1:
			transform.SetPositionY(value);
			break;
		case 2:
			transform.SetPositionZ(value);
			break;
		case 3:
			transform.SetEulerRotationX(value);
			break;
		case 4:
			transform.SetEulerRotationY(value);
			break;
		case 5:
			transform.SetEulerRotationZ(value);
			break;
		case 6:
			transform.SetLocalScaleX(value);
			break;
		case 7:
			transform.SetLocalScaleY(value);
			break;
		case 8:
			transform.SetLocalScaleZ(value);
			break;
		}
	}
}
