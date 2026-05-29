using System;
using System.Collections.Generic;
using SoulGames.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SoulGames.EasyGridBuilderPro
{
	[ExecuteAlways]
	public class EasyGridBuilderPro : MonoBehaviour
	{
		public delegate void OnBuildableEdgeObjectFlipDelegate(float edgeRotation);

		public delegate void OnBuildConditionCheckCallerBuildableGridObjectDelegate(BuildableGridObjectTypeSO buildableGridObjectTypeSO);

		public delegate void OnBuildConditionCompleteCallerBuildableGridObjectDelegate(BuildableGridObjectTypeSO buildableGridObjectTypeSO);

		public delegate void OnBuildConditionCheckCallerBuildableEdgeObjectDelegate(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO);

		public delegate void OnBuildConditionCompleteCallerBuildableEdgebjectDelegate(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO);

		public delegate void OnBuildConditionCheckCallerBuildableFreeObjectDelegate(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO);

		public delegate void OnBuildConditionCompleteCallerBuildableFreeObjectDelegate(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO);

		public delegate void OnBuildableGridObjectTypeSOListChangeDelegate();

		public delegate void OnBuildableEdgeObjectTypeSOListChangeDelegate();

		public delegate void OnBuildableFreeObjectTypeSOListChangeDelegate();

		public class GridObjectXZ
		{
			private GridXZ<GridObjectXZ> gridXZ;

			private int x;

			private int y;

			public BuildableGridObject buildableGridObject;

			public BuildableEdgeObject downBuildableEdgeObject;

			public BuildableEdgeObject leftBuildableEdgeObject;

			public BuildableEdgeObject upBuildableEdgeObject;

			public BuildableEdgeObject rightBuildableEdgeObject;

			public GridObjectXZ(GridXZ<GridObjectXZ> grid, int x, int y)
			{
				gridXZ = grid;
				this.x = x;
				this.y = y;
				buildableGridObject = null;
				downBuildableEdgeObject = null;
				leftBuildableEdgeObject = null;
				upBuildableEdgeObject = null;
				rightBuildableEdgeObject = null;
			}

			public override string ToString()
			{
				return x + ", " + y + "\n" + buildableGridObject;
			}

			public void TriggerGridObjectChanged()
			{
				gridXZ.TriggerGridObjectChanged(x, y);
			}

			public void TriggerEdgeObjectChanged()
			{
				gridXZ.TriggerEdgeObjectChanged(x, y);
			}

			public void SetPlacedObject(BuildableGridObject buildableGridObject)
			{
				this.buildableGridObject = buildableGridObject;
				TriggerGridObjectChanged();
			}

			public void SetPlacedDownEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				downBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void SetPlacedLeftEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				leftBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void SetPlacedUpEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				upBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void SetPlacedRightEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				rightBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedObject()
			{
				buildableGridObject = null;
				TriggerGridObjectChanged();
			}

			public void ClearPlacedDownEdgeObject()
			{
				downBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedLeftEdgeObject()
			{
				leftBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedUpEdgeObject()
			{
				upBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedRightEdgeObject()
			{
				rightBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public BuildableGridObject GetPlacedObject()
			{
				return buildableGridObject;
			}

			public BuildableEdgeObject GetPlacedDownEdgeObject()
			{
				return downBuildableEdgeObject;
			}

			public BuildableEdgeObject GetPlacedLeftEdgeObject()
			{
				return leftBuildableEdgeObject;
			}

			public BuildableEdgeObject GetPlacedUpEdgeObject()
			{
				return upBuildableEdgeObject;
			}

			public BuildableEdgeObject GetPlacedRightEdgeObject()
			{
				return rightBuildableEdgeObject;
			}

			public bool CanBuild()
			{
				return buildableGridObject == null;
			}

			public bool CanBuildEdgeObjectDown()
			{
				return downBuildableEdgeObject == null;
			}

			public bool CanBuildEdgeObjectLeft()
			{
				return leftBuildableEdgeObject == null;
			}

			public bool CanBuildEdgeObjectUp()
			{
				return upBuildableEdgeObject == null;
			}

			public bool CanBuildEdgeObjectRight()
			{
				return rightBuildableEdgeObject == null;
			}
		}

		public class GridObjectXY
		{
			private GridXY<GridObjectXY> gridXY;

			private int x;

			private int y;

			public BuildableGridObject buildableGridObject;

			public BuildableEdgeObject downBuildableEdgeObject;

			public BuildableEdgeObject leftBuildableEdgeObject;

			public BuildableEdgeObject upBuildableEdgeObject;

			public BuildableEdgeObject rightBuildableEdgeObject;

			public GridObjectXY(GridXY<GridObjectXY> grid, int x, int y)
			{
				gridXY = grid;
				this.x = x;
				this.y = y;
				buildableGridObject = null;
				downBuildableEdgeObject = null;
				leftBuildableEdgeObject = null;
				upBuildableEdgeObject = null;
				rightBuildableEdgeObject = null;
			}

			public override string ToString()
			{
				return x + ", " + y + "\n" + buildableGridObject;
			}

			public void TriggerGridObjectChanged()
			{
				gridXY.TriggerGridObjectChanged(x, y);
			}

			public void TriggerEdgeObjectChanged()
			{
				gridXY.TriggerEdgeObjectChanged(x, y);
			}

			public void SetPlacedObject(BuildableGridObject buildableGridObject)
			{
				this.buildableGridObject = buildableGridObject;
				TriggerGridObjectChanged();
			}

			public void SetPlacedDownEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				downBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void SetPlacedLeftEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				leftBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void SetPlacedUpEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				upBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void SetPlacedRightEdgeObject(BuildableEdgeObject buildableEdgeObject)
			{
				rightBuildableEdgeObject = buildableEdgeObject;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedObject()
			{
				buildableGridObject = null;
				TriggerGridObjectChanged();
			}

			public void ClearPlacedDownEdgeObject()
			{
				downBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedLeftEdgeObject()
			{
				leftBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedUpEdgeObject()
			{
				upBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public void ClearPlacedRightEdgeObject()
			{
				rightBuildableEdgeObject = null;
				TriggerEdgeObjectChanged();
			}

			public BuildableGridObject GetPlacedObject()
			{
				return buildableGridObject;
			}

			public BuildableEdgeObject GetPlacedDownEdgeObject()
			{
				return downBuildableEdgeObject;
			}

			public BuildableEdgeObject GetPlacedLeftEdgeObject()
			{
				return leftBuildableEdgeObject;
			}

			public BuildableEdgeObject GetPlacedUpEdgeObject()
			{
				return upBuildableEdgeObject;
			}

			public BuildableEdgeObject GetPlacedRightEdgeObject()
			{
				return rightBuildableEdgeObject;
			}

			public bool CanBuild()
			{
				return buildableGridObject == null;
			}

			public bool CanBuildEdgeObjectDown()
			{
				return downBuildableEdgeObject == null;
			}

			public bool CanBuildEdgeObjectLeft()
			{
				return leftBuildableEdgeObject == null;
			}

			public bool CanBuildEdgeObjectUp()
			{
				return upBuildableEdgeObject == null;
			}

			public bool CanBuildEdgeObjectRight()
			{
				return rightBuildableEdgeObject == null;
			}
		}

		[Serializable]
		public class SaveObject
		{
			public PlacedObjectSaveObjectArray[] placedObjectSaveObjectArrayArray;

			public PlacedEdgeObjectSaveObjectArray[] placedEdgeObjectSaveObjectArrayArray;

			public LooseSaveObject[] looseSaveObjectArray;
		}

		[Serializable]
		public class PlacedObjectSaveObjectArray
		{
			public BuildableGridObject.SaveObject[] placedObjectSaveObjectArray;
		}

		[Serializable]
		public class PlacedEdgeObjectSaveObjectArray
		{
			public BuildableEdgeObject.SaveObject[] placedEdgeObjectSaveObjectArray;
		}

		[Serializable]
		public class LooseSaveObject
		{
			public string looseObjectSOName;

			public Vector3 position;

			public float quaternion;
		}

		[HideInInspector]
		public GridEditorMode gridEditorMode;

		private GridMode gridMode;

		private BuildableGridObjectTypeSO buildableGridObjectTypeSO;

		private BuildableGridObjectTypeSO.Dir dir;

		private BuildableFreeObjectTypeSO buildableFreeObjectTypeSO;

		private float buildableFreeObjectRotation;

		private List<Transform> builtBuildableFreeObjectList;

		private BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO;

		private BuildableEdgeObjectTypeSO.Dir edgeDir;

		private float edgeRotation;

		private Vector3 localMousePosition;

		private BuildableObjectType currentBuildableObjectType;

		private BoxCollider colliderObject;

		private int selectedIndex = 1;

		private bool isBuildableDestroyActive;

		private bool isBuildableBuildActive;

		private GameObject canvas;

		private List<GridXZ<GridObjectXZ>> gridXZList;

		private List<GridXY<GridObjectXY>> gridXYList;

		private GridXZ<GridObjectXZ> gridXZ;

		private GridXY<GridObjectXY> gridXY;

		private List<Vector3> gridOriginXZList;

		private List<Vector3> gridOriginXYList;

		private int currentActiveGridIndex;

		private bool useBuildModeActivationKey;

		private bool useDestructionModeActivationKey;

		private bool buildablePlacementKeyHolding;

		private bool ghostRotateLeftKeyHolding;

		private bool ghostRotateRightKeyHolding;

		private bool buildableAreaBlockerHit;

		private int gridObjectListCount;

		private int edgeObjectListCount;

		private int freeObjectListCount;

		[Space]
		[Tooltip("List of buildable grid objects. Take 'Buildable Grid Object Type SO' assets")]
		[SerializeField]
		private List<BuildableGridObjectTypeSO> buildableGridObjectTypeSOList;

		[Tooltip("List of buildable edge objects. Take 'Buildable Edge Object Type SO' assets")]
		[SerializeField]
		private List<BuildableEdgeObjectTypeSO> buildableEdgeObjectTypeSOList;

		[Tooltip("List of buildable free objects. Take 'Buildable Free Object Type SO' assets")]
		[SerializeField]
		private List<BuildableFreeObjectTypeSO> buildableFreeObjectTypeSOList;

		[Tooltip("Currently using grid axis. \n(XZ = Horizontal, More useful in 3D) \n(XY = Vertical, More useful in 2D)")]
		[SerializeField]
		public GridAxis gridAxis;

		[Tooltip("Width of the grid. \n(How many cells in the 1st axis)")]
		[Min(0f)]
		[SerializeField]
		private int gridWidth = 10;

		[Tooltip("Length of the grid. \n(How many cells in the 2nd axis)")]
		[Min(0f)]
		[SerializeField]
		private int gridLength = 10;

		[Tooltip("Cell size of the grid. \n(CellSize 1 = Unit 1)")]
		[Min(0f)]
		[SerializeField]
		private float cellSize = 10f;

		[Tooltip("Set XZ grid origin position in world space.")]
		[SerializeField]
		private Vector3 gridOriginXZ = new Vector3(0f, 0f, 0f);

		[Tooltip("Set XY grid origin position in world space.")]
		[SerializeField]
		private Vector3 gridOriginXY = new Vector3(0f, 0f, 0f);

		[Tooltip("Use attached game object's origin as grid orgin. If this is active 'Grid Origin' is ignored.")]
		[SerializeField]
		private bool useHolderPositionAsOrigin = true;

		[SerializeField]
		public bool showVerticalGridData;

		[Space]
		[Tooltip("How many grids should be created vertically")]
		[Min(1f)]
		[SerializeField]
		private int verticalGridsCount = 1;

		[Tooltip("Space between each vertical grid")]
		[Min(0f)]
		[SerializeField]
		private float gridHeight = 2.5f;

		[Tooltip("If enabled, Provided input will be used to swtich between vertical grids")]
		[SerializeField]
		private bool changeHeightWithInput = true;

		[Tooltip("If enabled, Vertical grid will choose automatically using the mouse position. If 'Change Height With Input' is also enabled, this will be ignored")]
		[SerializeField]
		public bool autoDetectHeight;

		[Tooltip("Layer Mask that use to check 'Auto Detect Height'.")]
		[Rename("Auto Detect Height Layer")]
		[SerializeField]
		public LayerMask autoDetectHeightLayerMask;

		[SerializeField]
		public bool showBuildableDistanceData;

		[Space]
		[Tooltip("Enable using buildable distance settings. \n(Make sure to set Min Max distances and the Object)")]
		[SerializeField]
		public bool useBuildableDistance;

		[Tooltip("Provide the object transform that should be used to check buildable distance. \n(If an object is not provided Camera's transform will be used)")]
		[SerializeField]
		private Transform distanceCheckObject;

		[Tooltip("Set the minimum distance that should be from 'distanceCheckObject'. \n(Set to 0 if you don't need a minimum distance check)")]
		[SerializeField]
		private float distanceMin;

		[Tooltip("Set the maximum distance that should be from 'distanceCheckObject'.")]
		[SerializeField]
		private float distanceMax;

		[SerializeField]
		public bool showGridObjectCollisionData;

		[Space]
		[Tooltip("Layer Mask that is used as grid surface. Simply set this to 'Grid Surface' Layer")]
		[Rename("Grid Object Colliding Layer")]
		[SerializeField]
		public LayerMask mouseColliderLayerMask;

		[Tooltip("Layer Mask that is used to place Buildable Free Objects. Simply check all the layers that Buildable Free Objects can be built on top of")]
		[Rename("Free Object Colliding Layer")]
		[SerializeField]
		public LayerMask freeObjectCollidingLayerMask;

		[Tooltip("Set the Created collider's size. \n(1 = collider size equal to the grid size) \n(If using value = 1, when mouse point is not on the grid, ghost object will snap to the center of the grid. To prevent this keep the collider larger than the grid. If you have multiple grids close to another, use a lower size)")]
		[Range(0f, 10f)]
		[SerializeField]
		private float colliderSizeMultiplier = 5f;

		[Tooltip("If this is disabled, When vertical grid is changed grid Collider will also change it's position according to the current active vertical grid.")]
		[SerializeField]
		private bool lockColliderOnHeightChange;

		[SerializeField]
		public bool showCanvasGridData;

		[Space]
		[Tooltip("Displays a canvas based grid in editor and play mode.")]
		[Rename("Show Editor&Runtime Canvas Grid")]
		[SerializeField]
		public bool showEditorAndRuntimeCanvasGrid;

		[Tooltip("Add provided 'Grid Canvas' prefab. \n(Must be provided)")]
		[SerializeField]
		public Canvas gridCanvasPrefab;

		[Tooltip("Add a provided sprite to use as the grid visual")]
		[SerializeField]
		public Sprite gridImageSprite;

		[Tooltip("Color of the grid when it is displaying")]
		[SerializeField]
		private Color showColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		[Tooltip("Color of the grid when it is not displaying.")]
		[SerializeField]
		private Color hideColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);

		[Tooltip("Color transition speed when grid change it's mode to show and hide.")]
		[Min(0f)]
		[SerializeField]
		private float colorTransitionSpeed = 20f;

		[Tooltip("Show grid in Default Mode \n(Visible even when not using the grid)")]
		[SerializeField]
		private bool showOnDefaultMode = true;

		[Tooltip("Show grid in Build Mode \n(Visible grid when placing objects)")]
		[SerializeField]
		private bool showOnBuildMode = true;

		[Tooltip("Show grid in Destruct Mode \n(Visible when destroying objects)")]
		[SerializeField]
		private bool showOnDestructMode = true;

		[Tooltip("Show grid in Selection Mode \n(Visible when selecting objects)")]
		[SerializeField]
		private bool showOnSelectedMode = true;

		[Tooltip("Color of the grid images.")]
		private bool showOnMoveMode = true;

		[Tooltip("If this is disabled, When vertical grid is changed Canvas grid view will also change it's position according to the current active vertical grid.")]
		[SerializeField]
		private bool lockCanvasGridOnHeightChange;

		[SerializeField]
		public bool showDebugGridData;

		[Space]
		[Tooltip("Display a debug grid in the editor and play mode. \n(Make sure to enable gizmos in editor and play mode)")]
		[Rename("Show Editor&Runtime Debug Grid")]
		[SerializeField]
		public bool showEditorAndRuntimeDebugGrid = true;

		[Tooltip("Color of the editor debug grid's lines.")]
		[Rename("Grid Lines Color")]
		[SerializeField]
		private Color editorGridLineColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		[Tooltip("If this is disabled, When vertical grid is changed Debug grid view will also change it's position according to the current active vertical grid.")]
		[SerializeField]
		private bool lockDebugGridOnHeightChange;

		[SerializeField]
		public bool showNodeGridData;

		[Space]
		[Tooltip("Display a node based grid in runtime mode. \n(Make sure to add 'Grid Node Prefab')")]
		[SerializeField]
		public bool showRuntimeNodeGrid;

		[Tooltip("Add prefab to spawn in each node cell. If multiple objects are provided, each cell will spawn a random object. \n(At least one must be provided)")]
		[SerializeField]
		private GameObject[] gridNodePrefab;

		[Tooltip("Node object's size as a percentage. \n(If cell size is 10 & 'Grid Node Size Percentage' is 20, Node object size will be = 2)")]
		[Rename("Grid Node Size Percentage")]
		[Range(0f, 100f)]
		[SerializeField]
		private float gridNodeMarginPercentage = 95f;

		[Tooltip("Each node object's local position offset.")]
		[SerializeField]
		private Vector3 gridNodeLocalOffset = new Vector3(0f, 0f, 0f);

		[SerializeField]
		public bool showTextGridData;

		[Space]
		[Tooltip("Displays a text based grid in runtime mode, Each grid cell will display it's grid position as a text. Use this with larger cells. Smaller grid cells can have a blurred or invisible text.")]
		[Rename("Show Runtime Text Grid")]
		[SerializeField]
		public bool showRuntimeGridText;

		[Tooltip("Color of the grid text.")]
		[SerializeField]
		private Color gridTextColor = new Color32(0, 0, 0, byte.MaxValue);

		[Tooltip("Grid text size as a multiplier. \n(2 = Double sized text) \n(0.5 = Half sized text)")]
		[Min(0f)]
		[SerializeField]
		private float gridTextSizeMultiplier = 1f;

		[Tooltip("Grid text displays each cell's value. \n(First cell will display = '0,0')")]
		[SerializeField]
		private bool showCellValueText = true;

		[Tooltip("Grid text displays a prefix text before Cell Value.")]
		[SerializeField]
		private string gridTextPrefix;

		[Tooltip("Grid text displays a suffix text after Cell Value.")]
		[SerializeField]
		private string gridTextSuffix;

		[Tooltip("Each text object's local position offset.")]
		[SerializeField]
		private Vector3 gridTextLocalOffset = new Vector3(0f, 0f, 0f);

		[SerializeField]
		public bool showSaveAndLoadData;

		[Space]
		[Tooltip("Activate save and load features.")]
		[Rename("Enable Save & Load")]
		[SerializeField]
		public bool enableSaveAndLoad = true;

		[Tooltip("Provide save file a unique name. \n(This name must be unique for each gridObject in all scenes. Grids with same ID will override saved data.)")]
		[SerializeField]
		public string uniqueSaveName = "EasyGridBuilder_SaveData_";

		[Tooltip("Provide save file location.")]
		[ReadOnly]
		[SerializeField]
		public string saveLocation = "/EasyGridBuilder Pro/LocalSaves/";

		[Space]
		[Tooltip("Displays various console debug commands. \n(Need to enable at least one of below commands)")]
		[Rename("Show Console Text")]
		[SerializeField]
		public bool showConsoleText;

		[SerializeField]
		public bool showConsoleData;

		[Space]
		[Tooltip("Displays a debug command when placing objects.")]
		[SerializeField]
		private bool objectPlacement;

		[Tooltip("Displays a debug command when destroying objects.")]
		[SerializeField]
		private bool objectDestruction;

		[Tooltip("Displays a debug command when selecting grid objects.")]
		[SerializeField]
		public bool objectSelected;

		[Tooltip("Displays a debug command when changing grid levels")]
		[SerializeField]
		public bool gridLevelChange;

		[Tooltip("Displays a debug command when grid is saved or load")]
		[SerializeField]
		private bool saveAndLoad;

		[Space]
		[Tooltip("Enables provided unity events below.")]
		[SerializeField]
		public bool enableUnityEvents;

		[SerializeField]
		public bool showBaseEvent;

		[Space]
		public UnityEvent OnSelectedBuildableChangedUnityEvent;

		public UnityEvent OnGridCellChangedUnityEvent;

		public UnityEvent OnActiveGridLevelChangedUnityEvent;

		[SerializeField]
		public bool showObjectInteractEvents;

		[Space]
		public UnityEvent OnObjectPlacedUnityEvent;

		public UnityEvent OnObjectRemovedUnityEvent;

		public UnityEvent OnObjectSelectedUnityEvent;

		public UnityEvent OnObjectDeselectedUnityEvent;

		public static EasyGridBuilderPro Instance { get; private set; }

		public event EventHandler OnSelectedBuildableChanged;

		public event EventHandler OnObjectPlaced;

		public event EventHandler OnActiveGridLevelChanged;

		public event EventHandler OnGridModeChange;

		public event OnBuildableEdgeObjectFlipDelegate OnBuildableEdgeObjectFlip;

		public event OnBuildConditionCheckCallerBuildableGridObjectDelegate OnBuildConditionCheckCallerBuildableGridObject;

		public event OnBuildConditionCompleteCallerBuildableGridObjectDelegate OnBuildConditionCompleteCallerBuildableGridObject;

		public event OnBuildConditionCheckCallerBuildableEdgeObjectDelegate OnBuildConditionCheckCallerBuildableEdgeObject;

		public event OnBuildConditionCompleteCallerBuildableEdgebjectDelegate OnBuildConditionCompleteCallerBuildableEdgeObject;

		public event OnBuildConditionCheckCallerBuildableFreeObjectDelegate OnBuildConditionCheckCallerBuildableFreeObject;

		public event OnBuildConditionCompleteCallerBuildableFreeObjectDelegate OnBuildConditionCompleteCallerBuildableFreeObject;

		public event OnBuildableGridObjectTypeSOListChangeDelegate OnBuildableGridObjectTypeSOListChange;

		public event OnBuildableEdgeObjectTypeSOListChangeDelegate OnBuildableEdgeObjectTypeSOListChange;

		public event OnBuildableFreeObjectTypeSOListChangeDelegate OnBuildableFreeObjectTypeSOListChange;

		private void Awake()
		{
			if (gridEditorMode == GridEditorMode.None)
			{
				return;
			}
			Instance = this;
			if (useHolderPositionAsOrigin)
			{
				if (gridEditorMode == GridEditorMode.GridLite)
				{
					gridOriginXZ = new Vector3(cellSize * (float)gridWidth / 2f * -1f + base.transform.position.x, base.transform.position.y, cellSize * (float)gridLength / 2f * -1f + base.transform.position.z);
					gridOriginXY = new Vector3(cellSize * (float)gridWidth / 2f * -1f + base.transform.position.x, cellSize * (float)gridLength / 2f * -1f + base.transform.position.y, base.transform.position.z);
				}
				else if (gridEditorMode == GridEditorMode.GridPro)
				{
					gridOriginXZList = new List<Vector3>();
					for (int i = 0; i < verticalGridsCount; i++)
					{
						Vector3 item = new Vector3(cellSize * (float)gridWidth / 2f * -1f + base.transform.position.x, base.transform.position.y + gridHeight * (float)i, cellSize * (float)gridLength / 2f * -1f + base.transform.position.z);
						gridOriginXZList.Add(item);
					}
					gridOriginXZ = gridOriginXZList[0];
					gridOriginXYList = new List<Vector3>();
					for (int j = 0; j < verticalGridsCount; j++)
					{
						Vector3 item2 = new Vector3(cellSize * (float)gridWidth / 2f * -1f + base.transform.position.x, cellSize * (float)gridLength / 2f * -1f + base.transform.position.y, base.transform.position.z - gridHeight * (float)j);
						gridOriginXYList.Add(item2);
					}
					gridOriginXY = gridOriginXYList[0];
				}
			}
			else if (gridEditorMode == GridEditorMode.GridPro)
			{
				gridOriginXZList = new List<Vector3>();
				for (int k = 0; k < verticalGridsCount; k++)
				{
					Vector3 item3 = new Vector3(gridOriginXZ.x, gridOriginXZ.y + gridHeight * (float)k, gridOriginXZ.z);
					gridOriginXZList.Add(item3);
				}
				gridOriginXZ = gridOriginXZList[0];
				gridOriginXYList = new List<Vector3>();
				for (int l = 0; l < verticalGridsCount; l++)
				{
					Vector3 item4 = new Vector3(gridOriginXY.x, gridOriginXY.y, gridOriginXY.z - gridHeight * (float)l);
					gridOriginXYList.Add(item4);
				}
				gridOriginXY = gridOriginXYList[0];
			}
			if (gridAxis == GridAxis.XZ)
			{
				if (Application.isPlaying)
				{
					if (gridEditorMode == GridEditorMode.GridLite)
					{
						gridXZ = new GridXZ<GridObjectXZ>(gridWidth, gridLength, cellSize, gridOriginXZ, (GridXZ<GridObjectXZ> g, int x, int y) => new GridObjectXZ(g, x, y), showRuntimeNodeGrid, showRuntimeGridText, gridTextColor, gridTextSizeMultiplier, showCellValueText, gridTextPrefix, gridTextSuffix, gridTextLocalOffset, base.transform, gridNodePrefab, gridNodeMarginPercentage, gridNodeLocalOffset);
					}
					else if (gridEditorMode == GridEditorMode.GridPro)
					{
						gridXZList = new List<GridXZ<GridObjectXZ>>();
						for (int num = 0; num < verticalGridsCount; num++)
						{
							GridXZ<GridObjectXZ> item5 = new GridXZ<GridObjectXZ>(gridWidth, gridLength, cellSize, gridOriginXZList[num], (GridXZ<GridObjectXZ> g, int x, int y) => new GridObjectXZ(g, x, y), showRuntimeNodeGrid, showRuntimeGridText, gridTextColor, gridTextSizeMultiplier, showCellValueText, gridTextPrefix, gridTextSuffix, gridTextLocalOffset, base.transform, gridNodePrefab, gridNodeMarginPercentage, gridNodeLocalOffset);
							gridXZList.Add(item5);
						}
						gridXZ = gridXZList[0];
					}
				}
				if (!base.transform.gameObject.GetComponent<BoxCollider>())
				{
					colliderObject = base.transform.gameObject.AddComponent<BoxCollider>();
					colliderObject.size = new Vector3(cellSize * (float)gridWidth * colliderSizeMultiplier, 0f, cellSize * (float)gridLength * colliderSizeMultiplier);
				}
			}
			else
			{
				if (Application.isPlaying)
				{
					if (gridEditorMode == GridEditorMode.GridLite)
					{
						gridXY = new GridXY<GridObjectXY>(gridWidth, gridLength, cellSize, gridOriginXY, (GridXY<GridObjectXY> g, int x, int y) => new GridObjectXY(g, x, y), showRuntimeNodeGrid, showRuntimeGridText, gridTextColor, gridTextSizeMultiplier, showCellValueText, gridTextPrefix, gridTextSuffix, gridTextLocalOffset, base.transform, gridNodePrefab, gridNodeMarginPercentage, gridNodeLocalOffset);
					}
					else if (gridEditorMode == GridEditorMode.GridPro)
					{
						gridXYList = new List<GridXY<GridObjectXY>>();
						for (int num2 = 0; num2 < verticalGridsCount; num2++)
						{
							GridXY<GridObjectXY> item6 = new GridXY<GridObjectXY>(gridWidth, gridLength, cellSize, gridOriginXYList[num2], (GridXY<GridObjectXY> g, int x, int y) => new GridObjectXY(g, x, y), showRuntimeNodeGrid, showRuntimeGridText, gridTextColor, gridTextSizeMultiplier, showCellValueText, gridTextPrefix, gridTextSuffix, gridTextLocalOffset, base.transform, gridNodePrefab, gridNodeMarginPercentage, gridNodeLocalOffset);
							gridXYList.Add(item6);
						}
						gridXY = gridXYList[0];
					}
				}
				if (!base.transform.gameObject.GetComponent<BoxCollider>())
				{
					colliderObject = base.transform.gameObject.AddComponent<BoxCollider>();
					colliderObject.size = new Vector3(cellSize * (float)gridWidth * colliderSizeMultiplier, cellSize * (float)gridLength * colliderSizeMultiplier, 0f);
				}
			}
			buildableGridObjectTypeSO = null;
			buildableEdgeObjectTypeSO = null;
			buildableFreeObjectTypeSO = null;
			builtBuildableFreeObjectList = new List<Transform>();
			gridObjectListCount = buildableGridObjectTypeSOList.Count;
			edgeObjectListCount = buildableEdgeObjectTypeSOList.Count;
			freeObjectListCount = buildableFreeObjectTypeSOList.Count;
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				GridObjectSelector.OnObjectSelect += OnObjectSelect;
				GridObjectSelector.OnObjectDeselect += OnObjectDeselect;
				GridObjectMover.OnObjectStartMoving += OnObjectStartMoving;
				GridObjectMover.OnObjectStoppedMoving += OnObjectStoppedMoving;
				GridObjectGhost.OnBuildableObjectAreaBlockerEnter += OnBuildableObjectAreaBlockerEnter;
				GridObjectGhost.OnBuildableObjectAreaBlockerExit += OnBuildableObjectAreaBlockerExit;
				FreeObjectGhost.OnBuildableObjectAreaBlockerEnter += OnBuildableObjectAreaBlockerEnter;
				FreeObjectGhost.OnBuildableObjectAreaBlockerExit += OnBuildableObjectAreaBlockerExit;
			}
			if (GetGridAxis() == GridAxis.XY)
			{
				buildableEdgeObjectTypeSOList.Clear();
			}
		}

		private void OnDestroy()
		{
			GridObjectSelector.OnObjectSelect -= OnObjectSelect;
			GridObjectSelector.OnObjectDeselect -= OnObjectDeselect;
			GridObjectMover.OnObjectStartMoving -= OnObjectStartMoving;
			GridObjectMover.OnObjectStoppedMoving -= OnObjectStoppedMoving;
			GridObjectGhost.OnBuildableObjectAreaBlockerEnter -= OnBuildableObjectAreaBlockerEnter;
			GridObjectGhost.OnBuildableObjectAreaBlockerExit -= OnBuildableObjectAreaBlockerExit;
			FreeObjectGhost.OnBuildableObjectAreaBlockerEnter -= OnBuildableObjectAreaBlockerEnter;
			FreeObjectGhost.OnBuildableObjectAreaBlockerExit -= OnBuildableObjectAreaBlockerExit;
		}

		private void OnObjectSelect(EasyGridBuilderPro ownSystem, GameObject selectedObject)
		{
			if (ownSystem == this && enableUnityEvents)
			{
				OnObjectSelectedUnityEvent?.Invoke();
			}
		}

		private void OnObjectDeselect(EasyGridBuilderPro ownSystem, GameObject selectedObject)
		{
			if (ownSystem == this && enableUnityEvents)
			{
				OnObjectDeselectedUnityEvent?.Invoke();
			}
		}

		private void OnBuildableObjectAreaBlockerEnter()
		{
			buildableAreaBlockerHit = true;
		}

		private void OnBuildableObjectAreaBlockerExit()
		{
			buildableAreaBlockerHit = false;
		}

		private void Update()
		{
			if (gridEditorMode == GridEditorMode.None)
			{
				return;
			}
			HandleGridOrigin();
			HandleGridCollider();
			HandleVisualCanvasGrid();
			if (!Application.isPlaying)
			{
				return;
			}
			localMousePosition = GetMouseWorldPosition();
			HandleAutoGridHeightDetection();
			HandleBuildableTypeSOChangeEvents();
			if (buildablePlacementKeyHolding)
			{
				if (buildableGridObjectTypeSO != null)
				{
					if (buildableGridObjectTypeSO.holdToPlace && !buildableGridObjectTypeSO.placeAndDeselect)
					{
						TriggerBuildablePlacement();
					}
				}
				else if (buildableEdgeObjectTypeSO != null)
				{
					if (buildableEdgeObjectTypeSO.holdToPlace && !buildableEdgeObjectTypeSO.placeAndDeselect)
					{
						TriggerBuildablePlacement();
					}
				}
				else if (buildableFreeObjectTypeSO != null && buildableFreeObjectTypeSO.holdToPlace && !buildableFreeObjectTypeSO.placeAndDeselect)
				{
					TriggerBuildablePlacement();
				}
			}
			if (ghostRotateLeftKeyHolding && buildableFreeObjectTypeSO != null)
			{
				buildableFreeObjectRotation -= Time.deltaTime * 90f;
			}
			if (ghostRotateRightKeyHolding && buildableFreeObjectTypeSO != null)
			{
				buildableFreeObjectRotation += Time.deltaTime * 90f;
			}
		}

		private void HandleGridOrigin()
		{
			if (useHolderPositionAsOrigin && !Application.isPlaying)
			{
				gridOriginXZ = new Vector3(cellSize * (float)gridWidth / 2f * -1f + base.transform.position.x, base.transform.position.y, cellSize * (float)gridLength / 2f * -1f + base.transform.position.z);
				gridOriginXY = new Vector3(cellSize * (float)gridWidth / 2f * -1f + base.transform.position.x, cellSize * (float)gridLength / 2f * -1f + base.transform.position.y, base.transform.position.z);
			}
		}

		private void HandleGridCollider()
		{
			if (!Application.isPlaying)
			{
				if (gridAxis == GridAxis.XZ)
				{
					if (!base.transform.gameObject.GetComponent<BoxCollider>())
					{
						colliderObject = base.transform.gameObject.AddComponent<BoxCollider>();
						return;
					}
					if (colliderObject == null)
					{
						colliderObject = base.transform.gameObject.GetComponent<BoxCollider>();
					}
					colliderObject.center = new Vector3(cellSize * (float)gridWidth / 2f + gridOriginXZ.x - base.transform.position.x, gridOriginXZ.y - base.transform.position.y, cellSize * (float)gridLength / 2f + gridOriginXZ.z - base.transform.position.z);
					colliderObject.size = new Vector3(cellSize * (float)gridWidth * colliderSizeMultiplier, 0f, cellSize * (float)gridLength * colliderSizeMultiplier);
				}
				else if (!base.transform.gameObject.GetComponent<BoxCollider>())
				{
					colliderObject = base.transform.gameObject.AddComponent<BoxCollider>();
				}
				else
				{
					if (colliderObject == null)
					{
						colliderObject = base.transform.gameObject.GetComponent<BoxCollider>();
					}
					colliderObject.center = new Vector3(cellSize * (float)gridWidth / 2f + gridOriginXY.x - base.transform.position.x, cellSize * (float)gridLength / 2f + gridOriginXY.y - base.transform.position.y, gridOriginXY.z - base.transform.position.z);
					colliderObject.size = new Vector3(cellSize * (float)gridWidth * colliderSizeMultiplier, cellSize * (float)gridLength * colliderSizeMultiplier, 0f);
				}
			}
			else if (colliderObject == null)
			{
				colliderObject = base.transform.gameObject.GetComponent<BoxCollider>();
			}
			else if (gridAxis == GridAxis.XZ)
			{
				if (lockColliderOnHeightChange && gridEditorMode == GridEditorMode.GridPro)
				{
					colliderObject.center = new Vector3(cellSize * (float)gridWidth / 2f + gridOriginXZList[0].x - base.transform.position.x, gridOriginXZList[0].y - base.transform.position.y, cellSize * (float)gridLength / 2f + gridOriginXZList[0].z - base.transform.position.z);
				}
				else
				{
					colliderObject.center = new Vector3(cellSize * (float)gridWidth / 2f + gridOriginXZ.x - base.transform.position.x, gridOriginXZ.y - base.transform.position.y, cellSize * (float)gridLength / 2f + gridOriginXZ.z - base.transform.position.z);
				}
			}
			else if (lockColliderOnHeightChange && gridEditorMode == GridEditorMode.GridPro)
			{
				colliderObject.center = new Vector3(cellSize * (float)gridWidth / 2f + gridOriginXYList[0].x - base.transform.position.x, cellSize * (float)gridLength / 2f + gridOriginXYList[0].y - base.transform.position.y, gridOriginXYList[0].z - base.transform.position.z);
			}
			else
			{
				colliderObject.center = new Vector3(cellSize * (float)gridWidth / 2f + gridOriginXY.x - base.transform.position.x, cellSize * (float)gridLength / 2f + gridOriginXY.y - base.transform.position.y, gridOriginXY.z - base.transform.position.z);
			}
		}

		private void HandleVisualCanvasGrid()
		{
			if (gridAxis == GridAxis.XZ)
			{
				if (showEditorAndRuntimeCanvasGrid && !canvas && (bool)gridCanvasPrefab)
				{
					if (!base.transform.Find("Grid Canvas(Clone)"))
					{
						canvas = UnityEngine.Object.Instantiate(gridCanvasPrefab.gameObject, Vector3.zero, Quaternion.identity);
						canvas.transform.SetParent(base.transform, worldPositionStays: false);
					}
					else
					{
						canvas = base.transform.Find("Grid Canvas(Clone)").gameObject;
					}
				}
				if (!showEditorAndRuntimeCanvasGrid && base.transform.childCount != 0)
				{
					for (int i = 0; i < base.transform.childCount; i++)
					{
						Transform child = base.transform.GetChild(i);
						if (child.name == "Grid Canvas(Clone)")
						{
							UnityEngine.Object.DestroyImmediate(child.gameObject);
						}
					}
				}
				if (!canvas)
				{
					return;
				}
				Vector2 sizeDelta = new Vector2((float)gridWidth * cellSize, (float)gridLength * cellSize);
				Transform child2 = canvas.transform.GetChild(0);
				Image component = child2.GetComponent<Image>();
				canvas.transform.eulerAngles = new Vector3(90f, 0f, 0f);
				if (Application.isPlaying && lockCanvasGridOnHeightChange && gridEditorMode == GridEditorMode.GridPro)
				{
					canvas.transform.position = gridOriginXZList[0];
				}
				else
				{
					canvas.transform.position = gridOriginXZ;
				}
				canvas.GetComponent<RectTransform>().sizeDelta = sizeDelta;
				child2.GetComponent<RectTransform>().sizeDelta = sizeDelta;
				component.sprite = gridImageSprite;
				component.type = Image.Type.Tiled;
				component.pixelsPerUnitMultiplier = 100f / cellSize;
				if (Application.isPlaying)
				{
					switch (GetGridMode())
					{
					case GridMode.None:
						if (showOnDefaultMode)
						{
							if (component.color != showColor)
							{
								CanvasAlphaTransition(_showAlpha: true, component);
							}
						}
						else if (component.color != hideColor)
						{
							CanvasAlphaTransition(_showAlpha: false, component);
						}
						break;
					case GridMode.Build:
						if (showOnBuildMode)
						{
							if (component.color != showColor)
							{
								CanvasAlphaTransition(_showAlpha: true, component);
							}
						}
						else if (component.color != hideColor)
						{
							CanvasAlphaTransition(_showAlpha: false, component);
						}
						break;
					case GridMode.Destruct:
						if (showOnDestructMode)
						{
							if (component.color != showColor)
							{
								CanvasAlphaTransition(_showAlpha: true, component);
							}
						}
						else if (component.color != hideColor)
						{
							CanvasAlphaTransition(_showAlpha: false, component);
						}
						break;
					case GridMode.Selected:
						if (showOnSelectedMode)
						{
							if (component.color != showColor)
							{
								CanvasAlphaTransition(_showAlpha: true, component);
							}
						}
						else if (component.color != hideColor)
						{
							CanvasAlphaTransition(_showAlpha: false, component);
						}
						break;
					case GridMode.Moving:
						if (showOnMoveMode)
						{
							if (component.color != showColor)
							{
								CanvasAlphaTransition(_showAlpha: true, component);
							}
						}
						else if (component.color != hideColor)
						{
							CanvasAlphaTransition(_showAlpha: false, component);
						}
						break;
					}
				}
				else
				{
					component.color = showColor;
				}
				return;
			}
			if (showEditorAndRuntimeCanvasGrid && !canvas && (bool)gridCanvasPrefab)
			{
				if (!base.transform.Find("Grid Canvas(Clone)"))
				{
					canvas = UnityEngine.Object.Instantiate(gridCanvasPrefab.gameObject, Vector3.zero, Quaternion.identity);
					canvas.transform.SetParent(base.transform, worldPositionStays: false);
				}
				else
				{
					canvas = base.transform.Find("Grid Canvas(Clone)").gameObject;
				}
			}
			if (!showEditorAndRuntimeCanvasGrid && base.transform.childCount != 0)
			{
				for (int j = 0; j < base.transform.childCount; j++)
				{
					Transform child3 = base.transform.GetChild(j);
					if (child3.name == "Grid Canvas(Clone)")
					{
						UnityEngine.Object.DestroyImmediate(child3.gameObject);
					}
				}
			}
			if (!canvas)
			{
				return;
			}
			Vector2 sizeDelta2 = new Vector2((float)gridWidth * cellSize, (float)gridLength * cellSize);
			Transform child4 = canvas.transform.GetChild(0);
			Image component2 = child4.GetComponent<Image>();
			canvas.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			if (Application.isPlaying && lockCanvasGridOnHeightChange && gridEditorMode == GridEditorMode.GridPro)
			{
				canvas.transform.position = gridOriginXYList[0];
			}
			else
			{
				canvas.transform.position = gridOriginXY;
			}
			canvas.GetComponent<RectTransform>().sizeDelta = sizeDelta2;
			child4.GetComponent<RectTransform>().sizeDelta = sizeDelta2;
			component2.sprite = gridImageSprite;
			component2.type = Image.Type.Tiled;
			component2.pixelsPerUnitMultiplier = 100f / cellSize;
			if (Application.isPlaying)
			{
				switch (GetGridMode())
				{
				case GridMode.None:
					if (showOnDefaultMode)
					{
						if (component2.color != showColor)
						{
							CanvasAlphaTransition(_showAlpha: true, component2);
						}
					}
					else if (component2.color != hideColor)
					{
						CanvasAlphaTransition(_showAlpha: false, component2);
					}
					break;
				case GridMode.Build:
					if (showOnBuildMode)
					{
						if (component2.color != showColor)
						{
							CanvasAlphaTransition(_showAlpha: true, component2);
						}
					}
					else if (component2.color != hideColor)
					{
						CanvasAlphaTransition(_showAlpha: false, component2);
					}
					break;
				case GridMode.Destruct:
					if (showOnDestructMode)
					{
						if (component2.color != showColor)
						{
							CanvasAlphaTransition(_showAlpha: true, component2);
						}
					}
					else if (component2.color != hideColor)
					{
						CanvasAlphaTransition(_showAlpha: false, component2);
					}
					break;
				case GridMode.Selected:
					if (showOnSelectedMode)
					{
						if (component2.color != showColor)
						{
							CanvasAlphaTransition(_showAlpha: true, component2);
						}
					}
					else if (component2.color != hideColor)
					{
						CanvasAlphaTransition(_showAlpha: false, component2);
					}
					break;
				case GridMode.Moving:
					if (showOnMoveMode)
					{
						if (component2.color != showColor)
						{
							CanvasAlphaTransition(_showAlpha: true, component2);
						}
					}
					else if (component2.color != hideColor)
					{
						CanvasAlphaTransition(_showAlpha: false, component2);
					}
					break;
				}
			}
			else
			{
				component2.color = showColor;
			}
		}

		private void CanvasAlphaTransition(bool _showAlpha, Image gridImage)
		{
			if (_showAlpha)
			{
				gridImage.color = Color.Lerp(gridImage.color, showColor, colorTransitionSpeed * Time.deltaTime);
			}
			else
			{
				gridImage.color = Color.Lerp(gridImage.color, hideColor, colorTransitionSpeed * Time.deltaTime);
			}
		}

		private void HandleAutoGridHeightDetection()
		{
			if (!autoDetectHeight || changeHeightWithInput || gridEditorMode != GridEditorMode.GridPro || GetGridMode() == GridMode.None)
			{
				return;
			}
			if (gridAxis == GridAxis.XZ)
			{
				int num = Mathf.Clamp(Mathf.RoundToInt((AutoDetectHeightMousePosition().y - gridOriginXZList[0].y) / gridHeight), 0, gridXZList.Count - 1);
				gridXZ = gridXZList[num];
				this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnActiveGridLevelChangedUnityEvent?.Invoke();
				}
				if (showConsoleText && gridLevelChange)
				{
					Debug.Log("Grid XZ <color=green>Grid Level Changed! Current Grid Level :</color> " + (num + 1));
				}
				gridOriginXZ = gridOriginXZList[num];
				currentActiveGridIndex = num;
			}
			else
			{
				int num2 = Mathf.Clamp(Mathf.RoundToInt((AutoDetectHeightMousePosition().z - gridOriginXYList[0].z) * -1f / gridHeight), 0, gridXYList.Count - 1);
				gridXY = gridXYList[num2];
				this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnActiveGridLevelChangedUnityEvent?.Invoke();
				}
				if (showConsoleText && gridLevelChange)
				{
					Debug.Log("Grid XY <color=green>Grid Level Changed! Current Grid Level :</color> " + (num2 + 1));
				}
				gridOriginXY = gridOriginXYList[num2];
				currentActiveGridIndex = num2;
			}
		}

		private void HandleBuildableTypeSOChangeEvents()
		{
			if (gridObjectListCount != buildableGridObjectTypeSOList.Count)
			{
				this.OnBuildableGridObjectTypeSOListChange?.Invoke();
				gridObjectListCount = buildableGridObjectTypeSOList.Count;
			}
			if (edgeObjectListCount != buildableEdgeObjectTypeSOList.Count)
			{
				this.OnBuildableEdgeObjectTypeSOListChange?.Invoke();
				edgeObjectListCount = buildableEdgeObjectTypeSOList.Count;
			}
			if (freeObjectListCount != buildableFreeObjectTypeSOList.Count)
			{
				this.OnBuildableFreeObjectTypeSOListChange?.Invoke();
				freeObjectListCount = buildableFreeObjectTypeSOList.Count;
			}
		}

		public void SetInputGridModeVariables(bool useBuildModeActivationKey, bool useDestructionModeActivationKey, bool useSelectionModeActivationKey)
		{
			this.useBuildModeActivationKey = useBuildModeActivationKey;
			this.useDestructionModeActivationKey = useDestructionModeActivationKey;
		}

		public void SetGridModeReset()
		{
			DeselectObjectType();
		}

		public void TriggerGridHeightChangeManually()
		{
			if (!changeHeightWithInput || gridEditorMode != GridEditorMode.GridPro)
			{
				return;
			}
			if (gridAxis == GridAxis.XZ)
			{
				int num = (gridXZList.IndexOf(gridXZ) + 1) % gridXZList.Count;
				gridXZ = gridXZList[num];
				this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnActiveGridLevelChangedUnityEvent?.Invoke();
				}
				if (showConsoleText && gridLevelChange)
				{
					Debug.Log("Grid XZ <color=green>Grid Level Changed! Current Grid Level :</color> " + (num + 1));
				}
				gridOriginXZ = gridOriginXZList[num];
				currentActiveGridIndex = num;
			}
			else
			{
				int num2 = (gridXYList.IndexOf(gridXY) + 1) % gridXYList.Count;
				gridXY = gridXYList[num2];
				this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnActiveGridLevelChangedUnityEvent?.Invoke();
				}
				if (showConsoleText && gridLevelChange)
				{
					Debug.Log("Grid XY <color=green>Grid Level Changed! Current Grid Level :</color> " + (num2 + 1));
				}
				gridOriginXY = gridOriginXYList[num2];
				currentActiveGridIndex = num2;
			}
		}

		public void TriggerGridHeightChangeUI(Vector2 value)
		{
			if (!changeHeightWithInput || gridEditorMode != GridEditorMode.GridPro)
			{
				return;
			}
			if (value.y > 0f)
			{
				if (gridAxis == GridAxis.XZ)
				{
					int value2 = gridXZList.IndexOf(gridXZ) + 1;
					value2 = Mathf.Clamp(value2, 0, gridXZList.Count - 1);
					gridXZ = gridXZList[value2];
					this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
					if (enableUnityEvents)
					{
						OnActiveGridLevelChangedUnityEvent?.Invoke();
					}
					if (showConsoleText && gridLevelChange)
					{
						Debug.Log("Grid XZ <color=green>Grid Level Changed! Current Grid Level :</color> " + (value2 + 1));
					}
					gridOriginXZ = gridOriginXZList[value2];
					currentActiveGridIndex = value2;
				}
				else
				{
					int value3 = gridXYList.IndexOf(gridXY) + 1;
					value3 = Mathf.Clamp(value3, 0, gridXYList.Count - 1);
					gridXY = gridXYList[value3];
					this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
					if (enableUnityEvents)
					{
						OnActiveGridLevelChangedUnityEvent?.Invoke();
					}
					if (showConsoleText && gridLevelChange)
					{
						Debug.Log("Grid XY <color=green>Grid Level Changed! Current Grid Level :</color> " + (value3 + 1));
					}
					gridOriginXY = gridOriginXYList[value3];
					currentActiveGridIndex = value3;
				}
			}
			else
			{
				if (!(value.y < 0f))
				{
					return;
				}
				if (gridAxis == GridAxis.XZ)
				{
					int value4 = gridXZList.IndexOf(gridXZ) - 1;
					value4 = Mathf.Clamp(value4, 0, gridXZList.Count - 1);
					gridXZ = gridXZList[value4];
					this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
					if (enableUnityEvents)
					{
						OnActiveGridLevelChangedUnityEvent?.Invoke();
					}
					if (showConsoleText && gridLevelChange)
					{
						Debug.Log("Grid XZ <color=green>Grid Level Changed! Current Grid Level :</color> " + (value4 + 1));
					}
					gridOriginXZ = gridOriginXZList[value4];
					currentActiveGridIndex = value4;
				}
				else
				{
					int value5 = gridXYList.IndexOf(gridXY) - 1;
					value5 = Mathf.Clamp(value5, 0, gridXYList.Count - 1);
					gridXY = gridXYList[value5];
					this.OnActiveGridLevelChanged?.Invoke(this, EventArgs.Empty);
					if (enableUnityEvents)
					{
						OnActiveGridLevelChangedUnityEvent?.Invoke();
					}
					if (showConsoleText && gridLevelChange)
					{
						Debug.Log("Grid XY <color=green>Grid Level Changed! Current Grid Level :</color> " + (value5 + 1));
					}
					gridOriginXY = gridOriginXYList[value5];
					currentActiveGridIndex = value5;
				}
			}
		}

		public void SetGridModeBuilding()
		{
			if (useBuildModeActivationKey)
			{
				if (GetGridMode() != GridMode.Build)
				{
					isBuildableBuildActive = true;
					SetGridMode(GridMode.Build);
				}
				else
				{
					isBuildableBuildActive = false;
					SetGridMode(GridMode.None);
				}
			}
		}

		public void TriggerBuildablePlacement()
		{
			buildablePlacementKeyHolding = true;
			if (!MultiGridManager.Instance.onGrid || MultiGridManager.Instance.activeGridSystem != this)
			{
				return;
			}
			if (!useBuildModeActivationKey)
			{
				isBuildableBuildActive = true;
			}
			if (currentBuildableObjectType == BuildableObjectType.DefaultObject)
			{
				if (buildableGridObjectTypeSO != null && (GetGridMode() == GridMode.None || GetGridMode() == GridMode.Build))
				{
					if (buildableGridObjectTypeSO.holdToPlace && !buildableGridObjectTypeSO.placeAndDeselect)
					{
						if (isBuildableBuildActive && buildableGridObjectTypeSO != null && !IsPointerOverUI())
						{
							Vector3 mouseWorldPosition = GetMouseWorldPosition();
							if (useBuildableDistance)
							{
								if (!distanceCheckObject)
								{
									distanceCheckObject = Camera.main.transform;
								}
								if (Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) > distanceMin && Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) < distanceMax)
								{
									CallObjectPlacementGridObject(mouseWorldPosition);
								}
								else if (showConsoleText && objectPlacement)
								{
									Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Not inside the provided Min/Max range. Distance : " + Vector3.Distance(distanceCheckObject.position, mouseWorldPosition));
								}
							}
							else
							{
								CallObjectPlacementGridObject(mouseWorldPosition);
							}
						}
					}
					else if (isBuildableBuildActive && buildableGridObjectTypeSO != null && !IsPointerOverUI())
					{
						Vector3 mouseWorldPosition2 = GetMouseWorldPosition();
						if (useBuildableDistance)
						{
							if (!distanceCheckObject)
							{
								distanceCheckObject = Camera.main.transform;
							}
							if (Vector3.Distance(distanceCheckObject.position, mouseWorldPosition2) > distanceMin && Vector3.Distance(distanceCheckObject.position, mouseWorldPosition2) < distanceMax)
							{
								CallObjectPlacementGridObject(mouseWorldPosition2);
								if (buildableGridObjectTypeSO.placeAndDeselect && !buildableGridObjectTypeSO.holdToPlace)
								{
									DeselectObjectType();
								}
							}
							else if (showConsoleText && objectPlacement)
							{
								Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Not inside the provided Min/Max range. Distance : " + Vector3.Distance(distanceCheckObject.position, mouseWorldPosition2));
							}
						}
						else
						{
							CallObjectPlacementGridObject(mouseWorldPosition2);
							if (buildableGridObjectTypeSO.placeAndDeselect)
							{
								DeselectObjectType();
							}
						}
					}
				}
			}
			else if (currentBuildableObjectType == BuildableObjectType.EdgeObject)
			{
				if (buildableEdgeObjectTypeSO != null && (GetGridMode() == GridMode.None || GetGridMode() == GridMode.Build))
				{
					if (buildableEdgeObjectTypeSO.holdToPlace && !buildableEdgeObjectTypeSO.placeAndDeselect)
					{
						if (isBuildableBuildActive && buildableEdgeObjectTypeSO != null && !IsPointerOverUI())
						{
							Vector3 mouseWorldPosition3 = GetMouseWorldPosition();
							if (useBuildableDistance)
							{
								if (!distanceCheckObject)
								{
									distanceCheckObject = Camera.main.transform;
								}
								if (Vector3.Distance(distanceCheckObject.position, mouseWorldPosition3) > distanceMin && Vector3.Distance(distanceCheckObject.position, mouseWorldPosition3) < distanceMax)
								{
									CallObjectPlacementEdgeObject(mouseWorldPosition3);
								}
								else if (showConsoleText && objectPlacement)
								{
									Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Not inside the provided Min/Max range. Distance : " + Vector3.Distance(distanceCheckObject.position, mouseWorldPosition3));
								}
							}
							else
							{
								CallObjectPlacementEdgeObject(mouseWorldPosition3);
							}
						}
					}
					else if (isBuildableBuildActive && buildableEdgeObjectTypeSO != null && !IsPointerOverUI())
					{
						Vector3 mouseWorldPosition4 = GetMouseWorldPosition();
						if (useBuildableDistance)
						{
							if (!distanceCheckObject)
							{
								distanceCheckObject = Camera.main.transform;
							}
							if (Vector3.Distance(distanceCheckObject.position, mouseWorldPosition4) > distanceMin && Vector3.Distance(distanceCheckObject.position, mouseWorldPosition4) < distanceMax)
							{
								CallObjectPlacementEdgeObject(mouseWorldPosition4);
								if (buildableEdgeObjectTypeSO.placeAndDeselect && !buildableEdgeObjectTypeSO.holdToPlace)
								{
									DeselectObjectType();
								}
							}
							else if (showConsoleText && objectPlacement)
							{
								Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Not inside the provided Min/Max range. Distance : " + Vector3.Distance(distanceCheckObject.position, mouseWorldPosition4));
							}
						}
						else
						{
							CallObjectPlacementEdgeObject(mouseWorldPosition4);
							if (buildableEdgeObjectTypeSO.placeAndDeselect)
							{
								DeselectObjectType();
							}
						}
					}
				}
			}
			else if (currentBuildableObjectType == BuildableObjectType.FreeObject && buildableFreeObjectTypeSO != null && (GetGridMode() == GridMode.None || GetGridMode() == GridMode.Build))
			{
				if (buildableFreeObjectTypeSO.holdToPlace && !buildableFreeObjectTypeSO.placeAndDeselect)
				{
					if (isBuildableBuildActive && buildableFreeObjectTypeSO != null && !IsPointerOverUI())
					{
						Vector3 mouseWorldPosition5 = GetMouseWorldPosition();
						if (useBuildableDistance)
						{
							if (!distanceCheckObject)
							{
								distanceCheckObject = Camera.main.transform;
							}
							if (Vector3.Distance(distanceCheckObject.position, mouseWorldPosition5) > distanceMin && Vector3.Distance(distanceCheckObject.position, mouseWorldPosition5) < distanceMax)
							{
								CallObjectPlacementFreeObject(mouseWorldPosition5);
							}
							else if (showConsoleText && objectPlacement)
							{
								Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Not inside the provided Min/Max range. Distance : " + Vector3.Distance(distanceCheckObject.position, mouseWorldPosition5));
							}
						}
						else
						{
							CallObjectPlacementFreeObject(mouseWorldPosition5);
						}
					}
				}
				else if (isBuildableBuildActive && buildableFreeObjectTypeSO != null && !IsPointerOverUI())
				{
					Vector3 mouseWorldPosition6 = GetMouseWorldPosition();
					if (useBuildableDistance)
					{
						if (!distanceCheckObject)
						{
							distanceCheckObject = Camera.main.transform;
						}
						if (Vector3.Distance(distanceCheckObject.position, mouseWorldPosition6) > distanceMin && Vector3.Distance(distanceCheckObject.position, mouseWorldPosition6) < distanceMax)
						{
							CallObjectPlacementFreeObject(mouseWorldPosition6);
							if (buildableFreeObjectTypeSO.placeAndDeselect && !buildableFreeObjectTypeSO.holdToPlace)
							{
								DeselectObjectType();
							}
						}
						else if (showConsoleText && objectPlacement)
						{
							Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Not inside the provided Min/Max range. Distance : " + Vector3.Distance(distanceCheckObject.position, mouseWorldPosition6));
						}
					}
					else
					{
						CallObjectPlacementFreeObject(mouseWorldPosition6);
						if (buildableFreeObjectTypeSO.placeAndDeselect)
						{
							DeselectObjectType();
						}
					}
				}
			}
			if (!useBuildModeActivationKey)
			{
				isBuildableBuildActive = false;
			}
		}

		public void TriggerBuildablePlacementCancelled()
		{
			buildablePlacementKeyHolding = false;
		}

		public void TriggerBuildableListScroll(Vector2 value)
		{
			if (!useBuildModeActivationKey)
			{
				isBuildableBuildActive = true;
			}
			if (isBuildableBuildActive && (GetGridMode() == GridMode.None || GetGridMode() == GridMode.Build))
			{
				if (gridEditorMode == GridEditorMode.GridLite)
				{
					if (value.y > 0f)
					{
						if (buildableGridObjectTypeSOList.Count > 0)
						{
							if (selectedIndex < buildableGridObjectTypeSOList.Count)
							{
								selectedIndex++;
							}
							selectedIndex = Mathf.Clamp(selectedIndex, 1, buildableGridObjectTypeSOList.Count);
							buildableGridObjectTypeSO = buildableGridObjectTypeSOList[selectedIndex - 1];
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
						}
					}
					else if (value.y < 0f && buildableGridObjectTypeSOList.Count > 0)
					{
						if (selectedIndex != 1)
						{
							selectedIndex--;
						}
						selectedIndex = Mathf.Clamp(selectedIndex, 1, buildableGridObjectTypeSOList.Count);
						buildableGridObjectTypeSO = buildableGridObjectTypeSOList[selectedIndex - 1];
						RefreshselectedIndexType();
						isBuildableDestroyActive = false;
						if (GetGridMode() != GridMode.Build)
						{
							SetGridMode(GridMode.Build);
						}
						if (enableUnityEvents)
						{
							OnSelectedBuildableChangedUnityEvent?.Invoke();
						}
					}
				}
				else if (gridEditorMode == GridEditorMode.GridPro)
				{
					if (value.y > 0f)
					{
						int num = buildableGridObjectTypeSOList.Count + buildableEdgeObjectTypeSOList.Count + buildableFreeObjectTypeSOList.Count;
						if (num > 0)
						{
							if (selectedIndex < num)
							{
								selectedIndex++;
							}
							selectedIndex = Mathf.Clamp(selectedIndex, 1, num);
							if (selectedIndex <= buildableGridObjectTypeSOList.Count)
							{
								buildableGridObjectTypeSO = buildableGridObjectTypeSOList[selectedIndex - 1];
								currentBuildableObjectType = BuildableObjectType.DefaultObject;
								buildableFreeObjectTypeSO = null;
								buildableEdgeObjectTypeSO = null;
							}
							else if (selectedIndex <= buildableGridObjectTypeSOList.Count + buildableEdgeObjectTypeSOList.Count && selectedIndex > buildableGridObjectTypeSOList.Count)
							{
								buildableEdgeObjectTypeSO = buildableEdgeObjectTypeSOList[selectedIndex - buildableGridObjectTypeSOList.Count - 1];
								currentBuildableObjectType = BuildableObjectType.EdgeObject;
								buildableGridObjectTypeSO = null;
								buildableFreeObjectTypeSO = null;
							}
							else
							{
								buildableFreeObjectTypeSO = buildableFreeObjectTypeSOList[selectedIndex - buildableGridObjectTypeSOList.Count - buildableEdgeObjectTypeSOList.Count - 1];
								currentBuildableObjectType = BuildableObjectType.FreeObject;
								buildableGridObjectTypeSO = null;
								buildableEdgeObjectTypeSO = null;
							}
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
						}
					}
					else if (value.y < 0f)
					{
						int num2 = buildableGridObjectTypeSOList.Count + buildableEdgeObjectTypeSOList.Count + buildableFreeObjectTypeSOList.Count;
						if (num2 > 0)
						{
							if (selectedIndex != 1)
							{
								selectedIndex--;
							}
							selectedIndex = Mathf.Clamp(selectedIndex, 1, num2);
							if (selectedIndex <= buildableGridObjectTypeSOList.Count)
							{
								buildableGridObjectTypeSO = buildableGridObjectTypeSOList[selectedIndex - 1];
								currentBuildableObjectType = BuildableObjectType.DefaultObject;
								buildableEdgeObjectTypeSO = null;
								buildableFreeObjectTypeSO = null;
							}
							else if (selectedIndex <= buildableGridObjectTypeSOList.Count + buildableEdgeObjectTypeSOList.Count && selectedIndex > buildableGridObjectTypeSOList.Count)
							{
								buildableEdgeObjectTypeSO = buildableEdgeObjectTypeSOList[selectedIndex - buildableGridObjectTypeSOList.Count - 1];
								currentBuildableObjectType = BuildableObjectType.EdgeObject;
								buildableGridObjectTypeSO = null;
								buildableFreeObjectTypeSO = null;
							}
							else
							{
								buildableFreeObjectTypeSO = buildableFreeObjectTypeSOList[selectedIndex - buildableGridObjectTypeSOList.Count - buildableEdgeObjectTypeSOList.Count - 1];
								currentBuildableObjectType = BuildableObjectType.FreeObject;
								buildableGridObjectTypeSO = null;
								buildableEdgeObjectTypeSO = null;
							}
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
						}
					}
				}
			}
			if (!useBuildModeActivationKey)
			{
				isBuildableBuildActive = false;
			}
		}

		public void TriggerBuildableListUI(string buttonName)
		{
			if (!useBuildModeActivationKey)
			{
				isBuildableBuildActive = true;
			}
			if (isBuildableBuildActive && (GetGridMode() == GridMode.None || GetGridMode() == GridMode.Build))
			{
				if (gridEditorMode == GridEditorMode.GridLite)
				{
					foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
					{
						if (buildableGridObjectTypeSO.objectName == buttonName)
						{
							this.buildableGridObjectTypeSO = buildableGridObjectTypeSO;
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
							break;
						}
					}
				}
				else if (gridEditorMode == GridEditorMode.GridPro)
				{
					foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO2 in buildableGridObjectTypeSOList)
					{
						if (buildableGridObjectTypeSO2.objectName == buttonName)
						{
							this.buildableGridObjectTypeSO = buildableGridObjectTypeSO2;
							currentBuildableObjectType = BuildableObjectType.DefaultObject;
							buildableEdgeObjectTypeSO = null;
							buildableFreeObjectTypeSO = null;
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
							break;
						}
					}
					foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
					{
						if (buildableEdgeObjectTypeSO.objectName == buttonName)
						{
							this.buildableEdgeObjectTypeSO = buildableEdgeObjectTypeSO;
							currentBuildableObjectType = BuildableObjectType.EdgeObject;
							this.buildableGridObjectTypeSO = null;
							buildableFreeObjectTypeSO = null;
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
							break;
						}
					}
					foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
					{
						if (buildableFreeObjectTypeSO.objectName == buttonName)
						{
							this.buildableFreeObjectTypeSO = buildableFreeObjectTypeSO;
							currentBuildableObjectType = BuildableObjectType.FreeObject;
							this.buildableGridObjectTypeSO = null;
							this.buildableEdgeObjectTypeSO = null;
							RefreshselectedIndexType();
							isBuildableDestroyActive = false;
							if (GetGridMode() != GridMode.Build)
							{
								SetGridMode(GridMode.Build);
							}
							if (enableUnityEvents)
							{
								OnSelectedBuildableChangedUnityEvent?.Invoke();
							}
							break;
						}
					}
				}
			}
			if (!useBuildModeActivationKey)
			{
				isBuildableBuildActive = false;
			}
		}

		public void TriggerGhostRotateLeft()
		{
			ghostRotateLeftKeyHolding = true;
			dir = BuildableGridObjectTypeSO.GetNextDirLeft(dir);
			if (edgeRotation == 0f)
			{
				edgeRotation = 180f;
			}
			else
			{
				edgeRotation = 0f;
			}
			this.OnBuildableEdgeObjectFlip?.Invoke(edgeRotation);
		}

		public void TriggerGhostRotateRight()
		{
			ghostRotateRightKeyHolding = true;
			dir = BuildableGridObjectTypeSO.GetNextDirRight(dir);
			if (edgeRotation == 0f)
			{
				edgeRotation = 180f;
			}
			else
			{
				edgeRotation = 0f;
			}
			this.OnBuildableEdgeObjectFlip?.Invoke(edgeRotation);
		}

		public void TriggerGhostRotateLeftCancelled()
		{
			ghostRotateLeftKeyHolding = false;
		}

		public void TriggerGhostRotateRightCancelled()
		{
			ghostRotateRightKeyHolding = false;
		}

		public void SetGridModeDestruction()
		{
			if (useDestructionModeActivationKey)
			{
				if (GetGridMode() != GridMode.Destruct)
				{
					buildableGridObjectTypeSO = null;
					buildableEdgeObjectTypeSO = null;
					buildableFreeObjectTypeSO = null;
					isBuildableDestroyActive = true;
					SetGridMode(GridMode.Destruct);
					RefreshselectedIndexType();
				}
				else
				{
					buildableGridObjectTypeSO = null;
					buildableEdgeObjectTypeSO = null;
					buildableFreeObjectTypeSO = null;
					isBuildableDestroyActive = false;
					SetGridMode(GridMode.None);
					RefreshselectedIndexType();
				}
			}
		}

		public void TriggerBuildableDestroy()
		{
			if (!useDestructionModeActivationKey)
			{
				buildableGridObjectTypeSO = null;
				buildableEdgeObjectTypeSO = null;
				buildableFreeObjectTypeSO = null;
				isBuildableDestroyActive = true;
				if (GetGridMode() != GridMode.Destruct)
				{
					SetGridMode(GridMode.Destruct);
				}
				RefreshselectedIndexType();
			}
			if ((GetGridMode() == GridMode.None || GetGridMode() == GridMode.Destruct) && isBuildableDestroyActive && !IsPointerOverUI())
			{
				if (gridAxis == GridAxis.XZ)
				{
					gridXZ.GetXZ(localMousePosition, out var x, out var z);
					Vector3 placedObjectMouseWorldPosition = GetPlacedObjectMouseWorldPosition();
					gridXZ.GetXZ(placedObjectMouseWorldPosition, out var x2, out var z2);
					BuildableGridObject buildableGridObject = (IsValidGridPositionXZ(new Vector2Int(x, z)) ? gridXZ.GetGridObjectXZ(localMousePosition).GetPlacedObject() : ((!IsValidGridPositionXZ(new Vector2Int(x2, z2))) ? null : gridXZ.GetGridObjectXZ(placedObjectMouseWorldPosition).GetPlacedObject()));
					if (buildableGridObject != null)
					{
						buildableGridObject.DestroySelf();
						if (enableUnityEvents)
						{
							OnObjectRemovedUnityEvent?.Invoke();
						}
						if (showConsoleText && objectDestruction)
						{
							Debug.Log("Grid XZ <color=Red>Object Destroyed :</color> " + buildableGridObject);
						}
						foreach (Vector2Int gridPosition in buildableGridObject.GetGridPositionList())
						{
							gridXZ.GetGridObjectXZ(gridPosition.x, gridPosition.y).ClearPlacedObject();
							if (enableUnityEvents)
							{
								OnGridCellChangedUnityEvent?.Invoke();
							}
						}
					}
				}
				else
				{
					Vector3 mouseWorldPosition = GetMouseWorldPosition();
					gridXY.GetXY(mouseWorldPosition, out var x3, out var y);
					Vector3 placedObjectMouseWorldPosition2 = GetPlacedObjectMouseWorldPosition();
					gridXY.GetXY(placedObjectMouseWorldPosition2, out var x4, out var y2);
					BuildableGridObject buildableGridObject2 = (IsValidGridPositionXY(new Vector2Int(x3, y)) ? gridXY.GetGridObjectXY(mouseWorldPosition).GetPlacedObject() : ((!IsValidGridPositionXY(new Vector2Int(x4, y2))) ? null : gridXY.GetGridObjectXY(placedObjectMouseWorldPosition2).GetPlacedObject()));
					if (buildableGridObject2 != null)
					{
						buildableGridObject2.DestroySelf();
						if (enableUnityEvents)
						{
							OnObjectRemovedUnityEvent?.Invoke();
						}
						if (showConsoleText && objectDestruction)
						{
							Debug.Log("Grid XY <color=Red>Object Destroyed :</color> " + buildableGridObject2);
						}
						foreach (Vector2Int gridPosition2 in buildableGridObject2.GetGridPositionList())
						{
							gridXY.GetGridObjectXY(gridPosition2.x, gridPosition2.y).ClearPlacedObject();
							if (enableUnityEvents)
							{
								OnGridCellChangedUnityEvent?.Invoke();
							}
						}
					}
				}
				DestroyBuildableEdgeObject();
				DestroyBuildableFreeObject();
			}
			if (!useDestructionModeActivationKey)
			{
				isBuildableDestroyActive = false;
				if (GetGridMode() != GridMode.None)
				{
					SetGridMode(GridMode.None);
				}
			}
		}

		private void DestroyBuildableEdgeObject()
		{
			if (gridAxis != GridAxis.XZ)
			{
				return;
			}
			BuildableEdgeObject placedEdgeObjectMouseWorldPosition = GetPlacedEdgeObjectMouseWorldPosition();
			if (!(placedEdgeObjectMouseWorldPosition != null))
			{
				return;
			}
			placedEdgeObjectMouseWorldPosition.DestroySelf();
			if (enableUnityEvents)
			{
				OnObjectRemovedUnityEvent?.Invoke();
			}
			if (showConsoleText && objectDestruction)
			{
				Debug.Log("Grid XZ <color=Red>Object Destroyed :</color> " + placedEdgeObjectMouseWorldPosition);
			}
			List<Vector2Int> gridPositionList = placedEdgeObjectMouseWorldPosition.GetGridPositionList();
			switch (placedEdgeObjectMouseWorldPosition.GetEdgeObjectDir())
			{
			case BuildableEdgeObjectTypeSO.Dir.Down:
			{
				foreach (Vector2Int item in gridPositionList)
				{
					gridXZ.GetGridObjectXZ(item.x, item.y).ClearPlacedDownEdgeObject();
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				break;
			}
			case BuildableEdgeObjectTypeSO.Dir.Left:
			{
				foreach (Vector2Int item2 in gridPositionList)
				{
					gridXZ.GetGridObjectXZ(item2.x, item2.y).ClearPlacedLeftEdgeObject();
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				break;
			}
			case BuildableEdgeObjectTypeSO.Dir.Up:
			{
				foreach (Vector2Int item3 in gridPositionList)
				{
					gridXZ.GetGridObjectXZ(item3.x, item3.y).ClearPlacedUpEdgeObject();
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				break;
			}
			case BuildableEdgeObjectTypeSO.Dir.Right:
			{
				foreach (Vector2Int item4 in gridPositionList)
				{
					gridXZ.GetGridObjectXZ(item4.x, item4.y).ClearPlacedRightEdgeObject();
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				break;
			}
			}
		}

		private void DestroyBuildableFreeObject()
		{
			BuildableFreeObject buildableFreeObject = null;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f, freeObjectCollidingLayerMask) && (bool)hitInfo.collider.gameObject.transform.root.GetComponent<BuildableFreeObject>())
			{
				buildableFreeObject = hitInfo.collider.gameObject.transform.root.GetComponent<BuildableFreeObject>();
			}
			if (!(buildableFreeObject != null))
			{
				return;
			}
			buildableFreeObject.DestroySelf();
			if (enableUnityEvents)
			{
				OnObjectRemovedUnityEvent?.Invoke();
			}
			if (showConsoleText && objectDestruction)
			{
				Debug.Log("Grid XZ <color=Red>Object Destroyed :</color> " + buildableFreeObject);
			}
			foreach (Transform builtBuildableFreeObject in builtBuildableFreeObjectList)
			{
				if (builtBuildableFreeObject == buildableFreeObject.transform)
				{
					builtBuildableFreeObjectList.Remove(builtBuildableFreeObject);
					break;
				}
			}
		}

		public void TriggerGridSave()
		{
			if (enableSaveAndLoad)
			{
				GridSave();
			}
		}

		public void TriggerGridLoad()
		{
			if (enableSaveAndLoad)
			{
				GridLoad();
			}
		}

		private void CallObjectPlacementGridObject(Vector3 mousePosition)
		{
			if (gridAxis == GridAxis.XZ)
			{
				gridXZ.GetXZ(mousePosition, out var x, out var z);
				Vector2Int placedObjectOrigin = new Vector2Int(x, z);
				if (TryPlaceGridObjectXZ(placedObjectOrigin, buildableGridObjectTypeSO, dir, isCallFromLoad: false, out var buildableGridObject))
				{
					if (showConsoleText && objectPlacement)
					{
						Debug.Log("Grid XZ <color=green>Object Placed :</color> " + buildableGridObject);
					}
				}
				else if (IsValidGridPositionXZ(new Vector2Int(x, z)))
				{
					if (showConsoleText && objectPlacement)
					{
						Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Grid Position: " + x + "," + z);
					}
				}
				else if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Out of the Grid");
				}
				return;
			}
			gridXY.GetXY(mousePosition, out var x2, out var y);
			Vector2Int placedObjectOrigin2 = new Vector2Int(x2, y);
			if (TryPlaceGridObjectXY(placedObjectOrigin2, buildableGridObjectTypeSO, dir, isCallFromLoad: false, out var buildableGridObject2))
			{
				if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XY <color=green>Object Placed :</color> " + buildableGridObject2);
				}
			}
			else if (IsValidGridPositionXY(new Vector2Int(x2, y)))
			{
				if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XY <color=orange>Cannot Build Here!</color> Grid Position: " + x2 + "," + y);
				}
			}
			else if (showConsoleText && objectPlacement)
			{
				Debug.Log("Grid XY <color=orange>Cannot Build Here!</color> Out of the Grid");
			}
		}

		private void CallObjectPlacementEdgeObject(Vector3 mousePosition)
		{
			if (gridAxis == GridAxis.XZ)
			{
				gridXZ.GetXZ(mousePosition, out var x, out var z);
				Vector2Int placedObjectOrigin = new Vector2Int(x, z);
				if (TryPlaceEdgeObjectXZ(placedObjectOrigin, buildableEdgeObjectTypeSO, CalcualteEdgeObjectDir(localMousePosition), edgeRotation, localMousePosition, isCallFromLoad: false, out var buildableEdgeObject))
				{
					if (showConsoleText && objectPlacement)
					{
						Debug.Log("Grid XZ <color=green>Object Placed :</color> " + buildableEdgeObject);
					}
				}
				else if (IsValidGridPositionXZ(new Vector2Int(x, z)))
				{
					if (showConsoleText && objectPlacement)
					{
						Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Grid Position: " + x + "," + z);
					}
				}
				else if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Out of the Grid");
				}
				return;
			}
			gridXY.GetXY(mousePosition, out var x2, out var y);
			Vector2Int placedObjectOrigin2 = new Vector2Int(x2, y);
			if (TryPlaceEdgeObjectXY(placedObjectOrigin2, buildableEdgeObjectTypeSO, CalcualteEdgeObjectDir(localMousePosition), edgeRotation, localMousePosition, isCallFromLoad: false, out var buildableEdgeObject2))
			{
				if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XY <color=green>Object Placed :</color> " + buildableEdgeObject2);
				}
			}
			else if (IsValidGridPositionXY(new Vector2Int(x2, y)))
			{
				if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XY <color=orange>Cannot Build Here!</color> Grid Position: " + x2 + "," + y);
				}
			}
			else if (showConsoleText && objectPlacement)
			{
				Debug.Log("Grid XY <color=orange>Cannot Build Here!</color> Out of the Grid");
			}
		}

		private void CallObjectPlacementFreeObject(Vector3 mousePosition)
		{
			if (gridAxis == GridAxis.XZ)
			{
				Vector3 worldPosition = BuildableFreeObjectCollidingMousePosition();
				if (TryPlaceFreeObjectXZ(buildableFreeObjectTypeSO, worldPosition, buildableFreeObjectRotation, isCallFromLoad: false, out var buildableFreeObject))
				{
					if (showConsoleText && objectPlacement)
					{
						Debug.Log("Grid XZ <color=green>Object Placed :</color> " + buildableFreeObject);
					}
				}
				else if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XZ <color=orange>Cannot Build Here!</color> Out of the Grid");
				}
				return;
			}
			Vector3 worldPosition2 = BuildableFreeObjectCollidingMousePosition();
			if (TryPlaceFreeObjectXY(buildableFreeObjectTypeSO, worldPosition2, buildableFreeObjectRotation, isCallFromLoad: false, out var buildableFreeObject2))
			{
				if (showConsoleText && objectPlacement)
				{
					Debug.Log("Grid XY <color=green>Object Placed :</color> " + buildableFreeObject2);
				}
			}
			else if (showConsoleText && objectPlacement)
			{
				Debug.Log("Grid XY <color=orange>Cannot Build Here!</color> Out of the Grid");
			}
		}

		public bool TryPlaceGridObjectXZ(Vector2Int placedObjectOrigin, BuildableGridObjectTypeSO buildableGridObjectTypeSO, BuildableGridObjectTypeSO.Dir dir, bool isCallFromLoad, out BuildableGridObject buildableGridObject)
		{
			return TryPlaceGridObjectXZ(gridXZ, placedObjectOrigin, buildableGridObjectTypeSO, dir, isCallFromLoad, out buildableGridObject);
		}

		public bool TryPlaceGridObjectXZ(GridXZ<GridObjectXZ> passedGridXZ, Vector2Int placedObjectOrigin, BuildableGridObjectTypeSO buildableGridObjectTypeSO, BuildableGridObjectTypeSO.Dir dir, bool isCallFromLoad, out BuildableGridObject buildableGridObject)
		{
			List<Vector2Int> gridPositionList = buildableGridObjectTypeSO.GetGridPositionList(placedObjectOrigin, dir, passedGridXZ.GetCellSize());
			bool flag = true;
			foreach (Vector2Int item in gridPositionList)
			{
				if (!passedGridXZ.IsValidGridPosition(item))
				{
					flag = false;
					break;
				}
				if (!passedGridXZ.GetGridObjectXZ(item.x, item.y).CanBuild())
				{
					flag = false;
					break;
				}
				if (!isCallFromLoad)
				{
					if (buildableGridObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
					{
						flag = false;
						break;
					}
					if (buildableAreaBlockerHit)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Vector2Int rotationOffset = buildableGridObjectTypeSO.GetRotationOffset(dir, passedGridXZ.GetCellSize());
				GetMouseWorldPosition();
				Vector3 vector = passedGridXZ.GetWorldPosition(placedObjectOrigin.x, placedObjectOrigin.y) + new Vector3(rotationOffset.x, base.transform.localPosition.y, rotationOffset.y) * passedGridXZ.GetCellSize();
				Vector3 worldPosition = new Vector3(vector.x, gridOriginXZ.y, vector.z);
				buildableGridObject = BuildableGridObject.Create(worldPosition, placedObjectOrigin, dir, buildableGridObjectTypeSO, this);
				if (!isCallFromLoad && buildableGridObjectTypeSO.enableBuildCondition)
				{
					CompleteBuildConditionBuildableGridObject(buildableGridObjectTypeSO);
				}
				foreach (Vector2Int item2 in gridPositionList)
				{
					passedGridXZ.GetGridObjectXZ(item2.x, item2.y).SetPlacedObject(buildableGridObject);
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				buildableGridObject.GridSetupDone(this, isObjectBuilt: true, currentActiveGridIndex, dir);
				this.OnObjectPlaced?.Invoke(buildableGridObject, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnObjectPlacedUnityEvent?.Invoke();
				}
				return true;
			}
			buildableGridObject = null;
			return false;
		}

		public bool TryPlaceGridObjectXY(Vector2Int placedObjectOrigin, BuildableGridObjectTypeSO buildableGridObjectTypeSO, BuildableGridObjectTypeSO.Dir dir, bool isCallFromLoad, out BuildableGridObject buildableGridObject)
		{
			return TryPlaceGridObjectXY(gridXY, placedObjectOrigin, buildableGridObjectTypeSO, dir, isCallFromLoad, out buildableGridObject);
		}

		public bool TryPlaceGridObjectXY(GridXY<GridObjectXY> passedGridXY, Vector2Int placedObjectOrigin, BuildableGridObjectTypeSO buildableGridObjectTypeSO, BuildableGridObjectTypeSO.Dir dir, bool isCallFromLoad, out BuildableGridObject buildableGridObject)
		{
			List<Vector2Int> gridPositionList = buildableGridObjectTypeSO.GetGridPositionList(placedObjectOrigin, dir, passedGridXY.GetCellSize());
			bool flag = true;
			foreach (Vector2Int item in gridPositionList)
			{
				if (!passedGridXY.IsValidGridPosition(item))
				{
					flag = false;
					break;
				}
				if (!passedGridXY.GetGridObjectXY(item.x, item.y).CanBuild())
				{
					flag = false;
					break;
				}
				if (!isCallFromLoad)
				{
					if (buildableGridObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
					{
						flag = false;
						break;
					}
					if (buildableAreaBlockerHit)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Vector2Int rotationOffset = buildableGridObjectTypeSO.GetRotationOffset(dir, passedGridXY.GetCellSize());
				GetMouseWorldPosition();
				Vector3 vector = passedGridXY.GetWorldPosition(placedObjectOrigin.x, placedObjectOrigin.y) + new Vector3(rotationOffset.x, rotationOffset.y, base.transform.localPosition.z) * passedGridXY.GetCellSize();
				Vector3 worldPosition = new Vector3(vector.x, vector.y, gridOriginXY.z);
				buildableGridObject = BuildableGridObject.Create(worldPosition, placedObjectOrigin, dir, buildableGridObjectTypeSO, this);
				buildableGridObject.transform.rotation = Quaternion.Euler(0f, 0f, -buildableGridObjectTypeSO.GetRotationAngle(dir));
				if (!isCallFromLoad && buildableGridObjectTypeSO.enableBuildCondition)
				{
					CompleteBuildConditionBuildableGridObject(buildableGridObjectTypeSO);
				}
				foreach (Vector2Int item2 in gridPositionList)
				{
					passedGridXY.GetGridObjectXY(item2.x, item2.y).SetPlacedObject(buildableGridObject);
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				buildableGridObject.GridSetupDone(this, isObjectBuilt: true, currentActiveGridIndex, dir);
				this.OnObjectPlaced?.Invoke(buildableGridObject, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnObjectPlacedUnityEvent?.Invoke();
				}
				return true;
			}
			buildableGridObject = null;
			return false;
		}

		public bool TryPlaceEdgeObjectXZ(Vector2Int placedObjectOrigin, BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO, BuildableEdgeObjectTypeSO.Dir dir, float edgeRotation, Vector3 mousePosition, bool isCallFromLoad, out BuildableEdgeObject buildableEdgeObject)
		{
			return TryPlaceEdgeObjectXZ(gridXZ, placedObjectOrigin, buildableEdgeObjectTypeSO, dir, edgeRotation, mousePosition, isCallFromLoad, out buildableEdgeObject);
		}

		public bool TryPlaceEdgeObjectXZ(GridXZ<GridObjectXZ> passedGridXZ, Vector2Int placedObjectOrigin, BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO, BuildableEdgeObjectTypeSO.Dir dir, float edgeRotation, Vector3 mousePosition, bool isCallFromLoad, out BuildableEdgeObject buildableEdgeObject)
		{
			List<Vector2Int> gridPositionList = buildableEdgeObjectTypeSO.GetGridPositionList(placedObjectOrigin, dir, passedGridXZ.GetCellSize());
			bool flag = true;
			foreach (Vector2Int item in gridPositionList)
			{
				if (!passedGridXZ.IsValidGridPosition(item))
				{
					flag = false;
					break;
				}
				switch (dir)
				{
				case BuildableEdgeObjectTypeSO.Dir.Down:
					if (!passedGridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectDown())
					{
						flag = false;
					}
					break;
				case BuildableEdgeObjectTypeSO.Dir.Left:
					if (!passedGridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectLeft())
					{
						flag = false;
					}
					break;
				case BuildableEdgeObjectTypeSO.Dir.Up:
					if (!passedGridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectUp())
					{
						flag = false;
					}
					break;
				case BuildableEdgeObjectTypeSO.Dir.Right:
					if (!passedGridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectRight())
					{
						flag = false;
					}
					break;
				}
				if (!isCallFromLoad)
				{
					if (buildableEdgeObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableEdgeObject(buildableEdgeObjectTypeSO))
					{
						flag = false;
						break;
					}
					if (buildableAreaBlockerHit)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Vector2Int rotationOffset = buildableEdgeObjectTypeSO.GetRotationOffset(CalcualteEdgeObjectDir(mousePosition), passedGridXZ.GetCellSize());
				Vector3 vector = passedGridXZ.GetWorldPosition(placedObjectOrigin.x, placedObjectOrigin.y) + new Vector3(rotationOffset.x, base.transform.localPosition.y, rotationOffset.y) * passedGridXZ.GetCellSize();
				Vector3 worldPosition = new Vector3(vector.x, gridOriginXZ.y, vector.z);
				buildableEdgeObject = BuildableEdgeObject.Create(worldPosition, placedObjectOrigin, CalcualteEdgeObjectDir(mousePosition), mousePosition, buildableEdgeObjectTypeSO, this, edgeRotation);
				if (!isCallFromLoad && buildableEdgeObjectTypeSO.enableBuildCondition)
				{
					CompleteBuildConditionBuildableEdgeObject(buildableEdgeObjectTypeSO);
				}
				foreach (Vector2Int item2 in gridPositionList)
				{
					switch (CalcualteEdgeObjectDir(mousePosition))
					{
					case BuildableEdgeObjectTypeSO.Dir.Down:
						passedGridXZ.GetGridObjectXZ(item2.x, item2.y).SetPlacedDownEdgeObject(buildableEdgeObject);
						break;
					case BuildableEdgeObjectTypeSO.Dir.Left:
						passedGridXZ.GetGridObjectXZ(item2.x, item2.y).SetPlacedLeftEdgeObject(buildableEdgeObject);
						break;
					case BuildableEdgeObjectTypeSO.Dir.Up:
						passedGridXZ.GetGridObjectXZ(item2.x, item2.y).SetPlacedUpEdgeObject(buildableEdgeObject);
						break;
					case BuildableEdgeObjectTypeSO.Dir.Right:
						passedGridXZ.GetGridObjectXZ(item2.x, item2.y).SetPlacedRightEdgeObject(buildableEdgeObject);
						break;
					}
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				buildableEdgeObject.GridSetupDone(this, isObjectBuilt: true, currentActiveGridIndex, dir);
				this.OnObjectPlaced?.Invoke(buildableEdgeObject, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnObjectPlacedUnityEvent?.Invoke();
				}
				return true;
			}
			buildableEdgeObject = null;
			return false;
		}

		public bool TryPlaceEdgeObjectXY(Vector2Int placedObjectOrigin, BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO, BuildableEdgeObjectTypeSO.Dir dir, float edgeRotation, Vector3 mousePosition, bool isCallFromLoad, out BuildableEdgeObject buildableEdgeObject)
		{
			return TryPlaceEdgeObjectXY(gridXY, placedObjectOrigin, buildableEdgeObjectTypeSO, dir, edgeRotation, mousePosition, isCallFromLoad, out buildableEdgeObject);
		}

		public bool TryPlaceEdgeObjectXY(GridXY<GridObjectXY> passedGridXY, Vector2Int placedObjectOrigin, BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO, BuildableEdgeObjectTypeSO.Dir dir, float edgeRotation, Vector3 mousePosition, bool isCallFromLoad, out BuildableEdgeObject buildableEdgeObject)
		{
			List<Vector2Int> gridPositionList = buildableEdgeObjectTypeSO.GetGridPositionList(placedObjectOrigin, dir, passedGridXY.GetCellSize());
			bool flag = true;
			foreach (Vector2Int item in gridPositionList)
			{
				if (!passedGridXY.IsValidGridPosition(item))
				{
					flag = false;
					break;
				}
				if (!passedGridXY.GetGridObjectXY(item.x, item.y).CanBuild())
				{
					flag = false;
					break;
				}
				if (!isCallFromLoad)
				{
					if (buildableGridObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
					{
						flag = false;
						break;
					}
					if (buildableAreaBlockerHit)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Vector2Int rotationOffset = buildableEdgeObjectTypeSO.GetRotationOffset(dir, passedGridXY.GetCellSize());
				Vector3 vector = passedGridXY.GetWorldPosition(placedObjectOrigin.x, placedObjectOrigin.y) + new Vector3(rotationOffset.x, rotationOffset.y, base.transform.localPosition.z) * passedGridXY.GetCellSize();
				Vector3 worldPosition = new Vector3(vector.x, vector.y, gridOriginXY.z);
				buildableEdgeObject = BuildableEdgeObject.Create(worldPosition, placedObjectOrigin, dir, mousePosition, buildableEdgeObjectTypeSO, this, edgeRotation);
				buildableEdgeObject.transform.rotation = Quaternion.Euler(0f, 0f, -buildableEdgeObjectTypeSO.GetRotationAngle(dir));
				if (!isCallFromLoad && buildableEdgeObjectTypeSO.enableBuildCondition)
				{
					CompleteBuildConditionBuildableEdgeObject(buildableEdgeObjectTypeSO);
				}
				foreach (Vector2Int item2 in gridPositionList)
				{
					passedGridXY.GetGridObjectXY(item2.x, item2.y).SetPlacedDownEdgeObject(buildableEdgeObject);
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
				buildableEdgeObject.GridSetupDone(this, isObjectBuilt: true, currentActiveGridIndex, dir);
				this.OnObjectPlaced?.Invoke(buildableEdgeObject, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnObjectPlacedUnityEvent?.Invoke();
				}
				return true;
			}
			buildableEdgeObject = null;
			return false;
		}

		public bool TryPlaceFreeObjectXZ(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO, Vector3 worldPosition, float rotation, bool isCallFromLoad, out BuildableFreeObject buildableFreeObject)
		{
			bool flag = true;
			if (!isCallFromLoad)
			{
				if (buildableFreeObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableFreeObject(buildableFreeObjectTypeSO))
				{
					flag = false;
				}
				if (buildableAreaBlockerHit)
				{
					flag = false;
				}
			}
			if (flag)
			{
				BuildableFreeObjectCollidingMousePosition();
				buildableFreeObject = BuildableFreeObject.Create(worldPosition, rotation, buildableFreeObjectTypeSO, this);
				builtBuildableFreeObjectList.Add(buildableFreeObject.transform);
				if (!isCallFromLoad && buildableFreeObjectTypeSO.enableBuildCondition)
				{
					CompleteBuildConditionBuildableFreeObject(buildableFreeObjectTypeSO);
				}
				buildableFreeObject.GridSetupDone(this, isObjectBuilt: true, rotation);
				this.OnObjectPlaced?.Invoke(buildableFreeObject, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnObjectPlacedUnityEvent?.Invoke();
				}
				return true;
			}
			buildableFreeObject = null;
			return false;
		}

		public bool TryPlaceFreeObjectXY(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO, Vector3 worldPosition, float rotation, bool isCallFromLoad, out BuildableFreeObject buildableFreeObject)
		{
			bool flag = true;
			if (!isCallFromLoad)
			{
				if (buildableFreeObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableFreeObject(buildableFreeObjectTypeSO))
				{
					flag = false;
				}
				if (buildableAreaBlockerHit)
				{
					flag = false;
				}
			}
			if (flag)
			{
				buildableFreeObject = BuildableFreeObject.Create(worldPosition, rotation, buildableFreeObjectTypeSO, this);
				builtBuildableFreeObjectList.Add(buildableFreeObject.transform);
				if (!isCallFromLoad && buildableFreeObjectTypeSO.enableBuildCondition)
				{
					CompleteBuildConditionBuildableFreeObject(buildableFreeObjectTypeSO);
				}
				buildableFreeObject.GridSetupDone(this, isObjectBuilt: true, rotation);
				this.OnObjectPlaced?.Invoke(buildableFreeObject, EventArgs.Empty);
				if (enableUnityEvents)
				{
					OnObjectPlacedUnityEvent?.Invoke();
				}
				return true;
			}
			buildableFreeObject = null;
			return false;
		}

		public BuildableEdgeObjectTypeSO.Dir CalcualteEdgeObjectDir(Vector3 mousePosition)
		{
			if (gridAxis == GridAxis.XZ)
			{
				gridXZ.GetXZ(mousePosition, out var x, out var z);
				Vector3 worldPosition = gridXZ.GetWorldPosition(x, z);
				new Vector3(worldPosition.x + cellSize / 2f, worldPosition.y, worldPosition.z + cellSize / 2f);
				Vector3 b = new Vector3(worldPosition.x + cellSize / 2f, worldPosition.y, worldPosition.z + cellSize);
				Vector3 b2 = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z + cellSize / 2f);
				Vector3 b3 = new Vector3(worldPosition.x + cellSize / 2f, worldPosition.y, worldPosition.z);
				Vector3 b4 = new Vector3(worldPosition.x + cellSize, worldPosition.y, worldPosition.z + cellSize / 2f);
				BuildableEdgeObjectTypeSO.Dir result = BuildableEdgeObjectTypeSO.Dir.Down;
				float num = Vector3.Distance(mousePosition, b);
				float num2 = Vector3.Distance(mousePosition, b2);
				float num3 = Vector3.Distance(mousePosition, b3);
				float num4 = Vector3.Distance(mousePosition, b4);
				float num5 = Mathf.Min(num, Mathf.Min(num2, Mathf.Min(num3, num4)));
				if (num == num5)
				{
					result = BuildableEdgeObjectTypeSO.Dir.Down;
				}
				else if (num2 == num5)
				{
					result = BuildableEdgeObjectTypeSO.Dir.Left;
				}
				else if (num3 == num5)
				{
					result = BuildableEdgeObjectTypeSO.Dir.Up;
				}
				else if (num4 == num5)
				{
					result = BuildableEdgeObjectTypeSO.Dir.Right;
				}
				edgeDir = result;
				return result;
			}
			gridXY.GetXY(mousePosition, out var x2, out var y);
			if (buildableGridObjectTypeSO != null)
			{
				Vector2Int rotationOffset = buildableGridObjectTypeSO.GetRotationOffset(dir, cellSize);
				_ = gridXY.GetWorldPosition(x2, y) + new Vector3(rotationOffset.x, rotationOffset.y, mousePosition.z / gridXY.GetCellSize()) * gridXY.GetCellSize();
				return BuildableEdgeObjectTypeSO.Dir.Down;
			}
			return BuildableEdgeObjectTypeSO.Dir.Down;
		}

		private void DeselectObjectType()
		{
			selectedIndex = 1;
			buildableGridObjectTypeSO = null;
			buildableEdgeObjectTypeSO = null;
			buildableFreeObjectTypeSO = null;
			isBuildableDestroyActive = false;
			isBuildableBuildActive = false;
			if (GetGridMode() != GridMode.None)
			{
				SetGridMode(GridMode.None);
			}
			RefreshselectedIndexType();
		}

		private void RefreshselectedIndexType()
		{
			this.OnSelectedBuildableChanged?.Invoke(this, EventArgs.Empty);
		}

		public Vector2Int GetGridPositionXZ(Vector3 worldPosition)
		{
			gridXZ.GetXZ(worldPosition, out var x, out var z);
			return new Vector2Int(x, z);
		}

		public Vector2Int GetGridPositionXY(Vector3 worldPosition)
		{
			gridXY.GetXY(worldPosition, out var x, out var y);
			return new Vector2Int(x, y);
		}

		public Vector3 GetWorldPositionXZ(Vector2Int gridPosition)
		{
			return gridXZ.GetWorldPosition(gridPosition.x, gridPosition.y);
		}

		public Vector3 GetWorldPositionXY(Vector2Int gridPosition)
		{
			return gridXY.GetWorldPosition(gridPosition.x, gridPosition.y);
		}

		public GridObjectXZ GetGridObjectXZ(Vector2Int gridPosition)
		{
			return gridXZ.GetGridObjectXZ(gridPosition.x, gridPosition.y);
		}

		public GridObjectXY GetGridObjectXY(Vector2Int gridPosition)
		{
			return gridXY.GetGridObjectXY(gridPosition.x, gridPosition.y);
		}

		public GridObjectXZ GetGridObjectXZ(Vector3 worldPosition)
		{
			return gridXZ.GetGridObjectXZ(worldPosition);
		}

		public GridObjectXY GetGridObjectXY(Vector3 worldPosition)
		{
			return gridXY.GetGridObjectXY(worldPosition);
		}

		public bool IsValidGridPositionXZ(Vector2Int gridPosition)
		{
			return gridXZ.IsValidGridPosition(gridPosition);
		}

		public bool IsValidGridPositionXY(Vector2Int gridPosition)
		{
			return gridXY.IsValidGridPosition(gridPosition);
		}

		public Vector3 GetMouseWorldSnappedPosition()
		{
			if (gridAxis == GridAxis.XZ)
			{
				Vector3 mouseWorldPosition = GetMouseWorldPosition();
				gridXZ.GetXZ(mouseWorldPosition, out var x, out var z);
				if (buildableGridObjectTypeSO != null)
				{
					Vector2Int rotationOffset = buildableGridObjectTypeSO.GetRotationOffset(dir, cellSize);
					return gridXZ.GetWorldPosition(x, z) + new Vector3(rotationOffset.x, mouseWorldPosition.y / gridXZ.GetCellSize(), rotationOffset.y) * gridXZ.GetCellSize();
				}
				return mouseWorldPosition;
			}
			Vector3 mouseWorldPosition2 = GetMouseWorldPosition();
			gridXY.GetXY(mouseWorldPosition2, out var x2, out var y);
			if (buildableGridObjectTypeSO != null)
			{
				Vector2Int rotationOffset2 = buildableGridObjectTypeSO.GetRotationOffset(dir, cellSize);
				return gridXY.GetWorldPosition(x2, y) + new Vector3(rotationOffset2.x, rotationOffset2.y, mouseWorldPosition2.z / gridXY.GetCellSize()) * gridXY.GetCellSize();
			}
			return mouseWorldPosition2;
		}

		public Vector3 GetMouseWorldSnappedPositionForEdgeObjects()
		{
			if (gridAxis == GridAxis.XZ)
			{
				Vector3 mouseWorldPosition = GetMouseWorldPosition();
				gridXZ.GetXZ(mouseWorldPosition, out var x, out var z);
				Vector3 worldPosition = gridXZ.GetWorldPosition(x, z);
				new Vector3(worldPosition.x + cellSize / 2f, worldPosition.y, worldPosition.z + cellSize / 2f);
				Vector3 vector = new Vector3(worldPosition.x + cellSize / 2f, worldPosition.y, worldPosition.z + cellSize);
				Vector3 vector2 = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z + cellSize / 2f);
				Vector3 vector3 = new Vector3(worldPosition.x + cellSize / 2f, worldPosition.y, worldPosition.z);
				Vector3 vector4 = new Vector3(worldPosition.x + cellSize, worldPosition.y, worldPosition.z + cellSize / 2f);
				Vector3 result = mouseWorldPosition;
				float num = Vector3.Distance(mouseWorldPosition, vector);
				float num2 = Vector3.Distance(mouseWorldPosition, vector2);
				float num3 = Vector3.Distance(mouseWorldPosition, vector3);
				float num4 = Vector3.Distance(mouseWorldPosition, vector4);
				float num5 = Mathf.Min(num, Mathf.Min(num2, Mathf.Min(num3, num4)));
				if (num == num5)
				{
					result = vector;
				}
				else if (num2 == num5)
				{
					result = vector2;
				}
				else if (num3 == num5)
				{
					result = vector3;
				}
				else if (num4 == num5)
				{
					result = vector4;
				}
				if (buildableEdgeObjectTypeSO != null)
				{
					return result;
				}
				return mouseWorldPosition;
			}
			Vector3 mouseWorldPosition2 = GetMouseWorldPosition();
			gridXY.GetXY(mouseWorldPosition2, out var x2, out var y);
			if (buildableGridObjectTypeSO != null)
			{
				Vector2Int rotationOffset = buildableGridObjectTypeSO.GetRotationOffset(dir, cellSize);
				return gridXY.GetWorldPosition(x2, y) + new Vector3(rotationOffset.x, rotationOffset.y, mouseWorldPosition2.z / gridXY.GetCellSize()) * gridXY.GetCellSize();
			}
			return mouseWorldPosition2;
		}

		public Vector3 GetMouseWorldSnappedPositionForMoving(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			if (gridAxis == GridAxis.XZ)
			{
				Vector3 mouseWorldPosition = GetMouseWorldPosition();
				gridXZ.GetXZ(mouseWorldPosition, out var x, out var z);
				if (buildableGridObjectTypeSO != null)
				{
					Vector2Int rotationOffset = buildableGridObjectTypeSO.GetRotationOffset(dir, cellSize);
					return gridXZ.GetWorldPosition(x, z) + new Vector3(rotationOffset.x, mouseWorldPosition.y / gridXZ.GetCellSize(), rotationOffset.y) * gridXZ.GetCellSize();
				}
				return mouseWorldPosition;
			}
			Vector3 mouseWorldPosition2 = GetMouseWorldPosition();
			gridXY.GetXY(mouseWorldPosition2, out var x2, out var y);
			if (buildableGridObjectTypeSO != null)
			{
				Vector2Int rotationOffset2 = buildableGridObjectTypeSO.GetRotationOffset(dir, cellSize);
				return gridXY.GetWorldPosition(x2, y) + new Vector3(rotationOffset2.x, rotationOffset2.y, mouseWorldPosition2.z / gridXY.GetCellSize()) * gridXY.GetCellSize();
			}
			return mouseWorldPosition2;
		}

		public Quaternion GetPlacedObjectRotation()
		{
			if (gridAxis == GridAxis.XZ)
			{
				if (buildableGridObjectTypeSO != null)
				{
					return Quaternion.Euler(0f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
				}
				return Quaternion.identity;
			}
			if (buildableGridObjectTypeSO != null)
			{
				return Quaternion.Euler(0f, 0f, -buildableGridObjectTypeSO.GetRotationAngle(dir));
			}
			return Quaternion.identity;
		}

		public Quaternion GetPlacedEdgeObjectRotation()
		{
			if (gridAxis == GridAxis.XZ)
			{
				if (buildableEdgeObjectTypeSO != null)
				{
					return Quaternion.Euler(0f, buildableEdgeObjectTypeSO.GetRotationAngle(CalcualteEdgeObjectDir(localMousePosition)), 0f);
				}
				return Quaternion.identity;
			}
			if (buildableEdgeObjectTypeSO != null)
			{
				return Quaternion.Euler(0f, 0f, -buildableEdgeObjectTypeSO.GetRotationAngle(CalcualteEdgeObjectDir(localMousePosition)));
			}
			return Quaternion.identity;
		}

		public Quaternion GetPlacedObjectRotationForMoving(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			if (gridAxis == GridAxis.XZ)
			{
				if (buildableGridObjectTypeSO != null)
				{
					return Quaternion.Euler(0f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
				}
				return Quaternion.identity;
			}
			if (buildableGridObjectTypeSO != null)
			{
				return Quaternion.Euler(0f, 0f, -buildableGridObjectTypeSO.GetRotationAngle(dir));
			}
			return Quaternion.identity;
		}

		public BuildableEdgeObjectTypeSO.Dir GetEdgeObjectDir()
		{
			return edgeDir;
		}

		public float GetEdgeObjectRotation()
		{
			return edgeRotation;
		}

		public BuildableGridObjectTypeSO GetBuildableGridObjectTypeSO()
		{
			return buildableGridObjectTypeSO;
		}

		public BuildableEdgeObjectTypeSO GetBuildableEdgeObjectTypeSO()
		{
			return buildableEdgeObjectTypeSO;
		}

		public BuildableFreeObjectTypeSO GetBuildableFreeObjectTypeSO()
		{
			return buildableFreeObjectTypeSO;
		}

		public Vector3 GetBuildableFreeObjectMouseWorldPosition()
		{
			return BuildableFreeObjectCollidingMousePosition();
		}

		public float GetBuildableFreeObjectRotation()
		{
			return buildableFreeObjectRotation;
		}

		public Vector3 GetLocalMousePosition()
		{
			return localMousePosition;
		}

		public void SetSelectedBuildableGridObjectType(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			this.buildableGridObjectTypeSO = buildableGridObjectTypeSO;
			isBuildableDestroyActive = false;
			RefreshselectedIndexType();
		}

		public Vector3 GetWorldPositionForDebugXZ(int x, int z)
		{
			Vector3 vector = ((!lockDebugGridOnHeightChange) ? gridOriginXZ : gridOriginXZList[0]);
			return new Vector3(x, 0f, z) * cellSize + vector;
		}

		public Vector3 GetWorldPositionForDebugXY(int x, int y)
		{
			Vector3 vector = ((!lockDebugGridOnHeightChange) ? gridOriginXY : gridOriginXYList[0]);
			return new Vector3(x, y, 0f) * cellSize + vector;
		}

		public bool NotPlaceableVisualCallerBuildableGridObject()
		{
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			bool flag = false;
			if (gridAxis == GridAxis.XZ)
			{
				gridXZ.GetXZ(mouseWorldPosition, out var x, out var z);
				Vector2Int offset = new Vector2Int(x, z);
				List<Vector2Int> gridPositionList = buildableGridObjectTypeSO.GetGridPositionList(offset, dir, cellSize);
				flag = true;
				foreach (Vector2Int item in gridPositionList)
				{
					if (!gridXZ.IsValidGridPosition(item))
					{
						flag = false;
						break;
					}
					if (!gridXZ.GetGridObjectXZ(item.x, item.y).CanBuild())
					{
						flag = false;
						break;
					}
					if (buildableGridObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
					{
						flag = false;
						break;
					}
				}
				Camera.main.ScreenPointToRay(Input.mousePosition);
				if (useBuildableDistance)
				{
					if (!distanceCheckObject)
					{
						distanceCheckObject = Camera.main.transform;
					}
					if (!(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) > distanceMin) || !(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) < distanceMax))
					{
						flag = false;
					}
				}
				if (buildableAreaBlockerHit)
				{
					flag = false;
				}
				return flag;
			}
			gridXY.GetXY(mouseWorldPosition, out var x2, out var y);
			Vector2Int offset2 = new Vector2Int(x2, y);
			List<Vector2Int> gridPositionList2 = buildableGridObjectTypeSO.GetGridPositionList(offset2, dir, cellSize);
			flag = true;
			foreach (Vector2Int item2 in gridPositionList2)
			{
				if (!gridXY.IsValidGridPosition(item2))
				{
					flag = false;
					break;
				}
				if (!gridXY.GetGridObjectXY(item2.x, item2.y).CanBuild())
				{
					flag = false;
					break;
				}
				if (buildableGridObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
				{
					flag = false;
					break;
				}
			}
			Camera.main.ScreenPointToRay(Input.mousePosition);
			if (useBuildableDistance)
			{
				if (!distanceCheckObject)
				{
					distanceCheckObject = Camera.main.transform;
				}
				if (!(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) > distanceMin) || !(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) < distanceMax))
				{
					flag = false;
				}
			}
			if (buildableAreaBlockerHit)
			{
				flag = false;
			}
			return flag;
		}

		public bool NotPlaceableVisualCallerBuildableEdgeObject()
		{
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			bool flag = false;
			if (gridAxis == GridAxis.XZ)
			{
				gridXZ.GetXZ(mouseWorldPosition, out var x, out var z);
				Vector2Int offset = new Vector2Int(x, z);
				List<Vector2Int> gridPositionList = buildableEdgeObjectTypeSO.GetGridPositionList(offset, edgeDir, cellSize);
				flag = true;
				foreach (Vector2Int item in gridPositionList)
				{
					if (!gridXZ.IsValidGridPosition(item))
					{
						flag = false;
						break;
					}
					switch (edgeDir)
					{
					case BuildableEdgeObjectTypeSO.Dir.Down:
						if (!gridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectDown())
						{
							flag = false;
						}
						break;
					case BuildableEdgeObjectTypeSO.Dir.Left:
						if (!gridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectLeft())
						{
							flag = false;
						}
						break;
					case BuildableEdgeObjectTypeSO.Dir.Up:
						if (!gridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectUp())
						{
							flag = false;
						}
						break;
					case BuildableEdgeObjectTypeSO.Dir.Right:
						if (!gridXZ.GetGridObjectXZ(item.x, item.y).CanBuildEdgeObjectRight())
						{
							flag = false;
						}
						break;
					}
					if (buildableEdgeObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
					{
						flag = false;
						break;
					}
				}
				Camera.main.ScreenPointToRay(Input.mousePosition);
				if (useBuildableDistance)
				{
					if (!distanceCheckObject)
					{
						distanceCheckObject = Camera.main.transform;
					}
					if (!(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) > distanceMin) || !(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) < distanceMax))
					{
						flag = false;
					}
				}
				if (buildableAreaBlockerHit)
				{
					flag = false;
				}
				return flag;
			}
			gridXY.GetXY(mouseWorldPosition, out var x2, out var y);
			Vector2Int offset2 = new Vector2Int(x2, y);
			List<Vector2Int> gridPositionList2 = buildableGridObjectTypeSO.GetGridPositionList(offset2, dir, cellSize);
			flag = true;
			foreach (Vector2Int item2 in gridPositionList2)
			{
				if (!gridXY.IsValidGridPosition(item2))
				{
					flag = false;
					break;
				}
				if (!gridXY.GetGridObjectXY(item2.x, item2.y).CanBuild())
				{
					flag = false;
					break;
				}
				if (buildableGridObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableGridObject(buildableGridObjectTypeSO))
				{
					flag = false;
					break;
				}
			}
			Camera.main.ScreenPointToRay(Input.mousePosition);
			if (useBuildableDistance)
			{
				if (!distanceCheckObject)
				{
					distanceCheckObject = Camera.main.transform;
				}
				if (!(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) > distanceMin) || !(Vector3.Distance(distanceCheckObject.position, mouseWorldPosition) < distanceMax))
				{
					flag = false;
				}
			}
			if (buildableAreaBlockerHit)
			{
				flag = false;
			}
			return flag;
		}

		public bool NotPlaceableVisualCallerBuildableFreeObject()
		{
			Vector3 b = BuildableFreeObjectCollidingMousePosition();
			bool result = false;
			if (currentBuildableObjectType != BuildableObjectType.FreeObject)
			{
				return result;
			}
			if (gridAxis == GridAxis.XZ)
			{
				result = true;
				if (buildableFreeObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableFreeObject(buildableFreeObjectTypeSO))
				{
					result = false;
				}
				Camera.main.ScreenPointToRay(Input.mousePosition);
				if (useBuildableDistance)
				{
					if (!distanceCheckObject)
					{
						distanceCheckObject = Camera.main.transform;
					}
					if (!(Vector3.Distance(distanceCheckObject.position, b) > distanceMin) || !(Vector3.Distance(distanceCheckObject.position, b) < distanceMax))
					{
						result = false;
					}
				}
				if (buildableAreaBlockerHit)
				{
					result = false;
				}
				return result;
			}
			result = true;
			if (buildableFreeObjectTypeSO.enableBuildCondition && !GetBuildConditionBuildableFreeObject(buildableFreeObjectTypeSO))
			{
				result = false;
			}
			Camera.main.ScreenPointToRay(Input.mousePosition);
			if (useBuildableDistance)
			{
				if (!distanceCheckObject)
				{
					distanceCheckObject = Camera.main.transform;
				}
				if (!(Vector3.Distance(distanceCheckObject.position, b) > distanceMin) || !(Vector3.Distance(distanceCheckObject.position, b) < distanceMax))
				{
					result = false;
				}
			}
			if (buildableAreaBlockerHit)
			{
				result = false;
			}
			return result;
		}

		public bool GetBuildConditionBuildableGridObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			this.OnBuildConditionCheckCallerBuildableGridObject?.Invoke(buildableGridObjectTypeSO);
			if (MultiGridBuildConditionManager.BuidConditionResponseBuildableGridObject)
			{
				return true;
			}
			if (showConsoleText && objectPlacement)
			{
				Debug.Log("<color=orange>Cannot Build!</color> Build conditions are not met!");
			}
			return false;
		}

		public void CompleteBuildConditionBuildableGridObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			this.OnBuildConditionCompleteCallerBuildableGridObject?.Invoke(buildableGridObjectTypeSO);
		}

		public bool GetBuildConditionBuildableEdgeObject(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO)
		{
			this.OnBuildConditionCheckCallerBuildableEdgeObject?.Invoke(buildableEdgeObjectTypeSO);
			if (MultiGridBuildConditionManager.BuidConditionResponseBuildableEdgeObject)
			{
				return true;
			}
			if (showConsoleText && objectPlacement)
			{
				Debug.Log("<color=orange>Cannot Build!</color> Build conditions are not met!");
			}
			return false;
		}

		public void CompleteBuildConditionBuildableEdgeObject(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO)
		{
			this.OnBuildConditionCompleteCallerBuildableEdgeObject?.Invoke(buildableEdgeObjectTypeSO);
		}

		public bool GetBuildConditionBuildableFreeObject(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			this.OnBuildConditionCheckCallerBuildableFreeObject?.Invoke(buildableFreeObjectTypeSO);
			if (MultiGridBuildConditionManager.BuidConditionResponseBuildableFreeObject)
			{
				return true;
			}
			if (showConsoleText && objectPlacement)
			{
				Debug.Log("<color=orange>Cannot Build!</color> Build conditions are not met!");
			}
			return false;
		}

		public void CompleteBuildConditionBuildableFreeObject(BuildableFreeObjectTypeSO buildableFreebjectTypeSO)
		{
			this.OnBuildConditionCompleteCallerBuildableFreeObject?.Invoke(buildableFreebjectTypeSO);
		}

		private void GridSave()
		{
			if (gridAxis == GridAxis.XZ)
			{
				List<PlacedObjectSaveObjectArray> list = new List<PlacedObjectSaveObjectArray>();
				foreach (GridXZ<GridObjectXZ> gridXZ in gridXZList)
				{
					List<BuildableGridObject.SaveObject> list2 = new List<BuildableGridObject.SaveObject>();
					List<BuildableGridObject> list3 = new List<BuildableGridObject>();
					for (int i = 0; i < gridXZ.GetWidth(); i++)
					{
						for (int j = 0; j < gridXZ.GetLength(); j++)
						{
							BuildableGridObject placedObject = gridXZ.GetGridObjectXZ(i, j).GetPlacedObject();
							if (placedObject != null && !list3.Contains(placedObject))
							{
								list3.Add(placedObject);
								list2.Add(placedObject.GetSaveObject());
							}
						}
					}
					PlacedObjectSaveObjectArray item = new PlacedObjectSaveObjectArray
					{
						placedObjectSaveObjectArray = list2.ToArray()
					};
					list.Add(item);
				}
				List<PlacedEdgeObjectSaveObjectArray> list4 = new List<PlacedEdgeObjectSaveObjectArray>();
				foreach (GridXZ<GridObjectXZ> gridXZ2 in gridXZList)
				{
					List<BuildableEdgeObject.SaveObject> list5 = new List<BuildableEdgeObject.SaveObject>();
					List<BuildableEdgeObject> list6 = new List<BuildableEdgeObject>();
					for (int k = 0; k < gridXZ2.GetWidth(); k++)
					{
						for (int l = 0; l < gridXZ2.GetLength(); l++)
						{
							if (gridXZ2.GetGridObjectXZ(k, l).GetPlacedDownEdgeObject() != null)
							{
								BuildableEdgeObject placedDownEdgeObject = gridXZ2.GetGridObjectXZ(k, l).GetPlacedDownEdgeObject();
								if (placedDownEdgeObject != null && !list6.Contains(placedDownEdgeObject))
								{
									list6.Add(placedDownEdgeObject);
									list5.Add(placedDownEdgeObject.GetSaveObject());
								}
							}
							if (gridXZ2.GetGridObjectXZ(k, l).GetPlacedLeftEdgeObject() != null)
							{
								BuildableEdgeObject placedLeftEdgeObject = gridXZ2.GetGridObjectXZ(k, l).GetPlacedLeftEdgeObject();
								if (placedLeftEdgeObject != null && !list6.Contains(placedLeftEdgeObject))
								{
									list6.Add(placedLeftEdgeObject);
									list5.Add(placedLeftEdgeObject.GetSaveObject());
								}
							}
							if (gridXZ2.GetGridObjectXZ(k, l).GetPlacedUpEdgeObject() != null)
							{
								BuildableEdgeObject placedUpEdgeObject = gridXZ2.GetGridObjectXZ(k, l).GetPlacedUpEdgeObject();
								if (placedUpEdgeObject != null && !list6.Contains(placedUpEdgeObject))
								{
									list6.Add(placedUpEdgeObject);
									list5.Add(placedUpEdgeObject.GetSaveObject());
								}
							}
							if (gridXZ2.GetGridObjectXZ(k, l).GetPlacedRightEdgeObject() != null)
							{
								BuildableEdgeObject placedRightEdgeObject = gridXZ2.GetGridObjectXZ(k, l).GetPlacedRightEdgeObject();
								if (placedRightEdgeObject != null && !list6.Contains(placedRightEdgeObject))
								{
									list6.Add(placedRightEdgeObject);
									list5.Add(placedRightEdgeObject.GetSaveObject());
								}
							}
						}
					}
					PlacedEdgeObjectSaveObjectArray item2 = new PlacedEdgeObjectSaveObjectArray
					{
						placedEdgeObjectSaveObjectArray = list5.ToArray()
					};
					list4.Add(item2);
				}
				List<LooseSaveObject> list7 = new List<LooseSaveObject>();
				foreach (Transform builtBuildableFreeObject in builtBuildableFreeObjectList)
				{
					if (!(builtBuildableFreeObject == null))
					{
						list7.Add(new LooseSaveObject
						{
							looseObjectSOName = builtBuildableFreeObject.GetComponent<BuildableFreeObject>().GetBuildableFreeObjectTypeSO().name,
							position = builtBuildableFreeObject.position,
							quaternion = builtBuildableFreeObject.rotation.y
						});
					}
				}
				string text = JsonUtility.ToJson(new SaveObject
				{
					placedObjectSaveObjectArrayArray = list.ToArray(),
					placedEdgeObjectSaveObjectArrayArray = list4.ToArray(),
					looseSaveObjectArray = list7.ToArray()
				});
				PlayerPrefs.SetString(uniqueSaveName + "_XZ", text);
				GridSaveSystem.Save(uniqueSaveName + "_XZ", text, overwrite: true);
				if (showConsoleText && saveAndLoad)
				{
					Debug.Log("Grid XZ <color=green>Grid Data Saved!</color>");
				}
				return;
			}
			List<PlacedObjectSaveObjectArray> list8 = new List<PlacedObjectSaveObjectArray>();
			foreach (GridXY<GridObjectXY> gridXY in gridXYList)
			{
				List<BuildableGridObject.SaveObject> list9 = new List<BuildableGridObject.SaveObject>();
				List<BuildableGridObject> list10 = new List<BuildableGridObject>();
				for (int m = 0; m < gridXY.GetWidth(); m++)
				{
					for (int n = 0; n < gridXY.GetLength(); n++)
					{
						BuildableGridObject placedObject2 = gridXY.GetGridObjectXY(m, n).GetPlacedObject();
						if (placedObject2 != null && !list10.Contains(placedObject2))
						{
							list10.Add(placedObject2);
							list9.Add(placedObject2.GetSaveObject());
						}
					}
				}
				PlacedObjectSaveObjectArray item3 = new PlacedObjectSaveObjectArray
				{
					placedObjectSaveObjectArray = list9.ToArray()
				};
				list8.Add(item3);
			}
			List<LooseSaveObject> list11 = new List<LooseSaveObject>();
			foreach (Transform builtBuildableFreeObject2 in builtBuildableFreeObjectList)
			{
				if (!(builtBuildableFreeObject2 == null))
				{
					list11.Add(new LooseSaveObject
					{
						looseObjectSOName = builtBuildableFreeObject2.GetComponent<BuildableFreeObject>().GetBuildableFreeObjectTypeSO().name,
						position = builtBuildableFreeObject2.position,
						quaternion = builtBuildableFreeObject2.rotation.z
					});
				}
			}
			string text2 = JsonUtility.ToJson(new SaveObject
			{
				placedObjectSaveObjectArrayArray = list8.ToArray(),
				looseSaveObjectArray = list11.ToArray()
			});
			PlayerPrefs.SetString(uniqueSaveName + "_XY", text2);
			GridSaveSystem.Save(uniqueSaveName + "_XY", text2, overwrite: true);
			if (showConsoleText && saveAndLoad)
			{
				Debug.Log("Grid XY <color=green>Grid Data Saved!</color>");
			}
		}

		private void GridLoad()
		{
			if (gridAxis == GridAxis.XZ)
			{
				if (PlayerPrefs.HasKey(uniqueSaveName + "_XZ"))
				{
					PlayerPrefs.GetString(uniqueSaveName + "_XZ");
					SaveObject saveObject = JsonUtility.FromJson<SaveObject>(GridSaveSystem.Load(uniqueSaveName + "_XZ"));
					Vector3 vector = gridOriginXZ;
					for (int i = 0; i < gridXZList.Count; i++)
					{
						GridXZ<GridObjectXZ> passedGridXZ = gridXZList[i];
						gridOriginXZ = gridOriginXZList[i];
						BuildableGridObject.SaveObject[] placedObjectSaveObjectArray = saveObject.placedObjectSaveObjectArrayArray[i].placedObjectSaveObjectArray;
						foreach (BuildableGridObject.SaveObject saveObject2 in placedObjectSaveObjectArray)
						{
							BuildableGridObjectTypeSO buildableGridObjectTypeSOFromName = GetBuildableGridObjectTypeSOFromName(saveObject2.buildableGridObjectTypeSOName);
							TryPlaceGridObjectXZ(passedGridXZ, saveObject2.origin, buildableGridObjectTypeSOFromName, saveObject2.dir, isCallFromLoad: true, out var _);
						}
					}
					for (int k = 0; k < gridXZList.Count; k++)
					{
						GridXZ<GridObjectXZ> passedGridXZ2 = gridXZList[k];
						gridOriginXZ = gridOriginXZList[k];
						BuildableEdgeObject.SaveObject[] placedEdgeObjectSaveObjectArray = saveObject.placedEdgeObjectSaveObjectArrayArray[k].placedEdgeObjectSaveObjectArray;
						foreach (BuildableEdgeObject.SaveObject saveObject3 in placedEdgeObjectSaveObjectArray)
						{
							BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSOFromName = GetBuildableEdgeObjectTypeSOFromName(saveObject3.buildableEdgeObjectTypeSOName);
							TryPlaceEdgeObjectXZ(passedGridXZ2, saveObject3.origin, buildableEdgeObjectTypeSOFromName, saveObject3.dir, saveObject3.edgeRotation, saveObject3.mousePosition, isCallFromLoad: true, out var _);
						}
					}
					LooseSaveObject[] looseSaveObjectArray = saveObject.looseSaveObjectArray;
					foreach (LooseSaveObject looseSaveObject in looseSaveObjectArray)
					{
						TryPlaceFreeObjectXZ(GetBuildableFreeObjectTypeSOFromName(looseSaveObject.looseObjectSOName), looseSaveObject.position, looseSaveObject.quaternion, isCallFromLoad: true, out var _);
					}
					gridOriginXZ = vector;
				}
				if (showConsoleText && saveAndLoad)
				{
					Debug.Log("Grid XZ <color=green>Grid Data Loaded!</color>");
				}
				return;
			}
			if (PlayerPrefs.HasKey(uniqueSaveName + "_XY"))
			{
				PlayerPrefs.GetString(uniqueSaveName + "_XY");
				SaveObject saveObject4 = JsonUtility.FromJson<SaveObject>(GridSaveSystem.Load(uniqueSaveName + "_XY"));
				Vector3 vector2 = gridOriginXY;
				for (int l = 0; l < gridXYList.Count; l++)
				{
					GridXY<GridObjectXY> passedGridXY = gridXYList[l];
					gridOriginXY = gridOriginXYList[l];
					BuildableGridObject.SaveObject[] placedObjectSaveObjectArray = saveObject4.placedObjectSaveObjectArrayArray[l].placedObjectSaveObjectArray;
					foreach (BuildableGridObject.SaveObject saveObject5 in placedObjectSaveObjectArray)
					{
						BuildableGridObjectTypeSO buildableGridObjectTypeSOFromName2 = GetBuildableGridObjectTypeSOFromName(saveObject5.buildableGridObjectTypeSOName);
						TryPlaceGridObjectXY(passedGridXY, saveObject5.origin, buildableGridObjectTypeSOFromName2, saveObject5.dir, isCallFromLoad: true, out var _);
					}
				}
				LooseSaveObject[] looseSaveObjectArray = saveObject4.looseSaveObjectArray;
				foreach (LooseSaveObject looseSaveObject2 in looseSaveObjectArray)
				{
					TryPlaceFreeObjectXY(GetBuildableFreeObjectTypeSOFromName(looseSaveObject2.looseObjectSOName), looseSaveObject2.position, looseSaveObject2.quaternion, isCallFromLoad: true, out var _);
				}
				gridOriginXY = vector2;
			}
			if (showConsoleText && saveAndLoad)
			{
				Debug.Log("Grid XY <color=green>Grid Data Loaded!</color>");
			}
		}

		public BuildableFreeObjectTypeSO GetBuildableFreeObjectTypeSOFromName(string buildableFreeObjectTypeSOName)
		{
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
			{
				if (buildableFreeObjectTypeSO.name == buildableFreeObjectTypeSOName)
				{
					return buildableFreeObjectTypeSO;
				}
			}
			return null;
		}

		public BuildableEdgeObjectTypeSO GetBuildableEdgeObjectTypeSOFromName(string buildableEdgeObjectTypeSOName)
		{
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
			{
				if (buildableEdgeObjectTypeSO.name == buildableEdgeObjectTypeSOName)
				{
					return buildableEdgeObjectTypeSO;
				}
			}
			return null;
		}

		public BuildableGridObjectTypeSO GetBuildableGridObjectTypeSOFromName(string buildableGridObjectTypeSOName)
		{
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
			{
				if (buildableGridObjectTypeSO.name == buildableGridObjectTypeSOName)
				{
					return buildableGridObjectTypeSO;
				}
			}
			return null;
		}

		public void SetGridWidth(int gridWidth)
		{
			this.gridWidth = gridWidth;
		}

		public void SetGridLength(int gridLength)
		{
			this.gridLength = gridLength;
		}

		public void SetGridCellSize(float cellSize)
		{
			this.cellSize = cellSize;
		}

		public void SetGridHeight(float gridHeight)
		{
			this.gridHeight = gridHeight;
		}

		public void SetGridMode(GridMode gridMode)
		{
			this.gridMode = gridMode;
			this.OnGridModeChange?.Invoke(this, EventArgs.Empty);
		}

		public void SetActiveVerticalGrid(int currentActiveGridIndex)
		{
			if (gridAxis == GridAxis.XZ)
			{
				gridOriginXZ = gridOriginXZList[currentActiveGridIndex];
			}
			else
			{
				gridOriginXY = gridOriginXYList[currentActiveGridIndex];
			}
		}

		public void SetAutoDetectHeight(bool setActive)
		{
			autoDetectHeight = setActive;
		}

		public void SetChangeHeightWithInput(bool setActive)
		{
			changeHeightWithInput = setActive;
		}

		public void AddBuildableGridObjectTypeSO(BuildableGridObjectTypeSO buildableGridObjectTypeSO, bool checkIfAlreadyHas = false)
		{
			if (checkIfAlreadyHas)
			{
				if (!buildableGridObjectTypeSOList.Contains(buildableGridObjectTypeSO))
				{
					buildableGridObjectTypeSOList.Add(buildableGridObjectTypeSO);
				}
			}
			else
			{
				buildableGridObjectTypeSOList.Remove(buildableGridObjectTypeSO);
			}
		}

		public void AddBuildableFreeObjectTypeSO(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO, bool checkIfAlreadyHas = false)
		{
			if (checkIfAlreadyHas)
			{
				if (!buildableFreeObjectTypeSOList.Contains(buildableFreeObjectTypeSO))
				{
					buildableFreeObjectTypeSOList.Add(buildableFreeObjectTypeSO);
				}
			}
			else
			{
				buildableFreeObjectTypeSOList.Remove(buildableFreeObjectTypeSO);
			}
		}

		public void RemoveBuildableFreeObjectTypeSO(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			if (!buildableGridObjectTypeSOList.Contains(buildableGridObjectTypeSO))
			{
				buildableGridObjectTypeSOList.Remove(buildableGridObjectTypeSO);
			}
		}

		public void RemoveBuildableFreeObjectTypeSO(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			if (!buildableFreeObjectTypeSOList.Contains(buildableFreeObjectTypeSO))
			{
				buildableFreeObjectTypeSOList.Remove(buildableFreeObjectTypeSO);
			}
		}

		public void SetUseBuildableDistance(bool enable, Transform objectTransform = null, float distanceMin = 0f, float distanceMax = 0f)
		{
			useBuildableDistance = enable;
			distanceCheckObject = objectTransform;
			this.distanceMin = distanceMin;
			this.distanceMax = distanceMax;
		}

		public void SetUniqueSaveName(string uniqueSaveName)
		{
			this.uniqueSaveName = uniqueSaveName;
		}

		public void SetSaveLocation(string saveLocation)
		{
			this.saveLocation = saveLocation;
		}

		public GridAxis GetGridAxis()
		{
			return gridAxis;
		}

		public int GetGridWidth()
		{
			return gridWidth;
		}

		public int GetGridLength()
		{
			return gridLength;
		}

		public float GetGridCellSize()
		{
			return cellSize;
		}

		public float GetGridHeight()
		{
			return gridHeight;
		}

		public int GetActiveVerticalGridIndex()
		{
			return currentActiveGridIndex;
		}

		public int GetVerticalGridCount()
		{
			return verticalGridsCount;
		}

		public bool GetAutoDetectHeight()
		{
			return autoDetectHeight;
		}

		public bool GetChangeHeightWithInput()
		{
			return changeHeightWithInput;
		}

		public List<BuildableGridObjectTypeSO> GetBuildableGridObjectTypeSOList()
		{
			return buildableGridObjectTypeSOList;
		}

		public List<BuildableEdgeObjectTypeSO> GetBuildableEdgeObjectTypeSOList()
		{
			return buildableEdgeObjectTypeSOList;
		}

		public List<BuildableFreeObjectTypeSO> GetBuildableFreeObjectTypeSOList()
		{
			return buildableFreeObjectTypeSOList;
		}

		public Vector3 GetGridOrigin()
		{
			if (gridAxis == GridAxis.XZ)
			{
				return gridOriginXZ;
			}
			return gridOriginXY;
		}

		public GridMode GetGridMode()
		{
			return gridMode;
		}

		public string GetUniqueSaveName()
		{
			return uniqueSaveName;
		}

		public string GetSaveLocation()
		{
			return saveLocation;
		}

		private void OnObjectStartMoving(EasyGridBuilderPro ownSystem, GameObject movingObject)
		{
			if (!(ownSystem == this))
			{
				return;
			}
			if (gridAxis == GridAxis.XZ)
			{
				Vector3 mouseWorldPosition = GetMouseWorldPosition();
				gridXZ.GetXZ(mouseWorldPosition, out var x, out var z);
				BuildableGridObject buildableGridObject = ((!IsValidGridPositionXZ(new Vector2Int(x, z))) ? null : gridXZ.GetGridObjectXZ(mouseWorldPosition).GetPlacedObject());
				if (!(buildableGridObject != null))
				{
					return;
				}
				{
					foreach (Vector2Int gridPosition in buildableGridObject.GetGridPositionList())
					{
						gridXZ.GetGridObjectXZ(gridPosition.x, gridPosition.y).ClearPlacedObject();
						if (enableUnityEvents)
						{
							OnGridCellChangedUnityEvent?.Invoke();
						}
					}
					return;
				}
			}
			Vector3 mouseWorldPosition2 = GetMouseWorldPosition();
			gridXY.GetXY(mouseWorldPosition2, out var x2, out var y);
			BuildableGridObject buildableGridObject2 = ((!IsValidGridPositionXY(new Vector2Int(x2, y))) ? null : gridXY.GetGridObjectXY(mouseWorldPosition2).GetPlacedObject());
			if (!(buildableGridObject2 != null))
			{
				return;
			}
			foreach (Vector2Int gridPosition2 in buildableGridObject2.GetGridPositionList())
			{
				gridXY.GetGridObjectXY(gridPosition2.x, gridPosition2.y).ClearPlacedObject();
				if (enableUnityEvents)
				{
					OnGridCellChangedUnityEvent?.Invoke();
				}
			}
		}

		private void OnObjectStoppedMoving(EasyGridBuilderPro ownSystem, GameObject movingObject)
		{
			_ = ownSystem == this;
		}

		private void RemoveGridObjects()
		{
			BuildableGridObject[] array = UnityEngine.Object.FindObjectsOfType<BuildableGridObject>();
			BuildableGridObject[] array2;
			if (gridAxis == GridAxis.XZ)
			{
				array2 = array;
				foreach (BuildableGridObject buildableGridObject in array2)
				{
					if (!(buildableGridObject != null) || !(buildableGridObject.GetOwnGridSystem() == this))
					{
						continue;
					}
					buildableGridObject.DestroySelf();
					if (enableUnityEvents)
					{
						OnObjectRemovedUnityEvent?.Invoke();
					}
					if (showConsoleText && objectDestruction)
					{
						Debug.Log("Grid XZ <color=Red>Object Destroyed :</color> " + buildableGridObject);
					}
					foreach (Vector2Int gridPosition in buildableGridObject.GetGridPositionList())
					{
						gridXZ.GetGridObjectXZ(gridPosition.x, gridPosition.y).ClearPlacedObject();
						if (enableUnityEvents)
						{
							OnGridCellChangedUnityEvent?.Invoke();
						}
					}
				}
				return;
			}
			array2 = array;
			foreach (BuildableGridObject buildableGridObject2 in array2)
			{
				if (!(buildableGridObject2 != null))
				{
					continue;
				}
				buildableGridObject2.DestroySelf();
				if (enableUnityEvents)
				{
					OnObjectRemovedUnityEvent?.Invoke();
				}
				if (showConsoleText && objectDestruction)
				{
					Debug.Log("Grid XY <color=Red>Object Destroyed :</color> " + buildableGridObject2);
				}
				foreach (Vector2Int gridPosition2 in buildableGridObject2.GetGridPositionList())
				{
					gridXY.GetGridObjectXY(gridPosition2.x, gridPosition2.y).ClearPlacedObject();
					if (enableUnityEvents)
					{
						OnGridCellChangedUnityEvent?.Invoke();
					}
				}
			}
		}

		public void OnDrawGizmos()
		{
			if (gridEditorMode == GridEditorMode.None || !showEditorAndRuntimeDebugGrid)
			{
				return;
			}
			if (gridAxis == GridAxis.XZ)
			{
				Gizmos.color = editorGridLineColor;
				int[,] array = new int[gridWidth, gridLength];
				for (int i = 0; i < array.GetLength(0); i++)
				{
					for (int j = 0; j < array.GetLength(1); j++)
					{
						Gizmos.DrawLine(GetWorldPositionForDebugXZ(i, j), GetWorldPositionForDebugXZ(i, j + 1));
						Gizmos.DrawLine(GetWorldPositionForDebugXZ(i, j), GetWorldPositionForDebugXZ(i + 1, j));
					}
				}
				Gizmos.DrawLine(GetWorldPositionForDebugXZ(0, gridLength), GetWorldPositionForDebugXZ(gridWidth, gridLength));
				Gizmos.DrawLine(GetWorldPositionForDebugXZ(gridWidth, 0), GetWorldPositionForDebugXZ(gridWidth, gridLength));
				return;
			}
			Gizmos.color = editorGridLineColor;
			int[,] array2 = new int[gridWidth, gridLength];
			for (int k = 0; k < array2.GetLength(0); k++)
			{
				for (int l = 0; l < array2.GetLength(1); l++)
				{
					Gizmos.DrawLine(GetWorldPositionForDebugXY(k, l), GetWorldPositionForDebugXY(k, l + 1));
					Gizmos.DrawLine(GetWorldPositionForDebugXY(k, l), GetWorldPositionForDebugXY(k + 1, l));
				}
			}
			Gizmos.DrawLine(GetWorldPositionForDebugXY(0, gridLength), GetWorldPositionForDebugXY(gridWidth, gridLength));
			Gizmos.DrawLine(GetWorldPositionForDebugXY(gridWidth, 0), GetWorldPositionForDebugXY(gridWidth, gridLength));
		}

		public bool IsPointerOverUI()
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			foreach (RaycastResult item in list)
			{
				if (item.gameObject.GetComponent<RectTransform>() != null)
				{
					return true;
				}
			}
			return false;
		}

		protected Vector3 GetMouseWorldPosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f, mouseColliderLayerMask))
			{
				return hitInfo.point;
			}
			return new Vector3(-99999f, -99999f, -99999f);
		}

		private Vector3 BuildableFreeObjectCollidingMousePosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f, freeObjectCollidingLayerMask))
			{
				if (currentBuildableObjectType == BuildableObjectType.FreeObject && buildableFreeObjectTypeSO != null)
				{
					if (buildableFreeObjectTypeSO.snapToObjectSnappers)
					{
						if ((bool)hitInfo.collider.GetComponent<BuildableFreeObjectSnapper>())
						{
							return hitInfo.collider.GetComponent<BuildableFreeObjectSnapper>().transform.position;
						}
						return hitInfo.point;
					}
					return hitInfo.point;
				}
				return hitInfo.point;
			}
			return new Vector3(-99999f, -99999f, -99999f);
		}

		private Vector3 AutoDetectHeightMousePosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f, autoDetectHeightLayerMask))
			{
				return hitInfo.point;
			}
			return GetGridOrigin();
		}

		private Vector3 GetPlacedObjectMouseWorldPosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f))
			{
				if ((bool)hitInfo.collider.transform.root.GetComponent<BuildableGridObject>())
				{
					return hitInfo.collider.transform.root.GetComponent<BuildableGridObject>().transform.position;
				}
				return new Vector3(-99999f, -99999f, -99999f);
			}
			return new Vector3(-99999f, -99999f, -99999f);
		}

		private BuildableEdgeObject GetPlacedEdgeObjectMouseWorldPosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f))
			{
				if ((bool)hitInfo.collider.transform.root.GetComponent<BuildableEdgeObject>())
				{
					return hitInfo.collider.transform.root.GetComponent<BuildableEdgeObject>();
				}
				return null;
			}
			return null;
		}
	}
}
