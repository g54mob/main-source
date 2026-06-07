using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Rigidbody))]
public class RollABall : MonoBehaviour
{
	public Vector3 tilt;

	public float speed;

	private float circ;

	private Vector3 previousPosition;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void LateUpdate()
	{
	}
}
