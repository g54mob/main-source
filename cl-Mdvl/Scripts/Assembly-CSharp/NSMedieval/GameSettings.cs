using System;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class GameSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private int allowedAutosaves;

		[SerializeField]
		private int autosaveFrequency;

		[SerializeField]
		private float gameSpeedNormal;

		[SerializeField]
		private float gameSpeedFast;

		[SerializeField]
		private float gameSpeedFaster;

		[SerializeField]
		private float gameSpeedWhenAllSleeping;

		[SerializeField]
		private float gameSpeedDev;

		[SerializeField]
		private float gameSpeedSlow;

		[SerializeField]
		private float gameSpeedSlower;

		[SerializeField]
		private float gameSpeedSuperSlow;

		[SerializeField]
		private Vector2Int refResolution;

		[SerializeField]
		private Vector2Int defaultResolution;

		[SerializeField]
		private int refreshRate;

		[SerializeField]
		private int defaultUISize;

		[SerializeField]
		private bool fullscreen;

		[SerializeField]
		private bool runInBackground;

		[SerializeField]
		private bool autosaveActive;

		[SerializeField]
		private int vsync;

		[SerializeField]
		private bool devTools;

		[SerializeField]
		private bool showWorkerNames;

		[SerializeField]
		private bool showResourceGroups;

		[SerializeField]
		private bool showTutorial;

		[SerializeField]
		private float masterVolume;

		[SerializeField]
		private float musicVolume;

		[SerializeField]
		private bool playlistPause;

		[SerializeField]
		private float sfxVolume;

		[SerializeField]
		private float ambienceVolume;

		[SerializeField]
		private int language;

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
		private bool sunbeams;

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
		private float cameraVisualsDurationTime;

		[SerializeField]
		private bool cameraOffsetByBuildings;

		[SerializeField]
		private bool sendAutoReports;

		[SerializeField]
		private int showAnimalNameOption;

		[SerializeField]
		private float hoverIntensity;

		[SerializeField]
		private int lifeLogLimit;

		[SerializeField]
		private int eulaVersionAccepted;

		[SerializeField]
		private bool allowScreenEdgeMove;

		[SerializeField]
		private float cameraSensitivity;

		[SerializeField]
		private bool cameraLockedToLayer;

		[SerializeField]
		private int lockedLayerIndex;

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

		public int TextureQuality => textureQuality;

		public bool AnisotropicFiltering => anisotropicFiltering;

		public bool AutosaveActive => autosaveActive;

		public int AllowedAutosaves => allowedAutosaves;

		public int AutosaveFrequency => autosaveFrequency;

		public float GameSpeedNormal => gameSpeedNormal;

		public float GameSpeedFast => gameSpeedFast;

		public float GameSpeedWhenAllSleeping => gameSpeedWhenAllSleeping;

		public float GameSpeedFaster => gameSpeedFaster;

		public float GameSpeedSlow => gameSpeedSlow;

		public float GameSpeedSlower => gameSpeedSlower;

		public float GameSpeedSuperSlow => gameSpeedSuperSlow;

		public Vector2Int RefResolution => refResolution;

		public Vector2Int DefaultResolution => defaultResolution;

		public int DefaultUiSize => defaultUISize;

		public bool Fullscreen => fullscreen;

		public bool RunInBackground => runInBackground;

		public int VSync => vsync;

		public bool DevTools => devTools;

		public bool ShowTutorial => showTutorial;

		public bool ShowWorkerNames => showWorkerNames;

		public float MasterVolume => masterVolume;

		public float MusicVolume => musicVolume;

		public float SfxVolume => sfxVolume;

		public float AmbienceVolume => ambienceVolume;

		public bool PlaylistPause => playlistPause;

		public float GameSpeedDev => gameSpeedDev;

		public bool ShowResourceGroups => showResourceGroups;

		public int RefreshRate => refreshRate;

		public int Language => language;

		public int ShadowQuality => shadowQuality;

		public bool SoftParticles => softParticles;

		public int AntiAliasing => antiAliasing;

		public bool MotionBlur => motionBlur;

		public bool GrassHidden => grassHidden;

		public float Sharpness => sharpness;

		public bool AmbientOcclusion => ambientOcclusion;

		public bool Bloom => bloom;

		public bool Sunbeams => sunbeams;

		public bool EnvironmentFootprintsParticles => environmentFootprintsParticles;

		public bool BirdsEffect => birdsEffect;

		public bool EnvironmentParticles => environmentParticles;

		public bool CameraShake => cameraShake;

		public bool CameraVisuals => cameraVisuals;

		public float CameraVisualsDurationTime => cameraVisualsDurationTime;

		public bool CameraOffsetByBuildings => cameraOffsetByBuildings;

		public bool SendAutoReports => sendAutoReports;

		public int FPSCap => fpsCap;

		public int ShowAnimalNameOption => showAnimalNameOption;

		public float HoverIntensity => hoverIntensity;

		public int LifeLogLimit => lifeLogLimit;

		public int EulaVersionAccepted => eulaVersionAccepted;

		public float CameraSensitivity => cameraSensitivity;

		public bool AllowScreenEdgeMove => allowScreenEdgeMove;

		public bool CameraLockedToLayer => cameraLockedToLayer;

		public int LockedLayerIndex => lockedLayerIndex;

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

		public override string GetID()
		{
			return "GameSettings";
		}
	}
}
