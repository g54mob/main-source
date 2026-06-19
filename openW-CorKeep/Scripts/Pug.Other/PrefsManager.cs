using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using ModIO.Util;
using ModIOBrowser;
using ModIOBrowser.Implementation;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.Platform;
using Pug.UnityExtensions;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

public class PrefsManager : ManagerBase
{
	public SeasonsTable seasonsTable;

	[NonSerialized]
	public Action<PugParticleQuality> OnParticleQualityChanged;

	[NonSerialized]
	public Action<bool> OnSquashBugsChanged;

	[NonSerialized]
	public Action<bool> OnGroundFogChanged;

	private PrefsData data = new PrefsData();

	private ServerPrefsData serverData = new ServerPrefsData();

	private FilesystemManager.File fileHandle;

	private FilesystemManager.File serverFileHandle;

	private readonly CultureInfo timeFormatProvider = CultureInfo.InvariantCulture;

	private bool _isDirty;

	public static readonly Vector2Int SERVER_WORLD_ID_CLAMP = new Vector2Int(0, 29);

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("PrefsManager.Init");

	public float masterAudioVolume
	{
		get
		{
			return data.masterAudioVolume;
		}
		set
		{
			if (!Mathf.Approximately(data.masterAudioVolume, value))
			{
				data.masterAudioVolume = value;
				SetDirty();
			}
		}
	}

	public float musicVolume
	{
		get
		{
			return data.bgmVol;
		}
		set
		{
			if (!Mathf.Approximately(data.bgmVol, value))
			{
				data.bgmVol = value;
				SetDirty();
			}
		}
	}

	public float sfxVolume
	{
		get
		{
			return data.sfxVol;
		}
		set
		{
			if (!Mathf.Approximately(data.sfxVol, value))
			{
				data.sfxVol = value;
				SetDirty();
			}
		}
	}

	public float ambientSfxVolume
	{
		get
		{
			return data.ambSfxVol;
		}
		set
		{
			if (!Mathf.Approximately(data.ambSfxVol, value))
			{
				data.ambSfxVol = value;
				SetDirty();
			}
		}
	}

	public float instrumentsSfxVolume
	{
		get
		{
			return data.instrVol;
		}
		set
		{
			if (!Mathf.Approximately(data.instrVol, value))
			{
				data.instrVol = value;
				SetDirty();
			}
		}
	}

	public bool gamepadSpeaker
	{
		get
		{
			return data.gamepadSpeaker;
		}
		set
		{
			if (data.gamepadSpeaker != value)
			{
				data.gamepadSpeaker = value;
				SetDirty();
			}
		}
	}

	public bool limitColors
	{
		get
		{
			return data.limitColors;
		}
		set
		{
			bool num = data.limitColors;
			data.limitColors = value;
			if (num != value)
			{
				SetDirty();
			}
		}
	}

	public float brightness
	{
		get
		{
			return data.brightness;
		}
		set
		{
			if (data.brightness != value)
			{
				data.brightness = value;
				SetDirty();
			}
		}
	}

	public bool vsync
	{
		get
		{
			return data.vsync;
		}
		set
		{
			if (data.vsync != value)
			{
				data.vsync = value;
				SetDirty();
			}
		}
	}

	public bool integerScaling
	{
		get
		{
			return data.integerScaling;
		}
		set
		{
			if (data.integerScaling != value)
			{
				data.integerScaling = value;
				SetDirty();
			}
		}
	}

	public int fullscreen
	{
		get
		{
			return data.fullscreenOption;
		}
		set
		{
			int fullscreenOption = data.fullscreenOption;
			int num = ((value != 3) ? value : 0);
			data.fullscreenOption = num;
			switch (value)
			{
			case 0:
			case 3:
			{
				int num2 = 128;
				int num3 = math.min((Screen.currentResolution.width - num2) / 480, (Screen.currentResolution.height - num2) / 270);
				if (num3 < 1)
				{
					num3 = 1;
				}
				Debug.Log($"windowed with scale {num3}");
				int width = Screen.width;
				int height = Screen.height;
				if (value == 0)
				{
					width = 480 * num3;
					height = 270 * num3;
				}
				Cursor.lockState = CursorLockMode.None;
				Screen.SetResolution(width, height, FullScreenMode.Windowed);
				break;
			}
			case 1:
				Cursor.lockState = CursorLockMode.None;
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
				break;
			case 2:
				Cursor.lockState = CursorLockMode.Confined;
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
				break;
			}
			if (fullscreenOption != num)
			{
				SetDirty();
			}
		}
	}

