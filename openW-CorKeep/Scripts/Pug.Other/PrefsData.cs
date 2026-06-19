using System;
using System.Collections.Generic;

[Serializable]
public class PrefsData
{
	public int version;

	public string applicationVersion;

	public float masterAudioVolume;

	public float sfxVol;

	public float ambSfxVol;

	public float bgmVol;

	public float instrVol;

	public bool gamepadSpeaker;

	public bool vsync;

	public bool integerScaling;

	public bool limitColors;

	public float brightness;

	public bool fullscreen;

	public int fullscreenOption;

	public bool vibration;

	public float vibrationIntensity;

	public bool faceMouseDirection;

	public bool squashBugs;

	public bool fishingMiniGameEnabled;

	public bool flashingLights;

	public bool screenShakes;

	public string lang;

	public DebugFlags debugFlags;

	public bool showDamageNumbers;

	public bool showCharacterNames;

	public bool showMinimap;

	public string playerGuid;

	public bool streamerMode;

	public bool showKeyHints;

	public int shadowQuality;

	public int objectShadows;

	public int dynamicWater;

	public int ssaoQuality;

	public bool reflections;

	public int bloom;

	public int colorRange;

	public int crtFilter;

	public int targetFrameRate;

	public int maxQueuedFrames;

	public bool allowJoinByPresence;

	public int lightQuality;

	public bool hideInGameUI;

	public int particleQuality;

	public List<SavedServerData> previouslyJoinedServers;

	public List<SavedServerData> previouslyJoinedDirectConnectionServers;

	public bool hasShownShortCutsWindow;

	public bool showOutdatedVersionPopUp;

	public bool showEulaPopUp;

	public bool showExplorersEditionPopup;

	public bool showHotbarKeyboardNumbers;

	public bool showHotbarArrows;

	public bool godeMode;

	public bool crossPlay;

	public bool triggerEffects;

	public string bilibiliCode;

	public bool enableTutorial;

	public bool showInputMappingResetPopup;

	public bool allowTouchpad;

	public bool useRGBEffects;

	public bool showGroundFog;

	public bool hasOpenedConsoleCommands;
}
