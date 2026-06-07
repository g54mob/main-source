using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class MyControls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActions
	{
		private MyControls m_Wrapper;

		public InputAction Move => null;

		public InputAction Cancel => null;

		public InputAction Look => null;

		public InputAction Interact => null;

		public InputAction Pickup => null;

		public InputAction Crouch => null;

		public InputAction Jump => null;

		public InputAction Sprint => null;

		public InputAction MenuEscape => null;

		public InputAction Build => null;

		public InputAction Zoom => null;

		public InputAction Drop => null;

		public InputAction Action1 => null;

		public InputAction Action2 => null;

		public InputAction Action3 => null;

		public InputAction Keyboard1 => null;

		public InputAction Keyboard2 => null;

		public InputAction Keyboard3 => null;

		public InputAction Keyboard4 => null;

		public InputAction Keyboard5 => null;

		public InputAction Keyboard6 => null;

		public InputAction Keyboard7 => null;

		public InputAction Keyboard8 => null;

		public InputAction Keyboard9 => null;

		public InputAction Keyboard0 => null;

		public InputAction RightClick => null;

		public InputAction Fire => null;

		public InputAction cursor => null;

		public InputAction Map => null;

		public InputAction QuestLogOpen => null;

		public InputAction SkillTree => null;

		public InputAction BarControls => null;

		public InputAction TrailerCam => null;

		public InputAction Emotes => null;

		public InputAction CarLight => null;

		public InputAction Mic => null;

		public InputAction CameraMode => null;

		public bool enabled => false;

		public PlayerActions(MyControls wrapper)
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

	public struct CarActions
	{
		private MyControls m_Wrapper;

		public InputAction StartCar => null;

		public InputAction Steer => null;

		public InputAction Accelerate => null;

		public InputAction Brake => null;

		public InputAction Look => null;

		public InputAction Handbrake => null;

		public InputAction DownShift => null;

		public InputAction UpShift => null;

		public InputAction LeftTurnSignal => null;

		public InputAction RightTurnSignal => null;

		public InputAction HazardLights => null;

		public InputAction LowBeamLight => null;

		public InputAction HighBeamLight => null;

		public InputAction SwitchCamera => null;

		public InputAction Restart => null;

		public InputAction Carcontrol1 => null;

		public InputAction CarControl2 => null;

		public InputAction CarControl3 => null;

		public InputAction Wheelie => null;

		public bool enabled => false;

		public CarActions(MyControls wrapper)
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

		public static implicit operator InputActionMap(CarActions set)
		{
			return null;
		}

		public void AddCallbacks(ICarActions instance)
		{
		}

		private void UnregisterCallbacks(ICarActions instance)
		{
		}

		public void RemoveCallbacks(ICarActions instance)
		{
		}

		public void SetCallbacks(ICarActions instance)
		{
		}
	}

	public struct UIActions
	{
		private MyControls m_Wrapper;

		public InputAction Navigate => null;

		public InputAction Submit => null;

		public InputAction Point => null;

		public InputAction Click => null;

		public InputAction Validate => null;

		public InputAction RightClick => null;

		public InputAction MiddleClick => null;

		public InputAction ScrollWheel => null;

		public InputAction TrackedDevicePosition => null;

		public InputAction TrackedDeviceOrientation => null;

		public InputAction Toggle => null;

		public InputAction Rotate => null;

		public InputAction ShowMarketRates => null;

		public InputAction SellItemsToMarket => null;

		public bool enabled => false;

		public UIActions(MyControls wrapper)
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

	public struct BuildingActions
	{
		private MyControls m_Wrapper;

		public InputAction Validate => null;

		public InputAction Cancel => null;

		public InputAction Select => null;

		public InputAction Rotate => null;

		public bool enabled => false;

		public BuildingActions(MyControls wrapper)
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

		public static implicit operator InputActionMap(BuildingActions set)
		{
			return null;
		}

		public void AddCallbacks(IBuildingActions instance)
		{
		}

		private void UnregisterCallbacks(IBuildingActions instance)
		{
		}

		public void RemoveCallbacks(IBuildingActions instance)
		{
		}

		public void SetCallbacks(IBuildingActions instance)
		{
		}
	}

	public struct EconomyDebugActions
	{
		private MyControls m_Wrapper;

		public InputAction PrintPrices => null;

		public InputAction ForceNextDay => null;

		public InputAction DetailedAnalysis => null;

		public InputAction ToggleLogging => null;

		public bool enabled => false;

		public EconomyDebugActions(MyControls wrapper)
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

		public static implicit operator InputActionMap(EconomyDebugActions set)
		{
			return null;
		}

		public void AddCallbacks(IEconomyDebugActions instance)
		{
		}

		private void UnregisterCallbacks(IEconomyDebugActions instance)
		{
		}

		public void RemoveCallbacks(IEconomyDebugActions instance)
		{
		}

		public void SetCallbacks(IEconomyDebugActions instance)
		{
		}
	}

	public interface IPlayerActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);

		void OnPickup(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);

		void OnJump(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnMenuEscape(InputAction.CallbackContext context);

		void OnBuild(InputAction.CallbackContext context);

		void OnZoom(InputAction.CallbackContext context);

		void OnDrop(InputAction.CallbackContext context);

		void OnAction1(InputAction.CallbackContext context);

		void OnAction2(InputAction.CallbackContext context);

		void OnAction3(InputAction.CallbackContext context);

		void OnKeyboard1(InputAction.CallbackContext context);

		void OnKeyboard2(InputAction.CallbackContext context);

		void OnKeyboard3(InputAction.CallbackContext context);

		void OnKeyboard4(InputAction.CallbackContext context);

		void OnKeyboard5(InputAction.CallbackContext context);

		void OnKeyboard6(InputAction.CallbackContext context);

		void OnKeyboard7(InputAction.CallbackContext context);

		void OnKeyboard8(InputAction.CallbackContext context);

		void OnKeyboard9(InputAction.CallbackContext context);

		void OnKeyboard0(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnFire(InputAction.CallbackContext context);

		void OnCursor(InputAction.CallbackContext context);

		void OnMap(InputAction.CallbackContext context);

		void OnQuestLogOpen(InputAction.CallbackContext context);

		void OnSkillTree(InputAction.CallbackContext context);

		void OnBarControls(InputAction.CallbackContext context);

		void OnTrailerCam(InputAction.CallbackContext context);

		void OnEmotes(InputAction.CallbackContext context);

		void OnCarLight(InputAction.CallbackContext context);

		void OnMic(InputAction.CallbackContext context);

		void OnCameraMode(InputAction.CallbackContext context);
	}

	public interface ICarActions
	{
		void OnStartCar(InputAction.CallbackContext context);

		void OnSteer(InputAction.CallbackContext context);

		void OnAccelerate(InputAction.CallbackContext context);

		void OnBrake(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnHandbrake(InputAction.CallbackContext context);

		void OnDownShift(InputAction.CallbackContext context);

		void OnUpShift(InputAction.CallbackContext context);

		void OnLeftTurnSignal(InputAction.CallbackContext context);

		void OnRightTurnSignal(InputAction.CallbackContext context);

		void OnHazardLights(InputAction.CallbackContext context);

		void OnLowBeamLight(InputAction.CallbackContext context);

		void OnHighBeamLight(InputAction.CallbackContext context);

		void OnSwitchCamera(InputAction.CallbackContext context);

		void OnRestart(InputAction.CallbackContext context);

		void OnCarcontrol1(InputAction.CallbackContext context);

		void OnCarControl2(InputAction.CallbackContext context);

		void OnCarControl3(InputAction.CallbackContext context);

		void OnWheelie(InputAction.CallbackContext context);
	}

	public interface IUIActions
	{
		void OnNavigate(InputAction.CallbackContext context);

		void OnSubmit(InputAction.CallbackContext context);

		void OnPoint(InputAction.CallbackContext context);

		void OnClick(InputAction.CallbackContext context);

		void OnValidate(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnMiddleClick(InputAction.CallbackContext context);

		void OnScrollWheel(InputAction.CallbackContext context);

		void OnTrackedDevicePosition(InputAction.CallbackContext context);

		void OnTrackedDeviceOrientation(InputAction.CallbackContext context);

		void OnToggle(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnShowMarketRates(InputAction.CallbackContext context);

		void OnSellItemsToMarket(InputAction.CallbackContext context);
	}

	public interface IBuildingActions
	{
		void OnValidate(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnSelect(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);
	}

	public interface IEconomyDebugActions
	{
		void OnPrintPrices(InputAction.CallbackContext context);

		void OnForceNextDay(InputAction.CallbackContext context);

		void OnDetailedAnalysis(InputAction.CallbackContext context);

		void OnToggleLogging(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Player;

	private List<IPlayerActions> m_PlayerActionsCallbackInterfaces;

	private readonly InputAction m_Player_Move;

	private readonly InputAction m_Player_Cancel;

	private readonly InputAction m_Player_Look;

	private readonly InputAction m_Player_Interact;

	private readonly InputAction m_Player_Pickup;

	private readonly InputAction m_Player_Crouch;

	private readonly InputAction m_Player_Jump;

	private readonly InputAction m_Player_Sprint;

	private readonly InputAction m_Player_MenuEscape;

	private readonly InputAction m_Player_Build;

	private readonly InputAction m_Player_Zoom;

	private readonly InputAction m_Player_Drop;

	private readonly InputAction m_Player_Action1;

	private readonly InputAction m_Player_Action2;

	private readonly InputAction m_Player_Action3;

	private readonly InputAction m_Player_Keyboard1;

	private readonly InputAction m_Player_Keyboard2;

	private readonly InputAction m_Player_Keyboard3;

	private readonly InputAction m_Player_Keyboard4;

	private readonly InputAction m_Player_Keyboard5;

	private readonly InputAction m_Player_Keyboard6;

	private readonly InputAction m_Player_Keyboard7;

	private readonly InputAction m_Player_Keyboard8;

	private readonly InputAction m_Player_Keyboard9;

	private readonly InputAction m_Player_Keyboard0;

	private readonly InputAction m_Player_RightClick;

	private readonly InputAction m_Player_Fire;

	private readonly InputAction m_Player_cursor;

	private readonly InputAction m_Player_Map;

	private readonly InputAction m_Player_QuestLogOpen;

	private readonly InputAction m_Player_SkillTree;

	private readonly InputAction m_Player_BarControls;

	private readonly InputAction m_Player_TrailerCam;

	private readonly InputAction m_Player_Emotes;

	private readonly InputAction m_Player_CarLight;

	private readonly InputAction m_Player_Mic;

	private readonly InputAction m_Player_CameraMode;

	private readonly InputActionMap m_Car;

	private List<ICarActions> m_CarActionsCallbackInterfaces;

	private readonly InputAction m_Car_StartCar;

	private readonly InputAction m_Car_Steer;

	private readonly InputAction m_Car_Accelerate;

	private readonly InputAction m_Car_Brake;

	private readonly InputAction m_Car_Look;

	private readonly InputAction m_Car_Handbrake;

	private readonly InputAction m_Car_DownShift;

	private readonly InputAction m_Car_UpShift;

	private readonly InputAction m_Car_LeftTurnSignal;

	private readonly InputAction m_Car_RightTurnSignal;

	private readonly InputAction m_Car_HazardLights;

	private readonly InputAction m_Car_LowBeamLight;

	private readonly InputAction m_Car_HighBeamLight;

	private readonly InputAction m_Car_SwitchCamera;

	private readonly InputAction m_Car_Restart;

	private readonly InputAction m_Car_Carcontrol1;

	private readonly InputAction m_Car_CarControl2;

	private readonly InputAction m_Car_CarControl3;

	private readonly InputAction m_Car_Wheelie;

	private readonly InputActionMap m_UI;

	private List<IUIActions> m_UIActionsCallbackInterfaces;

	private readonly InputAction m_UI_Navigate;

	private readonly InputAction m_UI_Submit;

	private readonly InputAction m_UI_Point;

	private readonly InputAction m_UI_Click;

	private readonly InputAction m_UI_Validate;

	private readonly InputAction m_UI_RightClick;

	private readonly InputAction m_UI_MiddleClick;

	private readonly InputAction m_UI_ScrollWheel;

	private readonly InputAction m_UI_TrackedDevicePosition;

	private readonly InputAction m_UI_TrackedDeviceOrientation;

	private readonly InputAction m_UI_Toggle;

	private readonly InputAction m_UI_Rotate;

	private readonly InputAction m_UI_ShowMarketRates;

	private readonly InputAction m_UI_SellItemsToMarket;

	private readonly InputActionMap m_Building;

	private List<IBuildingActions> m_BuildingActionsCallbackInterfaces;

	private readonly InputAction m_Building_Validate;

	private readonly InputAction m_Building_Cancel;

	private readonly InputAction m_Building_Select;

	private readonly InputAction m_Building_Rotate;

	private readonly InputActionMap m_EconomyDebug;

	private List<IEconomyDebugActions> m_EconomyDebugActionsCallbackInterfaces;

	private readonly InputAction m_EconomyDebug_PrintPrices;

	private readonly InputAction m_EconomyDebug_ForceNextDay;

	private readonly InputAction m_EconomyDebug_DetailedAnalysis;

	private readonly InputAction m_EconomyDebug_ToggleLogging;

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

	public CarActions Car => default(CarActions);

	public UIActions UI => default(UIActions);

	public BuildingActions Building => default(BuildingActions);

	public EconomyDebugActions EconomyDebug => default(EconomyDebugActions);

	public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

	public InputControlScheme GamepadScheme => default(InputControlScheme);

	public InputControlScheme TouchScheme => default(InputControlScheme);

	public InputControlScheme JoystickScheme => default(InputControlScheme);

	public InputControlScheme XRScheme => default(InputControlScheme);

	~MyControls()
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
