using Tayx.Graphy.Advanced;
using Tayx.Graphy.Audio;
using Tayx.Graphy.Fps;
using Tayx.Graphy.Ram;
using Tayx.Graphy.Utils;
using UnityEngine;

namespace Tayx.Graphy
{
	public class GraphyManager : G_Singleton<GraphyManager>
	{
		public enum Mode
		{
			FULL = 0,
			LIGHT = 1
		}

		public enum ModuleType
		{
			FPS = 0,
			RAM = 1,
			AUDIO = 2,
			ADVANCED = 3
		}

		public enum ModuleState
		{
			FULL = 0,
			TEXT = 1,
			BASIC = 2,
			BACKGROUND = 3,
			OFF = 4
		}

		public enum ModulePosition
		{
			TOP_RIGHT = 0,
			TOP_LEFT = 1,
			BOTTOM_RIGHT = 2,
			BOTTOM_LEFT = 3,
			FREE = 4
		}

		public enum LookForAudioListener
		{
			ALWAYS = 0,
			ON_SCENE_LOAD = 1,
			NEVER = 2
		}

		public enum ModulePreset
		{
			FPS_BASIC = 0,
			FPS_TEXT = 1,
			FPS_FULL = 2,
			FPS_TEXT_RAM_TEXT = 3,
			FPS_FULL_RAM_TEXT = 4,
			FPS_FULL_RAM_FULL = 5,
			FPS_TEXT_RAM_TEXT_AUDIO_TEXT = 6,
			FPS_FULL_RAM_TEXT_AUDIO_TEXT = 7,
			FPS_FULL_RAM_FULL_AUDIO_TEXT = 8,
			FPS_FULL_RAM_FULL_AUDIO_FULL = 9,
			FPS_FULL_RAM_FULL_AUDIO_FULL_ADVANCED_FULL = 10,
			FPS_BASIC_ADVANCED_FULL = 11
		}

		[SerializeField]
		private Mode m_graphyMode;

		[SerializeField]
		private bool m_enableOnStartup;

		[SerializeField]
		private bool m_keepAlive;

		[SerializeField]
		private bool m_background;

		[SerializeField]
		private Color m_backgroundColor;

		[SerializeField]
		private bool m_enableHotkeys;

		[SerializeField]
		private KeyCode m_toggleModeKeyCode;

		[SerializeField]
		private bool m_toggleModeCtrl;

		[SerializeField]
		private bool m_toggleModeAlt;

		[SerializeField]
		private KeyCode m_toggleActiveKeyCode;

		[SerializeField]
		private bool m_toggleActiveCtrl;

		[SerializeField]
		private bool m_toggleActiveAlt;

		[SerializeField]
		private ModulePosition m_graphModulePosition;

		[SerializeField]
		private ModuleState m_fpsModuleState;

		[SerializeField]
		private Color m_goodFpsColor;

		[SerializeField]
		private int m_goodFpsThreshold;

		[SerializeField]
		private Color m_cautionFpsColor;

		[SerializeField]
		private int m_cautionFpsThreshold;

		[SerializeField]
		private Color m_criticalFpsColor;

		[Range(10f, 300f)]
		[SerializeField]
		private int m_fpsGraphResolution;

		[Range(1f, 200f)]
		[SerializeField]
		private int m_fpsTextUpdateRate;

		[SerializeField]
		private ModuleState m_ramModuleState;

		[SerializeField]
		private Color m_allocatedRamColor;

		[SerializeField]
		private Color m_reservedRamColor;

		[SerializeField]
		private Color m_monoRamColor;

		[Range(10f, 300f)]
		[SerializeField]
		private int m_ramGraphResolution;

		[Range(1f, 200f)]
		[SerializeField]
		private int m_ramTextUpdateRate;

		[SerializeField]
		private ModuleState m_audioModuleState;

		[SerializeField]
		private LookForAudioListener m_findAudioListenerInCameraIfNull;

		[SerializeField]
		private AudioListener m_audioListener;

		[SerializeField]
		private Color m_audioGraphColor;

