public enum Preferences
{
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	SeatedPlayAreaType = 0,
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	ComfortTunnel = 1,
	[BlnPref(true, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	SmoothLocomotion = 2,
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	UseControllerDirection = 3,
	[IntPref(1, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	RotationMode = 4,
	[IntPref(3, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	SnapRotationAngle = 5,
	[FltPref(180f, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	SmoothRotationSpeed = 6,
	[FltPref(1f, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	StrafeSpeedMultiplier = 7,
	[FltPref(3f, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	RunSpeedMultiplier = 8,
	[FltPref(0.1f, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	SmoothLocomotionEasing = 9,
	[BlnPref(true, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	CameraDampening = 10,
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	ShovelCoalPhysics = 11,
	[IntPref(2, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	XrGameViewDisplayMode = 12,
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	PlayAreaIndicator = 13,
	[FltPref(0f, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	PlayerSeatedHeight = 14,
	[FltPref(0f, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	PlayerRoomscaleHeight = 15,
	[IntPref(0, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	VRTeleportOrientation = 16,
	[BlnPref(true, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	TouchInteraction = 17,
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	WandPressToMove = 18,
	[BlnPref(false, PreferenceCategory.VR, PreferencesExclusivity.VR)]
	VRDebugShortcuts = 19,
	[BlnPref(false, PreferenceCategory.Controls, PreferencesExclusivity.NonVR)]
	InvertMouseY = 20,
	[BlnPref(false, false, PreferenceCategory.Controls, PreferencesExclusivity.Any)]
	AlwaysRunToggle = 21,
	[FltPref(2f, PreferenceCategory.Controls, PreferencesExclusivity.NonVR)]
	MouseSensitivity = 22,
	[IntPref(0, PreferenceCategory.Controls, PreferencesExclusivity.NonVR)]
	Crosshair = 23,
	[BlnPref(true, PreferenceCategory.Controls, PreferencesExclusivity.NonVR)]
	LeanToggle = 24,
	[BlnPref(false, false, PreferenceCategory.Controls, PreferencesExclusivity.Any)]
	CrouchToggle = 25,
	[BlnPref(false, false, PreferenceCategory.Controls, PreferencesExclusivity.Any)]
	RunToggle = 26,
	[BlnPref(true, true, PreferenceCategory.Controls, PreferencesExclusivity.Any)]
	HeadBob = 27,
	[IntPref(2, PreferenceCategory.Controls, PreferencesExclusivity.VR)]
	ItemHoldType = 28,
	[IntPref(1, PreferenceCategory.Controls, PreferencesExclusivity.Any)]
	ScrollDownMeansRight = 29,
	[BlnPref(false, PreferenceCategory.Controls, PreferencesExclusivity.Any)]
	InvertPageFlipping = 30,
	[BlnPref(false, PreferenceCategory.Game, PreferencesExclusivity.NonVR)]
	PauseInBackground = 31,
	[IntPref(0, PreferenceCategory.Game, PreferencesExclusivity.NonVR)]
	MouseDrag = 32,
	[BlnPref(true, true, PreferenceCategory.Game, PreferencesExclusivity.Any)]
	HighlightCabToggle = 33,
	[BlnPref(true, true, PreferenceCategory.Game, PreferencesExclusivity.Any)]
	HighlightSigns = 34,
	[BlnPref(true, true, PreferenceCategory.Game, PreferencesExclusivity.Any)]
	HighlightControls = 35,
	[BlnPref(true, false, PreferenceCategory.Game, PreferencesExclusivity.Any)]
	HighlightItems = 36,
	[BlnPref(false, false, PreferenceCategory.Game, PreferencesExclusivity.Any)]
	TelemetryEnabled = 37,
	[IntPref(3, 3, PreferenceCategory.Game, PreferencesExclusivity.Any)]
	AutosaveInterval = 38,
	[BlnPref(true, PreferenceCategory.Game, PreferencesExclusivity.NonVR)]
	PhotomodeAutopause = 39,
	[FltPref(1f, PreferenceCategory.Game, PreferencesExclusivity.NonVR)]
	PhotomodeSmoothing = 40,
	[IntPref(2, 2, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	AnisotropicFiltering = 41,
	[IntPref(4, 6, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	ShadowsQualityIndex = 42,
	[IntPref(2, 2, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	TerrainLightingQualityIndex = 43,
	[IntPref(3, 4, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	ReflectionQualityIndex = 44,
	[IntPref(3, 3, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	RainQualityIndex = 45,
	[IntPref(5, 7, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	VegetationQualityIndex = 46,
	[IntPref(3, 3, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	AntiAliasingForwardLevelsIndex = 47,
	[IntPref(1, 1, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	AntiAliasingDeferredLevelsIndex = 48,
	[IntPref(2, 2, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	DetailLevel = 49,
	[IntPref(2, 2, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	LightingQualityIndex = 50,
	[BlnPref(true, true, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	PostProcessing = 51,
	[BlnPref(true, PreferenceCategory.Graphics, PreferencesExclusivity.NonVR)]
	MotionBlur = 52,
	[IntPref(60, 120, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	MotionBlurReferenceFPS = 53,
	[IntPref(2, 2, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	AmbientOcclusionQualityIndex = 54,
	[IntPref(1920, PreferenceCategory.Graphics, PreferencesExclusivity.NonVR)]
	ScreenResolutionWidth = 55,
	[IntPref(1080, PreferenceCategory.Graphics, PreferencesExclusivity.NonVR)]
	ScreenResolutionHeight = 56,
	[FltPref(50f, PreferenceCategory.Graphics, PreferencesExclusivity.NonVR)]
	FieldOfView = 57,
	[IntPref(0, PreferenceCategory.Graphics, PreferencesExclusivity.NonVR)]
	FrameLimit = 58,
	[BlnPref(true, true, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	TextureStreamingEnabled = 59,
	[FltPref(0.7f, 0.7f, PreferenceCategory.Graphics, PreferencesExclusivity.Any)]
	TextureStreamingMemoryBudget = 60,
	[BlnPref(true, true, PreferenceCategory.Audio, PreferencesExclusivity.Any)]
	RadioSignalLoss = 61,
	[FltPref(1f, 1f, PreferenceCategory.Audio, PreferencesExclusivity.Any)]
	MasterVolumeLevel = 62,
	[FltPref(0.3f, 0.3f, PreferenceCategory.Audio, PreferencesExclusivity.Any)]
	MainMenuMusicVolume = 63
}
