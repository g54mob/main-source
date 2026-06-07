using SpaceGraphicsToolkit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionSpace : MonoBehaviour
{
	public static MissionSpace instance;

	public GameObject fileBrowserPanelPrefab;

	public Canvas[] canvases;

	public GameObject audioControllerRef;

	public MissionSpaceMainNav mainNavPane;

	public RegionNav regionNav;

	public AlphaZone alphaZonePane;

	public MissionSpaceMapEditor editorPane;

	public GameRecorderViewer recorderViewer;

	public GameObject backgroundClouds;

	public GameObject UICanvas;

	public GameObject UI;

	public GameObject border;

	public RawImage finalUI;

	public RawImage finalUI2;

	public TMP_Text versionText;

	public Transform circleGrid;

	public SgtStarfieldInfinite starfieldInfinite;

	public Camera mainCamera;

	public Camera eclipticCamera;

	private float CAMERA_ROTATE_SPEED;

	private float cameraYRotation;

	private float cameraXRotation;

	private float CAMERA_FLY_SPEED;

	private bool loadingMission;

	private bool launched;

	public GameObject preloadTextures;

	private bool _freeAngle;

	private float launchMultiplier;

	private string launch_fileToLoad;

	private bool launch_embeddedLoad;

	private bool launch_editMode;

	private string launch_editorDirName;

	private bool launch_importMap;

	private GameSpace.CATEGORY launch_category;

	private int launch_colonyID;

	private bool freeAngle
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public static void SetDefaultCulture()
	{
	}

	public void LaunchMission(string fileToLoad, bool embeddedLoad, bool editMode, bool importMap, GameSpace.CATEGORY category, int colonyID, string editorDirName)
	{
	}

	public void PlayClickSound()
	{
	}

	public void PlayOpenSound()
	{
	}

	public void PlayCloseSound()
	{
	}

	public void OnUIScaleChanged(float scale)
	{
	}

	public void LoadMissionFromFileClicked()
	{
	}

	private void FileBrowserOutput(string[] paths)
	{
	}

	public void BlackBoxClicked()
	{
	}

	private void FileBrowserBlackBoxOutput(string[] paths)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}

	public void OnBlackBoxClosed()
	{
	}

	public void ExitGame()
	{
	}

	public void ExitGameImmediate()
	{
	}
}
