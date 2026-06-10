using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
	public class PointerData
	{
		public RectTransform pointerObject;

		public RectTransform followRect;

		public Vector2 followPos;

		public float pointerShow;
	}

	public class MapRoute
	{
		public NewNode start;

		public NewNode end;

		public NewGameLocation destinationTextOverride;

		public Human human;

		public int routeCursor;

		public PathFinder.PathData pathData;

		public bool nodeSpecific;

		public int lastUsedTolerance;

		private NewNode drawnFrom;

		private NewNode drawnTo;

		public Dictionary<GameObject, NewNode> spawnedObjects;

		public MapRoute(NewNode newStart, NewNode newEnd, Human newHuman, bool newNodeSpecific, NewGameLocation newDestinationTextOverride)
		{
		}

		public bool TryUpdateRouteCursor(out int newCursor, out int usedTolerance, int offcourseTolerance = 1)
		{
			newCursor = default(int);
			usedTolerance = default(int);
			return false;
		}

		public void UpdateRouteBasedOnPlayerPosition()
		{
		}

		public bool UpdatePathData(NewNode fromNode)
		{
			return false;
		}

		public void UpdateDrawnRoute()
		{
		}

		public void Remove()
		{
		}

		public string GetDestinationText()
		{
			return null;
		}

		public NewGameLocation GetDestinationLocation()
		{
			return null;
		}
	}

	public struct MapLayer
	{
		public Canvas canvas;

		public CanvasGroup canvasGroup;

		public RectTransform backgroundContainer;

		public RectTransform baseContainer;

		public RectTransform ductsContainer;

		public DrawingController drawingController;

		public Dictionary<Vector2, RawImage> baseBackgroundImages;

		public Dictionary<Vector2, Image> wallImages;
	}

	public delegate void RoutePlot();

	public delegate void RemoveRoute();

	[CompilerGenerated]
	private sealed class _003COpen_003Ed__145 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003COpen_003Ed__145(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CClose_003Ed__147 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CClose_003Ed__147(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Components")]
	public RectTransform contentRect;

	public RectTransform paperRect;

	public RectTransform viewport;

	public ZoomContent zoomController;

	public DragCoverage drag;

	public CustomScrollRect scrollRect;

	public RectTransform controlsRect;

	public Canvas contentCanvas;

	public ButtonController mapCloseButton;

	public RectTransform mapCursor;

	public ContextMenuController mapContextMenu;

	public TextMeshProUGUI districtMapName;

	public ButtonController centreOnPlayerButton;

	public ButtonController controllerSelectMapButton;

	public ButtonController plotRouteButton;

	public ButtonController autoTravelButton;

	public JuiceController plotRouteActiveJuice;

	public JuiceController autoTravelActiveJuice;

	public Sprite autoTravelIcon;

	public Sprite fastTravelIcon;

	public RectTransform viewportCenter;

	public GameObject mapLoadingGraphic;

	[Header("Drawing")]
	public bool drawingMode;

	public bool eraseMode;

	public Color drawingColour;

	public RectTransform drawBrushRect;

	public ButtonController toggleDrawingButton;

	public ColourSelectorButtonController colourButton;

	public ButtonController eraserButton;

	public ButtonController clearButton;

	[Header("State")]
	public int load;

	public bool displayPlayerCharacter;

	public bool displayFirstPerson;

	public RectTransform playerCharacterRect;

	public NewNode mapCursorNode;

	private NewNode cursorNodeChange;

	public Vector2 cursorPos;

	public List<MapAddressButtonController> mapUpdateList;

	public List<MapDuctsButtonController> ductsUpdateList;

	public List<MapAddressButtonController> mapDrawnList;

	[Header("Map Overlays")]
	public RectTransform routesRect;

	public RectTransform linesRouteRect;

	public RectTransform citizensRouteRect;

	public RectTransform sightingsRoutRect;

	public RectTransform overlayAll;

	public RectTransform pinsRect;

	public RectTransform tooltipOverride;

	private List<PointerData> pointers;

	public Dictionary<Transform, List<RectTransform>> dynamicTrackedObjects;

	public Dictionary<Transform, List<RectTransform>> staticTrackedObjects;

	public Dictionary<InfoWindow, MapPinButtonController> pinnedObjects;

	public List<InfoWindow> invisiblePins;

	[Header("Key")]
	public TextMeshProUGUI keyUnexplored;

	public TextMeshProUGUI keyExploredSafe;

	public TextMeshProUGUI keyExploredPrivate;

	public TextMeshProUGUI keyVent;

	public TextMeshProUGUI keyDuct;

	public TextMeshProUGUI keyOpenHoursOnly;

	[Header("Setup")]
	public float nodePositionMultiplier;

	private float realPositionMultiplier;

	public float positionBuffer;

	public float edgeBuffer;

	public float focusSpeed;

	public float openProgress;

	public float savedSize;

	public RectTransform baseLayer;

	public FloorZoomController fzc;

	private bool forceFocusActive;

	private float forceFocusProgress;

	private RectTransform focusRect;

	private Vector2 focusPos;

	private Vector2 lastViewportCentrePos;

	public MapRoute playerRoute;

	[Header("Graphics")]
	public float mapResolutionDivision;

	public int wallWidth;

	public Color roomBaseColor;

	[Tooltip("Add this amount to the above once highlighted")]
	public Color highlightedColourAdditive;

	[Tooltip("This will be drawn to all floor textures")]
	public Texture2D publicFloorTexture;

	public Texture2D privateFloorTexture;

	public Texture2D nullRoomTexture;

	public Texture2D undiscoveredTexture;

	[Tooltip("This will be used for drawing walls")]
	public Texture2D wallTexture;

	public Texture2D wallTexCorners;

	public List<Texture2D> wallEdge;

	public List<Texture2D> wallDoorway;

	public List<Texture2D> wallWindow;

	public List<Texture2D> outsideWindow;

	public List<Texture2D> dividerLeft;

	public List<Texture2D> dividerRight;

	public List<Texture2D> stairwell;

	public Texture2D vent;

	public Texture2D ventUpwardsConnection;

	public Texture2D ventDownwardsConnection;

	[Header("Direction Arrow")]
	public GameObject directionalArrowContainer;

	public bool displayDirectionArrow;

	public Transform directionalArrow;

	public float directionalArrowDesiredFade;

	public float directionalArrowAlpha;

	public Material arrowMaterial;

	[Header("Canvas Components")]
	public Dictionary<int, MapLayer> mapLayers;

	public List<MapAddressButtonController> buttons;

	private List<GameObject> spawnedDebugComponents;

	private static MapController _instance;

	public static MapController Instance => null;

	public event RoutePlot OnPlotRoute
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event RemoveRoute OnRemoveRoute
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void Setup()
	{
	}

	public void ControllerMapHoverChange(ButtonController hoveredButton, bool hovered)
	{
	}

	public void BuildMap()
	{
	}

	public void UpdateNeededMapDisplay()
	{
	}

	public void AddUpdateCall(MapAddressButtonController loc, bool needsImageRebuild = true)
	{
	}

	public void AddDuctUpdateCall(MapDuctsButtonController loc, bool needsImageRebuild = true)
	{
	}

	public void OnPinNewEvidence(Evidence ev)
	{
	}

	public void OnUnpinEvidence(Evidence ev)
	{
	}

	public void PinnedDataKeyChange()
	{
	}

	public void AddNewTrackedObject(Transform gameObj, Sprite mapIcon, Vector2 size, Color colour, bool isDynamic, object buttonReference)
	{
	}

	public void PressTracked(ButtonController pressedButton)
	{
	}

	public void HoverTracked(ButtonController hoveredButton, bool hovered)
	{
	}

	public void RemoveTrackedObject(Transform gameObj)
	{
	}

	public void UpdateTrackedObject(Transform gameObj, RectTransform mapObj)
	{
	}

	public void CentreOnTrackedObject(Transform gameObj, bool instant = false)
	{
	}

	public void CentreOnObject(RectTransform mapObj, bool instant = false, bool showPointer = false)
	{
	}

	public void CentreOnNodeCoordinate(Vector3 pathCoord, bool instant = false, bool showPointer = false)
	{
	}

	public Vector2 ClampMapScrollPosition(Vector2 focusPos)
	{
		return default(Vector2);
	}

	public void SetFloorLayer(int newFloor, bool forceLoad = false)
	{
	}

	public Vector2 NodeCoordToMap(Vector3 pos)
	{
		return default(Vector2);
	}

	public Vector2 RealPosToMap(Vector3 coords)
	{
		return default(Vector2);
	}

	public Vector2 MapToNode(Vector2 coords)
	{
		return default(Vector2);
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void UpdateSize()
	{
	}

	public void OpenMap(bool firstPerson, bool playSound = true)
	{
	}

	[IteratorStateMachine(typeof(_003COpen_003Ed__145))]
	private IEnumerator Open()
	{
		return null;
	}

	public void CloseMap(bool playSound = true)
	{
	}

	[IteratorStateMachine(typeof(_003CClose_003Ed__147))]
	private IEnumerator Close()
	{
		return null;
	}

	public void LocateEvidenceOnMap(Evidence ev)
	{
	}

	public void LocateRoomOnMap(NewRoom room)
	{
	}

	public void PlotPlayerRoute(Evidence ev)
	{
	}

	public void PlotPlayerRoute(NewGameLocation loc)
	{
	}

	public void PlotPlayerRoute(NewAddress loc)
	{
	}

	public void PlotPlayerRoute(StreetController loc)
	{
	}

	public void PlotPlayerRoute(NewNode loc, bool nodeSpecific, NewGameLocation destinationTextOverride = null)
	{
	}

	public void RemovePlayerRoute()
	{
	}

	private void SetTimelineCitizenTransparency(int citizenFloor, RectTransform objectRect)
	{
	}

	private Vector3 FindWorldPoint(PathFinder.PathData pathData, float percentAlong, out int lastPointIndex, out float distanceSinceLastPoint, out int nextPointIndex)
	{
		lastPointIndex = default(int);
		distanceSinceLastPoint = default(float);
		nextPointIndex = default(int);
		return default(Vector3);
	}

	public void DisplayDirectionArrow(bool val)
	{
	}

	public void ResetThis()
	{
	}

	public void ToggleDrawingMode()
	{
	}

	public void OnChangeDrawingColour()
	{
	}

	public void ToggleEraser()
	{
	}

	public void ClearDrawing()
	{
	}

	public void OpenEvidence()
	{
	}

	public void PlotRoute()
	{
	}

	public void AutoTravel()
	{
	}

	public void CancelRoute()
	{
	}

	public void DebugAccess()
	{
	}
}
