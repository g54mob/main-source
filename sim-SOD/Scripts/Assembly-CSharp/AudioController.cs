using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using NaughtyAttributes;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[Serializable]
	public class AmbientZoneInstance
	{
		public AmbientZone preset;

		public float playerDistance;

		public int penetrationCount;

		public NewRoom audibleRoom;

		public bool isActive;

		[Space(5f)]
		public float desiredVolume;

		public float actualVolume;

		[Space(5f)]
		public float desiredWalla;

		public float actualWalla;

		[NonSerialized]
		public LoopingSoundInfo eventData;

		public HashSet<NewRoom> rooms;

		public AmbientZoneInstance(AmbientZone newPreset)
		{
		}
	}

	[Serializable]
	public class LoopingSoundInfo
	{
		public string name;

		public bool init;

		public EventInstance audioEvent;

		public bool isValid;

		public EventDescription description;

		public float volumeOverride;

		public AudioEvent eventPreset;

		public NewNode sourceLocation;

		public Actor who;

		[NonSerialized]
		public Interactable interactable;

		public bool forceSuspicious;

		public List<FMODParam> parameters;

		public float lastUpdated;

		public int currentOcclusion;

		public bool pauseWhenGamePaused;

		public Vector3 worldPos;

		public PLAYBACK_STATE state;

		public bool paused;

		public List<NewRoom> audibleRooms;

		public SessionData.TelevisionChannel isBroadcast;

		public float occlusionVolume;

		public float fadeToVolume;

		public float vol;

		public bool isActive;

		public string debugStoppedReason;

		public InteractablePreset.IfSwitchStateSFX interactableLoopInfo;

		public bool clipIsValid;

		public bool clipPaused;

		public PLAYBACK_STATE clipState;

		public EventInstance clipAudioEvent;

		public PLAYBACK_STATE UpdatePlayState()
		{
			return default(PLAYBACK_STATE);
		}

		public void UpdateWorldPosition(Vector3 newWorldPos, NewNode newNodePos)
		{
		}

		public void UpdateOcclusion(bool ignoreLastUpdateTime = false)
		{
		}

		public void SetVolumeImmediate(float vol)
		{
		}

		public void SetVolumeFadeTo(float vol)
		{
		}

		public void OnPauseChange()
		{
		}

		public void UpdateDynamicClip()
		{
		}

		private void PassCrowdReaction()
		{
		}
	}

	public class ActiveListener
	{
		public Actor listener;

		public float soundLevel;

		public int escalationLevel;
	}

	[Serializable]
	public class DelayedSoundInfo
	{
		public float delay;

		public AudioEvent eventPreset;

		public Actor who;

		public NewNode location;

		public Vector3 worldPosition;

		public List<FMODParam> parameters;

		public float volumeOverride;

		public List<NewNode> additionalSources;

		public bool forceIgnoreOcclusion;

		public bool is2D;

		public DelayedSoundInfo(float newDelay, AudioEvent newEventPreset, Actor newWho, NewNode newLocation, Vector3 newWorldPosition, List<FMODParam> newParameters = null, float newVolumeOverride = 1f, List<NewNode> newAdditionalSources = null, bool newForceIgnoreOcclusion = false, bool newIs2D = false)
		{
		}
	}

	[Serializable]
	public class SoundMaterialOverride
	{
		public float concrete;

		public float wood;

		public float carpet;

		public float tile;

		public float plaster;

		public float fabric;

		public float metal;

		public float glass;

		public SoundMaterialOverride(float newConcrete, float newWood, float newCarpet, float newTile, float newPlaster, float newFabric, float newMetal, float newGlass)
		{
		}
	}

	public enum CitizenReaction
	{
		investigate = 0,
		immediatePersue = 1,
		alarm = 2
	}

	public enum SurfaceType
	{
		concrete = 0,
		woodenFloor = 1,
		tile = 2,
		carpet = 3
	}

	public enum StopType
	{
		immediate = 0,
		fade = 1,
		triggerCue = 2
	}

	public struct FMODParam
	{
		public string name;

		public float value;
	}

	public StudioListener playerListener;

	[Tooltip("Speed of sound in unity (m) per (in-game) second")]
	[Header("Misc. Settings")]
	public float speedOfSound;

	[Tooltip("Each occlusion unit will decrease volume by this amount...")]
	[Space(7f)]
	[Header("Occlusion: Modifiers")]
	public float occlusionUnitVolumeModifier;

	[Range(0f, 10f)]
	public int openDoorOcclusionUnits;

	[Range(0f, 10f)]
	public int closedDoorOcclusionUnits;

	[Range(0f, 10f)]
	public int windowOcclusionUnits;

	[Range(0f, 10f)]
	public int wallOcclusionUnits;

	[Range(0f, 10f)]
	public int ceilingOcclusionUnits;

	[Range(0f, 10f)]
	public int floorOcclusionUnits;

	[Range(0f, 10f)]
	public int floorDifferenceOcclusionUnits;

	[Space(5f)]
	[Tooltip("Loop through this many rooms as a maximum...")]
	public int loopingMaximum;

	[Tooltip("Sounds can travel this many rooms away from the source. After that they gain +1 occlusion unit per additional room.")]
	public int maxRoomDistance;

	[Tooltip("The emulated rolloff of the sound")]
	public AnimationCurve emulationRolloff;

	[Tooltip("Sound needs to be playing at at least this volume for the AI to register it")]
	public float aiHearingThreshold;

	[Tooltip("Sound needs to be playing at at least this volume for the player to register it")]
	public float playerHearingThreshold;

	[Tooltip("A sound icon represents this much simulated range")]
	public float soundIconRangeUnit;

	[ReadOnly]
	[Header("Ambient Sound Properties")]
	public int updateClosestWindowTicker;

	[ReadOnly]
	public int updateMixingTicker;

	[ReadOnly]
	public float updateAmbientZonesTimer;

	[Tooltip("Update closest windows and open ext door every X frames...")]
	public int updateClosestWindow;

	[Tooltip("Update closest windows and open ext door every X frames...")]
	public int updateMixing;

	[ReadOnly]
	[Tooltip("Current closest window position.")]
	public Vector3 windowAudioPosition;

	[Tooltip("Distance from player to above.")]
	[ReadOnly]
	public float closestWindowDistance;

	[Tooltip("Normalized version of above")]
	[ReadOnly]
	public float closestWindowDistanceNormalized;

	[Tooltip("Window distance multiplier (used to create normalised variable)")]
	public float closestWindowDistanceMultiplier;

	[Tooltip("Curve used as a multiplier for the above, and based on how open the door is on X (0 = closed, 1 = open)")]
	public AnimationCurve openMultiplierCurve;

	[ReadOnly]
	[Tooltip("Interpolated outdoors/indoors transition")]
	[Space(5f)]
	public float ventOutdoorsIndoors;

	[ReadOnly]
	[Tooltip("Distance to the nearest vent")]
	public float nearbyVent;

	[Space(5f)]
	[ReadOnly]
	[Tooltip("Current closest open external door position.")]
	public Vector3 doorAudioPosition;

	[ReadOnly]
	[Tooltip("Distance from player to above.")]
	public float closestDoorDistance;

	[Tooltip("Normalized version of above")]
	[ReadOnly]
	public float closestDoorDistanceNormalized;

	[Tooltip("Window distance multiplier (used to create normalised variable)")]
	public float closestDoorDistanceMultiplier;

	[Tooltip("Distance from an edge tile")]
	[Space(5f)]
	[ReadOnly]
	public float edgeDistance;

	[Tooltip("Normalized version of above")]
	[ReadOnly]
	public float edgeDistanceNormalized;

	[Tooltip("Edge distance multiplier (used to create normalised variable)")]
	public float edgeDistanceMultiplier;

	[Space(5f)]
	[Tooltip("Distance from an exterior wall")]
	[ReadOnly]
	public float extWallDistance;

	[ReadOnly]
	[Tooltip("Normalized version of above")]
	public float extWallNormalized;

	[Tooltip("Edge distance multiplier (used to create normalised variable)")]
	public float extWallDistanceMultiplier;

	[Space(7f)]
	[ReadOnly]
	public float passedWind;

	[ReadOnly]
	public float passedRain;

	[ReadOnly]
	public float passedCity;

	[BoxGroup("Ambient Zones")]
	public List<AmbientZoneInstance> ambientZones;

	public Dictionary<AmbientZone, AmbientZoneInstance> ambientZoneReference;

	[Tooltip("As this is a 2D sound we need to apply volume falloff manually")]
	public AnimationCurve ambientFalloff;

	public LoopingSoundInfo ambienceWind;

	public LoopingSoundInfo ambienceRain;

	public LoopingSoundInfo ambiencePA;

	[Header("PS5 Haptics")]
	public string hapticsPlaying;

	[NonSerialized]
	public LoopingSoundInfo threatLoop;

	public List<LoopingSoundInfo> loopingSounds;

	public HashSet<LoopingSoundInfo> volumeChangingSounds;

	public List<DelayedSoundInfo> delayedSound;

	public int footstepLayerMask;

	private List<LoopingSoundInfo> forceFeedbackLoops;

	private Action updateAmbientZonesAction;

	private static AudioController _instance;

	public static AudioController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void UpdateMixing()
	{
	}

	public void StartAmbienceTracks()
	{
	}

	public bool PlayWorldFootstep(AudioEvent eventPreset, Actor actor, bool rightFoot = false)
	{
		return false;
	}

	public void PlayerPlayerImpactSound(float fallCount)
	{
	}

	public EventInstance PlayWorldOneShot(AudioEvent eventPreset, Actor who, NewNode location, Vector3 worldPosition, Interactable interactable = null, List<FMODParam> parameters = null, float volumeOverride = 1f, List<NewNode> additionalSources = null, bool forceIgnoreOcclusion = false, SoundMaterialOverride surfaceData = null, bool forceSuspicious = false)
	{
		return default(EventInstance);
	}

	public void PlayOneShotDelayed(float delay, AudioEvent eventPreset, Actor who, NewNode location, Vector3 worldPosition, List<FMODParam> parameters = null, float volumeOverride = 1f, List<NewNode> additionalSources = null, bool forceIgnoreOcclusion = false)
	{
	}

	public LoopingSoundInfo PlayWorldLooping(AudioEvent eventPreset, Actor who, Interactable interactable, List<FMODParam> parameters = null, float volumeOverride = 1f, bool forceSuspicious = false, SessionData.TelevisionChannel isBroadcast = null, InteractablePreset.IfSwitchStateSFX newSwitchInfo = null)
	{
		return null;
	}

	public LoopingSoundInfo PlayWorldLoopingStatic(AudioEvent eventPreset, Actor who, NewNode worldNode, Vector3 worldPos, List<FMODParam> parameters = null, float volumeOverride = 1f, bool forceSuspicious = false, SessionData.TelevisionChannel isBroadcast = null, InteractablePreset.IfSwitchStateSFX newSwitchInfo = null)
	{
		return null;
	}

	public LoopingSoundInfo PlayWorldLooping(AudioEvent eventPreset, Actor who, NewNode worldNode, Vector3 worldPosition, Interactable interactable = null, List<FMODParam> parameters = null, float volumeOverride = 1f, bool forceSuspicious = false, SessionData.TelevisionChannel isBroadcast = null, InteractablePreset.IfSwitchStateSFX newSwitchInfo = null)
	{
		return null;
	}

	public LoopingSoundInfo Play2DLooping(AudioEvent eventPreset, List<FMODParam> parameters = null, float volumeOverride = 1f)
	{
		return null;
	}

	public void UpdateAllLoopingSoundOcclusion()
	{
	}

	public void UpdateClosestWindowAndDoor(bool doorCheckOnly = false)
	{
	}

	public void UpdateDistanceFromEdge()
	{
	}

	public void PassWindowDistance()
	{
	}

	public void PassDistanceFromExternalDoor()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PassWeatherParams()
	{
	}

	public void PassIndoorOutdoor()
	{
	}

	public void UpdateVentIndoorOutdoor()
	{
	}

	public void UpdateDistanceToVent()
	{
	}

	public void PassTimeOfDay()
	{
	}

	public void PassEdgeDistance()
	{
	}

	public void UpdateClosestExteriorWall()
	{
	}

	public void PassExteriorWallDistance()
	{
	}

	public bool IsSoundPlaying(LoopingSoundInfo sound)
	{
		return false;
	}

	public bool IsSoundPlaying(EventInstance sound)
	{
		return false;
	}

	public void StopSound(LoopingSoundInfo loop, StopType stop)
	{
	}

	public void StopSound(EventInstance sound, StopType stop)
	{
	}

	public EventInstance Play2DSound(AudioEvent eventPreset, List<FMODParam> parameters = null, float volumeOverride = 1f)
	{
		return default(EventInstance);
	}

	public void Play2DSoundDelayed(AudioEvent eventPreset, float delay, List<FMODParam> parameters = null, float volumeOverride = 1f)
	{
	}

	public float GetOcculusion(NewNode listenerLocation, NewNode sourceLocation, AudioEvent audioEvent, float baseVolume, Actor soundMaker, SoundMaterialOverride detailedMaterialData, out int penetrationCount, out List<ActiveListener> activeListeners, out bool isSuspicious, out List<NewRoom> audibleRooms, out float rangeHearing, List<NewNode> additionalLocations = null, bool forceSuspicious = false)
	{
		penetrationCount = default(int);
		activeListeners = null;
		isSuspicious = default(bool);
		audibleRooms = null;
		rangeHearing = default(float);
		return 0f;
	}

	public float GetAmbientZoneOcculusion(NewNode listenerLocation, AmbientZoneInstance ambientZone, out float distance, out int penetrationCount, out NewRoom audibleRoom)
	{
		distance = default(float);
		penetrationCount = default(int);
		audibleRoom = null;
		return 0f;
	}

	public void ForceOutlineCheck(AudioEvent audioEvent, Interactable inter, bool forceOff = false)
	{
	}

	public float GetPlayersSoundLevel(NewNode sourceLocation, AudioEvent audioEvent, float occludedVolume, SoundMaterialOverride detailedMaterialData)
	{
		return 0f;
	}

	public void UpdateAmbientZonesOnEndOfFrame()
	{
	}

	public void UpdateAmbientZones()
	{
	}

	public void ResetThis()
	{
	}

	public void SetVCALevel(string vcaName, float value)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateAmbientPlaybackState()
	{
	}

	public void StopAllSounds()
	{
	}

	public void UpdateVolumeChanging()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugWeatherLoopDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void NextTVShow()
	{
	}

	public void UpdateLoopBasedControllerVibration()
	{
	}
}
