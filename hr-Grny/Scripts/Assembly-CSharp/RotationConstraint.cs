using System;
using UnityEngine;

[Serializable]
public class RotationConstraint : MonoBehaviour
{
	public ConstraintAxis axis;

	public float min;

	public float max;

	private Transform thisTransform;

	private Vector3 rotateAround;

	private Quaternion minQuaternion;

	private Quaternion maxQuaternion;

	private float range;

	public virtual void Start()
	{
	}

	public virtual void LateUpdate()
	{
	}
}