	public bool vibration
	{
		get
		{
			return data.vibration;
		}
		set
		{
			if (data.vibration != value)
			{
				data.vibration = value;
				SetDirty();
			}
		}
	}

	public float vibrationIntensity
	{
		get
		{
			return data.vibrationIntensity;
		}
		set
		{
			if (data.vibrationIntensity != value)
			{
				data.vibrationIntensity = value;
				SetDirty();
			}
		}
	}

	public bool triggerEffects
	{
		get
		{
			return data.triggerEffects;
		}
		set
		{
			if (data.triggerEffects != value)
			{
				data.triggerEffects = value;
				SetDirty();
			}
		}
	}

	public bool faceMouseDirection
	{
		get
		{
			return data.faceMouseDirection;
		}
		set
		{
			if (data.faceMouseDirection != value)
			{
				data.faceMouseDirection = value;
				SetDirty();
			}
		}
	}

	public bool squashBugs
	{
		get
		{
			return data.squashBugs;
		}
		set
		{
			OnSquashBugsChanged?.Invoke(value);
			if (data.squashBugs != value)
			{
				data.squashBugs = value;
				SetDirty();
			}
		}
	}

	public bool fishingMiniGameEnabled
	{
		get
		{
			return data.fishingMiniGameEnabled;
		}
		set
		{
			if (data.fishingMiniGameEnabled != value)
			{
				data.fishingMiniGameEnabled = value;
				SetDirty();
			}
		}
	}

	public bool flashingLights
	{
		get
		{
			return data.flashingLights;
		}
		set
		{
			if (data.flashingLights != value)
			{
				data.flashingLights = value;
				SetDirty();
			}
		}
	}

	public bool screenShakes
	{
		get
		{
			return data.screenShakes;
		}
		set
		{
			if (data.screenShakes != value)
			{
				data.screenShakes = value;
				SetDirty();
			}
		}
	}

	public bool crossPlay
	{
		get
		{
			return data.crossPlay;
		}
		set
		{
			if (data.crossPlay != value)
			{
				data.crossPlay = value;
				SetDirty();
			}
		}
	}

	public bool enableTutorial
	{
		get
		{
			return data.enableTutorial;
		}
		set
		{
			if (data.enableTutorial != value)
			{
				data.enableTutorial = value;
				SetDirty();
			}
		}
	}

	public bool useRGBEffects
	{
		get
		{
			return data.useRGBEffects;
		}
		set
		{
			if (data.useRGBEffects != value)
			{
				data.useRGBEffects = value;
				SetDirty();
			}
		}
	}

	public string language
	{
		get
		{
			return data.lang;
		}
		set
		{
			string lang = data.lang;
			data.lang = value;
			ReloadLanguage();
			if (!(lang == value))
			{
				SetDirty();
			}
		}
	}

	public bool showDamageNumbers
	{
		get
		{
			return data.showDamageNumbers;
		}
		set
		{
			if (data.showDamageNumbers != value)
			{
				data.showDamageNumbers = value;
				SetDirty();
			}
		}
	}

	public bool showCharacterNames
	{
		get
		{
			return data.showCharacterNames;
		}
		set
		{
			if (data.showCharacterNames != value)
			{
				data.showCharacterNames = value;
				SetDirty();
			}
		}
	}

	public bool showMinimap
	{
		get
		{
			return data.showMinimap;
		}
		set
		{
			if (data.showMinimap != value)
			{
				data.showMinimap = value;
				SetDirty();
			}
		}
	}

	public string playerGuid => data.playerGuid;

	public bool saveEnabled
	{
		get
		{
			if (!Manager.DEBUG_MODE)
			{
				return true;
			}
			return (data.debugFlags & DebugFlags.SaveDisabled) == 0;
		}
		set
		{
			if (value)
			{
				data.debugFlags &= ~DebugFlags.SaveDisabled;
			}
			else
			{
				data.debugFlags |= DebugFlags.SaveDisabled;
			}
			SetDirty();
		}
	}

