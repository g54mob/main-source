using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActionController : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct GlobalActions
	{
		private InputActionController m_Wrapper;

		public InputAction ESC => null;

		public InputAction Reset => null;

		public InputAction MousePosition => null;

		public InputAction MouseScroll => null;

		public InputAction MouseLeftClick => null;

		public InputAction MouseRightClick => null;

		public InputAction DisplayPalletNext => null;

		public InputAction DisplayPalletPrev => null;

		public InputAction DisplayHoldMenu => null;

		public InputAction DisplayOpenInventory => null;

		public InputAction SystemLeftClick => null;

		public bool enabled => false;

		public GlobalActions(InputActionController wrapper)
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

		public static implicit operator InputActionMap(GlobalActions set)
		{
			return null;
		}

		public void AddCallbacks(IGlobalActions instance)
		{
		}

		private void UnregisterCallbacks(IGlobalActions instance)
		{
		}

		public void RemoveCallbacks(IGlobalActions instance)
		{
		}

		public void SetCallbacks(IGlobalActions instance)
		{
		}
	}

	public struct InGameActions
	{
		private InputActionController m_Wrapper;

		public InputAction CameraScroll => null;

		public InputAction CameraMode => null;

		public InputAction RulerMode => null;

		public InputAction Spuit => null;

		public InputAction Rotate => null;

		public InputAction CounterRotate => null;

		public InputAction LongThinkMode => null;

		public InputAction Pause => null;

		public InputAction ShowGuide => null;

		public InputAction SwitchToggle => null;

		public InputAction EnterTips => null;

		public InputAction ModeCancel => null;

		public InputAction CameraMoveUp => null;

		public InputAction CameraMoveUpByStick => null;

		public InputAction CameraMoveLeft => null;

		public InputAction CameraMoveLeftByStick => null;

		public InputAction CameraMoveDown => null;

		public InputAction CameraMoveDownByStick => null;

		public InputAction CameraMoveRight => null;

		public InputAction CameraMoveRightByStick => null;

		public InputAction CameraMoveLStick => null;

		public InputAction OpenResearchTree => null;

		public InputAction SwitchScene => null;

		public InputAction ChangeSpeed => null;

		public InputAction OpenCollection => null;

		public InputAction OpenInvasionRoute => null;

		public InputAction OpenHeroTree => null;

		public InputAction ChangeCamera => null;

		public InputAction OpenMapExtendViewer => null;

		public InputAction PaletteNext => null;

		public InputAction PaletteNext2 => null;

		public InputAction PalettePrev => null;

		public InputAction PalettePrev2 => null;

		public InputAction OpenInventory => null;

		public InputAction OpenSetting => null;

		public bool enabled => false;

		public InGameActions(InputActionController wrapper)
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

		public static implicit operator InputActionMap(InGameActions set)
		{
			return null;
		}

		public void AddCallbacks(IInGameActions instance)
		{
		}

		private void UnregisterCallbacks(IInGameActions instance)
		{
		}

		public void RemoveCallbacks(IInGameActions instance)
		{
		}

		public void SetCallbacks(IInGameActions instance)
		{
		}
	}

	public struct DebugActions
	{
		private InputActionController m_Wrapper;

		public InputAction DumpAllRoute => null;

		public bool enabled => false;

		public DebugActions(InputActionController wrapper)
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

		public static implicit operator InputActionMap(DebugActions set)
		{
			return null;
		}

		public void AddCallbacks(IDebugActions instance)
		{
		}

		private void UnregisterCallbacks(IDebugActions instance)
		{
		}

		public void RemoveCallbacks(IDebugActions instance)
		{
		}

		public void SetCallbacks(IDebugActions instance)
		{
		}
	}

	public struct PaletteActions
	{
		private InputActionController m_Wrapper;

		public InputAction SelectCategory_1 => null;

		public InputAction SelectCategory_2 => null;

		public InputAction SelectCategory_3 => null;

		public InputAction SelectCategory_4 => null;

		public InputAction SelectCategory_5 => null;

		public InputAction SelectCategory_6 => null;

		public InputAction SelectCategory_7 => null;

		public InputAction SelectCategory_8 => null;

		public InputAction SelectCategory_9 => null;

		public InputAction SelectCategory_10 => null;

		public InputAction SelectCategory_11 => null;

		public InputAction SelectCategory_12 => null;

		public InputAction SelectItem_1 => null;

		public InputAction SelectItem_2 => null;

		public InputAction SelectItem_3 => null;

		public InputAction SelectItem_4 => null;

		public InputAction SelectItem_5 => null;

		public InputAction SelectItem_6 => null;

		public InputAction SelectItem_7 => null;

		public InputAction SelectItem_8 => null;

		public InputAction SelectItem_9 => null;

		public InputAction SelectItem_10 => null;

		public bool enabled => false;

		public PaletteActions(InputActionController wrapper)
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

		public static implicit operator InputActionMap(PaletteActions set)
		{
			return null;
		}

		public void AddCallbacks(IPaletteActions instance)
		{
		}

		private void UnregisterCallbacks(IPaletteActions instance)
		{
		}

		public void RemoveCallbacks(IPaletteActions instance)
		{
		}

		public void SetCallbacks(IPaletteActions instance)
		{
		}
	}

	public struct UIControlActions
	{
		private InputActionController m_Wrapper;

		public InputAction Switch => null;

		public InputAction LeftTrigger => null;

		public InputAction RightTrigger => null;

		public InputAction Cancel => null;

		public InputAction Decide => null;

		public InputAction Down => null;

		public InputAction Up => null;

		public InputAction Right => null;

		public InputAction Left => null;

		public InputAction Select => null;

		public InputAction LeftShoulder => null;

		public InputAction RightShoulder => null;

		public InputAction SubMenu => null;

		public InputAction Start => null;

		public InputAction RightStickPush => null;

		public bool enabled => false;

		public UIControlActions(InputActionController wrapper)
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

		public static implicit operator InputActionMap(UIControlActions set)
		{
			return null;
		}

		public void AddCallbacks(IUIControlActions instance)
		{
		}

		private void UnregisterCallbacks(IUIControlActions instance)
		{
		}

		public void RemoveCallbacks(IUIControlActions instance)
		{
		}

		public void SetCallbacks(IUIControlActions instance)
		{
		}
	}

	public struct MovieActions
	{
		private InputActionController m_Wrapper;

		public InputAction PressAnyKey => null;

		public InputAction SkipWithSpace => null;

		public InputAction SplashSkip => null;

		public bool enabled => false;

		public MovieActions(InputActionController wrapper)
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

		public static implicit operator InputActionMap(MovieActions set)
		{
			return null;
		}

		public void AddCallbacks(IMovieActions instance)
		{
		}

		private void UnregisterCallbacks(IMovieActions instance)
		{
		}

		public void RemoveCallbacks(IMovieActions instance)
		{
		}

		public void SetCallbacks(IMovieActions instance)
		{
		}
	}

	public interface IGlobalActions
	{
		void OnESC(InputAction.CallbackContext context);

		void OnReset(InputAction.CallbackContext context);

		void OnMousePosition(InputAction.CallbackContext context);

		void OnMouseScroll(InputAction.CallbackContext context);

		void OnMouseLeftClick(InputAction.CallbackContext context);

		void OnMouseRightClick(InputAction.CallbackContext context);

		void OnDisplayPalletNext(InputAction.CallbackContext context);

		void OnDisplayPalletPrev(InputAction.CallbackContext context);

		void OnDisplayHoldMenu(InputAction.CallbackContext context);

		void OnDisplayOpenInventory(InputAction.CallbackContext context);

		void OnSystemLeftClick(InputAction.CallbackContext context);
	}

	public interface IInGameActions
	{
		void OnCameraScroll(InputAction.CallbackContext context);

		void OnCameraMode(InputAction.CallbackContext context);

		void OnRulerMode(InputAction.CallbackContext context);

		void OnSpuit(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnCounterRotate(InputAction.CallbackContext context);

		void OnLongThinkMode(InputAction.CallbackContext context);

		void OnPause(InputAction.CallbackContext context);

		void OnShowGuide(InputAction.CallbackContext context);

		void OnSwitchToggle(InputAction.CallbackContext context);

		void OnEnterTips(InputAction.CallbackContext context);

		void OnModeCancel(InputAction.CallbackContext context);

		void OnCameraMoveUp(InputAction.CallbackContext context);

		void OnCameraMoveUpByStick(InputAction.CallbackContext context);

		void OnCameraMoveLeft(InputAction.CallbackContext context);

		void OnCameraMoveLeftByStick(InputAction.CallbackContext context);

		void OnCameraMoveDown(InputAction.CallbackContext context);

		void OnCameraMoveDownByStick(InputAction.CallbackContext context);

		void OnCameraMoveRight(InputAction.CallbackContext context);

		void OnCameraMoveRightByStick(InputAction.CallbackContext context);

		void OnCameraMoveLStick(InputAction.CallbackContext context);

		void OnOpenResearchTree(InputAction.CallbackContext context);

		void OnSwitchScene(InputAction.CallbackContext context);

		void OnChangeSpeed(InputAction.CallbackContext context);

		void OnOpenCollection(InputAction.CallbackContext context);

		void OnOpenInvasionRoute(InputAction.CallbackContext context);

		void OnOpenHeroTree(InputAction.CallbackContext context);

		void OnChangeCamera(InputAction.CallbackContext context);

		void OnOpenMapExtendViewer(InputAction.CallbackContext context);

		void OnPaletteNext(InputAction.CallbackContext context);

		void OnPaletteNext2(InputAction.CallbackContext context);

		void OnPalettePrev(InputAction.CallbackContext context);

		void OnPalettePrev2(InputAction.CallbackContext context);

		void OnOpenInventory(InputAction.CallbackContext context);

		void OnOpenSetting(InputAction.CallbackContext context);
	}

	public interface IDebugActions
	{
		void OnDumpAllRoute(InputAction.CallbackContext context);
	}

	public interface IPaletteActions
	{
		void OnSelectCategory_1(InputAction.CallbackContext context);

		void OnSelectCategory_2(InputAction.CallbackContext context);

		void OnSelectCategory_3(InputAction.CallbackContext context);

		void OnSelectCategory_4(InputAction.CallbackContext context);

		void OnSelectCategory_5(InputAction.CallbackContext context);

		void OnSelectCategory_6(InputAction.CallbackContext context);

		void OnSelectCategory_7(InputAction.CallbackContext context);

		void OnSelectCategory_8(InputAction.CallbackContext context);

		void OnSelectCategory_9(InputAction.CallbackContext context);

		void OnSelectCategory_10(InputAction.CallbackContext context);

		void OnSelectCategory_11(InputAction.CallbackContext context);

		void OnSelectCategory_12(InputAction.CallbackContext context);

		void OnSelectItem_1(InputAction.CallbackContext context);

		void OnSelectItem_2(InputAction.CallbackContext context);

		void OnSelectItem_3(InputAction.CallbackContext context);

		void OnSelectItem_4(InputAction.CallbackContext context);

		void OnSelectItem_5(InputAction.CallbackContext context);

		void OnSelectItem_6(InputAction.CallbackContext context);

		void OnSelectItem_7(InputAction.CallbackContext context);

		void OnSelectItem_8(InputAction.CallbackContext context);

		void OnSelectItem_9(InputAction.CallbackContext context);

		void OnSelectItem_10(InputAction.CallbackContext context);
	}

	public interface IUIControlActions
	{
		void OnSwitch(InputAction.CallbackContext context);

		void OnLeftTrigger(InputAction.CallbackContext context);

		void OnRightTrigger(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnDecide(InputAction.CallbackContext context);

		void OnDown(InputAction.CallbackContext context);

		void OnUp(InputAction.CallbackContext context);

		void OnRight(InputAction.CallbackContext context);

		void OnLeft(InputAction.CallbackContext context);

		void OnSelect(InputAction.CallbackContext context);

		void OnLeftShoulder(InputAction.CallbackContext context);

		void OnRightShoulder(InputAction.CallbackContext context);

		void OnSubMenu(InputAction.CallbackContext context);

		void OnStart(InputAction.CallbackContext context);

		void OnRightStickPush(InputAction.CallbackContext context);
	}

	public interface IMovieActions
	{
		void OnPressAnyKey(InputAction.CallbackContext context);

		void OnSkipWithSpace(InputAction.CallbackContext context);

		void OnSplashSkip(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Global;

	private List<IGlobalActions> m_GlobalActionsCallbackInterfaces;

	private readonly InputAction m_Global_ESC;

	private readonly InputAction m_Global_Reset;

	private readonly InputAction m_Global_MousePosition;

	private readonly InputAction m_Global_MouseScroll;

	private readonly InputAction m_Global_MouseLeftClick;

	private readonly InputAction m_Global_MouseRightClick;

	private readonly InputAction m_Global_DisplayPalletNext;

	private readonly InputAction m_Global_DisplayPalletPrev;

	private readonly InputAction m_Global_DisplayHoldMenu;

	private readonly InputAction m_Global_DisplayOpenInventory;

	private readonly InputAction m_Global_SystemLeftClick;

	private readonly InputActionMap m_InGame;

	private List<IInGameActions> m_InGameActionsCallbackInterfaces;

	private readonly InputAction m_InGame_CameraScroll;

	private readonly InputAction m_InGame_CameraMode;

	private readonly InputAction m_InGame_RulerMode;

	private readonly InputAction m_InGame_Spuit;

	private readonly InputAction m_InGame_Rotate;

	private readonly InputAction m_InGame_CounterRotate;

	private readonly InputAction m_InGame_LongThinkMode;

	private readonly InputAction m_InGame_Pause;

	private readonly InputAction m_InGame_ShowGuide;

	private readonly InputAction m_InGame_SwitchToggle;

	private readonly InputAction m_InGame_EnterTips;

	private readonly InputAction m_InGame_ModeCancel;

	private readonly InputAction m_InGame_CameraMoveUp;

	private readonly InputAction m_InGame_CameraMoveUpByStick;

	private readonly InputAction m_InGame_CameraMoveLeft;

	private readonly InputAction m_InGame_CameraMoveLeftByStick;

	private readonly InputAction m_InGame_CameraMoveDown;

	private readonly InputAction m_InGame_CameraMoveDownByStick;

	private readonly InputAction m_InGame_CameraMoveRight;

	private readonly InputAction m_InGame_CameraMoveRightByStick;

	private readonly InputAction m_InGame_CameraMoveLStick;

	private readonly InputAction m_InGame_OpenResearchTree;

	private readonly InputAction m_InGame_SwitchScene;

	private readonly InputAction m_InGame_ChangeSpeed;

	private readonly InputAction m_InGame_OpenCollection;

	private readonly InputAction m_InGame_OpenInvasionRoute;

	private readonly InputAction m_InGame_OpenHeroTree;

	private readonly InputAction m_InGame_ChangeCamera;

	private readonly InputAction m_InGame_OpenMapExtendViewer;

	private readonly InputAction m_InGame_PaletteNext;

	private readonly InputAction m_InGame_PaletteNext2;

	private readonly InputAction m_InGame_PalettePrev;

	private readonly InputAction m_InGame_PalettePrev2;

	private readonly InputAction m_InGame_OpenInventory;

	private readonly InputAction m_InGame_OpenSetting;

	private readonly InputActionMap m_Debug;

	private List<IDebugActions> m_DebugActionsCallbackInterfaces;

	private readonly InputAction m_Debug_DumpAllRoute;

	private readonly InputActionMap m_Palette;

	private List<IPaletteActions> m_PaletteActionsCallbackInterfaces;

	private readonly InputAction m_Palette_SelectCategory_1;

	private readonly InputAction m_Palette_SelectCategory_2;

	private readonly InputAction m_Palette_SelectCategory_3;

	private readonly InputAction m_Palette_SelectCategory_4;

	private readonly InputAction m_Palette_SelectCategory_5;

	private readonly InputAction m_Palette_SelectCategory_6;

	private readonly InputAction m_Palette_SelectCategory_7;

	private readonly InputAction m_Palette_SelectCategory_8;

	private readonly InputAction m_Palette_SelectCategory_9;

	private readonly InputAction m_Palette_SelectCategory_10;

	private readonly InputAction m_Palette_SelectCategory_11;

	private readonly InputAction m_Palette_SelectCategory_12;

	private readonly InputAction m_Palette_SelectItem_1;

	private readonly InputAction m_Palette_SelectItem_2;

	private readonly InputAction m_Palette_SelectItem_3;

	private readonly InputAction m_Palette_SelectItem_4;

	private readonly InputAction m_Palette_SelectItem_5;

	private readonly InputAction m_Palette_SelectItem_6;

	private readonly InputAction m_Palette_SelectItem_7;

	private readonly InputAction m_Palette_SelectItem_8;

	private readonly InputAction m_Palette_SelectItem_9;

	private readonly InputAction m_Palette_SelectItem_10;

	private readonly InputActionMap m_UIControl;

	private List<IUIControlActions> m_UIControlActionsCallbackInterfaces;

	private readonly InputAction m_UIControl_Switch;

	private readonly InputAction m_UIControl_LeftTrigger;

	private readonly InputAction m_UIControl_RightTrigger;

	private readonly InputAction m_UIControl_Cancel;

	private readonly InputAction m_UIControl_Decide;

	private readonly InputAction m_UIControl_Down;

	private readonly InputAction m_UIControl_Up;

	private readonly InputAction m_UIControl_Right;

	private readonly InputAction m_UIControl_Left;

	private readonly InputAction m_UIControl_Select;

	private readonly InputAction m_UIControl_LeftShoulder;

	private readonly InputAction m_UIControl_RightShoulder;

	private readonly InputAction m_UIControl_SubMenu;

	private readonly InputAction m_UIControl_Start;

	private readonly InputAction m_UIControl_RightStickPush;

	private readonly InputActionMap m_Movie;

	private List<IMovieActions> m_MovieActionsCallbackInterfaces;

	private readonly InputAction m_Movie_PressAnyKey;

	private readonly InputAction m_Movie_SkipWithSpace;

	private readonly InputAction m_Movie_SplashSkip;

	private int m_KeyboardMouseSchemeIndex;

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

	public GlobalActions Global => default(GlobalActions);

	public InGameActions InGame => default(InGameActions);

	public DebugActions Debug => default(DebugActions);

	public PaletteActions Palette => default(PaletteActions);

	public UIControlActions UIControl => default(UIControlActions);

	public MovieActions Movie => default(MovieActions);

	public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

	~InputActionController()
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
