using Dorfromantik;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ActionInput : MonoBehaviour
{
	[SerializeField]
	private InputActionReference inputAction;

	[SerializeField]
	private UnityEvent OnInputStarted;

	[SerializeField]
	private UnityEvent OnInputStopped;

	[SerializeField]
	private bool checkIfTilePlacementAllowed;

	[SerializeField]
	private bool checkIfTileRotationAllowed;

	[SerializeField]
	private bool noInputWhileOnConfirmationScreen;

	[SerializeField]
	private bool stopInputOnDestroy;

	[SerializeField]
	private bool noInputDuringInteractionRestriction_TilePlacement;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private InputActionReference modificationKey;

	[SerializeField]
	private UnityEvent OnModifiedInputStarted;

	[SerializeField]
	private UnityEvent OnModifiedInputStopped;

	private bool modificationKeyActive;

	private InputManager inputManager;

	private void Awake()
	{
		inputManager = GetComponentInParent<InputManager>();
	}

	private void Start()
	{
		if ((bool)modificationKey)
		{
			modificationKey.action.started += delegate
			{
				SetModificationMultiplier(isModificationMultiplierActive: true);
			};
			modificationKey.action.canceled += delegate
			{
				SetModificationMultiplier(isModificationMultiplierActive: false);
			};
		}
	}

	private void OnEnable()
	{
		inputAction.action.started += StartInput;
		inputAction.action.canceled += StopInput;
	}

	private void SetModificationMultiplier(bool isModificationMultiplierActive)
	{
		modificationKeyActive = isModificationMultiplierActive;
	}

	private void StartInput(InputAction.CallbackContext callbackContext)
	{
		if (base.enabled && (!checkIfTilePlacementAllowed || inputManager.TilePlacementAllowed) && (!checkIfTileRotationAllowed || inputManager.TileRotationAllowed) && (!noInputDuringInteractionRestriction_TilePlacement || (inputRouter.InteractionRestriction.tileControlsAllowed && inputRouter.GameState == GameState.Playing)) && (!noInputWhileOnConfirmationScreen || !Singleton<MainMenuUi>.Instance.ActiveConfirmationScreen) && !Singleton<SplashScreenManager>.Instance)
		{
			if (modificationKeyActive)
			{
				OnModifiedInputStarted?.Invoke();
			}
			else
			{
				OnInputStarted?.Invoke();
			}
		}
	}

	private void StopInput(InputAction.CallbackContext callbackContext)
	{
		if (base.enabled && (!checkIfTilePlacementAllowed || inputManager.TilePlacementAllowed) && (!checkIfTileRotationAllowed || inputManager.TileRotationAllowed) && (!noInputDuringInteractionRestriction_TilePlacement || (inputRouter.InteractionRestriction.tileControlsAllowed && inputRouter.GameState == GameState.Playing)) && (!noInputWhileOnConfirmationScreen || !Singleton<MainMenuUi>.Instance || !Singleton<MainMenuUi>.Instance.ActiveConfirmationScreen))
		{
			if (modificationKeyActive)
			{
				OnModifiedInputStopped?.Invoke();
			}
			else
			{
				OnInputStopped?.Invoke();
			}
		}
	}

	private void OnDisable()
	{
		inputAction.action.started -= StartInput;
		inputAction.action.canceled -= StopInput;
		if (stopInputOnDestroy)
		{
			StopInput(default(InputAction.CallbackContext));
		}
	}

	private void _003CStart_003Eb__15_0(InputAction.CallbackContext _)
	{
		SetModificationMultiplier(isModificationMultiplierActive: true);
	}

	private void _003CStart_003Eb__15_1(InputAction.CallbackContext _)
	{
		SetModificationMultiplier(isModificationMultiplierActive: false);
	}
}
