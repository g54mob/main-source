using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameGalaxy : MonoBehaviour
{
	public enum SECTOR
	{
		MAIN = 0,
		STORY = 1,
		SPAN = 2,
		CHRONOM = 3,
		MARKV = 4,
		EDITOR = 5,
		COLONIES = 6,
		DEMO = 7,
		MVERSE = 8
	}

	[Serializable]
	public class ResponseData
	{
		public string image;

		public string link;
	}

	public GameObject gogGalaxyManager;

	public GameObject fileBrowserPanelPrefab;

	public GameObject writeFailPane;

	public TextMeshProUGUI writeFailErrorText;

	public GameObject windowsNPane;

	public GameObject exitGameDialog;

	public GameRecorderViewer recorderViewer;

	public Texture2D enemyIconsAtlas;

	public Camera mainCamera;

	public Vector3 camMainPos;

	public GameObject skyboxAnimator;

	public GameObject audioControllerRef;

	private List<Canvas> canvases;

	public GameObject galaxyPlanetPrefab;

	public TMP_Text versionText;

	public Image muteButtonImage;

	public static GameGalaxy instance;

	public GameObject[] sectorGOs;

	public GameObject celectialBackground;

	public GameObject mainMenu;

	public GameObject mainMenuControls;

	public GameObject mainMenuTitles;

	public GameObject showMainMenuButton;

	public TextMeshProUGUI spanCompleteText;

	public TextMeshProUGUI spanPartialText;

	public TextMeshProUGUI spanAvailText;

	public TextMeshProUGUI demoCompleteText;

	public Image chronomBadge0;

	public Image chronomBadge1;

	public Image chronomBadge2;

	public Image chronomBadge3;

	public Image chronomBadge4;

	public GameObject demoLabel;

	public GameObject demoButtonGrid;

	public GameObject demoTestButton;

	public GameObject farsiteButton;

	public GameObject chronomButton;

	public GameObject spanButton;

	public GameObject markVButton;

	public GameObject editorButton;

	public GameObject coloniesButton;

	public GameObject recordingsButton;

	public GameObject loadFileButton;

	public GameObject settingsButton;

	public GameObject knuckleCrackerButton;

	public GameObject creditsButton;

	public static GameSpace.CATEGORY? categoryScreenToShow;

	public Material[] spanNetworkPlanetObjectiveMaterial;

	public GameObject howToVideoContainer;

	public GameObject noVideoContainer;

	public TextMeshProUGUI newsText;

	public RawImage newsImage;

	public GameObject startHereIndicator;

	public GameObject demoSteamButton;

	private SECTOR _sector;

	public static bool multirun;

	public static string gameStartData;

	public static string rplTextFileName;

	private bool muteSound;

	private string launch_fileToLoad;

	private bool launch_embeddedLoad;

	private bool launch_editMode;

	private string launch_editorDirName;

	private bool launch_importMap;

	private GameSpace.CATEGORY launch_category;

	private int launch_colonyID;

	public static int launchedColonyID;

	private bool launching;

	private int lastScreenWidth;

	private int lastScreenHeight;

	private int lastScreenResolutionWidth;

	private int lastScreenResolutionHeight;

	private static bool ALLOWQUIT;

	public SECTOR sector
	{
		get
		{
			return default(SECTOR);
		}
		set
		{
		}
	}

	public void OnDisable()
	{
	}

	public void Start()
	{
	}

	public static bool CheckMultiRun()
	{
		return false;
	}

	private void ParseCommandLineArgs()
	{
	}

	public void Awake()
	{
	}

	private IEnumerator GetNews()
	{
		return null;
	}

	private IEnumerator GetNewsImage()
	{
		return null;
	}

	public void VisitWeb(string url)
	{
	}

	public void OnSteam()
	{
	}

	private static string GetGameObjectPath(Transform transform)
	{
		return null;
	}

	public void OnSoundOnOff()
	{
	}

	private void SetMuteSound(bool muteSound)
	{
	}

	public void LateUpdate()
	{
	}

	private void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void OnUIScaleChanged(float scale)
	{
	}

	public static void SetDefaultCulture()
	{
	}

	public void SetSector(int sector)
	{
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		return default(Vector3);
	}

	public void LaunchMission(string fileToLoad, bool embeddedLoad, bool editMode, bool importMap, GameSpace.CATEGORY category, int colonyID, string editorDirName, string title, string specifier)
	{
	}

	private void DelayedLaunchMission()
	{
	}

	public void OnRecordingsClosed()
	{
	}

	public void OnViewRecordingClicked()
	{
	}

	public void LoadMissionFromFileClicked()
	{
	}

	public void ToggleMainMenu()
	{
	}

	public void HideMainMenu()
	{
	}

	public void ShowMainMenu()
	{
	}

	public void OnCloseWindowsNPane()
	{
	}

	public void OnHowToButtonClicked()
	{
	}

	public void OnExitButtonClicked()
	{
	}

	public void ExitGame()
	{
	}

	public void ExitGameImmediate()
	{
	}

	private void CheckForResolutionChange()
	{
	}

	public bool WantsToQuit()
	{
		return false;
	}
}
