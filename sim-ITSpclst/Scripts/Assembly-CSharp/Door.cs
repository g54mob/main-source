using System;
using UnityEngine;

[Serializable]
public class Door
{
	public string name;

	public Transform pivot;

	public DoorPivot hingeSide;

	[HideInInspector]
	public Quaternion closedRotation;

	[HideInInspector]
	public Quaternion openRotation;

	[HideInInspector]
	public Quaternion targetRotation;

	[HideInInspector]
	public bool anim;
}
