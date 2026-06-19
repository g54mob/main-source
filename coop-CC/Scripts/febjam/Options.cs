using Aggro.Core;
using FMODUnity;
using Mirror;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Options
{
	private class OptionsInputController : IInputController
	{
		public GameObject selected;

		public void OnInputControlGained()
		{
			AggroInputManager.DisableUIModule();
		}

		public void OnInputControlLost()
		{
			if (AggroInputManager.mode == InputMode.Gamepad)
			{
				EventSystem.current.SetSelectedGameObject(selected);
			}
		}
	}

	private const bool IS_CONSOLE = false;

	private static bool _initialized;

	private static OptionsInputController _inputController = new OptionsInputController();

	private static readonly int RENDER_SCALE_ID = AggroSettings.IdToHash("video-renderscale");

	private static readonly int RENDER_SCALE_SHADER_ID = Shader.PropertyToID("_RenderScale");

	private static readonly int UseUIWobble = Shader.PropertyToID("_UseUIWobble");

	private const int DRIVING = 1;

	private const int GAME_ACTIONS = 2;

	private const int TIPTAP_ACTIONS = 3;

	private const int DRIVING_MASK = 2;

	private const int GAME_ACTIONS_MASK = 4;

	private const int TIPTAP_ACTIONS_MASK = 8;

	private const int ALL_ACTIONS_MASK = 14;

	private const int GAME_ONLY_ACTIONS_MASK = 6;

	public static float renderScale => AggroSettings.GetFloat(RENDER_SCALE_ID);

	[RuntimeInitializeOnLoadMethod]
	private static void RuntimeInit()
	{
		_initialized = false;
	}

	public static void Initialize()
	{
		if (!_initialized)
		{
			_initialized = true;
			AggroSettings.Initialize(localized: true, delegate
			{
				AggroInputManager.PushController(_inputController);
			}, delegate(GameObject selected)
			{
				_inputController.selected = selected;
				AggroInputManager.RemoveController(_inputController);
			});
			AddGameSettings();
			AddVideoSettings();
			AddAudioSettings();
			AddControlsSettings();
			AggroSettings.LoadAll();
			AggroSettings.SaveAll();
		}
	}

	private static void AddGameSettings()
	{
		AggroSettings.AddSetting("game-language", "game", "SETTINGLANGUAGE", new LanguageSetting());
		AggroSettings.AddSetting("game-controllershake", "game", "SETTINGCONTROLLERSHAKE", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f));
		AggroSettings.AddSetting("game-invertReverse", "game", "SETTINGINVERTREVERSE", new ToggleSetting(defaultValue: true));
		AggroSettings.AddSetting("game-screenshake", "game", "SETTINGSCREENSHAKE", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f));
		AggroSettings.AddSetting("game-lobbyallowfriends", "game", "SETTINGLOBBYALLOWFRIENDS", new DropdownSetting(1, new string[2] { "SETTINGLOBBYALLOWFRIENDSINVITEONLY", "SETTINGLOBBYALLOWFRIENDSALLOWED" }, delegate(int index)
		{
			if (AggroNetworkManager.networkMode == NetworkManagerMode.Host)
			{
				Aggro.Core.Platform.SetLobbyAllowFriends(index != 0);
			}
		}));
	}

	private static void AddVideoSettings()
	{
		AggroSettings.AddSetting("video-resolution", "video", "SETTINGVIDEORESOLUTION", new ResolutionSetting(0, 0, int.MaxValue, int.MaxValue, 1.6f));
		AggroSettings.AddSetting("video-fullscreenmode", "video", "SETTINGFULLSCREENMODE", new FullScreenModeSetting());
		AggroSettings.AddSetting("video-framerate", "video", "SETTINGFRAMERATE", new FloatSetting(FloatSetting.Style.Integer, 30f, 240f, 60f, delegate(float x)
		{
			if (Application.isEditor)
			{
				Application.targetFrameRate = -1;
			}
			else
			{
				Application.targetFrameRate = Mathf.RoundToInt(x);
			}
		}));
		AggroSettings.AddSetting("video-vsync", "video", "SETTINGVSYNC", new ToggleSetting(QualitySettings.vSyncCount == 1, delegate(bool x)
		{
			if (Application.isEditor)
			{
				QualitySettings.vSyncCount = 0;
			}
			else
			{
				QualitySettings.vSyncCount = (x ? 1 : 0);
			}
		}));
		AggroSettings.AddSetting("video-renderscale", "video", "SETTINGVIDEORENDERSCALE", new FloatSetting(FloatSetting.Style.Percentage, 0.5f, 1f, (Aggro.Core.Platform.GetPlatformType() == PlatformType.SteamDeck) ? 0.75f : 1f, delegate(float x)
		{
			Shader.SetGlobalFloat(RENDER_SCALE_SHADER_ID, MathUtil.CeilToIncrement(x, 0.01f));
		}));
		AggroSettings.AddSetting("video-depthoffield", "video", "SETTINGDEPTHOFFIELD", new ToggleSetting(defaultValue: true, delegate(bool x)
		{
			PostProcessingSettings.SetDepthOfFieldAllPosts(x);
		}));
		AggroSettings.AddSetting("video-bloom", "video", "SETTINGBLOOM", new ToggleSetting(defaultValue: true, delegate(bool x)
		{
			PostProcessingSettings.SetBloomAllPosts(x);
		}));
		AggroSettings.AddSetting("video-aggroao", "video", "SETTINGAMBIENTOCCLUSION", new ToggleSetting(true, null, true));
		AggroSettings.AddSetting("video-fxaa", "video", "SETTINGFXAA", new ToggleSetting(true, null, true));
		AggroSettings.AddSetting("video-uiwobble", "video", "SETTINGUIWOBBLE", new ToggleSetting(defaultValue: true, delegate(bool x)
		{
			Shader.SetGlobalFloat(UseUIWobble, x ? 1f : 0f);
		}));
	}

	private static void AddAudioSettings()
	{
		AggroSettings.AddSetting("audio-game", "audio", "SETTINGGAMEVOLUME", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f, delegate(float x)
		{
			AudioManager.SetGameVolume(x);
		}));
		AggroSettings.AddSetting("audio-music", "audio", "SETTINGMUSICVOLUME", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f, delegate(float x)
		{
			AudioManager.SetMusicVolume(x);
		}));
		AggroSettings.AddSetting("audio-sfx", "audio", "SETTINGSFXVOLUME", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f, delegate(float x)
		{
			AudioManager.SetSfxVolume(x);
		}, RuntimeManager.PathToEventReference("event:/COC/UI/audio-sfx-Volume")));
		AggroSettings.AddSetting("audio-ui", "audio", "SETTINGUIVOLUME", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f, delegate(float x)
		{
			AudioManager.SetUIVolume(x);
		}, RuntimeManager.PathToEventReference("event:/COC/UI/audio-ui-Volume")));
		AggroSettings.AddSetting("audio-vo", "audio", "SETTINGVOVOLUME", new FloatSetting(FloatSetting.Style.Percentage, 0f, 1f, 1f, delegate(float x)
		{
			AudioManager.SetVOVolume(x);
		}, RuntimeManager.PathToEventReference("event:/COC/UI/audio-vo-Volume"), RuntimeManager.PathToEventReference("event:/COC/UI/audio-vo-Off")));
		AggroSettings.AddSetting("audio-mono", "audio", "SETTINGMONO", new ToggleSetting(defaultValue: false, delegate(bool x)
		{
			AudioManager.SetMonoAudio(x);
		}));
		AggroSettings.AddSetting("audio-output", "audio", "SETTINGOUTPUTDEVICE", new FMODAudioOutputSetting());
		AggroSettings.AddSetting("audio-input", "audio", "SETTINGINPUTDEVICE", new FMODAudioInputSetting());
		AggroSettings.AddSetting("audio-voip", "audio", "SETTINGVOIP", new DropdownSetting(0, new string[3] { "SETTINGVOIPACTIVE", "SETTINGVOIPPTT", "SETTINGVOIPDISABLED" }));
	}

	private static void AddControlsSettings()
	{
		AggroSettings.AddSetting("controls-forward", "controls", "CONTROLSFORWARD", new InputSetting(AggroInputManager.input.Game.Steering, AggroInputManager.GetKbmCompositeBinding("Up"), InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, null, InputRebindGamepadMask.None, 1, 14));
		AggroSettings.AddSetting("controls-left", "controls", "CONTROLSLEFT", new InputSetting(AggroInputManager.input.Game.Steering, AggroInputManager.GetKbmCompositeBinding("Left"), InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, null, InputRebindGamepadMask.None, 1, 14));
		AggroSettings.AddSetting("controls-brakeReverse", "controls", "CONTROLSBRAKEREVERSE", new InputSetting(AggroInputManager.input.Game.Brake, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 1, 14));
		AggroSettings.AddSetting("controls-right", "controls", "CONTROLSRIGHT", new InputSetting(AggroInputManager.input.Game.Steering, AggroInputManager.GetKbmCompositeBinding("Right"), InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, null, InputRebindGamepadMask.None, 1, 14));
		AggroSettings.AddSetting("controls-steering", "controls", "CONTROLSSTEERING", new InputSetting(AggroInputManager.input.Game.Steering, null, InputRebindKbmMask.None, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.ReadOnly, 1, 14));
		AggroSettings.AddSetting("controls-boost", "controls", "CONTROLSBOOST", new InputSetting(AggroInputManager.input.Game.Gas, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-horn", "controls", "CONTROLSHORN", new InputSetting(AggroInputManager.input.Game.Beep, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-drift", "controls", "CONTROLSDRIFT", new InputSetting(AggroInputManager.input.Game.Drift, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-raiseLower", "controls", "CONTROLSRAISELOWER", new InputSetting(AggroInputManager.input.Game.RaiseLower, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-grabRelease", "controls", "CONTROLSGRABRELEASE", new InputSetting(AggroInputManager.input.Game.GrabRelease, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-stationRotateClockwise", "controls", "CONTROLSSTATIONROTATECLOCKWISE", new InputSetting(AggroInputManager.input.Game.StationRotateClockwise, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-stationRotateCounterClockwise", "controls", "CONTROLSSTATIONROTATECOUNTERCLOCKWISE", new InputSetting(AggroInputManager.input.Game.StationRotateCounterClockwise, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-stationPlace", "controls", "CONTROLSSTATIONPLACE", new InputSetting(AggroInputManager.input.Game.StationPlace, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-useBox", "controls", "CONTROLSUSEBOX", new InputSetting(AggroInputManager.input.Game.UseBox, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 2, 6));
		AggroSettings.AddSetting("controls-swipeUpTipTap", "controls", "CONTROLSSWIPEUPTIPTAP", new InputSetting(AggroInputManager.input.Game.SwipeUpTipTap, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.MouseScroll | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 3, 10));
		AggroSettings.AddSetting("controls-swipeDownTipTap", "controls", "CONTROLSSWIPEDOWNTIPTAP", new InputSetting(AggroInputManager.input.Game.SwipeDownTipTap, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.MouseScroll | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 3, 10));
		AggroSettings.AddSetting("controls-likeTipTap", "controls", "CONTROLSLIKETIPTAP", new InputSetting(AggroInputManager.input.Game.SwipeRightTipTap, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 3, 10));
		AggroSettings.AddSetting("controls-shareTipTap", "controls", "CONTROLSSHARETIPTAP", new InputSetting(AggroInputManager.input.Game.SwipeLeftTipTap, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtonsButStick, 3, 10));
		AggroSettings.AddSetting("controls-ptt", "controls", "SETTINGPTT", new InputSetting(AggroInputManager.input.Always.PTT, AggroInputManager.kbmInputBinding, InputRebindKbmMask.MouseButtons | InputRebindKbmMask.KeyboardKeys, AggroInputManager.gamepadInputBinding, InputRebindGamepadMask.AllButtons));
	}
}
