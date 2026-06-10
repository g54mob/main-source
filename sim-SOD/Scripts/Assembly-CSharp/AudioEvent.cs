using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "audioevent_data", menuName = "Audio/Audio Event")]
public class AudioEvent : SoCustomComparison
{
	public enum MemoryTag
	{
		none = 0,
		gunshot = 1,
		scream = 2
	}

	[OnValueChanged("OnGUIDValueChangedCallback")]
	[Tooltip("Paste the GUID from FMOD in here. Curly braces will be removed.")]
	[Header("Setup")]
	public string guid;

	[Tooltip("If enabled, this sound's occlusion will never be checked")]
	public bool disableOcclusion;

	[Tooltip("If enabled, this will print out debug info in the console")]
	public bool debug;

	[Tooltip("If enabled, this run the sound through the occlusion and AI checks without physically playing it")]
	public bool isDummyEvent;

	[Tooltip("Is this a licensed music track?")]
	public bool isLicensed;

	[Header("Loop Settings")]
	[Tooltip("Do we want this to pause when the game pauses?")]
	public bool pauseWhenGameIsPaused;

	[Header("Disable")]
	[Tooltip("Disable this in-game completely.")]
	public bool disabled;

	[Header("Occlusion")]
	[Tooltip("If true this sound can penetrate walls")]
	public bool canPenetrateWalls;

	[Tooltip("If true this sound can penetrate floors")]
	public bool canPenetrateFloors;

	[Tooltip("If true this sound can penetrate cielings")]
	public bool canPenetrateCeilings;

	[Space(7f)]
	public bool overrideMaximumLoops;

	[InfoBox("If more than one of wall/floor/ceiling penetration is enabled, it is recommended to increase the maximum possible loops for this sound to reach the listener properly", EInfoBoxType.Normal)]
	[EnableIf("overrideMaximumLoops")]
	public int overriddenMaxLoops;

	[Space(7f)]
	[Tooltip("Overrides default occlusion value sound in the audio controller")]
	public bool overrideOcclusionModifier;

	[EnableIf("overrideOcclusionModifier")]
	[InfoBox("If overridden, make sure this is set to below 0, otherwise it may cause occlusion evalulation problems.", EInfoBoxType.Normal)]
	[Tooltip("Each occlusion unit will decrease volume by this amount...")]
	public float occlusionUnitVolumeModifier;

	[Space(7f)]
	public bool overrideOpenDoorOcclusion;

	[Range(0f, 10f)]
	[EnableIf("overrideOpenDoorOcclusion")]
	public int openDoorOcclusionUnits;

	public bool overrideClosedDoorOcclusion;

	[EnableIf("overrideClosedDoorOcclusion")]
	[Range(0f, 10f)]
	public int closedDoorOcclusionUnits;

	public bool overrideWindowOcclusion;

	[EnableIf("overrideWindowOcclusion")]
	[Range(0f, 10f)]
	public int windowOcclusionUnits;

	public bool overrideWallOcclusion;

	[EnableIf("overrideWallOcclusion")]
	[Range(0f, 10f)]
	public int wallOcclusionUnits;

	public bool overrideCeilingOcclusion;

	[EnableIf("overrideCeilingOcclusion")]
	[Range(0f, 10f)]
	public int ceilingOcclusionUnits;

	public bool overrideFloorOcclusion;

	[Range(0f, 10f)]
	[EnableIf("overrideFloorOcclusion")]
	public int floorOcclusionUnits;

	[Tooltip("On updated occlusion, force the volume to change level at a specific rate (seconds)")]
	[Space(7f)]
	public bool forceVolumeLevelFadeTime;

	[EnableIf("forceVolumeLevelFadeTime")]
	public float volumeLevelFadeTime;

	[Header("Suspicion")]
	[Tooltip("Can this audio trigger an AI reaction?")]
	public bool canBeSuspicious;

	[Space(7f)]
	[Tooltip("This event will by default trigger an AI reaction")]
	[EnableIf("canBeSuspicious")]
	public bool alwaysSuspicious;

	[Tooltip("This event will only trigger an AI reaction if 1) The actor is trespassing and 2) The listener is allowed to go there without trespassing.")]
	[EnableIf("canBeSuspicious")]
	public bool suspiciousIfTresspassing;

	[EnableIf("canBeSuspicious")]
	[Tooltip("This event is only considered suspicious if the AI can't see the player")]
	[InfoBox("The following will override the above settings", EInfoBoxType.Normal)]
	[Space(7f)]
	public bool suspiciousIfCantSeeSoundMaker;

	[Tooltip("This event will only trigger an AI reaction if the address is empty apart from the player and the following number of people")]
	[EnableIf("canBeSuspicious")]
	public bool onlySuspiciousIfEmptyAddress;

	[Tooltip("Only suspicious if not caused by an enforcer")]
	[EnableIf("canBeSuspicious")]
	public bool onlySuspiciousIfNotEnforcer;

	[EnableIf("canBeSuspicious")]
	public int suspiciousIfCitizenCount;

	[Tooltip("If this event is urgency (eg gunshot), AI will immediately run for investiation")]
	public bool urgentResponse;

	[Tooltip("AI hearing this event triggers this amount of audio focus. 1 Will mean they investigate immediately, any less will be added within their focus window...")]
	[Range(0f, 1f)]
	public float audioFocus;

	[EnableIf("canBeSuspicious")]
	[Space(5f)]
	[Tooltip("Force this to display a red outline if this loop is heard by the player")]
	public bool forceOutlineForLoopIfPlayerTrespassing;

	public MemoryTag citizenMemoryTag;

	[Space(7f)]
	[Tooltip("Will citizens get scared by this?")]
	public float spookValue;

	[Tooltip("Enforcers do not get scared by this")]
	public bool noSpookIfEnforcer;

	[Tooltip("If the AI is asleep, how likely is it that they awaken upon hearing this? (Only works in conjunction with suspicious sounds)")]
	[Range(0f, 1f)]
	[Header("AI Hearing and Emulation")]
	public float awakenChance;

	[ReadOnly]
	[Tooltip("The actual sound range set in FMOD.")]
	public float actualSoundRange;

	[Tooltip("The effective sound range that the AI can hear (applied to actual sound range above)")]
	public float hearingRange;

	[Tooltip("If in stealth mode, also apply the following modifier to the hearing range...")]
	public float stealthModeModifier;

	[Tooltip("If running apply the following modifier to the hearing range...")]
	public float runModifier;

	[Tooltip("Can the AI dance to this?")]
	public bool canDanceTo;

	[Header("Overrides")]
	[Range(0f, 1f)]
	public float masterVolumeScale;

	[Tooltip("If true then the AI 'sound level' above is overridden based on surface type. Important: Only works for footsteps!")]
	public bool modifyBasedOnSurface;

	[EnableIf("modifyBasedOnSurface")]
	public float concreteHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float woodHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float carpetHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float tileHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float plasterHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float fabricHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float metalHearingRangeModifier;

	[EnableIf("modifyBasedOnSurface")]
	public float glassHearingRangeModifier;

	[Header("Force Feedback")]
	public bool enableVibrationOnPlay;

	[Tooltip("You might want to disable this if we have haptics in-place instead...")]
	public bool disableForPS5;

	[EnableIf("enableVibrationOnPlay")]
	public List<InputController.ControllerVibration> vibrationSetup;

	private void OnGUIDValueChangedCallback()
	{
	}
}
