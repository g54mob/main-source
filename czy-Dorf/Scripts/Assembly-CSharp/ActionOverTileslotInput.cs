using Dorfromantik;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ActionOverTileslotInput : MonoBehaviour
{
	[SerializeField]
	private InputActionReference inputAction;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private bool dontTriggerInputOverUi;

	[SerializeField]
	[FormerlySerializedAs("OnInputOverTileslot")]
	private UnityEvent OnInputOverTileslotStarted;

	[SerializeField]
	private UnityEvent OnInputOverTileslotStopped;

	[SerializeField]
	private bool checkIfTilePlacementAllowed;

	[SerializeField]
	private bool disableIfCursorInvisible;

	private Camera mainCamera;

	private TileSlot lastTileSlot;

	private TileSlot currentTileSlot;

	private bool receivingInput;

	private InputManager inputManager;

	private bool invalidInput;

	private void Awake()
	{
		inputManager = GetComponentInParent<InputManager>();
		inputAction.action.started += StartInput;
		inputAction.action.canceled += StopInput;
	}

	private void StartInput(InputAction.CallbackContext callbackContext)
	{
		if (!base.enabled || (checkIfTilePlacementAllowed && !inputManager.TilePlacementAllowed) || (disableIfCursorInvisible && !Cursor.visible))
		{
			return;
		}
		if (dontTriggerInputOverUi && (bool)CameraUtility.PointerGameObject(5))
		{
			invalidInput = true;
			return;
		}
		DetermineCurrentTileSlot();
		if ((bool)currentTileSlot)
		{
			OnInputOverTileslotStarted?.Invoke();
		}
	}

	private void StopInput(InputAction.CallbackContext callbackContext)
	{
		if (!base.enabled)
		{
			return;
		}
		if (invalidInput)
		{
			invalidInput = false;
		}
		else if ((!checkIfTilePlacementAllowed || inputManager.TilePlacementAllowed) && (!disableIfCursorInvisible || Cursor.visible) && (!dontTriggerInputOverUi || !CameraUtility.PointerGameObject(5)))
		{
			DetermineCurrentTileSlot();
			if ((bool)currentTileSlot)
			{
				OnInputOverTileslotStopped?.Invoke();
			}
		}
	}

	private void UpdateInputCameraReference(Scene obj)
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		}
	}

	private void Start()
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			UpdateInputCameraReference(default(Scene));
		}
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
	}

	private void DetermineCurrentTileSlot()
	{
		if ((bool)mainCamera)
		{
			Physics.Raycast(mainCamera.ScreenPointToRay(Pointer.current.position.ReadValue()), out var hitInfo, 1000f, LayerMask.GetMask("TileSlot"));
			currentTileSlot = (hitInfo.collider ? hitInfo.collider.GetComponent<TileSlot>() : null);
			if (currentTileSlot != null && !currentTileSlot.IsValid)
			{
				currentTileSlot = null;
			}
		}
	}

	private void OnDestroy()
	{
		sceneLoader.OnSceneLoaded -= UpdateInputCameraReference;
		inputAction.action.started -= StartInput;
		inputAction.action.canceled -= StopInput;
	}
}
