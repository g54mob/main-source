using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class SessionData : MonoBehaviour
{
	public enum TimeSpeed
	{
		slow = 0,
		normal = 1,
		fast = 2,
		veryFast = 3,
		simulation = 4
	}

	public enum TimeOfDay
	{
		morning = 0,
		afternoon = 1,
		evening = 2
	}

	public enum WeekDay
	{
		monday = 0,
		tuesday = 1,
		wednesday = 2,
		thursday = 3,
		friday = 4,
		saturday = 5,
		sunday = 6
	}

	public enum Month
	{
		jan = 0,
		feb = 1,
		mar = 2,
		apr = 3,
		may = 4,
		jun = 5,
		jul = 6,
		aug = 7,
		sep = 8,
		oct = 9,
		nov = 10,
		dec = 11
	}

	[Serializable]
	public class WetMaterial
	{
		public Material mat;

		public Material instancedMat;

		public List<MeshRenderer> affectedRenderers;

		[Space(7f)]
		public bool affectRain;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("affectRain")]
		public Vector2 rainMinMax;

		[ShowIf("affectRain")]
		public float rainMultiplier;

		[Space(7f)]
		public bool affectCityWetness;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("affectCityWetness")]
		public Vector2 cityWetnessMinMax;

		[ShowIf("affectCityWetness")]
		public float cityWetnessMultiplier;

		[ShowIf("affectCityWetness")]
		public bool cityWetnessLogScale;

		[Space(7f)]
		public bool affectCitySnow;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("affectCitySnow")]
		public Vector2 citySnowMinMax;

		[ShowIf("affectCitySnow")]
		public float citySnowMultiplier;

		[Space(7f)]
		public bool affectCoatMask;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("affectCoatMask")]
		public Vector2 coatMaskMinMax;

		[ShowIf("affectCoatMask")]
		public float coatMaskMultiplier;

		[Space(7f)]
		public bool affectWind;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("affectWind")]
		public Vector2 windMinMax;

		[ShowIf("affectWind")]
		public float windMultiplier;
	}

	public enum SceneProfile
	{
		outdoors = 0,
		indoors = 1,
		grimey = 2,
		clean = 3,
		corporate = 4,
		cbd = 5,
		chinatown = 6,
		industrial = 7,
		residential = 8,
		warm = 9
	}

	[Serializable]
	public class SkyboxGradient : IComparable<SkyboxGradient>
	{
		public float time;

		public Color skyColour;

		public Color fogAlbedo;

		[Space(3f)]
		public Color ambientLightTop;

		public Color ambientLightMiddle;

		public Color ambientLightBottom;

		public Color ambientLightingColour;

		public Color fogColour;

		public Color seaEmission;

		public Color smokeEmission;

		public int CompareTo(SkyboxGradient otherObject)
		{
			return 0;
		}
	}

	public class TelevisionChannel
	{
		public BroadcastSchedule currentBroadcastSchedule;

		public BroadcastPreset currentShow;

		public Material broadcastMaterialInstanced;

		public int currentScheduleIndex;

		public float currentShowProgressSeconds;

		public float currentShowImageProgress;

		private EventDescription currentShowEventDescription;

		private int currentShowAudioLength;

		private int currentShowImageLength;

		private int currentImageIndex;

		public float crowdParam;

		public bool dynamicShowActive;

		public BroadcastPreset.DynamicClip currentDynamicClip;

		public BroadcastPreset.DynamicClipEvent currentDynamicEvent;

		public AudioEvent currentDynamicAudio;

		public float currentClipProgressSeconds;

		public int currentClipAudioLength;

		private EventDescription currentClipEventDescription;

		public int clipIndex;

		public List<BroadcastPreset.DynamicShowParam> appliedParameters;

		public void ProcessTelevisionBroadcast()
		{
		}

		private void ProcessDynamicShow()
		{
		}

		public BroadcastPreset.DynamicClip GetNextClip()
		{
			return null;
		}

		public BroadcastPreset.DynamicClipEvent GetEvent()
		{
			return null;
		}
	}

	public enum PhysicsSyncType
	{
		now = 0,
		onPlayerMovement = 1,
		both = 2
	}

	public delegate void OnPauseUnPause(bool openDesktopMode);

	public delegate void WeatherChange();

	public delegate void HourChange();

	public delegate void TutorialNotificationChange();

	[Header("Flags")]
	public bool isFloorEdit;

	public bool isDialogEdit;

	public bool isCityEdit;

	public bool isTestScene;

	public bool dirtyScene;

	public bool isDecorEdit;

	public bool enableUserPause;

	public bool enableFirstPersonMap;

	public bool play;

	public bool enableTutorialText;

	public HashSet<string> tutorialTextTriggered;

	public bool startedGame;

	public int pauseUnpauseDelay;

	private float drunkOscillatorX;

	private float drunkOscillatorY;

	public Vector2 drunkOscillation;

	private float shiverOscillatorX;

	private float shiverOscillatorY;

	private float shiverProgress;

	public Vector2 shiverOscillation;

	private float drunkLensProgress;

	private float headacheProgress;

	private int sunShadowFrameCounter;

	[Header("Time")]
	public float gameTime;

	public double gameTimeDouble;

	public double gameTimePassedThisFrame;

	private int prevHour;

	private double watchChangeCounter;

	public float decimalClock;

	public double decimalClockDouble;

	public TimeSpeed currentTimeSpeed;

	public float currentTimeMultiplier;

	public float behaviourDelay;

	public TimeOfDay timeOfDay;

	public int dayInt;

	public WeekDay day;

	public int dateInt;

	public Month month;

	public int monthInt;

	public List<int> daysInMonths;

	public int yearInt;

	public int publicYear;

	public int leapYearCycle;

	public float gameTimeLimit;

	[Header("Weather")]
	[Range(0f, 1f)]
	public float currentRain;

	[Range(0f, 1f)]
	public float desiredRain;

	[Range(0f, 1f)]
	public float currentWind;

	[Range(0f, 1f)]
	public float desiredWind;

	[Range(0f, 1f)]
	public float currentSnow;

	[Range(0f, 1f)]
	public float desiredSnow;

	[Range(0f, 1f)]
	public float currentLightning;

	[Range(0f, 1f)]
	public float desiredLightning;

	[Range(0f, 1f)]
	public float currentFog;

	[Range(0f, 1f)]
	public float desiredFog;

	public float transitionSpeed;

	public float weatherChangeTimer;

	private float monthTempMultiplier;

	public float temperature;

	[Space(5f)]
	public float lightningTimer;

	[Space(5f)]
	public Vector3 windDirection;

	public float windForce;

	[Header("Scene")]
	public float dayProgress;

	public RainSheetController nearRainSheet;

	public RainSheetController farRainSheet;

	public Vector2 nearRainAlpha1Threshold;

	public Vector2 nearRainAlpha2Threshold;

	public Vector2 nearRainSpeedThreshold;

	public Vector2 nearRainXTile1Threshold;

	public Vector2 nearRainXTile2Threshold;

	[Space(5f)]
	public Vector2 farRainAlpha1Threshold;

	public Vector2 farRainAlpha2Threshold;

	public Vector2 farRainSpeedThreshold;

	public Vector2 farRainXTile1Threshold;

	public Vector2 farRainXTile2Threshold;

	[Space(5f)]
	public Vector2 particalRainCountThreshold;

	public Vector2 particalSnowCountThreshold;

	[Space(5f)]
	public float cityWetness;

	public float citySnow;

	[Tooltip("Configuration of materials where instancing will occur and weather params within them changed and updated")]
	public List<WetMaterial> wetMaterials;

	public Dictionary<Material, WetMaterial> weatherMaterialsReference;

	public List<CustomPassVolume> customPasses;

	public Dictionary<GameObject, WallFrontagePreset> rainyWindowFrontageObjects;

	public float autoPauseTimer;

	public float autoResetTimer;

	private float lightswitchPulse;

	private bool lightswitchPulseMode;

	[Header("PP Profiles")]
	public SceneProfile currentProfile;

	[NonSerialized]
	public CityControls.PPProfile currentSceneProfile;

	[NonSerialized]
	public CityControls.PPProfile desiredSceneProfile;

	[Header("HDRP")]
	[Tooltip("The global (outdoors) profile")]
	public Volume globalVolume;

	public GradientSky gradientSky;

	public Fog volFog;

	public DepthOfField dof;

	public Vignette vignette;

	public MotionBlur motionBlur;

	public FilmGrain grain;

	public Tonemapping toneMapping;

	public Bloom bloom;

	public ChromaticAberration chromaticAberration;

	public LiftGammaGain lgg;

	public ColorAdjustments colour;

	public LensDistortion lensDistort;

	public Exposure exposure;

	public ChannelMixer channelMixer;

	public ScreenSpaceReflection ssReflection;

	public int skyboxGradientIndex;

	public SkyboxGradient fromSkyboxColours;

	public SkyboxGradient toSkyboxColours;

	[Header("Elevators")]
	public List<Elevator> activeElevators;

	[Header("Particle Systems")]
	public List<InteractableController> particleSystems;

	[Header("Television")]
	public Material broadcastMaterial;

	public List<TelevisionChannel> televisionChannels;

	[Header("References")]
	public TextMeshProUGUI pauseText;

	public GameObject pauseLensFlare;

	public Image pauseButtonImg;

	public Image normalSpeedButtonImg;

	public Image fastSpeedButtonImg;

	public Image veryFastSpeedButtonImg;

	public TextMeshPro newWatchTimeText;

	public TextMeshPro newWatchDateText;

	public TextMeshProUGUI clockText;

	public TextMeshProUGUI dayText;

	public Image pauseButtonIcon;

	public Sprite pauseIcon;

	public Sprite playIcon;

	public NewNode startingNode;

	[NonSerialized]
	private AudioController.LoopingSoundInfo interfaceActiveAudio;

	[Header("Debug")]
	public Vector2 debugDecimalRange;

	public List<WeekDay> debugDayList;

	public Action UnloadPipes;

	public List<PipeConstructor.PipeGroup> pipesToUnload;

	private static SessionData _instance;

	public static SessionData Instance => null;

	public event OnPauseUnPause OnPauseChange
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

	public event WeatherChange OnWeatherChange
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

	public event HourChange OnHourChange
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

	public event TutorialNotificationChange OnTutorialNotificationChange
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

	private void Start()
	{
	}

	public void SetupTelevisionChannels()
	{
	}

	public void StartTestScene()
	{
	}

	public void SetGameTime(int newYear, int newMonth, int newDate, int newDay, float newStartingTime, int newLeapYearCycle)
	{
	}

	public void SetGameTime(float newGameTime, int newLeapYearCycle)
	{
	}

	public void UpdateSkyboxGraidentTargets()
	{
	}

	public void SetTimeSpeed(TimeSpeed newTimeSpeed)
	{
	}

	public float GetGameSpeedMotionBlurModifier()
	{
		return 0f;
	}

	public void SetSceneProfile(SceneProfile newProfile, bool immediate = false)
	{
	}

	private void Update()
	{
	}

	public void UpdateGameTimerText()
	{
	}

	public void EndDemo()
	{
	}

	public void ExecuteSyncPhysics(PhysicsSyncType syncType)
	{
	}

	public void ExecuteWeatherChange()
	{
	}

	public void ExecuteWetnessChange()
	{
	}

	public void ExecuteWindChange()
	{
	}

	public Material GetWeatherAffectedMaterial(Material inputMat, MeshRenderer inputRenderer)
	{
		return null;
	}

	public void ExecuteLightningStrike()
	{
	}

	public void SetSceneVisuals(float newDecimalClock)
	{
	}

	public void SetEnablePause(bool val)
	{
	}

	public void ParseTimeData(float newTime, out float decimalHourOut, out int dayIntOut, out int dateIntOut, out int monthIntOut, out int yearIntOut, out WeekDay dayEnumOut, out Month monthEnumOut, out int leapCycleOut)
	{
		decimalHourOut = default(float);
		dayIntOut = default(int);
		dateIntOut = default(int);
		monthIntOut = default(int);
		yearIntOut = default(int);
		dayEnumOut = default(WeekDay);
		monthEnumOut = default(Month);
		leapCycleOut = default(int);
	}

	public void ParseTimeData(float newTime, out float decimalHourOut, out int dayIntOut, out int dateIntOut, out int monthIntOut, out int yearIntOut)
	{
		decimalHourOut = default(float);
		dayIntOut = default(int);
		dateIntOut = default(int);
		monthIntOut = default(int);
		yearIntOut = default(int);
	}

	public void ParseTimeData(float newTime, out float decimalHourOut, out WeekDay dayEnumOut, out int dateIntOut, out Month monthEnumOut, out int yearIntOut)
	{
		decimalHourOut = default(float);
		dayEnumOut = default(WeekDay);
		dateIntOut = default(int);
		monthEnumOut = default(Month);
		yearIntOut = default(int);
	}

	public float ParseGameTime(float decimalHourIn, int dateIntIn, int monthIntIn, int yearIntIn, out int dayCount, out int leapYear)
	{
		dayCount = default(int);
		leapYear = default(int);
		return 0f;
	}

	public float FloatDecimal24H(float time)
	{
		return 0f;
	}

	public float FloatMinutes24H(float newTime)
	{
		return 0f;
	}

	public float FloatMinutes12H(float newTime)
	{
		return 0f;
	}

	public string DecimalToClockString(float newTime, bool useZeroHoursMethod)
	{
		return null;
	}

	public string DecimalToTimeLengthString(float newTime)
	{
		return null;
	}

	public string GameTimeToClock24String(float newGameTime, bool useZeroHoursMethod)
	{
		return null;
	}

	public string GameTimeToClock12String(float newGameTime, bool useZeroHoursMethod)
	{
		return null;
	}

	public string MinutesToClockString(float formatted, bool useZeroHoursMethod)
	{
		return null;
	}

	public string CurrentTimeString(bool useZeroHoursMethod, bool use12HourClock = false)
	{
		return null;
	}

	public string ShortDateString(float newGameTime, bool shortenYear)
	{
		return null;
	}

	public string CurrentShortDateString(bool shortenYear)
	{
		return null;
	}

	public string LongDateString(float newGameTime, bool includeDay, bool shortenDay, bool includeMonth, bool shortenMonth, bool includeDate, bool includeYear, bool shortenYear, bool useCommas)
	{
		return null;
	}

	public string CurrentLongDateString(bool includeDay, bool shortenDay, bool includeMonth, bool shortenMonth, bool includeDate, bool includeYear, bool shortenYear, bool useCommas)
	{
		return null;
	}

	public string TimeString(float newGameTime, bool useZeroHoursMethod)
	{
		return null;
	}

	public string TimeStringOnDay(float newGameTime, bool useZeroHoursMethod, bool shortenDay)
	{
		return null;
	}

	public string TimeAndDate(float newGameTime, bool useZeroHoursMethod, bool shortenDay, bool shortenYear)
	{
		return null;
	}

	public string OnDay(int newDay, bool shortenDay)
	{
		return null;
	}

	public float GetNextOrPreviousGameTimeForThisHour(ref List<WeekDay> days, float startHour, float endHour)
	{
		return 0f;
	}

	public float GetNextOrPreviousGameTimeForThisHour(float forThisGameTime, float forThisDecimalHour, WeekDay forThisWeekday, ref List<WeekDay> validWeekDays, float startDecimalHour, float endDecimalHour)
	{
		return 0f;
	}

	public float GetTimeDifference(float time1, float time2)
	{
		return 0f;
	}

	public bool CompareTimes(float time1, float time2)
	{
		return false;
	}

	public WeekDay WeekdayFromInt(int weekInt)
	{
		return default(WeekDay);
	}

	public Month MonthFromInt(int monthInt)
	{
		return default(Month);
	}

	public void SetWeather(float newRain, float newWind, float newSnow, float newLightning, float newFog, float newTransitionSpeed = 0.1f, bool updateInstantly = false)
	{
	}

	public void UpdateWatchText()
	{
	}

	public void UpdateWatchDay()
	{
	}

	public void TogglePause(bool openDesktopMode = true)
	{
	}

	public void PauseGame(bool showPauseText, bool delayOverride = false, bool openDesktopMode = true)
	{
	}

	public void ResumeGame()
	{
	}

	public void SetDisplayTutorialText(bool val)
	{
	}

	public void TutorialTrigger(string str, bool isSilent = false)
	{
	}

	public void UpdateTutorialNotifications()
	{
	}

	public void ExecuteUnloadPipes()
	{
	}

	public void OnSceneExit()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugPreviousOrLastTime()
	{
	}
}
