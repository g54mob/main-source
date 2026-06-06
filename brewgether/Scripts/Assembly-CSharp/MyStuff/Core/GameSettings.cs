using System;
using UnityEngine;

namespace MyStuff.Core
{
	[Serializable]
	public class GameSettings
	{
		public int screenWidth;

		public int screenHeight;

		public FullScreenMode fullScreenMode;

		public int refreshRate;

		public bool vSyncEnabled;

		public int targetFrameRate;

		public int graphicsQualityPreset;

		public string visualPresetName;

		public float fieldOfView;

		public float brightness;

		public float gamma;

		public float shadowLift;

		public float drinkVisionIntensity;

		public int shadowQualityOverride;

		public int antiAliasingOverride;

		public float renderScaleOverride;

		public int ssaoOverride;

		public int bloomOverride;

		public int depthOfFieldOverride;

		public int motionBlurOverride;

		public int filmGrainOverride;

		public int vignetteOverride;

		public int chromaticAberrationOverride;

		public float masterVolume;

		public float musicVolume;

		public float sfxVolume;

		public float ambienceVolume;

		public float voiceVolume;

		public float vehicleVolume;

		public float micVolume;

		public bool micMuted;

		public float mouseSensitivityX;

		public float mouseSensitivityY;

		public float uiScale;

		private const string PREFIX = "GameSettings_";

		private const string KEY_SCREEN_WIDTH = "GameSettings_ScreenWidth";

		private const string KEY_SCREEN_HEIGHT = "GameSettings_ScreenHeight";

		private const string KEY_FULLSCREEN_MODE = "GameSettings_FullScreenMode";

		private const string KEY_REFRESH_RATE = "GameSettings_RefreshRate";

		private const string KEY_VSYNC = "GameSettings_VSync";

		private const string KEY_TARGET_FPS = "GameSettings_TargetFPS";

		private const string KEY_QUALITY_PRESET = "GameSettings_QualityPreset";

		private const string KEY_VISUAL_PRESET = "GameSettings_VisualPreset";

		private const string KEY_FOV = "GameSettings_FOV";

		private const string KEY_BRIGHTNESS = "GameSettings_Brightness";

		private const string KEY_GAMMA = "GameSettings_Gamma";

		private const string KEY_SHADOW_LIFT = "GameSettings_ShadowLift";

		private const string KEY_DRINK_VISION_INTENSITY = "GameSettings_DrinkVisionIntensity";

		private const string KEY_MASTER_VOLUME = "GameSettings_MasterVolume";

		private const string KEY_MUSIC_VOLUME = "GameSettings_MusicVolume";

		private const string KEY_SFX_VOLUME = "GameSettings_SFXVolume";

		private const string KEY_AMBIENCE_VOLUME = "GameSettings_AmbienceVolume";

		private const string KEY_VOICE_VOLUME = "GameSettings_VoiceVolume";

		private const string KEY_VEHICLE_VOLUME = "GameSettings_VehicleVolume";

		private const string KEY_MIC_VOLUME = "GameSettings_MicVolume";

		private const string KEY_MIC_MUTED = "GameSettings_MicMuted";

		private const string KEY_MOUSE_SENSITIVITY_X = "GameSettings_MouseSensitivityX";

		private const string KEY_MOUSE_SENSITIVITY_Y = "GameSettings_MouseSensitivityY";

		private const string KEY_UI_SCALE = "GameSettings_UIScale";

		private const string KEY_SHADOW_QUALITY_OVERRIDE = "GameSettings_ShadowQualityOverride";

		private const string KEY_ANTI_ALIASING_OVERRIDE = "GameSettings_AntiAliasingOverride";

		private const string KEY_RENDER_SCALE_OVERRIDE = "GameSettings_RenderScaleOverride";

		private const string KEY_SSAO_OVERRIDE = "GameSettings_SSAOOverride";

		private const string KEY_BLOOM_OVERRIDE = "GameSettings_BloomOverride";

		private const string KEY_DOF_OVERRIDE = "GameSettings_DepthOfFieldOverride";

		private const string KEY_MOTION_BLUR_OVERRIDE = "GameSettings_MotionBlurOverride";

		private const string KEY_FILM_GRAIN_OVERRIDE = "GameSettings_FilmGrainOverride";

		private const string KEY_VIGNETTE_OVERRIDE = "GameSettings_VignetteOverride";

		private const string KEY_CHROMATIC_ABERRATION_OVERRIDE = "GameSettings_ChromaticAberrationOverride";

		public const int QUALITY_LOW = 0;

		public const int QUALITY_MEDIUM = 1;

		public const int QUALITY_HIGH = 2;

		public const int QUALITY_ULTRA = 3;

		public const int QUALITY_CINEMATIC = 4;

		public const int QUALITY_NOT_SET = -1;

		public static string GetQualityPresetName(int level)
		{
			return null;
		}

		public static int AutoDetectQualityPreset()
		{
			return 0;
		}

		public void Save()
		{
		}

		public static GameSettings Load()
		{
			return null;
		}

		public static GameSettings CreateDefault()
		{
			return null;
		}

		public static void DeleteAll()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