	public bool playerInvincible
	{
		get
		{
			if (!Manager.DEBUG_MODE)
			{
				return false;
			}
			return (data.debugFlags & DebugFlags.PlayerInvincible) != 0;
		}
		set
		{
			if (value)
			{
				data.debugFlags |= DebugFlags.PlayerInvincible;
			}
			else
			{
				data.debugFlags &= ~DebugFlags.PlayerInvincible;
			}
			SetDirty();
		}
	}

	public bool enemiesDisabled
	{
		get
		{
			if (!Manager.DEBUG_MODE)
			{
				return false;
			}
			return (data.debugFlags & DebugFlags.EnemiesDisabled) != 0;
		}
		set
		{
			if (value)
			{
				data.debugFlags |= DebugFlags.EnemiesDisabled;
			}
			else
			{
				data.debugFlags &= ~DebugFlags.EnemiesDisabled;
			}
			SetDirty();
		}
	}

	public bool streamerMode
	{
		get
		{
			return data.streamerMode;
		}
		set
		{
			if (data.streamerMode != value)
			{
				data.streamerMode = value;
				SetDirty();
			}
		}
	}

	public bool showKeyHints
	{
		get
		{
			return data.showKeyHints;
		}
		set
		{
			if (data.showKeyHints != value)
			{
				data.showKeyHints = value;
				SetDirty();
			}
		}
	}

	public bool hideInGameUI
	{
		get
		{
			return data.hideInGameUI;
		}
		set
		{
			if (data.hideInGameUI != value)
			{
				data.hideInGameUI = value;
				SetDirty();
			}
		}
	}

	public Season season { get; private set; }

	public int shadowQuality
	{
		get
		{
			return data.shadowQuality;
		}
		set
		{
			if (data.shadowQuality != value)
			{
				data.shadowQuality = value;
				QualitySettings.shadowResolution = (ShadowResolution)value;
				SetDirty();
			}
		}
	}

	public int ssaoQuality
	{
		get
		{
			return data.ssaoQuality;
		}
		set
		{
			if (data.ssaoQuality != value)
			{
				data.ssaoQuality = value;
				SetDirty();
			}
		}
	}

	public int objectShadows
	{
		get
		{
			return data.objectShadows;
		}
		set
		{
			if (data.objectShadows != value)
			{
				data.objectShadows = value;
				SetDirty();
			}
		}
	}

	public int dynamicWater
	{
		get
		{
			return data.dynamicWater;
		}
		set
		{
			if (data.dynamicWater != value)
			{
				data.dynamicWater = value;
				SetDirty();
			}
		}
	}

	public int lightQuality
	{
		get
		{
			return data.lightQuality;
		}
		set
		{
			if (data.lightQuality != value)
			{
				data.lightQuality = value;
				SetDirty();
			}
		}
	}

	public int particleQuality
	{
		get
		{
			return data.particleQuality;
		}
		set
		{
			int num = data.particleQuality;
			data.particleQuality = value;
			OnParticleQualityChanged?.Invoke((PugParticleQuality)value);
			if (num != value)
			{
				SetDirty();
			}
		}
	}

	public bool reflections
	{
		get
		{
			return data.reflections;
		}
		set
		{
			if (data.reflections != value)
			{
				data.reflections = value;
				SetDirty();
			}
		}
	}

	public int bloom
	{
		get
		{
			return data.bloom;
		}
		set
		{
			if (data.bloom != value)
			{
				data.bloom = value;
				SetDirty();
			}
		}
	}

	public int colorRange
	{
		get
		{
			return data.colorRange;
		}
		set
		{
			if (data.colorRange != value)
			{
				data.colorRange = value;
				SetDirty();
			}
		}
	}

	public int crtFilter
	{
		get
		{
			return data.crtFilter;
		}
		set
		{
			if (data.crtFilter != value)
			{
				data.crtFilter = value;
				SetDirty();
			}
		}
	}

	public int targetFrameRate
	{
		get
		{
			if (!data.vsync)
			{
				return data.targetFrameRate;
			}
			return Screen.currentResolution.refreshRate;
		}
		set
		{
			if (data.targetFrameRate != value)
			{
				data.targetFrameRate = value;
				SetDirty();
			}
		}
	}

	public int maxQueuedFrames
	{
		get
		{
			return data.maxQueuedFrames;
		}
		set
		{
			if (data.maxQueuedFrames != value)
			{
				data.maxQueuedFrames = value;
				SetDirty();
			}
		}
	}

