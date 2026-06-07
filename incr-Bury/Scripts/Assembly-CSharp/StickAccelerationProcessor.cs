using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class StickAccelerationProcessor : InputProcessor<Vector2>
{
	public float power = 2f;

	public override Vector2 Process(Vector2 value, InputControl control)
	{
		float magnitude = value.magnitude;
		if (magnitude <= 0f)
		{
			return Vector2.zero;
		}
		float num = Mathf.Pow(magnitude, power);
		return value.normalized * num;
	}
}
