using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dorfromantik;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsRouter : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Resolution, Resolution> _003C_003E9__221_0;

		public static Func<Resolution, bool> _003C_003E9__221_1;

		internal Resolution _003CSetupAwake_003Eb__221_0(Resolution resolution)
		{
			return new Resolution
			{
				width = resolution.width,
				height = resolution.height
			};
		}

		internal bool _003CSetupAwake_003Eb__221_1(Resolution x)
		{
			if (x.width >= 640)
			{
				return x.height >= 400;
			}
			return false;
		}
	}

	public static bool InstancingEnabled;

	[SerializeField]
	private AudioMixer audioMixer;

	[SerializeField]
	private AnimationCurve volumeCurve;

	[SerializeField]
	private UniversalRendererData urpRenderer;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private UiScalingManager scalingManager;

	[SerializeField]
	private InputActionReference cameraMovementAction;

	[SerializeField]
	private InputActionReference tileSlotSelectionMovementAction;

	public DefaultSettings defaultSettings;

	[SerializeField]
	private Vector2 minMaxMasterVolume = new Vector2(-80f, 13f);

	[SerializeField]
	private Material preplacedTileMaterial;

	[SerializeField]
	private Material preplacedTileMaterialWithoutPostProcessing;

	public bool instancingEnabled;

	public bool displaySaveFileNames;

	private bool _003CIsFullscreen_003Ek__BackingField;

	private List<Resolution> _003CAvailableResolutions_003Ek__BackingField;

	private int _003CAntiAliasingLevel_003Ek__BackingField;

	private bool _003CPostProcessingEnabled_003Ek__BackingField;

	private bool _003CDecorationEnabled_003Ek__BackingField;

	private bool _003CTranslucentUiEnabled_003Ek__BackingField;

	private int _003CVsyncLevel_003Ek__BackingField;

	private bool _003CDynamicBackgroundEnabled_003Ek__BackingField;

	private int _003CQualityLevel_003Ek__BackingField;

	private Resolution _003CCurrentResolution_003Ek__BackingField;

	private static int _003CMeshQualityLevel_003Ek__BackingField;

	private UiScalingLevelId _003CUiScale_003Ek__BackingField;

	private float _003CMasterVolume_003Ek__BackingField;

	private float _003CMusicVolume_003Ek__BackingField;

	private float _003CFxVolume_003Ek__BackingField;

	private bool _003CPlacingTilesWithClick_003Ek__BackingField;

	private int _003CCameraSpeedLevel_003Ek__BackingField;

	private int _003CCameraRotationSpeedLevel_003Ek__BackingField;

	private int _003CCameraZoomSpeedLevel_003Ek__BackingField;

	private bool _003CIngameUiVisible_003Ek__BackingField;

	private bool _003CDebugUiVisible_003Ek__BackingField;

	private int _003CTooltipLevel_003Ek__BackingField;

	private bool _003CRunInBackground_003Ek__BackingField;

	private bool _003CHighlightingMatchingEdges_003Ek__BackingField;

	private int _003CMaxZoomOutDistance_003Ek__BackingField;

	private bool _003CAllTilesCountAsPerfect_003Ek__BackingField;

	private bool _003CInstanceDrawerEnabled_003Ek__BackingField = true;

	private bool _003CFocusBiomeEnabled_003Ek__BackingField = true;

	private bool _003CDisableAntiAliasingWhenCameraMoves_003Ek__BackingField = true;

	private bool _003CAutomaticallyHighlightOffscreenQuestsWhenPreviewingTile_003Ek__BackingField = true;

	private bool _003CScaleQuestsByScreenPos_003Ek__BackingField;

	private bool _003CIsChallengeInfoSectionExpanded_003Ek__BackingField;

	public EventBroadcaster<bool> eventBroadcaster_onEnableDecorationSystem = new EventBroadcaster<bool>();

	public bool IsFullscreen
	{
		get
		{
			return _003CIsFullscreen_003Ek__BackingField;
		}
		private set
		{
			_003CIsFullscreen_003Ek__BackingField = value;
		}
	}

	public List<Resolution> AvailableResolutions
	{
		get
		{
			return _003CAvailableResolutions_003Ek__BackingField;
		}
		private set
		{
			_003CAvailableResolutions_003Ek__BackingField = value;
		}
	}

	public int AntiAliasingLevel
	{
		get
		{
			return _003CAntiAliasingLevel_003Ek__BackingField;
		}
		private set
		{
			_003CAntiAliasingLevel_003Ek__BackingField = value;
		}
	}

	public bool PostProcessingEnabled
	{
		get
		{
			return _003CPostProcessingEnabled_003Ek__BackingField;
		}
		private set
		{
			_003CPostProcessingEnabled_003Ek__BackingField = value;
		}
	}

	public bool DecorationEnabled
	{
		get
		{
			return _003CDecorationEnabled_003Ek__BackingField;
		}
		private set
		{
			_003CDecorationEnabled_003Ek__BackingField = value;
		}
	}

	public bool TranslucentUiEnabled
	{
		get
		{
			return _003CTranslucentUiEnabled_003Ek__BackingField;
		}
		private set
		{
			_003CTranslucentUiEnabled_003Ek__BackingField = value;
		}
	}

	public int VsyncLevel
	{
		get
		{
			return _003CVsyncLevel_003Ek__BackingField;
		}
		private set
		{
			_003CVsyncLevel_003Ek__BackingField = value;
		}
	}

	public bool DynamicBackgroundEnabled
	{
		get
		{
			return _003CDynamicBackgroundEnabled_003Ek__BackingField;
		}
		private set
		{
			_003CDynamicBackgroundEnabled_003Ek__BackingField = value;
		}
	}

	public int QualityLevel
	{
		get
		{
			return _003CQualityLevel_003Ek__BackingField;
		}
		private set
		{
			_003CQualityLevel_003Ek__BackingField = value;
		}
	}

	public Resolution CurrentResolution
	{
		get
		{
			return _003CCurrentResolution_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentResolution_003Ek__BackingField = value;
		}
	}

	public static int MeshQualityLevel
	{
		get
		{
			return _003CMeshQualityLevel_003Ek__BackingField;
		}
		private set
		{
			_003CMeshQualityLevel_003Ek__BackingField = value;
		}
	}

	public UiScalingLevelId UiScale
	{
		get
		{
			return _003CUiScale_003Ek__BackingField;
		}
		private set
		{
			_003CUiScale_003Ek__BackingField = value;
		}
	}

	public float MasterVolume
	{
		get
		{
			return _003CMasterVolume_003Ek__BackingField;
		}
		private set
		{
			_003CMasterVolume_003Ek__BackingField = value;
		}
	}

	public float MusicVolume
	{
		get
		{
			return _003CMusicVolume_003Ek__BackingField;
		}
		private set
		{
			_003CMusicVolume_003Ek__BackingField = value;
		}
	}

	public float FxVolume
	{
		get
		{
			return _003CFxVolume_003Ek__BackingField;
		}
		private set
		{
			_003CFxVolume_003Ek__BackingField = value;
		}
	}

	public bool PlacingTilesWithClick
	{
		get
		{
			return _003CPlacingTilesWithClick_003Ek__BackingField;
		}
		private set
		{
			_003CPlacingTilesWithClick_003Ek__BackingField = value;
		}
	}

	public int CameraSpeedLevel
	{
		get
		{
			return _003CCameraSpeedLevel_003Ek__BackingField;
		}
		private set
		{
			_003CCameraSpeedLevel_003Ek__BackingField = value;
		}
	}

	public int CameraRotationSpeedLevel
	{
		get
		{
			return _003CCameraRotationSpeedLevel_003Ek__BackingField;
		}
		private set
		{
			_003CCameraRotationSpeedLevel_003Ek__BackingField = value;
		}
	}

	public int CameraZoomSpeedLevel
	{
		get
		{
			return _003CCameraZoomSpeedLevel_003Ek__BackingField;
		}
		private set
		{
			_003CCameraZoomSpeedLevel_003Ek__BackingField = value;
		}
	}

	public bool IngameUiVisible
	{
		get
		{
			return _003CIngameUiVisible_003Ek__BackingField;
		}
		private set
		{
			_003CIngameUiVisible_003Ek__BackingField = value;
		}
	}

	public bool DebugUiVisible
	{
		get
		{
			return _003CDebugUiVisible_003Ek__BackingField;
		}
		private set
		{
			_003CDebugUiVisible_003Ek__BackingField = value;
		}
	}

	public int TooltipLevel
	{
		get
		{
			return _003CTooltipLevel_003Ek__BackingField;
		}
		private set
		{
			_003CTooltipLevel_003Ek__BackingField = value;
		}
	}

	public bool RunInBackground
	{
		get
		{
			return _003CRunInBackground_003Ek__BackingField;
		}
		private set
		{
			_003CRunInBackground_003Ek__BackingField = value;
		}
	}

	public bool HighlightingMatchingEdges
	{
		get
		{
			return _003CHighlightingMatchingEdges_003Ek__BackingField;
		}
		private set
		{
			_003CHighlightingMatchingEdges_003Ek__BackingField = value;
		}
	}

	public int MaxZoomOutDistance
	{
		get
		{
			return _003CMaxZoomOutDistance_003Ek__BackingField;
		}
		private set
		{
			_003CMaxZoomOutDistance_003Ek__BackingField = value;
		}
	}

	public bool AllTilesCountAsPerfect
	{
		get
		{
			return _003CAllTilesCountAsPerfect_003Ek__BackingField;
		}
		private set
		{
			_003CAllTilesCountAsPerfect_003Ek__BackingField = value;
		}
	}

	public bool InstanceDrawerEnabled
	{
		get
		{
			return _003CInstanceDrawerEnabled_003Ek__BackingField;
		}
		private set
		{
			_003CInstanceDrawerEnabled_003Ek__BackingField = value;
		}
	}

	public bool FocusBiomeEnabled
	{
		get
		{
			return _003CFocusBiomeEnabled_003Ek__BackingField;
		}
		private set
		{
			_003CFocusBiomeEnabled_003Ek__BackingField = value;
		}
	}

	public bool DisableAntiAliasingWhenCameraMoves
	{
		get
		{
			return _003CDisableAntiAliasingWhenCameraMoves_003Ek__BackingField;
		}
		private set
		{
			_003CDisableAntiAliasingWhenCameraMoves_003Ek__BackingField = value;
		}
	}

	public bool AutomaticallyHighlightOffscreenQuestsWhenPreviewingTile
	{
		get
		{
			return _003CAutomaticallyHighlightOffscreenQuestsWhenPreviewingTile_003Ek__BackingField;
		}
		private set
		{
			_003CAutomaticallyHighlightOffscreenQuestsWhenPreviewingTile_003Ek__BackingField = value;
		}
	}

	public bool ScaleQuestsByScreenPos
	{
		get
		{
			return _003CScaleQuestsByScreenPos_003Ek__BackingField;
		}
		private set
		{
			_003CScaleQuestsByScreenPos_003Ek__BackingField = value;
		}
	}

	public bool IsChallengeInfoSectionExpanded
	{
		get
		{
			return _003CIsChallengeInfoSectionExpanded_003Ek__BackingField;
		}
		private set
		{
			_003CIsChallengeInfoSectionExpanded_003Ek__BackingField = value;
		}
	}

	public bool PinChallengesEnabled => defaultSettings.pinChallengesEnabled;

	public event Action<bool> OnFullscreenChanged;

	public event Action<Resolution> OnResolutionChanged;

	public event Action<bool> OnPostProcessingEnabled;

	public event Action<int> OnQualityLevelChanged;

	public event Action<int> OnMeshQualityLevelChanged;

	public event Action<int> OnFpsCapChanged;

	public event Action<float> OnMasterVolumeChanged;

	public event Action<float> OnMusicVolumeChanged;

	public event Action<float> OnFxVolumeChanged;

	public event Action<Language> OnLanguageChanged;

	public event Action<bool> OnShowIngameUi;

	public event Action<bool> OnShowDebugUi;

	public event Action<bool> OnEnableDecorationSystem;

	public event Action<bool> OnEnableDynamicBackground;

	public event Action<int> OnVsyncLevelChanged;

	public event Action<bool> OnTranslucentUiEnabled;

	public event Action<int> OnAntiAliasingChanged;

	public event Action<bool> OnPlaceTileWithClickChanged;

	public event Action<int> OnCameraSpeedLevelChanged;

	public event Action<int> OnCameraRotationSpeedLevelChanged;

	public event Action<int> OnCameraZoomSpeedLevelChanged;

	public event Action<bool> OnSetRunInBackground;

	public event Action<bool> OnHighlightMatchingEdgesChanged;

	public event Action<bool> OnLoadingAllAtOnceChanged;

	public event Action<UiScalingLevelId> OnUiScaleChanged;

	public void SetupAwake()
	{
		InstancingEnabled = instancingEnabled;
		AvailableResolutions = new List<Resolution>(Screen.resolutions);
		AvailableResolutions = Enumerable.ToList(Enumerable.Distinct(Enumerable.Where(Enumerable.Select(AvailableResolutions, (Resolution resolution) => new Resolution
		{
			width = resolution.width,
			height = resolution.height
		}), (Resolution x) => x.width >= 640 && x.height >= 400)));
		AvailableResolutions.Reverse();
		CurrentResolution = Screen.currentResolution;
		IsFullscreen = Screen.fullScreen;
		InitializeQualityLevel(PlayerPrefsAccessor.GetInt("QualityLevel", defaultSettings.qualityLevel));
		SetMeshQualityLevel(PlayerPrefsAccessor.GetInt(Constants.Settings.Graphics.MeshQualityLevel, defaultSettings.meshQualityLevel));
		SetPostProcessingEnabled(PlayerPrefsAccessor.GetInt("PostProcessingEnabled", defaultSettings.postProcessingEnabled) == 1);
		SetAntialisingLevel(PlayerPrefsAccessor.GetInt("Antialiasing", defaultSettings.antiAliasingLevel));
		EnableTranslucentUI(PlayerPrefsAccessor.GetInt("TranslucentUiEnabled", defaultSettings.translucentUiEnabled) == 1);
		SetVsyncLevel(PlayerPrefsAccessor.GetInt("VsyncCount", defaultSettings.vsyncLevel));
		EnableDynamicBackground(PlayerPrefsAccessor.GetInt(Constants.Settings.Graphics.DynamicBackgroundEnabled, defaultSettings.dynamicBackgroundEnabled) == 1);
		DisableAntiAliasingWhileCameraMoves(PlayerPrefsAccessor.GetInt(Constants.Settings.Graphics.DisableAAWhileMovingCam, defaultSettings.disableAAWhileMovingCam) == 1);
		SetUiScale(PlayerPrefs.GetInt(Constants.Settings.Graphics.UiScale, (int)defaultSettings.uiScalingLevelId));
		SetMasterVolume(PlayerPrefsAccessor.GetFloat("MasterVolume2", defaultSettings.masterVolume));
		SetMusicVolume(PlayerPrefsAccessor.GetFloat("MusicVolume2", defaultSettings.musicVolume));
		SetFxVolume(PlayerPrefsAccessor.GetFloat("FxVolume2", defaultSettings.fxVolume));
		SetPlacingTilesWithClick(PlayerPrefsAccessor.GetInt("PlacingTilesWithClick", defaultSettings.placingTilesWithClick) == 1);
		SetCameraSpeed(PlayerPrefsAccessor.GetInt("CameraSpeed", defaultSettings.cameraSpeedLevel));
		SetCameraRotationSpeed(PlayerPrefsAccessor.GetInt("CameraRotationSpeed", defaultSettings.cameraRotationSpeedLevel));
		SetCameraZoomSpeed(PlayerPrefsAccessor.GetInt("CameraZoomSpeed", defaultSettings.cameraZoomSpeedLevel));
		ShowDebugUI(newActive: false);
		ShowIngameUI(newActive: true);
		SetTooltipLevel(PlayerPrefsAccessor.GetInt("TooltipLevel", defaultSettings.tooltipLevel));
		SetRunInBackground(PlayerPrefsAccessor.GetInt("RunInBackground", defaultSettings.runInBackground) == 1);
		SetHighlightMatchingEdges(PlayerPrefsAccessor.GetInt("HighlightMatchingEdges", defaultSettings.highlightMatchingEdges) == 1);
		SetChallengeInfoSectionExpanded(PlayerPrefs.GetInt("IsChallengeInfoSectionExpanded", 1) == 1);
		SetMaxZoomOutDistance(defaultSettings.maxZoomOutDistance);
	}

	public void SetMaxZoomOutDistance(int maxZoomOutDistance)
	{
		MaxZoomOutDistance = maxZoomOutDistance;
	}

	public void EnableDynamicBackground(bool shouldEnable)
	{
		DynamicBackgroundEnabled = shouldEnable;
		PlayerPrefsAccessor.SetInt(Constants.Settings.Graphics.DynamicBackgroundEnabled, shouldEnable ? 1 : 0);
		this.OnEnableDynamicBackground?.Invoke(DynamicBackgroundEnabled);
	}

	public void SetupStart()
	{
		EnableDecorationSystem(PlayerPrefsAccessor.GetInt("DecorationSystemEnabled", defaultSettings.decorationEnabled) == 1);
	}

	public void SetupEventBroadcasters()
	{
		eventBroadcaster_onEnableDecorationSystem = new EventBroadcaster<bool>();
	}

	private void DebugListenerCount()
	{
		Debug.Log(eventBroadcaster_onEnableDecorationSystem.ListenerCount);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Debug.Log("Set Fullscreen");
		IsFullscreen = isFullscreen;
		Screen.fullScreen = isFullscreen;
		if (isFullscreen)
		{
			ChangeResolution(0);
		}
		this.OnFullscreenChanged?.Invoke(isFullscreen);
	}

	public void ChangeResolution(int resolutionIndex)
	{
		Debug.Log($"Change Resolution to {AvailableResolutions[resolutionIndex]}");
		CurrentResolution = AvailableResolutions[resolutionIndex];
		Screen.SetResolution(CurrentResolution.width, CurrentResolution.height, IsFullscreen);
		this.OnResolutionChanged?.Invoke(CurrentResolution);
	}

	public void SetPostProcessingEnabled(bool newEnabled)
	{
		PostProcessingEnabled = newEnabled;
		PlayerPrefsAccessor.SetInt("PostProcessingEnabled", newEnabled ? 1 : 0);
		this.OnPostProcessingEnabled?.Invoke(newEnabled);
	}

	public void SetAntialisingLevel(int aliasingLevel)
	{
		PlayerPrefsAccessor.SetInt("Antialiasing", aliasingLevel);
		AntiAliasingLevel = aliasingLevel;
		UniversalRenderPipelineAsset universalRenderPipelineAsset = null;
		if (QualitySettings.renderPipeline is UniversalRenderPipelineAsset universalRenderPipelineAsset2)
		{
			universalRenderPipelineAsset = universalRenderPipelineAsset2;
		}
		else if (GraphicsSettings.renderPipelineAsset is UniversalRenderPipelineAsset universalRenderPipelineAsset3)
		{
			universalRenderPipelineAsset = universalRenderPipelineAsset3;
		}
		if (universalRenderPipelineAsset != null)
		{
			universalRenderPipelineAsset.msaaSampleCount = Constants.Settings.Graphics.AntiAliasingMultiplierByLevel[aliasingLevel];
		}
		this.OnAntiAliasingChanged?.Invoke(aliasingLevel);
	}

	private void InitializeQualityLevel(int qualityLevel)
	{
		QualityLevel = qualityLevel;
		QualitySettings.SetQualityLevel(Constants.Settings.Graphics.QualityLevelByInputLevel[qualityLevel]);
		PlayerPrefsAccessor.SetInt("QualityLevel", qualityLevel);
		this.OnQualityLevelChanged?.Invoke(qualityLevel);
	}

	public void SetMeshQualityLevel(int meshQualityLevel)
	{
		MeshQualityLevel = meshQualityLevel;
		PlayerPrefsAccessor.SetInt(Constants.Settings.Graphics.MeshQualityLevel, meshQualityLevel);
		this.OnMeshQualityLevelChanged?.Invoke(meshQualityLevel);
	}

	public void SetQualityLevelAndConnectedGraphicSettings(int qualityLevel)
	{
		QualityLevel = qualityLevel;
		QualitySettings.SetQualityLevel(Constants.Settings.Graphics.QualityLevelByInputLevel[qualityLevel]);
		PlayerPrefsAccessor.SetInt("QualityLevel", qualityLevel);
		this.OnQualityLevelChanged?.Invoke(qualityLevel);
		SetAntialisingLevel(Constants.Settings.Graphics.AntiAliasingLevelByQualityLevel[qualityLevel]);
		EnableDecorationSystem(qualityLevel < 2);
		SetPostProcessingEnabled(qualityLevel < 2);
		SetVsyncLevel(Constants.Settings.Graphics.VsyncLevelByQualityLevel[qualityLevel]);
		EnableTranslucentUI(qualityLevel < 2);
		SetMeshQualityLevel(Constants.Settings.Graphics.MeshQualityLevelByQualityLevel[qualityLevel]);
	}

	public void EnableDecorationSystem(bool newEnabled)
	{
		PlayerPrefsAccessor.SetInt("DecorationSystemEnabled", newEnabled ? 1 : 0);
		DecorationEnabled = newEnabled;
		eventBroadcaster_onEnableDecorationSystem.BroadcastToAllListeners(newEnabled);
		this.OnEnableDecorationSystem?.Invoke(newEnabled);
	}

	public void EnableTranslucentUI(bool newEnabled)
	{
		PlayerPrefsAccessor.SetInt("TranslucentUiEnabled", newEnabled ? 1 : 0);
		TranslucentUiEnabled = newEnabled;
		this.OnTranslucentUiEnabled?.Invoke(newEnabled);
	}

	public void SetVsyncLevel(int targetLevel)
	{
		int vSyncCount = Constants.Settings.Graphics.VsyncCountByLevel[targetLevel];
		PlayerPrefsAccessor.SetInt("VsyncCount", targetLevel);
		Application.targetFrameRate = 90;
		QualitySettings.vSyncCount = vSyncCount;
		VsyncLevel = targetLevel;
		this.OnVsyncLevelChanged?.Invoke(targetLevel);
	}

	public void SetUiScale(int targetScalingLevel)
	{
		UiScale = Constants.Settings.Graphics.UiScaleByLevel[targetScalingLevel];
		scalingManager.SetUiScalingLevel(UiScale);
		PlayerPrefsAccessor.SetInt(Constants.Settings.Graphics.UiScale, targetScalingLevel);
		this.OnUiScaleChanged?.Invoke(UiScale);
	}

	public void SetMasterVolume(float newMasterVolume)
	{
		MasterVolume = newMasterVolume;
		float t = volumeCurve.Evaluate(newMasterVolume);
		float value = Mathf.Lerp(minMaxMasterVolume.x, minMaxMasterVolume.y, t);
		audioMixer.SetFloat("MasterVolume", value);
		PlayerPrefsAccessor.SetFloat("MasterVolume2", newMasterVolume);
		this.OnMasterVolumeChanged?.Invoke(newMasterVolume);
	}

	public void SetMusicVolume(float newMusicVolume)
	{
		MusicVolume = newMusicVolume;
		float t = volumeCurve.Evaluate(newMusicVolume);
		float value = Mathf.Lerp(-80f, 0f, t);
		audioMixer.SetFloat("MusicVolume", value);
		PlayerPrefsAccessor.SetFloat("MusicVolume2", newMusicVolume);
		this.OnMusicVolumeChanged?.Invoke(newMusicVolume);
	}

	public void SetFxVolume(float newFxVolume)
	{
		FxVolume = newFxVolume;
		float t = volumeCurve.Evaluate(newFxVolume);
		float value = Mathf.Lerp(-80f, 0f, t);
		audioMixer.SetFloat("FxVolume", value);
		PlayerPrefsAccessor.SetFloat("FxVolume2", newFxVolume);
		this.OnFxVolumeChanged?.Invoke(newFxVolume);
	}

	public void SetPlacingTilesWithClick(bool shouldPlaceTilesWithClick)
	{
		PlacingTilesWithClick = shouldPlaceTilesWithClick;
		PlayerPrefsAccessor.SetInt("PlacingTilesWithClick", shouldPlaceTilesWithClick ? 1 : 0);
		this.OnPlaceTileWithClickChanged?.Invoke(PlacingTilesWithClick);
	}

	public void SetMouseSensitivity(float newMouseSensitivity)
	{
	}

	public void SetCameraSpeed(float newSpeed)
	{
		int num = (CameraSpeedLevel = Mathf.RoundToInt(newSpeed));
		PlayerPrefsAccessor.SetInt("CameraSpeed", num);
		this.OnCameraSpeedLevelChanged?.Invoke(num);
	}

	public void SetCameraRotationSpeed(float newSpeed)
	{
		int num = (CameraRotationSpeedLevel = Mathf.RoundToInt(newSpeed));
		PlayerPrefsAccessor.SetInt("CameraRotationSpeed", num);
		this.OnCameraRotationSpeedLevelChanged?.Invoke(num);
	}

	public void SetCameraZoomSpeed(float newSpeed)
	{
		int num = (CameraZoomSpeedLevel = Mathf.RoundToInt(newSpeed));
		PlayerPrefsAccessor.SetInt("CameraZoomSpeed", num);
		this.OnCameraZoomSpeedLevelChanged?.Invoke(num);
	}

	public void InvertRightJoystickXAxis(bool invertAxis)
	{
		InvertJoystickAxis(affectLeftJoystick: false, affectXAxis: true, invertAxis);
	}

	public void InvertRightJoystickYAxis(bool invertAxis)
	{
		InvertJoystickAxis(affectLeftJoystick: false, affectXAxis: false, invertAxis);
	}

	public void InvertLeftJoystickXAxis(bool invertAxis)
	{
		InvertJoystickAxis(affectLeftJoystick: true, affectXAxis: true, invertAxis);
	}

	public void InvertLeftJoystickYAxis(bool invertAxis)
	{
		InvertJoystickAxis(affectLeftJoystick: true, affectXAxis: false, invertAxis);
	}

	private void InvertJoystickAxis(bool affectLeftJoystick, bool affectXAxis, bool invert)
	{
		InputAction inputAction = (affectLeftJoystick ? tileSlotSelectionMovementAction.action : cameraMovementAction.action);
		int bindingIndex = InputActionRebindingExtensions.GetBindingIndex(inputAction, "Gamepad");
		string text = (affectXAxis ? "invertX" : "invertY");
		string text2 = (invert ? "false" : "true");
		string text3 = (invert ? "true" : "false");
		string path = inputAction.bindings[bindingIndex].path;
		string processors = inputAction.bindings[bindingIndex].processors;
		string effectivePath = inputAction.bindings[bindingIndex].effectivePath;
		string effectiveProcessors = inputAction.bindings[bindingIndex].effectiveProcessors;
		Debug.Log($"current processors for {inputAction} binding {bindingIndex}: {effectiveProcessors}\ntargetAxis: {text}, targetValue:{text3}");
		effectiveProcessors = effectiveProcessors.Replace(text + "=" + text2, text + "=" + text3);
		InputBinding binding = inputAction.bindings[bindingIndex];
		binding.overrideProcessors = effectiveProcessors;
		InputActionSetupExtensions.ChangeBinding(inputAction, bindingIndex).To(binding);
		Debug.Log("original binding path: " + path + " - currentBinding:" + effectivePath + "\noriginalProcessors: " + processors + " - modifiedProcessors: " + effectiveProcessors);
		Debug.Log("apply binding override: " + inputAction.bindings[bindingIndex].effectivePath + " with processors " + inputAction.bindings[bindingIndex].effectiveProcessors);
	}

	public void SwitchJoysticks(bool switchJoysticks)
	{
		Debug.Log($"Switch joysticks {switchJoysticks}");
		int bindingIndex = InputActionRebindingExtensions.GetBindingIndex(cameraMovementAction.action, "Gamepad");
		int bindingIndex2 = InputActionRebindingExtensions.GetBindingIndex(tileSlotSelectionMovementAction.action, "Gamepad");
		InputBinding inputBinding = tileSlotSelectionMovementAction.action.bindings[bindingIndex2];
		InputBinding inputBinding2 = cameraMovementAction.action.bindings[bindingIndex];
		Debug.Log("Original bindings:" + $"\n{cameraMovementAction} -> {cameraMovementAction.action.bindings[bindingIndex].path}" + $"\n{tileSlotSelectionMovementAction} -> {tileSlotSelectionMovementAction.action.bindings[bindingIndex2].path}");
		InputActionRebindingExtensions.ApplyBindingOverride(cameraMovementAction.action, switchJoysticks ? inputBinding.path : inputBinding2.path, inputBinding2.groups);
		InputActionRebindingExtensions.ApplyBindingOverride(tileSlotSelectionMovementAction.action, switchJoysticks ? inputBinding2.path : inputBinding.path, inputBinding.groups);
		Debug.Log("New bindings:" + $"\n{cameraMovementAction} -> {cameraMovementAction.action.bindings[bindingIndex].effectivePath}" + $"\n{tileSlotSelectionMovementAction} -> {tileSlotSelectionMovementAction.action.bindings[bindingIndex2].effectivePath}");
	}

	public void ChangeLanguage(Language targetLanguage)
	{
		PlayerPrefsAccessor.SetInt("Language", (int)targetLanguage);
		this.OnLanguageChanged?.Invoke(targetLanguage);
	}

	public void ChangeLanguageFromSettings(int availableLanguageIndex)
	{
		Language targetLanguage = LocalizationManager.Instance.AvailableLanguages[availableLanguageIndex];
		ChangeLanguage(targetLanguage);
	}

	public void SetTooltipLevel(int newTooltipLevel)
	{
		PlayerPrefsAccessor.SetInt("TooltipLevel", newTooltipLevel);
		TooltipLevel = newTooltipLevel;
	}

	public void ToggleIngameUI()
	{
		ShowIngameUI(!IngameUiVisible);
	}

	public void ShowIngameUI(bool newActive)
	{
		IngameUiVisible = newActive;
		if ((bool)Singleton<MainMenuUi>.Instance && rewardSystem.IsGameOver && (bool)OverwritingSingleton<GameSession>.Instance && OverwritingSingleton<GameSession>.Instance.GameMode.doesTriggerGameOver)
		{
			Singleton<MainMenuUi>.Instance.ShowScoreScreen(newActive, inputRouter.GameState == GameState.NavigationBar || !newActive);
		}
		this.OnShowIngameUi?.Invoke(newActive);
	}

	public void ShowDebugUI(bool newActive)
	{
		DebugUiVisible = newActive;
		this.OnShowDebugUi?.Invoke(newActive);
	}

	public void SetRunInBackground(bool runInBackground)
	{
		RunInBackground = runInBackground;
		Application.runInBackground = RunInBackground;
		PlayerPrefsAccessor.SetInt("RunInBackground", RunInBackground ? 1 : 0);
		this.OnSetRunInBackground?.Invoke(RunInBackground);
	}

	public void SetHighlightMatchingEdges(bool highlightMatchingEdges)
	{
		HighlightingMatchingEdges = highlightMatchingEdges;
		PlayerPrefsAccessor.SetInt("HighlightMatchingEdges", HighlightingMatchingEdges ? 1 : 0);
		this.OnHighlightMatchingEdgesChanged?.Invoke(HighlightingMatchingEdges);
	}

	public Material GetPreviewTileMaterial()
	{
		if (!PostProcessingEnabled)
		{
			return preplacedTileMaterialWithoutPostProcessing;
		}
		return preplacedTileMaterial;
	}

	public void EnableAllTilesPerfect(bool enable)
	{
		AllTilesCountAsPerfect = enable;
	}

	public void EnableFocusBiomeUpdater(bool enable)
	{
		FocusBiomeEnabled = enable;
	}

	public void EnableInstanceDrawer(bool enable)
	{
		InstanceDrawerEnabled = enable;
	}

	public void DisableAntiAliasingWhileCameraMoves(bool disable)
	{
		DisableAntiAliasingWhenCameraMoves = disable;
		PlayerPrefsAccessor.SetInt(Constants.Settings.Graphics.DisableAAWhileMovingCam, DisableAntiAliasingWhenCameraMoves ? 1 : 0);
	}

	public void SetAutomaticallyHighlightOffscreenQuestsWhenPreviewingTile(bool value)
	{
		AutomaticallyHighlightOffscreenQuestsWhenPreviewingTile = value;
	}

	public void SetScaleQuestsByScreenPos(bool value)
	{
		ScaleQuestsByScreenPos = value;
	}

	public Dictionary<string, string> GetAllSettings()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{
				"dorfromantik.isFullscreen",
				IsFullscreen.ToString()
			},
			{
				"dorfromantik.resolution",
				CurrentResolution.ToString()
			},
			{
				"dorfromantik.antiAliasingLevel",
				AntiAliasingLevel.ToString()
			},
			{
				"dorfromantik.postProcessingEnabled",
				PostProcessingEnabled.ToString()
			},
			{
				"dorfromantik.decorationEnabled",
				DecorationEnabled.ToString()
			},
			{
				"dorfromantik.translucentUiEnabled",
				TranslucentUiEnabled.ToString()
			},
			{
				"dorfromantik.vSyncLevel",
				VsyncLevel.ToString()
			},
			{
				"dorfromantik.dynamicBackgroundEnabled",
				DynamicBackgroundEnabled.ToString()
			},
			{
				"dorfromantik.qualityLevel",
				QualityLevel.ToString()
			},
			{
				"dorfromantik.masterVolume",
				MasterVolume.ToString(CultureInfo.InvariantCulture)
			},
			{
				"dorfromantik.musicVolume",
				MusicVolume.ToString(CultureInfo.InvariantCulture)
			},
			{
				"dorfromantik.fxVolume",
				FxVolume.ToString(CultureInfo.InvariantCulture)
			},
			{
				"dorfromantik.placingTilesWithClick",
				PlacingTilesWithClick.ToString()
			},
			{
				"dorfromantik.ingameUiVisible",
				IngameUiVisible.ToString()
			},
			{
				"dorfromantik.debugUiVisible",
				DebugUiVisible.ToString()
			},
			{
				"dorfromantik.tooltipLevel",
				TooltipLevel.ToString()
			}
		};
		if ((bool)LocalizationManager.Instance)
		{
			dictionary.Add("dorfromantik.language", LocalizationManager.Instance.Language.ToString());
		}
		return dictionary;
	}

	private void UnloadUnusedAssets()
	{
		Resources.UnloadUnusedAssets();
	}

	public void UpdateSettings(DefaultSettings defaultSettings)
	{
		this.defaultSettings = defaultSettings;
		SetMaxZoomOutDistance(this.defaultSettings.maxZoomOutDistance);
	}

	public void SetChallengeInfoSectionExpanded(bool expand)
	{
		IsChallengeInfoSectionExpanded = expand;
		PlayerPrefs.SetInt("IsChallengeInfoSectionExpanded", IsChallengeInfoSectionExpanded ? 1 : 0);
	}
}
