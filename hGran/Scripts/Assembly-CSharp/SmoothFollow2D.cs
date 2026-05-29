using System;
using UnityEngine;

[Serializable]
public class SmoothFollow2D : MonoBehaviour
{
	public Transform target;

	public float smoothTime;

	private Transform thisTransform;

	private Vector2 velocity;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
