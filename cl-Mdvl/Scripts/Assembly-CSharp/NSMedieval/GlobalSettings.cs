using System;
using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Modding;
using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class GlobalSettings : ISerializationCallbackReceiver
	{
		[SerializeField]
		private Vector2Int refResolution;

		[SerializeField]
		private Vector2Int defaultResolution;

		[SerializeField]
		private int refreshRate;

		[SerializeField]
		private Keybinding[] keybindings;

		[SerializeField]
		private bool autosaveActive;

		[SerializeField]
		private int autosaveFrequency;

		[SerializeField]
		private TemperatureUnitsType temperatureUnits;

		[SerializeField]
		private UISizes currentUISize;

		[SerializeField]
		private bool fullscreen;

		[SerializeField]
		private bool runInBackground;

		[SerializeField]
		private bool screenEdgeMouseScroll;

		[SerializeField]
		private bool showTutorial;

		[SerializeField]
		private float cameraSensitivity;

		[SerializeField]
		private int vsync;

		[SerializeField]
		private bool devTools;

		[SerializeField]
		private bool showWorkerNames;

		[SerializeField]
		private float masterVolume;

		[SerializeField]
		private float musicVolume;

		[SerializeField]
		private float sfxVolume;

		[SerializeField]
		private float ambienceVolume;

		[SerializeField]
		private bool playlistPause;

		[SerializeField]
		private int language;

		[SerializeField]
		private string languageName;

		[SerializeField]
		private int textureQuality;

		[SerializeField]
		private int shadowQuality;

		[SerializeField]
		private bool anisotropicFiltering;

		[SerializeField]
		private int vSync;

		[SerializeField]
		private int fpsCap;

		[SerializeField]
		private bool softParticles;

		[SerializeField]
		private int antiAliasing;

		[SerializeField]
		private bool motionBlur;

		[SerializeField]
		private bool grassHidden;

		[SerializeField]
		private float sharpness;

		[SerializeField]
		private bool ambientOcclusion;

		[SerializeField]
		private bool bloom;

		[SerializeField]
		private bool firstLaunch = true;

		[SerializeField]
		private bool sunBeams;

		[SerializeField]
		private bool environmentFootprintsParticles;

		[SerializeField]
		private bool birdsEffect;

		[SerializeField]
		private bool environmentParticles;

		[SerializeField]
		private bool cameraShake;

		[SerializeField]
		private bool cameraVisuals;

		[SerializeField]
		private bool sendAutoReports;

		[SerializeField]
		private int showAnimalNameOption;

		[SerializeField]
		private float hoverIntensity;

		[SerializeField]
		private int lifeLogLimit;

		[SerializeField]
		private float cameraVisualsDurationTime;

		[SerializeField]
		private bool cameraOffsetByBuildings;

		[SerializeField]
		private List<ModSaveSetting> modSaveSettings;

		[SerializeField]
		private int eulaVersionAccepted;

		[SerializeField]
		private bool tutorialWarningShown;

		[SerializeField]
		private bool tutorialGuidedStepsShow;

		[SerializeField]
		private bool tutorialComplete;

		[SerializeField]
		private bool twitchNameCommandEnabled;

		[SerializeField]
		private bool twitchAppearCommandEnabled;

		[SerializeField]
		private bool twitchGiftCommandEnabled;

		[SerializeField]
		private int twitchGiftCommandCooldown;

		[SerializeField]
		private bool twitchStrikeCommandEnabled;

		[SerializeField]
		private int twitchStrikeCommandCooldown;

		[SerializeField]
		private bool twitchRaidCommandEnabled;

		[SerializeField]
		private int twitchRaidMinViewers;

		[SerializeField]
		private bool twitchNewSettlersEnabled;

		[SerializeField]
		private int twitchNewSettlersCooldown;

		[SerializeField]
		private TwitchSettlerEventType twitchSettlerEventType;

		public Keybinding[] Keybindings => keybindings;

		public int AutosaveFrequency => autosaveFrequency;

		public TemperatureUnitsType TemperatureUnits => temperatureUnits;

		public UISizes CurrentUISize => currentUISize;

		public Vector2Int RefResolution => refResolution;

		public Vector2Int DefaultResolution => defaultResolution;

		public bool Fullscreen => fullscreen;

		public bool RunInBackground => runInBackground;

		public bool AutosaveActive => autosaveActive;

		public bool ScreenEdgeMouseScroll => screenEdgeMouseScroll;

		public float CameraSensitivity => cameraSensitivity;

		public float CameraVisualsDurationTime => cameraVisualsDurationTime;

		public bool CameraOffsetByBuildings => cameraOffsetByBuildings;

		public int VSync => vsync;

		public int FPSCap => fpsCap;

		public int TextureQuality => textureQuality;

		public bool AnisotropicFiltering => anisotropicFiltering;

		public bool DevTools => devTools;

		public bool ShowWorkerNames => showWorkerNames;

		public int ShowAnimalNameOption => showAnimalNameOption;

		public float HoverIntensity => hoverIntensity;

		public bool SendAutoReports => sendAutoReports;

		public float MasterVolume => masterVolume;

		public float MusicVolume => musicVolume;

		public float SfxVolume => sfxVolume;

		public float AmbienceVolume => ambienceVolume;

		public bool PlaylistPause => playlistPause;

		public bool ShowTutorial => showTutorial;

		public int RefreshRate => refreshRate;

		public int Language => language;

		public string LanguageName
		{
			get
			{
				if (string.IsNullOrEmpty(languageName))
				{
					Language language = (Language)this.language;
					languageName = language.ToString();
					this.language = -1;
				}
				if (string.IsNullOrEmpty(languageName))
				{
					languageName = "None";
				}
				return languageName;
			}
		}

		public int ShadowQuality => shadowQuality;

		public bool SoftParticles => softParticles;

		public int AntiAliasing => antiAliasing;

		public bool MotionBlur => motionBlur;

		public bool GrassHidden => grassHidden;

		public float Sharpness => sharpness;

		public bool AmbientOcclusion => ambientOcclusion;

		public bool Bloom => bloom;

		public bool FirstLaunch => firstLaunch;

		public bool SunBeams => sunBeams;

		public bool EnvironmentFootprintsParticles => environmentFootprintsParticles;

		public bool BirdsEffect => birdsEffect;

		public bool EnvironmentParticles => environmentParticles;

		public bool CameraShake => cameraShake;

		public bool CameraVisuals => cameraVisuals;

		public int LifeLogLimit => lifeLogLimit;

		public List<ModSaveSetting> ModSaveSettings => modSaveSettings;

		public int EulaVersionAccepted => eulaVersionAccepted;

		public bool TutorialWarningShown => tutorialWarningShown;

		public bool TutorialGuidedStepsShow => tutorialGuidedStepsShow;

		public bool TutorialComplete => tutorialComplete;

		public bool TwitchNameCommandEnabled => twitchNameCommandEnabled;

		public bool TwitchAppearCommandEnabled => twitchAppearCommandEnabled;

		public bool TwitchGiftCommandEnabled => twitchGiftCommandEnabled;

		public int TwitchGiftCommandCooldown => twitchGiftCommandCooldown;

		public bool TwitchStrikeCommandEnabled => twitchStrikeCommandEnabled;

		public int TwitchStrikeCommandCooldown => twitchStrikeCommandCooldown;

		public bool TwitchRaidCommandEnabled => twitchRaidCommandEnabled;

		public int TwitchRaidMinViewers => twitchRaidMinViewers;

		public bool TwitchNewSettlerEnabled => twitchNewSettlersEnabled;

		public int TwitchNewSettlersCooldown => twitchNewSettlersCooldown;

		public TwitchSettlerEventType TwitchSettlerEventType => twitchSettlerEventType;

		public GlobalSettings(object callerObject)
		{
			if (!Repository<GameSettingsData, GameSettings>.IsInstantiated())
			{
				new GameSettingsData();
			}
			GameSettings data = Repository<GameSettingsData, GameSettings>.Instance.GetData<GameSettings>();
			autosaveFrequency = data.AutosaveFrequency;
			currentUISize = (UISizes)Enum.Parse(typeof(UISizes), Enum.GetName(typeof(UISizes), data.DefaultUiSize));
			refResolution = data.RefResolution;
			defaultResolution = data.DefaultResolution;
			refreshRate = data.RefreshRate;
			fullscreen = data.Fullscreen;
			runInBackground = data.RunInBackground;
			autosaveActive = data.AutosaveActive;
			screenEdgeMouseScroll = data.AllowScreenEdgeMove;
			cameraSensitivity = data.CameraSensitivity;
			devTools = data.DevTools;
			showWorkerNames = data.ShowWorkerNames;
			masterVolume = data.MasterVolume;
			musicVolume = data.MusicVolume;
			sfxVolume = data.SfxVolume;
			ambienceVolume = data.AmbienceVolume;
			playlistPause = data.PlaylistPause;
			showTutorial = data.ShowTutorial;
			language = data.Language;
			textureQuality = data.TextureQuality;
			shadowQuality = data.ShadowQuality;
			anisotropicFiltering = data.AnisotropicFiltering;
			vsync = data.VSync;
			fpsCap = data.FPSCap;
			softParticles = data.SoftParticles;
			antiAliasing = data.AntiAliasing;
			motionBlur = data.MotionBlur;
			grassHidden = data.GrassHidden;
			sharpness = data.Sharpness;
			ambientOcclusion = data.AmbientOcclusion;
			bloom = data.Bloom;
			sunBeams = data.Sunbeams;
			environmentFootprintsParticles = data.EnvironmentFootprintsParticles;
			birdsEffect = data.BirdsEffect;
			environmentParticles = data.EnvironmentParticles;
			cameraShake = data.CameraShake;
			cameraVisuals = data.CameraVisuals;
			cameraVisualsDurationTime = data.CameraVisualsDurationTime;
			cameraOffsetByBuildings = data.CameraOffsetByBuildings;
			sendAutoReports = data.SendAutoReports;
			showAnimalNameOption = data.ShowAnimalNameOption;
			hoverIntensity = data.HoverIntensity;
			lifeLogLimit = data.LifeLogLimit;
			modSaveSettings = new List<ModSaveSetting>();
			eulaVersionAccepted = data.EulaVersionAccepted;
			tutorialWarningShown = data.TutorialWarningShown;
			tutorialGuidedStepsShow = data.TutorialGuidedStepsShow;
			tutorialComplete = data.TutorialComplete;
			twitchNameCommandEnabled = data.TwitchNameCommandEnabled;
			twitchAppearCommandEnabled = data.TwitchAppearCommandEnabled;
			twitchGiftCommandEnabled = data.TwitchGiftCommandEnabled;
			twitchGiftCommandCooldown = data.TwitchGiftCommandCooldown;
			twitchStrikeCommandEnabled = data.TwitchStrikeCommandEnabled;
			twitchStrikeCommandCooldown = data.TwitchStrikeCommandCooldown;
			twitchRaidCommandEnabled = data.TwitchRaidCommandEnabled;
			twitchRaidMinViewers = data.TwitchRaidMinViewers;
			twitchNewSettlersEnabled = data.TwitchNewSettlerEnabled;
			twitchNewSettlersCooldown = data.TwitchNewSettlersCooldown;
			twitchSettlerEventType = data.TwitchSettlerEventType;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			if (keybindings != null && keybindings.Length != 0)
			{
				Keybinding[] array = Repository<DefaultPlayerControlsData, DefaultPlayerControls>.Instance.GetData<DefaultPlayerControls>().Keybindings;
				for (int i = keybindings.Length; i < array.Length; i++)
				{
					Array.Resize(ref keybindings, keybindings.Length + 1);
					keybindings[i] = array[i];
				}
			}
		}

		public void SetKeybindings(Keybinding[] keybindings)
		{
			this.keybindings = keybindings;
		}

		public void SetAutosaveFrequency(int frequency)
		{
			autosaveFrequency = frequency;
		}

		public int GetAutosaveDays()
		{
			return autosaveFrequency switch
			{
				2 => 3, 
				3 => 7, 
				_ => autosaveFrequency, 
			};
		}

		public void SetTemperatureUnits(TemperatureUnitsType units)
		{
			temperatureUnits = units;
		}

		public void SetUISize(UISizes size)
		{
			currentUISize = size;
		}

		public void SetResolution(Vector2Int resolution)
		{
			defaultResolution = resolution;
		}

		public void SetRefreshrate(int rate)
		{
			refreshRate = rate;
		}

		public void SetFullscreen(bool fullscreen)
		{
			this.fullscreen = fullscreen;
		}

		public void SetRunInBackground(bool runInBackground)
		{
			this.runInBackground = runInBackground;
		}

		public void SetScreenEdgeMouseScroll(bool scrollOn)
		{
			screenEdgeMouseScroll = scrollOn;
		}

		public void SetShowTutorial(bool showTutorial)
		{
			this.showTutorial = showTutorial;
		}

		public void SetAutosaveActive(bool active)
		{
			autosaveActive = active;
		}

		public void SetCameraSensitivity(float value)
		{
			cameraSensitivity = value;
		}

		public void SetTextureQuality(int value)
		{
			textureQuality = value;
		}

		public void SetShadowQuality(int value)
		{
			shadowQuality = value;
		}

		public void SetAnisotropicFiltering(bool value)
		{
			anisotropicFiltering = value;
		}

		public void SetVSync(int value)
		{
			vsync = value;
		}

		public void SetFPSCap(int value)
		{
			fpsCap = value;
		}

		public void SetSoftParticles(bool setOn)
		{
			softParticles = setOn;
		}

		public void SetAntiAliasing(int value)
		{
			antiAliasing = value;
		}

		public void SetMotionBlur(bool setOn)
		{
			motionBlur = setOn;
		}

		public void SetGrassHidden(bool grass)
		{
			grassHidden = grass;
		}

		public void SetSharpness(float value)
		{
			sharpness = value;
		}

		public void SetAmbientOcclusion(bool setOn)
		{
			ambientOcclusion = setOn;
		}

		public void SetBloom(bool setOn)
		{
			bloom = setOn;
		}

		public void SetSunbeams(bool setOn)
		{
			sunBeams = setOn;
		}

		public void SetEnvironmentFootprintsParticles(bool setOn)
		{
			environmentFootprintsParticles = setOn;
		}

		public void SetBirdsEffect(bool setOn)
		{
			birdsEffect = setOn;
		}

		public void SetEnvironmentParticles(bool setOn)
		{
			environmentParticles = setOn;
		}

		public void SetCameraShake(bool setOn)
		{
			cameraShake = setOn;
		}

		public void SetCameraVisuals(bool setOn)
		{
			cameraVisuals = setOn;
		}

		public void SetCameraVisualsDurationTime(float value)
		{
			cameraVisualsDurationTime = value;
		}

		public void SetCameraOffsetByBuildings(bool isOn)
		{
			cameraOffsetByBuildings = isOn;
		}

		public void SetDevTools(bool devToolsOn)
		{
			devTools = devToolsOn;
		}

		public void SetSendAutoReports(bool isOn)
		{
			sendAutoReports = isOn;
		}

		public void SetWorkerNames(bool isOn)
		{
			showWorkerNames = isOn;
		}

		public void SetAnimalNames(int selectedOption)
		{
			showAnimalNameOption = selectedOption;
		}

		public void SetHoverIntensity(float value)
		{
			hoverIntensity = value;
		}

		public void SetMasterVolume(float value)
		{
			masterVolume = value;
		}

		public void SetMusicVolume(float value)
		{
			musicVolume = value;
		}

		public void SetSfxVolume(float value)
		{
			sfxVolume = value;
		}

		public void SetAmbienceVolume(float value)
		{
			ambienceVolume = value;
		}

		public void SetMusicPause(bool value)
		{
			playlistPause = value;
		}

		public void SetFirstLaunch(bool value)
		{
			firstLaunch = value;
		}

		public void SetLanguageName(string languageName)
		{
			this.languageName = languageName;
		}

		public void SaveModSettings(IEnumerable<ModInstance> allGeneralMods)
		{
			modSaveSettings.Clear();
			foreach (ModInstance allGeneralMod in allGeneralMods)
			{
				modSaveSettings.Add(new ModSaveSetting(allGeneralMod.SystemId, allGeneralMod.IsEnabled));
			}
		}

		public void SetEulaVersion(int version)
		{
			eulaVersionAccepted = version;
		}

		public void SetTutorialWarningShown()
		{
			tutorialWarningShown = true;
		}

		public void ToggleTutorialGuidedStepsShow()
		{
			tutorialGuidedStepsShow = !tutorialGuidedStepsShow;
		}

		public void SetTutorialComplete()
		{
			tutorialComplete = true;
		}

		public void SetTwitchNameCommandEnabled(bool value)
		{
			twitchNameCommandEnabled = value;
		}

		public void SetTwitchAppearCommandEnabled(bool value)
		{
			twitchAppearCommandEnabled = value;
		}

		public void SetTwitchGiftCommandEnabled(bool value)
		{
			twitchGiftCommandEnabled = value;
		}

		public void SetTwitchGiftCommandCooldown(int value)
		{
			twitchGiftCommandCooldown = value;
		}

		public void SetTwitchStrikeCommandEnabled(bool value)
		{
			twitchStrikeCommandEnabled = value;
		}

		public void SetTwitchStrikeCommandCooldown(int value)
		{
			twitchStrikeCommandCooldown = value;
		}

		public void SetTwitchRaidCommandEnabled(bool value)
		{
			twitchRaidCommandEnabled = value;
		}

		public void SetTwitchRaidMinViewers(int value)
		{
			twitchRaidMinViewers = value;
		}

		public void SetTwitchNewSettlersEnabled(bool value)
		{
			twitchNewSettlersEnabled = value;
		}

		public void SetTwitchNewSettlersCooldown(int value)
		{
			twitchNewSettlersCooldown = value;
		}

		public void SetTwitchSettlerEventType(TwitchSettlerEventType value)
		{
			twitchSettlerEventType = value;
		}
	}
}
