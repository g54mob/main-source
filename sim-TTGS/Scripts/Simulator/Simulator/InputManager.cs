using System;
using Dhs5.Utility.Updates;
using Simulator.GameWorld;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.UI;

namespace Simulator
{
	[RequireComponent(typeof(EventSystem), typeof(InputSystemUIInputModule), typeof(PlayerInput))]
	public class InputManager : TransientManager<InputManager>
	{
		public enum EMap
		{
			NONE = 0,
			PLAYER = 1,
			UI = 2
		}

		public enum ESide
		{
			MAIN = 0,
			SECOND = 1,
			JUMP = 2
		}

		[SerializeField]
		private PlayerInput m_playerInput;

		[SerializeField]
		private EventSystem m_eventSystem;

		[SerializeField]
		private InputSystemUIInputModule m_uiInputModule;

		[SerializeField]
		private GameObject m_virtualMousePrefab;

		protected InputActionMap m_playerMap;

		protected InputActionMap m_uiMap;

		protected InputActionMap m_debugMap;

		private bool m_playerMapRegistered;

		private bool m_uiMapRegistered;

		private GameObject m_virtualMouse;

		private EMap m_previousMap;

		private bool m_changedCursorThisFrame;

		private bool m_isMainHolding;

		private bool m_isNextDayHolding;

		public InputAction MainTapInputAction { get; private set; }

		public InputAction SecondTapInputAction { get; private set; }

		public InputAction MainHoldInputAction { get; private set; }

		public InputAction ThirdTapInputAction { get; private set; }

		public InputAction NextDayInputAction { get; private set; }

		public InputAction PaintInputAction { get; private set; }

		public PlayerInput PlayerInput => m_playerInput;

		public InputSystemUIInputModule UIInputModule => m_uiInputModule;

		public EInputDeviceType CurrentDevice { get; private set; }

		public EMap CurrentMap { get; private set; }

		public int LastMapChange { get; private set; }

		public bool CursorUseful { get; private set; }

		public int DeviceChangeFrame { get; private set; }

		public float MainTapInteractionDuration { get; private set; }

		public float MainHoldInteractionDuration { get; private set; }

		public float SecondTapInteractionDuration { get; private set; }

		public float ThirdInteractionDuration { get; private set; }

		public float JumpHoldInteractionDuration { get; private set; }

		public static bool InputFieldFocused { get; set; }

		public static event Action<EMap> MapChanged;

		public static event Action<EInputDeviceType> DeviceChanged;

		protected override void OnEnable()
		{
			base.OnEnable();
			RegisterDeviceChange(register: true);
			GetInputMaps();
			SetMap(EMap.NONE);
			CameraManager.BlendStarted += OnStartCameraBlend;
			CameraManager.BlendFinished += OnFinishCameraBlend;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (base.enabled)
			{
				RegisterDeviceChange(register: false);
				RegisterPlayerActions(register: false);
				RegisterUIActions(register: false);
				DisablePlayerMap();
				CameraManager.BlendStarted -= OnStartCameraBlend;
				CameraManager.BlendFinished -= OnFinishCameraBlend;
			}
		}

		protected override void OnMenuEvent(EMenuEvent menuEvent)
		{
			base.OnMenuEvent(menuEvent);
			switch (menuEvent)
			{
			case EMenuEvent.INITIALISATION:
				CacheInputActions();
				CacheInteractionsDuration();
				RegisterUIActions(register: true);
				break;
			case EMenuEvent.START:
				SetMap(EMap.UI);
				break;
			case EMenuEvent.OPEN:
				SetMap(EMap.UI);
				break;
			case EMenuEvent.CLOSE:
				SetMap(EMap.NONE);
				break;
			}
		}

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.INITIALISATION:
				RegisterPlayerActions(register: true);
				break;
			case EWorldEvent.START:
				m_eventSystem.SetSelectedGameObject(null);
				SetMap(EMap.PLAYER);
				break;
			case EWorldEvent.PAUSE:
				DisableAllMaps();
				break;
			case EWorldEvent.UNPAUSE:
				ReenableCorrectMap();
				break;
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			if (gameEvent == EGameEvent.DAY_START)
			{
				SetMap(EMap.PLAYER);
			}
		}

		private void RegisterDeviceChange(bool register)
		{
			if (register)
			{
				m_playerInput.onControlsChanged += OnDeviceChange;
			}
			else
			{
				m_playerInput.onControlsChanged -= OnDeviceChange;
			}
		}

