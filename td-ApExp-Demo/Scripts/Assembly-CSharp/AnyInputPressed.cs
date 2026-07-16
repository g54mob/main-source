using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class AnyInputPressed : MonoBehaviour
{
	public event Action onAnyInputPressed;

	private void Update()
	{
		if (Keyboard.current.anyKey.wasPressedThisFrame)
		{
			this.onAnyInputPressed?.Invoke();
		}
		if (Gamepad.current != null && AnyGamepadButtonPressed())
		{
			this.onAnyInputPressed?.Invoke();
		}
	}

	private bool AnyGamepadButtonPressed()
	{
		foreach (InputControl allControl in Gamepad.current.allControls)
		{
			if (allControl is ButtonControl { wasPressedThisFrame: not false })
			{
				return true;
			}
		}
		return false;
	}
}
