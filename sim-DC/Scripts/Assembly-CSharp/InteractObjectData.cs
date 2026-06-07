using System;
using UnityEngine;

[Serializable]
public class InteractObjectData
{
	public int uid;

	public float[] value;

	public int[] saveIntArray;

	public int[] saveIntArray2;

	public Vector3 position;

	public Quaternion rotation;

	public InteractObjectData(Interact _interactObject)
	{
	}
}