	public bool allowJoinByPresence
	{
		get
		{
			return data.allowJoinByPresence;
		}
		set
		{
			bool num = data.allowJoinByPresence;
			data.allowJoinByPresence = value;
			if (num != value)
			{
				SetDirty();
			}
		}
	}

	public bool hasShownShortCutsWindow
	{
		get
		{
			return data.hasShownShortCutsWindow;
		}
		set
		{
			if (data.hasShownShortCutsWindow != value)
			{
				data.hasShownShortCutsWindow = value;
				SetDirty();
			}
		}
	}

	public bool ShowOutdatedVersionPopUp
	{
		get
		{
			return data.showOutdatedVersionPopUp;
		}
		set
		{
			data.showOutdatedVersionPopUp = value;
			SetDirty();
		}
	}

	public bool ShowHotbarKeyboardNumbers
	{
		get
		{
			return data.showHotbarKeyboardNumbers;
		}
		set
		{
			data.showHotbarKeyboardNumbers = value;
			SetDirty();
		}
	}

	public bool ShowHotbarArrows
	{
		get
		{
			return data.showHotbarArrows;
		}
		set
		{
			data.showHotbarArrows = value;
			SetDirty();
		}
	}

	public bool ShowGroundFog
	{
		get
		{
			return data.showGroundFog;
		}
		set
		{
			OnGroundFogChanged?.Invoke(value);
			if (data.showGroundFog != value)
			{
				data.showGroundFog = value;
				SetDirty();
			}
		}
	}

	public bool GodModeEnabled
	{
		get
		{
			return data.godeMode;
		}
		set
		{
			data.godeMode = value;
			SetDirty();
		}
	}

	public string BilibiliCode
	{
		get
		{
			return data.bilibiliCode;
		}
		set
		{
			data.bilibiliCode = value;
			SetDirty();
		}
	}

	public bool ShowInputMappingResetPopup
	{
		get
		{
			return data.showInputMappingResetPopup;
		}
		set
		{
			data.showInputMappingResetPopup = value;
			SetDirty();
		}
	}

	public bool AllowTouchpad
	{
		get
		{
			return data.allowTouchpad;
		}
		set
		{
			data.allowTouchpad = value;
			SetDirty();
		}
	}

	public string serverGameId
	{
		get
		{
			return serverData.gameId;
		}
		private set
		{
			if (serverData.gameId == value)
			{
				Debug.Log("Old and new server gameid is the same");
				return;
			}
			serverData.gameId = value;
			SetDirty();
		}
	}

	public string serverPassword
	{
		get
		{
			return serverData.password;
		}
		private set
		{
			if (serverData.gameId == value)
			{
				Debug.Log("Old and new server gameid is the same");
				return;
			}
			serverData.password = value;
			SetDirty();
		}
	}

	public int serverWorld
	{
		get
		{
			return serverData.world;
		}
		set
		{
			if (serverData.world != value)
			{
				serverData.world = value;
				SetDirty();
			}
		}
	}

	public string serverWorldName
	{
		get
		{
			return serverData.worldName;
		}
		set
		{
			if (!(serverData.worldName == value))
			{
				serverData.worldName = value;
				SetDirty();
			}
		}
	}

	public string serverWorldSeed
	{
		get
		{
			return serverData.worldSeed;
		}
		set
		{
			if (!(serverData.worldSeed == value))
			{
				serverData.worldSeed = value;
				SetDirty();
			}
		}
	}

	public uint serverHashedWorldSeed
	{
		get
		{
			return serverData.hashedWorldSeed;
		}
		set
		{
			if (serverData.hashedWorldSeed != value)
			{
				serverData.hashedWorldSeed = value;
				SetDirty();
			}
		}
	}

	public int serverMaxNumberPlayers
	{
		get
		{
			return serverData.maxNumberPlayers;
		}
		set
		{
			if (serverData.maxNumberPlayers != value)
			{
				serverData.maxNumberPlayers = value;
				SetDirty();
			}
		}
	}

	public int serverMaxNumberOfPacketsSentPerFrame
	{
		get
		{
			return serverData.maxNumberPacketsSentPerFrame;
		}
		set
		{
			if (serverData.maxNumberPacketsSentPerFrame != value)
			{
				serverData.maxNumberPacketsSentPerFrame = value;
				SetDirty();
			}
		}
	}

