using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class DevInputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct ConsoleActions
	{
		private DevInputActions m_Wrapper;

		public InputAction ToggleConsole => null;

		public InputAction NavigateCommandHistory => null;

		public bool enabled => false;

		public ConsoleActions(DevInputActions wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap Get()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public static implicit operator InputActionMap(ConsoleActions set)
		{
			return null;
		}

		public void AddCallbacks(IConsoleActions instance)
		{
		}

		private void UnregisterCallbacks(IConsoleActions instance)
		{
		}

		public void RemoveCallbacks(IConsoleActions instance)
		{
		}

		public void SetCallbacks(IConsoleActions instance)
		{
		}
	}

	public interface IConsoleActions
	{
		void OnToggleConsole(InputAction.CallbackContext context);

		void OnNavigateCommandHistory(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Console;

	private List<IConsoleActions> m_ConsoleActionsCallbackInterfaces;

	private readonly InputAction m_Console_ToggleConsole;

	private readonly InputAction m_Console_NavigateCommandHistory;

	private int m_KeyboardMouseSchemeIndex;

	private int m_GamepadSchemeIndex;

	private int m_TouchSchemeIndex;

	private int m_JoystickSchemeIndex;

	private int m_XRSchemeIndex;

	public InputActionAsset asset { get; }

	public InputBinding? bindingMask
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => default(ReadOnlyArray<InputControlScheme>);

	public IEnumerable<InputBinding> bindings => null;

	public ConsoleActions Console => default(ConsoleActions);

	public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

	public InputControlScheme GamepadScheme => default(InputControlScheme);

	public InputControlScheme TouchScheme => default(InputControlScheme);

	public InputControlScheme JoystickScheme => default(InputControlScheme);

	public InputControlScheme XRScheme => default(InputControlScheme);

	~DevInputActions()
	{
	}

	public void Dispose()
	{
	}

	public bool Contains(InputAction action)
	{
		return false;
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return null;
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		action = null;
		return 0;
	}
}