		private void OnDeviceChange(PlayerInput playerInput)
		{
			string currentControlScheme = playerInput.currentControlScheme;
			if (!(currentControlScheme == "Keyboard&Mouse"))
			{
				if (currentControlScheme == "Gamepad")
				{
					SetDeviceType(EInputDeviceType.GAMEPAD);
				}
			}
			else
			{
				SetDeviceType(EInputDeviceType.KEYBOARD);
			}
			DeviceChangeFrame = Time.frameCount;
		}

		private void SetDeviceType(EInputDeviceType type)
		{
			CurrentDevice = type;
			switch (type)
			{
			case EInputDeviceType.KEYBOARD:
				if (CursorUseful)
				{
					SetCursorActive(active: true);
				}
				break;
			case EInputDeviceType.GAMEPAD:
				Cursor.visible = false;
				break;
			}
			InputManager.DeviceChanged?.Invoke(type);
		}

		protected virtual void GetInputMaps()
		{
			m_playerMap = InputSystem.actions.FindActionMap("Player", throwIfNotFound: true);
			m_uiMap = InputSystem.actions.FindActionMap("UI", throwIfNotFound: true);
			m_debugMap = InputSystem.actions.FindActionMap("Debug", throwIfNotFound: true);
		}

		public virtual InputActionMap GetMap(EMap map)
		{
			return map switch
			{
				EMap.PLAYER => m_playerMap, 
				EMap.UI => m_uiMap, 
				_ => m_debugMap, 
			};
		}

		public virtual void SetMap(EMap map)
		{
			if (CameraManager.IsBlending)
			{
				SetMapWhileCameraBlending(map);
			}
			else
			{
				InternalSetMap(map);
			}
		}

		protected virtual void InternalSetMap(EMap map)
		{
			CurrentMap = map;
			switch (CurrentMap)
			{
			case EMap.NONE:
				DisablePlayerMap();
				EnableUIMap(enable: false);
				break;
			case EMap.PLAYER:
				EnableUIMap(enable: false);
				EnablePlayerMap();
				break;
			case EMap.UI:
				DisablePlayerMap();
				EnableUIMap(enable: true);
				break;
			}
			LastMapChange = Time.frameCount;
			InputManager.MapChanged?.Invoke(map);
		}

		protected void EnablePlayerMap()
		{
			m_playerMap.Enable();
		}

		protected void DisablePlayerMap()
		{
			m_playerMap.Disable();
		}

		protected virtual void EnableUIMap(bool enable)
		{
			if (enable)
			{
				m_uiMap.Enable();
				m_uiInputModule.Process();
				m_eventSystem.enabled = true;
				CameraManager.GraphicRaycasterEnabled = false;
				UseCursor(useCursor: true);
			}
			else
			{
				m_uiMap.Disable();
				m_eventSystem.enabled = false;
				CameraManager.GraphicRaycasterEnabled = true;
				UseCursor(useCursor: false);
			}
		}

		protected void DisableAllMaps()
		{
			m_previousMap = CurrentMap;
			SetMap(EMap.NONE);
		}

		protected void ReenableCorrectMap()
		{
			SetMap(m_previousMap);
		}

		public void UseCursor(bool useCursor)
		{
			CursorUseful = useCursor;
			if (!m_changedCursorThisFrame)
			{
				m_changedCursorThisFrame = true;
				Updater.OneShotAfterLateUpdate += InternalUpdateCursor;
			}
		}

		private void InternalUpdateCursor()
		{
			m_changedCursorThisFrame = false;
			if (CursorUseful)
			{
				if (CurrentDevice == EInputDeviceType.KEYBOARD)
				{
					SetCursorActive(active: true);
				}
			}
			else
			{
				SetCursorActive(active: false);
			}
		}