	public int serverNetworkSendRate
	{
		get
		{
			return serverData.networkSendRate;
		}
		set
		{
			if (serverData.networkSendRate != value)
			{
				serverData.networkSendRate = value;
				SetDirty();
			}
		}
	}

	public WorldMode serverWorldMode
	{
		get
		{
			return serverData.worldMode;
		}
		set
		{
			if (serverData.worldMode != value)
			{
				serverData.worldMode = value;
				SetDirty();
			}
		}
	}

	public int serverSeasonOverride
	{
		get
		{
			return serverData.seasonOverride;
		}
		set
		{
			if (serverData.seasonOverride != value)
			{
				serverData.seasonOverride = value;
				SetDirty();
			}
		}
	}

	public bool ShowEulaPopUp
	{
		get
		{
			return data.showEulaPopUp;
		}
		set
		{
			if (data.showEulaPopUp != value)
			{
				data.showEulaPopUp = value;
				SetDirty();
			}
		}
	}

	public bool ShowExplorersEditionPopup
	{
		get
		{
			return data.showExplorersEditionPopup;
		}
		set
		{
			if (data.showExplorersEditionPopup != value)
			{
				data.showExplorersEditionPopup = value;
				SetDirty();
			}
		}
	}

	public bool HasOpenedConsoleCommands
	{
		get
		{
			return data.hasOpenedConsoleCommands;
		}
		set
		{
			if (data.hasOpenedConsoleCommands != value)
			{
				data.hasOpenedConsoleCommands = value;
				SetDirty();
			}
		}
	}

	private void SetDefault()
	{
		data.version = 1;
		data.applicationVersion = Application.version;
		data.masterAudioVolume = 1f;
		data.sfxVol = 0.5f;
		data.bgmVol = 0.5f;
		data.ambSfxVol = 0.5f;
		data.instrVol = 0.5f;
		data.gamepadSpeaker = true;
		data.vsync = true;
		data.integerScaling = false;
		data.limitColors = false;
		data.brightness = 0f;
		data.fullscreen = true;
		data.fullscreenOption = 1;
		data.vibration = true;
		data.vibrationIntensity = 1f;
		data.triggerEffects = true;
		data.faceMouseDirection = true;
		data.squashBugs = true;
		data.fishingMiniGameEnabled = false;
		data.flashingLights = true;
		data.screenShakes = true;
		data.lang = null;
		data.showDamageNumbers = true;
		data.showCharacterNames = true;
		data.showMinimap = true;
		data.playerGuid = PugRandom.GenerateGuid().ToString();
		data.streamerMode = false;
		data.showKeyHints = true;
		data.shadowQuality = 1;
		data.objectShadows = 2;
		data.dynamicWater = 2;
		data.ssaoQuality = 2;
		data.lightQuality = 2;
		data.particleQuality = 1;
		data.reflections = true;
		data.bloom = 2;
		data.colorRange = 0;
		data.crtFilter = 0;
		data.maxQueuedFrames = 2;
		data.targetFrameRate = -1;
		data.allowJoinByPresence = true;
		data.hideInGameUI = false;
		data.previouslyJoinedServers = new List<SavedServerData>();
		data.previouslyJoinedDirectConnectionServers = new List<SavedServerData>();
		data.hasShownShortCutsWindow = false;
		data.showOutdatedVersionPopUp = true;
		data.showExplorersEditionPopup = true;
		data.showHotbarKeyboardNumbers = true;
		data.showInputMappingResetPopup = true;
		data.showHotbarArrows = true;
		data.godeMode = false;
		data.crossPlay = true;
		data.bilibiliCode = "";
		data.enableTutorial = true;
		data.useRGBEffects = true;
		data.showGroundFog = true;
		serverData.maxNumberPlayers = 100;
		serverData.maxNumberPacketsSentPerFrame = 1;
		serverData.networkSendRate = 20;
		serverData.gameId = null;
		serverData.password = null;
		serverData.world = 0;
		serverData.worldName = "Core Keeper";
		serverData.worldSeed = "";
		serverData.worldMode = WorldMode.Normal;
		serverData.seasonOverride = -1;
		SetFromPlatformConfiguration(PlatformConfiguration.Instance, overwriteUserAdjustableSettings: true);
	}

