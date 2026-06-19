using System;
using System.Collections.Generic;
using HighlightingSystem;
using I2.Loc;
using InControl;
using UnityEngine;

public static class ObjectPlacementManager
{
	public delegate void ObjectPlacedCallback();

	public enum SubMode
	{
		SELECT = 0,
		PLACE = 1,
		MOVE_SELECTED = 2,
		EDIT_SELECTED = 3,
		DESTROY = 4,
		IDLE = 5,
		PRUNE = 6
	}

	private static ObjectPlacedCallback OnObjectPlaced = null;

	public static bool debugVisDogs = false;

	public static bool debugVisIsolation = false;

	public static bool debugVisReservations = true;

	public static float GRID_SQUARE_SIZE = 1f;

	public static float PLANT_GRID_SQUARE_SIZE = 0.25f;

	public static float PUDDLE_GRID_SQUARE_SIZE = 1f;

	public static GameObject gridPlanePrefab;

	private static GameObject instantiatedGrid;

	private static Material gridMatRef;

	public static GameObject plantPrunedParticles;

	public static GameObject objectPlacementParticles;

	public static GameObject objectDestructionParticles;

	public static GameObject worldMessagePrefab;

	private static Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private static int gridX;

	private static int gridY;

	private static float gridSpacingX;

	private static float gridSpacingY;

	private static Vector2Int activeGridCell = new Vector2Int(0, 0);

	private static Vector3 yPosOffset = new Vector3(0f, -0.05f, 0f);

	private static SubMode currentSubMode = SubMode.IDLE;

	private static RaycastHit[] results = new RaycastHit[1000];

	private static PlacedObjectInfo currentlySelectedObject = null;

	private static PlacedObjectInfo currentlyHighlightedObject = null;

	private static PlacedObjectInfo storedObjectInfo;

	private static bool inPlacementMode = false;

	private static List<List<int>> placementGrid;

	private static RoomBase currentPlacementRoom = null;

	private static Vector2 grabOffsetPosition = Vector2.zero;

	private static int rotationValue = 0;

	private static float currentScaleValue = 1f;

	private static bool currentlyPlacingPlant = false;

	private static GameObject currentDraggableGhost = null;

	private static InventoryItem currentPreviewObjectOverride = null;

	private static RoomCustomizationObject currentPlacementObject = null;

	private static float scaleValueMin = 0.5f;

	private static float scaleValueMax = 2f;

	private static float scaleIncrement = 0.25f;

	private static Texture2D emptyTexture;

	private static Texture2D markedGridCellTexture;

	private static Texture2D specialGridCellTexture;

	private static Texture2D specialGridCellTexture2;

	private static Texture2D highlightedGridCellTexture;

	private static Texture2D highlightedGridCellTextureInvalid;

	private static string placementModeEnterSound = "placementModeEnter";

	private static string wallpaperPlacementSound = "place_wallpaper";

	private static string carpetPlacementSound = "place_carpet";

	private static string objectPlacementSound = "place_object";

	private static string objectDestroyedSound = "placement_destroy_object";

	private static string objectGrabbedSound = "placement_grab_object";

	private static string objectGrabbedFailureSound = "placement_grab_object_failure";

	private static string objectSelectedSound = "placement_new_object_selected";

	private static string objectRotatedSound = "placement_rotate_object";

	private static string plantRemovedSound = "placement_remove_plant";

	private static string scaleUpSound = "scale_up";

	private static string scaleDownSound = "scale_down";

	private static int requiredNeighbors = 2;

	private static int maxObstructionDist = 5;

	private static float minValidIsolationScore = 0.3f;

	private static List<List<float>> isolationGrid;

	private static List<List<ulong?>> plantGrid;

	private static List<List<ulong?>> puddleGrid;

	private static RoomCustomizationObject pruneModeBuildableObject = null;

	private static List<ulong> highlightedPlants = new List<ulong>();

	private static List<PlacedObjectInfo> highlightedPlantInfos = new List<PlacedObjectInfo>();

	private static List<ulong> highlightedPuddles = new List<ulong>();

	private static List<PlacedObjectInfo> highlightedPuddleInfos = new List<PlacedObjectInfo>();

	private static ulong placedPlantIDCounter = 0uL;

	private static ulong placedPuddleIDCounter = 0uL;

	private static ulong placedObjectIDCounter = 0uL;

	private static Camera cameraRef;

	private static NavmeshHelper navmeshRef;

	private static GUIManagerPens pensGUIRef;

	private static CursorController cursorRef;

	private static PlacementModeGUI placementGUIRef;

	private static ConstructionManager constructionRef;

	public static void OnStart()
	{
		cursorRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		pruneModeBuildableObject = ScriptableObject.CreateInstance<RoomCustomizationObject>();
		pruneModeBuildableObject.centerOffset = Vector3.zero;
		pruneModeBuildableObject.footprint = new Vector3(PLANT_GRID_SQUARE_SIZE, PLANT_GRID_SQUARE_SIZE, PLANT_GRID_SQUARE_SIZE);
	}

	public static ulong GetNewPlaceableID(bool isPlant, bool isPuddle)
	{
		ulong result;
		if (isPlant)
		{
			result = placedPlantIDCounter;
			placedPlantIDCounter++;
		}
		else if (isPuddle)
		{
			result = placedPuddleIDCounter;
			placedPuddleIDCounter++;
		}
		else
		{
			result = placedObjectIDCounter;
			placedObjectIDCounter++;
		}
		return result;
	}

	public static ulong GetCurrentPlaceableIDCounter()
	{
		return placedObjectIDCounter;
	}

	public static void SetPlaceableIDCounter(ulong newCounter)
	{
		placedObjectIDCounter = newCounter;
	}

	public static ulong GetCurrentPlantIDCounter()
	{
		return placedPlantIDCounter;
	}

	public static void SetPlantIDCounter(ulong newCounter)
	{
		placedPlantIDCounter = newCounter;
	}

	public static ulong GetCurrentPuddleIDCounter()
	{
		return placedPuddleIDCounter;
	}

	public static void SetPuddleIDCounter(ulong newCounter)
	{
		placedPuddleIDCounter = newCounter;
	}

	public static bool IsInPlacementMode()
	{
		return inPlacementMode;
	}

	public static bool IsPlacingObject()
	{
		if (!inPlacementMode)
		{
			return false;
		}
		if (currentSubMode == SubMode.PLACE || currentSubMode == SubMode.MOVE_SELECTED)
		{
			return true;
		}
		return false;
	}

	private static bool IsUIMousedOver()
	{
		return RaycastUtil.GlobalGUICheck();
	}

	public static void LoadSavedObject(RoomBase roomRef, SaveablePlacedObject savedObject, RoomCustomizationObject buildableRef)
	{
		OnEnterPlacementMode(roomRef);
		currentPlacementObject = buildableRef;
		if (savedObject.scaleValue == 0f)
		{
			savedObject.scaleValue = 1f;
		}
		PlaceObjectAtPosition(savedObject.gridPos.Load(), savedObject.rotationValue, savedObject.scaleValue, savedObject.GetCopy(), particles: false);
		OnExitPlacementMode();
	}

	public static void LoadSavedPlant(RoomBase roomRef, SaveablePlacedObject savedPlant, RoomCustomizationObject buildableRef)
	{
		currentPlacementObject = buildableRef;
		PlacePlant(roomRef, currentPlacementObject, savedPlant.gridPos.Load(), savedPlant.GetCopy());
	}

	public static void LoadSavedPuddle(RoomBase roomRef, SaveablePlacedObject savedPuddle, RoomCustomizationObject buildableRef)
	{
		currentPlacementObject = buildableRef;
		PlacePuddle(roomRef, currentPlacementObject, savedPuddle.gridPos.Load(), savedPuddle.GetCopy());
	}

