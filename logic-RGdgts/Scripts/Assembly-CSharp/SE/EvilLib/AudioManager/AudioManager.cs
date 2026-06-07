using System.Collections.Generic;
using SE.EvilLib.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace SE.EvilLib.AudioManager
{
	public class AudioManager : MonoBehaviour
	{
		private static AudioManager _Instance;

		[Separator]
		public AudioMixerGroup groupMusic;

		public AudioMixerGroup groupSfx;

		public AudioMixerGroup groupVoice;

		public AudioSource templateMusicSource;

		public AudioSource templateSfxSource;

		public AudioSource templateVoiceSource;

		public List<CustomTemplate> customTemplates;

		[Separator]
		public bool dontDestroyOnLoad;

		public AudioCfg cfg;

		[Separator]
		[SerializeField]
		private bool dbgCmd_RandomMusic;

		[SerializeField]
		private bool dbgCmd_RandomVoice;

		[SerializeField]
		private bool dbgCmd_RandomSfx;

		[ReadOnly]
		[SerializeField]
		private List<PlayingSound> curPlaying;

		private string curLanguage;

		private static bool initialized;

		public static AudioManager Instance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string defaultMusicGroupName { get; set; }

		public string defaultSfxGroupName { get; set; }

		public string defaultVoiceGroupName { get; set; }

		public PlayingSound DBGCMD_RANDMUSIC()
		{
			return null;
		}

		public PlayingSound DBGCMD_RANDVOICE()
		{
			return null;
		}

		public PlayingSound DBGCMD_RANDSFX()
		{
			return null;
		}

		private void Init()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void SetNewLanguage(string newLanguage)
		{
		}

		public void StopAll(float fadeTime = 0f, AudioCategory category = AudioCategory.Any)
		{
		}

		public PlayingSound PlayMusic(int type, bool fadeIn)
		{
			return null;
		}

		public void StopMusic(bool fadeOut = true)
		{
		}

		public void ChangeMusicVolume(float volume)
		{
		}

		public void FadeMusic(float normValue, float time)
		{
		}

		public void ChangeSFXVolume(float volume)
		{
		}

		public PlayingSound PlaySfx(int type, Transform parent = null, Vector3? pos = null, int clipsIndex = 0, int clipsCount = -1)
		{
			return null;
		}

		public PlayingSound PlayVoice(int type, Transform parent = null, Vector3? pos = null)
		{
			return null;
		}

		public void FadeGroup(string groupName, float normVal, float time, AudioCategory category = AudioCategory.Any)
		{
		}

		public void StopGroup(string groupName, float fadeTime = 0f, AudioCategory category = AudioCategory.Any)
		{
		}

		public void PauseGroup(string groupName, bool pauseValue, float time = 0f, AudioCategory category = AudioCategory.Any)
		{
		}

		public void StopById(string id, float fadeTime = 0f)
		{
		}

		public void Stop(PlayingSound ps, float fadeTime = 0f)
		{
		}

		public AudioSource GetNewSource(int templateType)
		{
			return null;
		}

		public AudioSource GetNewSource(AudioSource template)
		{
			return null;
		}

		private void RemovePlayingSound(PlayingSound ps)
		{
		}

		private void RemovePlayingSound(int index)
		{
		}
	}
}
