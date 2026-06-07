using System;
using System.Collections;
using AmplifyOcclusion;
using AwesomeTechnologies.VegetationSystem;
using DV;
using DV.Interaction.Inputs;
using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using PI.NGSS;
using SCPE;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GraphicsOptions : SingletonBehaviour<GraphicsOptions>
{
	public enum VegetationQuality
	{
		OFF = 0,
		MEGA_LOW = 1,
		VERY_LOW = 2,
		LOW = 3,
		MEDIUM = 4,
		HIGH = 5,
		VERY_HIGH = 6,
		ULTRA_HIGH = 7
	}

	public enum ShadowsQuality
	{
		OFF = 0,
		VERY_LOW = 1,
		LOW = 2,
		MEDIUM = 3,
		HIGH = 4,
		VERY_HIGH = 5,
		ULTRA_HIGH = 6
	}

	public enum TerrainLightingQuality
	{
		LOW = 0,
		MEDIUM = 1,
		HIGH = 2
	}

	public enum WaterReflectionQuality
	{
		VERY_LOW = 0,
		LOW = 1,
		MEDIUM = 2,
		HIGH = 3,
		VERY_HIGH = 4
	}

	public enum LightingQuality
	{
		LOW = 0,
		MEDIUM = 1,
		HIGH = 2
	}

	public enum AntiAliasingDeferred
	{
		OFF = 0,
		TAA = 1,
		FXAA = 2,
		SMAA = 3
	}

	public enum AntiAliasingForward
	{
		OFF = 0,
		X2 = 1,
		X4 = 2,
		X8 = 3
	}

	public enum AmbientOcclusionQuality
	{
		OFF = 0,
		LOW = 1,
		HIGH = 2
	}

	private static bool loadingExpected;

	public const string L_OFF = "settings/quality_level_off";

	public const string L_MEGA_LOW = "settings/quality_level_mega_low";

	public const string L_VERY_LOW = "settings/quality_level_very_low";

	public const string L_LOW = "settings/quality_level_low";

	public const string L_MEDIUM = "settings/quality_level_medium";

	public const string L_HIGH = "settings/quality_level_high";

	public const string L_VERY_HIGH = "settings/quality_level_very_high";

	public const string L_ULTRA_HIGH = "settings/quality_level_ultra_high";

	public const string L_NORMAL = "settings/quality_level_normal";

	public const string L_ULTRA = "settings/quality_level_ultra";

	public readonly string[] VegetationQuality_LOC = new string[8] { "settings/quality_level_off", "settings/quality_level_mega_low", "settings/quality_level_very_low", "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high", "settings/quality_level_very_high", "settings/quality_level_ultra_high" };

	public readonly string[] ShadowsQuality_LOC = new string[7] { "settings/quality_level_off", "settings/quality_level_very_low", "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high", "settings/quality_level_very_high", "settings/quality_level_ultra_high" };

	public readonly string[] TerrainLightingQuality_LOC = new string[3] { "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high" };

	public readonly string[] RainQuality_LOC = new string[4] { "settings/quality_level_off", "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high" };

	public readonly string[] WaterReflectionQuality_LOC = new string[5] { "settings/quality_level_very_low", "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high", "settings/quality_level_very_high" };

	public readonly string[] LightingQuality_LOC = new string[3] { "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high" };

	public readonly string[] AntiAliasingDeferred_LOC = new string[4] { "settings/antialiasing_off", "settings/antialiasing_taa", "settings/antialiasing_fxaa", "settings/antialiasing_smaa" };

	public readonly string[] AntiAliasingForward_LOC = new string[4] { "settings/antialiasing_off", "settings/antialiasing_2x", "settings/antialiasing_4x", "settings/antialiasing_8x" };

	public readonly string[] AmbientOcclusionQuality_LOC = new string[3] { "settings/quality_level_off", "settings/quality_level_low", "settings/quality_level_high" };

	public readonly string[] DetailLevelLodBias_LOC = new string[3] { "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high" };

	public readonly string[] AnisotropicLevel_LOC = new string[3] { "settings/quality_level_low", "settings/quality_level_medium", "settings/quality_level_high" };

	private MotionBlur motionBlur;

	private Option<PostProcessVolume> _globalPostProcessVolume;

	private bool isForwardRendering;

	private VegetationSystemPro vs;

	private Coroutine coro;

	private Coroutine lightWaitingCoro;

	private bool isInGameWorld;

	public Option<PostProcessVolume> GlobalPostProcessVolume
	{
		get
		{
			if (_globalPostProcessVolume.IsNone() && isInGameWorld)
			{
				_globalPostProcessVolume = GameObject.Find("[GlobalPostProcessing]")?.GetComponent<PostProcessVolume>();
			}
			return _globalPostProcessVolume;
		}
	}

	public bool IsForwardRendering
	{
		get
		{
			return isForwardRendering;
		}
		private set
		{
			if (value != isForwardRendering)
			{
				isForwardRendering = value;
				OnPreferenceUpdated();
				this.OnForwardRenderingChanged?.Invoke();
			}
		}
	}

	public bool IsPostProcessingOn => GamePreferences.Get<bool>(Preferences.PostProcessing);

	public bool IsBlobOcclusionOn => GamePreferences.Get<int>(Preferences.AmbientOcclusionQualityIndex) >= 1;

	public bool IsSSAOOn => GamePreferences.Get<int>(Preferences.AmbientOcclusionQualityIndex) >= 2;

	public bool IsMotionBlurOn
	{
		get
		{
			if (!VRManager.IsVREnabled())
			{
				return GamePreferences.Get<bool>(Preferences.MotionBlur);
			}
			return false;
		}
	}

	public int MotionBlurReferenceFPS => GamePreferences.Get<int>(Preferences.MotionBlurReferenceFPS);

	public bool PauseInBackground { get; private set; }

	public bool RunInBackgroundWhilePaused { get; set; }

	private float DetailLodBiasLevel
	{
		get
		{
			float[] array = new float[3] { 1f, 2f, 3f };
			int value = GamePreferences.Get<int>(Preferences.DetailLevel);
			return array[Mathf.Clamp(value, 0, array.Length - 1)];
		}
	}

	private int AnisotropicFilteringIndex
	{
		get
		{
			int num = GamePreferences.Get<int>(Preferences.AnisotropicFiltering);
			if (!Enum.IsDefined(typeof(AnisotropicFiltering), num))
			{
				return 1;
			}
			return num;
		}
	}

	private VegetationQuality VegetationQualityLevel
	{
		get
		{
			int num = GamePreferences.Get<int>(Preferences.VegetationQualityIndex);
			if (!Enum.IsDefined(typeof(VegetationQuality), num))
			{
				return VegetationQuality.HIGH;
			}
			return (VegetationQuality)num;
		}
	}

	private ShadowsQuality ShadowsQualityLevel
	{
		get
		{
			int num = GamePreferences.Get<int>(Preferences.ShadowsQualityIndex);
			if (!Enum.IsDefined(typeof(ShadowsQuality), num))
			{
				return ShadowsQuality.VERY_HIGH;
			}
			return (ShadowsQuality)num;
		}
	}

	public WaterReflectionQuality WaterReflectionQualityLevel
	{
		get
		{
			int num = GamePreferences.Get<int>(Preferences.ReflectionQualityIndex);
			if (!Enum.IsDefined(typeof(WaterReflectionQuality), num))
			{
				return WaterReflectionQuality.HIGH;
			}
			return (WaterReflectionQuality)num;
		}
	}

	public LightingQuality LightingQualityLevel
	{
		get
		{
			int num = GamePreferences.Get<int>(Preferences.LightingQualityIndex);
			if (!Enum.IsDefined(typeof(LightingQuality), num))
			{
				return LightingQuality.HIGH;
			}
			return (LightingQuality)num;
		}
	}

	public TerrainLightingQuality TerrainLightingQualityLevel
	{
		get
		{
			int num = GamePreferences.Get<int>(Preferences.TerrainLightingQualityIndex);
			if (!Enum.IsDefined(typeof(TerrainLightingQuality), num))
			{
				return TerrainLightingQuality.MEDIUM;
			}
			return (TerrainLightingQuality)num;
		}
	}

	public event Action OnForwardRenderingChanged;

	public new static string AllowAutoCreate()
	{
		return "[GraphicsOptions]";
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Init()
	{
		loadingExpected = false;
	}

	private void Start()
	{
		isInGameWorld = SceneSwitcher.IsInGameWorld;
		UpdateAllExceptVegetationLevel();
		UpdateVegetationLevel();
		if (!vs)
		{
			StartCoroutine(UpdateVegetationLevelDelayed());
		}
		SetupListeners(on: true);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		SetupListeners(on: false);
	}

	private void LateUpdate()
	{
		if (IsMotionBlurOn && GlobalPostProcessVolume.IsSome(out var value))
		{
			if (!motionBlur)
			{
				value.profile.TryGetSettings<MotionBlur>(out motionBlur);
				return;
			}
			if (MotionBlurReferenceFPS <= 0)
			{
				motionBlur.shutterAngle.Override(180f);
				return;
			}
			float num = 1f / Time.unscaledDeltaTime / (float)MotionBlurReferenceFPS;
			motionBlur.shutterAngle.Override(180f * num);
		}
	}

	private void UpdateAllExceptVegetationLevel()
	{
		UpdateBackgroundSetting();
		ShadowSettings.SetShadowSettings(ShadowsQualityLevel);
		UpdateAmbientOcclusion();
		UpdateTerrainLighting();
		UpdatePostProcessing();
		UpdateDetailLevelLodBias();
		UpdateAnisotropic();
		UpdateTextureStreaming();
		UpdateShadows();
	}

	private void SetupListeners(bool on)
	{
		GamePreferences.RegisterToUpdateIfEligible(Preferences.PauseInBackground, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.AnisotropicFiltering, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.ShadowsQualityIndex, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.AntiAliasingForwardLevelsIndex, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.AntiAliasingDeferredLevelsIndex, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.DetailLevel, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.PostProcessing, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.MotionBlur, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.AmbientOcclusionQualityIndex, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.TextureStreamingEnabled, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.TextureStreamingMemoryBudget, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.TerrainLightingQualityIndex, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.ShadowsQualityIndex, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.VegetationQualityIndex, UpdateVegetationLevel, on);
		if (on)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused += UpdateRunInBackground;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += UpdateRunInBackground;
			SingletonBehaviour<LoadingScreenManager>.Instance.LoadingStateChanged += UpdateRunInBackground;
			PlayerManager.PlayerChanged += UpdateAllExceptVegetationLevel;
			UnloadWatcher.UnloadRequested += UpdateRunInBackground;
			SceneSwitcher.SceneRequested += OnSceneSwitchRequested;
			return;
		}
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= UpdateRunInBackground;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= UpdateRunInBackground;
			SingletonBehaviour<LoadingScreenManager>.Instance.LoadingStateChanged -= UpdateRunInBackground;
		}
		PlayerManager.PlayerChanged -= UpdateAllExceptVegetationLevel;
		UnloadWatcher.UnloadRequested -= UpdateRunInBackground;
		SceneSwitcher.SceneRequested -= OnSceneSwitchRequested;
	}

	private void OnSceneSwitchRequested(DVScenes scene)
	{
		if (scene == DVScenes.Game || scene == DVScenes.MainMenu)
		{
			loadingExpected = true;
			Application.runInBackground = true;
			UpdateRunInBackground();
		}
	}

	private void OnPreferenceUpdated()
	{
		if (coro == null)
		{
			coro = StartCoroutine(UpdateAllAtEndOfFrame());
		}
	}

	private IEnumerator UpdateAllAtEndOfFrame()
	{
		yield return WaitFor.EndOfFrame;
		coro = null;
		UpdateAllExceptVegetationLevel();
	}

	public void UpdateBackgroundSetting()
	{
		PauseInBackground = !PreferencesUtils.IsExcluded(Preferences.PauseInBackground) && GamePreferences.Get<bool>(Preferences.PauseInBackground);
		UpdateRunInBackground();
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		UpdateRunInBackground();
		if (!hasFocus && PauseInBackground && !LoadingScreenManager.IsLoading)
		{
			SingletonBehaviour<AppUtil>.Instance.PauseGame();
		}
	}

	private IEnumerator PauseLater()
	{
		yield return null;
		SingletonBehaviour<AppUtil>.Instance.PauseGame();
	}

	private void UpdateRunInBackground()
	{
		if (LoadingScreenManager.IsLoading)
		{
			loadingExpected = false;
		}
		bool flag = !PauseInBackground || Application.isFocused;
		if (!RunInBackgroundWhilePaused && SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen && !Application.isFocused)
		{
			flag = false;
		}
		if (!flag && !VRManager.IsVREnabled())
		{
			InputManager.Actions.pausedInBackground = true;
		}
		else
		{
			StartCoroutine(RestorePausedInBackground());
		}
		if (LoadingScreenManager.IsLoading || loadingExpected)
		{
			flag = true;
		}
		if (UnloadWatcher.isQuitting)
		{
			flag = true;
		}
		Application.runInBackground = flag || VRManager.IsVREnabled();
	}

	private IEnumerator RestorePausedInBackground()
	{
		yield return WaitFor.EndOfFrame;
		InputManager.Actions.pausedInBackground = false;
	}

	private void UpdatePostProcessing()
	{
		if (GlobalPostProcessVolume.IsSome(out var value))
		{
			bool isPostProcessingOn = IsPostProcessingOn;
			if (value.profile.TryGetSettings<Bloom>(out var outSetting))
			{
				outSetting.active = isPostProcessingOn;
			}
			else
			{
				Debug.LogError("Couldn't find Bloom on GlobalPostProcessing prefab!");
			}
			if (value.profile.TryGetSettings<AutoExposure>(out var outSetting2))
			{
				outSetting2.active = false;
			}
			else
			{
				Debug.LogError("Couldn't find AutoExposure on GlobalPostProcessing prefab!");
			}
			if (value.profile.TryGetSettings<Sunshafts>(out var outSetting3))
			{
				outSetting3.active = isPostProcessingOn;
			}
			else
			{
				Debug.LogError("Couldn't find Sunshafts on GlobalPostProcessing prefab!");
			}
			if (value.profile.TryGetSettings<ColorGrading>(out var outSetting4))
			{
				outSetting4.active = isPostProcessingOn;
			}
			else
			{
				Debug.LogError("Couldn't find ColorGrading on GlobalPostProcessing prefab!");
			}
			if (value.profile.TryGetSettings<MotionBlur>(out var outSetting5))
			{
				outSetting5.active = IsMotionBlurOn && !VRManager.IsVREnabled();
			}
			else
			{
				Debug.LogError("Couldn't find MotionBlur on GlobalPostProcessing prefab!");
			}
		}
	}

	private void UpdateAmbientOcclusion()
	{
		if (GlobalPostProcessVolume.IsSome(out var value))
		{
			bool flag = IsBlobOcclusionOn && !IsForwardRendering;
			bool active = IsSSAOOn && !IsForwardRendering;
			if (value.profile.TryGetSettings<AmplifyOcclusionEffect>(out var outSetting))
			{
				outSetting.active = active;
			}
			else
			{
				Debug.LogError("Couldn't find AmplifyOcclusionEffect on GlobalPostProcessing prefab!");
			}
			SingletonBehaviour<DeferredDecalRenderer>.Instance.enabled = flag;
		}
	}

	private void UpdateTerrainLighting()
	{
		if ((bool)SingletonBehaviour<ShadowTracer>.Instance)
		{
			SingletonBehaviour<ShadowTracer>.Instance.AORenderer = GamePreferences.Get<int>(Preferences.TerrainLightingQualityIndex) >= 1;
			SingletonBehaviour<ShadowTracer>.Instance.ShadowTracing = GamePreferences.Get<int>(Preferences.TerrainLightingQualityIndex) >= 2;
		}
	}

	public void UpdateShadows()
	{
		int num = GamePreferences.Get<int>(Preferences.ShadowsQualityIndex);
		SetScreenSpaceShadowsState(num >= ShadowsQuality_LOC.Length - 2, num >= ShadowsQuality_LOC.Length - 1);
	}

	private IEnumerator WaitForLightSourceAndUpdateShadows(bool state, bool highQuality)
	{
		while (!SingletonBehaviour<WeatherDriver>.Instance.manager.LightSource)
		{
			yield return null;
		}
		SetScreenSpaceShadowsState(state, highQuality);
	}

	public void SetScreenSpaceShadowsState(bool state, bool highQuality)
	{
		NGSS_FrustumShadows instance = NGSS_FrustumShadows.instance;
		if (!instance)
		{
			return;
		}
		if (lightWaitingCoro != null)
		{
			StopCoroutine(lightWaitingCoro);
			lightWaitingCoro = null;
		}
		if (state)
		{
			if (!SingletonBehaviour<WeatherDriver>.Instance.manager.LightSource)
			{
				lightWaitingCoro = StartCoroutine(WaitForLightSourceAndUpdateShadows(state, highQuality));
				return;
			}
			instance.mainShadowsLight = SingletonBehaviour<WeatherDriver>.Instance.manager.LightSource;
			if (highQuality)
			{
				instance.m_raySamples = 32;
				instance.m_rayScale = 0.4f;
			}
			else
			{
				instance.m_raySamples = 16;
				instance.m_rayScale = 0.3f;
			}
			instance.enabled = true;
		}
		else
		{
			instance.enabled = false;
			instance.mainShadowsLight = null;
		}
	}

	private void UpdateAnisotropic()
	{
		QualitySettings.anisotropicFiltering = (AnisotropicFiltering)AnisotropicFilteringIndex;
	}

	private void UpdateTextureStreaming()
	{
		QualitySettings.streamingMipmapsActive = GamePreferences.Get<bool>(Preferences.TextureStreamingEnabled);
		float num = Mathf.Clamp01(GamePreferences.Get<float>(Preferences.TextureStreamingMemoryBudget));
		QualitySettings.streamingMipmapsMemoryBudget = Mathf.Round((float)SystemInfo.graphicsMemorySize * num);
		Debug.Log(string.Format("Texture streaming is {0}. Memory budget is {1} ({2}%)", QualitySettings.streamingMipmapsActive ? "enabled" : "disabled", QualitySettings.streamingMipmapsMemoryBudget, Mathf.Round(num * 100f)));
	}

	private void UpdateDetailLevelLodBias()
	{
		QualitySettings.lodBias = DetailLodBiasLevel;
	}

	private IEnumerator UpdateVegetationLevelDelayed()
	{
		while (!WorldStreamingInit.IsLoaded)
		{
			yield return null;
		}
		UpdateVegetationLevel();
	}

	private void UpdateVegetationLevel()
	{
		if (!vs)
		{
			vs = UnityEngine.Object.FindObjectOfType<VegetationSystemPro>();
			if (!vs)
			{
				return;
			}
		}
		VegetationQuality vegetationQualityLevel = VegetationQualityLevel;
		switch (vegetationQualityLevel)
		{
		case VegetationQuality.OFF:
			vs.enabled = false;
			return;
		case VegetationQuality.MEGA_LOW:
			vs.VegetationSettings.LODDistanceFactor = 0.2f;
			vs.VegetationSettings.PlantDistance = 0f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 100f;
			vs.VegetationSettings.AdditionalBillboardDistance = 200f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 0f;
			vs.VegetationSettings.PlantDensity = 0.5f;
			vs.VegetationSettings.TreeDensity = 0.5f;
			vs.VegetationSettings.LargeObjectDensity = 0.5f;
			vs.enabled = true;
			break;
		case VegetationQuality.VERY_LOW:
			vs.VegetationSettings.LODDistanceFactor = 0.3f;
			vs.VegetationSettings.PlantDistance = 60f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 100f;
			vs.VegetationSettings.AdditionalBillboardDistance = 300f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 0.7f;
			vs.VegetationSettings.PlantDensity = 0.7f;
			vs.VegetationSettings.TreeDensity = 0.7f;
			vs.VegetationSettings.LargeObjectDensity = 0.7f;
			vs.enabled = true;
			break;
		case VegetationQuality.LOW:
			vs.VegetationSettings.LODDistanceFactor = 0.4f;
			vs.VegetationSettings.PlantDistance = 80f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 130f;
			vs.VegetationSettings.AdditionalBillboardDistance = 400f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 0.8f;
			vs.VegetationSettings.PlantDensity = 0.8f;
			vs.VegetationSettings.TreeDensity = 0.7f;
			vs.VegetationSettings.LargeObjectDensity = 0.8f;
			vs.enabled = true;
			break;
		case VegetationQuality.MEDIUM:
			vs.VegetationSettings.LODDistanceFactor = 0.5f;
			vs.VegetationSettings.PlantDistance = 100f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 150f;
			vs.VegetationSettings.AdditionalBillboardDistance = 400f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 0.9f;
			vs.VegetationSettings.PlantDensity = 0.9f;
			vs.VegetationSettings.TreeDensity = 0.8f;
			vs.VegetationSettings.LargeObjectDensity = 0.8f;
			vs.enabled = true;
			break;
		case VegetationQuality.HIGH:
			vs.VegetationSettings.LODDistanceFactor = 0.7f;
			vs.VegetationSettings.PlantDistance = 150f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 250f;
			vs.VegetationSettings.AdditionalBillboardDistance = 400f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 1f;
			vs.VegetationSettings.PlantDensity = 1f;
			vs.VegetationSettings.TreeDensity = 1f;
			vs.VegetationSettings.LargeObjectDensity = 1f;
			vs.enabled = true;
			break;
		case VegetationQuality.VERY_HIGH:
			vs.VegetationSettings.LODDistanceFactor = 1f;
			vs.VegetationSettings.PlantDistance = 200f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 300f;
			vs.VegetationSettings.AdditionalBillboardDistance = 400f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 1f;
			vs.VegetationSettings.PlantDensity = 1f;
			vs.VegetationSettings.TreeDensity = 1f;
			vs.VegetationSettings.LargeObjectDensity = 1f;
			vs.enabled = true;
			break;
		case VegetationQuality.ULTRA_HIGH:
			vs.VegetationSettings.LODDistanceFactor = 3f;
			vs.VegetationSettings.PlantDistance = 250f;
			vs.VegetationSettings.AdditionalTreeMeshDistance = 350f;
			vs.VegetationSettings.AdditionalBillboardDistance = 500f;
			vs.VegetationSettings.GrassShadows = false;
			vs.VegetationSettings.PlantShadows = false;
			vs.VegetationSettings.TreeShadows = true;
			vs.VegetationSettings.ObjectShadows = true;
			vs.VegetationSettings.LargeObjectShadows = true;
			vs.VegetationSettings.BillboardShadows = false;
			vs.VegetationSettings.GrassDensity = 1f;
			vs.VegetationSettings.PlantDensity = 1f;
			vs.VegetationSettings.TreeDensity = 1f;
			vs.VegetationSettings.LargeObjectDensity = 1f;
			vs.enabled = true;
			break;
		default:
			Debug.LogError($"Unhandled vegetation level {vegetationQualityLevel}");
			break;
		}
		vs.ClearCache();
		vs.RefreshTerrainHeightmap();
		vs.RefreshMaterials();
	}

	public void SetForwardRendering(bool on)
	{
		IsForwardRendering = on;
	}
}
