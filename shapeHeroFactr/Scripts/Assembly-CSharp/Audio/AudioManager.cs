using System;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Libs;
using UnityEngine;

namespace Audio
{
	public class AudioManager : SingletonMonoBehaviour<AudioManager>
	{
		private class SEVolumeData
		{
			public string name;

			public float volume;
		}

		[Serializable]
		public class PlayerAudioSetting
		{
			[Range(0f, 1f)]
			public float masterVolume;

			[Range(0f, 1f)]
			public float bgmVolume;

			[Range(0f, 1f)]
			public float seVolume;

			public PlayerAudioSetting(float masterVolume, float bgmVolume, float seVolume)
			{
			}
		}

		public const string AudioMenuPath = "Development/Audio/音あり";

		public const string AudioMenuOutputSoundNamePath = "Development/Audio/サウンド名出力";

		private bool playOnAwake;

		private bool outputSoundName;

		[SerializeField]
		private float displayMaxVolume;

		private string _nowPlaylist;

		public bool isLastBossDefeated;

		private string _previousBGMPlaylistName;

		private string _previousBGMClipName;

		private float _previousBGMTime;

		private PlaylistController _playlistController;

		private float _filterTransitionTime;

		private Dictionary<eSoundGroupCategory, HDRController> hdrControllers;

		private List<SEVolumeData> _tempSEVolumes;

		private List<string> _playSounds;

		private List<eSoundGroupCategory> _alwaysPlayCategorys;

		private Dictionary<string, int> _seWeights;

		private Dictionary<(eEnemy enemy, eEnemySoundActionType actionType), List<eSoundGroupId>> _enemySECache;

		private Dictionary<(eUnit unit, eUnitSoundActionType actionType), List<eSoundGroupId>> _unitSECache;

		private float _startBGMVolume;

		private bool _beforeIsPause;

		private string _beforeScene;

		private bool enableCountdown;

		private PlaylistController.SongLoopedEventHandler eventHandler;

		private string nextPlaylistName;

		private string nextBgmName;

		private PlaylistController.SongEndedEventHandler songEndedEventHandler;

		private string delayedStartPlaylist;

		private string delayedStartBgmName;

		private float delayedStartTime;

		public PlayerAudioSetting audioSetting { get; private set; }

		public static PlaySEElement SE { get; private set; }

		public float GetTempSEVolume(string name)
		{
			return 0f;
		}

		public void SetTempSEVolume(string name, float volume)
		{
		}

		private void Awake()
		{
		}

		private void InitSoundGroup()
		{
		}

		private void InitHDRControllers(AudioSettings settings)
		{
		}

		public void SwitchScene()
		{
		}

		public void SwitchBattleBGM(string nextScene)
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void PlayUIBGM()
		{
		}

		private void RecordForPreviousBGM()
		{
		}

		private void ResumeBGM()
		{
		}

		public void PlayBattleStartBGM()
		{
		}

		public void PlayBossStartBGM()
		{
		}

		public void PlayLastBossStartBGM()
		{
		}

		public void PlayClearOrdealAtmosphere()
		{
		}

		public void PlayLastBossStartAtmosphere()
		{
		}

		public void PlayLastBossBattleBGM()
		{
		}

		public void PlayEndingBGM()
		{
		}

		public void PlaySE(string clipName, float correctVolume = 1f, float? pitch = null, float delaySoundTime = 0f)
		{
		}

		public void PlaySE(eSoundGroupId groupId, Vector3? targetPosition = null, Vector3? correctPosition = null, float delay = 0f, bool isMuteIgnore = false)
		{
		}

		public void ForcedOverwritePlaySE(eSoundGroupId groupId, eSoundGroupCategory? overwriteCategory = null, bool? is3D = null, Vector3? targetPosition = null, Vector3? correctPosition = null, float delay = 0f, bool isMuteIgnore = false)
		{
		}

		public bool IsMuteCategory(eSoundGroupCategory category)
		{
			return false;
		}

		public void PlaySE(eSoundGroupCategory soundCategory, string clipName, bool is3DSound, Vector3? targetPosition = null, Vector3? correctPosition = null, bool mute = false, float delaySoundTime = 0f)
		{
		}

		public void PlayMachineSE(eMachine machine, eMachineSoundActionType actionType, Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void PlayEnemySE(eEnemy enemy, eEnemySoundActionType actionType, Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void PlayUnitSE(eUnit unit, eUnitSoundActionType actionType, Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		private List<eSoundGroupId> GetEnemySESoundGroups(eEnemy enemy, eEnemySoundActionType actionType)
		{
			return null;
		}

		private List<eSoundGroupId> GetUnitSESoundGroups(eUnit unit, eUnitSoundActionType actionType)
		{
			return null;
		}

		public void PlaySpellSE(eMiracle miracle, eSpellSoundActionType actionType, Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void StepPlaySE(eSoundGroupId before, eSoundGroupId after)
		{
		}

		public void StatPlaylist(string playlistName, string bgmName, float startTime = 0f, bool resetFilter = true, bool forceMaxVolumeStart = false)
		{
		}

		private void SetLowPassFiter(float transitionTime)
		{
		}

		public void ResetFiter(float transitionTime)
		{
		}

		public void SetLowVolumeFiter(float transitionTime)
		{
		}

		public void FadeBGM(float targetVolume, float fadeTime)
		{
		}

		public void TriggerNextPlaylistClip()
		{
		}

		public bool TriggerPlaylistClip(string clipName)
		{
			return false;
		}

		public void ChangePitchBGM(float pitch)
		{
		}

		public void UnPauseBGM()
		{
		}

		public void StopBGM()
		{
		}

		public void FadeoutAndStartBGM(float fadeTime, string nextPlaylistName = null, string clipName = null)
		{
		}

		public void PauseBGM()
		{
		}

		public void ChangeBGMVolume(float value)
		{
		}

		public void ChangeMasterVolume(float value)
		{
		}

		public void ChangeSEVolume(float value)
		{
		}

		public void ChangeBGMWhenLoopingPreviousBGM(string playlistName, string bgmName, bool forceOverride = false)
		{
		}

		private void ChangeLoopBGMEventHandler(string songName)
		{
		}

		public void ClearSongLoopedEventHandler()
		{
		}

		public void ChangeBGMWhenEndedPreviousBGM(string playlistName, string bgmName, bool forceOverride = false)
		{
		}

		private void ChangeEndedBGMEventHandler(string songName)
		{
		}

		public void ClearSongEndedEventHandler()
		{
		}

		public void DelayedStartPlaylist(string playlistName, string bgmName, float delay, bool forceOverride = false)
		{
		}

		public void StopOpeningMovieSound()
		{
		}

		public void StopSE(string clipName)
		{
		}

		public void StopSE(eSoundGroupId groupId)
		{
		}

		public Dictionary<eSoundGroupCategory, HDRController> GetHDRControllers()
		{
			return null;
		}
	}
}
