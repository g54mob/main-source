using RLD;
using UnityEngine;

public class HandToolPositionChangedAction : IUndoRedoAction
{
	private Transform transform;

	private Vector3 originalPosition;

	private Quaternion originalRotation;

	private Vector3 newPosition;

	private Quaternion newRotation;

	public HandToolPositionChangedAction(Transform transform, Vector3 prePos, Quaternion preRot, Vector3 posPos, Quaternion posRot)
	{
		this.transform = transform;
		originalPosition = prePos;
		originalRotation = preRot;
		newPosition = posPos;
		newRotation = posRot;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (!(transform == null))
		{
			transform.position = originalPosition;
			transform.rotation = originalRotation;
		}
	}

	public void Redo()
	{
		if (!(transform == null))
		{
			transform.position = newPosition;
			transform.rotation = newRotation;
		}
	}

	public void OnRemovedFromUndoRedoStack()
	{
	}
}
