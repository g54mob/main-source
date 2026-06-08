using System;
using UnityEngine;

public class SineRotation : MonoBehaviour
{
	public enum Axis
	{
		none = 0,
		x = 1,
		y = 2,
		z = 3
	}

	public Axis axis1 = Axis.x;

	public Axis axis2 = Axis.z;

	public float amplitude1 = 0.5f;

	public float amplitude2 = 0.5f;

	public float rotationPerSecond = 1f;

	public float phase1;

	public float phase2;

	private void Update()
	{
		Quaternion localRotation = base.transform.localRotation;
		if (axis1 != Axis.none)
		{
			phase1 += (float)Math.PI * 2f * rotationPerSecond * Time.deltaTime;
			float num = Mathf.Sin(phase1) * amplitude1;
			if (axis1 == Axis.x)
			{
				localRotation.x = num;
			}
			else if (axis1 == Axis.y)
			{
				localRotation.y = num;
			}
			else if (axis1 == Axis.z)
			{
				localRotation.z = num;
			}
		}
		if (axis2 != Axis.none)
		{
			phase2 += (float)Math.PI * 2f * rotationPerSecond * Time.deltaTime;
			float num2 = Mathf.Cos(phase2) * amplitude2;
			if (axis2 == Axis.x)
			{
				localRotation.x = num2;
			}
			else if (axis2 == Axis.y)
			{
				localRotation.y = num2;
			}
			else if (axis2 == Axis.z)
			{
				localRotation.z = num2;
			}
		}
		base.transform.localRotation = localRotation;
	}
}
