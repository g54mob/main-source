using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ActionOverTileInput : MonoBehaviour
{
	[SerializeField]
	private InputActionReference inputAction;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private TileEvent OnInputOverTileStarted;

	[SerializeField]
	private TileEvent OnInputOverTileStopped;

	[SerializeField]
	private bool checkIfTilePlacementAllowed;

	private Camera mainCamera;

	private Tile lastTile;

	private Tile currentTile;

	private bool receivingInput;

	private InputManager inputManager;

	private void Awake()
	{
		inputAction.action.started += StartInput;
		inputAction.action.canceled += StopInput;
	}

	private void Start()
	{
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			UpdateInputCameraReference(default(Scene));
		}
	}

	private void StartInput(InputAction.CallbackContext callbackContext)
	{
		if (base.enabled && (!checkIfTilePlacementAllowed || inputManager.TilePlacementAllowed))
		{
			DetermineCurrentTile();
			if ((bool)currentTile)
			{
				OnInputOverTileStarted?.Invoke(currentTile);
			}
		}
	}

	private void StopInput(InputAction.CallbackContext callbackContext)
	{
		if (base.enabled && (!inputManager || !checkIfTilePlacementAllowed || inputManager.TilePlacementAllowed))
		{
			DetermineCurrentTile();
			if ((bool)currentTile)
			{
				OnInputOverTileStopped?.Invoke(currentTile);
			}
		}
	}

	private void UpdateInputCameraReference(Scene obj)
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		}
		inputManager = Singleton<InputManager>.Instance;
	}

	private void DetermineCurrentTile()
	{
		if (!mainCamera)
		{
			return;
		}
		currentTile = null;
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = Pointer.current.position.ReadValue();
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		foreach (RaycastResult item in list)
		{
			if (item.gameObject.layer == 5)
			{
				return;
			}
			if (item.gameObject.layer == 10 && (bool)item.gameObject.GetComponent<Tile>())
			{
				currentTile = item.gameObject.GetComponent<Tile>();
			}
		}
		if (currentTile != null && currentTile.State != TileState.placed)
		{
			currentTile = null;
		}
	}

	private void OnDestroy()
	{
		sceneLoader.OnSceneLoaded -= UpdateInputCameraReference;
		inputAction.action.started -= StartInput;
		inputAction.action.canceled -= StopInput;
	}
}
