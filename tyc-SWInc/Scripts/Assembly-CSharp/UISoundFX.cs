using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UISoundFX : MonoBehaviour
{
	[Serializable]
	public class SoundFXInstance
	{
		public string Name;

		public AudioClip[] Clips;

		public bool PitchShift;

		public bool Randomize;

		public bool StopAtLast;

		public float Cooldown;

		public float MaxPitch;

		public float IncrementCooldown;

		public float Volume = 1f;

		public int PitchIncrement;

		public string Group;

		[NonSerialized]
		public float LastPlayed = -1f;

		[NonSerialized]
		public float Pitch = 1f;

		[NonSerialized]
		public int Index;
	}

	[Serializable]
	public class MusicInstance
	{
		public string Name;

		public AudioClip Clip;

		public bool Looping;

		public bool AlwaysPlay;

		public string State;

		public float FadeInTime;

		public float Volume = 1f;

		[NonSerialized]
		private float _lastPlayed = -1f;

		public bool CanPlay()
		{
			if (!AlwaysPlay && _lastPlayed != -1f)
			{
				return Time.realtimeSinceStartup - _lastPlayed > 60f;
			}
			return true;
		}

		public void Play()
		{
			_lastPlayed = Time.realtimeSinceStartup;
		}
	}

	public static Dictionary<string, float> CanSkipWithin = new Dictionary<string, float>
	{
		{ "Spring", 0f },
		{ "Summer", 0f },
		{ "Autumn", 0f },
		{ "Winter", 0f }
	};

	[NonSerialized]
	private Dictionary<string, SoundFXInstance> _soundEffects;

	[NonSerialized]
	private Dictionary<string, List<MusicInstance>> _music;

	[NonSerialized]
	private List<AudioSource> _channels = new List<AudioSource>();

	[NonSerialized]
	private List<AudioSource> _3Dchannels = new List<AudioSource>();

	[NonSerialized]
	private string[] _channelGroup;

	[NonSerialized]
	private Dictionary<string, int> _groupPlaying = new Dictionary<string, int>();

	[NonSerialized]
	private int _playIndex;

	[NonSerialized]
	private int _3DplayIndex;

	public static UISoundFX Instance;

	public AudioSource Audio3DPrefab;

	public List<SoundFXInstance> SoundEffects = new List<SoundFXInstance>();

	public List<MusicInstance> MusicTracks = new List<MusicInstance>();

	public int ChannelCount;

	public AudioMixerGroup UIMixerGroup;

	public AudioSource MusicChannel;

	public bool FadeMusic;

	public float FadeIn;

	public float FadeInMax;

	public float UIDbScale = 1f;

	[NonSerialized]
	private string _hasPlayedDuring;

	[NonSerialized]
	private string CurrentMusicState;

	[NonSerialized]
	private MusicInstance Playing;

	[NonSerialized]
	private bool _windowFocus = true;

	private void OnApplicationFocus(bool focus)
	{
		_windowFocus = focus;
	}

	private void Update()
	{
		if (FadeMusic)
		{
			FadeIn = 0f;
			MusicChannel.volume = Mathf.Lerp(MusicChannel.volume, 0f, Time.deltaTime * 4f);
			if (MusicChannel.volume < 0.01f)
			{
				if (Playing != null && !Playing.State.Equals(CurrentMusicState))
				{
					_hasPlayedDuring = null;
				}
				MusicChannel.Stop();
				FadeMusic = false;
			}
			return;
		}
		if (FadeIn > 0f)
		{
			FadeIn = Mathf.Max(0f, FadeIn - Time.deltaTime);
			MusicChannel.volume = Mathf.Lerp(0f, Playing.Volume, 1f - FadeIn / FadeInMax);
			return;
		}
		if (Playing != null && MusicChannel.isPlaying && MusicChannel.time > 10f)
		{
			Playing.Play();
		}
		if (CurrentMusicState == null || MusicChannel.isPlaying || CurrentMusicState.Equals(_hasPlayedDuring) || !_windowFocus || !(AudioManager.GetVolume("Music") > -80f))
		{
			return;
		}
		List<MusicInstance> orNull = _music.GetOrNull(CurrentMusicState);
		bool flag = false;
		if (orNull != null)
		{
			for (int i = 0; i < orNull.Count; i++)
			{
				MusicInstance musicInstance = orNull[i];
				if (musicInstance != Playing && musicInstance.CanPlay())
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			_hasPlayedDuring = CurrentMusicState;
			PlayMusic(orNull.GetRandomWhere((MusicInstance x) => x != Playing && x.CanPlay()));
		}
	}

	public static void ForceSkipTrack()
	{
		if (Instance != null && Instance.MusicChannel.isPlaying)
		{
			Instance.FadeMusic = true;
		}
	}

	public static void ChangeMusicState(string state)
	{
		if (Instance != null)
		{
			float num = 1000f;
			if (Instance.MusicChannel.isPlaying && Instance.Playing != null)
			{
				num = CanSkipWithin.GetOrDefault(Instance.Playing.State, 1000f);
			}
			else if (state != null)
			{
				num = CanSkipWithin.GetOrDefault(state, 1000f);
			}
			Instance.CurrentMusicState = state;
			if (Instance.FadeMusic && Instance.Playing != null && Instance.Playing.State.Equals(state))
			{
				Instance.FadeMusic = false;
				Instance.FadeInMax = 1f;
				Instance.FadeIn = 1f - Instance.MusicChannel.volume / Instance.Playing.Volume;
			}
			else if (Instance.MusicChannel.isPlaying && Instance.MusicChannel.time < num)
			{
				Instance.FadeMusic = true;
			}
		}
	}

	private void PlayMusic(MusicInstance instance)
	{
		Playing = instance;
		MusicChannel.clip = instance.Clip;
		MusicChannel.loop = instance.Looping;
		MusicChannel.volume = ((instance.FadeInTime > 0f) ? 0f : instance.Volume);
		FadeIn = (FadeInMax = instance.FadeInTime);
		MusicChannel.Play();
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			base.enabled = false;
			return;
		}
		Instance = this;
		SceneManager.sceneLoaded += delegate(Scene x, LoadSceneMode y)
		{
			ChangeMusicState(x.name);
		};
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		_soundEffects = SoundEffects.ToDictionary((SoundFXInstance x) => x.Name, (SoundFXInstance x) => x);
		_music = (from x in MusicTracks
			group x by x.State).ToDictionary((IGrouping<string, MusicInstance> x) => x.Key, (IGrouping<string, MusicInstance> x) => x.ToList());
		for (int num = 0; num < ChannelCount; num++)
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.outputAudioMixerGroup = UIMixerGroup;
			_channels.Add(audioSource);
			AudioSource audioSource2 = UnityEngine.Object.Instantiate(Audio3DPrefab);
			audioSource2.transform.SetParent(base.transform);
			_3Dchannels.Add(audioSource2);
		}
		_channelGroup = new string[_channels.Count];
	}

	private void StopFromGroup(string group)
	{
		int value = 0;
		if (_groupPlaying.TryGetValue(group, out value) && group.Equals(_channelGroup[value]) && _channels[value].isPlaying)
		{
			_channels[value].Stop();
		}
	}

	public static void PlaySFX(string sfxName, bool reverb)
	{
		PlaySFX(sfxName, -1f, 0f, reverb);
	}

	public static void PlaySFX(string sfxName, float pitch = -1f, float pan = 0f, bool reverb = false)
	{
		if (Instance == null)
		{
			return;
		}
		SoundFXInstance value;
		if (Instance._soundEffects.TryGetValue(sfxName, out value))
		{
			if (value.LastPlayed > 0f && Time.realtimeSinceStartup - value.LastPlayed < value.Cooldown)
			{
				return;
			}
			for (int i = 0; i < Instance._channels.Count; i++)
			{
				AudioSource audioSource = Instance._channels[Instance._playIndex];
				if (!audioSource.isPlaying)
				{
					audioSource.outputAudioMixerGroup = (reverb ? AudioManager.UIReverb : AudioManager.UI);
					PlayOnChannel(value, audioSource, pitch, pan, false);
					break;
				}
				Instance._playIndex = (Instance._playIndex + 1) % Instance._channels.Count;
			}
		}
		else
		{
			Debug.LogError("Couldn't play SFX as it doesn't exist " + sfxName);
		}
	}

	public static void PlaySFX(AudioClip asfx, float volume = 1f, float pitch = -1f, float pan = 0f, bool reverb = false)
	{
		if (Instance == null)
		{
			return;
		}
		for (int i = 0; i < Instance._channels.Count; i++)
		{
			AudioSource audioSource = Instance._channels[Instance._playIndex];
			if (!audioSource.isPlaying)
			{
				audioSource.outputAudioMixerGroup = (reverb ? AudioManager.UIReverb : AudioManager.UI);
				audioSource.volume = Instance.UIDbScale * volume;
				audioSource.pitch = ((pitch > 0f) ? pitch : 1f);
				audioSource.clip = asfx;
				audioSource.Play();
				audioSource.panStereo = pan;
				Instance._playIndex = (Instance._playIndex + 1) % Instance._channels.Count;
				break;
			}
			Instance._playIndex = (Instance._playIndex + 1) % Instance._channels.Count;
		}
	}

	public static void PlaySFX(string sfxName, Vector3 position, bool muffled = false, float pitch = -1f, float distance = 8f)
	{
		if (Instance == null)
		{
			return;
		}
		SoundFXInstance value;
		if (Instance._soundEffects.TryGetValue(sfxName, out value))
		{
			if ((value.LastPlayed > 0f && Time.realtimeSinceStartup - value.LastPlayed < value.Cooldown) || (!GameSettings.Instance.IsReferenceNull() && (CameraScript.Instance.LastListenerPos - position).sqrMagnitude > distance * distance))
			{
				return;
			}
			for (int i = 0; i < Instance._3Dchannels.Count; i++)
			{
				AudioSource audioSource = Instance._3Dchannels[Instance._3DplayIndex];
				if (!audioSource.isPlaying)
				{
					audioSource.transform.position = position;
					audioSource.outputAudioMixerGroup = (muffled ? AudioManager.InGameHighPass : AudioManager.InGameNormal);
					audioSource.maxDistance = distance;
					PlayOnChannel(value, audioSource, pitch, 0f, true);
					break;
				}
				Instance._3DplayIndex = (Instance._3DplayIndex + 1) % Instance._3Dchannels.Count;
			}
		}
		else
		{
			Debug.LogError("Couldn't play SFX as it doesn't exist " + sfxName);
		}
	}

	public static void PlaySFX(AudioClip clip, Vector3 position, AudioSource src)
	{
		if (Instance == null || (!GameSettings.Instance.IsReferenceNull() && (CameraScript.Instance.LastListenerPos - position).sqrMagnitude > src.maxDistance * src.maxDistance))
		{
			return;
		}
		for (int i = 0; i < Instance._3Dchannels.Count; i++)
		{
			AudioSource audioSource = Instance._3Dchannels[Instance._3DplayIndex];
			if (!audioSource.isPlaying)
			{
				audioSource.transform.position = position;
				audioSource.volume = src.volume;
				audioSource.pitch = src.pitch;
				audioSource.clip = clip;
				audioSource.panStereo = 0f;
				audioSource.outputAudioMixerGroup = src.outputAudioMixerGroup;
				audioSource.maxDistance = src.maxDistance;
				audioSource.Play();
				Instance._3DplayIndex = (Instance._3DplayIndex + 1) % Instance._3Dchannels.Count;
				break;
			}
			Instance._3DplayIndex = (Instance._3DplayIndex + 1) % Instance._3Dchannels.Count;
		}
	}

	public static void PlaySFX(AudioClip clip, Vector3 position, AudioMixerGroup gr, float volume = 1f, float pitch = 1f, float distance = 8f)
	{
		if (Instance == null || (!GameSettings.Instance.IsReferenceNull() && (CameraScript.Instance.LastListenerPos - position).sqrMagnitude > distance * distance))
		{
			return;
		}
		for (int i = 0; i < Instance._3Dchannels.Count; i++)
		{
			AudioSource audioSource = Instance._3Dchannels[Instance._3DplayIndex];
			if (!audioSource.isPlaying)
			{
				audioSource.transform.position = position;
				audioSource.volume = volume;
				audioSource.pitch = pitch;
				audioSource.clip = clip;
				audioSource.panStereo = 0f;
				audioSource.outputAudioMixerGroup = gr;
				audioSource.maxDistance = distance;
				audioSource.Play();
				Instance._3DplayIndex = (Instance._3DplayIndex + 1) % Instance._3Dchannels.Count;
				break;
			}
			Instance._3DplayIndex = (Instance._3DplayIndex + 1) % Instance._3Dchannels.Count;
		}
	}

	private static void PlayOnChannel(SoundFXInstance sfx, AudioSource channel, float pitch, float pan, bool threeD)
	{
		if ((sfx.PitchShift || sfx.StopAtLast) && sfx.LastPlayed > 0f && Time.realtimeSinceStartup - sfx.LastPlayed >= sfx.IncrementCooldown)
		{
			sfx.Pitch = 1f;
			sfx.Index = 0;
		}
		if (sfx.Clips.Length > 1)
		{
			if (sfx.Randomize)
			{
				sfx.Index = (sfx.Index + UnityEngine.Random.Range(1, sfx.Clips.Length - 1)) % sfx.Clips.Length;
			}
			else if (!sfx.StopAtLast || sfx.Index < sfx.Clips.Length - 1)
			{
				sfx.Index = (sfx.Index + 1) % sfx.Clips.Length;
			}
		}
		channel.volume = (threeD ? sfx.Volume : (sfx.Volume * Instance.UIDbScale));
		channel.pitch = ((pitch > 0f) ? pitch : sfx.Pitch);
		channel.clip = sfx.Clips[sfx.Index];
		channel.Play();
		channel.panStereo = pan;
		if (!threeD)
		{
			if (!string.IsNullOrEmpty(sfx.Group))
			{
				Instance.StopFromGroup(sfx.Group);
				Instance._groupPlaying[sfx.Group] = Instance._playIndex;
				Instance._channelGroup[Instance._playIndex] = sfx.Group;
			}
			else
			{
				Instance._channelGroup[Instance._playIndex] = null;
			}
		}
		if (sfx.PitchShift && (sfx.LastPlayed < 0f || Time.realtimeSinceStartup - sfx.LastPlayed < sfx.IncrementCooldown))
		{
			sfx.Pitch = Mathf.Min(sfx.MaxPitch, sfx.Pitch + (sfx.MaxPitch - 1f) / (float)sfx.PitchIncrement);
		}
		sfx.LastPlayed = Time.realtimeSinceStartup;
		if (threeD)
		{
			Instance._3DplayIndex = (Instance._3DplayIndex + 1) % Instance._3Dchannels.Count;
		}
		else
		{
			Instance._playIndex = (Instance._playIndex + 1) % Instance._channels.Count;
		}
	}
}
