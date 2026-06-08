using System;
using Dorfromantik;
using UnityEngine;

public class InputRouter : ScriptableObject
{
	private TileSlot currentTileSlot;

	private Tile currentTile;

	[SerializeField]
	private InteractionRestriction interactionRestriction;

	private bool _003CIsSplashScreenActive_003Ek__BackingField;

	private bool _003CHighlightingQuests_003Ek__BackingField;

	private GameState _003CGameState_003Ek__BackingField;

	private ToolId _003CActiveTool_003Ek__BackingField;

	private bool isLoading;

	public bool IsLoading
	{
		get
		{
			if (!isLoading)
			{
				return IsSplashScreenActive;
			}
			return true;
		}
	}

	private bool IsSplashScreenActive
	{
		get
		{
			return _003CIsSplashScreenActive_003Ek__BackingField;
		}
		set
		{
			_003CIsSplashScreenActive_003Ek__BackingField = value;
		}
	}

	public bool HighlightingQuests
	{
		get
		{
			return _003CHighlightingQuests_003Ek__BackingField;
		}
		private set
		{
			_003CHighlightingQuests_003Ek__BackingField = value;
		}
	}

	public GameState GameState
	{
		get
		{
			return _003CGameState_003Ek__BackingField;
		}
		private set
		{
			_003CGameState_003Ek__BackingField = value;
		}
	}

	public InteractionRestriction InteractionRestriction => interactionRestriction;

	private bool IsDeletionModeEnabled => ActiveTool == ToolId.TileDeletion;

	private bool IsPipetteEnabled => ActiveTool == ToolId.Pipette;

	public ToolId ActiveTool
	{
		get
		{
			return _003CActiveTool_003Ek__BackingField;
		}
		private set
		{
			_003CActiveTool_003Ek__BackingField = value;
		}
	}

	public event Action<TileSlot> OnMovePreviewTile;

	public event Action<TileSlot> OnPlaceTile;

	public event Action<Tile> OnDeleteTile;

	public event Action<Vector2> OnChangeSelectedTileSlot;

	public event Action<Vector2> OnRadialMenuInput;

	public event Action OnRadialMenuSubmit;

	public event Action OnChangeSelectionInputStopped;

	public event Action OnMoveCameraToSelection;

	public event Action<ToolId, bool> OnToolEnabled;

	public event Action<ToolId, ISelectable> OnToolPreview;

	public event Action<ToolId> OnToolUsed;

	public event Action<Tile> OnPipettePick;

	public event Action OnUndo;

	public event Action<TileSlot> OnFillHole;

	public event Action<int> OnRotatePreviewTile;

	public event Action<Vector2> OnPanCamera;

	public event Action<Vector2> OnPanCameraLocalSpace;

	public event Action OnFinishPanCamera;

	public event Action<float> OnZoomCamera;

	public event Action<Vector2> OnSetCameraRotationPoint;

	public event Action<Vector2> OnRotateCamera;

	public event Action<GameState> OnInputStateChanged;

	public event Action OnFinishRotateCamera;

	public event Action OnResetCamera;

	public event Action<bool> OnOpenIngameMenu;

	public event Action<bool> OnHighlightQuests;

	public event Action OnToggleMenu;

	public event Action<bool, bool> OnShowRadialMenu;

	public event Action OnToggleRadialMenu;

	public event Action OnMenuCancel;

	public event Action<bool, bool> OnDiscardCurrentTile;

	public void PlaceTileOnCurrentSlot()
	{
		if (GameState == GameState.Playing && !IsLoading)
		{
			if (ActiveTool != ToolId.None)
			{
				UseTool(ActiveTool);
			}
			else if (!(currentTileSlot == null) && interactionRestriction.tileControlsAllowed && CameraUtility.IsVisibleByCamera(currentTileSlot.transform.position, OverwritingSingleton<IngameUi>.Instance.mainCamera, new Vector2(0.1f, 0.1f)))
			{
				this.OnPlaceTile?.Invoke(currentTileSlot);
			}
		}
	}