		public void SetCursorActive(bool active)
		{
			if (active)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		public void SetVirtualMouseActive(bool active)
		{
			if (m_virtualMouse == null)
			{
				if (!active)
				{
					return;
				}
				m_virtualMouse = UnityEngine.Object.Instantiate(m_virtualMousePrefab);
			}
			if (!(m_virtualMouse == null))
			{
				m_virtualMouse.SetActive(active);
				if (active)
				{
					Cursor.lockState = CursorLockMode.None;
				}
			}
		}

		public void DestroyVirtualMouse()
		{
			if (m_virtualMouse != null)
			{
				UnityEngine.Object.Destroy(m_virtualMouse);
			}
		}

		private void CacheInputActions()
		{
			MainTapInputAction = m_playerMap.FindAction("MainInteract");
			SecondTapInputAction = m_playerMap.FindAction("SecondInteract");
			MainHoldInputAction = m_playerMap.FindAction("MainHoldInteract");
			ThirdTapInputAction = m_playerMap.FindAction("SecondHoldInteract");
			NextDayInputAction = m_playerMap.FindAction("NextDay");
			PaintInputAction = m_uiMap.FindAction("Paint");
		}

		private void CacheInteractionsDuration()
		{
			MainTapInteractionDuration = MainTapInputAction.GetTapInteractionDuration();
			MainHoldInteractionDuration = MainHoldInputAction.GetHolInteractionDuration();
			SecondTapInteractionDuration = SecondTapInputAction.GetTapInteractionDuration();
			ThirdInteractionDuration = ThirdTapInputAction.GetTapInteractionDuration();
		}

		protected void RegisterPlayerActions(bool register)
		{
			if (register && !m_playerMapRegistered)
			{
				m_playerMapRegistered = true;
				OnRegisterPlayerActions();
			}
			else if (!register && m_playerMapRegistered)
			{
				m_playerMapRegistered = false;
				OnUnregisterPlayerActions();
			}
		}

		protected virtual void OnRegisterPlayerActions()
		{
			m_playerMap.FindAction("Look").performed += OnPlayerInput_Look;
			m_playerMap.FindAction("Move").performed += OnPlayerInput_Move;
			m_playerMap.FindAction("Move").canceled += OnPlayerInput_MoveEnded;
			MainTapInputAction.started += OnPlayerInput_MainInteractTap;
			MainHoldInputAction.started += OnPlayerInput_MainHoldProcessing;
			MainHoldInputAction.performed += OnPlayerInput_MainHoldStart;
			MainHoldInputAction.canceled += OnPlayerInput_MainHoldCancel;
			SecondTapInputAction.started += OnPlayerInput_SecondInteract;
			ThirdTapInputAction.started += OnPlayerInput_ThirdInteract;
			m_playerMap.FindAction("Rotate").performed += OnPlayerInput_Rotate;
			m_playerMap.FindAction("Jump").performed += OnPlayerInput_Jump;
			NextDayInputAction.started += OnPlayerInputNextDayProcessing;
			NextDayInputAction.performed += OnPlayerInputNextDayStart;
			NextDayInputAction.canceled += OnPlayerInputNextDayCancel;
			m_playerMap.FindAction("Sprint").started += OnPlayerInput_SprintStarted;
			m_playerMap.FindAction("Sprint").canceled += OnPlayerInput_SprintEnded;
			m_playerMap.FindAction("Crouch").performed += OnPlayerInput_Crouch;
			m_playerMap.FindAction("Pause").performed += OnPlayerInput_Pause;
			m_playerMap.FindAction("QuickSave").performed += OnPlayerInput_QuickSave;
			m_playerMap.FindAction("QuickLoad").performed += OnPlayerInput_QuickLoad;
		}

		protected virtual void OnUnregisterPlayerActions()
		{
			m_playerMap.FindAction("Look").performed -= OnPlayerInput_Look;
			m_playerMap.FindAction("Move").performed -= OnPlayerInput_Move;
			m_playerMap.FindAction("Move").canceled -= OnPlayerInput_MoveEnded;
			MainTapInputAction.started -= OnPlayerInput_MainInteractTap;
			MainHoldInputAction.started -= OnPlayerInput_MainHoldProcessing;
			MainHoldInputAction.performed -= OnPlayerInput_MainHoldStart;
			MainHoldInputAction.canceled -= OnPlayerInput_MainHoldCancel;
			SecondTapInputAction.started -= OnPlayerInput_SecondInteract;
			ThirdTapInputAction.started -= OnPlayerInput_ThirdInteract;
			m_playerMap.FindAction("Rotate").performed -= OnPlayerInput_Rotate;
			m_playerMap.FindAction("Jump").performed -= OnPlayerInput_Jump;
			m_playerMap.FindAction("Crouch").performed -= OnPlayerInput_Crouch;
			NextDayInputAction.started -= OnPlayerInputNextDayProcessing;
			NextDayInputAction.performed -= OnPlayerInputNextDayStart;
			NextDayInputAction.canceled -= OnPlayerInputNextDayCancel;
			m_playerMap.FindAction("Sprint").started -= OnPlayerInput_SprintStarted;
			m_playerMap.FindAction("Sprint").canceled -= OnPlayerInput_SprintEnded;
			m_playerMap.FindAction("Pause").performed -= OnPlayerInput_Pause;
			m_playerMap.FindAction("QuickSave").performed -= OnPlayerInput_QuickSave;
			m_playerMap.FindAction("QuickLoad").performed -= OnPlayerInput_QuickLoad;
		}

		protected virtual void OnPlayerInput_Look(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_Look(context.ReadValue<Vector2>());
			}
		}

