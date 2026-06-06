using System;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
	[SerializeField]
	private float maxSpeed = 36f;

	private Vector3 rotationRandomValues;

	private Vector3 rotationVelocity;

	private Vector3 rotationPosition;

	private void Start()
	{
		rotationRandomValues = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f));
	}

	private void FixedUpdate()
	{
		rotationVelocity = maxSpeed * new Vector3(Mathf.Sin(Time.time * (float)Math.PI * rotationRandomValues.x), Mathf.Sin(Time.time * (float)Math.PI * rotationRandomValues.y), Mathf.Sin(Time.time * (float)Math.PI * rotationRandomValues.z));
		rotationPosition += rotationVelocity * Time.fixedDeltaTime;
		base.transform.rotation = Quaternion.Euler(rotationPosition);
	}
}
