using System;
using UnityEngine;

[Serializable]
public class VisualPrefabPersistentData
{
	public int PrefabIndex;

	public Quaternion Rotation;

	public VisualPrefabPersistentData(VisualPrefab visualPrefab)
	{
		Rotation = visualPrefab.transform.rotation;
	}
}
