using System;
using UnityEngine;

[Serializable]
public class SnapPointPositionData
{
	public Transform transform;

	public SnapperRotationType rotationType;

	public GrabbableType suitableGrabbableType;

	public Vector3 bounds;

	public Vector3 meshCenter;
}