	private void ReloadAllSettings()
	{
		masterAudioVolume = data.masterAudioVolume;
		musicVolume = data.bgmVol;
		sfxVolume = data.sfxVol;
		ambientSfxVolume = data.ambSfxVol;
		instrumentsSfxVolume = data.instrVol;
		vsync = data.vsync;
		integerScaling = data.integerScaling;
		limitColors = data.limitColors;
		if (Manager.platform.CanSetFullscreen)
		{
			fullscreen = ((data.fullscreenOption == 0) ? 3 : data.fullscreenOption);
		}
		limitColors = data.limitColors;
		vibration = data.vibration;
		vibrationIntensity = data.vibrationIntensity;
		triggerEffects = data.triggerEffects;
		flashingLights = data.flashingLights;
		shadowQuality = data.shadowQuality;
		dynamicWater = data.dynamicWater;
		objectShadows = data.objectShadows;
		ssaoQuality = data.ssaoQuality;
		lightQuality = data.lightQuality;
		particleQuality = data.particleQuality;
		targetFrameRate = data.targetFrameRate;
		bloom = data.bloom;
		hasShownShortCutsWindow = data.hasShownShortCutsWindow;
		GodModeEnabled = data.godeMode;
		Write(force: true);
	}

	private void SetFromPlatformConfiguration(PlatformConfiguration config, bool overwriteUserAdjustableSettings = false)
	{
		if (config == null)
		{
			Debug.LogError("PrefsManager: PlatformConfiguration is null, cannot apply settings.");
			return;
		}
		Debug.Log("PrefsManager: applying settings for platform variant " + config.name + ".");
		Manager.prefs.objectShadows = config.PerformanceDeviceProfile.ObjectShadows;
		Manager.prefs.shadowQuality = (int)config.PerformanceDeviceProfile.ShadowQuality;
		Manager.prefs.dynamicWater = config.PerformanceDeviceProfile.DynamicWater;
		Manager.prefs.ssaoQuality = config.PerformanceDeviceProfile.SsaoQuality;
		Manager.prefs.reflections = config.PerformanceDeviceProfile.Reflections;
		Manager.prefs.bloom = config.PerformanceDeviceProfile.Bloom;
		Manager.prefs.lightQuality = (int)config.PerformanceDeviceProfile.LightQuality;
		Manager.prefs.particleQuality = (int)config.PerformanceDeviceProfile.ParticleQuality;
		Manager.prefs.maxQueuedFrames = config.PerformanceDeviceProfile.MaxQueuedFrames;
		Manager.prefs.targetFrameRate = config.PerformanceDeviceProfile.TargetFrameRate;
		if (overwriteUserAdjustableSettings)
		{
			Manager.prefs.sfxVolume = config.PerformanceDeviceProfile.SfxVolume;
			Manager.prefs.musicVolume = config.PerformanceDeviceProfile.MusicVolume;
			Manager.prefs.ambientSfxVolume = config.PerformanceDeviceProfile.AmbientSfxVolume;
			Manager.prefs.instrumentsSfxVolume = config.PerformanceDeviceProfile.InstrumentVolume;
		}
		Manager.prefs.serverMaxNumberPlayers = config.SessionConfiguration.MaxNumberOfPlayers;
	}

