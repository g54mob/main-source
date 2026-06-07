using System;
using UnityEngine;

[Serializable]
public class ModItemSaveData
{
	public string modFolderName;

	public Vector3 position;

	public Quaternion rotation;

	public float[] saveValue;

	public int[] saveIntArray;

	public int[] saveIntArray2;
}
