using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PointerOverTileInput : MonoBehaviour
{
	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private TileEvent onHoverOverTile;

	[SerializeField]
	private bool disableIfCursorInvisible;

	private Camera mainCamera;

	private Tile lastTile;

	private Tile currentTile;

	private InputManager inputManager;

	private void Start()
	{
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			UpdateInputCameraReference(default(Scene));
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

	public void Update()
	{
		lastTile = currentTile;
		if (inputRouter.ActiveTool == ToolId.None || ((bool)inputManager && !inputManager.TilePlacementAllowed))
		{
			currentTile = null;
		}
		else
		{
			DetermineCurrentTile();
		}
		if (currentTile != lastTile)
		{
			onHoverOverTile?.Invoke(currentTile);
		}
	}

	private void DetermineCurrentTile()
	{
		if (!mainCamera || !Pointer.current.wasUpdatedThisFrame || Singleton<InputManager>.Instance.CurrentInputDevice == Dorfromantik.InputDevice.Gamepad)
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
	}
}
