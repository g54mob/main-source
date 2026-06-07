using System;
using UnityEngine;

[Serializable]
public class BuildingRecorderObjectData
{
	public enum EAction
	{
		Add = 0,
		Remove = 1
	}

	public GameplayObjectData objectData;

	public Vector3 objectPosition;

	public Quaternion objectRotation;

	public EAction action;
}