	public void MovePreviewTile(TileSlot targetTileSlot)
	{
		if ((GameState == GameState.Playing || GameState == GameState.RadialMenu) && !IsLoading && interactionRestriction.tileControlsAllowed && !(currentTileSlot == targetTileSlot))
		{
			currentTileSlot = targetTileSlot;
			this.OnMovePreviewTile?.Invoke(targetTileSlot);
		}
	}

	public void ChangeSelectedTileSlot(Vector2 targetDirection)
	{
		if (GameState == GameState.RadialMenu)
		{
			this.OnRadialMenuInput?.Invoke(targetDirection);
		}
		else if (GameState == GameState.Playing && interactionRestriction.tileControlsAllowed)
		{
			this.OnChangeSelectedTileSlot?.Invoke(targetDirection);
		}
	}

	public void StopTileSlotSelectionInput()
	{
		if (GameState == GameState.Playing && !IsLoading && interactionRestriction.tileControlsAllowed)
		{
			this.OnChangeSelectionInputStopped?.Invoke();
		}
	}

	public void RotatePreviewTile(float amount)
	{
		if (GameState == GameState.Playing && !IsLoading && interactionRestriction.tileControlsAllowed)
		{
			this.OnRotatePreviewTile?.Invoke(Mathf.RoundToInt(amount));
		}
	}

	public void RotatePreviewTileOrZoom(float amount)
	{
		if (GameState == GameState.Playing && !IsLoading)
		{
			if (!interactionRestriction.tileControlsAllowed)
			{
				ZoomCamera(amount);
			}
			else
			{
				RotatePreviewTile(amount);
			}
		}
	}

	public void DiscardCurrentPreviewTileFromInput(bool refillStack)
	{
		if (GameState == GameState.Playing && !IsLoading && interactionRestriction.tileControlsAllowed)
		{
			DiscardCurrentPreviewTile(refillStack);
		}
	}

	public void DiscardCurrentPreviewTile(bool refillStack, bool initial = false)
	{
		this.OnDiscardCurrentTile?.Invoke(refillStack, initial);
	}

	public void EnablePipetteMode(bool enablePipette)
	{
		if (enablePipette)
		{
			SwitchToTool(ToolId.Pipette);
		}
		else if (ActiveTool == ToolId.Pipette)
		{
			SwitchToTool(ToolId.None);
		}
	}

	public void EnableDeletionMode(bool enableDeletionMode)
	{
		if (enableDeletionMode)
		{
			SwitchToTool(ToolId.TileDeletion);
		}
		else if (ActiveTool == ToolId.TileDeletion)
		{
			SwitchToTool(ToolId.None);
		}
	}

	public void EnableHoleFillMode(bool enableHoleFill)
	{
		if (enableHoleFill)
		{
			SwitchToTool(ToolId.MatchingTile);
		}
		else if (ActiveTool == ToolId.MatchingTile)
		{
			SwitchToTool(ToolId.None);
		}
	}

	public void SwitchToTool(ToolId targetTool)
	{
		Debug.Log($"switch to tool {targetTool}? {ActiveTool}, {GameState}, {IsLoading}, {interactionRestriction.tileControlsAllowed}");
		if (ActiveTool == targetTool || (targetTool != ToolId.None && ((GameState != GameState.Playing && GameState != GameState.RadialMenu) || IsLoading)) || (targetTool != ToolId.None && !interactionRestriction.tileControlsAllowed))
		{
			return;
		}
		if (ActiveTool != ToolId.None)
		{
			ShowToolPreview(ActiveTool, null, targetTool == ToolId.None);
			this.OnToolEnabled?.Invoke(ActiveTool, arg2: false);
		}
		else
		{
			MovePreviewTile(null);
		}
		ActiveTool = targetTool;
		if (ActiveTool != ToolId.None)
		{
			if (ActiveTool == ToolId.MatchingTile)
			{
				ShowToolPreview(ActiveTool, currentTileSlot);
			}
			else
			{
				ShowToolPreview(ActiveTool, currentTile);
			}
		}
		this.OnToolEnabled?.Invoke(ActiveTool, arg2: true);
	}

