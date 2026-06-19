using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pug.UnityExtensions;
using PugMod;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AudioManager : ManagerBase, IAudio
{
	public enum MixerGroupEnum
	{
		UI = 0,
		MUSIC = 1,
		EFFECTS = 2,
		NONE = 3,
		AMBIENT = 4,
		INSTRUMENTS = 5,
		TORCHES = 6,
		GENERATOR_OBJECTS = 7,
		UI_CONDITION_EFFECTS = 8,
		FIRE_BURNING = 9,
		ROBOT_BOSS = 10,
		PLAYER = 11,
		MINING = 12,
		WEAPONS = 13,
		FLAMETHROWER = 14,
		ENEMIES = 15,
		ROBOT_SWARMER = 16,
		MORTAR_IMPACT = 17,
		BOSS_FIGHT_SFX = 18,
		CINEMATIC_EVENTS = 19,
		CINEMATIC_EVENTS_2 = 20
	}

	[Serializable]
	public class SFXParams
	{
		public SfxID sfxID;

		public Vector3 relativePosition;

		public float volume = 1f;

		public float pitch = 1f;

		public float pitchDev;

		public bool reuse;

		public bool loop;

		public float volumeDev;

		public float sfxTableID;
	}

	[Serializable]
	public class OverrideInstrumentSounds
	{
		public ObjectID objectID;

		public SFXTableIDField[] tones = new SFXTableIDField[24];
	}

	public struct RunningSfxReference
	{
		private readonly int _allocationIndex;

		private readonly PoolableAudioSource _audioSource;

		public bool IsValid
		{
			get
			{
				if (_audioSource != null)
				{
					return _allocationIndex == _audioSource.validAllocationIndex;
				}
				return false;
			}
		}

		public bool Loop => _audioSource.audioSource.loop;

		public float ClipLength => _audioSource.audioSource.clip.length;

		public float Time => _audioSource.audioSource.time;

		public RunningSfxReference(int allocationIndex, PoolableAudioSource audioSource)
		{
			_allocationIndex = allocationIndex;
			_audioSource = audioSource;
		}

		public void Play()
		{
			if (_allocationIndex == _audioSource.validAllocationIndex)
			{
				_audioSource.audioSource.Play();
			}
		}

		public void PlayScheduled(double time)
		{
			if (IsValid)
			{
				_audioSource.audioSource.PlayScheduled(time);
			}
		}

		public void FadeOutAndStop()
		{
			FadeOutAndStop(Manager.audio.reuse_fadeOutDuration);
		}

		public void FadeOutAndStop(float duration)
		{
			if (IsValid)
			{
				_audioSource.FadeOutAndStop(duration);
			}
		}

		public void FadeIn(float duration, bool startVolumeAtZero)
		{
			if (IsValid)
			{
				_audioSource.FadeIn(duration, startVolumeAtZero);
			}
		}

		public void Stop()
		{
			if (IsValid)
			{
				_audioSource.audioSource.Stop();
			}
		}

		public void SetLoop(bool value)
		{
			if (IsValid)
			{
				_audioSource.audioSource.loop = value;
			}
		}

		public void SetFreeAfterStoppedPlaying(bool value)
		{
			if (IsValid)
			{
				_audioSource.freeAfterStoppedPlaying = value;
			}
		}

		public void SetTime(float time)
		{
			if (IsValid)
			{
				_audioSource.audioSource.time = time;
			}
		}

		public void SetVolume(float value)
		{
			if (IsValid)
			{
				_audioSource.SetVolume(value);
			}
		}
	}

	private const string PARAM_NAME_VOLUME = "volume";

	private const string PARAM_NAME_REVERB = "reverbMix";

	public const float MAX_AUDIO_PLAYTIME = 1000f;

	[NonSerialized]
	public float reuse_fadeOutDuration = 0.07f;

	[NonSerialized]
	public float reuse_antiPopMuteDuration = 0.1f;

	[NonSerialized]
	public float reuse_audioSpamCutOffDuration = 0.05f;

	public PoolSystem audioPoolSystem;

	[Header(" - Ambient sounds handler -")]
	public AmbientSoundsHandler ambientSoundsHandler;

	private AudioField[] audioFieldMap;

	private readonly Dictionary<SfxUnityInspectorFriendlyID, SfxID> inspectorFriendlySfxIDLookup = new Dictionary<SfxUnityInspectorFriendlyID, SfxID>(1891);

	private Dictionary<int, SfxPlaybackCycle> _playbackCycles = new Dictionary<int, SfxPlaybackCycle>();

	public SfxTable sfxTable;

	[Header("Audio mixer group references:")]
	public AudioMixerGroup masterMixerGroup;

	public AudioMixerGroup interfaceMixerGroup;

	public AudioMixerGroup musicMixerGroup;

	public AudioMixerGroup effectsMixerGroup;

	public AudioMixerGroup ambientMixerGroup;

	public AudioMixerGroup instrumentsMixerGroup;

	public Fader effectsMixerVolumeFader;

	public Fader ambientMixerVolumeFader;

	public Fader instrumentsMixerVolumeFader;

	[Header("Children-Audio mixer group references:")]
	[HideInInspector]
	public AudioMixerGroup generatorObjectsMixerGroup;

	[HideInInspector]
	public AudioMixerGroup torchesMixerGroup;

	[HideInInspector]
	public AudioMixerGroup uiConditionEffectsMixerGroup;

	[HideInInspector]
	public AudioMixerGroup fireBurningMixerGroup;

	[HideInInspector]
	public AudioMixerGroup bossFightSfxMixerGroup;

	[HideInInspector]
	public AudioMixerGroup robotBossMixerGroup;

	[HideInInspector]
	public AudioMixerGroup playerMixerGroup;

	[HideInInspector]
	public AudioMixerGroup miningMixerGroup;

	[HideInInspector]
	public AudioMixerGroup weaponsMixerGroup;

	[HideInInspector]
	public AudioMixerGroup flamethrowerMixerGroup;

	[HideInInspector]
	public AudioMixerGroup enemiesMixerGroup;

	[HideInInspector]
	public AudioMixerGroup robotSwarmerMixerGroup;

	[HideInInspector]
	public AudioMixerGroup mortarImpactMixerGroup;

	[HideInInspector]
	public AudioMixerGroup cinematicEventsMixerGroup;

	[HideInInspector]
	public AudioMixerGroup cinematicEvents2MixerGroup;

	[Header("Prefab used for audio pool object:")]
	public PoolableAudioSource audioPoolGameObjectPrefab;

	[Header("Auto load settings:")]
	public List<AssetLabelReference> assetLabelsToAutoLoad = new List<AssetLabelReference>();

	[Header("Override Instrument Sounds:")]
	public List<OverrideInstrumentSounds> overrideInstrumentSounds;

	[NonSerialized]
	public PoolableAudioSource[] reuseMap;

	private Dictionary<int, List<PoolableAudioSource>> sfxTableNonStackableMap;

	[NonSerialized]
	public List<PoolableAudioSource> loopingClips = new List<PoolableAudioSource>(32);

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("AudioManager.Init");

	private float _previousMasterVolume = -1f;

	private float _previousEffectsVolume = -1f;

	private float _previousAmbientVolume = -1f;

	private float _previousInterfaceVolume = -1f;

	private float _previousInstrumentsVolume = -1f;

	public bool Initialized { get; private set; }

	public bool SFXTableIDExists(int id)
	{
		return sfxTable.SFXTableIDExists(id);
	}

	public void FadeInAudioEffects(float fadeTime = 0.15f)
	{
		effectsMixerVolumeFader.FadeIn(fadeTime, Time.unscaledTime);
	}

	public void FadeOutAudioEffects(float fadeTime = 0.15f)
	{
		effectsMixerVolumeFader.FadeOut(fadeTime, Time.unscaledTime);
	}

	public void FadeInAudioAmbient(float fadeTime = 0.15f)
	{
		ambientMixerVolumeFader.FadeIn(fadeTime, Time.unscaledTime);
	}

	public void FadeOutAudioAmbient(float fadeTime = 0.15f)
	{
		ambientMixerVolumeFader.FadeOut(fadeTime, Time.unscaledTime);
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			AsyncInit();
			return true;
		}
	}

	private async Task AsyncInit()
	{
		sfxTable.Init();
		effectsMixerVolumeFader = new Fader(1f, Fader.FadeFunction.SmoothStep, Time.unscaledTime);
		ambientMixerVolumeFader = new Fader(1f, Fader.FadeFunction.SmoothStep, Time.unscaledTime);
		instrumentsMixerVolumeFader = new Fader(1f, Fader.FadeFunction.SmoothStep, Time.unscaledTime);
		foreach (SfxUnityInspectorFriendlyID item in Enum.GetValues(typeof(SfxUnityInspectorFriendlyID)).Cast<SfxUnityInspectorFriendlyID>())
		{
			if (!Enum.TryParse<SfxID>(item.ToString(), out var result))
			{
				Debug.LogWarning("SfxUIFID not found in SfxID: " + item);
			}
			else
			{
				inspectorFriendlySfxIDLookup[item] = result;
			}
		}
		reuseMap = new PoolableAudioSource[1891];
		sfxTableNonStackableMap = new Dictionary<int, List<PoolableAudioSource>>();
		await AutoLoadAudioFiles();
		int num = 50;
		audioPoolSystem = new PoolSystem(audioPoolGameObjectPrefab.gameObject, typeof(PoolableAudioSource), base.transform, autoEnable: true, num, -1, num, "SFX");
		Initialized = true;
	}

	public static bool IsLegalSfxID(SfxID id)
	{
		if (id >= SfxID.AcidLoop)
		{
			return id < SfxID.__max__;
		}
		return false;
	}

	public static float GetVolume(int SfxTableID, int index)
	{
		SfxTableElement sfxInfo = Manager.audio.sfxTable.GetSfxInfo(SfxTableID);
		if (sfxInfo == null)
		{
			return 0f;
		}
		if (sfxInfo.sounds == null || sfxInfo.sounds.Count <= index)
		{
			return 0f;
		}
		return sfxInfo.sounds[index].volume;
	}

	public SfxID InspectorFriendlySfxIDToSfxID(SfxUnityInspectorFriendlyID sfxUIFID)
	{
		if (!inspectorFriendlySfxIDLookup.TryGetValue(sfxUIFID, out var value))
		{
			Debug.LogError($"Unknown SfxUIFID: {sfxUIFID}");
			return SfxID.__illegal__;
		}
		return value;
	}

	public int GetOverrideInstrumentSounds(ObjectID objectID, int toneIndex)
	{
		foreach (OverrideInstrumentSounds overrideInstrumentSound in overrideInstrumentSounds)
		{
			if (overrideInstrumentSound.objectID == objectID)
			{
				return overrideInstrumentSound.tones[toneIndex].value;
			}
		}
		return 0;
	}

	private static void SetMixerGroupVolumeIfChanged(AudioMixerGroup group, float volume, ref float previousVolume)
	{
		if (volume != previousVolume)
		{
			group.audioMixer.SetLinearVolume("volume", volume);
			previousVolume = volume;
		}
	}

	public void LateUpdate()
	{
		float volume = Manager.prefs.masterAudioVolume;
		if (Manager.prefs.fullscreen == 2 && !Application.isFocused)
		{
			volume = 0f;
		}
		SetMixerGroupVolumeIfChanged(masterMixerGroup, volume, ref _previousMasterVolume);
		float volume2 = Manager.prefs.sfxVolume * effectsMixerVolumeFader.UpdateFadeValue(Time.unscaledTime);
		SetMixerGroupVolumeIfChanged(effectsMixerGroup, volume2, ref _previousEffectsVolume);
		float volume3 = Manager.prefs.ambientSfxVolume * ambientMixerVolumeFader.UpdateFadeValue(Time.unscaledTime);
		SetMixerGroupVolumeIfChanged(ambientMixerGroup, volume3, ref _previousAmbientVolume);
		float volume4 = Manager.prefs.instrumentsSfxVolume * instrumentsMixerVolumeFader.UpdateFadeValue(Time.unscaledTime);
		SetMixerGroupVolumeIfChanged(instrumentsMixerGroup, volume4, ref _previousInstrumentsVolume);
		float volume5 = ((!Application.isFocused) ? 0f : Manager.prefs.sfxVolume);
		SetMixerGroupVolumeIfChanged(interfaceMixerGroup, volume5, ref _previousInterfaceVolume);
	}

	private async Task AutoLoadAudioFiles()
	{
		AsyncOperationHandle<IList<AudioClip>> handle = Addressables.LoadAssetsAsync<AudioClip>(assetLabelsToAutoLoad, null, Addressables.MergeMode.Union);
		await handle.Task;
		audioFieldMap = new AudioField[1891];
		List<AudioField> list = new List<AudioField>();
		foreach (AudioClip item in handle.Result)
		{
			AudioField audioField = new AudioField();
			audioField.audioPlayables.Add(item);
			audioField.audioFieldName = item.name;
			list.Add(audioField);
			if (Enum.TryParse<SfxID>(item.name, out var result))
			{
				AudioClipLoadType loadType = item.loadType;
				if (loadType != AudioClipLoadType.DecompressOnLoad && loadType != AudioClipLoadType.CompressedInMemory)
				{
					Debug.LogWarning($"SFX {item.name} has unexpected AudioClipLoadType and is {item.loadType} instead. Expected {AudioClipLoadType.DecompressOnLoad} or {AudioClipLoadType.CompressedInMemory}.");
				}
				audioFieldMap[(int)result] = audioField;
			}
		}
	}

	public static void SfxUI(SfxID sfxID, float pitch = 1f, bool reuse = true, float volume = 1f, float pitchDev = 0.15f, bool playOnGamepad = false, bool gamepadSpeakerOutputTypeIsSpeaker = true, float volumeDev = 0f)
	{
		if (Manager.input.singleplayerInputModule.InputEnabled && Application.isFocused)
		{
			SfxMono(sfxID, volume, pitch, pitchDev, reuse, MixerGroupEnum.UI, muteVolumeWhilePaused: false, playOnGamepad, gamepadSpeakerOutputTypeIsSpeaker);
		}
	}

	public static void SfxMono(SfxID sfxID, float volume = 1f, float pitch = 1f, float pitchDev = 0f, bool reuse = false, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, bool muteVolumeWhilePaused = false, bool playOnGamepad = false, bool gamepadSpeakerOutputTypeIsSpeaker = false)
	{
		Manager.audio.PlayAudioClip(sfxID, null, Entity.Null, Vector3.zero, loop: false, volume, 0f, mixerGroup, pitch, pitchDev, useSpatialSound: false, reuse, 16f, 10f, muteVolumeWhilePaused, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad, gamepadSpeakerOutputTypeIsSpeaker);
	}

	private static List<SfxTable.SFXSound> GetNextSfxInfoSounds(AudioManager audioManager, int sfxTableID)
	{
		if (!audioManager._playbackCycles.TryGetValue(sfxTableID, out var value))
		{
			SfxTableElement sfxInfo = audioManager.sfxTable.GetSfxInfo(sfxTableID);
			if (sfxInfo == null)
			{
				return null;
			}
			value = new SfxPlaybackCycle(sfxInfo.sounds, sfxInfo.variants);
			audioManager._playbackCycles[sfxTableID] = value;
		}
		return value.GetNextSound();
	}

	public static void SfxFollowTransform(int sfxTableID, Transform transformToFollow, float volumeMultiplier = 1f, float pitchMultiplier = 1f, bool loop = false, bool freeAudioSourceAfterItStoppedPlaying = true, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, bool reuseSfxs = false, bool playOnGamepad = false, List<RunningSfxReference> result = null, float minSpatialDistance = 1f, float randomStartMin = 0f, float randomStartMax = 1f, float fadeInDuration = 0f, float maxSpatialBlend = 0f)
	{
		if (sfxTableID == SfxTableID.none)
		{
			return;
		}
		AudioManager audio = Manager.audio;
		SfxTableElement sfxInfo = audio.sfxTable.GetSfxInfo(sfxTableID);
		if (sfxInfo == null || sfxInfo.mute)
		{
			return;
		}
		if (!sfxInfo.settings.stackable)
		{
			audio.FreeAnyNonStackableSfxTableIDElementAudios(sfxTableID);
		}
		List<SfxTable.SFXSound> nextSfxInfoSounds = GetNextSfxInfoSounds(audio, sfxTableID);
		if (nextSfxInfoSounds == null)
		{
			return;
		}
		foreach (SfxTable.SFXSound item in nextSfxInfoSounds)
		{
			SfxID sfxID = audio.InspectorFriendlySfxIDToSfxID(item.sfx);
			float volume = item.volume * volumeMultiplier;
			float pitch = item.pitch * pitchMultiplier;
			float pitchDev = item.pitchDev;
			MixerGroupEnum mixerGroup2 = item.mixerGroup;
			bool ignoreAudioIfOutsideOfViewport = sfxInfo.settings.ignoreAudioIfOutsideOfViewport;
			bool loop2 = loop;
			float maxSpatialDistance = ((sfxInfo.settings.overrideMaxSpatialDistance != 0f) ? sfxInfo.settings.overrideMaxSpatialDistance : 16f);
			float maxSpatialBlendDistance = ((sfxInfo.settings.overrideMaxSpatialBlendDistance != 0f) ? sfxInfo.settings.overrideMaxSpatialBlendDistance : 10f);
			bool freeAudioSourceAfterItStoppedPlaying2 = freeAudioSourceAfterItStoppedPlaying;
			PoolableAudioSource poolableAudioSource = SfxFollowTransform(sfxID, transformToFollow, volume, pitch, pitchDev, reuseSfxs, mixerGroup2, ignoreAudioIfOutsideOfViewport, !sfxInfo.settings.dontUseSpatialSound, loop2, maxSpatialDistance, maxSpatialBlendDistance, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying2, playOnGamepad, isPartOfSfxTableElement: true, item.volumeDev, item.randomStartTime, sfxTableID, minSpatialDistance, randomStartMin, randomStartMax, maxSpatialBlend);
			if (!(poolableAudioSource == null))
			{
				result?.Add(new RunningSfxReference(poolableAudioSource.validAllocationIndex, poolableAudioSource));
				if (!sfxInfo.settings.stackable)
				{
					audio.AddNonStackableSfxTableIDElementAudioSource(sfxTableID, poolableAudioSource);
				}
				if (poolableAudioSource != null && fadeInDuration > 0f)
				{
					poolableAudioSource.FadeIn(fadeInDuration, startVolumeAtZero: true);
				}
			}
		}
	}

	public static void Sfx(int sfxTableID, Vector3 position, float volumeMultiplier = 1f, float pitchMultiplier = 1f, bool loop = false, bool freeAudioSourceAfterItStoppedPlaying = true, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, bool reuseSfxs = false, bool playOnGamepad = false, List<RunningSfxReference> result = null, bool forceStackable = false, float minSpatialDistance = 1f, float randomStartMin = 0f, float randomStartMax = 1f, float fadeInDuration = 0f, float maxSpatialBlend = 0f)
	{
		if (sfxTableID == SfxTableID.none)
		{
			return;
		}
		AudioManager audio = Manager.audio;
		SfxTableElement sfxInfo = audio.sfxTable.GetSfxInfo(sfxTableID);
		if (sfxInfo == null || sfxInfo.mute)
		{
			return;
		}
		if (!forceStackable && !sfxInfo.settings.stackable)
		{
			audio.FreeAnyNonStackableSfxTableIDElementAudios(sfxTableID);
		}
		List<SfxTable.SFXSound> nextSfxInfoSounds = GetNextSfxInfoSounds(audio, sfxTableID);
		if (nextSfxInfoSounds == null)
		{
			return;
		}
		foreach (SfxTable.SFXSound item in nextSfxInfoSounds)
		{
			SfxID sfxID = audio.InspectorFriendlySfxIDToSfxID(item.sfx);
			float volume = item.volume * volumeMultiplier;
			float pitch = item.pitch * pitchMultiplier;
			float pitchDev = item.pitchDev;
			MixerGroupEnum mixerGroup2 = item.mixerGroup;
			bool ignoreAudioIfOutsideOfViewport = sfxInfo.settings.ignoreAudioIfOutsideOfViewport;
			bool loop2 = loop;
			bool playOnGamepad2 = playOnGamepad;
			float maxSpatialDistance = ((sfxInfo.settings.overrideMaxSpatialDistance != 0f) ? sfxInfo.settings.overrideMaxSpatialDistance : 16f);
			float maxSpatialBlendDistance = ((sfxInfo.settings.overrideMaxSpatialBlendDistance != 0f) ? sfxInfo.settings.overrideMaxSpatialBlendDistance : 10f);
			bool freeAudioSourceAfterItStoppedPlaying2 = freeAudioSourceAfterItStoppedPlaying;
			PoolableAudioSource poolableAudioSource = Sfx(sfxID, position, volume, pitch, pitchDev, reuseSfxs, mixerGroup2, ignoreAudioIfOutsideOfViewport, !sfxInfo.settings.dontUseSpatialSound, loop2, maxSpatialDistance, maxSpatialBlendDistance, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying2, playOnGamepad2, isPartOfSfxTableElement: true, item.volumeDev, item.randomStartTime, sfxTableID, minSpatialDistance, randomStartMin, randomStartMax, maxSpatialBlend);
			if (!(poolableAudioSource == null))
			{
				result?.Add(new RunningSfxReference(poolableAudioSource.validAllocationIndex, poolableAudioSource));
				if (!forceStackable && !sfxInfo.settings.stackable)
				{
					audio.AddNonStackableSfxTableIDElementAudioSource(sfxTableID, poolableAudioSource);
				}
				if (poolableAudioSource != null && fadeInDuration > 0f)
				{
					poolableAudioSource.FadeIn(fadeInDuration, startVolumeAtZero: true);
				}
			}
		}
	}

	private void AddNonStackableSfxTableIDElementAudioSource(int sfxTableID, PoolableAudioSource audioSource)
	{
		if (!sfxTableNonStackableMap.TryGetValue(sfxTableID, out var value))
		{
			value = new List<PoolableAudioSource>();
			sfxTableNonStackableMap[sfxTableID] = value;
		}
		audioSource.nonStackableSfxTableID = sfxTableID;
		value.Add(audioSource);
	}

	private void FreeAnyNonStackableSfxTableIDElementAudios(int sfxTableID)
	{
		if (!sfxTableNonStackableMap.TryGetValue(sfxTableID, out var value))
		{
			return;
		}
		for (int num = value.Count - 1; num >= 0; num--)
		{
			PoolableAudioSource poolableAudioSource = value[num];
			if (!(poolableAudioSource == null))
			{
				if (poolableAudioSource.GetTimeSinceAudioStartedPlaying() > reuse_audioSpamCutOffDuration)
				{
					poolableAudioSource.FadeOutAndStop();
				}
				else
				{
					poolableAudioSource.StopNow(antiPop: false);
				}
			}
		}
		value.Clear();
	}

	public void FadeOutAndStopSfx(int sfxTableID)
	{
		FreeAnyNonStackableSfxTableIDElementAudios(sfxTableID);
	}

	public void RemoveNonStackableAudioSource(PoolableAudioSource audioSource)
	{
		int nonStackableSfxTableID = audioSource.nonStackableSfxTableID;
		if (nonStackableSfxTableID != SfxTableID.none)
		{
			if (sfxTableNonStackableMap.TryGetValue(nonStackableSfxTableID, out var value))
			{
				value.Remove(audioSource);
			}
			audioSource.nonStackableSfxTableID = SfxTableID.none;
		}
	}

	public static PoolableAudioSource Sfx(SfxID sfxID, Vector3 position, float volume = 1f, float pitch = 1f, float pitchDev = 0f, bool reuse = false, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, bool ignoreAudioIfOutsideOfViewport = false, bool useSpatialSound = true, bool loop = false, float maxSpatialDistance = 16f, float maxSpatialBlendDistance = 10f, bool muteVolumeWhilePaused = true, bool freeAudioSourceAfterItStoppedPlaying = true, bool playOnGamepad = false, bool isPartOfSfxTableElement = false, float volumeDev = 0f, bool randomStartTime = false, int sfxTableID = 0, float minSpatialDistance = 1f, float randomStartMin = 0f, float randomStartMax = 1f, float maxSpatialBlend = 0f)
	{
		if (ignoreAudioIfOutsideOfViewport && !Manager.camera.IsPointInViewport(position))
		{
			return null;
		}
		AudioManager audio = Manager.audio;
		Entity entityToFollow = Entity.Null;
		bool useSpatialSound2 = useSpatialSound;
		bool reuse2 = reuse;
		return audio.PlayAudioClip(sfxID, null, entityToFollow, position, loop, volume, 0f, mixerGroup, pitch, pitchDev, useSpatialSound2, reuse2, maxSpatialDistance, maxSpatialBlendDistance, muteVolumeWhilePaused, freeAudioSourceAfterItStoppedPlaying, playOnGamepad, gamepadSpeakerOutputTypeIsSpeaker: false, isPartOfSfxTableElement, volumeDev, randomStartTime, sfxTableID, minSpatialDistance, randomStartMin, randomStartMax, maxSpatialBlend);
	}

	public static PoolableAudioSource SfxFollowTransform(SfxID sfxID, Transform transform, float volume = 1f, float pitch = 1f, float pitchDev = 0f, bool reuse = false, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, bool ignoreAudioIfOutsideOfViewport = false, bool useSpatialSound = true, bool loop = false, float maxSpatialDistance = 16f, float maxSpatialBlendDistance = 10f, bool muteVolumeWhilePaused = true, bool freeAudioSourceAfterItStoppedPlaying = true, bool playOnGamepad = false, bool isPartOfSfxTableElement = false, float volumeDev = 0f, bool randomStartTime = false, int sfxTableID = 0, float minSpatialDistance = 1f, float randomStartMin = 0f, float randomStartMax = 1f, float maxSpatialBlend = 0f)
	{
		if (ignoreAudioIfOutsideOfViewport && !Manager.camera.IsPointInViewport(transform.position))
		{
			return null;
		}
		AudioManager audio = Manager.audio;
		Entity entityToFollow = Entity.Null;
		Vector3 position = transform.position;
		bool useSpatialSound2 = useSpatialSound;
		bool reuse2 = reuse;
		return audio.PlayAudioClip(sfxID, transform, entityToFollow, position, loop, volume, 0f, mixerGroup, pitch, pitchDev, useSpatialSound2, reuse2, maxSpatialDistance, maxSpatialBlendDistance, muteVolumeWhilePaused, freeAudioSourceAfterItStoppedPlaying, playOnGamepad, gamepadSpeakerOutputTypeIsSpeaker: false, isPartOfSfxTableElement, volumeDev, randomStartTime, sfxTableID, minSpatialDistance, randomStartMin, randomStartMax, maxSpatialBlend);
	}

	public static PoolableAudioSource SfxFollowEntity(SfxID sfxID, Entity entity, float volume = 1f, float pitch = 1f, float pitchDev = 0f, bool reuse = false, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, bool useSpatialSound = true, bool loop = false, float maxSpatialDistance = 16f, float maxSpatialBlendDistance = 10f, bool muteVolumeWhilePaused = false)
	{
		AudioManager audio = Manager.audio;
		Vector3 zero = Vector3.zero;
		bool useSpatialSound2 = useSpatialSound;
		bool reuse2 = reuse;
		return audio.PlayAudioClip(sfxID, null, entity, zero, loop, volume, 0f, mixerGroup, pitch, pitchDev, useSpatialSound2, reuse2, maxSpatialDistance, maxSpatialBlendDistance, muteVolumeWhilePaused);
	}

	private PoolableAudioSource PlayAudioClip(SfxID sfxID, Transform transformToFollow, Entity entityToFollow, Vector3 position, bool loop = false, float volume = 1f, float timeOffset = 0f, MixerGroupEnum mixerGroup = MixerGroupEnum.EFFECTS, float pitch = 1f, float pitchDev = 0f, bool useSpatialSound = false, bool reuse = false, float maxSpatialDistance = 16f, float maxSpatialBlendDistance = 10f, bool muteVolumeWhilePaused = false, bool freeAudioSourceAfterItStoppedPlaying = true, bool playOnGamepad = false, bool gamepadSpeakerOutputTypeIsSpeaker = false, bool isPartOfSfxTableElement = false, float volumeDev = 0f, bool randomStartTime = false, int sfxTableID = 0, float minSpatialDistance = 1f, float randomStartMin = 0f, float randomStartMax = 1f, float maxSpatialBlend = 0f)
	{
		if (volume < 0f && volume > 1f)
		{
			Debug.LogError($"PlayAudioClip: illegal volume {volume} | ID: {sfxID}");
			return null;
		}
		if (!IsLegalSfxID(sfxID))
		{
			Debug.LogWarning("Illegal SfxID " + sfxID);
			return null;
		}
		int num = (int)sfxID;
		AudioField audioField = audioFieldMap[num];
		if (audioField == null)
		{
			Debug.LogWarning($"No audio field found for SfxID {sfxID} (index {num}). Did you forget to add the audio clip or is the name mismatched?");
			return null;
		}
		if (reuse)
		{
			PoolableAudioSource poolableAudioSource = reuseMap[num];
			if (poolableAudioSource != null)
			{
				if (poolableAudioSource.GetTimeSinceAudioStartedPlaying() > reuse_audioSpamCutOffDuration)
				{
					poolableAudioSource.FadeOutAndStop();
				}
				else
				{
					poolableAudioSource.StopNow(antiPop: false);
				}
				reuseMap[num] = null;
			}
		}
		PoolableAudioSource freeComponent = audioPoolSystem.GetFreeComponent<PoolableAudioSource>();
		if (!freeComponent)
		{
			Debug.LogWarning("Could not allocate sound effect for " + num);
			return null;
		}
		freeComponent.maxSpatialBlend = maxSpatialBlend;
		if (reuse)
		{
			freeComponent.reuseID = sfxID;
			reuseMap[num] = freeComponent;
		}
		freeComponent.transformToFollow = transformToFollow;
		freeComponent.entityToFollow = entityToFollow;
		freeComponent.followsAnEntityOrTransform = transformToFollow != null || entityToFollow != Entity.Null;
		freeComponent.UpdatePosition();
		AudioSource audioSource = freeComponent.audioSource;
		audioSource.outputAudioMixerGroup = EnumToMixerGroup(mixerGroup);
		audioSource.bypassReverbZones = mixerGroup == MixerGroupEnum.UI;
		audioSource.transform.position = position;
		audioSource.loop = loop;
		audioSource.gameObject.SetActive(value: true);
		AudioClip nextAudioClip = audioField.GetNextAudioClip();
		if (nextAudioClip == null)
		{
			Debug.LogWarning($"No audio clip available in audio field for SfxID {sfxID}.");
			return null;
		}
		audioSource.clip = nextAudioClip;
		float num2 = volume + volumeDev * UnityEngine.Random.Range(-1f, 1f);
		audioSource.volume = Mathf.Clamp01(num2);
		freeComponent.mutedFromPause = false;
		freeComponent.muteVolumeWhilePaused = muteVolumeWhilePaused;
		freeComponent.SetVolume(num2);
		if (randomStartTime && audioSource.clip != null)
		{
			float num3 = Mathf.Clamp01(randomStartMin);
			float num4 = Mathf.Clamp01(randomStartMax);
			if (num4 < num3)
			{
				float num5 = num4;
				float num6 = num3;
				num3 = num5;
				num4 = num6;
			}
			float length = audioSource.clip.length;
			audioSource.time = UnityEngine.Random.Range(num3 * length, num4 * length);
		}
		else
		{
			audioSource.time = timeOffset;
		}
		audioSource.pitch = pitch + pitchDev * UnityEngine.Random.Range(-1f, 1f);
		freeComponent.useSpatialSound = useSpatialSound;
		freeComponent.UpdateSpatialBlend();
		freeComponent.maxSpatialBlendDistance = maxSpatialBlendDistance;
		audioSource.maxDistance = maxSpatialDistance;
		audioSource.minDistance = minSpatialDistance;
		freeComponent.freeAfterStoppedPlaying = freeAudioSourceAfterItStoppedPlaying;
		if (loop)
		{
			loopingClips.Add(freeComponent);
		}
		audioSource.Play();
		if (playOnGamepad)
		{
			if (!gamepadSpeakerOutputTypeIsSpeaker)
			{
				VibrateController();
			}
			playOnGamepad = false;
		}
		return freeComponent;
		void VibrateController()
		{
			if (!gamepadSpeakerOutputTypeIsSpeaker && Manager.main.player != null)
			{
				float num7 = math.remap(25f, 0f, 0f, 1f, (Manager.main.player.RenderPosition - position).magnitude);
				num7 *= volume;
				if (num7 > 0f)
				{
					Manager.input.singleplayerInputModule.RumbleNow(0.18f, num7);
				}
			}
		}
	}

	public void FreeAllAudioSources()
	{
		audioPoolSystem.FreeAll();
	}

	public void FreeLoopingClips()
	{
		for (int num = loopingClips.Count - 1; num >= 0; num--)
		{
			loopingClips[num].Free();
		}
	}

	public AudioMixerGroup EnumToMixerGroup(MixerGroupEnum mixerEnum)
	{
		switch (mixerEnum)
		{
		case MixerGroupEnum.EFFECTS:
			return effectsMixerGroup;
		case MixerGroupEnum.MUSIC:
			return musicMixerGroup;
		case MixerGroupEnum.UI:
			return interfaceMixerGroup;
		case MixerGroupEnum.AMBIENT:
			return ambientMixerGroup;
		case MixerGroupEnum.INSTRUMENTS:
			return instrumentsMixerGroup;
		case MixerGroupEnum.TORCHES:
			return torchesMixerGroup;
		case MixerGroupEnum.GENERATOR_OBJECTS:
			return generatorObjectsMixerGroup;
		case MixerGroupEnum.UI_CONDITION_EFFECTS:
			return uiConditionEffectsMixerGroup;
		case MixerGroupEnum.FIRE_BURNING:
			return fireBurningMixerGroup;
		case MixerGroupEnum.BOSS_FIGHT_SFX:
			return bossFightSfxMixerGroup;
		case MixerGroupEnum.ROBOT_BOSS:
			return robotBossMixerGroup;
		case MixerGroupEnum.PLAYER:
			return playerMixerGroup;
		case MixerGroupEnum.MINING:
			return miningMixerGroup;
		case MixerGroupEnum.WEAPONS:
			return weaponsMixerGroup;
		case MixerGroupEnum.FLAMETHROWER:
			return flamethrowerMixerGroup;
		case MixerGroupEnum.ENEMIES:
			return enemiesMixerGroup;
		case MixerGroupEnum.ROBOT_SWARMER:
			return robotSwarmerMixerGroup;
		case MixerGroupEnum.MORTAR_IMPACT:
			return mortarImpactMixerGroup;
		case MixerGroupEnum.CINEMATIC_EVENTS:
			return cinematicEventsMixerGroup;
		case MixerGroupEnum.CINEMATIC_EVENTS_2:
			return cinematicEvents2MixerGroup;
		default:
			Debug.LogWarning("There is no mixer group bound to MixerGroupEnum '" + mixerEnum.ToString() + "'.");
			return null;
		}
	}

	public MixerGroupEnum MixerGroupToEnum(AudioMixerGroup mixerGroup)
	{
		if (mixerGroup == effectsMixerGroup)
		{
			return MixerGroupEnum.EFFECTS;
		}
		if (mixerGroup == musicMixerGroup)
		{
			return MixerGroupEnum.MUSIC;
		}
		if (mixerGroup == interfaceMixerGroup)
		{
			return MixerGroupEnum.UI;
		}
		if (mixerGroup == ambientMixerGroup)
		{
			return MixerGroupEnum.AMBIENT;
		}
		if (mixerGroup == instrumentsMixerGroup)
		{
			return MixerGroupEnum.INSTRUMENTS;
		}
		if (mixerGroup == torchesMixerGroup)
		{
			return MixerGroupEnum.TORCHES;
		}
		if (mixerGroup == generatorObjectsMixerGroup)
		{
			return MixerGroupEnum.GENERATOR_OBJECTS;
		}
		if (mixerGroup == uiConditionEffectsMixerGroup)
		{
			return MixerGroupEnum.UI_CONDITION_EFFECTS;
		}
		if (mixerGroup == fireBurningMixerGroup)
		{
			return MixerGroupEnum.FIRE_BURNING;
		}
		if (mixerGroup == bossFightSfxMixerGroup)
		{
			return MixerGroupEnum.BOSS_FIGHT_SFX;
		}
		if (mixerGroup == robotBossMixerGroup)
		{
			return MixerGroupEnum.ROBOT_BOSS;
		}
		if (mixerGroup == playerMixerGroup)
		{
			return MixerGroupEnum.PLAYER;
		}
		if (mixerGroup == miningMixerGroup)
		{
			return MixerGroupEnum.MINING;
		}
		if (mixerGroup == weaponsMixerGroup)
		{
			return MixerGroupEnum.WEAPONS;
		}
		if (mixerGroup == flamethrowerMixerGroup)
		{
			return MixerGroupEnum.FLAMETHROWER;
		}
		if (mixerGroup == enemiesMixerGroup)
		{
			return MixerGroupEnum.ENEMIES;
		}
		if (mixerGroup == robotSwarmerMixerGroup)
		{
			return MixerGroupEnum.ROBOT_SWARMER;
		}
		if (mixerGroup == mortarImpactMixerGroup)
		{
			return MixerGroupEnum.MORTAR_IMPACT;
		}
		if (mixerGroup == cinematicEventsMixerGroup)
		{
			return MixerGroupEnum.CINEMATIC_EVENTS;
		}
		if (mixerGroup == cinematicEvents2MixerGroup)
		{
			return MixerGroupEnum.CINEMATIC_EVENTS_2;
		}
		Debug.LogWarning("There is no enum bound to AudioMixerGroup '" + mixerGroup?.ToString() + "'.");
		return MixerGroupEnum.NONE;
	}

	public void PlaySfx(int sfxTableID, Vector3 position, Transform transformToFollow = null, float volumeMultiplier = 1f, float pitchMultiplier = 1f, int sfxType = 2)
	{
		if (transformToFollow == null)
		{
			Sfx(sfxTableID, position, volumeMultiplier, pitchMultiplier, loop: false, freeAudioSourceAfterItStoppedPlaying: true, (MixerGroupEnum)sfxType);
		}
		else
		{
			SfxFollowTransform(sfxTableID, transformToFollow, volumeMultiplier, pitchMultiplier, loop: false, freeAudioSourceAfterItStoppedPlaying: true, (MixerGroupEnum)sfxType);
		}
	}
}
