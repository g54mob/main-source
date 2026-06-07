using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActions
	{
		private Controls m_Wrapper;

		public InputAction Jump => null;

		public InputAction Move => null;

		public InputAction Look => null;

		public InputAction Sprint => null;

		public InputAction ToggleWalk => null;

		public InputAction Aim => null;

		public InputAction Crouch => null;

		public InputAction LockOn => null;

		public bool enabled => false;

		public PlayerActions(Controls wrapper)
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

		public static implicit operator InputActionMap(PlayerActions set)
		{
			return null;
		}

		public void AddCallbacks(IPlayerActions instance)
		{
		}

		private void UnregisterCallbacks(IPlayerActions instance)
		{
		}

		public void RemoveCallbacks(IPlayerActions instance)
		{
		}

		public void SetCallbacks(IPlayerActions instance)
		{
		}
	}

	public interface IPlayerActions
	{
		void OnJump(InputAction.CallbackContext context);

		void OnMove(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnToggleWalk(InputAction.CallbackContext context);

		void OnAim(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);

		void OnLockOn(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Player;

	private List<IPlayerActions> m_PlayerActionsCallbackInterfaces;

	private readonly InputAction m_Player_Jump;

	private readonly InputAction m_Player_Move;

	private readonly InputAction m_Player_Look;

	private readonly InputAction m_Player_Sprint;

	private readonly InputAction m_Player_ToggleWalk;

	private readonly InputAction m_Player_Aim;

	private readonly InputAction m_Player_Crouch;

	private readonly InputAction m_Player_LockOn;

	private int m_KeyboardandMouseSchemeIndex;

	private int m_GamepadSchemeIndex;

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

	public PlayerActions Player => default(PlayerActions);

	public InputControlScheme KeyboardandMouseScheme => default(InputControlScheme);

	public InputControlScheme GamepadScheme => default(InputControlScheme);

	~Controls()
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
