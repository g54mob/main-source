using System;
using UnityEngine;

[Serializable]
public class JointRemapMap
{
	public GameObject refObject;

	public GameObject remapTarget;

	public bool forceAssignOriginalPos;

	public bool autoConfigureConnectedAnchor;

	[HideInInspector]
	public Vector3 positionalOffset;
}
