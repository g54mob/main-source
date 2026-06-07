using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AK.Wwise;
using Gh.Tk;
using UnityEngine;
using Utils;

namespace Gh
{
	public class AudioController : SingletonMonoBehaviour<AudioController>
	{
		public class AudioInfo : IPersistable
		{
			public uint eventId;

			public int position;

			private AudioInfo()
			{
			}

			public AudioInfo(uint eventId, int position)
			{
			}
		}

		[Serializable]
		public class SoundBank
		{
			public bool loadAsynchronous;

			public Bank data;

			public bool isLocalized;

			public bool autoLoad;

			public string Id => null;

			public bool IsActive { get; private set; }

			public bool IsLoaded { get; private set; }

			public void ActivateSoundBank()
			{
			}

			public void DeactivateSoundBank(bool forceUnload = false)
			{
			}
		}

		public AnimationCurve DEBUG_TavernIntensity;

		public MusicManagerConfig musicManagerConfig;

		public GameObject aiTooltipVoiceOverContextObject;

		private AkMonitorErrorCode[] _importantErrors;

		private RollingList<string> _audioLogs;

		private float dayStartTime;

		private float nightStartTime;

		private SoundEngineStateControl _gameTimeState;

		private SoundEngineParameterControl<float> _gameTimeRTPC;

		private IEnumerable<GameLevel> _levels;

		private string[] _gameSpeedStateKeys;

		public State StartUpState;

		private bool _isStartUpFinished;

		[SerializeField]
		private RuntimeImportedAudioPlayer _generatedVoiceOverPlayer;

		private MusicManager _musicManager;

		[SerializeField]
		private GameObject _bgMusicObj;

		private SoundEngineParameterControl<float> _cameraZoomLevel;

		private bool _worldmapMusicStarted;

		[SerializeField]
		private GameObject _worldMapMusicObj;

		public Dictionary<string, float> patronProfileScores;

		[SerializeField]
		private List<SoundBank> _soundBanks;

		[field: SerializeField]
		public AkAudioListener GlobalListener { get; private set; }

		public static bool IsAKLoggingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MusicManager MusicManager => null;

		public bool IsSoundBanksReady { get; private set; }

		public static event EventHandler SoundBanksReady
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void SetActorSoundProfile(ActorData actorData, GameObject model)
		{
		}

		public override void Awake()
		{
		}

		private void AttachAdditionalHooks()
		{
		}

		private void OnMonitoringCallback(AkMonitorErrorCode inErrorCode, AkMonitorErrorLevel inErrorLevel, uint inPlayingID, ulong inGameObjID, string inMsg)
		{
		}

		public void OnWorldMapToggled(object sender, EventArgs eventArgs)
		{
		}

		private void OnPlayerProfileChanged(object sender, EventArgs<PlayerProfile> eventArgs)
		{
		}

		private void UpdateNarratorSpeed()
		{
		}

		public void ForceMuteAllVolumes()
		{
		}

		public void UpdateAllVolumes()
		{
		}

		private void UpdateVolumeLevel(string volumeId)
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void OnHourChanged(object sender, EventArgs e)
		{
		}

		private void UpdateTavernState()
		{
		}

		private void UpdateGameTime(object sender, EventArgs e)
		{
		}

		private void UpdateGameTime()
		{
		}

		public void OnLevelStarted()
		{
		}

		private void OnActorEnterOrExitTavern(object owner, EventArgs<Actor> e)
		{
		}

		private void UpdateTavernPopulationValues()
		{
		}

		public void Reset()
		{
		}

		private void OnGameSpeedChanged(object sender, EventArgs e)
		{
		}

		public void InitGameListeners()
		{
		}

		private void OnTavernGrandOpening(object sender, EventArgs e)
		{
		}

		public void Update()
		{
		}

		private bool IsResultValid(AKRESULT result, string error)
		{
			return false;
		}

		public void SetVolume(string name, int value)
		{
		}

		public uint PlayGlobalSoundEvent(string eventName)
		{
			return 0u;
		}

		public void StopGlobalSoundEvent(string eventName)
		{
		}

		public uint PlaySoundEvent(GameObject source, string eventName)
		{
			return 0u;
		}

		public bool IsSoundEventPlaying(GameObject source, string eventName)
		{
			return false;
		}

		private void SoundEventCallbackHandler(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
		{
		}

		private bool IsStartUpFinished()
		{
			return false;
		}

		public bool TryPlayVoiceOver(GameObject source, string id, Action markerCallback, Action endOfVoiceOverCallback, out uint eventId, bool enablePosition = false)
		{
			eventId = default(uint);
			return false;
		}

		public void StopVoiceOvers(GameObject source, bool withFade = true)
		{
		}

		public void PlayGeneratedVoiceOver(string filepath)
		{
		}

		public void PauseAll(GameObject source)
		{
		}

		public void ResumeAll(GameObject source)
		{
		}

		public void PlayCashSound(int amount)
		{
		}

		public List<AudioInfo> GetAllAudioInfos(GameObject source)
		{
			return null;
		}

		public int GetPlayPosition(uint playId)
		{
			return 0;
		}

		public void SetPlayPosition(GameObject source, uint playId, int positionInMs)
		{
		}

		public void LoadSounds(GameObject source, List<AudioInfo> infos)
		{
		}

		private void LoadSound(GameObject source, AudioInfo info)
		{
		}

		public void PauseSounds()
		{
		}

		public void ResumeSounds()
		{
		}

		public void ToggleAudioLogs()
		{
		}

		public void ToggleToiletCensorship()
		{
		}

		public void UpdateToiletCensorship()
		{
		}

		public void PlayBuildSound(string propSize)
		{
		}

		public void StopLevelSounds()
		{
		}

		public void ForceStopSound(string eventId, GameObject gameObjectEmitter)
		{
		}

		private void StartMusic()
		{
		}

		public void PlayBackgroundMusic(string trackId)
		{
		}

		public void PlayLoadingMusic(string music, string ambience)
		{
		}

		public void PlayBootMusic(string level)
		{
		}

		public void StopBackgroundMusic()
		{
		}

		public void PlayBackgroundMusic()
		{
		}

		public void PauseBackgroundMusic()
		{
		}

		public void ResumeBackgroundMusic()
		{
		}

		public void SetCameraZoomLevel(float zoomLevel)
		{
		}

		public void PlayWorldMapMusic()
		{
		}

		public void ResumeWorldMapMusic()
		{
		}

		public void PauseWorldMapMusic()
		{
		}

		public void SetWorldMapMusicVariation(string variation)
		{
		}

		public static void StopAll(GameObject obj)
		{
		}

		private static bool IsValidSoundObj(GameObject obj)
		{
			return false;
		}

		public void PlayWeatherSound(AK.Wwise.Event soundEvent)
		{
		}

		public void StopWeatherSounds()
		{
		}

		public void StopWeatherSound(string soundEvent)
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RegisterCustomPlatformName()
		{
		}

		public static void GetCustomPlatformName(ref string platformName)
		{
		}

		public DataStore SaveGlobalAudioData()
		{
			return null;
		}

		public void RestoreGlobalAudioData(IDataStore data)
		{
		}

		public void OnFinishedLoading()
		{
		}

		private void CheckSoundBanksReady()
		{
		}

		public void LoadDefaultSoundBanks()
		{
		}

		public void LoadSoundBank(string bankId)
		{
		}

		public void UnloadSoundBank(string bankId)
		{
		}

		private void OnMerchantSpawned(object sender, EventArgs e)
		{
		}

		private void OnMerchantDespawned(object sender, EventArgs e)
		{
		}
	}
}