	public static bool ReserveSpaceForObject(ulong reservingDogUID, RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell, ref Vector3 chosenPosition, int rotationValue = 0, float scaleValue = 1f)
	{
		if (!CanReserveSpaceForObject(roomRef, buildableRef, gridCell, ref chosenPosition, rotationValue, scaleValue))
		{
			return false;
		}
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, null, buildableRef, rotationValue);
		for (int i = 0; i < footprintGridSquares.Count; i++)
		{
			roomRef.ReserveTileForPlacement(footprintGridSquares[i], reservingDogUID);
		}
		return true;
	}

	public static bool CanReserveSpaceForObject(RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell, ref Vector3 chosenPosition, int rotationValue = 0, float scaleValue = 1f)
	{
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio);
		chosenPosition = GetPlacementPositionForGridCell(gridCell, buildableRef.footprint, buildableRef.centerOffset, _gridX, _gridY, _gridScale, _gridPos);
		List<List<int>> groundPlacementGrid;
		if (currentPlacementRoom != null && roomRef.gameObject.GetInstanceID() == currentPlacementRoom.gameObject.GetInstanceID())
		{
			groundPlacementGrid = placementGrid;
		}
		else
		{
			groundPlacementGrid = roomRef.GetGroundPlacementGrid();
			if (groundPlacementGrid.Count == 0)
			{
				InitializeGrids(_gridX, _gridY, groundPlacementGrid);
				groundPlacementGrid = roomRef.GetGroundPlacementGrid();
			}
		}
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, null, buildableRef, rotationValue, scaleValue);
		for (int i = 0; i < footprintGridSquares.Count; i++)
		{
			if (footprintGridSquares[i].x >= groundPlacementGrid.Count || footprintGridSquares[i].y >= groundPlacementGrid[footprintGridSquares[i].x].Count || footprintGridSquares[i].x < 0 || footprintGridSquares[i].y < 0)
			{
				return false;
			}
			if (groundPlacementGrid[footprintGridSquares[i].x][footprintGridSquares[i].y] == 1 || !roomRef.CanReserveTileForPlacement(footprintGridSquares[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static PlacedObjectInfo PlaceObjectManually(RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell, int rotationValue = 0, bool ignoreDogs = true, float scaleValue = 1f)
	{
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio);
		Vector3 placementPositionForGridCell = GetPlacementPositionForGridCell(gridCell, buildableRef.footprint, buildableRef.centerOffset, _gridX, _gridY, _gridScale, _gridPos, rotationValue, forPlants: false, forPuddles: false, scaleValue);
		GameObject gameObject = UnityEngine.Object.Instantiate(buildableRef.prefabObject, placementPositionForGridCell, Quaternion.Euler(0f, rotationValue, 0f));
		gameObject.transform.localScale = Vector3.one * scaleValue;
		PlacedObjectInfo placedObjectInfo = new PlacedObjectInfo(gameObject, buildableRef, gridCell, rotationValue, scaleValue);
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, placedObjectInfo, null, rotationValue, scaleValue);
		if (currentPlacementRoom != null && roomRef.gameObject.GetInstanceID() == currentPlacementRoom.gameObject.GetInstanceID())
		{
			MarkGrid(footprintGridSquares);
		}
		else
		{
			MarkGrid(footprintGridSquares, roomRef.GetGroundPlacementGrid(), roomRef.GetGroundIsolationGrid(), roomRef);
		}
		roomRef.OnObjectPlaced(placedObjectInfo, footprintGridSquares, null, ignoreDogs);
		return placedObjectInfo;
	}

	public static void RemoveObjectManually(PlacedObjectInfo infoRef, RoomBase roomRef)
	{
		if (infoRef == null)
		{
			return;
		}
		if (infoRef.customizationRef.objectType == CustomizationType.PLANT)
		{
			Debug.LogError("Shouldn't be possible to destroy plants this way.");
			return;
		}
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio);
		if (currentPlacementRoom != null && roomRef.gameObject.GetInstanceID() == currentPlacementRoom.gameObject.GetInstanceID())
		{
			ClearGrid(GetFootprintGridSquares(infoRef.gridPos, infoRef, null, infoRef.rotationValue, infoRef.scale));
		}
		else
		{
			ClearGrid(GetFootprintGridSquares(infoRef.gridPos, infoRef, null, infoRef.rotationValue, infoRef.scale), roomRef.GetGroundPlacementGrid(), roomRef.GetGroundIsolationGrid(), roomRef);
		}
		roomRef.OnObjectRemoved(infoRef, fromDestroy: true);
		UnityEngine.Object.Destroy(infoRef.objectRef);
		infoRef = null;
	}

	public static bool CanPlacePlant(RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell)
	{
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, null, buildableRef, 0, 1f, forPlants: true);
		for (int i = 0; i < footprintGridSquares.Count; i++)
		{
			if (!roomRef.IsPlantCellFree(footprintGridSquares[i]))
			{
				return false;
			}
		}
		List<Vector2Int> list = new List<Vector2Int>();
		for (int j = 0; j < footprintGridSquares.Count; j++)
		{
			Vector2Int placementGridSquareForPlantGridSquare = GetPlacementGridSquareForPlantGridSquare(footprintGridSquares[j]);
			if (!list.Contains(placementGridSquareForPlantGridSquare))
			{
				list.Add(placementGridSquareForPlantGridSquare);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			if (!roomRef.IsGroundPlacementCellFree(list[k]))
			{
				return false;
			}
		}
		return true;
	}

	public static PlacedObjectInfo PlacePlant(RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell, SaveablePlacedObject existingObject = null, bool clearExistingPlants = false)
	{
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio, forPlants: true);
		if (roomRef.GetPlantGrid().Count == 0)
		{
			InitializePlantGrid(_gridX, _gridY, roomRef.GetPlantGrid());
		}
		Vector3 placementPositionForGridCell = GetPlacementPositionForGridCell(gridCell, buildableRef.footprint, buildableRef.centerOffset, _gridX, _gridY, _gridScale, _gridPos, 0, forPlants: true, forPuddles: false, 1f);
		PlacedObjectInfo placedObjectInfo = new PlacedObjectInfo(UnityEngine.Object.Instantiate(buildableRef.prefabObject, placementPositionForGridCell, Quaternion.Euler(0f, 0f, 0f)), buildableRef, gridCell, 0, 1f);
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, placedObjectInfo, null, 0, 1f, forPlants: true);
		roomRef.OnObjectPlaced(placedObjectInfo, footprintGridSquares, existingObject, ignoreDogs: false, plant: true, puddle: false, clearExistingPlants);
		MarkPlantGrid(footprintGridSquares, roomRef.GetPlantGrid(), placedObjectInfo.objectID.Value);
		return placedObjectInfo;
	}

	public static void RemovePlantManually(PlacedObjectInfo infoRef, RoomBase roomRef)
	{
		if (infoRef == null)
		{
			return;
		}
		if (infoRef.customizationRef.objectType != CustomizationType.PLANT)
		{
			Debug.LogError("Attempting to call RemovePlant() on something that is not a plant! " + infoRef);
			return;
		}
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio, forPlants: true);
		if (roomRef.GetPlantGrid().Count == 0)
		{
			InitializePlantGrid(_gridX, _gridY, roomRef.GetPlantGrid());
		}
		if (infoRef.objectRef != null)
		{
			UnityEngine.Object.Instantiate(plantPrunedParticles, infoRef.objectRef.transform.position, Quaternion.identity);
		}
		ClearPlantGrid(GetFootprintGridSquares(infoRef.gridPos, infoRef, null, infoRef.rotationValue, infoRef.scale, forPlants: true), roomRef.GetPlantGrid());
		roomRef.OnObjectRemoved(infoRef, fromDestroy: true, fromRoomDestruction: false, forPlants: true);
		UnityEngine.Object.Destroy(infoRef.objectRef);
		infoRef = null;
	}

	public static bool CanPlacePuddle(RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell)
	{
		if (roomRef.GetPuddleGrid().Count == 0)
		{
			int _gridX = 0;
			int _gridY = 0;
			float _XYRatio = 0f;
			Vector3 _gridPos = Vector3.zero;
			Vector3 _gridScale = Vector3.zero;
			GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio, forPlants: false, forPuddles: true);
			InitializePuddleGrid(_gridX, _gridY, roomRef.GetPuddleGrid());
		}
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, null, buildableRef, 0, 1f, forPlants: false, forPuddles: true);
		for (int i = 0; i < footprintGridSquares.Count; i++)
		{
			if (!roomRef.IsPuddleCellFree(footprintGridSquares[i]))
			{
				return false;
			}
		}
		List<Vector2Int> list = new List<Vector2Int>();
		for (int j = 0; j < footprintGridSquares.Count; j++)
		{
			Vector2Int placementGridSquareForPuddleGridSquare = GetPlacementGridSquareForPuddleGridSquare(footprintGridSquares[j]);
			if (!list.Contains(placementGridSquareForPuddleGridSquare))
			{
				list.Add(placementGridSquareForPuddleGridSquare);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			if (!roomRef.IsGroundPlacementCellFree(list[k]))
			{
				return false;
			}
		}
		return true;
	}

	public static PlacedObjectInfo PlacePuddle(RoomBase roomRef, RoomCustomizationObject buildableRef, Vector2Int gridCell, SaveablePlacedObject existingObject = null)
	{
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio, forPlants: false, forPuddles: true);
		if (roomRef.GetPuddleGrid().Count == 0)
		{
			InitializePuddleGrid(_gridX, _gridY, roomRef.GetPuddleGrid());
		}
		Vector3 placementPositionForGridCell = GetPlacementPositionForGridCell(gridCell, buildableRef.footprint, buildableRef.centerOffset, _gridX, _gridY, _gridScale, _gridPos, 0, forPlants: false, forPuddles: true, 1f);
		PlacedObjectInfo placedObjectInfo = new PlacedObjectInfo(UnityEngine.Object.Instantiate(buildableRef.prefabObject, placementPositionForGridCell, Quaternion.Euler(0f, 0f, 0f)), buildableRef, gridCell, 0, 1f);
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridCell, placedObjectInfo, null, 0, 1f, forPlants: false, forPuddles: true);
		roomRef.OnObjectPlaced(placedObjectInfo, footprintGridSquares, existingObject, ignoreDogs: false, plant: false, puddle: true);
		MarkPuddleGrid(footprintGridSquares, roomRef.GetPuddleGrid(), placedObjectInfo.objectID.Value);
		return placedObjectInfo;
	}

	public static void RemovePuddleManually(PlacedObjectInfo infoRef, RoomBase roomRef)
	{
		if (infoRef == null)
		{
			return;
		}
		if (infoRef.customizationRef.objectType != CustomizationType.PUDDLE)
		{
			Debug.LogError("Attempting to call RemovePuddle() on something that is not a puddle! " + infoRef);
			return;
		}
		int _gridX = 0;
		int _gridY = 0;
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio, forPlants: false, forPuddles: true);
		if (roomRef.GetPuddleGrid().Count == 0)
		{
			InitializePuddleGrid(_gridX, _gridY, roomRef.GetPuddleGrid());
		}
		ClearPuddleGrid(GetFootprintGridSquares(infoRef.gridPos, infoRef, null, infoRef.rotationValue, infoRef.scale, forPlants: false, forPuddles: true), roomRef.GetPuddleGrid());
		roomRef.OnObjectRemoved(infoRef, fromDestroy: true, fromRoomDestruction: false, forPlants: false, forPuddles: true);
		UnityEngine.Object.Destroy(infoRef.objectRef);
		infoRef = null;
	}

	public static void ApplyCarpetToRoom(RoomCustomizationObject newCarpet)
	{
		currentPlacementRoom.ApplyCarpet(newCarpet);
		AudioController.Play(carpetPlacementSound);
	}

	public static void ApplyWallpaperToRoom(RoomCustomizationObject newWallpaper)
	{
		currentPlacementRoom.ApplyWallpaper(newWallpaper);
		AudioController.Play(wallpaperPlacementSound);
	}

	public static void SetDraggableObjectPrefab(RoomCustomizationObject obj, bool isPlant = false, InventoryItem previewObjectOverride = null)
	{
		currentPlacementObject = obj;
		currentlyPlacingPlant = isPlant;
		currentPreviewObjectOverride = previewObjectOverride;
		SetPlacementGridVisibility(val: true);
	}

	public static GameObject GetPlacementGrid()
	{
		return instantiatedGrid;
	}

	public static void SetPlacementModeGUIRef(PlacementModeGUI newRef)
	{
		placementGUIRef = newRef;
	}

	public static void HandlePlacementModeInput()
	{
		if (currentPlacementRoom == null)
		{
			OnExitPlacementMode();
			return;
		}
		switch (currentSubMode)
		{
		case SubMode.IDLE:
			HandleSubModeIdleInput();
			break;
		case SubMode.SELECT:
			HandleSubModeSelectInput();
			break;
		case SubMode.MOVE_SELECTED:
			HandleSubModeMoveSelectedInput();
			break;
		case SubMode.EDIT_SELECTED:
			HandleSubModeEditSelectedInput();
			break;
		case SubMode.PLACE:
			HandleSubModePlacementInput();
			break;
		case SubMode.DESTROY:
			HandleDestroyModeInput();
			break;
		case SubMode.PRUNE:
			HandlePruneModeInput();
			break;
		}
		DisplayDogPositions();
		DisplayReservations();
	}

	public static void GoBackAMode()
	{
		if (placementGUIRef.IsDenInfoWindowActive())
		{
			placementGUIRef.CloseDenInfoWindow();
			return;
		}
		switch (currentSubMode)
		{
		case SubMode.IDLE:
			GetConstructionRef().SetConstructionMode(ConstructionManager.CurrentMode.CONSTRUCTION);
			break;
		case SubMode.SELECT:
			ShowPlacementPanels();
			break;
		case SubMode.MOVE_SELECTED:
			ShowPlacementPanels();
			break;
		case SubMode.EDIT_SELECTED:
			ShowPlacementPanels();
			break;
		case SubMode.PLACE:
			ShowPlacementPanels();
			break;
		case SubMode.DESTROY:
			ShowPlacementPanels();
			break;
		case SubMode.PRUNE:
			ShowPlacementPanels();
			break;
		}
	}

	private static void HandleDestroyModeInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
			return;
		}
		if (IsUIMousedOver())
		{
			RemoveObjectHighlight();
			return;
		}
		if (currentlySelectedObject == null)
		{
			CheckForNewHighlightedObject();
		}
		if (currentlySelectedObject == null)
		{
			CheckForNewDeletedObject();
		}
	}

	private static void HandlePruneModeInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
			return;
		}
		ClearPlantHighlights();
		if (!IsUIMousedOver() && plantGrid.Count != 0)
		{
			CheckForNewHighlightedObject(forPlants: true);
			if (GameControls.actions.Interact.IsPressed && currentlyHighlightedObject != null)
			{
				RemovePlantManually(currentlyHighlightedObject, currentPlacementRoom);
				ClearPlantHighlights();
				currentlyHighlightedObject = null;
				AudioController.Play(plantRemovedSound);
			}
		}
	}

	private static void HandleSubModeIdleInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
		}
	}

	private static void HandleSubModeSelectInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
			return;
		}
		if (IsUIMousedOver())
		{
			RemoveObjectHighlight();
			return;
		}
		if (currentlySelectedObject == null)
		{
			CheckForNewHighlightedObject();
		}
		if (currentlySelectedObject == null)
		{
			CheckForNewSelectedObject();
		}
	}

	private static void HandleSubModeMoveSelectedInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
			return;
		}
		if (IsUIMousedOver())
		{
			HideGhost();
			return;
		}
		if (currentlySelectedObject == null)
		{
			SetSubMode(SubMode.SELECT);
			return;
		}
		HandleDraggedObjectInput(currentlySelectedObject);
		CheckSelectionPlacement();
		CheckSelectionDeletion();
	}

	private static void HandleSubModeEditSelectedInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
		}
		else if (currentlySelectedObject == null)
		{
			SetSubMode(SubMode.SELECT);
		}
	}

	private static void HandleSubModePlacementInput()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !GetPenGUIRef().IsPopupLockActive())
		{
			GoBackAMode();
			return;
		}
		if (IsUIMousedOver())
		{
			HideGhost();
			return;
		}
		HandleDraggedObjectInput(null, currentPlacementObject);
		CheckPlacement();
	}

	private static void HandleDraggedObjectInput(PlacedObjectInfo placeableObjectRef = null, RoomCustomizationObject buildableRef = null, bool forceRefresh = false)
	{
		if (!IsUIMousedOver())
		{
			bool flag = CheckScale(placeableObjectRef, buildableRef);
			bool flag2 = CheckRotation(placeableObjectRef, buildableRef);
			DetermineActiveGridCellForNewPlaceableObject(forceRefresh || flag2 || flag);
			UpdateDraggableGhost();
		}
	}

	public static void SetObjectPlacedCallback(ObjectPlacedCallback newCallback)
	{
		OnObjectPlaced = newCallback;
	}

	public static SubMode GetSubMode()
	{
		return currentSubMode;
	}

	public static RoomBase GetCurrentPlacementRoom()
	{
		return currentPlacementRoom;
	}

	public static void SetSubMode(SubMode newMode, bool playSounds = false, bool forDestroy = false)
	{
		OnExitSubMode(currentSubMode);
		currentSubMode = newMode;
		switch (newMode)
		{
		case SubMode.IDLE:
			OnEnterSubModeIdle();
			break;
		case SubMode.PLACE:
			OnEnterSubModePlace(playSounds);
			break;
		case SubMode.SELECT:
			OnEnterSubModeSelect();
			break;
		case SubMode.EDIT_SELECTED:
			OnEnterSubModeEdit();
			break;
		case SubMode.MOVE_SELECTED:
			OnEnterSubModeMove(forDestroy);
			break;
		case SubMode.DESTROY:
			OnEnterSubModeDestroy();
			break;
		case SubMode.PRUNE:
			OnEnterSubModePrune();
			break;
		}
	}

	private static void OnExitSubMode(SubMode oldMode)
	{
		switch (oldMode)
		{
		case SubMode.IDLE:
			OnExitSubModeIdle();
			break;
		case SubMode.PLACE:
			OnExitSubModePlace();
			break;
		case SubMode.SELECT:
			OnExitSubModeSelect();
			break;
		case SubMode.EDIT_SELECTED:
			OnExitSubModeEdit();
			break;
		case SubMode.MOVE_SELECTED:
			OnExitSubModeMove();
			break;
		case SubMode.DESTROY:
			OnExitSubModeDestroy();
			break;
		case SubMode.PRUNE:
			OnExitSubModePrune();
			break;
		}
	}

	private static void OnEnterSubModeDestroy()
	{
		SetPlacementGridVisibility(val: true);
	}

	private static void OnEnterSubModePrune()
	{
		SetPlacementGridVisibility(val: true);
		currentPlacementObject = pruneModeBuildableObject;
	}

	private static void OnExitSubModeDestroy()
	{
	}

	private static void OnExitSubModePrune()
	{
		currentPlacementObject = null;
	}

	private static void OnEnterSubModeIdle()
	{
		SetPlacementGridVisibility(val: false);
	}

	private static void OnExitSubModeIdle()
	{
	}

	private static void OnEnterSubModePlace(bool playSounds)
	{
		OnObjectPlaced = null;
		CancelObjectSelection();
		rotationValue = 0;
		currentScaleValue = 1f;
		CreateGhost();
		SetPlacementGridVisibility(val: true);
		placementGUIRef.ShowPlacementControls();
		if (currentPreviewObjectOverride != null)
		{
			placementGUIRef.ShowActiveObjectPanel(currentPreviewObjectOverride);
		}
		else
		{
			placementGUIRef.ShowActiveObjectPanel(currentPlacementObject);
		}
		if (playSounds)
		{
			AudioController.Play(objectSelectedSound);
		}
	}

	private static void OnExitSubModePlace()
	{
		RemoveGhost();
		currentlyPlacingPlant = false;
		placementGUIRef.HidePlacementControls();
		placementGUIRef.HideActiveObjectPanel();
	}

	private static void OnEnterSubModeSelect()
	{
		SetPlacementGridVisibility(val: true);
	}

	private static void OnEnterSubModeMove(bool forDestroy = false)
	{
		MoveSelectedObject(forDestroy);
		SetPlacementGridVisibility(val: true);
		if (placementGUIRef != null)
		{
			placementGUIRef.ShowPlacementControls();
		}
	}

	private static void OnEnterSubModeEdit()
	{
		SetPlacementGridVisibility(val: true);
		currentlySelectedObject.objectRef.GetComponent<PlaceableObject>().RunEditStartEvents();
	}

	private static void OnExitSubModeSelect()
	{
		HideSelectionGUI();
	}

	private static void OnExitSubModeEdit()
	{
		currentlySelectedObject.objectRef.GetComponent<PlaceableObject>().RunEditEndEvents();
	}

	private static void OnExitSubModeMove()
	{
		if (placementGUIRef != null)
		{
			placementGUIRef.HidePlacementControls();
		}
		grabOffsetPosition = Vector2.zero;
		if (currentlySelectedObject != null)
		{
			PlaceSelectedObject(currentlySelectedObject.gridPos, currentlySelectedObject.rotationValue, currentlySelectedObject.scale);
		}
	}

	private static void CheckForNewSelectedObject()
	{
		if (currentlyHighlightedObject == null || !GameControls.actions.Interact.WasPressed)
		{
			return;
		}
		PlaceableObject component = currentlyHighlightedObject.objectRef.GetComponent<PlaceableObject>();
		if (!component.canBeMoved)
		{
			AudioController.Play(objectGrabbedFailureSound);
			return;
		}
		if (component.isDen)
		{
			DogDen component2 = currentlyHighlightedObject.objectRef.GetComponent<DogDen>();
			if (component2 == null || !component2.CanBeMovedManually())
			{
				AudioController.Play(objectGrabbedFailureSound);
				return;
			}
		}
		AudioController.Play(objectGrabbedSound);
		SelectObject(currentlyHighlightedObject);
	}

	private static void DisplayImmovableObjectError(GameObject obj)
	{
		BoundingBoxComponent component = obj.GetComponent<BoundingBoxComponent>();
		GameObject gameObject = UnityEngine.Object.Instantiate(worldMessagePrefab, component.GetBoxCenter() + messageOffset, Quaternion.identity);
		gameObject.transform.localScale = Vector3.one;
		WorldMessage component2 = gameObject.GetComponent<WorldMessage>();
		component2.SetFadeTime(1.5f);
		component2.SetDisplayColor(Color.red);
		component2.SetDisplayMessage(ScriptLocalization.GUI.GUI_MESSAGE_IMMOVABLE);
	}

	private static void CheckForNewDeletedObject()
	{
		if (currentlyHighlightedObject == null || !GameControls.actions.Interact.WasPressed)
		{
			return;
		}
		if (currentlyHighlightedObject.objectRef != null && currentlyHighlightedObject.objectRef.CompareTag(Tags.DOG_DEN))
		{
			GUIManagerPens penGUIRef = GetPenGUIRef();
			if (penGUIRef != null)
			{
				if (storedObjectInfo != null)
				{
					Debug.LogError("Double setting storedObjectInfo");
				}
				DogDen component = currentlyHighlightedObject.objectRef.GetComponent<DogDen>();
				if (component != null)
				{
					ShowDestructionPopupForDen(currentlyHighlightedObject, component, penGUIRef);
				}
			}
		}
		else if (currentlyHighlightedObject.objectRef != null && currentlyHighlightedObject.objectRef.CompareTag(Tags.STORAGE_CHEST))
		{
			GUIManagerPens penGUIRef2 = GetPenGUIRef();
			if (penGUIRef2 != null)
			{
				if (storedObjectInfo != null)
				{
					Debug.LogError("Double setting storedObjectInfo");
				}
				StorageChest component2 = currentlyHighlightedObject.objectRef.GetComponent<StorageChest>();
				if (component2 != null)
				{
					ShowDestructionPopupForChest(currentlyHighlightedObject, component2, penGUIRef2);
				}
			}
		}
		else
		{
			FinalizeDestroyViaDeleteMode(currentlyHighlightedObject);
		}
	}

	private static void ShowDestructionPopupForDen(PlacedObjectInfo infoRef, DogDen denRef, GUIManagerPens guiRef)
	{
		storedObjectInfo = infoRef;
		string message = ScriptLocalization.GUI.GUI_PLCMNT_DENWARNING_BODY;
		if (!denRef.IsCompleted())
		{
			message = ScriptLocalization.GUI.GUI_PLCMNT_DIRTPATCHWARNING_BODY;
		}
		guiRef.RequestGenericPopup(ScriptLocalization.GUI.GUI_PLCMNT_DENWARNING_HEADER, message, ConfirmDestruction, CancelDestruction);
	}

	private static void ShowDestructionPopupForChest(PlacedObjectInfo infoRef, StorageChest chestRef, GUIManagerPens guiRef)
	{
		storedObjectInfo = infoRef;
		if (chestRef.IsEmpty())
		{
			ConfirmDestruction();
			return;
		}
		string gUI_PLCMNT_CHESTWARNING_BODY = ScriptLocalization.GUI.GUI_PLCMNT_CHESTWARNING_BODY;
		guiRef.RequestGenericPopup(ScriptLocalization.GUI.GUI_PLCMNT_DENWARNING_HEADER, gUI_PLCMNT_CHESTWARNING_BODY, ConfirmDestruction, CancelDestruction);
	}

	private static void ConfirmDestruction()
	{
		FinalizeDestroyViaDeleteMode(storedObjectInfo);
		storedObjectInfo = null;
	}

	private static void CancelDestruction()
	{
		storedObjectInfo = null;
		if (placementGUIRef != null)
		{
			placementGUIRef.OnSelectButtonPressed();
		}
		else
		{
			SetSubMode(SubMode.SELECT);
		}
	}

	public static void ShowMassCleanPopup(GUIManagerPens guiRef)
	{
		guiRef.RequestGenericPopup(ScriptLocalization.GUI.GUI_PLCMNT_CLEANINGHEADER, ScriptLocalization.GUI.GUI_PLCMNT_CLEANINGBODY, ConfirmMassClean, null, cancelKeyAllowed: true);
	}

	private static void ConfirmMassClean()
	{
		currentPlacementRoom.MassClean();
	}

	private static void FinalizeDestroyViaDeleteMode(PlacedObjectInfo objectToDestroy)
	{
		AudioController.Play(objectDestroyedSound);
		SelectObject(objectToDestroy, forDestroy: true);
		DestroySelectedObject();
		if (placementGUIRef != null)
		{
			placementGUIRef.OnDestroyButtonPressed();
		}
		else
		{
			SetSubMode(SubMode.DESTROY);
		}
	}

	public static void SelectObject(PlacedObjectInfo info, bool forDestroy = false)
	{
		RemoveObjectHighlight();
		currentlySelectedObject = info;
		SetSubMode(SubMode.MOVE_SELECTED, playSounds: false, forDestroy);
	}

	public static void MoveSelectedObject(bool forDestroy = false)
	{
		if (currentlySelectedObject == null)
		{
			Debug.LogError("Attempting to move the selected object but none exists.");
			return;
		}
		currentPlacementRoom.OnObjectRemoved(currentlySelectedObject, forDestroy);
		currentScaleValue = currentlySelectedObject.scale;
		rotationValue = currentlySelectedObject.rotationValue;
		currentPlacementObject = currentlySelectedObject.customizationRef;
		ClearGrid(GetFootprintGridSquares(currentlySelectedObject.gridPos, currentlySelectedObject, null, rotationValue, currentScaleValue));
		Vector3 position = GetPositionForGridCell(currentlySelectedObject.gridPos) + new Vector3(GRID_SQUARE_SIZE / 2f, 0f, GRID_SQUARE_SIZE / 2f);
		Vector3 vector = InputManager.MouseProvider.GetPosition();
		Vector3 vector2 = GetCameraRef().WorldToScreenPoint(position);
		grabOffsetPosition = vector - vector2;
		CreateGhost();
		if (!forDestroy)
		{
			DogDen component = currentlySelectedObject.objectRef.GetComponent<DogDen>();
			if (component != null)
			{
				component.ExpelDogs();
				navmeshRef.RemovePortalForDenUID(component.GetComponent<PlacedObjectID>().GetUID());
			}
		}
		currentlySelectedObject.objectRef.SetActive(value: false);
		HandleDraggedObjectInput(currentlySelectedObject, null, forceRefresh: true);
	}

	private static void CheckForNewHighlightedObject(bool forPlants = false)
	{
		if (GetPenGUIRef() != null && !GetPenGUIRef().GetGUIInteractiveStatus())
		{
			RemoveObjectHighlight();
			return;
		}
		Vector3 pos = new Vector3(InputManager.MouseProvider.GetPosition().x, InputManager.MouseProvider.GetPosition().y, 100f);
		Ray ray = GetCameraRef().ScreenPointToRay(pos);
		int num = RaycastUtil.GoodRaycastAllNonAlloc(ray, results);
		if (num == 0)
		{
			RemoveObjectHighlight();
			return;
		}
		RaycastHit closestHitIgnoringObject = RaycastUtil.GetClosestHitIgnoringObject(num, ray.origin, results, instantiatedGrid, allowDisabledRenderers: false, allowPipes: false);
		if (closestHitIgnoringObject.transform == null)
		{
			RemoveObjectHighlight();
			return;
		}
		GameObject gameObject = closestHitIgnoringObject.transform.root.gameObject;
		PlacedObjectInfo placedObjectInfoForObject = currentPlacementRoom.GetPlacedObjectInfoForObject(gameObject, forPlants);
		if (placedObjectInfoForObject == null)
		{
			RemoveObjectHighlight();
		}
		else
		{
			AddObjectHighlight(placedObjectInfoForObject);
		}
	}

	private static void CancelObjectSelection()
	{
		HideSelectionGUI();
		RemoveObjectHighlight();
		if (currentlySelectedObject != null)
		{
			PlaceSelectedObject(currentlySelectedObject.gridPos, currentlySelectedObject.rotationValue, currentlySelectedObject.scale);
		}
	}

	private static void PlaceSelectedObject(Vector2Int gridPos, int rotation, float scale)
	{
		if (currentlySelectedObject != null)
		{
			rotationValue = rotation;
			currentScaleValue = scale;
			currentlySelectedObject.scale = scale;
			currentlySelectedObject.gridPos = gridPos;
			currentlySelectedObject.rotationValue = rotation;
			List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridPos, currentlySelectedObject, null, rotationValue, currentScaleValue);
			MarkGrid(footprintGridSquares);
			currentlySelectedObject.objectRef.SetActive(value: true);
			currentlySelectedObject.objectRef.transform.localScale = Vector3.one * scale;
			currentlySelectedObject.objectRef.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
			currentlySelectedObject.objectRef.transform.position = GetPlacementPositionForGridCell(gridPos, currentlySelectedObject.customizationRef.footprint, currentlySelectedObject.customizationRef.centerOffset, null, null, null, null, null, forPlants: false, forPuddles: false, currentScaleValue);
			UnityEngine.Object.Instantiate(objectPlacementParticles, currentlySelectedObject.objectRef.transform.position, Quaternion.identity);
			currentPlacementRoom.OnObjectPlaced(currentlySelectedObject, footprintGridSquares);
			if (currentlySelectedObject.objectRef.GetComponent<DogDen>() != null)
			{
				navmeshRef.AddPortalForDen(currentlySelectedObject.objectRef);
			}
			currentlySelectedObject = null;
			RemoveGhost();
		}
	}

	private static void AddPlantHighlight(PlacedObjectInfo info)
	{
		if (!highlightedPlants.Contains(info.objectID.Value))
		{
			highlightedPlantInfos.Add(info);
			highlightedPlants.Add(info.objectID.Value);
			PlaceableObject component = info.objectRef.GetComponent<PlaceableObject>();
			component.SetState(PlaceableObjectState.SELECTED_FOR_DELETE);
			component.SetMaterials(placementGUIRef.GetMaterialForObjectState(PlaceableObjectState.SELECTED_FOR_DELETE));
		}
	}

	private static void RemovePlantHighlight(PlacedObjectInfo info)
	{
		if (highlightedPlants.Contains(info.objectID.Value))
		{
			highlightedPlantInfos.RemoveAt(highlightedPlants.IndexOf(info.objectID.Value));
			highlightedPlants.Remove(info.objectID.Value);
			if (!(info.objectRef == null))
			{
				PlaceableObject component = info.objectRef.GetComponent<PlaceableObject>();
				component.SetState(PlaceableObjectState.DEFAULT);
				component.RestoreMaterials();
			}
		}
	}

	private static void ClearPlantHighlights()
	{
		for (int num = highlightedPlantInfos.Count - 1; num >= 0; num--)
		{
			RemovePlantHighlight(highlightedPlantInfos[num]);
		}
		highlightedPlants.Clear();
		highlightedPlantInfos.Clear();
	}

	private static void AddPuddleHighlight(PlacedObjectInfo info)
	{
		if (!highlightedPuddles.Contains(info.objectID.Value))
		{
			highlightedPuddleInfos.Add(info);
			highlightedPuddles.Add(info.objectID.Value);
			PlaceableObject component = info.objectRef.GetComponent<PlaceableObject>();
			component.SetState(PlaceableObjectState.SELECTED_FOR_DELETE);
			component.SetMaterials(placementGUIRef.GetMaterialForObjectState(PlaceableObjectState.SELECTED_FOR_DELETE));
		}
	}

	private static void RemovePuddleHighlight(PlacedObjectInfo info)
	{
		if (highlightedPuddles.Contains(info.objectID.Value))
		{
			highlightedPuddleInfos.RemoveAt(highlightedPuddles.IndexOf(info.objectID.Value));
			highlightedPuddles.Remove(info.objectID.Value);
			if (!(info.objectRef == null))
			{
				PlaceableObject component = info.objectRef.GetComponent<PlaceableObject>();
				component.SetState(PlaceableObjectState.DEFAULT);
				component.RestoreMaterials();
			}
		}
	}

	private static void ClearPuddleHighlights()
	{
		for (int num = highlightedPuddleInfos.Count - 1; num >= 0; num--)
		{
			RemovePuddleHighlight(highlightedPuddleInfos[num]);
		}
		highlightedPuddles.Clear();
		highlightedPuddleInfos.Clear();
	}

	private static void AddObjectHighlight(PlacedObjectInfo info)
	{
		RemoveObjectHighlight();
		PlaceableObject component = info.objectRef.GetComponent<PlaceableObject>();
		Highlighter highlighter = info.objectRef.GetComponent<Highlighter>();
		if (highlighter == null)
		{
			highlighter = info.objectRef.AddComponent<Highlighter>();
			highlighter.overlay = true;
		}
		bool flag = true;
		if (!component.canBeMoved && currentSubMode == SubMode.SELECT)
		{
			flag = false;
		}
		else if (component.isDen && currentSubMode == SubMode.SELECT)
		{
			DogDen component2 = info.objectRef.GetComponent<DogDen>();
			if (component2 == null || !component2.CanBeMovedManually())
			{
				flag = false;
			}
		}
		if (flag)
		{
			highlighter.ConstantOnImmediate(Color.blue);
		}
		currentlyHighlightedObject = info;
		PlaceableObjectState state = PlaceableObjectState.SELECTED_FOR_MOVE;
		if (currentSubMode == SubMode.DESTROY || currentSubMode == SubMode.PRUNE)
		{
			state = PlaceableObjectState.SELECTED_FOR_DELETE;
		}
		if (flag)
		{
			component.SetState(state);
			component.SetMaterials(placementGUIRef.GetMaterialForObjectState(state));
		}
		else
		{
			state = PlaceableObjectState.INVALID_PLACEMENT;
			component.SetState(state);
			component.SetMaterials(placementGUIRef.GetMaterialForObjectState(state));
		}
		if (currentSubMode == SubMode.DESTROY || currentSubMode == SubMode.PRUNE)
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
		}
		else if (flag)
		{
			cursorRef.SetCursor(CursorController.CursorType.GRABBABLE);
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
		}
	}

	private static void RemoveObjectHighlight()
	{
		if (currentlyHighlightedObject != null && !(currentlyHighlightedObject.objectRef == null))
		{
			PlaceableObject component = currentlyHighlightedObject.objectRef.GetComponent<PlaceableObject>();
			component.SetState(PlaceableObjectState.DEFAULT);
			component.RestoreMaterials();
			currentlyHighlightedObject.objectRef.GetComponent<Highlighter>().ConstantOffImmediate();
			currentlyHighlightedObject = null;
		}
	}

	private static void CreateGhost()
	{
		RemoveGhost();
		currentDraggableGhost = UnityEngine.Object.Instantiate(currentPlacementObject.prefabObject);
		currentDraggableGhost.name = "Draggable Object Ghost";
		DogDen component = currentDraggableGhost.GetComponent<DogDen>();
		if (component != null)
		{
			component.SetStage(DenStage.STAGE_1, null, fromPlacementGhost: true);
			component.ApplyDenUpgrade(currentlySelectedObject.objectRef.GetComponent<DogDen>().GetCurrentDenUpgrade(), fromLoad: true);
			component = null;
		}
		ObjectUtil.SetAllColliders(currentDraggableGhost, enabledVal: false);
		ObjectUtil.RemoveAllComponents<Joint>(currentDraggableGhost);
		ObjectUtil.RemoveAllComponents<Rigidbody>(currentDraggableGhost);
		ObjectUtil.RemoveAllComponents<MonoBehaviour>(currentDraggableGhost);
		if (currentlySelectedObject != null)
		{
			Growable component2 = currentDraggableGhost.GetComponent<Growable>();
			if (component2 != null)
			{
				component2.CopyGrowable(currentlySelectedObject.objectRef.GetComponent<Growable>());
			}
		}
		currentDraggableGhost.AddComponent<PlaceableObject>();
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnPlacementStart(currentPlacementObject);
		}
	}

	private static void HideGhost()
	{
		if (currentDraggableGhost != null)
		{
			currentDraggableGhost.SetActive(value: false);
		}
		ClearHighlightedGridCells();
		MarkInvalidCells();
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnPlacementEnd();
		}
	}

	private static void RemoveGhost()
	{
		if (!(currentDraggableGhost == null))
		{
			if (currentDraggableGhost != null)
			{
				UnityEngine.Object.Destroy(currentDraggableGhost);
				currentDraggableGhost = null;
			}
			ClearHighlightedGridCells();
		}
	}

	private static Camera GetCameraRef()
	{
		if (cameraRef == null)
		{
			cameraRef = Camera.main;
		}
		return cameraRef;
	}

	private static GUIManagerPens GetPenGUIRef()
	{
		if (pensGUIRef == null)
		{
			pensGUIRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		}
		return pensGUIRef;
	}

	private static ConstructionManager GetConstructionRef()
	{
		if (constructionRef == null)
		{
			constructionRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		}
		return constructionRef;
	}

	private static NavmeshHelper GetNavmeshRef()
	{
		if (navmeshRef == null)
		{
			navmeshRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
		}
		return navmeshRef;
	}

	public static void InitializeDogGridForRoom(RoomBase roomRef)
	{
		if (roomRef.GetGroundPlacementGrid().Count == 0)
		{
			int _gridX = 0;
			int _gridY = 0;
			Vector3 _gridScale = Vector3.zero;
			Vector3 _gridPos = Vector3.zero;
			float _XYRatio = 0f;
			GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio);
			InitializeGrids(_gridX, _gridY, roomRef.GetGroundPlacementGrid(), roomRef.GetGroundIsolationGrid());
		}
		roomRef.InitializeDogPositionalGrid();
	}

	public static void OnEnterPlacementMode(RoomBase roomRef, bool playSounds = false)
	{
		if (inPlacementMode)
		{
			OnExitPlacementMode();
		}
		if (playSounds)
		{
			AudioController.Play(placementModeEnterSound);
		}
		inPlacementMode = true;
		currentPlacementRoom = roomRef;
		plantGrid = currentPlacementRoom.GetPlantGrid();
		puddleGrid = currentPlacementRoom.GetPuddleGrid();
		placementGrid = currentPlacementRoom.GetGroundPlacementGrid();
		isolationGrid = currentPlacementRoom.GetGroundIsolationGrid();
		DisplayPlacementGrid();
		SetPlacementGridVisibility(val: false);
		MarkInvalidCells();
		SetSubMode(SubMode.IDLE);
	}

	public static void OnExitPlacementMode()
	{
		RemoveObjectHighlight();
		SetSubMode(SubMode.SELECT);
		OnExitSubMode(currentSubMode);
		HidePlacementGrid();
		inPlacementMode = false;
		plantGrid = null;
		placementGrid = null;
		isolationGrid = null;
		currentPlacementRoom = null;
		currentlySelectedObject = null;
	}

	private static void GetGridProperties(RoomBase roomRef, ref int _gridX, ref int _gridY, ref Vector3 _gridScale, ref Vector3 _gridPos, ref float _XYRatio, bool forPlants = false, bool forPuddles = false)
	{
		BoundingBoxComponent bBC = roomRef.GetBBC();
		Vector3 boxSize = bBC.GetBoxSize();
		float num = (boxSize.x * 2f - 2f) / 10f;
		float num2 = (boxSize.z * 2f - 2f) / 10f;
		float num3 = GRID_SQUARE_SIZE;
		if (forPlants)
		{
			num3 = PLANT_GRID_SQUARE_SIZE;
		}
		else if (forPuddles)
		{
			num3 = PUDDLE_GRID_SQUARE_SIZE;
		}
		int num4 = Mathf.FloorToInt(num / (num3 / 10f)) + 1;
		int num5 = Mathf.FloorToInt(num2 / (num3 / 10f)) + 1;
		_gridX = Mathf.FloorToInt(num / (GRID_SQUARE_SIZE / 10f)) + 1;
		_gridY = Mathf.FloorToInt(num2 / (GRID_SQUARE_SIZE / 10f)) + 1;
		num = (float)_gridX / (10f / GRID_SQUARE_SIZE);
		num2 = (float)_gridY / (10f / GRID_SQUARE_SIZE);
		_gridX = num4;
		_gridY = num5;
		GameObject gameObject = roomRef.GetWallForDirection(WallDirection.DOWN).gameObject;
		BoxCollider componentInChildren = gameObject.GetComponentInChildren<BoxCollider>();
		float num6 = componentInChildren.bounds.max.y - componentInChildren.bounds.min.y;
		_gridPos = bBC.GetBoxCenter();
		_gridPos = new Vector3(_gridPos.x, gameObject.transform.position.y + num6 / 2f - 0.09f, _gridPos.z);
		_gridScale = new Vector3(num, 1f, num2);
		_XYRatio = num / num2;
	}

	public static void SetPlacementGridVisibility(bool val)
	{
		if (instantiatedGrid != null)
		{
			instantiatedGrid.SetActive(val);
		}
	}

	private static void DisplayPlacementGrid()
	{
		float _XYRatio = 0f;
		Vector3 _gridPos = Vector3.zero;
		Vector3 _gridScale = Vector3.zero;
		GetGridProperties(currentPlacementRoom, ref gridX, ref gridY, ref _gridScale, ref _gridPos, ref _XYRatio);
		instantiatedGrid = UnityEngine.Object.Instantiate(gridPlanePrefab, _gridPos, Quaternion.identity);
		gridMatRef = instantiatedGrid.GetComponent<Renderer>().material;
		instantiatedGrid.transform.localScale = _gridScale;
		gridMatRef.SetFloat("_GridSizeX", gridX);
		gridMatRef.SetFloat("_GridSizeY", gridY);
		gridSpacingX = 10f / (float)gridX;
		gridSpacingY = _XYRatio * gridSpacingX;
		gridMatRef.SetFloat("_GridSpacingX", gridSpacingX);
		gridMatRef.SetFloat("_GridSpacingY", gridSpacingY);
		float num = gridMatRef.GetFloat("_GridThicknessX");
		float value = _XYRatio * num;
		gridMatRef.SetFloat("_GridThicknessY", value);
		CreateGridCellTextures(gridX, gridY);
		InitializeGrids(gridX, gridY, placementGrid, isolationGrid);
		CalculateIsolationCells();
	}

	private static void InitializeGrids(int _gridX, int _gridY, List<List<int>> newPlacementGrid = null, List<List<float>> newIsolationGrid = null)
	{
		bool flag = newPlacementGrid != null && newPlacementGrid.Count == 0;
		bool flag2 = newIsolationGrid != null && newIsolationGrid.Count == 0;
		for (int i = 0; i < _gridX; i++)
		{
			if (flag)
			{
				newPlacementGrid.Add(new List<int>());
			}
			if (flag2)
			{
				newIsolationGrid.Add(new List<float>());
			}
			for (int j = 0; j < _gridY; j++)
			{
				if (flag)
				{
					newPlacementGrid[i].Add(0);
				}
				if (flag2)
				{
					newIsolationGrid[i].Add(0f);
				}
			}
		}
	}

	private static void InitializePlantGrid(int _gridX, int _gridY, List<List<ulong?>> newPlantGrid)
	{
		for (int i = 0; i < _gridX; i++)
		{
			newPlantGrid.Add(new List<ulong?>());
			for (int j = 0; j < _gridY; j++)
			{
				newPlantGrid[i].Add(null);
			}
		}
	}

	private static void InitializePuddleGrid(int _gridX, int _gridY, List<List<ulong?>> newPuddleGrid)
	{
		for (int i = 0; i < _gridX; i++)
		{
			newPuddleGrid.Add(new List<ulong?>());
			for (int j = 0; j < _gridY; j++)
			{
				newPuddleGrid[i].Add(null);
			}
		}
	}

	private static void CreateGridCellTextures(int cellCountX, int cellCountY)
	{
		markedGridCellTexture = new Texture2D(cellCountX, cellCountY, TextureFormat.ARGB32, mipChain: false);
		markedGridCellTexture.filterMode = FilterMode.Point;
		markedGridCellTexture.wrapMode = TextureWrapMode.Clamp;
		specialGridCellTexture = new Texture2D(cellCountX, cellCountY, TextureFormat.ARGB32, mipChain: false);
		specialGridCellTexture.filterMode = FilterMode.Point;
		specialGridCellTexture.wrapMode = TextureWrapMode.Clamp;
		specialGridCellTexture2 = new Texture2D(cellCountX, cellCountY, TextureFormat.ARGB32, mipChain: false);
		specialGridCellTexture2.filterMode = FilterMode.Point;
		specialGridCellTexture2.wrapMode = TextureWrapMode.Clamp;
		highlightedGridCellTexture = new Texture2D(cellCountX, cellCountY, TextureFormat.ARGB32, mipChain: false);
		highlightedGridCellTexture.filterMode = FilterMode.Point;
		highlightedGridCellTexture.wrapMode = TextureWrapMode.Clamp;
		highlightedGridCellTextureInvalid = new Texture2D(cellCountX, cellCountY, TextureFormat.ARGB32, mipChain: false);
		highlightedGridCellTextureInvalid.filterMode = FilterMode.Point;
		highlightedGridCellTextureInvalid.wrapMode = TextureWrapMode.Clamp;
		emptyTexture = new Texture2D(cellCountX, cellCountY, TextureFormat.ARGB32, mipChain: false);
		emptyTexture.filterMode = FilterMode.Point;
		emptyTexture.wrapMode = TextureWrapMode.Clamp;
		for (int i = 0; i < cellCountX; i++)
		{
			for (int j = 0; j < cellCountY; j++)
			{
				markedGridCellTexture.SetPixel(i, j, Color.white);
			}
		}
		markedGridCellTexture.Apply();
		gridMatRef.SetTexture("_MarkedGridCells", markedGridCellTexture);
		gridMatRef.SetTexture("_SpecialGridCells", specialGridCellTexture);
		gridMatRef.SetTexture("_SpecialGridCells2", specialGridCellTexture2);
		gridMatRef.SetTexture("_HighlightedGridCellsValid", highlightedGridCellTexture);
		gridMatRef.SetTexture("_HighlightedGridCellsInvalid", highlightedGridCellTextureInvalid);
	}

	private static void HidePlacementGrid()
	{
		if (instantiatedGrid != null)
		{
			UnityEngine.Object.Destroy(instantiatedGrid);
			instantiatedGrid = null;
			gridMatRef = null;
		}
		if (markedGridCellTexture != null)
		{
			emptyTexture = null;
			markedGridCellTexture = null;
			specialGridCellTexture = null;
			specialGridCellTexture2 = null;
			highlightedGridCellTexture = null;
			highlightedGridCellTextureInvalid = null;
		}
		activeGridCell = new Vector2Int(-1, -1);
	}

	private static void DetermineActiveGridCellForNewPlaceableObject(bool forceRefresh = false)
	{
		Vector3 pos = new Vector3(InputManager.MouseProvider.GetPosition().x - grabOffsetPosition.x, InputManager.MouseProvider.GetPosition().y - grabOffsetPosition.y, 100f);
		Ray ray = GetCameraRef().ScreenPointToRay(pos);
		float num = 100f;
		Vector3 localScale = instantiatedGrid.transform.localScale;
		instantiatedGrid.transform.localScale = new Vector3(instantiatedGrid.transform.localScale.x * num, instantiatedGrid.transform.localScale.y, instantiatedGrid.transform.localScale.z * num);
		Collider component = instantiatedGrid.GetComponent<Collider>();
		if (!component.Raycast(ray, out var hitInfo, 10000f))
		{
			instantiatedGrid.transform.localScale = localScale;
			return;
		}
		instantiatedGrid.transform.localScale = localScale;
		Vector3 vector = component.transform.InverseTransformPoint(hitInfo.point);
		vector += Vector3.one * 5f;
		vector /= 10f;
		Vector2Int vector2Int = new Vector2Int(Mathf.RoundToInt(vector.x * (float)gridX - GRID_SQUARE_SIZE / 2f), Mathf.RoundToInt(vector.z * (float)gridY - GRID_SQUARE_SIZE / 2f));
		vector2Int = new Vector2Int(Mathf.Clamp(vector2Int.x, 0, gridX - 1), Mathf.Clamp(vector2Int.y, 0, gridY - 1));
		if (!(vector2Int == activeGridCell) || forceRefresh)
		{
			Vector2Int gridSizeForFootprintBounds = GetGridSizeForFootprintBounds(currentPlacementObject.footprint * currentScaleValue);
			int num2 = (IsHorizontalRotation() ? gridSizeForFootprintBounds.x : gridSizeForFootprintBounds.y);
			int num3 = (IsHorizontalRotation() ? gridSizeForFootprintBounds.y : gridSizeForFootprintBounds.x);
			if (Is45DegreeRotation())
			{
				gridSizeForFootprintBounds = GetGridSizeForFootprintBounds(GetRotatedFootprintBounds(currentPlacementObject.footprint, currentPlacementObject.centerOffset, rotationValue) * currentScaleValue);
				num2 = gridSizeForFootprintBounds.x;
				num3 = gridSizeForFootprintBounds.y;
			}
			if (vector2Int.x + num2 >= gridX)
			{
				vector2Int.x = gridX - num2;
			}
			if (vector2Int.y + num3 >= gridY)
			{
				vector2Int.y = gridY - num3;
			}
			activeGridCell = vector2Int;
			MarkHighlightedGridCells(null, currentPlacementObject);
		}
	}

	private static bool IsHorizontalRotation(int val)
	{
		return _IsHorizontalRotationInternal(val);
	}

	private static bool IsHorizontalRotation()
	{
		return _IsHorizontalRotationInternal(rotationValue);
	}

	private static bool _IsHorizontalRotationInternal(int val)
	{
		if (val != 0)
		{
			return val == 180;
		}
		return true;
	}

	private static bool Is45DegreeRotation(int val)
	{
		return _Is45DegreeRotationInternal(val);
	}

	private static bool Is45DegreeRotation()
	{
		return _Is45DegreeRotationInternal(rotationValue);
	}

	private static bool _Is45DegreeRotationInternal(int val)
	{
		if (val != 45 && val != 135 && val != 225)
		{
			return val == 315;
		}
		return true;
	}

	private static List<Vector2Int> GetFootprintGridSquares(Vector2Int gridPos, PlacedObjectInfo placeableObjectRef = null, RoomCustomizationObject buildableRef = null, int rotationValue = 0, float scaleValue = 1f, bool forPlants = false, bool forPuddles = false)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		List<Vector2Int> list2 = new List<Vector2Int>();
		if (gridPos.x < 0 || gridPos.y < 0)
		{
			return list;
		}
		if (placeableObjectRef != null)
		{
			Vector3 footprintBounds = placeableObjectRef.customizationRef.footprint;
			if (Is45DegreeRotation(placeableObjectRef.rotationValue))
			{
				Vector2Int gridSizeForFootprintBounds = GetGridSizeForFootprintBounds(footprintBounds, scaleValue, forPlants, forPuddles);
				for (int i = 0; i < gridSizeForFootprintBounds.x; i++)
				{
					for (int j = 0; j < gridSizeForFootprintBounds.y; j++)
					{
						list2.Add(new Vector2Int(gridPos.x + i, gridPos.y + j));
					}
				}
				footprintBounds = GetRotatedFootprintBounds(footprintBounds, placeableObjectRef.customizationRef.centerOffset, placeableObjectRef.rotationValue);
			}
			Vector2Int gridSizeForFootprintBounds2 = GetGridSizeForFootprintBounds(footprintBounds, scaleValue, forPlants, forPuddles);
			for (int k = 0; k < gridSizeForFootprintBounds2.x; k++)
			{
				for (int l = 0; l < gridSizeForFootprintBounds2.y; l++)
				{
					int num = (IsHorizontalRotation(placeableObjectRef.rotationValue) ? k : l);
					int num2 = (IsHorizontalRotation(placeableObjectRef.rotationValue) ? l : k);
					list.Add(new Vector2Int(gridPos.x + num, gridPos.y + num2));
				}
			}
		}
		else
		{
			Vector3 footprintBounds2 = buildableRef.footprint;
			if (Is45DegreeRotation(rotationValue))
			{
				Vector2Int gridSizeForFootprintBounds3 = GetGridSizeForFootprintBounds(footprintBounds2, scaleValue, forPlants, forPuddles);
				for (int m = gridPos.x; m < gridPos.x + gridSizeForFootprintBounds3.x; m++)
				{
					for (int n = gridPos.y; n < gridPos.y + gridSizeForFootprintBounds3.y; n++)
					{
						list2.Add(new Vector2Int(m, n));
					}
				}
				footprintBounds2 = GetRotatedFootprintBounds(footprintBounds2, buildableRef.centerOffset, rotationValue);
			}
			Vector2Int gridSizeForFootprintBounds4 = GetGridSizeForFootprintBounds(footprintBounds2, scaleValue, forPlants, forPuddles);
			int num3 = (IsHorizontalRotation(rotationValue) ? gridSizeForFootprintBounds4.x : gridSizeForFootprintBounds4.y);
			int num4 = (IsHorizontalRotation(rotationValue) ? gridSizeForFootprintBounds4.y : gridSizeForFootprintBounds4.x);
			for (int num5 = gridPos.x; num5 < gridPos.x + num3; num5++)
			{
				for (int num6 = gridPos.y; num6 < gridPos.y + num4; num6++)
				{
					list.Add(new Vector2Int(num5, num6));
				}
			}
		}
		if (Is45DegreeRotation(rotationValue))
		{
			int num7 = -1;
			int num8 = -1;
			int num9 = -1;
			int num10 = -1;
			for (int num11 = 0; num11 < list2.Count; num11++)
			{
				if (list2[num11].x < num7 || num7 < 0)
				{
					num7 = list2[num11].x;
				}
				if (list2[num11].x > num8 || num8 < 0)
				{
					num8 = list2[num11].x;
				}
				if (list2[num11].y < num9 || num9 < 0)
				{
					num9 = list2[num11].y;
				}
				if (list2[num11].y > num10 || num10 < 0)
				{
					num10 = list2[num11].y;
				}
			}
			Vector2Int gridCell = new Vector2Int(num7, num10);
			Vector2Int gridCell2 = new Vector2Int(num8, num10);
			Vector2Int gridCell3 = new Vector2Int(num8, num9);
			Vector2Int gridCell4 = new Vector2Int(num7, num9);
			float num12 = GRID_SQUARE_SIZE;
			if (forPlants)
			{
				num12 = PLANT_GRID_SQUARE_SIZE;
			}
			else if (forPuddles)
			{
				num12 = PUDDLE_GRID_SQUARE_SIZE;
			}
			Vector3 vector = new Vector3(num12 / 2f, 0f, 0f);
			Vector3 vector2 = new Vector3(0f, 0f, num12 / 2f);
			Vector3 vec = GetPositionForGridCell(gridCell, null, null, forPlants, forPuddles) - vector + vector2;
			Vector3 vec2 = GetPositionForGridCell(gridCell2, null, null, forPlants, forPuddles) + vector + vector2;
			Vector3 vec3 = GetPositionForGridCell(gridCell3, null, null, forPlants, forPuddles) + vector - vector2;
			Vector3 vec4 = GetPositionForGridCell(gridCell4, null, null, forPlants, forPuddles) - vector - vector2;
			Vector3 footprint;
			Vector3 centerOffset;
			if (placeableObjectRef != null)
			{
				footprint = placeableObjectRef.customizationRef.footprint;
				centerOffset = placeableObjectRef.customizationRef.centerOffset;
			}
			else
			{
				footprint = buildableRef.footprint;
				centerOffset = buildableRef.centerOffset;
			}
			Vector2Int gridCell5 = gridPos;
			Vector3 footprint2 = footprint;
			Vector3 centerOffset2 = centerOffset;
			bool forPuddles2 = forPuddles;
			Vector3 placementPositionForGridCell = GetPlacementPositionForGridCell(gridCell5, footprint2, centerOffset2, null, null, null, null, null, forPlants, forPuddles2);
			Vector2Int gridCell6 = gridPos;
			Vector3 footprint3 = footprint;
			Vector3 centerOffset3 = centerOffset;
			int? rotationValueOverride = 0;
			forPuddles2 = forPuddles;
			Vector3 placementPositionForGridCell2 = GetPlacementPositionForGridCell(gridCell6, footprint3, centerOffset3, null, null, null, null, rotationValueOverride, forPlants, forPuddles2);
			Vector3 vector3 = placementPositionForGridCell - placementPositionForGridCell2;
			vec = RotateVector3(vec, rotationValue, placementPositionForGridCell2);
			vec2 = RotateVector3(vec2, rotationValue, placementPositionForGridCell2);
			vec3 = RotateVector3(vec3, rotationValue, placementPositionForGridCell2);
			vec4 = RotateVector3(vec4, rotationValue, placementPositionForGridCell2);
			vec += vector3;
			vec2 += vector3;
			vec3 += vector3;
			vec4 += vector3;
			for (int num13 = list.Count - 1; num13 >= 0; num13--)
			{
				Vector3 positionForGridCell = GetPositionForGridCell(list[num13], null, null, forPlants, forPuddles);
				Vector3 a = positionForGridCell - vector + vector2;
				Vector3 b = positionForGridCell + vector + vector2;
				Vector3 c = positionForGridCell + vector - vector2;
				Vector3 d = positionForGridCell - vector - vector2;
				if (!MathUtil.DoSquaresIntersect2D(vec, vec2, vec3, vec4, a, b, c, d))
				{
					list.RemoveAt(num13);
				}
			}
		}
		return list;
	}

	private static Vector3 RotateVector3(Vector3 vec, float angle, Vector3 pivot)
	{
		float f = angle * ((float)Math.PI / 180f);
		return new Vector3(pivot.x + (vec.x - pivot.x) * Mathf.Cos(f) + (vec.z - pivot.z) * Mathf.Sin(f), vec.y, pivot.z - (vec.x - pivot.x) * Mathf.Sin(f) + (vec.z - pivot.z) * Mathf.Cos(f));
	}

	public static Vector3 GetRotatedFootprintBounds(Vector3 footprintBounds, Vector3 centerOffset, float rot)
	{
		Vector3 vec = new Vector3((0f - footprintBounds.x) / 2f, 0f, footprintBounds.z / 2f);
		Vector3 vec2 = new Vector3(footprintBounds.x / 2f, 0f, footprintBounds.z / 2f);
		Vector3 vec3 = new Vector3(footprintBounds.x / 2f, 0f, (0f - footprintBounds.z) / 2f);
		Vector3 vec4 = new Vector3((0f - footprintBounds.x) / 2f, 0f, (0f - footprintBounds.z) / 2f);
		Vector3 pivot = new Vector3(0f - centerOffset.x, 0f, 0f - centerOffset.z);
		Vector3 vector = RotateVector3(vec, rot, pivot);
		vec2 = RotateVector3(vec2, rot, pivot);
		vec3 = RotateVector3(vec3, rot, pivot);
		vec4 = RotateVector3(vec4, rot, pivot);
		float num = Mathf.Min(vector.x, Mathf.Min(vec2.x, Mathf.Min(vec3.x, vec4.x)));
		float num2 = Mathf.Max(vector.x, Mathf.Max(vec2.x, Mathf.Max(vec3.x, vec4.x)));
		float num3 = Mathf.Min(vector.z, Mathf.Min(vec2.z, Mathf.Min(vec3.z, vec4.z)));
		float num4 = Mathf.Max(vector.z, Mathf.Max(vec2.z, Mathf.Max(vec3.z, vec4.z)));
		return new Vector3(Mathf.Abs(num2 - num), 0f, Mathf.Abs(num4 - num3));
	}

	public static Vector2Int GetGridSizeForFootprintBounds(Vector3 footprintBounds, float scaleValue = 1f, bool forPlants = false, bool forPuddles = false)
	{
		float num = GRID_SQUARE_SIZE;
		if (forPlants)
		{
			num = PLANT_GRID_SQUARE_SIZE;
		}
		else if (forPuddles)
		{
			num = PUDDLE_GRID_SQUARE_SIZE;
		}
		footprintBounds *= scaleValue;
		return new Vector2Int(Mathf.CeilToInt(footprintBounds.x / num), Mathf.CeilToInt(footprintBounds.z / num));
	}

	private static void ClearHighlightedGridCells()
	{
		if (highlightedGridCellTexture == null)
		{
			return;
		}
		for (int i = 0; i < gridX; i++)
		{
			for (int j = 0; j < gridY; j++)
			{
				highlightedGridCellTexture.SetPixel(i, j, Color.white);
			}
		}
		highlightedGridCellTexture.Apply();
		gridMatRef.SetTexture("_HighlightedGridCellsValid", highlightedGridCellTexture);
		ClearPlantHighlights();
		ClearPuddleHighlights();
	}

	private static void MarkHighlightedGridCells(PlacedObjectInfo placeableObjectRef = null, RoomCustomizationObject buildableRef = null)
	{
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(activeGridCell, placeableObjectRef, buildableRef, rotationValue, currentScaleValue);
		if (buildableRef == null || CanObjectBePlacedOnGrid(buildableRef))
		{
			for (int i = 0; i < gridX; i++)
			{
				for (int j = 0; j < gridY; j++)
				{
					highlightedGridCellTexture.SetPixel(i, j, footprintGridSquares.Contains(new Vector2Int(i, j)) ? Color.black : Color.white);
				}
			}
			highlightedGridCellTexture.Apply();
			gridMatRef.SetTexture("_HighlightedGridCellsValid", highlightedGridCellTexture);
			MarkInvalidCells();
		}
		else
		{
			for (int k = 0; k < gridX; k++)
			{
				for (int l = 0; l < gridY; l++)
				{
					highlightedGridCellTexture.SetPixel(k, l, (footprintGridSquares.Contains(new Vector2Int(k, l)) || placementGrid[k][l] == 1) ? Color.black : Color.white);
				}
			}
			highlightedGridCellTexture.Apply();
			gridMatRef.SetTexture("_HighlightedGridCellsValid", emptyTexture);
			gridMatRef.SetTexture("_HighlightedGridCellsInvalid", highlightedGridCellTexture);
		}
		ClearPlantHighlights();
		List<Vector2Int> list;
		if (currentlyPlacingPlant)
		{
			List<Vector2Int> plantGridSquaresForPlacementGridSquare = GetPlantGridSquaresForPlacementGridSquare(activeGridCell);
			list = GetFootprintGridSquares(plantGridSquaresForPlacementGridSquare[plantGridSquaresForPlacementGridSquare.Count / 2], null, currentPlacementObject, 0, 1f, forPlants: true);
		}
		else
		{
			list = GetPlantGridSquaresForPlacementGridSquares(footprintGridSquares);
		}
		for (int m = 0; m < list.Count; m++)
		{
			int x = list[m].x;
			int y = list[m].y;
			if (x < plantGrid.Count && y < plantGrid[x].Count && plantGrid[x][y].HasValue)
			{
				AddPlantHighlight(currentPlacementRoom.GetPlantInfoForUID(plantGrid[x][y].Value));
			}
		}
		ClearPuddleHighlights();
		List<Vector2Int> puddleGridSquaresForPlacementGridSquares = GetPuddleGridSquaresForPlacementGridSquares(footprintGridSquares);
		for (int n = 0; n < puddleGridSquaresForPlacementGridSquares.Count; n++)
		{
			int x2 = puddleGridSquaresForPlacementGridSquares[n].x;
			int y2 = puddleGridSquaresForPlacementGridSquares[n].y;
			if (x2 < puddleGrid.Count && y2 < puddleGrid[x2].Count && puddleGrid[x2][y2].HasValue)
			{
				AddPuddleHighlight(currentPlacementRoom.GetPuddleInfoForUID(puddleGrid[x2][y2].Value));
			}
		}
	}

	private static Vector2Int GetGridCellForPositionInternal(Vector3 pos, float _gridX, float _gridY, Vector3 _gridScale, Vector3 _gridPos, bool forPlants = false, bool forPuddles = false)
	{
		float num = GRID_SQUARE_SIZE;
		if (forPlants)
		{
			num = PLANT_GRID_SQUARE_SIZE;
		}
		else if (forPuddles)
		{
			num = PUDDLE_GRID_SQUARE_SIZE;
		}
		Vector3 vector = _gridScale * 10f;
		Vector3 vector2 = new Vector3(vector.x % num, 0f, vector.z % num);
		vector -= vector2;
		Vector3 vector3 = new Vector3(vector.x / 2f, 0f, vector.z / 2f);
		Vector3 vector4 = new Vector3(pos.x + vector3.x - _gridPos.x, 0f, pos.z + vector3.z - _gridPos.z);
		float num2 = vector4.x / vector.x;
		float num3 = vector4.z / vector.z;
		int x = Mathf.Clamp(Mathf.FloorToInt(num2 * _gridX), 0, (int)_gridX - 1);
		int y = Mathf.Clamp(Mathf.FloorToInt(num3 * _gridY), 0, (int)_gridY - 1);
		return new Vector2Int(x, y);
	}

	private static Vector3 GetPositionForGridCellInternal(Vector2Int gridCell, Vector3 _gridScale, Vector3 _gridPos, bool forPlants = false, bool forPuddles = false)
	{
		float num = GRID_SQUARE_SIZE;
		if (forPlants)
		{
			num = PLANT_GRID_SQUARE_SIZE;
		}
		else if (forPuddles)
		{
			num = PUDDLE_GRID_SQUARE_SIZE;
		}
		Vector3 vector = _gridScale * 10f;
		Vector3 vector2 = new Vector3(vector.x % num, 0f, vector.z % num);
		vector -= vector2;
		Vector3 vector3 = new Vector3(vector.x / 2f, 0f, vector.z / 2f);
		float num2 = num / 2f;
		Vector3 vector4 = new Vector3((float)gridCell.x * num + num2, 0f, (float)gridCell.y * num + num2);
		return _gridPos - vector3 + vector4;
	}

	public static List<Vector2Int> GetPlantGridSquaresForPlacementGridSquares(List<Vector2Int> placementSquares)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		for (int i = 0; i < placementSquares.Count; i++)
		{
			list.AddRange(GetPlantGridSquaresForPlacementGridSquare(placementSquares[i]));
		}
		return list;
	}

	public static List<Vector2Int> GetPlantGridSquaresForPlacementGridSquare(Vector2Int placementSquare)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		int num = Mathf.FloorToInt(GRID_SQUARE_SIZE / PLANT_GRID_SQUARE_SIZE);
		int num2 = placementSquare.x * num;
		int num3 = placementSquare.y * num;
		int num4 = num2 + num;
		int num5 = num3 + num;
		for (int i = num2; i <= num4; i++)
		{
			for (int j = num3; j <= num5; j++)
			{
				list.Add(new Vector2Int(i, j));
			}
		}
		return list;
	}

	public static Vector2Int GetPlacementGridSquareForPlantGridSquare(Vector2Int plantSquare)
	{
		int num = Mathf.FloorToInt(GRID_SQUARE_SIZE / PLANT_GRID_SQUARE_SIZE);
		int x = plantSquare.x / num;
		int y = plantSquare.y / num;
		return new Vector2Int(x, y);
	}

	public static List<Vector2Int> GetPuddleGridSquaresForPlacementGridSquares(List<Vector2Int> placementSquares)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		for (int i = 0; i < placementSquares.Count; i++)
		{
			list.AddRange(GetPuddleGridSquaresForPlacementGridSquare(placementSquares[i]));
		}
		return list;
	}

	public static List<Vector2Int> GetPuddleGridSquaresForPlacementGridSquare(Vector2Int placementSquare)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		int num = Mathf.FloorToInt(GRID_SQUARE_SIZE / PUDDLE_GRID_SQUARE_SIZE);
		int num2 = placementSquare.x * num;
		int num3 = placementSquare.y * num;
		int num4 = num2 + num;
		int num5 = num3 + num;
		for (int i = num2; i <= num4; i++)
		{
			for (int j = num3; j <= num5; j++)
			{
				list.Add(new Vector2Int(i, j));
			}
		}
		return list;
	}

	public static Vector2Int GetPlacementGridSquareForPuddleGridSquare(Vector2Int puddleSquare)
	{
		int num = Mathf.FloorToInt(GRID_SQUARE_SIZE / PUDDLE_GRID_SQUARE_SIZE);
		int x = puddleSquare.x / num;
		int y = puddleSquare.y / num;
		return new Vector2Int(x, y);
	}

	public static Vector2Int GetGridSquareForPositionAndRoom(Vector3 pos, RoomBase roomRef, bool forPlants = false, bool forPuddles = false)
	{
		float _XYRatio = 0f;
		int _gridX = 0;
		int _gridY = 0;
		Vector3 _gridScale = Vector3.zero;
		Vector3 _gridPos = Vector3.zero;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio, forPlants, forPuddles);
		return GetGridCellForPositionInternal(pos, _gridX, _gridY, _gridScale, _gridPos, forPlants, forPuddles);
	}

	public static Vector3 GetCenterPositionForGridCellAndRoom(Vector2Int gridCell, RoomBase roomRef)
	{
		float _XYRatio = 0f;
		int _gridX = 0;
		int _gridY = 0;
		Vector3 _gridScale = Vector3.zero;
		Vector3 _gridPos = Vector3.zero;
		Vector3 vector = new Vector3(GRID_SQUARE_SIZE, 0f, GRID_SQUARE_SIZE) / 2f;
		GetGridProperties(roomRef, ref _gridX, ref _gridY, ref _gridScale, ref _gridPos, ref _XYRatio);
		return GetPositionForGridCellInternal(gridCell, _gridScale, _gridPos) + vector;
	}

	private static Vector3 GetPositionForGridCell(Vector2Int gridCell, Vector3? gridScaleOverride = null, Vector3? gridPosOverride = null, bool forPlants = false, bool forPuddles = false)
	{
		if (gridScaleOverride.HasValue)
		{
			return GetPositionForGridCellInternal(gridCell, gridScaleOverride.Value, gridPosOverride.Value, forPlants, forPuddles);
		}
		return GetPositionForGridCellInternal(gridCell, instantiatedGrid.transform.localScale, instantiatedGrid.transform.position, forPlants, forPuddles);
	}

	private static Vector3 GetPlacementPositionForGridCell(Vector2Int gridCell, Vector3 footprint, Vector3 centerOffset, int? gridXOverride = null, int? gridYOverride = null, Vector3? gridScaleOverride = null, Vector3? gridPosOverride = null, int? rotationValueOverride = null, bool forPlants = false, bool forPuddles = false, float? scaleValueOverride = null)
	{
		int value = rotationValue;
		if (rotationValueOverride.HasValue)
		{
			value = rotationValueOverride.Value;
		}
		float num = GRID_SQUARE_SIZE;
		if (forPlants)
		{
			num = PLANT_GRID_SQUARE_SIZE;
		}
		else if (forPuddles)
		{
			num = PUDDLE_GRID_SQUARE_SIZE;
		}
		float num2 = currentScaleValue;
		if (scaleValueOverride.HasValue)
		{
			num2 = scaleValueOverride.Value;
		}
		footprint *= num2;
		centerOffset *= num2;
		float num3 = (IsHorizontalRotation(value) ? footprint.x : footprint.z);
		float num4 = (IsHorizontalRotation(value) ? footprint.z : footprint.x);
		if (Is45DegreeRotation(value))
		{
			Vector3 rotatedFootprintBounds = GetRotatedFootprintBounds(footprint, centerOffset, value);
			num3 = rotatedFootprintBounds.x;
			num4 = rotatedFootprintBounds.z;
		}
		float num5;
		for (num5 = 0f; num5 < num3; num5 += num)
		{
		}
		float num6;
		for (num6 = 0f; num6 < num4; num6 += num)
		{
		}
		float num7 = (num5 - 1f) / 2f;
		float num8 = (num6 - 1f) / 2f;
		float num9 = (num5 - num3) / 2f;
		float num10 = (num6 - num4) / 2f;
		if (IsHorizontalRotation(value))
		{
			if (value == 180)
			{
				num8 -= num10;
				centerOffset.z *= -1f;
				centerOffset.x *= -1f;
			}
			else
			{
				num8 += num10;
			}
		}
		else if (Is45DegreeRotation(value))
		{
			Vector3 vec = new Vector3((0f - footprint.x) / 2f, 0f, footprint.z / 2f);
			Vector3 vec2 = new Vector3(footprint.x / 2f, 0f, footprint.z / 2f);
			Vector3 pivot = new Vector3(0f - centerOffset.x, 0f, 0f - centerOffset.z);
			vec = RotateVector3(vec, rotationValue, pivot);
			vec2 = RotateVector3(vec2, rotationValue, pivot);
			switch (value)
			{
			case 45:
				num8 += num6 / 2f - vec.z;
				num7 += num5 / 2f - vec2.x;
				break;
			case 135:
				num8 += (0f - num6) / 2f - vec2.z;
				num7 += num5 / 2f - vec.x;
				break;
			case 225:
				num8 += (0f - num6) / 2f - vec.z;
				num7 += (0f - num5) / 2f - vec2.x;
				break;
			case 315:
				num8 += num6 / 2f - vec2.z;
				num7 += (0f - num5) / 2f - vec.x;
				break;
			}
		}
		else
		{
			float x = centerOffset.x;
			centerOffset.x = centerOffset.z;
			centerOffset.z = x;
			if (value == 90)
			{
				num7 += num9;
				centerOffset.z *= -1f;
			}
			else
			{
				num7 -= num9;
				centerOffset.x *= -1f;
			}
		}
		float y = 0f - centerOffset.y + footprint.y / 2f;
		Vector3 vector = new Vector3(num7, 0f, num8);
		Vector3 vector2 = new Vector3(0f - centerOffset.x, y, 0f - centerOffset.z);
		return GetPositionForGridCell(gridCell, gridScaleOverride, gridPosOverride, forPlants, forPuddles) + vector2 + vector + yPosOffset;
	}

	private static void UpdateDraggableGhost()
	{
		if (!(currentDraggableGhost == null))
		{
			cursorRef.SetCursor(CursorController.CursorType.GRABBING2D);
			currentDraggableGhost.SetActive(value: true);
			currentDraggableGhost.transform.rotation = Quaternion.Euler(0f, rotationValue, 0f);
			currentDraggableGhost.transform.localScale = Vector3.one * currentScaleValue;
			if (currentlyPlacingPlant)
			{
				List<Vector2Int> plantGridSquaresForPlacementGridSquare = GetPlantGridSquaresForPlacementGridSquare(activeGridCell);
				Vector2Int gridCell = plantGridSquaresForPlacementGridSquare[plantGridSquaresForPlacementGridSquare.Count / 2];
				currentDraggableGhost.transform.position = GetPlacementPositionForGridCell(gridCell, currentPlacementObject.footprint, currentPlacementObject.centerOffset, null, null, null, null, 0, forPlants: true, forPuddles: false, 1f);
			}
			else
			{
				currentDraggableGhost.transform.position = GetPlacementPositionForGridCell(activeGridCell, currentPlacementObject.footprint, currentPlacementObject.centerOffset);
			}
		}
	}

	private static bool CheckScale(PlacedObjectInfo placeableObjectRef = null, RoomCustomizationObject buildableRef = null)
	{
		if (currentlyPlacingPlant)
		{
			return false;
		}
		bool flag = GameControls.actions.IncreaseHeldObjectScale.WasPressed;
		bool flag2 = GameControls.actions.DecreaseHeldObjectScale.WasPressed;
		if (GameControls.isObjectScaleUpScrollWheel && Input.mouseScrollDelta != Vector2.zero)
		{
			flag = GameControls.actions.IncreaseHeldObjectScale.IsPressed;
		}
		if (GameControls.isObjectScaleDownScrollWheel && Input.mouseScrollDelta != Vector2.zero)
		{
			flag2 = GameControls.actions.DecreaseHeldObjectScale.IsPressed;
		}
		if (!flag && !flag2)
		{
			return false;
		}
		AudioController.Play(objectRotatedSound);
		if (flag)
		{
			if (currentScaleValue < scaleValueMax)
			{
				currentScaleValue += scaleIncrement;
				AudioController.Play(scaleUpSound);
			}
		}
		else if (flag2 && currentScaleValue > scaleValueMin)
		{
			currentScaleValue -= scaleIncrement;
			AudioController.Play(scaleDownSound);
		}
		currentScaleValue = Mathf.Clamp(currentScaleValue, scaleValueMin, scaleValueMax);
		MarkHighlightedGridCells(placeableObjectRef, buildableRef);
		return true;
	}

	private static bool CheckRotation(PlacedObjectInfo placeableObjectRef = null, RoomCustomizationObject buildableRef = null)
	{
		if (currentlyPlacingPlant)
		{
			return false;
		}
		bool wasPressed = GameControls.actions.RotateHeldObjectRight.WasPressed;
		bool wasPressed2 = GameControls.actions.RotateHeldObjectLeft.WasPressed;
		if (!wasPressed && !wasPressed2)
		{
			return false;
		}
		AudioController.Play(objectRotatedSound);
		if (wasPressed)
		{
			rotationValue += 45;
		}
		else if (wasPressed2)
		{
			rotationValue += 315;
		}
		rotationValue %= 360;
		MarkHighlightedGridCells(placeableObjectRef, buildableRef);
		return true;
	}

	private static void CheckPlacement()
	{
		if (currentDraggableGhost.GetComponents<PlaceableObject>().Length > 1)
		{
			return;
		}
		PlaceableObject component = currentDraggableGhost.GetComponent<PlaceableObject>();
		PlaceableObjectState placeableObjectState = PlaceableObjectState.VALID_PLACEMENT;
		if (!CanObjectBePlacedOnGrid(currentPlacementObject))
		{
			placeableObjectState = PlaceableObjectState.INVALID_PLACEMENT;
		}
		if (component.GetState() != placeableObjectState)
		{
			component.SetState(placeableObjectState);
			component.SetMaterials(placementGUIRef.GetMaterialForObjectState(placeableObjectState));
		}
		if (GameControls.actions.Interact.WasPressed && placeableObjectState == PlaceableObjectState.VALID_PLACEMENT)
		{
			if (currentlyPlacingPlant)
			{
				List<Vector2Int> plantGridSquaresForPlacementGridSquare = GetPlantGridSquaresForPlacementGridSquare(activeGridCell);
				Vector2Int gridCell = plantGridSquaresForPlacementGridSquare[plantGridSquaresForPlacementGridSquare.Count / 2];
				PlacePlant(currentPlacementRoom, currentPlacementObject, gridCell, null, clearExistingPlants: true);
			}
			else
			{
				PlaceObjectAtPosition(activeGridCell, rotationValue, currentScaleValue);
			}
			OnObjectPlaced?.Invoke();
			AudioController.Play(objectPlacementSound);
		}
	}

	public static void SetActiveObject(RoomCustomizationObject newObj)
	{
		SetDraggableObjectPrefab(newObj);
		CreateGhost();
		activeGridCell = new Vector2Int(activeGridCell.x + 100, activeGridCell.y + 100);
	}

	private static void CheckSelectionPlacement()
	{
		PlaceableObject component = currentDraggableGhost.GetComponent<PlaceableObject>();
		PlaceableObjectState placeableObjectState = PlaceableObjectState.VALID_PLACEMENT;
		if (!CanObjectBePlacedOnGrid(currentlySelectedObject.customizationRef))
		{
			placeableObjectState = PlaceableObjectState.INVALID_PLACEMENT;
		}
		if (component.GetState() != placeableObjectState)
		{
			component.SetState(placeableObjectState);
			component.SetMaterials(placementGUIRef.GetMaterialForObjectState(placeableObjectState));
		}
		if (GameControls.actions.Interact.WasPressed && placeableObjectState == PlaceableObjectState.VALID_PLACEMENT)
		{
			PlaceSelectedObject(activeGridCell, rotationValue, currentScaleValue);
			AudioController.Play(objectPlacementSound);
		}
	}

	private static void CheckSelectionDeletion()
	{
		if (!GameControls.actions.DestroyHeldObject.WasPressed || currentlySelectedObject == null)
		{
			return;
		}
		DogDen component = currentlySelectedObject.objectRef.GetComponent<DogDen>();
		StorageChest component2 = currentlySelectedObject.objectRef.GetComponent<StorageChest>();
		if (component != null)
		{
			PlacedObjectInfo infoRef = currentlySelectedObject;
			SetSubMode(SubMode.SELECT);
			GUIManagerPens penGUIRef = GetPenGUIRef();
			if (penGUIRef != null)
			{
				ShowDestructionPopupForDen(infoRef, component, penGUIRef);
			}
		}
		else if (component2 != null)
		{
			PlacedObjectInfo infoRef2 = currentlySelectedObject;
			SetSubMode(SubMode.SELECT);
			GUIManagerPens penGUIRef2 = GetPenGUIRef();
			if (penGUIRef2 != null)
			{
				ShowDestructionPopupForChest(infoRef2, component2, penGUIRef2);
			}
		}
		else
		{
			DestroySelectedObject();
			AudioController.Play(objectDestroyedSound);
		}
	}

	public static void DestroySelectedObject(bool particles = true)
	{
		DestroyObject(currentlySelectedObject, currentDraggableGhost, particles);
		currentlySelectedObject = null;
		currentlyHighlightedObject = null;
	}

	public static void DestroyObject(PlacedObjectInfo infoRef, GameObject draggableGhostRef, bool particles = true)
	{
		if (infoRef != null)
		{
			ClearGrid(GetFootprintGridSquares(infoRef.gridPos, infoRef, null, rotationValue, currentScaleValue));
			if (objectDestructionParticles != null && particles && draggableGhostRef != null)
			{
				UnityEngine.Object.Instantiate(objectDestructionParticles, draggableGhostRef.transform.position, Quaternion.identity);
			}
			if (draggableGhostRef != null)
			{
				RemoveGhost();
			}
			currentPlacementRoom.OnObjectRemoved(infoRef, fromDestroy: true);
			UnityEngine.Object.Destroy(infoRef.objectRef);
			infoRef = null;
		}
	}

	private static PlacedObjectInfo PlaceObjectAtPosition(Vector2Int gridPos, int newRotation, float newScale, SaveablePlacedObject existingObject = null, bool particles = true)
	{
		rotationValue = newRotation;
		currentScaleValue = newScale;
		Vector3 placementPositionForGridCell = GetPlacementPositionForGridCell(gridPos, currentPlacementObject.footprint, currentPlacementObject.centerOffset);
		GameObject gameObject = UnityEngine.Object.Instantiate(currentPlacementObject.prefabObject, placementPositionForGridCell, Quaternion.Euler(0f, newRotation, 0f));
		gameObject.transform.localScale = Vector3.one * newScale;
		PlacedObjectInfo placedObjectInfo = new PlacedObjectInfo(gameObject, currentPlacementObject, gridPos, newRotation, newScale);
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(gridPos, placedObjectInfo, null, rotationValue, currentScaleValue);
		MarkGrid(footprintGridSquares);
		currentPlacementRoom.OnObjectPlaced(placedObjectInfo, footprintGridSquares, existingObject);
		if (objectPlacementParticles != null && particles)
		{
			UnityEngine.Object.Instantiate(objectPlacementParticles, placementPositionForGridCell, Quaternion.identity);
		}
		if (placementGUIRef != null)
		{
			placementGUIRef.UpdateActiveObjectLeftText(currentPlacementObject);
		}
		return placedObjectInfo;
	}

	private static void ShowPlacementPanels()
	{
		SetSubMode(SubMode.IDLE);
		SetPlacementGridVisibility(val: false);
		placementGUIRef.ShowPanels();
	}

	private static bool CanObjectBePlacedOnGrid(RoomCustomizationObject objectRef)
	{
		List<Vector2Int> footprintGridSquares = GetFootprintGridSquares(activeGridCell, null, objectRef, rotationValue, currentScaleValue);
		for (int i = 0; i < footprintGridSquares.Count; i++)
		{
			if (footprintGridSquares[i].x >= gridX || footprintGridSquares[i].y >= gridY)
			{
				return false;
			}
			if (placementGrid[footprintGridSquares[i].x][footprintGridSquares[i].y] != 0)
			{
				return false;
			}
		}
		return true;
	}

	private static void MarkPlantGrid(List<Vector2Int> gridCells, List<List<ulong?>> plantGrid, ulong plantUID)
	{
		for (int i = 0; i < gridCells.Count; i++)
		{
			if (gridCells[i].x < plantGrid.Count && gridCells[i].y < plantGrid[gridCells[i].x].Count)
			{
				plantGrid[gridCells[i].x][gridCells[i].y] = plantUID;
			}
		}
	}

	private static void MarkPuddleGrid(List<Vector2Int> gridCells, List<List<ulong?>> puddleGrid, ulong puddleUID)
	{
		for (int i = 0; i < gridCells.Count; i++)
		{
			if (gridCells[i].x < puddleGrid.Count && gridCells[i].y < puddleGrid[gridCells[i].x].Count)
			{
				puddleGrid[gridCells[i].x][gridCells[i].y] = puddleUID;
			}
		}
	}

	private static void MarkGrid(List<Vector2Int> gridCells, List<List<int>> placementGridOverride = null, List<List<float>> isolationGridOverride = null, RoomBase roomOverride = null)
	{
		List<List<int>> list = placementGrid;
		if (placementGridOverride != null)
		{
			list = placementGridOverride;
		}
		for (int i = 0; i < gridCells.Count; i++)
		{
			if (gridCells[i].x < list.Count && gridCells[i].y < list[gridCells[i].x].Count)
			{
				list[gridCells[i].x][gridCells[i].y] = 1;
			}
		}
		UpdateNavmesh();
		if (placementGridOverride == null)
		{
			MarkInvalidCells();
			CalculateIsolationCells();
		}
		else
		{
			roomOverride.UpdateGroundPlacementGrid(list);
			CalculateIsolationCells(isolationGridOverride, list, roomOverride);
		}
	}

	private static void ClearPlantGrid(List<Vector2Int> gridCells, List<List<ulong?>> plantGrid)
	{
		if (plantGrid == null)
		{
			Debug.LogError("No plant grid assigned!");
			return;
		}
		for (int i = 0; i < gridCells.Count; i++)
		{
			if (gridCells[i].x < plantGrid.Count && gridCells[i].y < plantGrid[gridCells[i].x].Count)
			{
				plantGrid[gridCells[i].x][gridCells[i].y] = null;
			}
		}
	}

	private static void ClearPuddleGrid(List<Vector2Int> gridCells, List<List<ulong?>> puddleGrid)
	{
		if (puddleGrid == null)
		{
			Debug.LogError("No puddle grid assigned!");
			return;
		}
		for (int i = 0; i < gridCells.Count; i++)
		{
			if (gridCells[i].x < puddleGrid.Count && gridCells[i].y < puddleGrid[gridCells[i].x].Count)
			{
				puddleGrid[gridCells[i].x][gridCells[i].y] = null;
			}
		}
	}

	private static void ClearGrid(List<Vector2Int> gridCells, List<List<int>> placementGridOverride = null, List<List<float>> isolationGridOverride = null, RoomBase roomOverride = null)
	{
		List<List<int>> list = placementGrid;
		if (placementGridOverride != null)
		{
			list = placementGridOverride;
		}
		for (int i = 0; i < gridCells.Count; i++)
		{
			if (gridCells[i].x < list.Count && gridCells[i].y < list[gridCells[i].x].Count)
			{
				list[gridCells[i].x][gridCells[i].y] = 0;
			}
		}
		if (placementGridOverride == null)
		{
			MarkInvalidCells();
		}
		UpdateNavmesh();
		CalculateIsolationCells(isolationGridOverride, placementGridOverride, roomOverride);
	}

	private static void MarkInvalidCells()
	{
		for (int i = 0; i < placementGrid.Count; i++)
		{
			for (int j = 0; j < placementGrid[i].Count; j++)
			{
				highlightedGridCellTextureInvalid.SetPixel(i, j, (placementGrid[i][j] == 1) ? Color.black : Color.white);
			}
		}
		highlightedGridCellTextureInvalid.Apply();
		gridMatRef.SetTexture("_HighlightedGridCellsInvalid", highlightedGridCellTextureInvalid);
		currentPlacementRoom.UpdateGroundPlacementGrid(placementGrid);
	}

	private static void UpdateNavmesh()
	{
		NavmeshHelper navmeshHelper = GetNavmeshRef();
		if (navmeshHelper != null)
		{
			navmeshHelper.Rebuild();
		}
	}

	private static void ShowSelectionGUI()
	{
		if (currentlySelectedObject != null)
		{
			currentlySelectedObject.objectRef.GetComponent<PlaceableObject>().ShowSelectionGUI(currentlySelectedObject.customizationRef);
		}
	}

	private static void HideSelectionGUI()
	{
		if (currentlySelectedObject != null)
		{
			currentlySelectedObject.objectRef.GetComponent<PlaceableObject>().HideSelectionGUI();
		}
	}

	private static void CalculateIsolationCells(List<List<float>> isolationGridOverride = null, List<List<int>> placementGridOverride = null, RoomBase roomOverride = null)
	{
		List<List<int>> list = placementGrid;
		List<List<float>> list2 = isolationGrid;
		if (isolationGridOverride != null)
		{
			list = placementGridOverride;
			list2 = isolationGridOverride;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list2.Count <= i)
			{
				list2.Add(new List<float>());
			}
			for (int j = 0; j < list[i].Count; j++)
			{
				if (list2[i].Count <= j)
				{
					list2[i].Add(0f);
				}
				list2[i][j] = GetIsolationScoreForGridCell(i, j, placementGridOverride);
			}
		}
		CullIsolationNodes(list2, minValidIsolationScore);
		if (isolationGridOverride == null)
		{
			DisplayIsolationPositions();
			currentPlacementRoom.UpdateGroundIsolationGrid(list2);
		}
		else
		{
			roomOverride.UpdateGroundIsolationGrid(list2);
		}
	}

	private static void DisplayReservations()
	{
		if (!debugVisReservations || currentPlacementRoom == null)
		{
			return;
		}
		for (int i = 0; i < placementGrid.Count; i++)
		{
			for (int j = 0; j < placementGrid[i].Count; j++)
			{
				specialGridCellTexture2.SetPixel(i, j, (!currentPlacementRoom.IsTileReservedForPlacement(i, j)) ? Color.white : new Color(0f, 0f, 0f, 1f));
			}
		}
		specialGridCellTexture2.Apply();
		gridMatRef.SetTexture("_SpecialGridCells2", specialGridCellTexture2);
	}

	private static void DisplayIsolationPositions()
	{
		if (!debugVisIsolation)
		{
			return;
		}
		for (int i = 0; i < placementGrid.Count; i++)
		{
			for (int j = 0; j < placementGrid[i].Count; j++)
			{
				if (isolationGrid[i][j] >= minValidIsolationScore)
				{
					specialGridCellTexture.SetPixel(i, j, Color.black);
				}
				else
				{
					specialGridCellTexture.SetPixel(i, j, Color.white);
				}
			}
		}
		specialGridCellTexture.Apply();
		gridMatRef.SetTexture("_SpecialGridCells", specialGridCellTexture);
	}

	private static void DisplayDogPositions()
	{
		if (!debugVisDogs || placementGrid == null)
		{
			return;
		}
		for (int i = 0; i < placementGrid.Count; i++)
		{
			for (int j = 0; j < placementGrid[i].Count; j++)
			{
				specialGridCellTexture2.SetPixel(i, j, (currentPlacementRoom.GetDogScoreForGridSquare(i, j) == 0f) ? Color.white : new Color(0f, 0f, 0f, currentPlacementRoom.GetDogScoreForGridSquare(i, j)));
			}
		}
		specialGridCellTexture2.Apply();
		gridMatRef.SetTexture("_SpecialGridCells2", specialGridCellTexture2);
	}

	public static float GetIsolationScoreForGridCell(int x, int y, List<List<int>> placementGridOverride = null)
	{
		List<List<int>> list = placementGrid;
		if (placementGridOverride != null)
		{
			list = placementGridOverride;
		}
		if (list[x][y] == 1)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 1; i <= maxObstructionDist; i++)
		{
			if (x - i < 0 || list[x - i][y] == 1)
			{
				num += (float)(maxObstructionDist + 1 - i);
				break;
			}
		}
		for (int j = 1; j <= maxObstructionDist; j++)
		{
			if (x + j >= list.Count || list[x + j][y] == 1)
			{
				num += (float)(maxObstructionDist + 1 - j);
				break;
			}
		}
		for (int k = 1; k <= maxObstructionDist; k++)
		{
			if (y - k < 0 || list[x][y - k] == 1)
			{
				num += (float)(maxObstructionDist + 1 - k);
				break;
			}
		}
		for (int l = 1; l <= maxObstructionDist; l++)
		{
			if (y + l >= list[x].Count || list[x][y + l] == 1)
			{
				num += (float)(maxObstructionDist + 1 - l);
				break;
			}
		}
		float num2 = (float)maxObstructionDist * 4f;
		return num / num2;
	}

	private static void CullIsolationNodes(List<List<float>> nodeList, float minRequiredScore)
	{
		bool flag = false;
		for (int i = 0; i < nodeList.Count; i++)
		{
			for (int j = 0; j < nodeList[i].Count; j++)
			{
				if (nodeList[i][j] < minRequiredScore)
				{
					nodeList[i][j] = 0f;
					continue;
				}
				int num = 0;
				if (i - 1 < 0 || nodeList[i - 1][j] >= minRequiredScore)
				{
					num++;
				}
				if (i + 1 >= nodeList.Count || nodeList[i + 1][j] >= minRequiredScore)
				{
					num++;
				}
				if (j - 1 < 0 || nodeList[i][j - 1] >= minRequiredScore)
				{
					num++;
				}
				if (j + 1 >= nodeList[i].Count || nodeList[i][j + 1] >= minRequiredScore)
				{
					num++;
				}
				if (num < requiredNeighbors)
				{
					flag = true;
					nodeList[i][j] = 0f;
				}
			}
		}
		if (flag)
		{
			CullIsolationNodes(nodeList, minRequiredScore);
		}
	}
}
