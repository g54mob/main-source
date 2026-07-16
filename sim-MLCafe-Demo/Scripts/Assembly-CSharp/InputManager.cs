using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	[SerializeField]
	private InputMap inputMap;

	private static InputManager instance;

	public static UnityEvent OnOpenSettingsWindow = new UnityEvent();

	public static UnityEvent OnCancelMenuWindow = new UnityEvent();

	public static UnityEvent OnCancelSelection = new UnityEvent();

	public static UnityEvent OnCancleDialog = new UnityEvent();

	public static UnityEvent OnCharacterOpenInventoryEvent = new UnityEvent();

	public static UnityEvent OnCharacterMoveEvent = new UnityEvent();

	public static UnityEvent OnCameraTurnLeftEvent = new UnityEvent();

	public static UnityEvent OnCameraTurnRightEvent = new UnityEvent();

	public static UnityEvent OnMainClick = new UnityEvent();

	public static UnityEvent OnCancleClick = new UnityEvent();

	public static UnityEvent OnStopHoldingInteraction = new UnityEvent();

	private bool isHoldingInteraction;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		if (inputMap == null)
		{
			inputMap = new InputMap();
		}
	}

	private void OnEnable()
	{
		if (inputMap != null)
		{
			inputMap.Enable();
		}
	}

	private void OnDisable()
	{
		if (inputMap != null)
		{
			inputMap.Disable();
		}
	}

	private void Start()
	{
		inputMap.Menu.FPSToggle.performed += OnShowHideFPS;
		SwitchInputState(GameStateManager.GetCurrentGameState());
	}

	private void LateUpdate()
	{
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.GameRunning && isHoldingInteraction)
		{
			OnCharacterHoldInteraction();
		}
	}

	public static InputMap GetInputActions()
	{
		return instance.inputMap;
	}

	public static Vector2 GetPointerPosition()
	{
		_ = Vector2.zero;
		return instance.inputMap.Camera.MousePosition.ReadValue<Vector2>();
	}

	public static bool IsHoldingInteraction()
	{
		return instance.isHoldingInteraction;
	}

	public static bool PointerOverUIElement()
	{
		return EventSystem.current.IsPointerOverGameObject();
	}

	public static void SwitchInputState(GameStateManager.GameState gameState)
	{
		switch (gameState)
		{
		case GameStateManager.GameState.TitleScreen:
			instance.DialogRunning(subscribe: false);
			instance.GamePaused(subscribe: false);
			instance.GameRunning(subscribe: false);
			instance.InputLocked(subscribe: true);
			break;
		case GameStateManager.GameState.Lock:
			instance.DialogRunning(subscribe: false);
			instance.GamePaused(subscribe: false);
			instance.GameRunning(subscribe: false);
			instance.InputLocked(subscribe: true);
			break;
		case GameStateManager.GameState.GameRunning:
			instance.DialogRunning(subscribe: false);
			instance.InputLocked(subscribe: false);
			instance.GamePaused(subscribe: false);
			instance.GameRunning(subscribe: true);
			break;
		case GameStateManager.GameState.GamePaused:
			instance.DialogRunning(subscribe: false);
			instance.InputLocked(subscribe: false);
			instance.GameRunning(subscribe: false);
			instance.GamePaused(subscribe: true);
			break;
		case GameStateManager.GameState.Transition:
			break;
		}
	}

	private void InputLocked(bool subscribe)
	{
		if (subscribe)
		{
			inputMap.Character.Interact.performed += OnMainClickTrigger;
			inputMap.Character.Action.performed += OnCancleClickTrigger;
			inputMap.Menu.Cancel.performed += delegate
			{
				OnCancelMenuWindow.Invoke();
			};
		}
		else
		{
			inputMap.Character.Interact.performed -= OnMainClickTrigger;
			inputMap.Character.Action.performed -= OnCancleClickTrigger;
			inputMap.Menu.Cancel.performed -= delegate
			{
				OnCancelMenuWindow.Invoke();
			};
		}
	}

	private void DialogRunning(bool subscribe)
	{
		if (!DialogManager.IsValidated())
		{
			return;
		}
		if (DialogManager.IsAutoplayActive())
		{
			if (subscribe)
			{
				inputMap.Menu.Cancel.performed += delegate
				{
					OnCancleDialog.Invoke();
				};
				inputMap.Character.Interact.performed += OnMainClickTrigger;
				inputMap.Character.Action.performed += OnCancleClickTrigger;
				inputMap.Character.Movement.performed += OnPlayerMovement;
				inputMap.Character.Movement.canceled += StopPlayerMovement;
				inputMap.Camera.Turn.performed += OnCameraMovement;
				inputMap.Character.Running.performed += OnPlayerRunning;
				inputMap.Character.Running.canceled += StopPlayerRunning;
				inputMap.Character.Interact.performed += OnCharacterInteract;
				inputMap.Character.Action.performed += OnCharacterAction;
				inputMap.Character.HoldInteraction.performed += OnHoldInteractionPerformed;
				inputMap.Character.HoldInteraction.canceled += OnHoldInteractionCanceled;
				inputMap.Character.Place.performed += OnCharacterPlacePiece;
				inputMap.Character.Rotate.performed += OnCharacterRotatePiece;
			}
			else
			{
				inputMap.Menu.Cancel.performed -= delegate
				{
					OnCancleDialog.Invoke();
				};
				inputMap.Character.Interact.performed -= OnMainClickTrigger;
				inputMap.Character.Action.performed -= OnCancleClickTrigger;
				inputMap.Character.Movement.performed -= OnPlayerMovement;
				inputMap.Character.Movement.canceled -= StopPlayerMovement;
				inputMap.Camera.Turn.performed -= OnCameraMovement;
				inputMap.Character.Running.performed -= OnPlayerRunning;
				inputMap.Character.Running.canceled -= StopPlayerRunning;
				inputMap.Character.Interact.performed -= OnCharacterInteract;
				inputMap.Character.Action.performed -= OnCharacterAction;
				inputMap.Character.HoldInteraction.performed -= OnHoldInteractionPerformed;
				inputMap.Character.HoldInteraction.canceled -= OnHoldInteractionCanceled;
				inputMap.Character.Place.performed -= OnCharacterPlacePiece;
				inputMap.Character.Rotate.performed -= OnCharacterRotatePiece;
			}
		}
		else if (subscribe)
		{
			inputMap.Character.Interact.performed += OnMainClickTrigger;
			inputMap.Character.Action.performed += OnCancleClickTrigger;
			inputMap.Menu.Cancel.performed += delegate
			{
				OnCancleDialog.Invoke();
			};
		}
		else
		{
			inputMap.Character.Interact.performed -= OnMainClickTrigger;
			inputMap.Character.Action.performed -= OnCancleClickTrigger;
			inputMap.Menu.Cancel.performed -= delegate
			{
				OnCancleDialog.Invoke();
			};
		}
	}

	private void GameRunning(bool subscribe)
	{
		if (subscribe)
		{
			inputMap.Character.Interact.performed += OnMainClickTrigger;
			inputMap.Character.Action.performed += OnCancleClickTrigger;
			inputMap.Character.Movement.performed += OnPlayerMovement;
			inputMap.Character.Movement.canceled += StopPlayerMovement;
			inputMap.Camera.Turn.performed += OnCameraMovement;
			inputMap.Character.Running.performed += OnPlayerRunning;
			inputMap.Character.Running.canceled += StopPlayerRunning;
			inputMap.Character.Interact.performed += OnCharacterInteract;
			inputMap.Character.Action.performed += OnCharacterAction;
			inputMap.Character.HoldInteraction.performed += OnHoldInteractionPerformed;
			inputMap.Character.HoldInteraction.canceled += OnHoldInteractionCanceled;
			inputMap.Character.Place.performed += OnCharacterPlacePiece;
			inputMap.Character.Rotate.performed += OnCharacterRotatePiece;
			inputMap.Character.ToolbarHotkey.performed += OnCharacterToolbarHotkey;
			inputMap.Character.OpenCharacterMenu.performed += OnCharacterMenu;
			inputMap.Menu.Cancel.performed += OnMenuCancel;
			inputMap.Menu.Cancel.performed += OnSelectionCancel;
			inputMap.Menu.Cancel.performed += delegate
			{
				OnCancleDialog.Invoke();
			};
			inputMap.Menu.DragAndDrop.canceled += OnDragnDrop_Drop;
		}
		else
		{
			inputMap.Character.Interact.performed -= OnMainClickTrigger;
			inputMap.Character.Action.performed -= OnCancleClickTrigger;
			inputMap.Character.Movement.performed -= OnPlayerMovement;
			inputMap.Character.Movement.canceled -= StopPlayerMovement;
			inputMap.Camera.Turn.performed -= OnCameraMovement;
			inputMap.Character.Running.performed -= OnPlayerRunning;
			inputMap.Character.Running.canceled -= StopPlayerRunning;
			inputMap.Character.Interact.performed -= OnCharacterInteract;
			inputMap.Character.Action.performed -= OnCharacterAction;
			inputMap.Character.HoldInteraction.performed -= OnHoldInteractionPerformed;
			inputMap.Character.HoldInteraction.canceled -= OnHoldInteractionCanceled;
			inputMap.Character.Place.performed -= OnCharacterPlacePiece;
			inputMap.Character.Rotate.performed -= OnCharacterRotatePiece;
			inputMap.Character.ToolbarHotkey.performed -= OnCharacterToolbarHotkey;
			inputMap.Character.OpenCharacterMenu.performed -= OnCharacterMenu;
			inputMap.Menu.Cancel.performed -= OnMenuCancel;
			inputMap.Menu.Cancel.performed -= OnSelectionCancel;
			inputMap.Menu.Cancel.performed -= delegate
			{
				OnCancleDialog.Invoke();
			};
			inputMap.Menu.DragAndDrop.canceled -= OnDragnDrop_Drop;
		}
	}

	private void GamePaused(bool subscribe)
	{
		if (subscribe)
		{
			inputMap.Character.Interact.performed += OnMainClickTrigger;
			inputMap.Character.Action.performed += OnCancleClickTrigger;
			inputMap.Menu.Cancel.performed += OnMenuCancel;
		}
		else
		{
			inputMap.Character.Interact.performed -= OnMainClickTrigger;
			inputMap.Character.Action.performed -= OnCancleClickTrigger;
			inputMap.Menu.Cancel.performed -= OnMenuCancel;
		}
	}

	private void OnMainClickTrigger(InputAction.CallbackContext ctx)
	{
		OnMainClick.Invoke();
	}

	private void OnCancleClickTrigger(InputAction.CallbackContext ctx)
	{
		OnCancleClick.Invoke();
	}

	private void OnPlayerMovement(InputAction.CallbackContext ctx)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.CharacterMode)
		{
			Vector2 vector = ctx.ReadValue<Vector2>();
			Vector3 inputAxis = new Vector3(vector.x, 0f, vector.y);
			if (GlobalReferences.IsValidated())
			{
				GlobalReferences.GetCharacterController().SetInputAxis(inputAxis);
			}
			OnCharacterMoveEvent.Invoke();
		}
	}

	private void StopPlayerMovement(InputAction.CallbackContext ctx)
	{
		if (GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().SetInputAxis(Vector3.zero);
		}
	}

	private void OnPlayerRunning(InputAction.CallbackContext ctx)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.CharacterMode && GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().EnableRunning();
		}
	}

	private void StopPlayerRunning(InputAction.CallbackContext ctx)
	{
		if (GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().DisableRunning();
		}
	}

	private void OnCameraMovement(InputAction.CallbackContext ctx)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.CharacterMode && GlobalReferences.IsValidated() && !(GlobalReferences.GetActiveCameraController() == null))
		{
			GlobalReferences.GetActiveCameraController().Turn(ctx.ReadValue<Vector2>());
		}
	}

	private void OnCharacterInteract(InputAction.CallbackContext ctx)
	{
		if (GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().OnInteract();
		}
	}

	private void OnCharacterAction(InputAction.CallbackContext ctx)
	{
		if (!isHoldingInteraction && GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().OnAction();
		}
	}

	private void OnHoldInteractionPerformed(InputAction.CallbackContext ctx)
	{
		isHoldingInteraction = true;
	}

	private void OnHoldInteractionCanceled(InputAction.CallbackContext ctx)
	{
		isHoldingInteraction = false;
		OnStopHoldingInteraction.Invoke();
		if (GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().OnHoldInteractStopped();
		}
	}

	private void OnCharacterHoldInteraction()
	{
		if (GlobalReferences.IsValidated())
		{
			GlobalReferences.GetCharacterController().OnHoldInteract();
		}
	}

	private void OnCharacterPlacePiece(InputAction.CallbackContext ctx)
	{
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.GameRunning)
		{
			PlacingSystem.PlaceHoldingObject();
		}
	}

	private void OnCharacterRotatePiece(InputAction.CallbackContext ctx)
	{
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.GameRunning)
		{
			PreviewSystem.RotatePreview((int)ctx.ReadValue<float>());
		}
	}

	private void OnCharacterToolbarHotkey(InputAction.CallbackContext ctx)
	{
		if (GameStateManager.GetCurrentCharacterState() != GameStateManager.CharacterState.NPCDialogSequence)
		{
			ctx.ReadValue<float>();
		}
	}

	private void OnCharacterMenu(InputAction.CallbackContext ctx)
	{
	}

	private void OnSettingsMenu(InputAction.CallbackContext ctx)
	{
		GameStateManager.GetCurrentCharacterState();
	}

	private void OnMenuCancel(InputAction.CallbackContext ctx)
	{
		if (!TransitionManager.IsTransitioning() && GameStateManager.GetCurrentCharacterState() != GameStateManager.CharacterState.Locked && GameStateManager.GetCurrentCharacterState() != GameStateManager.CharacterState.NPCDialogSequence)
		{
			if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.MenuOpen || GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.ShopMode)
			{
				OnCancelMenuWindow.Invoke();
				MouseCursorInteraction.UpdateCursorState();
				SoundManager.PlaySoundOnce("ui_menu_close");
			}
			else
			{
				OnOpenSettingsWindow.Invoke();
				SoundManager.PlaySoundOnce("ui_menu_open");
			}
		}
	}

	private void OnSelectionCancel(InputAction.CallbackContext ctx)
	{
		OnCancelSelection.Invoke();
	}

	private void OnDragnDrop_Drop(InputAction.CallbackContext ctx)
	{
	}

	private void OnDispatchControllerMovement(InputAction.CallbackContext ctx)
	{
		Vector2 vector = ctx.ReadValue<Vector2>();
		Vector3 inputAxis = new Vector3(vector.x, 0f, vector.y);
		GlobalReferences.GetDispatchController().SetInputAxis(inputAxis);
	}

	private void StopDispatchControllerMovement(InputAction.CallbackContext ctx)
	{
		GlobalReferences.GetDispatchController().SetInputAxis(Vector3.zero);
	}

	private void OnShowHideFPS(InputAction.CallbackContext ctx)
	{
		if (FPSCount.IsVisible())
		{
			FPSCount.Hide();
		}
		else
		{
			FPSCount.Show();
		}
	}
}
