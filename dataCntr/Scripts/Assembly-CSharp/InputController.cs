using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputController : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActions
	{
		private InputController m_Wrapper;

		public InputAction Move => null;

		public InputAction Look => null;

		public InputAction Interact => null;

		public InputAction SecondAction => null;

		public InputAction Jump => null;

		public InputAction Sprint => null;

		public InputAction CloseMenu => null;

		public InputAction LookPosition => null;

		public InputAction Drop => null;

		public InputAction Crouch => null;

		public InputAction Scroll => null;

		public InputAction Zoom => null;

		public bool enabled => false;

		public PlayerActions(InputController wrapper)
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

	public struct UIActions
	{
		private InputController m_Wrapper;

		public InputAction Navigate => null;

		public InputAction Submit => null;

		public InputAction Cancel => null;

		public InputAction Point => null;

		public InputAction Click => null;

		public InputAction ScrollWheel => null;

		public InputAction MiddleClick => null;

		public InputAction RightClick => null;

		public InputAction WaitForPressKey => null;

		public InputAction Pause => null;

		public InputAction Inventory => null;

		public InputAction Map => null;

		public InputAction TimeControl => null;

		public InputAction Console => null;

		public InputAction ConsoleSubmit => null;

		public bool enabled => false;

		public UIActions(InputController wrapper)
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

		public static implicit operator InputActionMap(UIActions set)
		{
			return null;
		}

		public void AddCallbacks(IUIActions instance)
		{
		}

		private void UnregisterCallbacks(IUIActions instance)
		{
		}

		public void RemoveCallbacks(IUIActions instance)
		{
		}

		public void SetCallbacks(IUIActions instance)
		{
		}
	}

	public interface IPlayerActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);

		void OnSecondAction(InputAction.CallbackContext context);

		void OnJump(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnCloseMenu(InputAction.CallbackContext context);

		void OnLookPosition(InputAction.CallbackContext context);

		void OnDrop(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);

		void OnScroll(InputAction.CallbackContext context);

		void OnZoom(InputAction.CallbackContext context);
	}

	public interface IUIActions
	{
		void OnNavigate(InputAction.CallbackContext context);

		void OnSubmit(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnPoint(InputAction.CallbackContext context);

		void OnClick(InputAction.CallbackContext context);

		void OnScrollWheel(InputAction.CallbackContext context);

		void OnMiddleClick(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnWaitForPressKey(InputAction.CallbackContext context);

		void OnPause(InputAction.CallbackContext context);

		void OnInventory(InputAction.CallbackContext context);

		void OnMap(InputAction.CallbackContext context);

		void OnTimeControl(InputAction.CallbackContext context);

		void OnConsole(InputAction.CallbackContext context);

		void OnConsoleSubmit(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Player;

	private List<IPlayerActions> m_PlayerActionsCallbackInterfaces;

	private readonly InputAction m_Player_Move;

	private readonly InputAction m_Player_Look;

	private readonly InputAction m_Player_Interact;

	private readonly InputAction m_Player_SecondAction;

	private readonly InputAction m_Player_Jump;

	private readonly InputAction m_Player_Sprint;

	private readonly InputAction m_Player_CloseMenu;

	private readonly InputAction m_Player_LookPosition;

	private readonly InputAction m_Player_Drop;

	private readonly InputAction m_Player_Crouch;

	private readonly InputAction m_Player_Scroll;

	private readonly InputAction m_Player_Zoom;

	private readonly InputActionMap m_UI;

	private List<IUIActions> m_UIActionsCallbackInterfaces;

	private readonly InputAction m_UI_Navigate;

	private readonly InputAction m_UI_Submit;

	private readonly InputAction m_UI_Cancel;

	private readonly InputAction m_UI_Point;

	private readonly InputAction m_UI_Click;

	private readonly InputAction m_UI_ScrollWheel;

	private readonly InputAction m_UI_MiddleClick;

	private readonly InputAction m_UI_RightClick;

	private readonly InputAction m_UI_WaitForPressKey;

	private readonly InputAction m_UI_Pause;

	private readonly InputAction m_UI_Inventory;

	private readonly InputAction m_UI_Map;

	private readonly InputAction m_UI_TimeControl;

	private readonly InputAction m_UI_Console;

	private readonly InputAction m_UI_ConsoleSubmit;

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

	public PlayerActions Player => default(PlayerActions);

	public UIActions UI => default(UIActions);

	public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

	public InputControlScheme GamepadScheme => default(InputControlScheme);

	public InputControlScheme TouchScheme => default(InputControlScheme);

	public InputControlScheme JoystickScheme => default(InputControlScheme);

	public InputControlScheme XRScheme => default(InputControlScheme);

	~InputController()
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
