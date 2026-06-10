using System.Collections.Generic;
using UnityEngine;

public class PrefabControls : MonoBehaviour
{
	[Header("Interface Prefabs")]
	public GameObject progressBarPip;

	public GameObject buttonAdditionalHighlight;

	public GameObject contextMenuPanel;

	public GameObject evidenceContentPageControls;

	public GameObject speechBubble;

	public GameObject attackBar;

	public GameObject gameMessage;

	public GameObject keyMergeGameMessage;

	public GameObject socialCreditGameMessage;

	public GameObject tooltip;

	public GameObject dialogOption;

	public GameObject soundIndicatorIcon;

	public GameObject awarenessIndicator;

	public GameObject uiPointer;

	public GameObject crossOut;

	public GameObject aiReactionIndicator;

	public GameObject lockpickProgressBar;

	public GameObject statusElement;

	public GameObject statusRemovedIcon;

	public GameObject crosshairReaction;

	public GameObject upgradesSource;

	public GameObject upgradesInputButton;

	public GameObject upgradesOutputButton;

	public GameObject upgradesConnection;

	public GameObject radialSelectionSegment;

	public GameObject objectSelectionIcon;

	public GameObject revealQuestionObject;

	public GameObject interfaceVideo;

	[Header("CityEditor Prefabs")]
	public GameObject[] CityConstructorPrefabs;

	public GameObject pathfinderPrefab;

	[Header("CityEditor Target Transforms")]
	public Transform CityConstructorTargetTransform;

	[Header("Overhead Map")]
	public GameObject doorMapComponent;

	public GameObject mapButtonComponent;

	public GameObject mapDuctComponent;

	public GameObject floorPlanBlockWall;

	public GameObject streetName;

	public GameObject districtName;

	public GameObject playerMarker;

	public GameObject mapPointer;

	public GameObject routeLine;

	public GameObject mapBuildingGraphic;

	public GameObject tutorialPointer;

	public GameObject mapLayerCanvas;

	public GameObject mapRectContainer;

	public Texture2D drawingBrush;

	public Texture2D eraseBrush;

	public GameObject debugAccess;

	public Sprite mapCharacterMarker;

	public Color characterMarkerColor;

	public List<Color> motionTrackerColors;

	[Header("Buttons")]
	public GameObject evidenceButton;

	public GameObject factButton;

	public GameObject factHideToggleButton;

	public GameObject newCustomFactButton;

	public GameObject caseFolderClassIconButton;

	public GameObject contextMenuButton;

	public GameObject checklistButton;

	public GameObject linkButton;

	[Header("Case Panel")]
	public GameObject casePanelObject;

	public GameObject stringLink;

	public GameObject customStringLinkSelect;

	public GameObject boxSelect;

	public GameObject caseButton;

	public GameObject quickMenu;

	[Header("Window Prefabs")]
	public GameObject infoWindow;

	public GameObject tabButton;

	public GameObject suspectWindowEntry;

	public GameObject passcodesEntry;

	public GameObject passcodesEntryMini;

	public GameObject phoneNumberEntry;

	public GameObject drawingControls;

	public GameObject pagePip;

	[Header("Debug Prefabs")]
	public GameObject pathfindRoomDebug;

	public GameObject pathfindNodeDebug;

	public GameObject pathfindInternalDebug;

	public GameObject walkPointSphere;

	public GameObject usePointSphere;

	public GameObject streetChunkDebug;

	public GameObject junctionChunkDebug;

	public GameObject streetAreaChunkDebug;

	public GameObject streetNodeDebug;

	public GameObject furnitureDebug;

	[Header("City")]
	public GameObject neonSign;

	[Header("Game World")]
	public GameObject citizen;

	public GameObject floorTile;

	public GameObject smallFloorTile;

	public GameObject smallFloorTileVent;

	public GameObject ceilingTile;

	public GameObject smallCeilingTile;

	public GameObject smallCeilingTileVent;

	public GameObject wallTile;

	public GameObject shortWallTile;

	public GameObject corner;

	public GameObject quoin;

	public GameObject elevator;

	public GameObject peekUnderDoor;

	public InteractablePreset peekInteractable;

	public GameObject exteriorShadowLight;

	public InteractablePreset airVent;

	public GameObject policeTape;

	public GameObject damageCollider;

	public GameObject streetSniperMuzzleFlash;

	public GameObject lightningStrike;

	public GameObject fingerprint;

	public GameObject footprint;

	public GameObject scenePoserFigure;

	public GameObject shatterShard;

	public GameObject glassShard;

	public GameObject flashBombFlash;

	public GameObject incapacitatorFlash;

	public InteractablePreset bloodPool;

	public InteractablePreset cupOfWater;

	public GameObject cigarette;

	public GameObject cigar;

	public GameObject smokingExhale;

	public InteractablePreset cigaretteEnd;

	[Header("Blood Patterns")]
	public GameObject spatterSimulation;

	[Header("Modular Location Objects")]
	public GameObject district;

	public GameObject block;

	public GameObject cityTile;

	public GameObject building;

	public GameObject street;

	public GameObject floor;

	public GameObject address;

	public GameObject room;

	public GameObject tile;

	public GameObject node;

	public GameObject wall;

	public GameObject door;

	public GameObject covingShort;

	public GameObject covingLong;

	public GameObject covingCorner;

	[Header("Containers/References")]
	public Transform camHeightParent;

	public GameObject cityContainer;

	public RectTransform tooltipsContainer;

	public RectTransform contextMenuContainer;

	public Transform pathfindDebugParent;

	public RectTransform menuCanvas;

	public RectTransform tooltipsCanvas;

	public Transform mapContainer;

	public RectTransform dialogRect;

	public RectTransform dialogOptionContainer;

	public Transform poserContainer;

	public RectTransform objectSelectionContainer;

	public Transform debugDecorContainer;

	public GameObject citizenHolder;

	[Header("Floor Edit")]
	public GameObject editorTile;

	public GameObject entranceArrow;

	public GameObject wallTrigger;

	public GameObject blueprintWallLong;

	public GameObject blueprintWallShort;

	public GameObject heldSelector;

	public GameObject debugAttemptObject;

	public GameObject debugNodeDisplay;

	private static PrefabControls _instance;

	public static PrefabControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
