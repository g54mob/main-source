using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public delegate void OnControlChange();

	public static InputController inputActions;

	private InputDevice device;

	public static OnControlChange onControlChange;

	private Action<InputAction.CallbackContext> checkControlsAction;

	public static event Action rebindComplete
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action rebindCanceled
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action<InputAction, int> rebindStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	public static void LoadAllBindingOverrides()
	{
	}

	private void OnDestroy()
	{
	}

	public static void ConfinedCursorforUI()
	{
	}

	public static void LockedCursorForPlayerMovement()
	{
	}

	public static void StartRebind(string actionName, int bindingIndex, TextMeshProUGUI statusText, bool excludeMouse)
	{
	}

	private static void DoRebind(InputAction actionToRebind, int bindingIndex, TextMeshProUGUI statusText, bool allCompositeParts, bool excludeMouse)
	{
	}

	public static string GetBindingName(string actionName, int bindingIndex)
	{
		return null;
	}

	private static void SaveBindingOverride(InputAction action)
	{
	}

	public static void LoadBindingOverride(string actionName)
	{
	}

	public static void ResetBinding(string actionName, int bindingIndex)
	{
	}

	public static void ForceMousePositionToCenterOfGameWindow()
	{
	}

	private void CheckCurrentControls(InputAction.CallbackContext ctx)
	{
	}
}
