using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("")]
	public class AudioManagerInternal : MonoBehaviour
	{
		public class LoadedLibrary
		{
			public AudioLibrary Library;

			public long[] SoundKeys;

			public long[] MusicKeys;

			public int Users;
		}

		private readonly Dictionary<AudioLibrary, LoadedLibrary> loadedLibraries = new Dictionary<AudioLibrary, LoadedLibrary>();

		private readonly Dictionary<string, BaseAudioFileObject> audioFileLookup = new Dictionary<string, BaseAudioFileObject>();

		private readonly Dictionary<long, string> enumNameLookup = new Dictionary<long, string>();

		private readonly List<SoundChannelHelper> soundHelpers = new List<SoundChannelHelper>();

		private readonly List<MusicChannelHelper> musicHelpers = new List<MusicChannelHelper>();

		public bool MasterMuted;

		public float MasterVolume = 1f;

		public bool MusicMuted;

		public float MusicVolume = 1f;

		public bool SoundMuted;

		public float SoundVolume = 1f;

		public bool VoiceMuted;

		public float VoiceVolume = 1f;

		private Transform sourceHolder;

		[SerializeField]
		private GameObject sourcePrefab;

		private float prevTimeScale = 1f;

		private readonly Dictionary<BaseAudioFileObject, List<SoundChannelHelper>> limitedSounds = new Dictionary<BaseAudioFileObject, List<SoundChannelHelper>>();

		private readonly Dictionary<BaseAudioFileObject, List<MusicChannelHelper>> limitedMusic = new Dictionary<BaseAudioFileObject, List<MusicChannelHelper>>();

		public const float EPSILON = 1E-06f;

		public static List<IAudioHelperEvents> OnSpatializeUpdate = new List<IAudioHelperEvents>();

		public static List<IAudioHelperEvents> OnSpatializeLateUpdate = new List<IAudioHelperEvents>();

		public static List<IAudioHelperEvents> OnSpatializeFixedUpdate = new List<IAudioHelperEvents>();

		public static List<IAudioHelperEvents> OnTimeScaleChanged = new List<IAudioHelperEvents>();

		public static List<IAudioHelperEvents> OnMusicVolumeChanged = new List<IAudioHelperEvents>();

		public static List<IAudioHelperEvents> OnSoundVolumeChanged = new List<IAudioHelperEvents>();

		public static List<IAudioHelperEvents> OnVoiceVolumeChanged = new List<IAudioHelperEvents>();

		public Dictionary<AudioLibrary, LoadedLibrary> LoadedLibraries => loadedLibraries;

		public MusicChannelHelper MainMusic { get; private set; }

		private JSAMSettings Settings => JSAMSettings.Settings;

		public float ModifiedMasterVolume => MasterVolume * (float)Convert.ToInt32(!MasterMuted);

		public float ModifiedMusicVolume => ModifiedMasterVolume * MusicVolume * (float)Convert.ToInt32(!MusicMuted);

		public float ModifiedSoundVolume => ModifiedMasterVolume * SoundVolume * (float)Convert.ToInt32(!SoundMuted);

		public float ModifiedVoiceVolume => ModifiedMasterVolume * VoiceVolume * (float)Convert.ToInt32(!VoiceMuted);

		public static AudioManagerInternal Instance => AudioManager.InternalInstance;

		public bool IsLibraryLoaded(AudioLibrary library)
		{
			return loadedLibraries.ContainsKey(library);
		}

		public void SaveVolumeSettings()
		{
			if (JSAMSettings.Settings.SaveVolumeToPlayerPrefs)
			{
				PlayerPrefs.SetFloat(Settings.MasterVolumeKey, MasterVolume);
				PlayerPrefs.SetFloat(Settings.MusicVolumeKey, MusicVolume);
				PlayerPrefs.SetFloat(Settings.SoundVolumeKey, SoundVolume);
				PlayerPrefs.SetFloat(Settings.VoiceVolumeKey, VoiceVolume);
				PlayerPrefs.SetInt(Settings.MasterMutedKey, Convert.ToInt16(MasterMuted));
				PlayerPrefs.SetInt(Settings.MusicMutedKey, Convert.ToInt16(MusicMuted));
				PlayerPrefs.SetInt(Settings.SoundMutedKey, Convert.ToInt16(SoundMuted));
				PlayerPrefs.SetInt(Settings.VoiceMutedKey, Convert.ToInt16(VoiceMuted));
				PlayerPrefs.Save();
			}
		}

		public void LoadVolumeSettings()
		{
			if (Settings.SaveVolumeToPlayerPrefs)
			{
				MasterVolume = PlayerPrefs.GetFloat(Settings.MasterVolumeKey, 1f);
				MusicVolume = PlayerPrefs.GetFloat(Settings.MusicVolumeKey, 1f);
				SoundVolume = PlayerPrefs.GetFloat(Settings.SoundVolumeKey, 1f);
				VoiceVolume = PlayerPrefs.GetFloat(Settings.VoiceVolumeKey, 1f);
				MasterMuted = Convert.ToBoolean(PlayerPrefs.GetInt(Settings.MasterMutedKey, 0));
				MusicMuted = Convert.ToBoolean(PlayerPrefs.GetInt(Settings.MusicMutedKey, 0));
				SoundMuted = Convert.ToBoolean(PlayerPrefs.GetInt(Settings.SoundMutedKey, 0));
				VoiceMuted = Convert.ToBoolean(PlayerPrefs.GetInt(Settings.VoiceMutedKey, 0));
			}
		}

		private void MusicVolumeChanged(float channelVolume, float realVolume)
		{
			foreach (IAudioHelperEvents item in OnMusicVolumeChanged)
			{
				item.VolumeChanged(channelVolume, realVolume);
			}
		}

		private void SoundVolumeChanged(float channelVolume, float realVolume)
		{
			foreach (IAudioHelperEvents item in OnSoundVolumeChanged)
			{
				item.VolumeChanged(channelVolume, realVolume);
			}
		}

		private void VoiceVolumeChanged(float channelVolume, float realVolume)
		{
			foreach (IAudioHelperEvents item in OnVoiceVolumeChanged)
			{
				item.VolumeChanged(channelVolume, realVolume);
			}
		}

		public void RemovePlayingSound(BaseAudioFileObject s, SoundChannelHelper h)
		{
			if (limitedSounds.ContainsKey(s))
			{
				limitedSounds[s].Remove(h);
			}
		}

		public void RemovePlayingMusic(BaseAudioFileObject s, MusicChannelHelper h)
		{
			if (limitedMusic.ContainsKey(s))
			{
				limitedMusic[s].Remove(h);
			}
		}

		private void Awake()
		{
			LoadVolumeSettings();
			sourceHolder = new GameObject("Sources").transform;
			for (int i = 0; i < Settings.StartingSoundChannels; i++)
			{
				soundHelpers.Add(CreateSoundChannel());
			}
			for (int j = 0; j < Settings.StartingMusicChannels; j++)
			{
				musicHelpers.Add(CreateMusicChannel());
			}
			if (musicHelpers.Count > 0)
			{
				MainMusic = musicHelpers[0];
			}
			AudioManager.OnMusicVolumeChanged = (Action<float, float>)Delegate.Combine(AudioManager.OnMusicVolumeChanged, new Action<float, float>(MusicVolumeChanged));
			AudioManager.OnSoundVolumeChanged = (Action<float, float>)Delegate.Combine(AudioManager.OnSoundVolumeChanged, new Action<float, float>(SoundVolumeChanged));
			AudioManager.OnVoiceVolumeChanged = (Action<float, float>)Delegate.Combine(AudioManager.OnVoiceVolumeChanged, new Action<float, float>(VoiceVolumeChanged));
		}

		private void Start()
		{
			sourceHolder.SetParent(base.transform);
		}

		private void Update()
		{
			if (Settings.SpatializationMode == JSAMSettings.SpatializeUpdateMode.Default)
			{
				foreach (IAudioHelperEvents item in OnSpatializeUpdate)
				{
					item.Spatialize();
				}
			}
			if (Mathf.Abs(Time.timeScale - prevTimeScale) > 0f)
			{
				foreach (IAudioHelperEvents item2 in OnTimeScaleChanged)
				{
					item2.TimeScaleChanged(prevTimeScale);
				}
			}
			prevTimeScale = Time.timeScale;
		}

		private void FixedUpdate()
		{
			if (Settings.SpatializationMode != JSAMSettings.SpatializeUpdateMode.FixedUpdate)
			{
				return;
			}
			foreach (IAudioHelperEvents item in OnSpatializeFixedUpdate)
			{
				item.Spatialize();
			}
		}

		private void LateUpdate()
		{
			if (Settings.SpatializationMode != JSAMSettings.SpatializeUpdateMode.LateUpdate)
			{
				return;
			}
			foreach (IAudioHelperEvents item in OnSpatializeLateUpdate)
			{
				item.Spatialize();
			}
		}

		private void OnDestroy()
		{
			SaveVolumeSettings();
			AudioManager.OnMusicVolumeChanged = (Action<float, float>)Delegate.Remove(AudioManager.OnMusicVolumeChanged, new Action<float, float>(MusicVolumeChanged));
			AudioManager.OnSoundVolumeChanged = (Action<float, float>)Delegate.Remove(AudioManager.OnSoundVolumeChanged, new Action<float, float>(SoundVolumeChanged));
			AudioManager.OnVoiceVolumeChanged = (Action<float, float>)Delegate.Remove(AudioManager.OnVoiceVolumeChanged, new Action<float, float>(VoiceVolumeChanged));
		}

		private MusicChannelHelper HandleLimitedInstances(MusicFileObject music, MusicChannelHelper helper)
		{
			if (music.maxPlayingInstances != 0)
			{
				if (limitedMusic.ContainsKey(music))
				{
					if (limitedMusic[music].Count > music.maxPlayingInstances)
					{
						MusicChannelHelper musicChannelHelper = limitedMusic[music][0];
						limitedMusic[music].RemoveAt(0);
						limitedMusic[music].Add(musicChannelHelper);
						return musicChannelHelper;
					}
				}
				else
				{
					limitedMusic.Add(music, new List<MusicChannelHelper>());
				}
				limitedMusic[music].Add(helper);
			}
			return helper;
		}

		private bool PlaybackChecks(BaseAudioFileObject file)
		{
			if (!Application.isPlaying)
			{
				return false;
			}
			if ((bool)file)
			{
				return true;
			}
			AudioManager.DebugWarning("AudioManager was passed a null Audio File Object!");
			return false;
		}

		public MusicChannelHelper PlayMusicInternal(MusicFileObject music, bool isMain)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			if (isMain)
			{
				PlayMusicInternal(music, null, MainMusic);
			}
			else
			{
				PlayMusicInternal(music);
			}
			AudioManager.OnMusicPlayed?.Invoke(MainMusic, music);
			return MainMusic;
		}

		public MusicChannelHelper PlayMusicInternal(MusicFileObject music, Transform newTransform = null, MusicChannelHelper helper = null)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			bool flag = helper != null;
			if (helper == null)
			{
				helper = GetFreeMusicHelper();
			}
			if (helper == null)
			{
				return null;
			}
			if (!flag)
			{
				helper = HandleLimitedInstances(music, helper);
			}
			helper.AssignNewFile(music);
			helper.SetSpatializationTarget(newTransform);
			helper.Play();
			AudioManager.OnMusicPlayed?.Invoke(helper, music);
			return helper;
		}

		public MusicChannelHelper PlayMusicInternal(MusicFileObject music, Vector3 position, MusicChannelHelper helper = null)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			bool flag = helper != null;
			if (helper == null)
			{
				helper = GetFreeMusicHelper();
			}
			if (helper == null)
			{
				return null;
			}
			if (!flag)
			{
				helper = HandleLimitedInstances(music, helper);
			}
			helper.AssignNewFile(music);
			helper.SetSpatializationTarget(position);
			helper.Play();
			AudioManager.OnMusicPlayed?.Invoke(helper, music);
			return helper;
		}

		public MusicChannelHelper FadeMusicInInternal(MusicFileObject music, float fadeInTime, bool isMain)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			MusicChannelHelper musicChannelHelper;
			if (isMain)
			{
				musicChannelHelper = MainMusic;
			}
			else
			{
				musicChannelHelper = musicHelpers[GetFreeMusicChannel()];
				if (musicChannelHelper == null)
				{
					return null;
				}
				musicChannelHelper = HandleLimitedInstances(music, musicChannelHelper);
			}
			musicChannelHelper.AssignNewFile(music);
			musicChannelHelper.Play();
			musicChannelHelper.BeginFadeIn(fadeInTime);
			AudioManager.OnMusicPlayed?.Invoke(musicChannelHelper, music);
			return musicChannelHelper;
		}

		public MusicChannelHelper FadeMainMusicOutInternal(float fadeOutTime)
		{
			if (!Application.isPlaying)
			{
				return null;
			}
			_ = MainMusic;
			if (!MainMusic)
			{
				AudioManager.DebugWarning("Tried to fade out Main Music when no music was marked as Main! Marking now.");
				MainMusic = musicHelpers[0];
			}
			MusicChannelHelper musicChannelHelper = musicHelpers[GetFreeMusicChannel()];
			musicChannelHelper.AssignNewFile(MainMusic.AudioFile);
			musicChannelHelper.Play();
			musicChannelHelper.AudioSource.time = MainMusic.AudioSource.time;
			musicChannelHelper.BeginFadeOut(fadeOutTime);
			MainMusic.Stop();
			return musicChannelHelper;
		}

		public MusicChannelHelper FadeMusicOutInternal(MusicFileObject music, float fadeOutTime)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			if (TryGetPlayingMusic(music, out var helper))
			{
				helper.BeginFadeOut(fadeOutTime);
			}
			else
			{
				AudioManager.DebugWarning("Cannot fade out track " + music?.ToString() + " because track is not currently playing!");
			}
			return helper;
		}

		public MusicChannelHelper FadeMusicOutInternal(MusicChannelHelper helper, float fadeOutTime)
		{
			if (!Application.isPlaying)
			{
				return null;
			}
			if (!helper)
			{
				AudioManager.DebugWarning("AudioManager was passed a null music helper!");
				return null;
			}
			if ((bool)helper)
			{
				helper.BeginFadeOut(fadeOutTime);
			}
			else
			{
				AudioManager.DebugError("Music Fade Out Failed! Provided Music Channel Helper was null!");
			}
			return helper;
		}

		public void StopAllMusicInternal(bool stopInstantly)
		{
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].AudioSource.isPlaying)
				{
					musicHelpers[i].Stop(stopInstantly);
				}
			}
		}

		public MusicChannelHelper StopMusicInternal(MusicFileObject music, Transform t, bool stopInstantly)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].AudioSource == null)
				{
					return null;
				}
				if (music.Files.Contains(musicHelpers[i].AudioSource.clip) && (!(t != null) || !music.spatialize || !(musicHelpers[i].SpatializationTarget != t)))
				{
					musicHelpers[i].Stop(stopInstantly);
					return musicHelpers[i];
				}
			}
			return null;
		}

		public MusicChannelHelper StopMusicInternal(MusicFileObject music, Vector3 pos, bool stopInstantly)
		{
			if (!PlaybackChecks(music))
			{
				return null;
			}
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].AudioSource == null)
				{
					return null;
				}
				if (music.Files.Contains(musicHelpers[i].AudioSource.clip) && (!(musicHelpers[i].SpatializationPosition != pos) || !music.spatialize))
				{
					musicHelpers[i].Stop(stopInstantly);
					return musicHelpers[i];
				}
			}
			return null;
		}

		public bool StopMusicIfPlayingInternal(MusicFileObject music, Transform trans = null, bool stopInstantly = true)
		{
			if (!IsMusicPlayingInternal(music, trans))
			{
				return false;
			}
			StopMusicInternal(music, trans, stopInstantly);
			return true;
		}

		public bool StopMusicIfPlayingInternal(MusicFileObject music, Vector3 pos, bool stopInstantly = true)
		{
			if (!IsMusicPlayingInternal(music, pos))
			{
				return false;
			}
			StopMusicInternal(music, pos, stopInstantly);
			return true;
		}

		private SoundChannelHelper HandleLimitedInstances(SoundFileObject sound, SoundChannelHelper helper)
		{
			if (sound.maxPlayingInstances != 0)
			{
				if (limitedSounds.ContainsKey(sound))
				{
					if (limitedSounds[sound].Count >= sound.maxPlayingInstances)
					{
						SoundChannelHelper soundChannelHelper = limitedSounds[sound][0];
						limitedSounds[sound].RemoveAt(0);
						limitedSounds[sound].Add(soundChannelHelper);
						return soundChannelHelper;
					}
				}
				else
				{
					limitedSounds.Add(sound, new List<SoundChannelHelper>());
				}
				limitedSounds[sound].Add(helper);
			}
			return helper;
		}

		public SoundChannelHelper PlaySoundInternal(SoundFileObject sound, Transform newTransform = null, SoundChannelHelper helper = null)
		{
			if (!PlaybackChecks(sound))
			{
				return null;
			}
			bool flag = helper != null;
			if (helper == null)
			{
				helper = soundHelpers[GetFreeSoundChannel()];
			}
			if (helper == null)
			{
				return null;
			}
			if (!flag)
			{
				helper = HandleLimitedInstances(sound, helper);
			}
			helper.AssignNewFile(sound);
			helper.SetSpatializationTarget(newTransform);
			helper.Play();
			AudioManager.OnSoundPlayed?.Invoke(helper, sound);
			return helper;
		}

		public SoundChannelHelper PlaySoundInternal(SoundFileObject sound, Vector3 position, SoundChannelHelper helper = null)
		{
			if (!PlaybackChecks(sound))
			{
				return null;
			}
			bool flag = helper != null;
			if (helper == null)
			{
				helper = soundHelpers[GetFreeSoundChannel()];
			}
			if (helper == null)
			{
				return null;
			}
			if (!flag)
			{
				helper = HandleLimitedInstances(sound, helper);
			}
			helper.AssignNewFile(sound);
			helper.SetSpatializationTarget(position);
			helper.Play();
			AudioManager.OnSoundPlayed?.Invoke(helper, sound);
			return helper;
		}

		public void StopAllSoundsInternal(bool stopInstantly = true)
		{
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].AudioSource.isPlaying)
				{
					soundHelpers[i].Stop(stopInstantly);
				}
			}
		}

		public SoundChannelHelper StopSoundInternal(SoundFileObject sound, Transform t = null, bool stopInstantly = true)
		{
			if (!PlaybackChecks(sound))
			{
				return null;
			}
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].AudioSource == null)
				{
					return null;
				}
				if (sound.Files.Contains(soundHelpers[i].AudioSource.clip) && (!(t != null) || !sound.spatialize || !(soundHelpers[i].SpatializationTarget != t)))
				{
					soundHelpers[i].Stop(stopInstantly);
					return soundHelpers[i];
				}
			}
			return null;
		}

		public SoundChannelHelper StopSoundInternal(SoundFileObject sound, Vector3 pos, bool stopInstantly = true)
		{
			if (!PlaybackChecks(sound))
			{
				return null;
			}
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].AudioSource == null)
				{
					return null;
				}
				if (sound.Files.Contains(soundHelpers[i].AudioSource.clip) && (!(soundHelpers[i].SpatializationPosition != pos) || !sound.spatialize))
				{
					soundHelpers[i].Stop(stopInstantly);
					return soundHelpers[i];
				}
			}
			return null;
		}

		public bool StopSoundIfPlayingInternal(SoundFileObject sound, Transform trans = null, bool stopInstantly = true)
		{
			if (!IsSoundPlayingInternal(sound, trans))
			{
				return false;
			}
			StopSoundInternal(sound, trans, stopInstantly);
			return true;
		}

		public bool StopSoundIfPlayingInternal(SoundFileObject sound, Vector3 pos, bool stopInstantly = true)
		{
			if (!IsSoundPlayingInternal(sound, pos))
			{
				return false;
			}
			StopSoundInternal(sound, pos, stopInstantly);
			return true;
		}

		public MusicChannelHelper GetFreeMusicHelper()
		{
			return musicHelpers[GetFreeMusicChannel()];
		}

		private int GetFreeMusicChannel()
		{
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].IsFree)
				{
					return i;
				}
			}
			if (JSAMSettings.Settings.DynamicSourceAllocation)
			{
				musicHelpers.Add(CreateMusicChannel());
				return musicHelpers.Count - 1;
			}
			AudioManager.DebugError("Ran out of Music Sources! Please enable Dynamic Source Allocation in the AudioManager's settings or increase the number of Music Channels created on startup. You might be playing too many sounds at once.");
			return -1;
		}

		public SoundChannelHelper GetFreeSoundHelper()
		{
			return soundHelpers[GetFreeSoundChannel()];
		}

		private int GetFreeSoundChannel()
		{
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].IsFree)
				{
					return i;
				}
			}
			if (JSAMSettings.Settings.DynamicSourceAllocation)
			{
				soundHelpers.Add(CreateSoundChannel());
				return soundHelpers.Count - 1;
			}
			Debug.LogError("AudioManager Error: Ran out of Sound Sources! Please enable Dynamic Source Allocation in the AudioManager's settings or increase the number of Sound Channels created on startup. You might be playing too many sounds at once.");
			return -1;
		}

		public bool IsSoundPlayingInternal(SoundFileObject s, Transform trans)
		{
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].AudioFile == s && soundHelpers[i].AudioSource.isPlaying && (!(trans != null) || !s.spatialize || !(soundHelpers[i].SpatializationTarget != trans)))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsSoundPlayingInternal(SoundFileObject s, Vector3 pos)
		{
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].AudioFile == s && soundHelpers[i].AudioSource.isPlaying && (!(soundHelpers[i].SpatializationPosition != pos) || !s.spatialize))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetPlayingSound(SoundFileObject s, out SoundChannelHelper helper)
		{
			for (int i = 0; i < soundHelpers.Count; i++)
			{
				if (soundHelpers[i].AudioFile == s && soundHelpers[i].AudioSource.isPlaying)
				{
					helper = soundHelpers[i];
					return true;
				}
			}
			helper = null;
			return false;
		}

		public bool IsMusicPlayingInternal(MusicFileObject a, Transform trans = null)
		{
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].AudioFile == a && musicHelpers[i].AudioSource.isPlaying && (!(trans != null) || !a.spatialize || !(musicHelpers[i].SpatializationTarget != trans)))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsMusicPlayingInternal(MusicFileObject s, Vector3 pos)
		{
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].AudioFile == s && musicHelpers[i].AudioSource.isPlaying && (!(musicHelpers[i].SpatializationPosition != pos) || !s.spatialize))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetPlayingMusic(MusicFileObject a, out MusicChannelHelper helper)
		{
			for (int i = 0; i < musicHelpers.Count; i++)
			{
				if (musicHelpers[i].AudioFile == a && musicHelpers[i].AudioSource.isPlaying)
				{
					helper = musicHelpers[i];
					return true;
				}
			}
			helper = null;
			return false;
		}

		private MusicChannelHelper CreateMusicChannel()
		{
			MusicChannelHelper component;
			if ((bool)JSAMSettings.Settings.MusicChannelPrefab)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JSAMSettings.Settings.MusicChannelPrefab, sourceHolder);
				if (!gameObject.TryGetComponent<MusicChannelHelper>(out component))
				{
					component = gameObject.AddComponent<MusicChannelHelper>();
				}
			}
			else
			{
				GameObject gameObject = new GameObject("AudioChannel");
				gameObject.transform.SetParent(sourceHolder);
				gameObject.AddComponent<AudioSource>();
				component = gameObject.AddComponent<MusicChannelHelper>();
			}
			component.Init(Settings.MusicGroup);
			return component;
		}

		private SoundChannelHelper CreateSoundChannel()
		{
			SoundChannelHelper component;
			if ((bool)JSAMSettings.Settings.SoundChannelPrefab)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JSAMSettings.Settings.SoundChannelPrefab, sourceHolder);
				if (!gameObject.TryGetComponent<SoundChannelHelper>(out component))
				{
					component = gameObject.AddComponent<SoundChannelHelper>();
				}
			}
			else
			{
				GameObject gameObject = new GameObject("AudioChannel");
				gameObject.transform.SetParent(sourceHolder);
				gameObject.AddComponent<AudioSource>();
				component = gameObject.AddComponent<SoundChannelHelper>();
			}
			component.Init(Settings.SoundGroup);
			return component;
		}

		public BaseAudioFileObject AudioFileFromEnum<T>(T e) where T : Enum
		{
			long key = ComputeEnumHash(e);
			if (enumNameLookup.TryGetValue(key, out var value))
			{
				return AudioFileFromString(value);
			}
			throw new KeyNotFoundException($"Enum {e} of type {typeof(T).Name} not found in lookup!");
		}

		public BaseAudioFileObject AudioFileFromString(string s)
		{
			if (audioFileLookup.TryGetValue(s, out var _))
			{
				return audioFileLookup[s];
			}
			AudioManager.DebugError("Could not find the Audio File for enum " + s + "! Make sure its parent Library was loaded first.");
			return null;
		}

		public void LoadAudioLibrary(AudioLibrary l)
		{
			if (IsLibraryLoaded(l))
			{
				AudioManager.DebugWarning("Tried loading AudioLibrary " + l?.ToString() + " when it was already loaded!");
				return;
			}
			LoadedLibrary loadedLibrary = new LoadedLibrary
			{
				Library = l,
				Users = 1
			};
			List<string> list = new List<string>();
			string text = l.soundEnumGenerated;
			if (!l.soundNamespaceGenerated.IsNullEmptyOrWhiteSpace())
			{
				text = l.soundNamespaceGenerated + "." + text;
			}
			Type type = Type.GetType(text + ", Assembly-CSharp");
			list.AddRange(Enum.GetNames(type));
			loadedLibrary.SoundKeys = new long[list.Count];
			for (int i = 0; i < l.Sounds.Count; i++)
			{
				l.Sounds[i].Initialize();
				string text2 = text + "." + list[i];
				long num = ComputeEnumHash(type, i);
				loadedLibrary.SoundKeys[i] = num;
				audioFileLookup.Add(text2, l.Sounds[i]);
				enumNameLookup[num] = text2;
			}
			list.Clear();
			string text3 = l.musicEnumGenerated;
			if (!l.musicNamespaceGenerated.IsNullEmptyOrWhiteSpace())
			{
				text3 = l.musicNamespaceGenerated + "." + text3;
			}
			type = Type.GetType(text3 + ", Assembly-CSharp");
			list.AddRange(Enum.GetNames(type));
			loadedLibrary.MusicKeys = new long[list.Count];
			for (int j = 0; j < l.Music.Count; j++)
			{
				string text4 = text3 + "." + list[j];
				long num2 = ComputeEnumHash(type, j);
				loadedLibrary.MusicKeys[j] = num2;
				audioFileLookup.Add(text4, l.Music[j]);
				enumNameLookup[num2] = text4;
			}
			loadedLibraries.Add(l, loadedLibrary);
		}

		public void UnloadAudioLibrary(AudioLibrary l)
		{
			if (!IsLibraryLoaded(l))
			{
				AudioManager.DebugWarning("Tried unloading AudioLibrary " + l?.ToString() + " when it wasn't loaded!");
				return;
			}
			LoadedLibrary loadedLibrary = loadedLibraries[l];
			long[] soundKeys = loadedLibrary.SoundKeys;
			foreach (long key in soundKeys)
			{
				audioFileLookup.Remove(enumNameLookup[key]);
				enumNameLookup.Remove(key);
			}
			soundKeys = loadedLibrary.MusicKeys;
			foreach (long key2 in soundKeys)
			{
				audioFileLookup.Remove(enumNameLookup[key2]);
				enumNameLookup.Remove(key2);
			}
			loadedLibraries.Remove(l);
		}

		private long ComputeEnumHash(Type enumType, int value)
		{
			return ((long)enumType.MetadataToken << 32) | (uint)value;
		}

		private long ComputeEnumHash<T>(T e) where T : Enum
		{
			int enumUnderlyingValue = GetEnumUnderlyingValue(e);
			return ((long)typeof(T).MetadataToken << 32) | (uint)enumUnderlyingValue;
		}

		private static int GetEnumUnderlyingValue<T>(T e) where T : Enum
		{
			return UnsafeUtility.As<T, int>(ref e);
		}
	}
}
