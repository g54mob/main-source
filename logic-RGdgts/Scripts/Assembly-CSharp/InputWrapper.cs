using System;
using UnityEngine;

public class InputWrapper
{
	private Func<bool> isActive;

	public InputWrapper(Func<bool> isActive)
	{
	}

	public bool GetButton(RewiredEnum action)
	{
		return false;
	}

	public bool GetButtonDown(RewiredEnum action)
	{
		return false;
	}

	public bool GetButtonUp(RewiredEnum action)
	{
		return false;
	}

	public float GetAxis(RewiredEnum action)
	{
		return 0f;
	}

	public Vector2 GetAxis2D(RewiredEnum actionX, RewiredEnum actionY)
	{
		return default(Vector2);
	}
}
