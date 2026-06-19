using System;
using UnityEngine;

[Serializable]
public class WinchCable
{
	public string name = "Cable";

	public Transform winchAnchor;

	public Transform planeAttachPoint;

	[HideInInspector]
	public bool attached = true;

	public float restLength = 5f;

	public float minLength = 0.5f;

	public float maxLength = 30f;

	public float stiffness = 800f;

	public float damping = 80f;

	public float maxTension = 10000f;

	public LineRenderer lineRenderer;
}
