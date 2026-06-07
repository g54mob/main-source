using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
	private delegate void CellAction(int x, int y);

	public Camera mainCamera;

	public RawImage debugImage;

	public GameObject editLines;

	public GameObject editVerticalLine;

	public UnpauseConfirm unpauseConfirm;

	public GameObject editModeConfirm;

	public GameObject compileAllResultsDialog;

	public Text compileAllResultsText;

	[NonSerialized]
	public int DOUBLE_CLICK_SELECT_RANGE;

	private float CAMERA_ZOOM_SPEED;

	private float CAMERA_ROTATE_SPEED;

	private bool _rplCam;

	private bool _rplCamCursorLock;

	[NonSerialized]
	public Vector3 rplCamPos;

	[NonSerialized]
	public Vector3 rplCamRot;

	[NonSerialized]
	public float minCamHeight;

	[NonSerialized]
	public float maxCamHeight;

	private float minViewAngle;

	private float maxViewAngle;

	private float autoZoomHeight;

	private bool autoZoomPauseEnabled;

	private int lockX;

	private int lockY;

	private Vector3 cameraMove;

	[NonSerialized]
	public Vector3 cameraPos;

	[NonSerialized]
	public float cameraYRotation;

	private float rotateStartYRotation;

	private float lockZoomAngleStart;

	[NonSerialized]
	public float cameraXRotation;

	private float rotateStartXRotation;

	private Vector3 panMouseDown;

	private Vector2 panMouseScreenPos;

	private Vector3 rotateMouseDown;

	private Vector3 rotateMouseDownWorld;

	private float heightStartMove;

	private int singleStepFireCounter;

	private int singleStepFireCount;

	public bool lockCameraInput;

	[NonSerialized]
	public bool ignoreScapeLoss;

	[NonSerialized]
	public HashSet<GameObject> inputBlockers;

	[NonSerialized]
	public bool newNormals;

	private int _hideUIOverride;

	private bool _unitPathsAreVisible;

	private bool _showTerrainDecay;

	private bool _showTerrainBreeder;

	[NonSerialized]
	public List<UnitManager> selectedUnits;

	[NonSerialized]
	public MoveTarget selectedMoveTarget;

	[NonSerialized]
	public TargetIndicator selectedTargetIndicator;

	[NonSerialized]
	public List<UnitManager> queuedTargetIndicatorUnits;

	private int lastMouseCellX;

	private int lastMouseCellY;

	private int mouseCellX;

	private int mouseCellY;

	private float doubleClickStart;

	private bool doubleClick;

	public AnimationCurve shakeDamper;

	[NonSerialized]
	public UnitBuildGhost unitToBuild;

	[NonSerialized]
	public TerrainDecal decalToBuild;

	private EditTerrainRangeIndicator editTerrainRangeIndicator;

	private bool ignoreUpdate;

	private bool _autoOrthoMode;

	private bool _orthoMode;

	private bool _terraformEditMode;

	private bool _editTerrainMode;

	private bool _editTerrainTextureMode;

	private bool _editCliffTextureMode;

	private bool _editDetailTextureMode;

	private bool _editDecayMode;

	private bool _editCreeperMode;

	private bool _editBreederMode;

	private bool _editScapeMode;

	private bool _editTerrainSquare;

	private bool _editTerrainFloodFill;

	private bool _editTerrainFloodFill2;

	private bool _editTerrainLevelFill;

	private bool _editTerrainAllFill;

	private bool _multiSelectKeyDown;

	private bool _waypointKeyDown;

	private bool _zoomPause;

	private int mouseDownTerrainHeight;

	public GameObject LEFT;

	public GameObject LEFTTRIGGER;

	public GameObject RIGHT;

	public GameObject RIGHTTRIGGER;

	public GameObject BOTTOM;

	public GameObject BOTTOMTRIGGER;

	public GameObject BOTTOMRIGHT;

	public GameObject BOTTOMRIGHTTRIGGER;

	public GameObject GRAPHCANVAS;

	[NonSerialized]
	public bool forceHandleInput;

	private int doubleClickLastCellX;

	private int doubleClickLastCellY;

	private GameObject editGrabbedUnit;

	private Vector3 editGrabbedUnitOffset;

	[NonSerialized]
	public Vector2 startDragSelect;

	private const float SHAKE_DURATION = 0.7f;

	private const float SHAKE_SPEED = 10f;

	private float shakeTimeRemaining;

	private float shakeMagnitude;

	private bool _mouseLook;

	private bool cameraUnderCreeper;

	public bool underCreeperEffectEnabled;

	private float lockzoomangle;

	private bool freeAngle;

	private float CAMERA_PAN_SPEED => 0f;

	private float CAMERA_PAN_SPEED_BUMP => 0f;

	public bool rplCam
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool rplCamCursorLock
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool autoCam
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideUI
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideSpores
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool disableShake
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int hideUIOverride
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool hidePaths
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool flattenAC
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool transparentCreeper
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool enemyOutline
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool otherOutline
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideMesh
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideShields
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool unitPathsAreVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideMist
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideExplosions
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool enhanceSpecials
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool spikeStumps
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool showTerrainDecay
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool showTerrainBreeder
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool showMapIndicator
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool topDownCam
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hoverPaths
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideCreeperContours
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool hideACContours
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool autoOrthoMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool orthoMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool terraformEditMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainTextureMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editCliffTextureMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editDetailTextureMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editDecayMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editCreeperMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editBreederMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editScapeMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainSquare
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainFloodFill
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainFloodFill2
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainLevelFill
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool editTerrainAllFill
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool multiSelectKeyDown
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool waypointKeyDown
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool zoomPause
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void RefreshOrthoMode(bool oldMode, bool value)
	{
	}

	public void ApplyAllOptions()
	{
	}

	public void ApplyHidePaths()
	{
	}

	public void ApplyFlattenAC()
	{
	}

	public void ApplyTransparentCreeper()
	{
	}

	public void ApplyEnemyOutline()
	{
	}

	public void ApplyOtherOutline()
	{
	}

	public void ApplyHideMist()
	{
	}

	public void ApplyHideExplosions()
	{
	}

	public void ApplyHideMesh()
	{
	}

	public void ApplyHideShields()
	{
	}

	public void ApplyEcoSpike()
	{
	}

	public void ApplyEnhanceSpecials()
	{
	}

	public void ApplyMapIndicator()
	{
	}

	public void ApplyTopDownCam()
	{
	}

	public void ApplyHideCreeperContours()
	{
	}

	public void ApplyHideACContours()
	{
	}

	public void ApplyHoverPaths()
	{
	}

	public void ApplyHideUI()
	{
	}

	public void ApplyHideSpores()
	{
	}

	public void ApplyDisableShake()
	{
	}

	public void ApplyAutoCam()
	{
	}

	public void UpdateHideUI()
	{
	}

	public void UpdateHideSpores()
	{
	}

	private void UpdateAutoCam()
	{
	}

	private void UpdateACOpacity()
	{
	}

	private void UpdateOpacity()
	{
	}

	public void SetTerraformEditMode(bool val)
	{
	}

	public void ToggleTerraformEditMode()
	{
	}

	public void Start()
	{
	}

	public static GameObject FindParentWithTag(GameObject childObject, string tag)
	{
		return null;
	}

	private bool IsRayCastBlocker()
	{
		return false;
	}

	private bool IsBlockerOpen()
	{
		return false;
	}

	public static bool IsMouseOverBlockingUI()
	{
		return false;
	}

	public List<RaycastResult> UIRaycastMouse()
	{
		return null;
	}

	public void Init()
	{
	}

	public void OnApplicationFocus(bool focus)
	{
	}

	private IEnumerator LazyOnApplicationFocus()
	{
		return null;
	}

	public void HandleInputEarly()
	{
	}

	public void ToggleEditMode()
	{
	}

	public void HandleInput()
	{
	}

	private void HandleTerraformEditing()
	{
	}

	private List<UnitManager> GetEditUnits()
	{
		return null;
	}

	private void HandleMapEditing()
	{
	}

	private void RefreshTerrainRangeIndicatorMapEditor()
	{
	}

	public void AutoFillLevelScape(ScapePanel.ITEM item, int level, int amt, bool del)
	{
	}

	private void ActOnCells(bool alternateBrushRange, float editTerrainCoverage, CellAction cellAction)
	{
	}

	private void HandleUnitBuilding()
	{
	}

	private void HandleDecalBuilding()
	{
	}

	public static bool IsControlDown()
	{
		return false;
	}

	public static bool IsAltDown()
	{
		return false;
	}

	public static bool IsShiftDown()
	{
		return false;
	}

	private bool IsPaintingTerrainOrTextures()
	{
		return false;
	}

	private void UnselectIfOnlyNonMovable()
	{
	}

	private void HandleUnits()
	{
	}

	private Rect GetSelectionRect(Vector2 start, Vector2 finish)
	{
		return default(Rect);
	}

	public void SelectSquadUnits(UnitManager um, int squad, bool sel)
	{
	}

	public int FormSquad()
	{
		return 0;
	}

	public void OnCreateSquad()
	{
	}

	public void OnSelectSquad()
	{
	}

	private void SelectNearbyUnits(UnitManager um, bool sel)
	{
	}

	private void SelectNearbyAircraftMoveTargetBases(AircraftMoveTargetIndicator amti, bool sel)
	{
	}

	public void ShakeCamera(float magnitude)
	{
	}

	private void ToggleMouseLook()
	{
	}

	public void ExitMouseLook()
	{
	}

	private void SetMouseLook(bool val)
	{
	}

	private bool BumpLeft()
	{
		return false;
	}

	private bool BumpRight()
	{
		return false;
	}

	private bool BumpUp()
	{
		return false;
	}

	private bool BumpDown()
	{
		return false;
	}

	private void ToggleFreeView()
	{
	}

	private bool ClearFreeView()
	{
		return false;
	}

	public bool MouseScreenCheck()
	{
		return false;
	}

	private void UpdateRPLCam()
	{
	}

	private void HandleMapMovement()
	{
	}

	private float GetNormalizedCameraHeight(float bias = 1f)
	{
		return 0f;
	}

	public void RplCamTweenLookat(Vector3 moveTo, Vector3 lookat, float time = 0.6f)
	{
	}

	public void RplCamTween(Vector3 moveTo, Vector3 rot, float time = 0.6f)
	{
	}

	public void RplCamCopyPosAndRot()
	{
	}

	public float GetViewAngle()
	{
		return 0f;
	}

	private Vector3 GetZOffset(float viewAngle)
	{
		return default(Vector3);
	}

	public void MoveCameraToLookat(Vector3 pos)
	{
	}

	public void MoveCameraToLookat(int cellX, int cellZ)
	{
	}

	private Vector3 GetBasePixelUnderMouse()
	{
		return default(Vector3);
	}

	public static void GetMouseCell(out int hitX, out int hitY, int maxHeight = 20)
	{
		hitX = default(int);
		hitY = default(int);
	}

	public static void GetScreenPosCell(Vector3 pos, out int hitX, out int hitY, int maxHeight = 20)
	{
		hitX = default(int);
		hitY = default(int);
	}

	private float GetZoomSpeedModifier()
	{
		return 0f;
	}

	private void ZoomIn(float scale)
	{
	}

	private void ZoomOut(float scale)
	{
	}

	private Vector3 GetSlideLeft(bool freeAngle, float CAMERA_PAN_SPEED, float scale)
	{
		return default(Vector3);
	}

	private Vector3 GetSlideRight(bool freeAngle, float CAMERA_PAN_SPEED, float scale)
	{
		return default(Vector3);
	}

	private Vector3 GetSlideUp(bool freeAngle, float CAMERA_PAN_SPEED, float scale)
	{
		return default(Vector3);
	}

	private Vector3 GetSlideDown(bool freeAngle, float CAMERA_PAN_SPEED, float scale)
	{
		return default(Vector3);
	}

	public bool ContainsSelectedUnit(UnitManager um)
	{
		return false;
	}

	public void AddSelectedUnit(UnitManager um)
	{
	}

	public void RemoveSelectedUnit(UnitManager um)
	{
	}

	public void UnselectAllUnits()
	{
	}

	public void PositionAircraftTempTargets(int cellX, int cellY)
	{
	}

	public void PositionUnitMoveGhosts(int cellX, int cellY)
	{
	}

	private void PositionSelectedMoveTarget(int cellX, int cellY)
	{
	}

	public void PositionSelectedTargetIndicator()
	{
	}

	private void PositionSelectedTargetIndicator(int cellX, int cellY)
	{
	}

	public void Cancel()
	{
	}

	public void OnLockZoomAngleChange(float value)
	{
	}

	public void SetFreeAngle(bool val)
	{
	}

	public bool GetFreeAngle()
	{
		return false;
	}

	public void OnFreeAngleChange(bool value)
	{
	}

	public void OnZoomPauseChange(bool value)
	{
	}

	public void OnSpeed1ToggleChange(bool value)
	{
	}

	public void OnSpeed2ToggleChange(bool value)
	{
	}

	public void OnSpeed4ToggleChange(bool value)
	{
	}

	public void OnPausePressed()
	{
	}

	public void OnZoomPausePressed()
	{
	}

	public static Vector3 GetResetPosition()
	{
		return default(Vector3);
	}

	public void OnResetMapView(bool instantly)
	{
	}

	public void OnRotate(float amt)
	{
	}

	public void OnResetMapView()
	{
	}

	private GameObject GetUnitUnderMouse(out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return null;
	}

	public List<T> GetSelectedUnitsOfType<T>(out int numUnitsOfType, out int numUnitsTotal) where T : UnitManager
	{
		numUnitsOfType = default(int);
		numUnitsTotal = default(int);
		return null;
	}

	public static void SelectSimilar(string unitName)
	{
	}

	public void SelectSimilar()
	{
	}
}