	public void ShowPipettePreview(ISelectable hoverTile)
	{
		ShowToolPreview(ToolId.Pipette, hoverTile);
	}

	public void ShowDeletionPreview(ISelectable hoverTile)
	{
		ShowToolPreview(ToolId.TileDeletion, hoverTile);
	}

	public void ShowHoleFillPreview(ISelectable hoverTileSlot)
	{
		ShowToolPreview(ToolId.MatchingTile, hoverTileSlot);
	}

	public void ShowToolPreview(ToolId toolId, ISelectable newSelectable, bool updateCurrent = true)
	{
		if ((GameState == GameState.Playing || GameState == GameState.RadialMenu) && interactionRestriction.tileControlsAllowed && ActiveTool == toolId)
		{
			if (newSelectable == null)
			{
				currentTile = null;
				currentTileSlot = null;
			}
			else if (updateCurrent && newSelectable is Tile tile)
			{
				currentTile = tile;
			}
			else if (updateCurrent && newSelectable is TileSlot tileSlot)
			{
				currentTileSlot = tileSlot;
			}
			this.OnToolPreview?.Invoke(toolId, newSelectable);
		}
	}

	public void PipettePickCurrentTile()
	{
		UseTool(ToolId.Pipette);
	}

	public void Undo()
	{
		if (GameState == GameState.Playing && !IsLoading)
		{
			this.OnUndo?.Invoke();
		}
	}

	public void DeleteCurrentTile()
	{
		UseTool(ToolId.TileDeletion);
	}

	public void GenerateTileForCurrentTileslot()
	{
		UseTool(ToolId.MatchingTile);
	}

	public void UseTool(ToolId toolId)
	{
		if ((toolId == ToolId.MatchingTile || (bool)currentTile) && (toolId != ToolId.MatchingTile || (bool)currentTileSlot) && GameState == GameState.Playing && !IsLoading && interactionRestriction.tileControlsAllowed && ActiveTool == toolId)
		{
			switch (toolId)
			{
			case ToolId.Pipette:
				this.OnPipettePick?.Invoke(currentTile);
				EnablePipetteMode(enablePipette: false);
				break;
			case ToolId.TileDeletion:
				this.OnDeleteTile?.Invoke(currentTile);
				ShowDeletionPreview(null);
				break;
			case ToolId.MatchingTile:
				this.OnFillHole?.Invoke(currentTileSlot);
				break;
			}
			this.OnToolUsed?.Invoke(toolId);
		}
	}

	public void SetHoverTile(Tile newHoverTile)
	{
		currentTile = newHoverTile;
	}

