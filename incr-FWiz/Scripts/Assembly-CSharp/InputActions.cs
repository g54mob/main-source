using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct GameActions
	{
		private InputActions m_Wrapper;

		public InputAction MovePointer => null;

		public InputAction Press => null;

		public InputAction Pickup => null;

		public InputAction Drop => null;

		public InputAction Move => null;

		public InputAction Scroll => null;

		public InputAction Build => null;

		public InputAction Deconstruct => null;

		public InputAction Escape => null;

		public InputAction Sprint => null;

		public InputAction ScrollUp => null;

		public InputAction ScrollDown => null;

		public InputAction Pipelines => null;

		public InputAction ItemBook => null;

		public InputAction CursorMove => null;

		public bool enabled => false;

		public GameActions(InputActions wrapper)
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

		public static implicit operator InputActionMap(GameActions set)
		{
			return null;
		}

		public void AddCallbacks(IGameActions instance)
		{
		}

		private void UnregisterCallbacks(IGameActions instance)
		{
		}

		public void RemoveCallbacks(IGameActions instance)
		{
		}

		public void SetCallbacks(IGameActions instance)
		{
		}
	}

	public struct UIActions
	{
		private InputActions m_Wrapper;

		public InputAction Navigate => null;

		public InputAction Submit => null;

		public InputAction Cancel => null;

		public InputAction Point => null;

		public InputAction Click => null;

		public InputAction RightClick => null;

		public InputAction MiddleClick => null;

		public InputAction ScrollWheel => null;

		public InputAction TrackedDevicePosition => null;

		public InputAction TrackedDeviceOrientation => null;

		public bool enabled => false;

		public UIActions(InputActions wrapper)
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

	public interface IGameActions
	{
		void OnMovePointer(InputAction.CallbackContext context);

		void OnPress(InputAction.CallbackContext context);

		void OnPickup(InputAction.CallbackContext context);

		void OnDrop(InputAction.CallbackContext context);

		void OnMove(InputAction.CallbackContext context);

		void OnScroll(InputAction.CallbackContext context);

		void OnBuild(InputAction.CallbackContext context);

		void OnDeconstruct(InputAction.CallbackContext context);

		void OnEscape(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnScrollUp(InputAction.CallbackContext context);

		void OnScrollDown(InputAction.CallbackContext context);

		void OnPipelines(InputAction.CallbackContext context);

		void OnItemBook(InputAction.CallbackContext context);

		void OnCursorMove(InputAction.CallbackContext context);
	}

	public interface IUIActions
	{
		void OnNavigate(InputAction.CallbackContext context);

		void OnSubmit(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnPoint(InputAction.CallbackContext context);

		void OnClick(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnMiddleClick(InputAction.CallbackContext context);

		void OnScrollWheel(InputAction.CallbackContext context);

		void OnTrackedDevicePosition(InputAction.CallbackContext context);

		void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Game;

	private List<IGameActions> m_GameActionsCallbackInterfaces;

	private readonly InputAction m_Game_MovePointer;

	private readonly InputAction m_Game_Press;

	private readonly InputAction m_Game_Pickup;

	private readonly InputAction m_Game_Drop;

	private readonly InputAction m_Game_Move;

	private readonly InputAction m_Game_Scroll;

	private readonly InputAction m_Game_Build;

	private readonly InputAction m_Game_Deconstruct;

	private readonly InputAction m_Game_Escape;

	private readonly InputAction m_Game_Sprint;

	private readonly InputAction m_Game_ScrollUp;

	private readonly InputAction m_Game_ScrollDown;

	private readonly InputAction m_Game_Pipelines;

	private readonly InputAction m_Game_ItemBook;

	private readonly InputAction m_Game_CursorMove;

	private readonly InputActionMap m_UI;

	private List<IUIActions> m_UIActionsCallbackInterfaces;

	private readonly InputAction m_UI_Navigate;

	private readonly InputAction m_UI_Submit;

	private readonly InputAction m_UI_Cancel;

	private readonly InputAction m_UI_Point;

	private readonly InputAction m_UI_Click;

	private readonly InputAction m_UI_RightClick;

	private readonly InputAction m_UI_MiddleClick;

	private readonly InputAction m_UI_ScrollWheel;

	private readonly InputAction m_UI_TrackedDevicePosition;

	private readonly InputAction m_UI_TrackedDeviceOrientation;

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

	public GameActions Game => default(GameActions);

	public UIActions UI => default(UIActions);

	public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

	public InputControlScheme GamepadScheme => default(InputControlScheme);

	public InputControlScheme TouchScheme => default(InputControlScheme);

	public InputControlScheme JoystickScheme => default(InputControlScheme);

	public InputControlScheme XRScheme => default(InputControlScheme);

	~InputActions()
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