		[Range(10f, 300f)]
		[SerializeField]
		private int m_audioGraphResolution;

		[Range(1f, 200f)]
		[SerializeField]
		private int m_audioTextUpdateRate;

		[SerializeField]
		private FFTWindow m_FFTWindow;

		[Tooltip("Must be a power of 2 and between 64-8192")]
		[SerializeField]
		private int m_spectrumSize;

		[SerializeField]
		private ModulePosition m_advancedModulePosition;

		[SerializeField]
		private ModuleState m_advancedModuleState;

		private bool m_initialized;

		private bool m_active;

		private bool m_focused;

		private G_FpsManager m_fpsManager;

		private G_RamManager m_ramManager;

		private G_AudioManager m_audioManager;

		private G_AdvancedData m_advancedData;

		private G_FpsMonitor m_fpsMonitor;

		private G_RamMonitor m_ramMonitor;

		private G_AudioMonitor m_audioMonitor;

		private ModulePreset m_modulePresetState;

		public Mode GraphyMode
		{
			get
			{
				return default(Mode);
			}
			set
			{
			}
		}

		public bool EnableOnStartup => false;

		public bool KeepAlive => false;

		public bool Background
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public ModulePosition GraphModulePosition
		{
			get
			{
				return default(ModulePosition);
			}
			set
			{
			}
		}

		public ModuleState FpsModuleState
		{
			get
			{
				return default(ModuleState);
			}
			set
			{
			}
		}

		public Color GoodFPSColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color CautionFPSColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color CriticalFPSColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public int GoodFPSThreshold
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CautionFPSThreshold
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int FpsGraphResolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int FpsTextUpdateRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float CurrentFPS => 0f;

		public float AverageFPS => 0f;

		public float MinFPS => 0f;

		public float MaxFPS => 0f;

		public ModuleState RamModuleState
		{
			get
			{
				return default(ModuleState);
			}
			set
			{
			}
		}

		public Color AllocatedRamColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color ReservedRamColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color MonoRamColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public int RamGraphResolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int RamTextUpdateRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float AllocatedRam => 0f;

		public float ReservedRam => 0f;

		public float MonoRam => 0f;

		public ModuleState AudioModuleState
		{
			get
			{
				return default(ModuleState);
			}
			set
			{
			}
		}

		public AudioListener AudioListener
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LookForAudioListener FindAudioListenerInCameraIfNull
		{
			get
			{
				return default(LookForAudioListener);
			}
			set
			{
			}
		}

		public Color AudioGraphColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public int AudioGraphResolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int AudioTextUpdateRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public FFTWindow FftWindow
		{
			get
			{
				return default(FFTWindow);
			}
			set
			{
			}
		}

		public int SpectrumSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float[] Spectrum => null;

		public float MaxDB => 0f;

		public ModuleState AdvancedModuleState
		{
			get
			{
				return default(ModuleState);
			}
			set
			{
			}
		}

		public ModulePosition AdvancedModulePosition
		{
			get
			{
				return default(ModulePosition);
			}
			set
			{
			}
		}

		protected GraphyManager()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void OnApplicationFocus(bool isFocused)
		{
		}

		public void SetModulePosition(ModuleType moduleType, ModulePosition modulePosition)
		{
		}

		public void SetModuleMode(ModuleType moduleType, ModuleState moduleState)
		{
		}

		public void ToggleModes()
		{
		}

		public void SetPreset(ModulePreset modulePreset)
		{
		}

		public void ToggleActive()
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		private void Init()
		{
		}

		private void CheckForHotkeyPresses()
		{
		}

		private bool CheckFor1KeyPress(KeyCode key)
		{
			return false;
		}

		private bool CheckFor2KeyPress(KeyCode key1, KeyCode key2)
		{
			return false;
		}

		private bool CheckFor3KeyPress(KeyCode key1, KeyCode key2, KeyCode key3)
		{
			return false;
		}

		private void UpdateAllParameters()
		{
		}

		private void RefreshAllParameters()
		{
		}
	}
}