		protected virtual void OnPlayerInput_Move(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				Vector2 vector = context.ReadValue<Vector2>();
				receiver.OnPlayerInput_Move(new Vector3(vector.x, 0f, vector.y));
			}
		}

		protected virtual void OnPlayerInput_MoveEnded(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_Move(Vector2.zero);
			}
		}

		protected virtual void OnPlayerInput_MainInteractTap(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_MainInteractTap(PlayerSensor.GetSensable());
				MainHoldInputAction.Reset();
			}
		}

		protected virtual void OnPlayerInput_SecondInteract(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_SecondInteractTap(PlayerSensor.GetSensable());
			}
		}

		protected virtual void OnPlayerInput_ThirdInteract(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_ThirdInteractTap(PlayerSensor.GetSensable());
			}
		}

		protected virtual void OnPlayerInput_Rotate(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_Rotate(context.ReadValue<float>());
			}
		}

		protected virtual void OnPlayerInput_Jump(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_Jump();
			}
		}

		private void OnPlayerInput_Crouch(InputAction.CallbackContext obj)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_Crouch();
			}
		}

		protected virtual void OnPlayerInput_SprintStarted(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_SprintStarted();
			}
		}

		protected virtual void OnPlayerInput_SprintEnded(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_SprintEnded();
			}
		}

		protected virtual void OnPlayerInput_Pause(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnPlayerInput_Pause();
			}
		}

		protected virtual void OnPlayerInput_MainHoldProcessing(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				HoldInteraction holdInteraction = (HoldInteraction)context.interaction;
				ProcessingMainHold(holdInteraction, receiver, PlayerSensor.GetSensable());
			}
		}

		protected virtual void OnPlayerInput_MainHoldStart(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				StartMainHold(receiver, PlayerSensor.GetSensable());
			}
		}

		protected virtual void OnPlayerInput_MainHoldCancel(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				if (m_isMainHolding)
				{
					StopMainHold(receiver, PlayerSensor.GetSensable());
				}
				CancelMainHold(receiver, PlayerSensor.GetSensable());
			}
		}

		protected void ProcessingMainHold(HoldInteraction holdInteraction, IPlayerInputReceiver receiver, ISensable sensable)
		{
			PlayerSensor.SensableChanged += OnSensableChange;
			receiver.OnPlayerInput_MainHoldProcessing(holdInteraction, sensable);
		}

		protected void StartMainHold(IPlayerInputReceiver receiver, ISensable sensable)
		{
			m_isMainHolding = true;
			PlayerController.ControllableChanged += OnControllableChange;
			receiver.OnPlayerInput_MainHoldInteractStart(sensable);
		}

		protected void StopMainHold(IPlayerInputReceiver receiver, ISensable sensable)
		{
			m_isMainHolding = false;
			PlayerController.ControllableChanged -= OnControllableChange;
			receiver.OnPlayerInput_MainHoldInteractStop(sensable);
		}

		protected void CancelMainHold(IPlayerInputReceiver receiver, ISensable sensable)
		{
			PlayerSensor.SensableChanged -= OnSensableChange;
			receiver.OnPlayerInput_MainHoldInteractCancel(sensable);
		}

		private void OnPlayerInputNextDayProcessing(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				HoldInteraction holdInteraction = (HoldInteraction)context.interaction;
				receiver.OnPlayerInput_NextDayHoldProcessing(holdInteraction);
			}
		}

		private void OnPlayerInputNextDayStart(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				m_isNextDayHolding = true;
				PlayerController.ControllableChanged += OnControllableChange;
				receiver.OnPlayerInput_NextDayHoldStart();
			}
		}

		private void OnPlayerInputNextDayCancel(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver))
			{
				if (m_isNextDayHolding)
				{
					Debug.LogError("Hold next day cancelled");
					m_isNextDayHolding = false;
					PlayerController.ControllableChanged -= OnControllableChange;
					receiver.OnPlayerInput_NextDayHoldStop();
				}
				receiver.OnPlayerInput_NextDayHoldCancel();
			}
		}

		protected virtual void OnSensableChange(ISensable former, ISensable next)
		{
			if (IPlayerInputReceiver.HasCurrent(out var _))
			{
				MainHoldInputAction.Reset();
			}
		}

		protected virtual void OnControllableChange(IControllable former, IControllable next)
		{
			if (former is IPlayerInputReceiver)
			{
				MainHoldInputAction.Reset();
				NextDayInputAction.Reset();
			}
		}

		protected virtual void OnPlayerInput_QuickSave(InputAction.CallbackContext context)
		{
			SaveManager.QuickSave();
		}

		protected virtual void OnPlayerInput_QuickLoad(InputAction.CallbackContext context)
		{
			SaveManager.QuickLoad();
		}

		protected void RegisterUIActions(bool register)
		{
			if (register && !m_uiMapRegistered)
			{
				m_uiMapRegistered = true;
				OnRegisterUIActions();
			}
			else if (!register && m_uiMapRegistered)
			{
				m_uiMapRegistered = false;
				OnUnregisterUIActions();
			}
		}

		protected virtual void OnRegisterUIActions()
		{
			m_uiMap.FindAction("Cancel").performed += OnUIInput_Cancel;
			m_uiMap.FindAction("Space").performed += OnUIInput_Space;
			m_uiMap.FindAction("Navigate").performed += OnUIInput_Navigate;
			m_uiMap.FindAction("Point").performed += OnUIInput_Point;
			m_uiMap.FindAction("Submit").performed += OnUIInput_Submit;
			m_uiMap.FindAction("GamepadShoulders").performed += OnUIInput_GamepadShoulders;
			m_uiMap.FindAction("GamepadNorthButton").performed += OnUIInput_GamepadNorthButton;
			m_uiMap.FindAction("GamepadWestButton").performed += OnUIInput_GamepadWestButton;
			m_uiMap.FindAction("ExitWorkshop").performed += OnUIInput_ExitWorkshop;
		}

		protected virtual void OnUnregisterUIActions()
		{
			m_uiMap.FindAction("Cancel").performed -= OnUIInput_Cancel;
			m_uiMap.FindAction("Space").performed -= OnUIInput_Space;
			m_uiMap.FindAction("Navigate").performed -= OnUIInput_Navigate;
			m_uiMap.FindAction("Point").performed -= OnUIInput_Point;
			m_uiMap.FindAction("Submit").performed -= OnUIInput_Submit;
			m_uiMap.FindAction("GamepadShoulders").performed -= OnUIInput_GamepadShoulders;
			m_uiMap.FindAction("GamepadNorthButton").performed -= OnUIInput_GamepadNorthButton;
			m_uiMap.FindAction("GamepadWestButton").performed -= OnUIInput_GamepadWestButton;
			m_uiMap.FindAction("ExitWorkshop").performed -= OnUIInput_ExitWorkshop;
		}

		protected virtual void OnUIInput_Cancel(InputAction.CallbackContext context)
		{
			if (!ExecuteEvents.CanHandleEvent<ICancelHandler>(m_eventSystem.currentSelectedGameObject) && ICancelInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnCancel();
			}
		}

		protected virtual void OnUIInput_Space(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_Space();
			}
		}

		protected virtual void OnUIInput_Navigate(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_Navigate(context.ReadValue<Vector2>());
			}
		}

		protected virtual void OnUIInput_Point(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_Point(context.ReadValue<Vector2>());
			}
		}

		protected virtual void OnUIInput_Submit(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_Submit();
			}
		}

		private void OnUIInput_GamepadShoulders(InputAction.CallbackContext context)
		{
			if (IUIShouldersInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_GamepadShoulders(context.ReadValue<float>());
			}
		}

		private void OnUIInput_GamepadNorthButton(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_GamepadNorthButton();
			}
		}

		private void OnUIInput_GamepadWestButton(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_GamepadWestButton();
			}
		}

		private void OnUIInput_ExitWorkshop(InputAction.CallbackContext context)
		{
			if (IUIInputReceiver.HasCurrent(out var receiver))
			{
				receiver.OnUIInput_ExitWorkshop();
			}
		}

		protected virtual void SetMapWhileCameraBlending(EMap map)
		{
			m_previousMap = map;
		}

		protected virtual void OnStartCameraBlend(CinemachineCore.BlendEventParams _)
		{
			m_previousMap = CurrentMap;
			InternalSetMap(EMap.NONE);
		}

		protected virtual void OnFinishCameraBlend()
		{
			InternalSetMap(m_previousMap);
		}
	}
}
