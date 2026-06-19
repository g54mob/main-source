using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public static class DevInputManager
{
	public static DevInputActions Controls;

	private static short _disableStack;

	public static event Action AnnounceToggleConsole
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

	public static event Action<int> AnnounceNavigateCommandHistory
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

	public static void AddDisableStack()
	{
	}

	public static void RemoveDisableStack()
	{
	}

	private static void InitControls()
	{
	}

	[RuntimeInitializeOnLoadMethod]
	private static void Start()
	{
	}

	public static void Setup()
	{
	}

	private static void OnToggleConsole(InputAction.CallbackContext context)
	{
	}

	private static void OnNavigateCommandHistory(InputAction.CallbackContext context)
	{
	}
}
