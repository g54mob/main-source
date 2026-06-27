using System;
using System.Collections.Generic;
using System.Linq;
using FullSerializer;
using Helpers.Ranges;
using Restory.Data.GameConfigs;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.Gameplay.GameSettings
{
	public class GameSettingsManager : MonoBehaviour
	{
		[Serializable]
		public enum GraphicsPattern
		{
			None = -1,
			Low = 0,
			Middle = 1,
			High = 2,
			Ultra = 3
		}

		[Serializable]
		[fsObject("2", new Type[] { typeof(GameSettingsData_V1) })]
		public class GameSettingsData
		{
			[SerializeField]
			public GraphicsPattern graphicsPattern = GraphicsPattern.High;

			[SerializeField]
			public GraphicsPlatformType graphicsPlatformType;

			[SerializeField]
			public int unityPlayerQualityIndex;

			[SerializeField]
			public int resolutionWidth;

			[SerializeField]
			public int resolutionHeight;

			[SerializeField]
			public int screenIndex;

			[SerializeField]
			public bool fullScreen = true;

			[SerializeField]
			public bool vsync;

			[SerializeField]
			public int fpsLock = 60;

			[SerializeField]
			public float brightnessOffset;

			[SerializeField]
			[HideInInspector]
			public SystemLanguage localization = SystemLanguage.English;

			[SerializeField]
			public DifficultySettings difficultySettings = new DifficultySettings(CozyLevel.Normal);

			[SerializeField]
			public AudioFMODSettings audioSettings = new AudioFMODSettings();

			[SerializeField]
			public CameraSettings cameraSettings = new CameraSettings();

			[SerializeField]
			public TextSize? textSize;

			[SerializeField]
			public string gamepadScheme = string.Empty;

			[SerializeField]
			public bool showPathMinions;

			public GameSettingsData()
			{
			}

			public GameSettingsData(GameSettingsData_V1 settings)
			{
				graphicsPattern = settings.graphicsPattern;
				graphicsPlatformType = settings.graphicsPlatformType;
				unityPlayerQualityIndex = settings.unityPlayerQualityIndex;
				resolutionWidth = settings.resolutionWidth;
				resolutionHeight = settings.resolutionHeight;
				fullScreen = settings.fullScreen;
				vsync = settings.vsync;
				fpsLock = settings.fpsLock;
				brightnessOffset = settings.brightnessOffset;
				localization = settings.localization;
				difficultySettings = new DifficultySettings(settings.cozyLevel);
				textSize = settings.textSize;
				gamepadScheme = settings.gamepadScheme;
				showPathMinions = settings.showPathMinions;
				audioSettings = settings.audioSettings.Clone();
				cameraSettings = settings.cameraSettings.Clone();
			}
		}

		[Serializable]
		[fsObject("1", new Type[] { })]
		public class GameSettingsData_V1
		{
			[SerializeField]
			public GraphicsPattern graphicsPattern = GraphicsPattern.High;

			[SerializeField]
			public GraphicsPlatformType graphicsPlatformType;

			[SerializeField]
			public int unityPlayerQualityIndex;

			[SerializeField]
			public int resolutionWidth;

			[SerializeField]
			public int resolutionHeight;

			[SerializeField]
			public bool fullScreen = true;

			[SerializeField]
			public bool vsync = true;

			[SerializeField]
			public int fpsLock = -1;

			[SerializeField]
			public float brightnessOffset;

			[SerializeField]
			[HideInInspector]
			public SystemLanguage localization = SystemLanguage.English;

			[SerializeField]
			public CozyLevel cozyLevel;

			[SerializeField]
			public AudioFMODSettings audioSettings = new AudioFMODSettings();

			[SerializeField]
			public CameraSettings cameraSettings = new CameraSettings();

			[SerializeField]
			public TextSize? textSize;

			[SerializeField]
			public string gamepadScheme = string.Empty;

			[SerializeField]
			public bool showPathMinions;
		}

		[Serializable]
		[fsObject("3", new Type[] { typeof(GameSettingsData) })]
		public class GameSettingsData_V3
		{
			[SerializeField]
			private GraphicsPattern graphicsPattern = GraphicsPattern.High;

			[SerializeField]
			private GraphicsPlatformType graphicsPlatformType;

			[SerializeField]
			private int unityPlayerQualityIndex;

			[SerializeField]
			private int resolutionWidth;

			[SerializeField]
			private int resolutionHeight;

			[SerializeField]
			private int screenIndex;

			[SerializeField]
			private bool fullScreen = true;

			[SerializeField]
			private bool vsync;

			[SerializeField]
			private int fpsLock = 60;

			[SerializeField]
			private float brightnessOffset;

			[SerializeField]
			[HideInInspector]
			private SystemLanguage localization = SystemLanguage.English;

			[SerializeField]
			private DifficultySettings difficultySettings = new DifficultySettings(CozyLevel.Normal);

			[SerializeField]
			private AudioFMODSettings audioSettings = new AudioFMODSettings();

			[SerializeField]
			private CameraSettings cameraSettings = new CameraSettings();

			[SerializeField]
			private TextSize? textSize;

			[SerializeField]
			private string gamepadScheme = string.Empty;

			[SerializeField]
			private bool showPathMinions;

			public GraphicsPattern GraphicsPattern
			{
				get
				{
					return graphicsPattern;
				}
				set
				{
					graphicsPattern = value;
				}
			}

			public GraphicsPlatformType GraphicsPlatformType
			{
				get
				{
					return graphicsPlatformType;
				}
				set
				{
					graphicsPlatformType = value;
				}
			}

			public int UnityPlayerQualityIndex
			{
				get
				{
					return unityPlayerQualityIndex;
				}
				set
				{
					unityPlayerQualityIndex = value;
				}
			}

			public Resolution Resolution
			{
				get
				{
					if (!TryGetResolution(resolutionWidth, resolutionHeight, out var resolution))
					{
						resolution = Screen.currentResolution;
						resolutionWidth = resolution.width;
						resolutionHeight = resolution.height;
					}
					return resolution;
				}
				set
				{
					resolutionWidth = value.width;
					resolutionHeight = value.height;
				}
			}

			public int ScreenIndex
			{
				get
				{
					return screenIndex;
				}
				set
				{
					screenIndex = value;
				}
			}

			public bool FullScreen
			{
				get
				{
					return fullScreen;
				}
				set
				{
					fullScreen = value;
				}
			}

			public bool Vsync
			{
				get
				{
					return vsync;
				}
				set
				{
					vsync = value;
				}
			}

			public int FpsLock
			{
				get
				{
					return fpsLock;
				}
				set
				{
					fpsLock = value;
				}
			}

			public float BrightnessOffset
			{
				get
				{
					return brightnessOffset;
				}
				set
				{
					brightnessOffset = value;
				}
			}

			public SystemLanguage Localization
			{
				get
				{
					return localization;
				}
				set
				{
					localization = value;
				}
			}

			public DifficultySettings DifficultySettings => difficultySettings;

			public AudioFMODSettings AudioSettings => audioSettings;

			public CameraSettings CameraSettings => cameraSettings;

			public TextSize? TextSize
			{
				get
				{
					return textSize;
				}
				set
				{
					textSize = value;
				}
			}

			public string GamepadScheme
			{
				get
				{
					return gamepadScheme;
				}
				set
				{
					gamepadScheme = value;
				}
			}

			public bool ShowPathMinions
			{
				get
				{
					return showPathMinions;
				}
				set
				{
					showPathMinions = value;
				}
			}

			public GameSettingsData_V3()
			{
			}

			public GameSettingsData_V3(GameSettingsData settings)
			{
				graphicsPattern = settings.graphicsPattern;
				graphicsPlatformType = settings.graphicsPlatformType;
				unityPlayerQualityIndex = settings.unityPlayerQualityIndex;
				resolutionWidth = settings.resolutionWidth;
				resolutionHeight = settings.resolutionHeight;
				screenIndex = settings.screenIndex;
				fullScreen = settings.fullScreen;
				vsync = false;
				fpsLock = 60;
				brightnessOffset = settings.brightnessOffset;
				localization = settings.localization;
				difficultySettings = (DifficultySettings)settings.difficultySettings.Clone();
				textSize = settings.textSize;
				gamepadScheme = settings.gamepadScheme;
				showPathMinions = settings.showPathMinions;
				audioSettings = settings.audioSettings.Clone();
				cameraSettings = settings.cameraSettings.Clone();
			}

			public bool EqualResolutions(Resolution a, Resolution b)
			{
				if (a.width == b.width && a.height == b.height)
				{
					return a.refreshRate == b.refreshRate;
				}
				return false;
			}

			public void SetDefaultLocalizationLanguage(IEnumerable<SystemLanguage> supportedLocalizations)
			{
				SystemLanguage systemLanguage = Application.systemLanguage;
				localization = (supportedLocalizations.Contains(systemLanguage) ? systemLanguage : SystemLanguage.English);
			}

			public GameSettingsData_V3 Clone()
			{
				return new GameSettingsData_V3
				{
					graphicsPattern = graphicsPattern,
					graphicsPlatformType = graphicsPlatformType,
					unityPlayerQualityIndex = unityPlayerQualityIndex,
					resolutionWidth = resolutionWidth,
					resolutionHeight = resolutionHeight,
					screenIndex = screenIndex,
					fullScreen = fullScreen,
					vsync = vsync,
					fpsLock = fpsLock,
					brightnessOffset = brightnessOffset,
					localization = localization,
					difficultySettings = (DifficultySettings)difficultySettings.Clone(),
					textSize = textSize,
					gamepadScheme = gamepadScheme,
					showPathMinions = showPathMinions,
					audioSettings = audioSettings.Clone(),
					cameraSettings = cameraSettings.Clone()
				};
			}
		}

		public readonly UnityEvent<SystemLanguage> OnLocalisationChanged = new UnityEvent<SystemLanguage>();

		public readonly UnityEvent OnGraphicsSettingsChange = new UnityEvent();

		public readonly UnityEvent<GraphicsPlatformType, GraphicsPattern> OnPlatformGraphicsPatternChanged = new UnityEvent<GraphicsPlatformType, GraphicsPattern>();

		public readonly UnityEvent<AudioFMODSettings.AudioTypeSettings> OnAudioSettingsChanged = new UnityEvent<AudioFMODSettings.AudioTypeSettings>();

		[SerializeField]
		private GraphicsQualityPresetList graphicsQualityPresetList;

		public readonly FloatRange BrightnessRange = new FloatRange(-0.9f, 0.9f);

		[SerializeField]
		private GameConfig gameConfig;

		[SerializeField]
		private GameSettingsData_V3 defaultData;

		private GameSettingsData_V3 data;

		private AsyncOperation moveMainWindowOperation;

		public UnityEvent OnInitialized { get; } = new UnityEvent();

		public bool IsInitialized { get; private set; }

		public GraphicsPlatformType CurrentPlatform
		{
			get
			{
				return Data.GraphicsPlatformType;
			}
			set
			{
				Data.GraphicsPlatformType = value;
				OnPlatformGraphicsPatternChanged?.Invoke(value, CurrentGraphicsPattern);
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public GraphicsPattern CurrentGraphicsPattern
		{
			get
			{
				return Data.GraphicsPattern;
			}
			set
			{
				Data.GraphicsPattern = value;
				int qualityIndex = graphicsQualityPresetList.GetQualityIndex(CurrentPlatform, value);
				if (qualityIndex > -1)
				{
					Data.UnityPlayerQualityIndex = qualityIndex;
				}
				OnPlatformGraphicsPatternChanged.Invoke(CurrentPlatform, CurrentGraphicsPattern);
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public int CurrentUnityPlayerQualityIndex
		{
			get
			{
				return Data.UnityPlayerQualityIndex;
			}
			set
			{
				if (!Enum.IsDefined(typeof(GraphicsPattern), value))
				{
					Debug.LogError($"There is no quality setting with index [{value}] in [GraphicsPattern] enum!");
					return;
				}
				int qualityIndex = graphicsQualityPresetList.GetQualityIndex(CurrentPlatform, (GraphicsPattern)value);
				if (qualityIndex < 0)
				{
					Debug.LogError($"There is no quality setting with index [{value}] for platform [{CurrentPlatform}] in current [{graphicsQualityPresetList}]!");
				}
				else if (CurrentUnityPlayerQualityIndex != qualityIndex)
				{
					QualitySettings.SetQualityLevel(qualityIndex, applyExpensiveChanges: true);
					Data.UnityPlayerQualityIndex = qualityIndex;
					Data.GraphicsPattern = (GraphicsPattern)value;
					OnPlatformGraphicsPatternChanged.Invoke(CurrentPlatform, CurrentGraphicsPattern);
					OnGraphicsSettingsChange?.Invoke();
				}
			}
		}

		public bool Fullscreen
		{
			get
			{
				return Data.FullScreen;
			}
			set
			{
				Data.FullScreen = value;
				Screen.fullScreen = value;
				Screen.fullScreenMode = (value ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
				CurrentGraphicsPattern = CurrentGraphicsPattern;
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public float BrightnessOffset
		{
			get
			{
				return Data.BrightnessOffset;
			}
			set
			{
				value = BrightnessRange.Clamp(value);
				Data.BrightnessOffset = value;
				Screen.brightness = value;
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public bool Vsync
		{
			get
			{
				return Data.Vsync;
			}
			set
			{
				Data.Vsync = value;
				Data.FpsLock = -1;
				SetTargetFrameRateAndVsync(Data.Vsync, Data.FpsLock);
				CurrentGraphicsPattern = CurrentGraphicsPattern;
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public int FpsLock
		{
			get
			{
				return Data.FpsLock;
			}
			set
			{
				Data.FpsLock = value;
				Data.Vsync = false;
				SetTargetFrameRateAndVsync(Data.Vsync, Data.FpsLock);
				CurrentGraphicsPattern = CurrentGraphicsPattern;
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public Resolution ScreenResolution
		{
			get
			{
				return Data.Resolution;
			}
			set
			{
				Data.Resolution = value;
				SetScreenResolution(Data.Resolution, Fullscreen);
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public int ScreenIndex
		{
			get
			{
				return Data.ScreenIndex;
			}
			set
			{
				Data.ScreenIndex = value;
				SetScreenIndex(ScreenIndex);
				OnGraphicsSettingsChange?.Invoke();
			}
		}

		public TextSize? TextSize
		{
			get
			{
				if (!Data.TextSize.HasValue)
				{
					Data.TextSize = TextSizeSelector.DetectRecommendedSize();
					this.TextSizeChanged(Data.TextSize);
				}
				return Data.TextSize;
			}
			set
			{
				Data.TextSize = value;
				this.TextSizeChanged(value);
			}
		}

		public string GamepadScheme
		{
			get
			{
				return Data.GamepadScheme;
			}
			set
			{
				Data.GamepadScheme = value;
				this.GamepadSchemeChanged(value);
			}
		}

		public bool ShowPathMinions
		{
			get
			{
				return Data.ShowPathMinions;
			}
			set
			{
				Data.ShowPathMinions = value;
				this.ShowPathMinionsChanged(value);
			}
		}

		public SystemLanguage Localization
		{
			get
			{
				return Data?.Localization ?? SystemLanguage.English;
			}
			set
			{
				Data.Localization = value;
				OnLocalisationChanged?.Invoke(value);
			}
		}

		public DifficultySettings DifficultySettings => Data.DifficultySettings;

		public AudioFMODSettings AudioSettings => Data.AudioSettings;

		public CameraSettings CameraSettings => Data.CameraSettings;

		public GameSettingsData_V3 DefaultData => defaultData;

		public GameSettingsData_V3 Data => data;

		public event Action<TextSize?> TextSizeChanged = delegate
		{
		};

		public event Action<string> GamepadSchemeChanged = delegate
		{
		};

		public event Action<bool> ShowPathMinionsChanged = delegate
		{
		};

		public void Initialize(GameSettingsData_V3 data)
		{
			if (data == null)
			{
				defaultData.SetDefaultLocalizationLanguage(gameConfig.SupportedLocalizations);
				this.data = defaultData.Clone();
			}
			else
			{
				this.data = data;
			}
			OnLocalisationChanged?.Invoke(this.data.Localization);
			if (this.data.GraphicsPlatformType == GraphicsPlatformType.Unknown)
			{
				this.data.GraphicsPlatformType = graphicsQualityPresetList.GetGraphicsPlatformType();
			}
			GameSettingsData_V3 gameSettingsData_V = this.data;
			TextSize? textSize = gameSettingsData_V.TextSize;
			TextSize valueOrDefault = textSize.GetValueOrDefault();
			if (!textSize.HasValue)
			{
				valueOrDefault = TextSizeSelector.DetectRecommendedSize();
				TextSize? textSize2 = valueOrDefault;
				gameSettingsData_V.TextSize = textSize2;
			}
			this.TextSizeChanged(Data.TextSize);
			SubscribeEvents();
			ApplyCurrentSettingsDataToUnitySettings();
			ResolveAudioSettingsChanged(AudioSettings.Master);
			ResolveAudioSettingsChanged(AudioSettings.Music);
			ResolveAudioSettingsChanged(AudioSettings.SFX);
			IsInitialized = true;
			OnInitialized.Invoke();
		}

		public void ResetToDefault()
		{
			data = defaultData.Clone();
		}

		public static bool TryGetResolution(int width, int height, out Resolution resolution)
		{
			foreach (Resolution resolution2 in GetResolutions())
			{
				if (resolution2.width == width && resolution2.height == height)
				{
					resolution = resolution2;
					return true;
				}
			}
			resolution = default(Resolution);
			return false;
		}

		public static List<Resolution> GetResolutions()
		{
			Resolution[] resolutions = Screen.resolutions;
			HashSet<Tuple<int, int>> hashSet = new HashSet<Tuple<int, int>>();
			Dictionary<Tuple<int, int>, int> dictionary = new Dictionary<Tuple<int, int>, int>();
			for (int i = 0; i < resolutions.GetLength(0); i++)
			{
				Tuple<int, int> tuple = new Tuple<int, int>(resolutions[i].width, resolutions[i].height);
				hashSet.Add(tuple);
				if (!dictionary.ContainsKey(tuple))
				{
					dictionary.Add(tuple, (int)resolutions[i].refreshRateRatio.value);
				}
				else
				{
					dictionary[tuple] = (int)resolutions[i].refreshRateRatio.value;
				}
			}
			List<Resolution> list = new List<Resolution>(hashSet.Count);
			foreach (Tuple<int, int> item2 in hashSet)
			{
				Resolution item = new Resolution
				{
					width = item2.Item1,
					height = item2.Item2
				};
				if (dictionary.TryGetValue(item2, out var value))
				{
					item.refreshRate = value;
				}
				list.Add(item);
			}
			list.Reverse();
			return list;
		}

		public static List<DisplayInfo> GetDisplayInfos()
		{
			List<DisplayInfo> list = new List<DisplayInfo>();
			Screen.GetDisplayLayout(list);
			return list;
		}

		private void SubscribeEvents()
		{
			AudioSettings.Master.OnSettingsChanged.AddListener(ResolveAudioSettingsChanged);
			AudioSettings.Music.OnSettingsChanged.AddListener(ResolveAudioSettingsChanged);
			AudioSettings.SFX.OnSettingsChanged.AddListener(ResolveAudioSettingsChanged);
		}

		private void ResolveAudioSettingsChanged(AudioFMODSettings.AudioTypeSettings newSettings)
		{
			OnAudioSettingsChanged?.Invoke(newSettings);
		}

		private void ApplyCurrentSettingsDataToUnitySettings()
		{
			int qualityIndex = graphicsQualityPresetList.GetQualityIndex(CurrentPlatform, CurrentGraphicsPattern);
			if (qualityIndex > -1)
			{
				CurrentUnityPlayerQualityIndex = qualityIndex;
			}
			QualitySettings.SetQualityLevel(qualityIndex, applyExpensiveChanges: true);
			SetScreenIndex(ScreenIndex);
			SetScreenResolution(ScreenResolution, Fullscreen);
			if (Data.Vsync)
			{
				Data.FpsLock = -1;
			}
			SetTargetFrameRateAndVsync(Data.Vsync, Data.FpsLock);
			Screen.fullScreen = Fullscreen;
			Screen.fullScreenMode = (Fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
		}

		public static bool EqualResolutions(Resolution a, Resolution b)
		{
			if (a.width == b.width && a.height == b.height)
			{
				return a.refreshRate == b.refreshRate;
			}
			return false;
		}

		private static void SetScreenResolution(Resolution resolution, bool fullscreen)
		{
			Screen.SetResolution(resolution.width, resolution.height, fullscreen);
		}

		private void SetScreenIndex(int screenIndex)
		{
			List<DisplayInfo> list = new List<DisplayInfo>();
			Screen.GetDisplayLayout(list);
			screenIndex = Mathf.Clamp(screenIndex, 0, list.Count - 1);
			DisplayInfo display = list[screenIndex];
			Vector2Int position = new Vector2Int(0, 0);
			if (Screen.fullScreenMode != FullScreenMode.Windowed)
			{
				position.x += display.width / 2;
				position.y += display.height / 2;
			}
			if (moveMainWindowOperation != null)
			{
				moveMainWindowOperation.completed -= ResolveOnMoveMainWindowCompleted;
			}
			moveMainWindowOperation = Screen.MoveMainWindowTo(in display, position);
			moveMainWindowOperation.completed += ResolveOnMoveMainWindowCompleted;
		}

		private void SetTargetFrameRateAndVsync(bool vsync, int fpsLock)
		{
			QualitySettings.vSyncCount = (vsync ? 1 : 0);
			Application.targetFrameRate = fpsLock;
		}

		private void ResolveOnMoveMainWindowCompleted(AsyncOperation _)
		{
			moveMainWindowOperation.completed -= ResolveOnMoveMainWindowCompleted;
			moveMainWindowOperation = null;
			SetScreenResolution(ScreenResolution, Fullscreen);
			OnGraphicsSettingsChange?.Invoke();
		}
	}
}
