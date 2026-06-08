using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class DroneManager : MonoBehaviour, ICommandable
{
	public enum HintOverlayStateEnum
	{
		None = 0,
		PulsingOverlay = 1,
		HoldingOverlayAfterPulse = 2,
		HoldingOverlayUntilDone = 3,
		FadeOutToDone = 4
	}

	public enum QualityEnum
	{
		HighOrDefault = 0,
		Medium = 1,
		Low = 2
	}

	public class StaleLightData
	{
		public GameObject lightObj { get; private set; }

		public float lifetime { get; set; }

		public StaleLightData(GameObject lightObj, float lifetime)
		{
			this.lightObj = lightObj;
			this.lifetime = lifetime;
		}
	}

	private const float HINT_PULSE_DELAY = 0.25f;

	private const float HINT_COMPLETED_FADEOUT = 0.4f;

	private const int HINT_PULSE_COUNT = 5;

	private const float HINT_HOLD_AFTER_PULSE = 1f;

	private const float HINT_HOLD_TILL_DONE = 10f;

	private const float DRONE_SV_REFRESH_PERIOD = 0.2f;

	public static DroneManager Instance = null;

	public static int SeedLootableDrones = -1;

	public static Color UpgradeColorNormal = Color.white;

	public static Color UpgradeColorNormalDimmed = Color.gray;

	public static Color UpgradeColorBroken = Color.yellow;

	public static Color UpgradeColorError = Color.red;

	public static Color UpgradeColorBrokenDimmed = new Color(0.5f, 0.5f, 0.005f, 1f);

	public static Color UpgradeColorErrorDimmed = new Color(0.5f, 0f, 0f);

	public static Color UpgradeColorFixed = Color.cyan;

	public static Color UpgradeColorFixedDimmed = new Color(0f, 0.5f, 0.5f, 0.5f);

	public bool ShowDroneWindow = true;

	public DroneSelectedDelegate OnSelectedDrone;

	public GameObject DronePrefab;

	public GameObject DronesPanelGameObject;

	public GameObject[] DVOverlayLineObjects;

	private int _curDroneNumber = 1;

	public Camera DroneCamera;

	public Camera SchematicCamera;

	public Camera HUDCamera;

	public Camera HUDOverlayCamera;

	public Camera BoardingShipCamera;

	public Image boardingShipOverlayUI;

	public RawImage boardingShipUI;

	private RenderTexture lightRT;

	private RenderTexture pixelRT;

	private RenderTexture depthRT;

	private RenderTexture colorRT;

	private RenderTexture staticRT;

	public bool EnableStaleData;

	public bool EnableStaleDataLossWhenNotMoving;

	public bool EnableStaleDataOnCurrentOnly;

	public bool DebugDisableHUD;

	public bool DebugDisableDroneTopLight;

	public bool DebugUseTestSpotlight;

	public bool DebugUseCameraArraySpotlight;

	public bool DebugEnableCameraArray;

	public bool DebugEnableCameraArrayLight;

	public bool DebugEnableDualQuality;

	private Rect droneWindowRect;

	private int currentPreset = -1;

	private WeakReference _gameplayManagerWeakReference;

	private bool haveDronesToRemove;

	private List<Drone> dronesToRemoveList = new List<Drone>();

	private UILineRenderer line = new UILineRenderer();

	private List<Drone> _dronesThatJustDocked;

	public Dictionary<Drone, List<StaleLightData>> sdLightArray;

	public float StaleDataLifetimeSeconds = 2f;

	public int StaleDataMaxLightsPerDrone = 10;

	public bool EnableDelayBetweenLightDrops;

	public float DelayStaleDataLightMS = 100f;

	private float timeTilNextStaleLightDrop;

	private bool startupOnSchematicView;

	private Vector3 currentDronePositionLast;

	private HintOverlayStateEnum currentHintOverlayState;

	private bool isShowingHintOverlay;

	private float delayHintStates;

	private int pulseCount;

	private bool fadingIn;

	private bool renderedAtLeastOnePixelData;

	private float timerUntilDoneRenderPixels = 0.5f;

	public List<Camera> dvpCameras;

	private CameraColorMaskEffect currentColorDataCamShader;

	private CameraMultiChannelDepthEffect currentDepthDataCamShader;

	private bool previousFullScreen;

	private AudioSource asSEngineSustain;

	private AudioSource asRShipCreak;

	private GameAudio.SoundEnum soundRShipCreak;

	private bool isSEngineSustainPaused;

	private float _droneSvRefreshTimer = 0.1f;

	private GameObject droneAudioHolderGameObject;

	private System.Random rndLootableDrones;

	private List<Bounds> corridorBoundsList;

	private Dictionary<Collider, List<GameObject>> boundingTreeList;

	private string cameraArrayName = "CameraArray2";

	private Vector3 lastCurrentDronePosition = Vector3.zero;

	private List<RenderTexture> tempRenderTextures;

	private GameObject LightDataCameraObject;

	private List<CommandDefinition> commandList;

	private List<CommandDefinition> baseCommandList;

	private List<CommandDefinition> commandAvailableList = new List<CommandDefinition>();

	private List<ICombatTarget> lures = new List<ICombatTarget>(30);

	private List<ICombatTarget> probes = new List<ICombatTarget>(30);

	private List<ICombatTarget> sensors = new List<ICombatTarget>(10);

	public Camera ActiveCamera
	{
		get
		{
			return (GlobalSettings.cameraMode != CameraMode.Schematic) ? DroneCamera : SchematicCamera;
		}
	}

	public QualityEnum currentQuality { get; private set; }

	public List<Drone> dronesList { get; set; }

	public List<IDrone> IDronesList { get; set; }

	public List<Drone> LootableDronesList { get; set; }

	private GameplayManager GPManager
	{
		get
		{
			return (GameplayManager)_gameplayManagerWeakReference.Target;
		}
	}

	public bool swapUIShown { get; set; }

	public Drone CurrentDrone { get; private set; }

	public SchematicViewDronePanel currentDronePanel { get; private set; }

	public bool isHUDOverlayCameraInUse { get; private set; }

	public bool isGeneralGlitchEffectsInUse { get; set; }

	public List<GameObject> playerDroneSpotlights { get; set; }

	public bool isInLostVideoState { get; set; }

	public int DroneCameraMask { get; private set; }

	public int SchematicCameraMask { get; private set; }

	public int HudCameraMask { get; private set; }

	public bool IsPrimaryCommandContext { get; set; }

	public string CommandHeader
	{
		get
		{
			return "Global Drone";
		}
	}

	public Drone GetDrone(int droneNumber)
	{
		int count = dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone drone = dronesList[i];
			if (drone.DroneNumber == droneNumber)
			{
				return drone;
			}
		}
		return null;
	}

	public Drone GetDrone(string droneName)
	{
		int count = dronesList.Count;
		int length = droneName.Length;
		for (int i = 0; i < count; i++)
		{
			Drone drone = dronesList[i];
			if (drone.DroneName.Length == length && drone.DroneName[0] == droneName[0] && drone.DroneName == droneName)
			{
				return drone;
			}
		}
		return null;
	}

	private void Awake()
	{
		Instance = this;
		dronesList = new List<Drone>();
		IDronesList = new List<IDrone>();
		LootableDronesList = new List<Drone>();
		_dronesThatJustDocked = new List<Drone>();
		Camera[] array = UnityEngine.Object.FindObjectsOfType(typeof(Camera)) as Camera[];
		Camera[] array2 = array;
		foreach (Camera camera in array2)
		{
			camera.gameObject.SetActive(false);
			if (camera.name.StartsWith("DVP"))
			{
				if (dvpCameras == null)
				{
					dvpCameras = new List<Camera>();
				}
				dvpCameras.Add(camera);
			}
		}
		if (GlobalSettings.GameStartedFromGalaxyMap)
		{
			int j;
			for (j = 1; j <= 4; j++)
			{
				IDrone drone = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => !x.IsDead && x.IsVisible && x.DroneNumber == j);
				if (drone != null)
				{
					Drone drone2 = InstantiateFleetDrone(j);
					_dronesThatJustDocked.Add(drone2);
					drone2.DroneName = drone.DroneName;
				}
			}
		}
		else
		{
			DVPConfigurationManager.Initalize();
			int num = 4;
			if (GlobalSettings.IsTutorial)
			{
				num = 2;
			}
			for (int num2 = 1; num2 <= num; num2++)
			{
				Drone item = InstantiateFleetDrone(num2);
				_dronesThatJustDocked.Add(item);
			}
			if (GlobalSettings.IsTutorial)
			{
				dronesList[0].CSID = 2;
				dronesList[1].CSID = 4;
			}
		}
		previousFullScreen = Screen.fullScreen;
	}

	private void Start()
	{
		_gameplayManagerWeakReference = new WeakReference(GameplayManager.Instance);
		currentDronePanel = DronesPanelGameObject.GetComponent<SchematicViewDronePanel>();
		List<UIVertex> list = new List<UIVertex>();
		UIVertex item = new UIVertex
		{
			position = new Vector3(0f, 0f)
		};
		list.Add(default(UIVertex));
		item.position = new Vector3(100f, 100f);
		list.Add(item);
		if (DebugEnableCameraArray)
		{
			InitalizeCammeraArray();
		}
		ActivateDroneCamera();
		if (!DebugDisableHUD && HUDCamera != null)
		{
			SetUseHUDOverlayCamera(GameSaveFile.Get("Q_STATIC_HONLY", true));
			SetUseGlobalGlitchEffects(GameSaveFile.Get("Q_STATIC_H", true));
			HUDCamera.gameObject.SetActive(true);
			if (isHUDOverlayCameraInUse)
			{
				HUDOverlayCamera.gameObject.SetActive(true);
			}
			HUDCamera.transform.position = DroneCamera.transform.position;
			if (isHUDOverlayCameraInUse)
			{
				HUDOverlayCamera.transform.position = DroneCamera.transform.position;
			}
			HUDCamera.transform.parent = DroneCamera.transform;
			if (isHUDOverlayCameraInUse)
			{
				HUDOverlayCamera.transform.parent = DroneCamera.transform;
			}
		}
		droneWindowRect = new Rect(65f, 20f, 200f, 225f);
		int count = dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			dronesList[i].SetEnemyList(EnemyManager.Instance.Enemies);
		}
		DroneUpgradeFactory.Initialize();
		if (!GlobalSettings.GameStartedFromGalaxyMap)
		{
			PresetManager.Initialze();
		}
		if (GlobalSettings.GameStartedFromGalaxyMap && !GlobalSettings.IsTutorial)
		{
			SyncGlobalDronesToSceneDrones();
		}
		else
		{
			System.Random rnd = new System.Random();
			for (int num = count - 1; num >= 0; num--)
			{
				Drone drone = dronesList[num];
				if (GlobalSettings.IsTutorial && drone.DroneNumber > 2)
				{
					dronesList.RemoveAt(num);
					IDronesList.Remove(drone);
					UnityEngine.Object.Destroy(drone.transform.parent.gameObject);
				}
				else
				{
					DroneCharacteristics.Assign(drone, true, null, rnd);
					drone.SetSelectedDroneVisual();
					drone.CurrentMaxSpeed = drone.OriginalSpeed;
					drone.OverrideCurrentHitpoints(drone.TotalHitpoints);
					drone.NumberOfUpgradeSlots = 3;
					if (drone.transform.parent != null)
					{
						drone.transform.parent.name = string.Format("Drone {0} - {1} ParentObject", drone.DroneNumber, drone.DroneName);
					}
				}
			}
			if (!GlobalSettings.IsTutorial)
			{
				if (PresetManager.PresetList.Count > 0)
				{
					if (!PresetManager.HasSnapshot)
					{
						ChooseNextPreset();
					}
					else
					{
						PresetManager.BuildDronesFromPresetDefinition(PresetManager.SnapshotPreset, IDronesList);
					}
				}
				else
				{
					Drone drone2 = GetDrone(1);
					BaseDroneUpgrade upgrade = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.BruteTurret);
					drone2.AddDroneUpgrade(0, upgrade);
					BaseDroneUpgrade upgrade2 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.AreaSensor);
					drone2.AddDroneUpgrade(1, upgrade2);
					BaseDroneUpgrade upgrade3 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Scanner);
					drone2.AddDroneUpgrade(2, upgrade3);
					BaseDroneUpgrade upgrade4 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.SpeedBoost);
					drone2.AddDroneUpgrade(3, upgrade4);
					Drone drone3 = GetDrone(2);
					upgrade = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.SwarmTurret);
					drone3.AddDroneUpgrade(0, upgrade);
					BaseDroneUpgrade upgrade5 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Sensor);
					drone3.AddDroneUpgrade(1, upgrade5);
					BaseDroneUpgrade upgrade6 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.ProximityMine);
					drone3.AddDroneUpgrade(2, upgrade6);
					upgrade4 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.SpeedBoost);
					drone3.AddDroneUpgrade(3, upgrade4);
					Drone drone4 = GetDrone(3);
					BaseDroneUpgrade upgrade7 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Interface);
					drone4.AddDroneUpgrade(0, upgrade7);
					BaseDroneUpgrade upgrade8 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Gatherer);
					drone4.AddDroneUpgrade(1, upgrade8);
					BaseDroneUpgrade upgrade9 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Repair);
					drone4.AddDroneUpgrade(2, upgrade9);
					drone4.AddDroneUpgrade(3, DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Probe));
					Drone drone5 = GetDrone(4);
					BaseDroneUpgrade upgrade10 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Generator);
					drone5.AddDroneUpgrade(0, upgrade10);
					BaseDroneUpgrade upgrade11 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.StealthField);
					drone5.AddDroneUpgrade(1, upgrade11);
					BaseDroneUpgrade upgrade12 = DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Teleporter);
					drone5.AddDroneUpgrade(2, upgrade12);
					drone5.AddDroneUpgrade(3, DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Shield));
				}
			}
		}
		for (int j = 1; j <= 4 && !SetDroneNumber(j); j++)
		{
		}
		PositionFleetDrones();
		DungeonManager.Instance.DronesInitialized();
		DroneCameraMask = DroneCamera.cullingMask;
		SchematicCameraMask = SchematicCamera.cullingMask;
		if (!DebugDisableHUD)
		{
			HudCameraMask = HUDOverlayCamera.cullingMask;
		}
		sdLightArray = new Dictionary<Drone, List<StaleLightData>>();
		if (!GlobalSettings.IsTutorial)
		{
			GlobalSettings.cameraMode = CameraMode.Schematic;
			UpdateCameraView();
			GlobalSettings.cameraMode = CameraMode.Drone;
			currentDronePanel.IsVisible = false;
			startupOnSchematicView = true;
		}
		AddSoundSources();
		QualityEnum quality = (QualityEnum)GameSaveFile.Get("P_QG", 0);
		SetQuality(quality);
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Outpost)
		{
			BoardingShipCamera.gameObject.SetActive(false);
			boardingShipUI.gameObject.SetActive(false);
			boardingShipOverlayUI.gameObject.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		DronePrefab = null;
		DronesPanelGameObject = null;
		DVOverlayLineObjects = null;
		RemoveSoundSources();
		if (GlobalSettings.GameStartedFromGalaxyMap)
		{
			CleanUpBeforeClose();
		}
	}

	public void CleanUpBeforeClose()
	{
		if (DebugEnableCameraArray && tempRenderTextures != null)
		{
			int count = tempRenderTextures.Count;
			for (int i = 0; i < count; i++)
			{
				RenderTexture.ReleaseTemporary(tempRenderTextures[i]);
				tempRenderTextures[i] = null;
			}
		}
		if (lightRT != null)
		{
			RenderTexture.ReleaseTemporary(lightRT);
			lightRT = null;
		}
		if (colorRT != null)
		{
			RenderTexture.ReleaseTemporary(colorRT);
			colorRT = null;
		}
		if (depthRT != null)
		{
			RenderTexture.ReleaseTemporary(depthRT);
			depthRT = null;
		}
		if (pixelRT != null)
		{
			RenderTexture.ReleaseTemporary(pixelRT);
			pixelRT = null;
		}
		if (staticRT != null)
		{
			RenderTexture.ReleaseTemporary(staticRT);
			staticRT = null;
			HUDCamera.targetTexture = null;
			HUDCamera.GetComponent<ScreenOverlay>().textureRT = null;
		}
		DronePrefab = null;
		DronesPanelGameObject = null;
		DVOverlayLineObjects = null;
		boardingShipOverlayUI = null;
		boardingShipUI = null;
		boardingShipOverlayUI = null;
		boardingShipUI = null;
		if (playerDroneSpotlights != null)
		{
			playerDroneSpotlights.Clear();
			playerDroneSpotlights = null;
		}
		currentColorDataCamShader = null;
		currentDepthDataCamShader = null;
		asSEngineSustain = null;
		asRShipCreak = null;
		droneAudioHolderGameObject = null;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (!pauseStatus)
		{
			EnablePixelRender();
			Transform transform = DroneCamera.gameObject.transform.Find("PixelDataCamera");
			if (transform != null)
			{
				transform.gameObject.SetActive(true);
			}
		}
	}

	public void SetUseHUDOverlayCamera(bool use)
	{
		if (use)
		{
			HUDCamera.cullingMask = 0;
			HUDCamera.gameObject.GetComponent<ScreenOverlay>().enabled = true;
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				HUDOverlayCamera.gameObject.SetActive(true);
			}
			HUDOverlayCamera.transform.parent = DroneCamera.transform;
			HUDOverlayCamera.transform.localPosition = Vector3.zero;
			isHUDOverlayCameraInUse = true;
		}
		else
		{
			HUDCamera.cullingMask = HUDOverlayCamera.cullingMask;
			HUDCamera.GetComponent<ScreenOverlay>().enabled = false;
			if (HUDOverlayCamera.gameObject.activeSelf)
			{
				HUDOverlayCamera.gameObject.SetActive(false);
			}
			isHUDOverlayCameraInUse = false;
		}
	}

	public void SetUseGlobalGlitchEffects(bool use)
	{
		if (use)
		{
			HUDCamera.GetComponent<HUDCameraController>().enabled = true;
			foreach (Drone drones in Instance.dronesList)
			{
				if (drones.IsDead && drones.CanBeTowed)
				{
					HUDCameraController.Instance.FireStaticOnDisabled(drones.DroneNumber);
				}
			}
			isGeneralGlitchEffectsInUse = true;
		}
		else
		{
			HUDCamera.GetComponent<Compression>().enabled = false;
			HUDCamera.GetComponent<Static>().enabled = false;
			HUDCamera.GetComponent<GlitchOffset>().enabled = false;
			HUDCamera.GetComponent<Degauss>().enabled = false;
			HUDCamera.GetComponent<HUDCameraController>().enabled = false;
			isGeneralGlitchEffectsInUse = false;
		}
	}

	public void SetQuality(QualityEnum quality)
	{
		currentQuality = quality;
		float num = 0.5625f;
		switch (SystemManager.AspectRatio)
		{
		case SystemManager.AspectRationEnum.ar16x10:
			num = 0.625f;
			break;
		case SystemManager.AspectRationEnum.ar3x2:
			num = 2f / 3f;
			break;
		case SystemManager.AspectRationEnum.ar4x3:
			num = 0.75f;
			break;
		case SystemManager.AspectRationEnum.ar5x4:
			num = 0.8f;
			break;
		case SystemManager.AspectRationEnum.ar21x9:
			num = 0.42857143f;
			break;
		}
		switch (quality)
		{
		case QualityEnum.HighOrDefault:
			lightRT = RenderTexture.GetTemporary(1024, (int)(1024f * num), 0, RenderTextureFormat.ARGB32);
			colorRT = RenderTexture.GetTemporary(1024, (int)(1024f * num), 0, RenderTextureFormat.ARGB32);
			depthRT = RenderTexture.GetTemporary(1024, (int)(1024f * num), 0, RenderTextureFormat.ARGB32);
			pixelRT = RenderTexture.GetTemporary(2048, 1280, 0, RenderTextureFormat.ARGB32);
			staticRT = RenderTexture.GetTemporary(4096, (int)(4096f * num), 0, RenderTextureFormat.ARGB32);
			break;
		case QualityEnum.Medium:
			lightRT = RenderTexture.GetTemporary(512, (int)(512f * num), 0, RenderTextureFormat.ARGB32);
			colorRT = RenderTexture.GetTemporary(512, (int)(512f * num), 0, RenderTextureFormat.ARGB32);
			depthRT = RenderTexture.GetTemporary(512, (int)(512f * num), 0, RenderTextureFormat.ARGB32);
			pixelRT = RenderTexture.GetTemporary(1024, 640, 0, RenderTextureFormat.ARGB32);
			staticRT = RenderTexture.GetTemporary(2048, (int)(2048f * num), 0, RenderTextureFormat.ARGB32);
			break;
		case QualityEnum.Low:
			lightRT = RenderTexture.GetTemporary(256, (int)(256f * num), 0, RenderTextureFormat.ARGB32);
			colorRT = RenderTexture.GetTemporary(256, (int)(256f * num), 0, RenderTextureFormat.ARGB32);
			depthRT = RenderTexture.GetTemporary(256, (int)(256f * num), 0, RenderTextureFormat.ARGB32);
			pixelRT = RenderTexture.GetTemporary(512, 320, 0, RenderTextureFormat.ARGB32);
			staticRT = RenderTexture.GetTemporary(1024, (int)(1024f * num), 0, RenderTextureFormat.ARGB32);
			break;
		}
		lightRT.name = "Light RT";
		colorRT.name = "Color RT";
		depthRT.name = "Depth RT";
		pixelRT.name = "Pixel RT";
		staticRT.name = "Static RT";
		foreach (Drone drones in Instance.dronesList)
		{
			drones.DVP.SetRenderTextures(lightRT, colorRT, depthRT, pixelRT);
		}
		if (HUDOverlayCamera != null)
		{
			HUDOverlayCamera.targetTexture = staticRT;
			HUDCamera.GetComponent<ScreenOverlay>().textureRT = staticRT;
		}
		EnablePixelRender();
		Transform transform = DroneCamera.gameObject.transform.Find("PixelDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(true);
		}
	}

	public void EnablePixelRender()
	{
		renderedAtLeastOnePixelData = false;
		if (!GlobalSettings.IsTutorial)
		{
			timerUntilDoneRenderPixels = 0.5f;
		}
		else
		{
			timerUntilDoneRenderPixels = 2f;
		}
	}

	public int GetDroneNumberFromName(string possibleName, out string actualName)
	{
		actualName = string.Empty;
		possibleName = possibleName.ToLower();
		int count = dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			if (possibleName[0] == dronesList[i].DroneNameLower[0] && dronesList[i].DroneNameLower.StartsWith(possibleName))
			{
				actualName = dronesList[i].DroneName;
				return dronesList[i].DroneNumber;
			}
		}
		return -1;
	}

	public void OnApplicationQuit()
	{
		if (DebugEnableCameraArray && tempRenderTextures != null)
		{
			int count = tempRenderTextures.Count;
			for (int i = 0; i < count; i++)
			{
				RenderTexture.ReleaseTemporary(tempRenderTextures[i]);
				tempRenderTextures[i] = null;
			}
		}
		CleanUpBeforeClose();
	}

	public void DropLight(Drone drone, Light sourceLight)
	{
		if (!EnableDelayBetweenLightDrops || !(timeTilNextStaleLightDrop > 0f))
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(sourceLight.gameObject, sourceLight.transform.position, sourceLight.transform.rotation);
			gameObject.GetComponent<Light>().color = Color.red;
			gameObject.name = "DataLight";
			StaleLightData staleLightData = new StaleLightData(gameObject, StaleDataLifetimeSeconds);
			if (sdLightArray.ContainsKey(drone) && sdLightArray[drone].Count > StaleDataMaxLightsPerDrone)
			{
				GameObject lightObj = sdLightArray[drone][0].lightObj;
				UnityEngine.Object.Destroy(lightObj);
				sdLightArray[drone].RemoveAt(0);
			}
			if (!sdLightArray.ContainsKey(drone))
			{
				sdLightArray.Add(drone, new List<StaleLightData>());
			}
			sdLightArray[drone].Add(staleLightData);
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				staleLightData.lightObj.SetActive(false);
			}
			if (EnableDelayBetweenLightDrops)
			{
				timeTilNextStaleLightDrop = DelayStaleDataLightMS / 1000f;
			}
		}
	}

	public void ClearCurrentDroneDroppedLights()
	{
		if (sdLightArray == null)
		{
			return;
		}
		Dictionary<Drone, List<StaleLightData>>.Enumerator enumerator = sdLightArray.GetEnumerator();
		while (enumerator.MoveNext())
		{
			foreach (StaleLightData item in enumerator.Current.Value)
			{
				UnityEngine.Object.Destroy(item.lightObj);
			}
			enumerator.Current.Value.Clear();
		}
	}

	public void SetLightArrayStatus(bool active)
	{
		Dictionary<Drone, List<StaleLightData>>.Enumerator enumerator = sdLightArray.GetEnumerator();
		while (enumerator.MoveNext())
		{
			int count = enumerator.Current.Value.Count;
			for (int i = 0; i < count; i++)
			{
				StaleLightData staleLightData = enumerator.Current.Value[i];
				if (staleLightData.lightObj.activeSelf != active)
				{
					staleLightData.lightObj.SetActive(active);
				}
			}
		}
	}

	public void SetSpotLightStatus(bool active)
	{
		foreach (GameObject playerDroneSpotlight in playerDroneSpotlights)
		{
			if (playerDroneSpotlight != null && playerDroneSpotlight.activeSelf != active)
			{
				playerDroneSpotlight.SetActive(active);
			}
		}
	}

	public void SetSpotlightColors(Color color)
	{
		foreach (GameObject playerDroneSpotlight in playerDroneSpotlights)
		{
			playerDroneSpotlight.GetComponent<Light>().color = color;
		}
	}

	private Waypoint GetDroneSpawnPoint(int droneNumber)
	{
		Waypoint waypoint = null;
		NavigationHelper.LoadAllWaypoints();
		switch (droneNumber)
		{
		case 1:
			return NavigationHelper.GetWaypoints(WaypointTypeEnum.DroneSpawn1).First();
		case 2:
			return NavigationHelper.GetWaypoints(WaypointTypeEnum.DroneSpawn2).First();
		case 3:
			return NavigationHelper.GetWaypoints(WaypointTypeEnum.DroneSpawn3).First();
		case 4:
			return NavigationHelper.GetWaypoints(WaypointTypeEnum.DroneSpawn4).First();
		default:
			Debug.LogWarning("Unknown drone number, giving default spawn location: " + droneNumber);
			return NavigationHelper.GetMainRoomWaypoint(DungeonManager.Instance.BoardingVessel);
		}
	}

	private Drone InstantiateFleetDrone(int droneNumber)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(DronePrefab);
		Drone drone = (Drone)gameObject.GetComponentInChildren(typeof(Drone));
		drone.DroneNumber = droneNumber;
		TextMesh textMesh = (TextMesh)gameObject.GetComponentInChildren(typeof(TextMesh));
		textMesh.text = droneNumber.ToString();
		GameObject gameObject2 = null;
		gameObject2 = ((!DebugUseTestSpotlight && !DebugUseCameraArraySpotlight) ? drone.transform.Find("Spotlight").gameObject : ((!DebugUseCameraArraySpotlight) ? drone.Swival.transform.Find("SpotlightTest").gameObject : drone.transform.Find("SpotlightTestCameraArray").gameObject));
		gameObject2.SetActive(true);
		if (playerDroneSpotlights == null)
		{
			playerDroneSpotlights = new List<GameObject>();
		}
		playerDroneSpotlights.Add(gameObject2);
		if (!DebugDisableDroneTopLight)
		{
			drone.transform.Find("DroneLight").gameObject.SetActive(true);
		}
		if (DebugEnableCameraArray)
		{
			Transform transform = drone.transform.parent.Find("SceneMirrorHigh");
			if (transform != null)
			{
				if (droneNumber != 1)
				{
					Transform transform2 = drone.transform.parent.Find("SceneMirrorHigh");
					if (transform2 != null)
					{
						UnityEngine.Object.Destroy(transform2.gameObject);
					}
				}
				else
				{
					transform.gameObject.SetActive(true);
				}
			}
			if (DebugEnableDualQuality)
			{
				transform = drone.transform.parent.Find("SceneMirrorLow");
				if (transform != null)
				{
					if (droneNumber != 1)
					{
						Transform transform3 = drone.transform.parent.Find("SceneMirrorLow");
						if (transform3 != null)
						{
							UnityEngine.Object.Destroy(transform3.gameObject);
						}
					}
					else
					{
						transform.gameObject.SetActive(true);
					}
				}
			}
		}
		if (!GlobalSettings.GameStartedFromGalaxyMap)
		{
			drone.engineType = (EngineTypeEnum)UnityEngine.Random.Range(0, 2);
		}
		dronesList.Add(drone);
		IDronesList.Add(drone);
		return drone;
	}

	private void PositionFleetDrones()
	{
		foreach (Drone item in _dronesThatJustDocked)
		{
			SpawnDrone(item);
		}
	}

	public void SpawnDrone(Drone drone)
	{
		Waypoint droneSpawnPoint = GetDroneSpawnPoint(drone.DroneNumber);
		drone.transform.parent.transform.position = new Vector3(droneSpawnPoint.transform.position.x, droneSpawnPoint.transform.position.y, 0f);
		if (drone.OverlayLabelObject != null)
		{
			drone.OverlayLabelObject.transform.parent = null;
		}
		drone.transform.rotation = Quaternion.AngleAxis(droneSpawnPoint.transform.rotation.eulerAngles.z, new Vector3(0f, 0f, 1f));
		if (drone.OverlayLabelObject != null)
		{
			drone.OverlayLabelObject.transform.parent = drone.dvOverlayTrans;
		}
	}

	private void SyncGlobalDronesToSceneDrones()
	{
		int count = GlobalSettings.GameState.ThePlayer.Drones.Count;
		for (int i = 0; i < count; i++)
		{
			IDrone drone = GlobalSettings.GameState.ThePlayer.Drones[i];
			Drone drone2 = GetDrone(drone.DroneNumber);
			if (drone2 == null)
			{
				continue;
			}
			drone2.RemoveAllUpgrades();
			drone2.OverrideCurrentHitpoints(drone.CurrentHitPoints);
			drone2.OverrideTotalHitpoints(drone.TotalHitpoints);
			if (!drone.IsDead && drone.CurrentHitPoints == 0f)
			{
				drone2.OverrideIsDead(true);
				drone2.CanBeTowed = true;
				drone2.IsDisabledButAlive = true;
				if (Instance.isGeneralGlitchEffectsInUse)
				{
					HUDCameraController.Instance.FireStaticOnDisabled(drone2.DroneNumber);
				}
			}
			else
			{
				drone2.OverrideIsDead(drone.IsDead);
				drone2.IsDisabledButAlive = false;
			}
			drone2.CanBeFullyRepaired = drone.CanBeFullyRepaired;
			drone2.OriginalSpeed = drone.OriginalSpeed;
			drone2.CurrentMaxSpeed = drone.OriginalSpeed;
			drone2.NumberOfUpgradeSlots = drone.NumberOfUpgradeSlots;
			drone2.TimeInMission = drone.TimeInMission;
			drone2.VideoSignalLost = drone.VideoSignalLost;
			drone2.TimeOfNextVideoLoss = drone.TimeOfNextVideoLoss;
			drone2.TimeOfNextVideoRestore = drone.TimeOfNextVideoRestore;
			drone2.TimeTilNextFailMin = drone.TimeTilNextFailMin;
			drone2.TimeTilNextFailMax = drone.TimeTilNextFailMax;
			drone2.VideoLossDuration = drone.VideoLossDuration;
			drone2.AppliedModifications = drone.AppliedModifications;
			drone2.InternalID = drone.InternalID;
			if (drone2.transform.parent != null)
			{
				drone2.transform.parent.name = string.Format("Drone {0} - {1} ParentObject", drone2.DroneNumber, drone2.DroneName);
			}
			drone2.DroneVisualIndex = drone.DroneVisualIndex;
			drone2.DVPSeed = drone.DVPSeed;
			drone2.DVPName = drone.DVPName;
			drone2.CSID = drone.CSID;
			drone2.TraitVeer = drone.TraitVeer;
			drone2.TraitPermVeer = drone.TraitPermVeer;
			drone2.TraitPitchOffset = drone.TraitPitchOffset;
			drone2.SetSelectedDroneVisual();
			drone2.engineType = drone.engineType;
			drone2.CurrentRoom = DungeonManager.Instance.BoardingVessel;
			int num = 0;
			int count2 = drone.Upgrades.Count;
			for (int j = 0; j < count2; j++)
			{
				BaseDroneUpgrade baseDroneUpgrade = drone.Upgrades[j];
				if (baseDroneUpgrade != null)
				{
					drone2.AddDroneUpgrade(num, baseDroneUpgrade);
				}
				num++;
			}
		}
	}

	public void ChoosePrevPreset()
	{
		currentPreset--;
		if (currentPreset < 0)
		{
			currentPreset = PresetManager.PresetList.Count - 1;
		}
		PresetManager.LoadPreset(currentPreset, IDronesList);
	}

	public void ChooseNextPreset()
	{
		currentPreset++;
		if (currentPreset >= PresetManager.PresetList.Count)
		{
			currentPreset = 0;
		}
		PresetManager.LoadPreset(currentPreset, IDronesList);
	}

	public void RandomlyChooseUpgrades()
	{
		System.Random rnd = new System.Random();
		RandomlyChooseUpgrades(LootableDronesList, 1, 2, false, true, rnd);
		RandomlyChooseUpgrades(dronesList, 1, 1, true, false, rnd);
	}

	public void RandomlyChooseUpgrades(List<Drone> dronesToProcess, int upgradeRandomMin, int upgradeRandomMax, bool needEssentials, bool randomAge, System.Random rnd)
	{
		UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		int count = dronesToProcess.Count;
		int count2 = dronesToProcess.Count;
		for (int i = 0; i < count2; i++)
		{
			dronesToProcess[i].RemoveAllUpgrades();
		}
		int num = rnd.Next(count * upgradeRandomMin, count * upgradeRandomMax + 1);
		if (needEssentials)
		{
			int num2 = 3;
			for (int j = 0; j < num2; j++)
			{
				DroneUpgradeType type = DroneUpgradeType.Undefined;
				switch (j)
				{
				case 0:
					type = DroneUpgradeType.Generator;
					break;
				case 1:
					type = DroneUpgradeType.Gatherer;
					break;
				case 2:
					type = DroneUpgradeType.Sensor;
					break;
				}
				int droneNumber = rnd.Next(1, dronesToProcess.Count + 1);
				Drone drone = GetDrone(droneNumber);
				if (drone != null)
				{
					drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(type));
				}
			}
			num -= num2;
		}
		UniverseSaveFile.BeginBatch();
		bool flag = false;
		if (GlobalSettings.gameMode == GameModeEnum.Normal && GameSaveFile.Get("RESETS", 0) < 1)
		{
			flag = true;
		}
		for (int k = 0; k < num; k++)
		{
			bool flag2 = true;
			int num3 = -1;
			DroneUpgradeType droneUpgradeType = DroneUpgradeType.Undefined;
			do
			{
				flag2 = true;
				int num4 = 0;
				int num5 = 0;
				do
				{
					if (num4 == 1)
					{
						int num6 = 0;
						num6++;
					}
					num5 = rnd.Next(1, 22);
					if (flag && num5 == 7)
					{
						num5 = 0;
					}
					num4++;
					if (num4 > 100)
					{
						Debug.LogError("Problem choosing Drone upgrade!");
						return;
					}
				}
				while (num5 == 0 || num5 == 11 || num5 == 3);
				droneUpgradeType = (DroneUpgradeType)num5;
				num4 = 0;
				do
				{
					num3 = rnd.Next(0, count);
					num4++;
					if (num4 > 100)
					{
						Debug.LogError("Problem with Drone Loop!");
						return;
					}
				}
				while (dronesToProcess[num3] == null || dronesToProcess[num3].Upgrades[3] != null || dronesToProcess[num3].NumberOfUpgradesInstalled() == 3);
				if (dronesToProcess[num3].NumberOfUpgradesInstalled() > 0)
				{
					int upgradeInstanceCount = dronesToProcess[num3].GetUpgradeInstanceCount(droneUpgradeType);
					if (upgradeInstanceCount > 0 && rnd.Next(0, upgradeInstanceCount * 2) != 0)
					{
						flag2 = false;
					}
				}
			}
			while (!flag2);
			BaseDroneUpgrade baseDroneUpgrade = DroneUpgradeFactory.CreateUpgradeInstance(droneUpgradeType);
			if (randomAge)
			{
				int num7 = (baseDroneUpgrade.NumMissions = rnd.Next(0, 5));
				if (num7 > 0)
				{
					for (int l = 0; l < num7; l++)
					{
						float num9 = rnd.NextFloat(3f, 6f);
						float num10 = baseDroneUpgrade.UpgradeBreakFactor * num9;
						baseDroneUpgrade.BreakProbability += num10;
					}
				}
			}
			dronesToProcess[num3].AddDroneUpgrade(baseDroneUpgrade);
		}
		UniverseSaveFile.EndBatch();
		for (int m = 0; m < count2; m++)
		{
			Drone drone2 = dronesToProcess[m];
			if (drone2.NumberOfUpgradesInstalled() != 0)
			{
				continue;
			}
			for (int num11 = drone2.NumberOfUpgradeSlots; num11 >= 2; num11--)
			{
				bool flag3 = false;
				int count3 = dronesToProcess.Count;
				for (int n = 0; n < count3; n++)
				{
					Drone drone3 = dronesToProcess[n];
					if (drone2.DroneNumber == drone3.DroneNumber)
					{
						continue;
					}
					int num12 = drone3.NumberOfUpgradesInstalled();
					if (num12 >= num11)
					{
						if (num12 == 1)
						{
							int num13 = 0;
							num13++;
						}
						BaseDroneUpgrade baseDroneUpgrade2 = drone3.PullLastUpgrade();
						if (baseDroneUpgrade2 != null)
						{
							drone2.AddDroneUpgrade(baseDroneUpgrade2);
							flag3 = true;
							break;
						}
					}
				}
				if (flag3)
				{
					break;
				}
			}
		}
	}

	public void RandomizeFleetUpgrades(int numberOfUpgradesToChange)
	{
		int num = 0;
		int num2 = Mathf.Max(numberOfUpgradesToChange + 10, 20);
		for (int i = 0; i < numberOfUpgradesToChange; i++)
		{
			num++;
			bool flag = false;
			int num3 = 0;
			int num4 = -1;
			Drone drone = null;
			do
			{
				flag = false;
				num3 = UnityEngine.Random.Range(1, dronesList.Count + 1);
				drone = GetDrone(num3);
				if (drone == null)
				{
					continue;
				}
				if (drone.NumberOfUpgradesInstalled() > 0)
				{
					bool flag2 = false;
					do
					{
						flag2 = false;
						BaseDroneUpgrade baseDroneUpgrade = null;
						do
						{
							num4 = UnityEngine.Random.Range(0, drone.NumberOfUpgradeSlots);
							baseDroneUpgrade = drone.Upgrades[num4];
						}
						while (baseDroneUpgrade == null);
						if (baseDroneUpgrade.Definition.Type == DroneUpgradeType.Generator || baseDroneUpgrade.Definition.Type == DroneUpgradeType.Gatherer || baseDroneUpgrade.Definition.Type == DroneUpgradeType.Sensor)
						{
							foreach (Drone drones in dronesList)
							{
								int num5 = -1;
								foreach (BaseDroneUpgrade upgrade in drones.Upgrades)
								{
									num5++;
									if (upgrade != null && (drones.DroneNumber != drone.DroneNumber || num5 != num4) && upgrade.Definition.Type == baseDroneUpgrade.Definition.Type)
									{
										flag2 = true;
										break;
									}
								}
								if (flag2)
								{
									break;
								}
							}
							if (!flag2)
							{
								break;
							}
						}
						else
						{
							flag2 = true;
						}
						if (!flag2)
						{
							continue;
						}
						bool flag3 = false;
						DroneUpgradeType droneUpgradeType = DroneUpgradeType.NumberOfUpgrades;
						do
						{
							int num6 = UnityEngine.Random.Range(1, 22);
							droneUpgradeType = (DroneUpgradeType)num6;
							if (droneUpgradeType != baseDroneUpgrade.Definition.Type)
							{
								flag3 = true;
							}
							if (drone.NumberOfUpgradesInstalled() > 0)
							{
								int upgradeInstanceCount = drone.GetUpgradeInstanceCount(droneUpgradeType);
								if (upgradeInstanceCount > 0 && UnityEngine.Random.Range(0, upgradeInstanceCount * 2) != 0)
								{
									flag3 = false;
								}
							}
						}
						while (!flag3);
						drone.AddDroneUpgrade(num4, DroneUpgradeFactory.CreateUpgradeInstance(droneUpgradeType));
						flag = true;
					}
					while (!flag2 || !flag);
				}
				if (num > num2)
				{
					Debug.LogError("RandomizeFleetUpgrades() failsafe kicked in.  Likely too many upgrades choosen to be replaced.  In any event, the game can safely continue inspite of this error.");
					break;
				}
			}
			while (!flag);
		}
	}

	public void RandomlyPlaceLootableDrones()
	{
		int num = 5;
		int seed = (int)DateTime.Now.Ticks;
		if (SeedLootableDrones != -1)
		{
			seed = SeedLootableDrones;
		}
		rndLootableDrones = new System.Random(seed);
		if (corridorBoundsList == null)
		{
			corridorBoundsList = new List<Bounds>();
			int num2 = DungeonManager.Instance.corridors.Length;
			for (int i = 0; i < num2; i++)
			{
				Corridor corridor = DungeonManager.Instance.corridors[i];
				if (corridor != null)
				{
					Bounds bounds = corridor.GetComponent<Collider>().bounds;
					float angle = 0f;
					Vector3 axis = Vector3.zero;
					Vector3 zero = Vector3.zero;
					corridor.transform.rotation.ToAngleAxis(out angle, out axis);
					zero = new Vector3(2f, 2f, 0f);
					bounds.Expand(zero);
					corridorBoundsList.Add(bounds);
				}
			}
		}
		List<Room> list = new List<Room>();
		float num3 = float.MinValue;
		int num4 = DungeonManager.Instance.rooms.Length;
		for (int j = 0; j < num4; j++)
		{
			Room room = DungeonManager.Instance.rooms[j];
			if (room.boardingVessel)
			{
				continue;
			}
			bool flag = true;
			if (!GameSaveFile.Get("D_BLKDRONE", true) && (room.transform.localScale.x <= 2f || room.transform.localScale.y <= 2f))
			{
				flag = false;
			}
			if (flag)
			{
				int count = room.corridors.Count;
				for (int k = 0; k < count; k++)
				{
					Corridor corridor2 = room.corridors[k];
					Room otherRoom = corridor2.getOtherRoom(room);
					if (otherRoom != null && otherRoom.boardingVessel)
					{
						if (room.transform.localScale.x <= 2f || room.transform.localScale.y <= 2f)
						{
							flag = false;
						}
						break;
					}
				}
			}
			if (flag)
			{
				list.Add(room);
				if (room.GetComponent<Collider>().bounds.size.magnitude > num3)
				{
					num3 = room.GetComponent<Collider>().bounds.size.magnitude;
				}
			}
		}
		int num5 = 0;
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasDrone)
		{
			int num6 = DungeonManager.Instance.rooms.Length;
			num5 = rndLootableDrones.Next((int)((float)num6 * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneRatioMin), (int)((float)num6 * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneRatioMax));
			if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasDroneQty)
			{
				if (num5 < GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneQtyMin)
				{
					num5 = GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneQtyMin;
				}
				else if (num5 > GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneQtyMax)
				{
					num5 = GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneQtyMax;
				}
			}
		}
		else
		{
			num5 = rndLootableDrones.Next(0, 3);
		}
		for (int l = 0; l < num5; l++)
		{
			int num7 = -1;
			bool flag2 = false;
			do
			{
				num7 = rndLootableDrones.Next(0, list.Count());
				int maxValue = (int)((float)DungeonManager.Instance.lootLargeRoomBias * (1f - list[num7].GetComponent<Collider>().bounds.size.magnitude / num3));
				if (rndLootableDrones.Next(0, maxValue) == 0)
				{
					flag2 = true;
				}
			}
			while (!flag2);
			Room room2 = list[num7];
			Rect rect = new Rect(room2.transform.position.x - room2.transform.localScale.x / 2f, room2.transform.position.y - room2.transform.localScale.y / 2f, room2.transform.localScale.x, room2.transform.localScale.y);
			rect.x += DronePrefab.transform.localScale.x / 2f;
			rect.y += DronePrefab.transform.localScale.y / 2f;
			rect.width -= DronePrefab.transform.localScale.x;
			rect.height -= DronePrefab.transform.localScale.y;
			bool flag3 = false;
			int num8 = 0;
			List<Drone> list2 = null;
			int count2 = LootableDronesList.Count;
			for (int m = 0; m < count2; m++)
			{
				Drone drone = LootableDronesList[m];
				if (drone != null && drone.CurrentRoom == room2)
				{
					if (list2 == null)
					{
						list2 = new List<Drone>();
					}
					list2.Add(drone);
				}
			}
			List<Bounds> list3 = null;
			if (list2 != null)
			{
				int count3 = list2.Count;
				for (int n = 0; n < count3; n++)
				{
					Drone drone2 = list2[n];
					if (list3 == null)
					{
						list3 = new List<Bounds>();
					}
					list3.Add(drone2.droneViewModel.GetComponent<Collider>().bounds);
				}
			}
			Vector3 vector;
			do
			{
				float num9 = rndLootableDrones.NextFloat(0f, 1f);
				float num10 = rndLootableDrones.NextFloat(0f, 1f);
				vector = new Vector3(rect.x + rect.width * num9, rect.y + rect.height * num10, 0f);
				Bounds bounds2 = new Bounds(vector, DronePrefab.transform.localScale);
				bounds2.Expand(0.1f);
				num8++;
				flag3 = !room2.RoomItemsBoundsHit(bounds2, null, null);
				if (flag3)
				{
					int count4 = corridorBoundsList.Count;
					for (int num11 = 0; num11 < count4; num11++)
					{
						if (corridorBoundsList[num11].Intersects(bounds2))
						{
							flag3 = false;
							break;
						}
					}
				}
				if (!flag3 || list3 == null)
				{
					continue;
				}
				int count5 = list3.Count;
				for (int num12 = 0; num12 < count5; num12++)
				{
					if (list3[num12].Intersects(bounds2))
					{
						flag3 = false;
						break;
					}
				}
			}
			while (num8 < 50 && !flag3);
			if (flag3)
			{
				PlaceLootableDrone(num++, room2, vector);
			}
			else
			{
				Debug.LogWarning("Error placing new drone");
			}
		}
		RandomlyChooseUpgrades(LootableDronesList, 1, 2, false, true, rndLootableDrones);
	}

	public void PlaceLootableDroneInRoom(Room room, ref int droneNumberNext, bool isRepairable)
	{
		List<Bounds> list = new List<Bounds>();
		int num = DungeonManager.Instance.corridors.Length;
		for (int i = 0; i < num; i++)
		{
			Corridor corridor = DungeonManager.Instance.corridors[i];
			if (corridor != null)
			{
				Bounds bounds = corridor.GetComponent<Collider>().bounds;
				float angle = 0f;
				Vector3 axis = Vector3.zero;
				Vector3 zero = Vector3.zero;
				corridor.transform.rotation.ToAngleAxis(out angle, out axis);
				zero = new Vector3(2f, 2f, 0f);
				bounds.Expand(zero);
				list.Add(bounds);
			}
		}
		num = LootableDronesList.Count;
		for (int j = 0; j < num; j++)
		{
			Drone drone = LootableDronesList[j];
			if (drone != null && drone.CurrentRoom == room)
			{
				list.Add(drone.droneViewModel.GetComponent<Collider>().bounds);
			}
		}
		Rect rect = new Rect(room.transform.position.x - room.transform.localScale.x / 2f, room.transform.position.y - room.transform.localScale.y / 2f, room.transform.localScale.x, room.transform.localScale.y);
		rect.x += DronePrefab.transform.localScale.x / 2f;
		rect.y += DronePrefab.transform.localScale.y / 2f;
		rect.width -= DronePrefab.transform.localScale.x;
		rect.height -= DronePrefab.transform.localScale.y;
		bool flag = false;
		int num2 = 0;
		Vector3 vector;
		do
		{
			float value = UnityEngine.Random.value;
			float value2 = UnityEngine.Random.value;
			vector = new Vector3(rect.x + rect.width * value, rect.y + rect.height * value2, 0f);
			Bounds bounds2 = new Bounds(vector, DronePrefab.transform.localScale);
			bounds2.Expand(0.1f);
			num2++;
			flag = !room.RoomItemsBoundsHit(bounds2, null, null);
			if (!flag)
			{
				continue;
			}
			foreach (Bounds item in list)
			{
				if (item.Intersects(bounds2))
				{
					flag = false;
					break;
				}
			}
		}
		while (num2 < 50 && !flag);
		if (flag)
		{
			PlaceLootableDrone(droneNumberNext++, room, vector, true, isRepairable);
		}
		else
		{
			Debug.LogWarning("Error placing new drone");
		}
		System.Random rnd = new System.Random();
		RandomlyChooseUpgrades(LootableDronesList, 1, 2, false, true, rnd);
	}

	public void PlaceLootableDrone(int droneNumber, Room curRoom, Vector3 position)
	{
		PlaceLootableDrone(droneNumber, curRoom, position, false, false);
	}

	public void PlaceLootableDrone(int droneNumber, Room curRoom, Vector3 position, bool explictlySetStatus, bool isRepairable)
	{
		if (rndLootableDrones == null)
		{
			rndLootableDrones = new System.Random();
		}
		Drone drone = InstantiateLootableDrone(position, Quaternion.identity);
		DroneCharacteristics.Assign(drone, false, null, rndLootableDrones);
		drone.SetSelectedDroneVisual();
		drone.CurrentMaxSpeed = drone.OriginalSpeed;
		if (!GlobalSettings.IsTutorial && rndLootableDrones.Next(0, 100) < 10)
		{
			if (rndLootableDrones.Next(0, 2) == 0)
			{
				drone.NumberOfUpgradeSlots = 2;
			}
			else
			{
				drone.NumberOfUpgradeSlots = 4;
			}
		}
		else
		{
			drone.NumberOfUpgradeSlots = 3;
		}
		drone.engineType = (EngineTypeEnum)rndLootableDrones.Next(0, 2);
		drone.CurrentRoom = curRoom;
		drone.CSID = rndLootableDrones.Next(0, 13);
		if (rndLootableDrones.Next(0, 100) < 0)
		{
			float num = rndLootableDrones.NextFloat(0.5f, 3f);
			if (rndLootableDrones.Next(0, 2) == 0)
			{
				num = -1f * num;
			}
			drone.TraitVeer = num;
		}
		drone.InterfaceDisconnected = true;
		drone.SetDroneNumber(droneNumber);
		if (!explictlySetStatus)
		{
			drone.Kill(rndLootableDrones);
		}
		else
		{
			drone.Kill(isRepairable, true);
		}
		LootableDronesList.Add(drone);
		drone.transform.Rotate(Vector3.forward, rndLootableDrones.NextFloat(-360f, 360f));
	}

	public void ForgetDrone(Drone drone)
	{
		haveDronesToRemove = true;
		dronesToRemoveList.Add(drone);
	}

	public void HideDrone(ref Drone drone)
	{
		drone.IsVisible = false;
	}

	public void ShowDrone(ref Drone drone)
	{
		if (drone.DungeonLeftIn == null)
		{
			drone.IsVisible = true;
			if (drone.IsVisible && !DebugDisableDroneTopLight)
			{
				drone.transform.Find("DroneLight").gameObject.SetActive(true);
			}
		}
	}

	public void positionDroneCamera()
	{
		if (CurrentDrone.transform.parent != null)
		{
			DroneCamera.transform.parent = CurrentDrone.transform.parent;
		}
		else
		{
			DroneCamera.transform.parent = CurrentDrone.transform;
		}
		DroneCamera.transform.localPosition = new Vector3(0f, 0f, -6f);
	}

	private void Update()
	{
		if (startupOnSchematicView)
		{
			switchCameraView();
			startupOnSchematicView = false;
			return;
		}
		if (!GlobalSettings.IsGamePaused && (DialogUI.Instance == null || !DialogUI.Instance.IsShowing) && (AliasUI.Instance == null || !AliasUI.Instance.IsShowing))
		{
			if (previousFullScreen != Screen.fullScreen)
			{
				previousFullScreen = Screen.fullScreen;
				if (Instance != null)
				{
					Instance.SetQuality((QualityEnum)GameSaveFile.Get("P_QG", 0));
				}
				EnablePixelRender();
				HintManager.OnScreenPosition = HintManager.HintPanelGameObject.transform.position;
				HintManager.OffScreenPosition = new Vector3(HintManager.OnScreenPosition.x + 900f, HintManager.OnScreenPosition.y);
				Transform transform = DroneCamera.gameObject.transform.Find("PixelDataCamera");
				if (transform != null)
				{
					transform.gameObject.SetActive(true);
				}
			}
			if (CurrentDrone != null)
			{
				if (CurrentDrone.transform.position != currentDronePositionLast && isShowingHintOverlay && currentHintOverlayState == HintOverlayStateEnum.HoldingOverlayUntilDone)
				{
					delayHintStates = 0f;
				}
				if (CurrentDrone.DVP != null)
				{
					CurrentDrone.DVP.Update();
				}
			}
			if (haveDronesToRemove)
			{
				Drone drone;
				foreach (Drone dronesToRemove in dronesToRemoveList)
				{
					drone = dronesToRemove;
					if (LootableDronesList.Contains(drone))
					{
						LootableDronesList.Remove(drone);
					}
					else if (dronesList.Contains(drone))
					{
						dronesList.Remove(drone);
						IDrone drone2 = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.DroneNumber == drone.DroneNumber);
						if (drone2 != null)
						{
							GlobalSettings.GameState.ThePlayer.Drones.Remove(drone2);
							UniverseSaveFile.ClearGroup(string.Format("DRONE_{0}", drone2.InternalID));
						}
						if (dronesList.Any((Drone x) => x != null && x.DroneNumber == _curDroneNumber))
						{
						}
					}
				}
				haveDronesToRemove = false;
				dronesToRemoveList.Clear();
			}
			if (!GlobalSettings.ShowingGameOverlayWindow && !GPManager.CommandBeingTyped && Input.GetKeyDown(KeyCode.Tab))
			{
				int num = 50;
				do
				{
					_curDroneNumber++;
					if (_curDroneNumber > 4)
					{
						_curDroneNumber = 1;
					}
				}
				while (!SetDroneNumber(_curDroneNumber) && --num > 0);
			}
			int num2 = 0;
			if (Input.GetButtonDown("Drone 1"))
			{
				num2 = 1;
			}
			if (Input.GetButtonDown("Drone 2"))
			{
				num2 = 2;
			}
			if (Input.GetButtonDown("Drone 3"))
			{
				num2 = 3;
			}
			if (Input.GetButtonDown("Drone 4"))
			{
				num2 = 4;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				num2 = 5;
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				num2 = 6;
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				num2 = 7;
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				num2 = 8;
			}
			if (num2 > 0 && !GlobalSettings.ShowingGameOverlayWindow && !GPManager.CommandBeingTyped && !swapUIShown && GPManager.WindowState != GameWindowStates.ShowHelpManual)
			{
				Drone drone3 = GetDrone(num2);
				bool msgFailedDisplayed = false;
				if (drone3 == null)
				{
					SendConsoleMessage("No such drone: " + num2, ConsoleMessageType.Error);
				}
				else if (SetDroneNumber(num2, out msgFailedDisplayed))
				{
					if (GlobalSettings.cameraMode == CameraMode.Schematic && !GlobalSettings.CommandeeringShip && !GlobalSettings.GameIsOver && !DungeonManager.Instance.IsExiting)
					{
						switchCameraView();
						if (!CurrentDrone.VideoSignalLost && !HUDCamera.gameObject.activeSelf)
						{
							HUDCamera.gameObject.SetActive(true);
							if (isHUDOverlayCameraInUse)
							{
								HUDOverlayCamera.gameObject.SetActive(true);
							}
						}
					}
				}
				else if (!msgFailedDisplayed)
				{
					SendConsoleMessage("Drone " + num2 + " isn't responding...", ConsoleMessageType.Warning);
				}
			}
			if (CurrentDrone != null && (GlobalSettings.cameraMode == CameraMode.Drone || GlobalSettings.cheatMode) && !CurrentDrone.IsUnderShipControl && !CurrentDrone.IsStunned && !GlobalSettings.ShowingGameOverlayWindow && CurrentDrone.isMovingForwardBack && swapUIShown && CurrentDrone.IsBeingSwapped && !CurrentDrone.IsBraking)
			{
				HideUpgradeSwapUI();
			}
			_droneSvRefreshTimer -= Time.deltaTime;
			if (_droneSvRefreshTimer <= 0f)
			{
				_droneSvRefreshTimer = 0.2f;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					dronesList.ForEach(delegate(Drone x)
					{
						x.ReconnectSvVisuals();
					});
					LootableDronesList.ForEach(delegate(Drone x)
					{
						x.ReconnectSvVisuals();
					});
					ReconnectAllProbesSv();
					dronesList.ForEach(delegate(Drone x)
					{
						x.DisconnectSvVisuals();
					});
					LootableDronesList.ForEach(delegate(Drone x)
					{
						x.DisconnectSvVisuals();
					});
					DisconnectAllProbesSv();
				}
			}
			if (EnableStaleData)
			{
				Dictionary<Drone, List<StaleLightData>>.Enumerator enumerator2 = sdLightArray.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					if ((!EnableStaleDataLossWhenNotMoving && (!enumerator2.Current.Key.isMoving || enumerator2.Current.Key.isPumpingFuel || enumerator2.Current.Key.IsBraking)) || enumerator2.Current.Value.Count <= 0)
					{
						continue;
					}
					int count = enumerator2.Current.Value.Count;
					for (int num3 = count - 1; num3 >= 0; num3--)
					{
						enumerator2.Current.Value[num3].lifetime -= Time.deltaTime;
						if (enumerator2.Current.Value[num3].lifetime <= 0f)
						{
							UnityEngine.Object.Destroy(enumerator2.Current.Value[num3].lightObj);
							enumerator2.Current.Value.RemoveAt(num3);
						}
					}
				}
				if (EnableDelayBetweenLightDrops)
				{
					timeTilNextStaleLightDrop -= Time.deltaTime;
					if (timeTilNextStaleLightDrop < 0f)
					{
						timeTilNextStaleLightDrop = 0f;
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.X))
			{
				ToggleCheatMode();
			}
			if (GlobalSettings.cheatMode && LightDataCameraObject != null && !Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Home))
			{
				LightDataCameraObject.GetComponent<Camera>().aspect = 1f;
			}
			if (DebugEnableCameraArray && boundingTreeList != null && CurrentDrone.Position != lastCurrentDronePosition && Vector3.Distance(CurrentDrone.Position, lastCurrentDronePosition) > 1f)
			{
				Dictionary<Collider, List<GameObject>>.Enumerator enumerator3 = boundingTreeList.GetEnumerator();
				List<GameObject> list = new List<GameObject>();
				while (enumerator3.MoveNext())
				{
					if (!enumerator3.Current.Key.bounds.Intersects(Instance.CurrentDrone.GetComponent<Collider>().bounds))
					{
						continue;
					}
					foreach (GameObject item in enumerator3.Current.Value)
					{
						if (list.Contains(item))
						{
							continue;
						}
						list.Add(item);
						if (!(item.GetComponent<Collider>() != null))
						{
							continue;
						}
						if (item.GetComponent<Collider>().bounds.Intersects(Instance.CurrentDrone.GetComponent<Collider>().bounds))
						{
							if (item.GetComponent<Camera>().enabled)
							{
								continue;
							}
							item.GetComponent<Camera>().enabled = true;
							foreach (Transform item2 in item.transform)
							{
								if (DebugEnableCameraArrayLight || item2.name != "LightDataReaderCamera")
								{
									item2.gameObject.SetActive(true);
								}
							}
						}
						else
						{
							if (!item.GetComponent<Camera>().enabled)
							{
								continue;
							}
							item.GetComponent<Camera>().enabled = false;
							foreach (Transform item3 in item.transform)
							{
								if (DebugEnableCameraArrayLight || item3.name != "LightDataReaderCamera")
								{
									item3.gameObject.SetActive(false);
								}
							}
						}
					}
				}
				lastCurrentDronePosition = CurrentDrone.Position;
			}
			if (isShowingHintOverlay)
			{
				UpdateHintFade();
			}
			if (CurrentDrone != null)
			{
				currentDronePositionLast = CurrentDrone.transform.position;
			}
			if (!renderedAtLeastOnePixelData && GlobalSettings.cameraMode == CameraMode.Drone)
			{
				timerUntilDoneRenderPixels -= Time.deltaTime;
				if (timerUntilDoneRenderPixels <= 0f)
				{
					renderedAtLeastOnePixelData = true;
					Transform transform4 = DroneCamera.gameObject.transform.Find("PixelDataCamera");
					if (transform4 != null)
					{
						transform4.gameObject.SetActive(false);
					}
				}
			}
		}
		if (!(currentDronePanel != null))
		{
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && ShowDroneWindow && !GlobalSettings.ShowingGameOverlayWindow && CurrentDrone != null)
		{
			if (!currentDronePanel.IsVisible && !GameplayManager.Instance.isHidingCanvases)
			{
				currentDronePanel.IsVisible = true;
			}
		}
		else if (currentDronePanel.IsVisible)
		{
			currentDronePanel.IsVisible = false;
		}
	}

	private void ReconnectAllProbesSv()
	{
		List<DropableItem> value;
		if (DroneItemDropper.DroppedItemDict.Count > 0 && DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Probe, out value))
		{
			int count = value.Count;
			for (int i = 0; i < count; i++)
			{
				DropableItem dropableItem = value[i];
				ProbeItem probeItem = (ProbeItem)dropableItem;
				probeItem.ReconnectSvVisuals();
			}
		}
	}

	private void DisconnectAllProbesSv()
	{
		List<DropableItem> value;
		if (DroneItemDropper.DroppedItemDict.Count > 0 && DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Probe, out value))
		{
			int count = value.Count;
			for (int i = 0; i < count; i++)
			{
				DropableItem dropableItem = value[i];
				ProbeItem probeItem = (ProbeItem)dropableItem;
				probeItem.DisconnectSvVisuals();
			}
		}
	}

	private void UpdateHintFade()
	{
		delayHintStates -= Time.deltaTime;
		switch (currentHintOverlayState)
		{
		case HintOverlayStateEnum.PulsingOverlay:
		{
			if (DVOverlayLineObjects == null || DVOverlayLineObjects.Length == 0)
			{
				break;
			}
			Color color2 = DVOverlayLineObjects[0].GetComponent<UILineRendererV2>().color;
			float a2 = delayHintStates / 0.25f;
			color2.a = a2;
			if (fadingIn)
			{
				color2.a = 1f - color2.a;
			}
			GameObject[] dVOverlayLineObjects2 = DVOverlayLineObjects;
			foreach (GameObject gameObject2 in dVOverlayLineObjects2)
			{
				gameObject2.GetComponent<UILineRendererV2>().color = color2;
			}
			if (!(delayHintStates <= 0f))
			{
				break;
			}
			if (fadingIn)
			{
				pulseCount++;
				if (pulseCount >= 5)
				{
					currentHintOverlayState = HintOverlayStateEnum.HoldingOverlayAfterPulse;
					delayHintStates = 1f;
					break;
				}
			}
			fadingIn = !fadingIn;
			delayHintStates = 0.25f;
			break;
		}
		case HintOverlayStateEnum.HoldingOverlayAfterPulse:
			if (delayHintStates <= 0f)
			{
				currentHintOverlayState = HintOverlayStateEnum.HoldingOverlayUntilDone;
				delayHintStates = 10f;
			}
			break;
		case HintOverlayStateEnum.HoldingOverlayUntilDone:
			if (delayHintStates <= 0f)
			{
				currentHintOverlayState = HintOverlayStateEnum.FadeOutToDone;
				delayHintStates = 0.4f;
				fadingIn = false;
			}
			break;
		case HintOverlayStateEnum.FadeOutToDone:
		{
			Color color = DVOverlayLineObjects[0].GetComponent<UILineRendererV2>().color;
			float a = delayHintStates / 0.4f;
			color.a = a;
			if (fadingIn)
			{
				color.a = 1f - color.a;
			}
			GameObject[] dVOverlayLineObjects = DVOverlayLineObjects;
			foreach (GameObject gameObject in dVOverlayLineObjects)
			{
				gameObject.GetComponent<UILineRendererV2>().color = color;
			}
			if (delayHintStates <= 0f)
			{
				DisableUpgradeHintLines();
			}
			break;
		}
		}
	}

	private void ToggleCheatMode()
	{
		if (!(ConfigFile.GetSetting("AllowCheating").ToLower() == "yes"))
		{
			return;
		}
		GlobalSettings.cheatMode = !GlobalSettings.cheatMode;
		if (GlobalSettings.cheatMode)
		{
			GameplayManager.Instance.InitCheatModeUI();
			GameplayManager.Instance.SyncCheatModeUI();
			GameplayManagerGUI.Instance.Enable();
			Resources.UnloadUnusedAssets();
		}
		else
		{
			GameplayManagerGUI.Instance.Disable();
		}
		Room[] rooms = DungeonManager.Instance.rooms;
		foreach (Room room in rooms)
		{
			foreach (RoomItem roomItem in room.roomItems)
			{
				if (roomItem is SwamSpawnVent)
				{
					roomItem.Show = true;
				}
			}
		}
		DungeonManager.Instance.UpdateCameraView();
		if (GlobalSettings.cheatMode)
		{
			foreach (Drone lootableDrones in LootableDronesList)
			{
				Drone drone = lootableDrones;
				ShowDrone(ref drone);
			}
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				Room[] rooms2 = DungeonManager.Instance.rooms;
				foreach (Room room2 in rooms2)
				{
					room2.ShowRegisteredEnimies();
				}
			}
		}
		else
		{
			foreach (Drone lootableDrones2 in LootableDronesList)
			{
				if (lootableDrones2.IsVisible && lootableDrones2.InterfaceDisconnected && lootableDrones2.CurrentRoom != null && !lootableDrones2.CurrentRoom.isPowered)
				{
					Drone drone2 = lootableDrones2;
					HideDrone(ref drone2);
				}
			}
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				Room[] rooms3 = DungeonManager.Instance.rooms;
				foreach (Room room3 in rooms3)
				{
					room3.HideRegisteredEnimies();
				}
			}
		}
		if (!DebugEnableCameraArray && !DebugEnableCameraArrayLight)
		{
			UpdateCameraView();
		}
		if (GlobalSettings.cheatMode)
		{
			SendConsoleMessage("Cheat Mode Enabled", ConsoleMessageType.Info);
		}
		else
		{
			SendConsoleMessage("Cheat Mode Disabled", ConsoleMessageType.Info);
		}
	}

	private bool DroneHasTurretUpgrade(Drone drone)
	{
		return drone.HasUpgrade(DroneUpgradeType.SwarmTurret) || drone.HasUpgrade(DroneUpgradeType.BruteTurret);
	}

	public void CalcDroneCurrentRoom(Drone drone)
	{
		if (drone.CurrentRoom != null && drone.CurrentRoom.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds))
		{
			return;
		}
		bool flag = drone.CurrentRoom != null;
		Room room = null;
		Room[] rooms = DungeonManager.Instance.rooms;
		foreach (Room room2 in rooms)
		{
			if (room2.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds))
			{
				room = room2;
				break;
			}
		}
		drone.CurrentRoom = room;
		if (GlobalSettings.MissionStarted)
		{
			if (room != null)
			{
				room.DroneEnteredRoom();
				drone.StartShake();
			}
			else if (flag)
			{
				drone.StartShake();
			}
		}
	}

	public void CalcDroneCurrentCorridor(Drone drone)
	{
		if (drone.CurrentCorridor != null && drone.CurrentCorridor.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds))
		{
			return;
		}
		Corridor currentCorridor = null;
		Corridor[] corridors = DungeonManager.Instance.corridors;
		foreach (Corridor corridor in corridors)
		{
			if (corridor.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds))
			{
				currentCorridor = corridor;
				break;
			}
		}
		drone.CurrentCorridor = currentCorridor;
	}

	private bool CollidesWithCorridor(Drone drone, Corridor corridor)
	{
		return corridor.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds) || corridor.door.sliderA.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds) || corridor.door.sliderB.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds);
	}

	public static string GetDroneUpgradeText(BaseDroneUpgrade upgrade)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (upgrade.BreakProbability > 25f)
		{
			stringBuilder.AppendFormat("!! {0}", upgrade.Name);
		}
		else if (upgrade.BreakProbability > 15f)
		{
			stringBuilder.AppendFormat("! {0}", upgrade.Name);
		}
		else
		{
			stringBuilder.AppendFormat("{0}", upgrade.Name);
		}
		if (!string.IsNullOrEmpty(upgrade.ModIndicator))
		{
			stringBuilder.AppendFormat(" <color=#9ae2ff>{0}</color>", upgrade.ModIndicator);
		}
		if (upgrade is IStorageUpgrade)
		{
			IStorageUpgrade storageUpgrade = (IStorageUpgrade)upgrade;
			if (storageUpgrade.Capacity > 0)
			{
				stringBuilder.AppendFormat(" ({0}/{1}) ", storageUpgrade.Quantity, storageUpgrade.Capacity);
			}
		}
		else if (upgrade is IDamagableObject)
		{
			IDamagableObject damagableObject = (IDamagableObject)upgrade;
			if (damagableObject.TotalHitpoints > 0f)
			{
				stringBuilder.AppendFormat(" ({0}) ", Math.Round(damagableObject.CurrentHitPoints, 0));
			}
		}
		else if (upgrade is IPoweredObject)
		{
			IPoweredObject poweredObject = (IPoweredObject)upgrade;
			if (poweredObject.TotalPower > 0f)
			{
				stringBuilder.AppendFormat(" ({0}{1}) ", Math.Round(poweredObject.CurrentPower, 0), (!poweredObject.ShowPercentage) ? string.Empty : "%");
			}
		}
		return stringBuilder.ToString();
	}

	public static string GetShipUpgradeText(BaseShipUpgrade upgrade)
	{
		string text = ((upgrade.BreakProbability > 25f) ? string.Format("!! {0}", upgrade.Name) : ((!(upgrade.BreakProbability > 15f)) ? string.Format("{0}", upgrade.Name) : string.Format("! {0}", upgrade.Name)));
		if (upgrade is IStorageUpgrade)
		{
			IStorageUpgrade storageUpgrade = (IStorageUpgrade)upgrade;
			if (storageUpgrade.Capacity > 0)
			{
				string text2 = text;
				text = text2 + " (" + storageUpgrade.Quantity + "/" + storageUpgrade.Capacity + ") ";
			}
		}
		string upgradeIndicators = ModificationsHelper.GetUpgradeIndicators(upgrade.AppliedModifications);
		if (!string.IsNullOrEmpty(upgradeIndicators))
		{
			text += string.Format(" <color=#9ae2ff>{0}</color>", upgradeIndicators);
		}
		return text;
	}

	public static Color GetDroneUpgradeStatusColor(BaseDroneUpgrade upgrade, IDrone drone)
	{
		Color result = Color.white;
		if (upgrade != null)
		{
			if (upgrade.IsBlinking && GlobalSettings.cameraMode == CameraMode.Drone)
			{
				return upgrade.BlinkingColor;
			}
			if (drone.IsDead)
			{
				result = ((upgrade.BrokenState == BrokenStateEnum.Broken) ? Color.Lerp(Color.red, Color.gray, 0.7f) : ((upgrade.BrokenState != BrokenStateEnum.ErrorsDetected) ? Color.gray : Color.Lerp(Color.yellow, Color.gray, 0.7f)));
			}
			else
			{
				bool flag = false;
				if (upgrade.BrokenState == BrokenStateEnum.OK && upgrade is IPoweredObject)
				{
					IPoweredObject poweredObject = (IPoweredObject)upgrade;
					if (poweredObject.TotalPower > 0f && (poweredObject.CurrentPower <= 0f || poweredObject.IsCharging))
					{
						flag = true;
						result = (poweredObject.IsCharging ? Color.cyan : Color.Lerp(Color.cyan, Color.gray, 0.7f));
					}
				}
				if (!flag)
				{
					result = GetBasicUpgradeStatusColor(upgrade);
				}
			}
		}
		else if (drone.IsDead)
		{
			result = Color.gray;
		}
		return result;
	}

	public static Color GetBasicUpgradeStatusColor(BaseDroneUpgrade upgrade)
	{
		Color result = Color.white;
		if (upgrade != null)
		{
			if (upgrade.PoweredUp && upgrade.IsActivated)
			{
				result = Color.green;
			}
			else if (upgrade.BrokenState == BrokenStateEnum.Broken)
			{
				result = UpgradeColorError;
			}
			else if (upgrade.BreakProbability > 25f)
			{
				result = GlobalSettings.Constants.ORANGE;
			}
			else if (upgrade.BreakProbability > 15f)
			{
				result = Color.yellow;
			}
			else if (upgrade.PoweredUp && !upgrade.IsActivated)
			{
				result = UpgradeColorNormal;
			}
		}
		return result;
	}

	public static Color GetUpgradeStatus(BaseDroneUpgrade upgrade, bool dimmed)
	{
		Color result = Color.white;
		if (upgrade != null)
		{
			result = ((upgrade.BrokenState == BrokenStateEnum.Broken) ? (dimmed ? UpgradeColorErrorDimmed : UpgradeColorError) : ((upgrade.BreakProbability > 25f) ? (dimmed ? GlobalSettings.Constants.ORANGE_DIM : GlobalSettings.Constants.ORANGE) : ((!(upgrade.BreakProbability > 15f)) ? (dimmed ? UpgradeColorNormalDimmed : UpgradeColorNormal) : (dimmed ? (Color.yellow * 0.5f) : Color.yellow))));
		}
		return result;
	}

	public static Color GetUpgradeStatus(BaseShipUpgrade upgrade, bool dimmed)
	{
		Color result = Color.white;
		if (upgrade != null)
		{
			result = (upgrade.IsPermanentUpgrade ? (dimmed ? UpgradeColorFixedDimmed : UpgradeColorFixed) : ((upgrade.BrokenState == BrokenStateEnum.Broken) ? (dimmed ? UpgradeColorErrorDimmed : UpgradeColorError) : ((upgrade.BreakProbability > 25f) ? (dimmed ? GlobalSettings.Constants.ORANGE_DIM : GlobalSettings.Constants.ORANGE) : ((!(upgrade.BreakProbability > 15f)) ? (dimmed ? UpgradeColorNormalDimmed : UpgradeColorNormal) : (dimmed ? (Color.yellow * 0.5f) : Color.yellow)))));
		}
		return result;
	}

	public bool SetDroneNumber(int droneNumber)
	{
		bool msgFailedDisplayed = false;
		return SetDroneNumber(droneNumber, out msgFailedDisplayed);
	}

	public bool SetDroneNumber(int droneNumber, out bool msgFailedDisplayed)
	{
		msgFailedDisplayed = false;
		if (droneNumber > -1)
		{
			Drone drone = GetDrone(droneNumber);
			if (drone != null)
			{
				if (drone.CurrentRoom != null && drone.CurrentRoom.boardingVessel && BoardingShip.Instance.IsRedockingShip)
				{
					SendConsoleMessage("Drone " + droneNumber + " is on the moving boarding ship\n    Wait until it completes docking", ConsoleMessageType.Warning);
					msgFailedDisplayed = true;
					return false;
				}
				if (!drone.InterfaceDisconnected && drone.IsVisible)
				{
					_curDroneNumber = droneNumber;
					if (EnableStaleData && EnableStaleDataOnCurrentOnly && CurrentDrone != drone && sdLightArray != null)
					{
						Dictionary<Drone, List<StaleLightData>>.Enumerator enumerator = sdLightArray.GetEnumerator();
						while (enumerator.MoveNext())
						{
							if (!(enumerator.Current.Key != drone))
							{
								continue;
							}
							foreach (StaleLightData item in enumerator.Current.Value)
							{
								UnityEngine.Object.Destroy(item.lightObj);
							}
							enumerator.Current.Value.Clear();
						}
					}
					if (CurrentDrone != null)
					{
						CurrentDrone.StopRemoteSounds();
						if (CurrentDrone.listener != null)
						{
							CurrentDrone.listener.enabled = false;
						}
					}
					if (GlobalSettings.cameraMode == CameraMode.Drone && GlobalSettings.cameraMode == CameraMode.Drone && drone.listener != null)
					{
						drone.listener.enabled = true;
					}
					if (CurrentDrone != drone && isShowingHintOverlay)
					{
						DisableUpgradeHintLines();
					}
					CurrentDrone = drone;
					HUDCameraController.Instance.SwitchToDrone(CurrentDrone.DroneNumber);
					HUDOnlyCameraController.Instance.SwitchToDrone(CurrentDrone.DroneNumber);
					if (droneAudioHolderGameObject != null)
					{
						droneAudioHolderGameObject.transform.SetParent(CurrentDrone.transform);
					}
					CurrentDrone.DVP.BringOnline();
					DeactivateDroneCamera();
					CurrentDrone.DVP.Update();
					HUDCamera.transform.parent = DroneCamera.transform;
					HUDCamera.transform.localPosition = Vector3.zero;
					if (isHUDOverlayCameraInUse)
					{
						HUDOverlayCamera.transform.parent = DroneCamera.transform;
						HUDOverlayCamera.transform.localPosition = Vector3.zero;
					}
					CurrentDrone.PlayCallSign();
					if (GlobalSettings.cameraMode == CameraMode.Drone)
					{
						ActivateDroneCamera();
						DungeonManager.Instance.RefreshAfterDroneChange();
					}
					isInLostVideoState = false;
					currentDronePanel.SetDrone(CurrentDrone);
					positionDroneCamera();
					if (OnSelectedDrone != null)
					{
						OnSelectedDrone(_curDroneNumber);
					}
					foreach (Drone drones in dronesList)
					{
						drones.IsPrimaryCommandContext = false;
					}
					if (GlobalSettings.cameraMode == CameraMode.Drone)
					{
						foreach (Drone drones2 in dronesList)
						{
							drones2.isMoving = false;
							drones2.isMovingForwardBack = false;
						}
						drone.IsPrimaryCommandContext = true;
					}
					if (swapUIShown && !CurrentDrone.IsBeingSwapped)
					{
						HideUpgradeSwapUI();
					}
					return true;
				}
			}
		}
		else
		{
			CurrentDrone = null;
			currentDronePanel.SetDrone(null);
		}
		return false;
	}

	public void switchCameraView()
	{
		switch (GlobalSettings.cameraMode)
		{
		case CameraMode.Drone:
			GlobalSettings.cameraMode = CameraMode.Schematic;
			GameplayManager.Instance.RemoveAllDroneContextsFromConsole();
			if (EnableStaleData)
			{
				SetLightArrayStatus(false);
			}
			SetSpotLightStatus(false);
			ReconnectAllProbesSv();
			break;
		case CameraMode.Schematic:
			GlobalSettings.cameraMode = CameraMode.Drone;
			if (OnSelectedDrone != null)
			{
				OnSelectedDrone(_curDroneNumber);
			}
			if (EnableStaleData)
			{
				SetLightArrayStatus(true);
			}
			SetSpotLightStatus(true);
			DisconnectAllProbesSv();
			break;
		}
		UpdateCameraView();
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			DeactivateDroneCamera();
			if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.MyShip != null)
			{
				SchematicCamera.gameObject.SetActive(!GlobalSettings.GameState.ThePlayer.MyShip.VideoSignalLost);
			}
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				BoardingShipCamera.gameObject.SetActive(true);
				boardingShipUI.gameObject.SetActive(true);
				boardingShipOverlayUI.gameObject.SetActive(true);
			}
			GlobalSettings.cameraMode = CameraMode.Schematic;
			foreach (Drone drones in dronesList)
			{
				drones.IsPrimaryCommandContext = false;
				drones.SwitchToSchematicSounds();
				if (GlobalSettings.IsTutorial)
				{
					SchematicViewCanvas.Instance.RefreshDrone(drones.DroneNumber);
				}
			}
			DungeonManager.Instance.IsPrimaryCommandContext = true;
			if (CurrentDrone != null)
			{
				CurrentDrone.listener.enabled = false;
			}
			if (!GameplayManager.Instance.isHidingCanvases)
			{
				GameplayManager.Instance.SVInfoUI.gameObject.SetActive(true);
			}
			if (asRShipCreak != null && asRShipCreak.isPlaying)
			{
				asRShipCreak.volume = 0f;
			}
		}
		else
		{
			DeactivateSchematicCamera();
			ActivateDroneCamera();
			GlobalSettings.cameraMode = CameraMode.Drone;
			DungeonManager.Instance.IsPrimaryCommandContext = false;
			foreach (Drone drones2 in dronesList)
			{
				drones2.SwitchToRemoteSounds();
			}
			if (CurrentDrone != null)
			{
				CurrentDrone.IsPrimaryCommandContext = true;
				CurrentDrone.listener.enabled = true;
			}
			GameplayManager.Instance.SVInfoUI.gameObject.SetActive(false);
			if (asRShipCreak != null && asRShipCreak.isPlaying)
			{
				asRShipCreak.volume = GameAudio.VolumeMultiplier(soundRShipCreak, GameAudio.RemoteVolume);
			}
			if (isHUDOverlayCameraInUse)
			{
				HUDOverlayCamera.gameObject.SetActive(true);
			}
		}
		if (isShowingHintOverlay)
		{
			DisableUpgradeHintLines();
		}
		DungeonManager.Instance.UpdateCameraView();
		int count = dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			dronesList[i].switchCameraView();
		}
		count = LootableDronesList.Count;
		for (int j = 0; j < count; j++)
		{
			LootableDronesList[j].switchCameraView();
		}
		MonoBehaviour[] array = UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour)) as MonoBehaviour[];
		count = array.Length;
		for (int k = 0; k < count; k++)
		{
			MonoBehaviour monoBehaviour = array[k];
			if (monoBehaviour is IUpdateCameraView)
			{
				((IUpdateCameraView)monoBehaviour).UpdateCameraView();
			}
		}
	}

	private void InitalizeCammeraArray()
	{
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		Transform transform = GameObject.Find(cameraArrayName).transform;
		foreach (Transform item in transform.transform)
		{
			if (!(item.name == "BoundingTree"))
			{
				continue;
			}
			foreach (Transform item2 in item.transform)
			{
				if (item2.name.StartsWith("BoundArea") && item2.GetComponent<Collider>() != null)
				{
					if (boundingTreeList == null)
					{
						boundingTreeList = new Dictionary<Collider, List<GameObject>>();
					}
					boundingTreeList.Add(item2.GetComponent<Collider>(), new List<GameObject>());
				}
			}
			break;
		}
		foreach (Transform item3 in transform.transform)
		{
			if (!item3.name.StartsWith("DataReaderCamera"))
			{
				continue;
			}
			if (item3.GetComponent<Collider>() != null && boundingTreeList != null)
			{
				Dictionary<Collider, List<GameObject>>.Enumerator enumerator4 = boundingTreeList.GetEnumerator();
				item3.gameObject.SetActive(true);
				item3.GetComponent<Camera>().enabled = false;
				while (enumerator4.MoveNext())
				{
					if (enumerator4.Current.Key.GetComponent<Collider>().bounds.Intersects(item3.gameObject.GetComponent<Collider>().bounds))
					{
						boundingTreeList[enumerator4.Current.Key].Add(item3.gameObject);
					}
				}
			}
			RenderTexture temporary = RenderTexture.GetTemporary(1024, 640, 24, RenderTextureFormat.ARGB32);
			item3.gameObject.GetComponent<Camera>().targetTexture = temporary;
			if (DebugEnableDualQuality)
			{
				item3.gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("MirrorDataLayerLow");
			}
			if (tempRenderTextures == null)
			{
				tempRenderTextures = new List<RenderTexture>();
			}
			tempRenderTextures.Add(temporary);
			CameraEdgeDetectionArray component = item3.gameObject.GetComponent<CameraEdgeDetectionArray>();
			component.feedBackRT = temporary;
			foreach (Transform item4 in item3.transform)
			{
				if (item4.name.StartsWith("DataRenderer"))
				{
					item4.GetComponent<Renderer>().material.SetTexture("_MainTex", temporary);
				}
				if (!DebugEnableCameraArrayLight || !(item4.name == "LightDataReaderCamera"))
				{
					continue;
				}
				RenderTexture temporary2 = RenderTexture.GetTemporary(1024, 640, 24, RenderTextureFormat.ARGB32);
				item4.gameObject.GetComponent<Camera>().targetTexture = temporary2;
				tempRenderTextures.Add(temporary2);
				foreach (Transform item5 in item4.transform)
				{
					if (item5.name.StartsWith("LightDataRenderer"))
					{
						item5.GetComponent<Renderer>().material.SetTexture("_MainTex", temporary2);
					}
				}
			}
		}
	}

	private void ActivateDroneCamera()
	{
		DroneCamera.gameObject.SetActive(true);
		Transform transform = DroneCamera.gameObject.transform.Find("LightDataCamera");
		if (transform != null)
		{
			LightDataCameraObject = transform.gameObject;
			transform.gameObject.SetActive(true);
		}
		transform = DroneCamera.gameObject.transform.Find("DepthDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(true);
			currentDepthDataCamShader = transform.gameObject.GetComponent<CameraMultiChannelDepthEffect>();
			if (CurrentDrone != null && CurrentDrone.DVP != null)
			{
				currentDepthDataCamShader.disableBanding = CurrentDrone.DVP.depthCameraDisableBanding;
			}
		}
		else
		{
			currentDepthDataCamShader = null;
		}
		if (!renderedAtLeastOnePixelData)
		{
			transform = DroneCamera.gameObject.transform.Find("PixelDataCamera");
			if (transform != null)
			{
				transform.gameObject.SetActive(true);
			}
		}
		transform = DroneCamera.gameObject.transform.Find("ColorDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(true);
			currentColorDataCamShader = transform.gameObject.GetComponent<CameraColorMaskEffect>();
			if (CurrentDrone != null && CurrentDrone.DVP != null)
			{
				currentColorDataCamShader.brightness = CurrentDrone.DVP.colorCameraBrightness;
			}
		}
		else
		{
			currentColorDataCamShader = null;
		}
		if (!DebugEnableCameraArray)
		{
			return;
		}
		transform = DroneCamera.gameObject.transform.Find("SceneCaptureCameraHigh");
		if (transform != null)
		{
			transform.gameObject.SetActive(true);
		}
		if (DebugEnableDualQuality)
		{
			transform = DroneCamera.gameObject.transform.Find("SceneCaptureCameraLow");
			if (transform != null)
			{
				transform.gameObject.SetActive(true);
			}
		}
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		transform = GameObject.Find(cameraArrayName).transform;
		foreach (Transform item in transform.transform)
		{
			if (!item.name.StartsWith("DataReaderCamera"))
			{
				continue;
			}
			item.gameObject.SetActive(true);
			foreach (Transform item2 in item.transform)
			{
				if (item2.name.StartsWith("DataRenderer") || item2.name.StartsWith("LightDataCamera") || (DebugEnableCameraArrayLight && item2.name == "LightDataReaderCamera"))
				{
					item2.gameObject.SetActive(true);
				}
			}
		}
	}

	public void DeactivateDroneCamera()
	{
		DroneCamera.gameObject.SetActive(false);
		Transform transform = DroneCamera.gameObject.transform.Find("LightDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		transform = DroneCamera.gameObject.transform.Find("DepthDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		transform = DroneCamera.gameObject.transform.Find("PixelDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		transform = DroneCamera.gameObject.transform.Find("ColorDataCamera");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		if (!DebugEnableCameraArray)
		{
			return;
		}
		transform = DroneCamera.gameObject.transform.Find("SceneCaptureCameraHigh");
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
		if (DebugEnableDualQuality)
		{
			transform = DroneCamera.gameObject.transform.Find("SceneCaptureCameraLow");
			if (transform != null)
			{
				transform.gameObject.SetActive(false);
			}
		}
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		transform = GameObject.Find(cameraArrayName).transform;
		foreach (Transform item in transform.transform)
		{
			if (!item.name.StartsWith("DataReaderCamera"))
			{
				continue;
			}
			item.gameObject.SetActive(false);
			foreach (Transform item2 in item.transform)
			{
				if (item2.name.StartsWith("DataRenderer") || item2.name.StartsWith("LightDataCamera"))
				{
					item2.gameObject.SetActive(false);
				}
			}
		}
	}

	public void DeactivateSchematicCamera()
	{
		SchematicCamera.gameObject.SetActive(false);
		if (BoardingShipCamera.gameObject.activeSelf)
		{
			BoardingShipCamera.gameObject.SetActive(false);
			boardingShipUI.gameObject.SetActive(false);
			boardingShipOverlayUI.gameObject.SetActive(false);
		}
	}

	private List<CommandDefinition> QuerySchematicCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>();
		}
		else
		{
			commandList.Clear();
		}
		if (baseCommandList == null)
		{
			baseCommandList = new List<CommandDefinition>();
			baseCommandList.Add(new CommandDefinition(string.Empty, "\nDrone upgrade commands can be entered from this view also."));
			baseCommandList.Add(new CommandDefinition(string.Empty, "\texample: generator\n"));
			baseCommandList.AddRange(CommandHelper.GetCommands("DroneManager"));
		}
		int count = baseCommandList.Count;
		for (int i = 0; i < count; i++)
		{
			CommandDefinition commandDefinition = baseCommandList[i];
			bool flag = true;
			if (!string.IsNullOrEmpty(commandDefinition.Tag))
			{
				flag = false;
				int count2 = dronesList.Count;
				for (int j = 0; j < count2; j++)
				{
					Drone drone = dronesList[j];
					int count3 = drone.Upgrades.Count;
					for (int k = 0; k < count3; k++)
					{
						BaseDroneUpgrade baseDroneUpgrade = drone.Upgrades[k];
						if (baseDroneUpgrade != null && baseDroneUpgrade.Definition.Name.Equals(commandDefinition.Tag, StringComparison.InvariantCultureIgnoreCase))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (flag)
			{
				commandList.Add(commandDefinition);
			}
		}
		return commandList;
	}

	public List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandAvailableList == null)
		{
			commandAvailableList = new List<CommandDefinition>(60);
		}
		else
		{
			commandAvailableList.Clear();
		}
		int count = dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone drone = dronesList[i];
			List<CommandDefinition> list = drone.QueryAvailableCommands();
			int count2 = list.Count;
			for (int j = 0; j < count2; j++)
			{
				CommandDefinition commandDefinition = list[j];
				int length = commandDefinition.CommandName.Length;
				if (length <= 0)
				{
					continue;
				}
				bool flag = false;
				int count3 = commandAvailableList.Count;
				for (int k = 0; k < count3; k++)
				{
					CommandDefinition commandDefinition2 = commandAvailableList[k];
					if (commandDefinition2.CommandName.Length == length && commandDefinition2.CommandName[0] == commandDefinition.CommandName[0] && commandDefinition2.CommandName == commandDefinition.CommandName)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					commandAvailableList.Add(commandDefinition);
				}
			}
		}
		commandAvailableList.AddRange(QuerySchematicCommands());
		return commandAvailableList;
	}

	public List<CommandDefinition> QueryContextCommands()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			return QuerySchematicCommands();
		}
		return new List<CommandDefinition>();
	}

	public virtual List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		List<CommandDefinition> list = new List<CommandDefinition>();
		List<BaseDroneUpgrade> list2 = new List<BaseDroneUpgrade>();
		foreach (Drone drones in dronesList)
		{
			BaseDroneUpgrade upgrade;
			foreach (BaseDroneUpgrade upgrade2 in drones.Upgrades)
			{
				upgrade = upgrade2;
				if (upgrade != null && !list2.Any((BaseDroneUpgrade x) => x.Definition.Type == upgrade.Definition.Type))
				{
					list2.Add(upgrade);
				}
			}
		}
		DroneUpgradeType[] array = (DroneUpgradeType[])Enum.GetValues(typeof(DroneUpgradeType));
		DroneUpgradeType upgradeType;
		for (int num = 0; num < array.Length; num++)
		{
			upgradeType = array[num];
			if (upgradeType != DroneUpgradeType.Undefined && upgradeType != DroneUpgradeType.NumberOfUpgrades && !list2.Any((BaseDroneUpgrade x) => x.Definition.Type == upgradeType))
			{
				BaseDroneUpgrade baseDroneUpgrade = DroneUpgradeFactory.CreateUpgradeInstance(upgradeType);
				list.AddRange(baseDroneUpgrade.QueryAvailableCommands());
			}
		}
		return list.OrderBy((CommandDefinition x) => x.CommandName).ToList();
	}

	public void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		string commandName = command.Command.CommandName;
		if (command.DroneNumbers.Count == 0 || command.Command.CommandTarget == ConsoleCommandTarget.OtherDrone)
		{
			switch (commandName)
			{
			case "trap":
			{
				if (GlobalSettings.cameraMode != CameraMode.Schematic || command.Arguments.Count <= 0 || (command.Arguments[0][0] != 'b' && command.Arguments[0][0] != 'B') || !"boom".StartsWith(command.Arguments.First().ToLower()))
				{
					break;
				}
				bool flag = false;
				int count3 = dronesList.Count;
				for (int k = 0; k < count3; k++)
				{
					Drone drone2 = dronesList[k];
					int count4 = drone2.Upgrades.Count;
					for (int l = 0; l < count4; l++)
					{
						BaseDroneUpgrade baseDroneUpgrade2 = drone2.Upgrades[l];
						TrapUpgrade trapUpgrade = baseDroneUpgrade2 as TrapUpgrade;
						if (trapUpgrade != null && trapUpgrade.Detonate(false))
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					SendConsoleMessage("Detonated all traps", ConsoleMessageType.Info);
				}
				else
				{
					SendConsoleMessage("No traps to detonate", ConsoleMessageType.Info);
				}
				command.Handled = true;
				break;
			}
			case "list":
			{
				if (GlobalSettings.cameraMode != CameraMode.Schematic)
				{
					break;
				}
				int count = dronesList.Count;
				for (int i = 0; i < count; i++)
				{
					Drone drone = dronesList[i];
					if (!(drone != null) || (command.DroneNumbers.Count != 0 && !command.DroneNumbers.Contains(drone.DroneNumber)) || drone.IsHidden || (!(drone.CurrentRoom == null) && !drone.CurrentRoom.isExplored))
					{
						continue;
					}
					string text = "\r\n<b>Drone " + drone.DroneNumber + "</b> Upgrades:";
					if (drone.IsDead)
					{
						text = ((!drone.CanBeFullyRepaired) ? (text + string.Format(" ({0})", "Destroyed")) : (text + string.Format(" ({0})", "Disabled")));
					}
					GameplayManager.ShowConsoleMessage(text, ConsoleMessageType.Benefit);
					if (drone.NumberOfUpgradesInstalled() > 0)
					{
						int count2 = drone.Upgrades.Count;
						for (int j = 0; j < count2; j++)
						{
							BaseDroneUpgrade baseDroneUpgrade = drone.Upgrades[j];
							if (baseDroneUpgrade == null)
							{
								continue;
							}
							string text2 = "\t" + baseDroneUpgrade.Definition.Name;
							ConsoleMessageType type = ConsoleMessageType.Info;
							if (baseDroneUpgrade.BrokenState == BrokenStateEnum.Broken)
							{
								text2 += " (broken)";
								type = ConsoleMessageType.Warning;
							}
							else
							{
								Type[] array = baseDroneUpgrade.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IStorageUpgrade");
								if (array.Length > 0)
								{
									IStorageUpgrade storageUpgrade = (IStorageUpgrade)baseDroneUpgrade;
									if (storageUpgrade.Capacity > 0)
									{
										string text3 = text2;
										text2 = text3 + " (" + storageUpgrade.Quantity + "/" + storageUpgrade.Capacity + ") ";
									}
								}
								else
								{
									array = baseDroneUpgrade.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IDamagableObject");
									if (array.Length > 0)
									{
										IDamagableObject damagableObject = (IDamagableObject)baseDroneUpgrade;
										if (damagableObject.TotalHitpoints > 0f)
										{
											text2 = text2 + " (" + Math.Round(damagableObject.CurrentHitPoints, 0) + ") ";
										}
									}
								}
								if (baseDroneUpgrade.IsActivated)
								{
									type = ConsoleMessageType.Healthy;
								}
							}
							text2 = text2 + " [<i>" + baseDroneUpgrade.CommandValue + "</i>]";
							GameplayManager.ShowConsoleMessage(text2, type);
						}
					}
					else
					{
						GameplayManager.ShowConsoleMessage("\tNo installed upgrades.", ConsoleMessageType.Info);
					}
				}
				command.Handled = true;
				return;
			}
			}
		}
		if (command.Arguments.Count == 0)
		{
			if (commandName[0] == 's' && "swap".StartsWith(commandName))
			{
				if (CurrentDrone.isMovingForwardBack && !CurrentDrone.IsBraking)
				{
					GameplayManager.ShowConsoleMessage("Cannot swap while moving", ConsoleMessageType.Error);
				}
				else
				{
					int droneNumber = -1;
					if (command.DroneNumbers.Count > 0)
					{
						droneNumber = command.DroneNumbers[0];
					}
					if (GameplayManager.Instance.AddUI(GameWindowIds.UpgradeSwapWindow, droneNumber))
					{
						swapUIShown = true;
					}
					else
					{
						GameplayManager.ShowConsoleMessage("Nothing in range to swap with", ConsoleMessageType.Info);
					}
				}
				command.Handled = true;
				return;
			}
			if (commandName == "navigate" && command.DroneNumbers.Count > 0)
			{
				DroneManager instance = Instance;
				if (command.DroneNumbers.Count == 1)
				{
					if (command.DroneNumbers[0] != instance.CurrentDrone.DroneNumber)
					{
						Drone drone3 = instance.GetDrone(command.DroneNumbers[0]);
						if (drone3 != null)
						{
							if (drone3.CurrentRoom != CurrentDrone.CurrentRoom)
							{
								drone3.NavigateTo(CurrentDrone.CurrentRoom);
								drone3.PlayCallSign();
								if (!Drone.NagivateHintNotNeeded && GlobalSettings.cameraMode == CameraMode.Schematic && !GlobalSettings.IsTutorial && !GameSaveFile.Get("HNT_NAVIGATE", false))
								{
									GameSaveFile.Save("HNT_NAVIGATE", true);
								}
								SendConsoleMessage(string.Format("navigating drone {0} to room {1}, drone {2}'s current room", drone3.DroneNumber, CurrentDrone.CurrentRoom.Label, CurrentDrone.DroneNumber), ConsoleMessageType.Info);
							}
							else
							{
								SendConsoleMessage(string.Format("drone {0} is already in the same room ({1}) as drone {2}.\r\n'help navigate' for usage.", drone3.DroneNumber, CurrentDrone.CurrentRoom.Label, CurrentDrone.DroneNumber), ConsoleMessageType.Info);
							}
						}
						else
						{
							SendConsoleMessage("done not found: " + command.DroneNumbers[0] + ".\r\n'help navigate' for usage.", ConsoleMessageType.Warning);
						}
					}
					else
					{
						SendConsoleMessage("can't navigate a drone to itself.\r\n'help navigate' for usage.", ConsoleMessageType.Warning);
					}
				}
				else
				{
					int count5 = command.DroneNumbers.Count;
					Drone drone4 = instance.GetDrone(command.DroneNumbers[count5 - 1]);
					if (drone4 != null)
					{
						for (int m = 0; m < count5 - 1; m++)
						{
							Drone drone5 = instance.GetDrone(command.DroneNumbers[m]);
							if (drone5 != null)
							{
								if (drone4 != drone5)
								{
									if (drone5.CurrentRoom != drone4.CurrentRoom)
									{
										drone5.NavigateTo(drone4.CurrentRoom);
										drone5.PlayCallSign();
										if (!Drone.NagivateHintNotNeeded && GlobalSettings.cameraMode == CameraMode.Schematic && !GlobalSettings.IsTutorial && !GameSaveFile.Get("HNT_NAVIGATE", false))
										{
											GameSaveFile.Save("HNT_NAVIGATE", true);
										}
										if (drone4.CurrentRoom != null)
										{
											SendConsoleMessage(string.Format("navigating drone {0} to room {1}, drone {2}'s current room", drone5.DroneNumber, drone4.CurrentRoom.Label, drone4.DroneNumber), ConsoleMessageType.Info);
										}
										else
										{
											SendConsoleMessage(string.Format("navigating drone {0} to drone {1}'s current location", drone5.DroneNumber, drone4.DroneNumber), ConsoleMessageType.Info);
										}
									}
									else
									{
										SendConsoleMessage(string.Format("drone {0} is already in the same room ({1}) as drone {2}.\r\n'help navigate' for usage.", drone5.DroneNumber, drone4.CurrentRoom.Label, drone4.DroneNumber), ConsoleMessageType.Info);
									}
								}
								else
								{
									SendConsoleMessage(string.Format("ok, now you are just being silly\r\n'help navigate' for usage."), ConsoleMessageType.Info);
								}
							}
							else
							{
								SendConsoleMessage("source done not found: " + command.DroneNumbers[m] + ".\r\n'help navigate' for usage.", ConsoleMessageType.Warning);
							}
						}
					}
					else
					{
						SendConsoleMessage("target done not found: " + command.DroneNumbers[count5 - 1] + ".\r\n'help navigate' for usage.", ConsoleMessageType.Error);
					}
				}
				command.Handled = true;
			}
		}
		else if (command.Arguments.Count > 0)
		{
			string text4 = command.Arguments[0].ToLower();
			if (commandName == "navigate")
			{
				if (command.DroneNumbers.Count == 1 && text4 == "all")
				{
					int count6 = dronesList.Count;
					Drone drone6 = dronesList.Find((Drone x) => x != null && x.DroneNumber == command.DroneNumbers[0]);
					for (int num = 0; num < count6; num++)
					{
						Drone drone7 = dronesList[num];
						if (!(drone7 != null) || drone7.DroneNumber == command.DroneNumbers[0] || drone7.IsDead || drone7.BrokenState == BrokenStateEnum.Broken || drone7.BrokenState == BrokenStateEnum.ErrorsDetected)
						{
							continue;
						}
						if (drone7.CurrentRoom != drone6.CurrentRoom)
						{
							drone7.NavigateTo(drone6.CurrentRoom);
							if (!Drone.NagivateHintNotNeeded && GlobalSettings.cameraMode == CameraMode.Schematic && !GlobalSettings.IsTutorial && !GameSaveFile.Get("HNT_NAVIGATE", false))
							{
								GameSaveFile.Save("HNT_NAVIGATE", true);
							}
							SendConsoleMessage(string.Format("navigating drone {0} to room {1}, drone {2}'s current room", drone7.DroneNumber, drone6.CurrentRoom.Label, drone6.DroneNumber), ConsoleMessageType.Info);
						}
						else
						{
							SendConsoleMessage(string.Format("drone {0} is already in the same room ({1}) as drone {2}", drone7.DroneNumber, drone6.CurrentRoom.Label, drone6.DroneNumber), ConsoleMessageType.Info);
						}
					}
					command.Handled = true;
				}
			}
			else if (commandName == "interface" && text4 == "list" && command.DroneNumbers.Count == 0 && (GlobalSettings.cameraMode == CameraMode.Schematic || (command.Arguments.Count > 1 && command.Arguments[1].ToLower() == "all")))
			{
				TerminalManager.Instance.DisplayAllAvailableTerminalCommands();
				command.Handled = true;
			}
		}
		if (command.Handled || command.Command.CommandTarget == ConsoleCommandTarget.OtherDrone)
		{
			return;
		}
		ExecutedCommand executedCommand = new ExecutedCommand(command.Command, command.Arguments, null, command.RawCommandLine);
		executedCommand.RequestConfirmed = command.RequestConfirmed;
		List<int> list = new List<int>();
		if (command.Arguments.Count > 0 && command.Arguments[0] == "all" && commandName != "gather" && commandName != "pickup")
		{
			int count7 = dronesList.Count;
			for (int num2 = 0; num2 < count7; num2++)
			{
				Drone drone8 = dronesList[num2];
				list.Add(drone8.DroneNumber);
			}
		}
		else
		{
			list = command.DroneNumbers;
		}
		if (list.Count > 0)
		{
			bool flag2 = false;
			int count8 = list.Count;
			for (int num3 = 0; num3 < count8; num3++)
			{
				int num4 = list[num3];
				executedCommand.Handled = false;
				Drone drone9 = null;
				int count9 = dronesList.Count;
				for (int num5 = 0; num5 < count9; num5++)
				{
					if (dronesList[num5].DroneNumber == num4)
					{
						drone9 = dronesList[num5];
						break;
					}
				}
				if (!(drone9 != null))
				{
					continue;
				}
				if (drone9.IsStunned)
				{
					SendConsoleMessage("Drone " + drone9.DroneNumber + " is not responding", ConsoleMessageType.Warning);
					command.Handled = true;
					flag2 = true;
					continue;
				}
				GameplayManager.Instance.HookObjectToConsole(drone9);
				drone9.ExecuteCommand(executedCommand, partOfMultiCommand);
				GameplayManager.Instance.UnhookObjectFromConsole(drone9);
				command.Handled = executedCommand.Handled;
				command.Queued = executedCommand.Queued;
				command.RequestConfirmation = executedCommand.RequestConfirmation;
				command.RequestConfirmed = executedCommand.RequestConfirmed;
				if (executedCommand.Handled)
				{
					flag2 = true;
				}
				else if (command.Command.CommandName == "generator" || command.Command.CommandName == "motion" || command.Command.CommandName == "turret" || command.Command.CommandName == "stealth" || command.Command.CommandName == "gather" || command.Command.CommandName == "pickup" || command.Command.CommandName == "interface" || command.Command.CommandName == "lure" || command.Command.CommandName == "probe" || command.Command.CommandName == "mine" || command.Command.CommandName == "scan" || command.Command.CommandName == "sensor" || command.Command.CommandName == "shield" || command.Command.CommandName == "stun" || command.Command.CommandName == "turret" || command.Command.CommandName == "teleport" || command.Command.CommandName == "trap" || command.Command.CommandName == "sonic" || command.Command.CommandName == "tow" || command.Command.CommandName == "pry")
				{
					SendConsoleMessage(string.Format("No '{0}' on drone {1} ({2}).\r\nPlease specify a drone with a '{0}' upgrade", command.Command.CommandName, drone9.DroneNumber, drone9.DroneName), ConsoleMessageType.Warning);
					command.Handled = true;
				}
			}
			if (flag2)
			{
				executedCommand.Handled = true;
				command.Handled = true;
			}
		}
		else
		{
			if (GlobalSettings.cameraMode != CameraMode.Schematic)
			{
				return;
			}
			Drone drone10 = null;
			int num6 = 0;
			int count10 = dronesList.Count;
			for (int num7 = 0; num7 < count10; num7++)
			{
				Drone drone11 = dronesList[num7];
				bool flag3 = false;
				List<CommandDefinition> list2 = drone11.QueryAvailableCommands();
				int count11 = list2.Count;
				for (int num8 = 0; num8 < count11; num8++)
				{
					CommandDefinition commandDefinition = list2[num8];
					if (commandDefinition.CommandName == executedCommand.Command.CommandName)
					{
						flag3 = true;
						break;
					}
				}
				if (flag3)
				{
					drone10 = drone11;
					num6++;
				}
			}
			if (num6 == 1)
			{
				GameplayManager.Instance.HookObjectToConsole(drone10);
				drone10.ExecuteCommand(executedCommand, partOfMultiCommand);
				GameplayManager.Instance.UnhookObjectFromConsole(drone10);
				command.Handled = executedCommand.Handled;
				command.Queued = executedCommand.Queued;
			}
			else if (num6 > 1)
			{
				CommandProcessVerification(executedCommand.Command.CommandName, null);
			}
		}
	}

	public bool CommandProcessVerification(string commandText, object data)
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			return false;
		}
		if (data == null || ((List<int>)data).Count == 0)
		{
			bool flag = true;
			if (commandText == "info")
			{
				flag = false;
			}
			if (flag)
			{
				SendConsoleMessage(string.Format("Multiple drones can process command '{0}',\r\n please specify drone number. Eg: {0} 2 3", commandText), ConsoleMessageType.Info);
			}
			else
			{
				SendConsoleMessage(string.Format("Multiple drones can process command '{0}',\r\n please specify the specific drone number. Eg: {0} 2", commandText), ConsoleMessageType.Info);
			}
			return true;
		}
		return false;
	}

	public void SendConsoleMessage(string message, ConsoleMessageType messageType)
	{
		ConsoleWindow3.SendConsoleResponse(message, messageType);
	}

	public bool WouldBeLostInSpace(Vector3 position)
	{
		return DungeonManager.Instance.WouldBeLostInSpace(position);
	}

	public List<ICombatTarget> GetAvailableLures()
	{
		lures.Clear();
		if (DroneItemDropper.DroppedItemDict.ContainsKey(DropItemType.Lure) && DroneItemDropper.DroppedItemDict[DropItemType.Lure].Count > 0)
		{
			DroneItemDropper.DroppedItemDict[DropItemType.Lure].ForEach(delegate(DropableItem x)
			{
				lures.Add((ICombatTarget)x);
			});
		}
		return lures;
	}

	public List<ICombatTarget> GetAvailableProbes()
	{
		probes.Clear();
		if (DroneItemDropper.DroppedItemDict.ContainsKey(DropItemType.Probe) && DroneItemDropper.DroppedItemDict[DropItemType.Probe].Count > 0)
		{
			DroneItemDropper.DroppedItemDict[DropItemType.Probe].ForEach(delegate(DropableItem x)
			{
				probes.Add((ICombatTarget)x);
			});
		}
		return probes;
	}

	public List<ICombatTarget> GetAvailableSensors()
	{
		sensors.Clear();
		if (DroneItemDropper.DroppedItemDict.ContainsKey(DropItemType.Sensor) && DroneItemDropper.DroppedItemDict[DropItemType.Sensor].Count > 0)
		{
			DroneItemDropper.DroppedItemDict[DropItemType.Sensor].ForEach(delegate(DropableItem x)
			{
				sensors.Add((ICombatTarget)x);
			});
		}
		return sensors;
	}

	private Drone InstantiateLootableDrone(Vector3 position, Quaternion rotation)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(DronePrefab, position, rotation);
		Drone drone = (Drone)gameObject.GetComponentInChildren(typeof(Drone));
		TextMesh textMesh = (TextMesh)gameObject.GetComponentInChildren(typeof(TextMesh));
		textMesh.text = "0";
		Transform transform = null;
		if (!DebugDisableDroneTopLight)
		{
			transform = drone.transform.Find("DroneLight");
			transform.gameObject.SetActive(false);
		}
		transform = ((!DebugUseTestSpotlight && !DebugUseCameraArraySpotlight) ? drone.transform.Find("Spotlight") : ((!DebugUseCameraArraySpotlight) ? drone.Swival.transform.Find("SpotlightTest") : drone.transform.Find("SpotlightTestCameraArray")));
		transform.gameObject.SetActive(false);
		transform = drone.transform.Find("TurretCollision");
		UnityEngine.Object.Destroy(transform.gameObject);
		Transform transform2 = drone.transform.Find("Overlays");
		transform = transform2.Find("TurretUI");
		transform.GetComponent<Renderer>().enabled = false;
		transform = transform2.Find("ShieldUI");
		transform.GetComponent<Renderer>().enabled = false;
		transform = gameObject.transform.Find("DroneCamera");
		transform.gameObject.SetActive(false);
		drone.InterfaceDisconnected = true;
		Transform transform3 = drone.transform.Find("DroneUI");
		if (transform3 != null)
		{
			DroneUIObject droneUIObject = (DroneUIObject)transform3.gameObject.GetComponent(typeof(DroneUIObject));
			droneUIObject.Visible = false;
			droneUIObject.parentObject = drone.gameObject;
			droneUIObject.objectBecameVisible += LootableDroneUIBecameVisible;
		}
		transform = gameObject.transform.Find("SceneMirrorHigh");
		if (transform != null)
		{
			UnityEngine.Object.Destroy(transform.gameObject);
		}
		if (DebugEnableDualQuality)
		{
			transform = gameObject.transform.Find("SceneMirrorLow");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		HideDrone(ref drone);
		return drone;
	}

	private void LootableDroneUIBecameVisible(GameObject data)
	{
		if (data != null)
		{
			Drone drone = (Drone)data.GetComponent(typeof(Drone));
			if (!DebugDisableDroneTopLight)
			{
				drone.transform.Find("DroneLight").gameObject.SetActive(true);
			}
		}
	}

	public void HideUpgradeSwapUI()
	{
		HideUpgradeSwapUI(false);
	}

	public void HideUpgradeSwapUI(bool onlyIfAppliesToCurrent)
	{
		if ((!onlyIfAppliesToCurrent || CurrentDrone.IsBeingSwapped) && GameplayManager.Instance.HideUI(GameWindowIds.UpgradeSwapWindow, true))
		{
			swapUIShown = false;
		}
	}

	public void EnableUpgradeHintLines()
	{
		if (DVOverlayLineObjects != null)
		{
			delayHintStates = 0.25f;
			fadingIn = true;
			pulseCount = 0;
			GameObject[] dVOverlayLineObjects = DVOverlayLineObjects;
			foreach (GameObject gameObject in dVOverlayLineObjects)
			{
				gameObject.SetActive(true);
			}
			isShowingHintOverlay = true;
			currentHintOverlayState = HintOverlayStateEnum.PulsingOverlay;
		}
	}

	public void DisableUpgradeHintLines()
	{
		if (DVOverlayLineObjects != null)
		{
			GameObject[] dVOverlayLineObjects = DVOverlayLineObjects;
			foreach (GameObject gameObject in dVOverlayLineObjects)
			{
				gameObject.SetActive(false);
			}
		}
		currentHintOverlayState = HintOverlayStateEnum.None;
		isShowingHintOverlay = false;
	}

	public void ToggleUpgradeHintLines(bool visible)
	{
		if (DVOverlayLineObjects != null)
		{
			GameObject[] dVOverlayLineObjects = DVOverlayLineObjects;
			foreach (GameObject gameObject in dVOverlayLineObjects)
			{
				gameObject.GetComponent<Renderer>().enabled = visible;
			}
		}
	}

	public void PauseSoundsOnMenuOpen()
	{
		foreach (Drone drones in dronesList)
		{
			drones.PauseSoundsOnMenuOpen();
		}
		if (asSEngineSustain != null && asSEngineSustain.isPlaying)
		{
			isSEngineSustainPaused = true;
			asSEngineSustain.Pause();
		}
	}

	public void ResumeSoundsOnMenuClose()
	{
		foreach (Drone drones in dronesList)
		{
			drones.ResumeSoundsOnMenuClose();
		}
		if (isSEngineSustainPaused)
		{
			isSEngineSustainPaused = false;
			asSEngineSustain.Play();
		}
	}

	public void PlaySingleSVDroneSound()
	{
		if (GlobalSettings.cameraMode != CameraMode.Schematic || !(asSEngineSustain != null))
		{
			return;
		}
		if (!asSEngineSustain.isPlaying)
		{
			if (!asSEngineSustain.enabled)
			{
				asSEngineSustain.enabled = true;
			}
			asSEngineSustain.Play();
		}
		asSEngineSustain.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Schematic_DroneMapMove_Sustain, GameAudio.SchematicVolume);
	}

	public void StopMovement()
	{
		if (!asSEngineSustain.isPlaying)
		{
			return;
		}
		foreach (Drone drones in dronesList)
		{
			if (drones.isMoving)
			{
				return;
			}
		}
		asSEngineSustain.Stop();
	}

	public void PlayDroneShipCreak()
	{
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			soundRShipCreak = GameAudio.SoundEnum.Remote_ShipCreak1;
			break;
		case 1:
			soundRShipCreak = GameAudio.SoundEnum.Remote_ShipCreak2;
			break;
		case 2:
			soundRShipCreak = GameAudio.SoundEnum.Remote_ShipCreak3;
			break;
		}
		asRShipCreak.clip = GameAudio.GetClip(soundRShipCreak);
		asRShipCreak.volume = GameAudio.VolumeMultiplier(soundRShipCreak, GameAudio.RemoteVolume);
		asRShipCreak.Play();
	}

	private void AddSoundSources()
	{
		asSEngineSustain = Instance.SchematicCamera.gameObject.AddComponent<AudioSource>();
		asSEngineSustain.clip = GameAudio.GetClip(GameAudio.SoundEnum.Schematic_DroneMapMove_Sustain);
		asSEngineSustain.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Schematic_DroneMapMove_Sustain, GameAudio.SchematicVolume);
		asSEngineSustain.playOnAwake = false;
		droneAudioHolderGameObject = new GameObject("AudioHolder");
		asRShipCreak = droneAudioHolderGameObject.AddComponent<AudioSource>();
		asRShipCreak.volume = GameAudio.RemoteVolume;
		asRShipCreak.spatialBlend = 0f;
		asRShipCreak.playOnAwake = false;
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.Schematic_DroneMapMove_Sustain);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_ShipCreak1);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_ShipCreak2);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_ShipCreak3);
	}
}