	public override bool Setup()
	{
		return true;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			fileHandle = Manager.filesystemManager.GetFile(FilesystemManager.FileID.Preferences);
			serverFileHandle = Manager.filesystemManager.GetFile(FilesystemManager.FileID.ServerPreferences);
			SetDefault();
			if (Manager.filesystemManager.FileExists(fileHandle))
			{
				try
				{
					JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(Manager.filesystemManager.Read(fileHandle)), data);
				}
				catch (Exception ex)
				{
					Debug.LogError("Removing preferences file because of parse error: " + ex.Message);
					Manager.filesystemManager.Delete(fileHandle);
				}
			}
			if (CommandLineArgs.Has("-serverconfig"))
			{
				string param = CommandLineArgs.GetParam("-serverconfig");
				try
				{
					JsonUtility.FromJsonOverwrite(File.ReadAllText(param), serverData);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("Failed to read file " + param);
				}
			}
			else if (Manager.filesystemManager.FileExists(serverFileHandle))
			{
				try
				{
					JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(Manager.filesystemManager.Read(serverFileHandle)), serverData);
				}
				catch (Exception ex2)
				{
					Debug.LogError("Removing preferences file because of parse error: " + ex2.Message);
					Manager.filesystemManager.Delete(serverFileHandle);
				}
			}
			if (!string.Equals(data.applicationVersion, Application.version))
			{
				Debug.Log("Detected new version, backing up save data...");
				Manager.filesystemManager.Backup();
				data.applicationVersion = Application.version;
			}
			data.hideInGameUI = false;
			ReloadAllSettings();
			return true;
		}
	}

	public override void Deinit()
	{
		Write();
		base.Deinit();
	}

	public void ResetToDefaults()
	{
		SetDefault();
		Write(force: true);
	}

	public void UpdateSeason()
	{
		if (serverSeasonOverride >= 0)
		{
			this.season = (Season)serverSeasonOverride;
			return;
		}
		Season season = seasonsTable.CalculateSeason();
		if (this.season != season)
		{
			Debug.Log($"New season: {season}");
			this.season = season;
		}
	}

	public void SetSeason(Season newSeason)
	{
		if (season != newSeason)
		{
			Debug.Log($"Setting new season: {newSeason}");
			season = newSeason;
		}
	}

	private void SetDirty()
	{
		_isDirty = true;
	}

	public void Write(bool force = false)
	{
		if (!_isDirty && !force)
		{
			Debug.Log("PrefsManager.Write: no need to write settings to disk as they are unchanged.");
			return;
		}
		DebugFlags debugFlags = data.debugFlags;
		byte[] array = EncodeJson(data);
		data.debugFlags &= ~DebugFlags.SaveDisabled;
		Manager.filesystemManager.Write(fileHandle, array);
		byte[] array2 = EncodeJson(serverData);
		data.debugFlags &= ~DebugFlags.SaveDisabled;
		Manager.filesystemManager.Write(serverFileHandle, array2);
		data.debugFlags = debugFlags;
		_isDirty = false;
	}

	private byte[] EncodeJson(object dataObject)
	{
		string text = "";
		text = JsonUtility.ToJson(dataObject, prettyPrint: true);
		if (text == "")
		{
			throw new Exception("Empty JSON");
		}
		return Encoding.UTF8.GetBytes(text);
	}

	private void ReloadLanguage()
	{
		Manager.text.SetLanguageCode(language);
		UnityMainThreadDispatcher.Instance().StartCoroutine(SetModIOBrowserLanguage(language));
	}

	private IEnumerator SetModIOBrowserLanguage(string languageCode)
	{
		WaitForEndOfFrame waitForFrame = new WaitForEndOfFrame();
		bool modIoBrowserReady = false;
		while (!modIoBrowserReady)
		{
			try
			{
				modIoBrowserReady = MonoSingleton<Browser>.Instance != null;
			}
			catch (UnityException)
			{
			}
			yield return waitForFrame;
		}
		Debug.Log("got language code " + languageCode);
		switch (languageCode)
		{
		case "en":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.English);
			break;
		case "de":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.German);
			break;
		case "es":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Spanish);
			break;
		case "ko":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Korean);
			break;
		case "ja":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Japanese);
			break;
		case "zh-CN":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Chinese);
			break;
		case "th":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Thai);
			break;
		case "fr-FR":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.French);
			break;
		case "pt-BR":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.BrazilianPortuguese);
			break;
		case "it-IT":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Italian);
			break;
		case "zh-TW":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.ChineseTraditional);
			break;
		case "uk":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Ukrainian);
			break;
		case "ru":
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.Russian);
			break;
		default:
			Debug.LogWarning("unknown language code for mod.io " + languageCode);
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage(TranslatedLanguages.English);
			break;
		}
	}

	public List<SavedServer> GetPreviousServers(bool directConnectionsList)
	{
		List<SavedServer> list = new List<SavedServer>();
		List<SavedServerData> list2 = (directConnectionsList ? data.previouslyJoinedDirectConnectionServers : data.previouslyJoinedServers);
		for (int num = list2.Count - 1; num >= 0; num--)
		{
			SavedServerData savedServerData = list2[num];
			if (DateTime.TryParse(savedServerData.lastJoin, timeFormatProvider, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeUniversal, out var result))
			{
				list.Insert(0, new SavedServer
				{
					guid = savedServerData.guid,
					name = savedServerData.name,
					gameId = savedServerData.gameId,
					lastJoin = result
				});
			}
			else
			{
				list2.RemoveAt(num);
				Write(force: true);
			}
		}
		return list;
	}

	public void AddOrUpdateServer(string guid, string name, ServerConnectionInfo connectionInfo)
	{
		AddOrUpdateServer(guid, name, connectionInfo, connectionInfo.JoinedWithIP ? data.previouslyJoinedDirectConnectionServers : data.previouslyJoinedServers);
	}

	public void AddOrUpdateServer(string guid, string name, ServerConnectionInfo connectionInfo, List<SavedServerData> serverDataList)
	{
		string lastJoin = DateTime.UtcNow.ToString(timeFormatProvider);
		int i;
		for (i = 0; i < serverDataList.Count; i++)
		{
			if (string.Equals(serverDataList[i].guid, guid))
			{
				SavedServerData value = serverDataList[i];
				value.name = name;
				value.gameId = connectionInfo.ToString();
				value.lastJoin = lastJoin;
				serverDataList[i] = value;
				break;
			}
		}
		if (i == serverDataList.Count)
		{
			while (serverDataList.Count >= 10)
			{
				serverDataList.RemoveAt(serverDataList.Count - 1);
			}
			serverDataList.Add(new SavedServerData
			{
				guid = guid,
				name = name,
				gameId = connectionInfo.ToString(),
				lastJoin = lastJoin
			});
		}
		serverDataList.Sort(delegate(SavedServerData x, SavedServerData y)
		{
			DateTime dateTime = DateTime.Parse(x.lastJoin, timeFormatProvider);
			DateTime value2 = DateTime.Parse(y.lastJoin, timeFormatProvider);
			return -dateTime.CompareTo(value2);
		});
		Write(force: true);
	}

	public void SetServerGameID(ServerConnectionInfo connectionInfo, bool createFile)
	{
		serverGameId = connectionInfo.GameID;
		serverPassword = connectionInfo.Password;
	}

	private void CompileAndCreateGameInfo(ServerConnectionInfo serverConnectionInfo)
	{
		string text = "";
		string text2 = Manager.main.StartupIssueList();
		if (!string.IsNullOrEmpty(text2))
		{
			text = text2 + "\n\n";
		}
		text = ((!serverConnectionInfo.JoinedWithIP) ? (text + "GameID: " + serverConnectionInfo.GameID) : (text + string.Format("Allowed platforms: {0}\n", Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false) ? "All" : ((object)Manager.networking.AllowedPlatforms)) + "Steam GameID: " + serverConnectionInfo.GameID + "\nLocal IP: " + serverConnectionInfo.LocalIP + "\nPublic IP: " + serverConnectionInfo.PublicIP + "\nPort: " + serverConnectionInfo.Port + "\nPassword: " + serverConnectionInfo.Password + "\n\nPaste to ip-field in \"join via IP\" menu to easily fill all values\n" + serverConnectionInfo.CopiedPackedInfo + "\n\n"));
		CreateGameInfoFile(text);
	}

	public static void CreateGameInfoFile(string info)
	{
		string text = Path.Combine(Application.dataPath, "..", "GameInfo.txt");
		Debug.Log("GameInfo path: " + text);
		try
		{
			using FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate);
			fileStream.SetLength(0L);
			byte[] bytes = Encoding.UTF8.GetBytes(info);
			fileStream.Write(bytes, 0, bytes.Length);
		}
		catch
		{
			Debug.LogWarning("Failed to write " + text);
		}
	}

	public static void CreateGameIDFile(ServerConnectionInfo serverConnectionInfo)
	{
		string text = Path.Combine(Application.dataPath, "..", "GameID.txt");
		Debug.Log("GameID path: " + text);
		string text2 = serverConnectionInfo.GameID;
		if (serverConnectionInfo.JoinedWithIP)
		{
			text2 = text2 + "\n" + serverConnectionInfo.LocalIP + "\n" + serverConnectionInfo.PublicIP + "\n" + serverConnectionInfo.Port + "\n" + serverConnectionInfo.Password + "\n" + serverConnectionInfo.CopiedPackedInfo;
		}
		try
		{
			using FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate);
			fileStream.SetLength(0L);
			byte[] bytes = Encoding.UTF8.GetBytes(text2);
			fileStream.Write(bytes, 0, bytes.Length);
		}
		catch
		{
			Debug.LogWarning("Failed to write " + text);
		}
	}
}
