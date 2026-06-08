using System;
using UnityEngine;

[Serializable]
public class Rotate : MonoBehaviour
{
	public Vector3 degreesPerSecond;

	public Rotate()
	{
		degreesPerSecond = new Vector3(1f, 0f, 0f);
	}

	public virtual void FixedUpdate()
	{
		transform.Rotate(degreesPerSecond.x * Time.deltaTime, degreesPerSecond.y * Time.deltaTime, degreesPerSecond.z * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
