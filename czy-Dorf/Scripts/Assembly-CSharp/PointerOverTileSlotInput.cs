using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PointerOverTileSlotInput : MonoBehaviour
{
	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private TileSlotEvent onHoverOverTileSlot;

	[SerializeField]
	private bool disableIfCursorInvisible;

	[SerializeField]
	private ToolId toolPreview;

	private Camera mainCamera;

	private TileSlot lastTileSlot;

	private TileSlot currentTileSlot;

	private InputManager inputManager;

	private void Awake()
	{
		inputManager = GetComponentInParent<InputManager>();
	}

	private void Start()
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			UpdateInputCameraReference(default(Scene));
		}
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
		if (!inputManager)
		{
			inputManager = Singleton<InputManager>.Instance;
		}
	}

	private void UpdateInputCameraReference(Scene obj)
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		}
	}

	public void Update()
	{
		lastTileSlot = currentTileSlot;
		if (inputRouter.ActiveTool != toolPreview || ((bool)inputManager && !inputManager.TilePlacementAllowed))
		{
			currentTileSlot = null;
		}
		else
		{
			DetermineCurrentTileSlot();
		}
		if (currentTileSlot != lastTileSlot || (toolPreview != ToolId.None && inputManager.CurrentInputDevice == Dorfromantik.InputDevice.MouseKeyboard))
		{
			onHoverOverTileSlot?.Invoke(currentTileSlot);
		}
	}

	private void DetermineCurrentTileSlot()
	{
		if (!mainCamera || !Pointer.current.wasUpdatedThisFrame || Singleton<InputManager>.Instance.CurrentInputDevice == Dorfromantik.InputDevice.Gamepad)
		{
			return;
		}
		currentTileSlot = null;
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
			if (item.gameObject.layer == 8)
			{
				currentTileSlot = item.gameObject.GetComponent<TileSlot>();
			}
		}
		if (currentTileSlot != null && !currentTileSlot.IsValid)
		{
			currentTileSlot = null;
		}
	}

	private void OnDestroy()
	{
		sceneLoader.OnSceneLoaded -= UpdateInputCameraReference;
	}
}
