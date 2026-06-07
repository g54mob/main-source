using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class PlayerPrefsMgr
{
	[CompilerGenerated]
	private sealed class _003C_WaitAndRefreshUIScale_003Ed__184 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public int tgtWidth;

		public int tgtHeight;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003C_WaitAndRefreshUIScale_003Ed__184(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public const string kPrefSaveSlot = "saveSlot";

	public static int sSaveSlot;

	public const string kPrefVolSound = "volSound";

	public static float sVolSound;

	public const string kPrefVolSFXBus = "volSFXBus";

	public static float[] sVolSFXBus;

	public const string kPrefVolMusic = "volMusic";

	public static float sVolMusic;

	public const string kPrefUseScreenShake = "useScreenShake";

	public static bool sUseScreenShake;

	public const string kPrefShowFPS = "showFPS";

	public static bool sShowFPS;

	public const string kPrefVibration = "vibrationOn";

	public static bool sUseVibration;

	public static float sAspectRatio;

	public static int sUIScale;

	public static float sSmallPixelScale;

	public static float sSmallestPixelScale;

	public static float sSmallestFontScale;

	public const string kPrefFullScreen = "fullScreen";

	public static bool sFullScreen;

	public const string kPrefVSync = "vSync";

	public static int sVSync;

	public const string kPrefGraphicsPreset = "graphicsPreset";

	public static GraphicsPresetLevel sGraphicsPreset;

	public const string kPrefBloom = "bloom";

	public static bool sUseBloom;

	public const string kPrefCRT = "crt";

	public static bool sUseCRT;

	public const string kPrefVignette = "vignette";

	public static bool sUseVignette;

	public const string kPrefChromAberr = "chromAberr";

	public static bool sUseChromAberr;

	public const string kPrefAmbientOccl = "ambientOcclusion";

	public static AmbientOcclusionLevel sAmbientOccl;

	public const string kPrefFPS = "fps";

	public static int sTgtFPS;

	public const string kPrefBatterySaver = "batterySaver";

	public static bool sBatterySaver;

	public const string kPrefFont = "font";

	public static FontType sFontType;

	public const string kPrefShowVersionText = "versionText";

	public static bool sShowVersionText;

	public static DelegateUtl.NoArgsEvent OnShowVersionTextChanged;

	public static HideUIMode sHideUI;

	public const string kPrefGameSpeed = "gameSpeed";

	public static float sGameSpeed;

	public const string kPrefAutofire = "autofire";

	public static bool sAutofire;

	public static DelegateUtl.NoArgsEvent OnAutofireChanged;

	public const string kPrefPoolLevelUps = "poolLevelUps";

	public static bool sPoolLevelUps;

	public const string kPrefDisableChanting = "disableChanting";

	public static bool sDisableChanting;

	public const string kPrefReduceFlashing = "reduceFlashing";

	public static bool sReduceFlashing;

	public static DelegateUtl.NoArgsEvent OnReduceFlashingChanged;

	public const string kPrefSimplifyGraphics = "simplifyGraphics";

	public static bool sSimplifyGraphics;

	public const string kPrefDisableDamageNumbers = "disableDamageNumbers";

	public static bool sDisableDamageNumbers;

	public const string kPrefSlowerSpeed = "slowerSpeed";

	public static bool sSlowerSpeedOptions;

	public const string kPrefUseSystemCursor = "systemCursor";

	public static bool sUseSystemCursor;

	public const string kPrefMoveMouseCursorWithMovement = "moveMouseCursorWithMovement";

	public static bool sMoveMouseCursorWithMovement;

	public const string kPrefCursorSensitivity = "cursorSensitivity";

	public static float sCursorSensitivity;

	public const string kPrefControllerSensitivity = "controllerSensitivity";

	public static float sControllerSensitivity;

	public const string kPrefSkipLevelUpStats = "skipLevelUpStats";

	public static bool sSkipLevelUpStats;

	public const string kPrefHideBlood = "hideBlood";

	public static bool sHideBlood;

	public const string kPrefVizColliders = "vizColliders";

	public static bool sVizColliders;

	public const string kPrefMuteAudioBackground = "muteAudioBackground";

	public static bool sMuteAudioBackground;

	public const string kPrefScreenWidth = "screenWidth";

	public static int sScreenWidth;

	public const string kPrefScreenHeight = "screenHeight";

	public static int sScreenHeight;

	public const string kPrefCheatUnlockFullGame = "cheatUnlockFullGame";

	public static bool sMobileUnlockFullGame;

	public const string kPrefLeftTouchStickRadius = "leftTouchStickRadius";

	public static float sLeftTouchStickRadius;

	public const string kPrefRightTouchStickRadius = "rightTouchStickRadius";

	public static float sRightTouchStickRadius;

	public const string kPrefLeftTouchStickFixed = "leftTouchStickFixed";

	public static bool sFixLeftTouchStickPos;

	public const string kPrefRightTouchStickFixed = "rightTouchStickFixed";

	public static bool sFixRightTouchStickPos;

	public const string kPrefCloudSaveEnabled = "cloudSaveEnabled";

	public static bool sCloudSavesEnabled;

	public static bool sMobileDebugEnabled;

	public static DelegateUtl.NoArgsEvent OnStickRadiusChanged;

	public static bool kIsSmallScreen;

	public const bool kIsLowEndDevice = false;

	public static Rect sScreenSafeArea;

	public const int kVersion = 2;

	public const string kPrefPostLaunch = "cheatShowPostLaunch";

	public static bool sCheatShowPostLaunch;

	public const string kPrefDisableSwirling = "disableSwirling";

	public static bool sDisableSwirling;

	public const string kPrefTwitchPollLen = "twitchPollLen";

	public static float sTwitchPollLen;

	public const string kPrefTwitchCharPoll = "twitchCharPoll";

	public static bool sTwitchCharPoll;

	public const string kPrefTwitchLvlUpPoll = "twitchLvlUpPoll";

	public static bool sTwitchLvlUpPoll;

	public const string kPrefTwitchEvoPoll = "twitchEvoPoll";

	public static bool sTwitchEvoPoll;

	public const string kPrefTwitchFusionPoll = "twitchFusionPoll";

	public static bool sTwitchFusionPoll;

	public const string kPrefTwitchPositiveEvents = "twitchPositiveEvents";

	public static bool sTwitchPositiveEvents;

	public const string kPrefTwitchNegativeEvents = "twitchNegativeEvents";

	public static bool sTwitchNegativeEvents;

	public const string kPrefTwitchEventCooldown = "twitchEventCooldown";

	public static float sTwitchEventCooldown;

	public const string kPrefGameLanguage = "language";

	public static string sGameLanguage;

	public static DelegateUtl.NoArgsEvent OnSaveSlotChanged;

	public static DelegateUtl.NoArgsEvent OnResolutionChanged;

	public static DelegateUtl.NoArgsEvent OnPostProcChanged;

	public static DelegateUtl.NoArgsEvent OnSimplifyGraphicsChanged;

	public static DelegateUtl.NoArgsEvent OnLanguageChanged;

	public static DelegateUtl.NoArgsEvent OnShowFPSChanged;

	public static DelegateUtl.NoArgsEvent OnFPSChanged;

	public static DelegateUtl.NoArgsEvent OnFontTypeChanged;

	public static DelegateUtl.NoArgsEvent OnGameSpeedChanged;

	public static DelegateUtl.NoArgsEvent OnVSyncChanged;

	public static DelegateUtl.NoArgsEvent OnSlowSpeedChanged;

	public static void OnBeforeSceneLoadRuntimeMethod()
	{
	}

	public static void SetSaveSlot(int slot)
	{
	}

	public static void SetUseScreenShake(bool use)
	{
	}

	public static void SetDisableSwirling(bool use)
	{
	}

	public static void SetShowFPS(bool show)
	{
	}

	public static void SetVolSound(float vol)
	{
	}

	public static void SetVolMusic(float vol)
	{
	}

	public static void SetVolSFXBus(SFXBusType bus, float vol)
	{
	}

	public static void SetUseVibration(bool use)
	{
	}

	public static void SetGraphicsPreset(GraphicsPresetLevel lvl)
	{
	}

	public static void SetSimplifyGraphics(bool isOn)
	{
	}

	public static void SetUseBloom(bool use, bool runCallback = true)
	{
	}

	public static void SetUseVignette(bool use, bool runCallback = true)
	{
	}

	public static void SetUseCRT(bool use, bool runCallback = true)
	{
	}

	public static void SetUseChromAberr(bool use, bool runCallback = true)
	{
	}

	public static void SetAmbientOcclusion(AmbientOcclusionLevel lvl, bool runCallback = true)
	{
	}

	public static void SetGameSpeed(float speed)
	{
	}

	public static bool IsSuperSpeed()
	{
		return false;
	}

	public static void SetGameSpeed(GameSpeed spd)
	{
	}

	public static void SetGameLanguage(string language)
	{
	}

	public static float GetGameSpeed(GameSpeed spd)
	{
		return 0f;
	}

	public static void SetFPS(int fps)
	{
	}

	public static void SetFontType(FontType f)
	{
	}

	public static void SetAutofire(bool isOn)
	{
	}

	public static void SetPoolLevelUps(bool isOn)
	{
	}

	public static void SetDisableChanting(bool isDisabled)
	{
	}

	public static void SetReduceFlashing(bool isReduced)
	{
	}

	public static void SetDisableDamageNumbers(bool isDisabled)
	{
	}

	public static void SetSlowerSpeedOptions(bool isEnabled)
	{
	}

	public static void SetUseSystemCursor(bool isEnabled)
	{
	}

	public static void SetMoveMouseCursorWithMovement(bool isEnabled)
	{
	}

	public static void SetPostLaunchContentEnabled(bool isEnabled)
	{
	}

	public static void SetCursorSensitivity(float sensitivity)
	{
	}

	public static void SetControllerSensitivity(float sensitivity)
	{
	}

	public static void SetSkipLevelUpStats(bool isOn)
	{
	}

	public static void SetHideBlood(bool isOn)
	{
	}

	public static void SetVizColliders(bool isOn)
	{
	}

	public static void SetMuteAudioBackground(bool isOn)
	{
	}

	public static void SetLeftTouchStickRadius(float rad)
	{
	}

	public static void SetRightTouchStickRadius(float rad)
	{
	}

	public static void SetLeftTouchStickFixed(bool isOn)
	{
	}

	public static void SetRightTouchStickFixed(bool isOn)
	{
	}

	public static void SetPref(string name, bool val)
	{
	}

	public static void SetPref(string name, int val)
	{
	}

	public static void SetPref(string name, float val)
	{
	}

	public static bool GetPrefBool(string name, bool defaultVal = false)
	{
		return false;
	}

	public static int GetPrefInt(string name, int defaultVal = 0)
	{
		return 0;
	}

	public static void SetVSync(int vSync)
	{
	}

	public static void SetFullScreen(bool isFullScreen)
	{
	}

	public static void SetResolution(int width, int height)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndRefreshUIScale_003Ed__184))]
	private static IEnumerator<float> _WaitAndRefreshUIScale(int tgtWidth, int tgtHeight)
	{
		return null;
	}

	public static void RefreshUIScale()
	{
	}

	public static void SetShowVersion(bool isOn)
	{
	}

	public static void SetBatterySaver(bool isOn)
	{
	}

	public static void SetHideUI(HideUIMode mode)
	{
	}

	public static void SetTwitchPollLen(float len)
	{
	}

	public static void SetTwitchCharPoll(bool isOn)
	{
	}

	public static void SetTwitchLvlUpPoll(bool isOn)
	{
	}

	public static void SetTwitchEvoPoll(bool isOn)
	{
	}

	public static void SetTwitchFusionPoll(bool isOn)
	{
	}

	public static void SetTwitchPositiveEventPoll(bool isOn)
	{
	}

	public static void SetTwitchNegativeEventPoll(bool isOn)
	{
	}

	public static void SetTwitchEventCooldown(float len)
	{
	}

	public static void SetFullGameUnlocked(bool isOn)
	{
	}

	public static void SetCloudSavesEnabled(bool isOn)
	{
	}

	public static bool IsTablet()
	{
		return false;
	}
}
