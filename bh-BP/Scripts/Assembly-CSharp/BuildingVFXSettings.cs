using System;
using UnityEngine;

[Serializable]
public class BuildingVFXSettings
{
	public bool EnableInPreviewMode;

	public Transform Wrapper;

	public bool[] IsActive;

	public Vector3[] Position;
}