	public void PanCamera(Vector2 panAmount)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && interactionRestriction.cameraControlsAllowed)
		{
			this.OnPanCamera?.Invoke(panAmount);
		}
	}

	public void PanCameraLocalSpace(Vector2 panAmount)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && interactionRestriction.cameraControlsAllowed)
		{
			this.OnPanCameraLocalSpace?.Invoke(panAmount);
		}
	}

	public void PanCameraHorizontally(float xMovement)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && interactionRestriction.cameraControlsAllowed)
		{
			this.OnPanCameraLocalSpace?.Invoke(new Vector2(xMovement, 0f));
		}
	}

	public void PanCameraVertically(float yMovement)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && interactionRestriction.cameraControlsAllowed)
		{
			this.OnPanCameraLocalSpace?.Invoke(new Vector2(0f, yMovement));
		}
	}

	public void FinishPanCamera()
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive)
		{
			this.OnFinishPanCamera?.Invoke();
		}
	}

	public void MoveCameraToSelection()
	{
		GameState gameState = GameState;
		if (gameState != GameState.Menu && gameState != GameState.RadialMenu && !IsSplashScreenActive && interactionRestriction.cameraControlsAllowed)
		{
			this.OnMoveCameraToSelection?.Invoke();
		}
	}

	public void ZoomCamera(float zoomAmount)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && (GameState != GameState.NavigationBar || Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard) && interactionRestriction.cameraControlsAllowed)
		{
			this.OnZoomCamera?.Invoke(zoomAmount);
		}
	}

	public void SetCameraRotationPoint()
	{
		SetCameraRotationPoint(Vector2.zero);
	}

	public void SetCameraRotationPoint(Vector2 rotationPoint)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && (GameState != GameState.NavigationBar || Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard))
		{
			this.OnSetCameraRotationPoint?.Invoke(rotationPoint);
		}
	}

	public void RotateCameraX(float rotateAmount)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && (GameState != GameState.NavigationBar || Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard) && interactionRestriction.cameraControlsAllowed)
		{
			RotateCamera(new Vector2(rotateAmount, 0f));
		}
	}

	public void RotateCamera(Vector2 rotateAmount)
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && (GameState != GameState.NavigationBar || Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard) && interactionRestriction.cameraControlsAllowed)
		{
			this.OnRotateCamera?.Invoke(rotateAmount);
		}
	}

	public void FinishRotateCamera()
	{
		if (GameState != GameState.Menu && !IsSplashScreenActive && (GameState != GameState.NavigationBar || Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard) && interactionRestriction.cameraControlsAllowed)
		{
			this.OnFinishRotateCamera?.Invoke();
		}
	}

	public void ResetCamera()
	{
		if (interactionRestriction.cameraControlsAllowed)
		{
			this.OnResetCamera?.Invoke();
		}
	}

	public void OpenIngameMenu(bool newOpen)
	{
		this.OnOpenIngameMenu?.Invoke(newOpen);
	}

	public void ToggleIngameMenu()
	{
		this.OnToggleMenu?.Invoke();
	}

	public void ShowRadialMenu(bool show)
	{
		ShowRadialMenu(show, executeSelectedCommand: true);
	}

	public void ShowRadialMenu(bool show, bool executeSelectedCommand)
	{
		GameState gameState = GameState;
		if (gameState != GameState.Menu && gameState != GameState.NavigationBar && !IsLoading)
		{
			this.OnShowRadialMenu?.Invoke(show, executeSelectedCommand);
		}
	}

	public void ToggleRadialMenu()
	{
		GameState gameState = GameState;
		if (gameState != GameState.Menu && gameState != GameState.NavigationBar && !IsLoading)
		{
			this.OnToggleRadialMenu?.Invoke();
		}
	}

	public void HighlightQuests(bool newHighlight)
	{
		if (newHighlight)
		{
			GameState gameState = GameState;
			if (gameState == GameState.Menu || gameState == GameState.NavigationBar)
			{
				return;
			}
		}
		if (!IsSplashScreenActive && (!newHighlight || interactionRestriction.tileControlsAllowed))
		{
			HighlightingQuests = newHighlight;
			this.OnHighlightQuests?.Invoke(newHighlight);
		}
	}

	public void MenuCancel()
	{
		this.OnMenuCancel?.Invoke();
	}

	public void SetInputState(GameState newGameState)
	{
		GameState = newGameState;
		this.OnInputStateChanged?.Invoke(newGameState);
	}

	public void SetInteractionRestriction(InteractionRestriction interactionRestriction)
	{
		this.interactionRestriction = interactionRestriction;
		Debug.LogWarning($"Set InteractionRestriction {interactionRestriction.cameraControlsAllowed} {interactionRestriction.tileControlsAllowed}");
		if (interactionRestriction.tileControlsAllowed && (bool)currentTileSlot)
		{
			MovePreviewTile(currentTileSlot);
		}
	}

	public void SetIsLoading(bool isLoading)
	{
		this.isLoading = isLoading;
	}

	public void SetIsSplashScreenActive(bool splashScreenActive)
	{
		IsSplashScreenActive = splashScreenActive;
	}
}
