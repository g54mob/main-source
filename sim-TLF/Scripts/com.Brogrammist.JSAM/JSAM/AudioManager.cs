using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JSAM
{
	[DefaultExecutionOrder(1)]
	[DisallowMultipleComponent]
	public class AudioManager : MonoBehaviour
	{
		[Header("General Settings")]
		private static AudioManager instance;

		[Tooltip("The Audio Librarys that should be loaded on start")]
		[SerializeField]
		private AudioLibrary[] preloadedLibraries = new AudioLibrary[0];

		private static AudioListener listener;

		private bool doneLoading;

		private bool initialized;

		private static AudioManagerInternal internalInstance;

		private static bool isQuitting;

		public static Action OnAudioManagerInitialized;

		public static Action<SoundChannelHelper, SoundFileObject> OnSoundPlayed;

		public static Action<SoundChannelHelper, SoundFileObject> OnVoicePlayed;

		public static Action<MusicChannelHelper, MusicFileObject> OnMusicPlayed;

		public static Action<float> OnMasterVolumeChanged;

		public static Action<float, float> OnMusicVolumeChanged;

		public static Action<float, float> OnSoundVolumeChanged;

		public static Action<float, float> OnVoiceVolumeChanged;

		public static AudioManager Instance
		{
			get
			{
				bool flag = false;
				if (instance == null)
				{
					flag = true;
				}
				else
				{
					_ = instance.gameObject.scene;
				}
				if (flag)
				{
					instance = JSAMCompatibility.FindObjectOfType<AudioManager>();
					if (instance == null && !isQuitting && Application.isPlaying)
					{
						DebugError("No AudioManager found in scene " + SceneManager.GetActiveScene().name);
					}
				}
				return instance;
			}
		}

		public AudioLibrary[] PreloadedLibraries => preloadedLibraries;

		public static AudioListener AudioListener
		{
			get
			{
				if (!listener)
				{
					listener = JSAMCompatibility.FindObjectOfType<AudioListener>();
				}
				return listener;
			}
		}

		public bool Initialized => initialized;

		public static MusicChannelHelper MainMusicHelper => InternalInstance.MainMusic;

		public static MusicFileObject MainMusic => MainMusicHelper.AudioFile;

		public static AudioManagerInternal InternalInstance
		{
			get
			{
				if (internalInstance == null && Instance != null && Application.isPlaying)
				{
					internalInstance = Instance.gameObject.AddComponent<AudioManagerInternal>();
				}
				return internalInstance;
			}
		}

		public static float MasterVolume
		{
			get
			{
				return InternalInstance.MasterVolume;
			}
			set
			{
				float num = Mathf.Clamp01(value);
				if (num != InternalInstance.MasterVolume)
				{
					InternalInstance.MasterVolume = num;
					OnMasterVolumeChanged?.Invoke(num);
					OnMusicVolumeChanged?.Invoke(InternalInstance.MusicVolume, InternalInstance.ModifiedMusicVolume);
					OnSoundVolumeChanged?.Invoke(InternalInstance.SoundVolume, InternalInstance.ModifiedSoundVolume);
					OnVoiceVolumeChanged?.Invoke(InternalInstance.VoiceVolume, InternalInstance.ModifiedVoiceVolume);
				}
			}
		}

		public static bool MasterMuted
		{
			get
			{
				return InternalInstance.MasterMuted;
			}
			set
			{
				if (InternalInstance.MasterMuted != value)
				{
					InternalInstance.MasterMuted = value;
					OnMasterVolumeChanged?.Invoke(InternalInstance.MasterVolume);
					OnMusicVolumeChanged?.Invoke(InternalInstance.MusicVolume, InternalInstance.ModifiedMusicVolume);
					OnSoundVolumeChanged?.Invoke(InternalInstance.SoundVolume, InternalInstance.ModifiedSoundVolume);
					OnVoiceVolumeChanged?.Invoke(InternalInstance.VoiceVolume, InternalInstance.ModifiedVoiceVolume);
				}
			}
		}

		public static float MusicVolume
		{
			get
			{
				return InternalInstance.MusicVolume;
			}
			set
			{
				float num = Mathf.Clamp01(value);
				if (InternalInstance.MusicVolume != num)
				{
					InternalInstance.MusicVolume = num;
					OnMusicVolumeChanged?.Invoke(InternalInstance.MusicVolume, InternalInstance.ModifiedMusicVolume);
				}
			}
		}

		public static bool MusicMuted
		{
			get
			{
				return InternalInstance.MusicMuted;
			}
			set
			{
				InternalInstance.MusicMuted = value;
				OnMusicVolumeChanged?.Invoke(InternalInstance.MusicVolume, InternalInstance.ModifiedMusicVolume);
			}
		}

		public static float SoundVolume
		{
			get
			{
				return InternalInstance.SoundVolume;
			}
			set
			{
				float num = Mathf.Clamp01(value);
				if (InternalInstance.SoundVolume != num)
				{
					InternalInstance.SoundVolume = num;
					OnSoundVolumeChanged?.Invoke(InternalInstance.SoundVolume, InternalInstance.ModifiedSoundVolume);
				}
			}
		}

		public static bool SoundMuted
		{
			get
			{
				return InternalInstance.SoundMuted;
			}
			set
			{
				InternalInstance.SoundMuted = value;
				OnSoundVolumeChanged?.Invoke(InternalInstance.SoundVolume, InternalInstance.ModifiedSoundVolume);
			}
		}

		public static float VoiceVolume
		{
			get
			{
				return InternalInstance.VoiceVolume;
			}
			set
			{
				float num = Mathf.Clamp01(value);
				if (InternalInstance.VoiceVolume != num)
				{
					InternalInstance.VoiceVolume = num;
					OnVoiceVolumeChanged?.Invoke(InternalInstance.VoiceVolume, InternalInstance.ModifiedVoiceVolume);
				}
			}
		}

		public static bool VoiceMuted
		{
			get
			{
				return InternalInstance.VoiceMuted;
			}
			set
			{
				InternalInstance.VoiceMuted = value;
				OnVoiceVolumeChanged?.Invoke(InternalInstance.VoiceVolume, InternalInstance.ModifiedVoiceVolume);
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void RunOnStart()
		{
			OnAudioManagerInitialized = null;
			OnSoundPlayed = null;
			OnVoicePlayed = null;
			OnMusicPlayed = null;
			OnMasterVolumeChanged = null;
			OnMusicVolumeChanged = null;
			OnSoundVolumeChanged = null;
			OnVoiceVolumeChanged = null;
		}

		private void Awake()
		{
			if (JSAMSettings.Settings.DontDestroyOnLoad)
			{
				base.gameObject.transform.SetParent(null, worldPositionStays: true);
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			EstablishSingletonDominance();
			if (!initialized)
			{
				doneLoading = true;
			}
		}

		private void OnEnable()
		{
			SceneManager.activeSceneChanged += OnSceneChanged;
			Application.quitting += Quitting;
		}

		private void OnDisable()
		{
			SceneManager.activeSceneChanged -= OnSceneChanged;
			Application.quitting -= Quitting;
		}

		private void Quitting()
		{
			isQuitting = true;
		}

		private void Start()
		{
			AudioLibrary[] array = preloadedLibraries;
			foreach (AudioLibrary l in array)
			{
				InternalInstance.LoadAudioLibrary(l);
			}
			initialized = true;
		}

		private void OnSceneChanged(Scene scene1, Scene scene2)
		{
			if (JSAMSettings.Settings.StopSoundsOnSceneChanged)
			{
				StopAllSounds();
			}
			if (JSAMSettings.Settings.StopMusicOnSceneChanged)
			{
				StopAllMusic();
			}
		}

		private static SoundFileObject SoundFileFromEnum<T>(T e) where T : Enum
		{
			return InternalInstance.AudioFileFromEnum(e) as SoundFileObject;
		}

		public static SoundChannelHelper PlaySound<T>(T sound, Transform transform = null, SoundChannelHelper helper = null) where T : Enum
		{
			return InternalInstance.PlaySoundInternal(SoundFileFromEnum(sound), transform, helper);
		}

		public static SoundChannelHelper PlaySound<T>(T sound, Vector3 position, SoundChannelHelper helper = null) where T : Enum
		{
			return InternalInstance.PlaySoundInternal(SoundFileFromEnum(sound), position, helper);
		}

		public static SoundChannelHelper PlaySound(SoundFileObject sound, Transform transform = null, SoundChannelHelper helper = null)
		{
			return InternalInstance.PlaySoundInternal(sound, transform, helper);
		}

		public static SoundChannelHelper PlaySound(SoundFileObject sound, Vector3 position, SoundChannelHelper helper = null)
		{
			return InternalInstance.PlaySoundInternal(sound, position, helper);
		}

		public static SoundChannelHelper StopSound<T>(T sound, Transform transform = null, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopSoundInternal(SoundFileFromEnum(sound), transform, stopInstantly);
		}

		public static SoundChannelHelper StopSound<T>(T sound, Vector3 position, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopSoundInternal(SoundFileFromEnum(sound), position, stopInstantly);
		}

		public static SoundChannelHelper StopSound(SoundFileObject sound, Transform transform = null, bool stopInstantly = true)
		{
			return InternalInstance.StopSoundInternal(sound, transform, stopInstantly);
		}

		public static SoundChannelHelper StopSound(SoundFileObject sound, Vector3 position, bool stopInstantly = true)
		{
			return InternalInstance.StopSoundInternal(sound, position, stopInstantly);
		}

		public static void StopAllSounds(bool stopInstantly = true)
		{
			InternalInstance.StopAllSoundsInternal(stopInstantly);
		}

		public static bool StopSoundIfPlaying<T>(T sound, Transform transform = null, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopSoundIfPlayingInternal(SoundFileFromEnum(sound), transform, stopInstantly);
		}

		public static bool StopSoundIfPlaying<T>(T sound, Vector3 position, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopSoundIfPlayingInternal(SoundFileFromEnum(sound), position, stopInstantly);
		}

		public static bool StopSoundIfPlaying(SoundFileObject sound, Transform transform = null, bool stopInstantly = true)
		{
			return InternalInstance.StopSoundIfPlayingInternal(sound, transform, stopInstantly);
		}

		public static bool StopSoundIfPlaying(SoundFileObject sound, Vector3 position, bool stopInstantly = true)
		{
			return InternalInstance.StopSoundIfPlayingInternal(sound, position, stopInstantly);
		}

		public static bool IsSoundPlaying<T>(T sound, Transform transform = null) where T : Enum
		{
			return InternalInstance.IsSoundPlayingInternal(SoundFileFromEnum(sound), transform);
		}

		public static bool IsSoundPlaying<T>(T sound, Vector3 position) where T : Enum
		{
			return InternalInstance.IsSoundPlayingInternal(SoundFileFromEnum(sound), position);
		}

		public static bool IsSoundPlaying(SoundFileObject sound, Transform transform = null)
		{
			return InternalInstance.IsSoundPlayingInternal(sound, transform);
		}

		public static bool IsSoundPlaying(SoundFileObject sound, Vector3 position)
		{
			return InternalInstance.IsSoundPlayingInternal(sound, position);
		}

		public static bool TryGetPlayingSound<T>(T sound, out SoundChannelHelper helper) where T : Enum
		{
			return InternalInstance.TryGetPlayingSound(SoundFileFromEnum(sound), out helper);
		}

		public static bool TryGetPlayingSound(SoundFileObject sound, out SoundChannelHelper helper)
		{
			return InternalInstance.TryGetPlayingSound(sound, out helper);
		}

		private static MusicFileObject MusicFileFromEnum<T>(T e) where T : Enum
		{
			return InternalInstance.AudioFileFromEnum(e) as MusicFileObject;
		}

		public static MusicChannelHelper PlayMusic<T>(T music, bool isMainMusic) where T : Enum
		{
			return InternalInstance.PlayMusicInternal(MusicFileFromEnum(music), isMainMusic);
		}

		public static MusicChannelHelper PlayMusic(MusicFileObject music, bool isMainMusic)
		{
			return InternalInstance.PlayMusicInternal(music, isMainMusic);
		}

		public static MusicChannelHelper PlayMusic<T>(T music, Transform transform = null, MusicChannelHelper helper = null) where T : Enum
		{
			return InternalInstance.PlayMusicInternal(MusicFileFromEnum(music), transform, helper);
		}

		public static MusicChannelHelper PlayMusic<T>(T music, Vector3 position, MusicChannelHelper helper = null) where T : Enum
		{
			return InternalInstance.PlayMusicInternal(MusicFileFromEnum(music), position, helper);
		}

		public static MusicChannelHelper PlayMusic(MusicFileObject music, Transform transform = null, MusicChannelHelper helper = null)
		{
			return InternalInstance.PlayMusicInternal(music, transform, helper);
		}

		public static MusicChannelHelper PlayMusic(MusicFileObject music, Vector3 position, MusicChannelHelper helper = null)
		{
			return InternalInstance.PlayMusicInternal(music, position, helper);
		}

		public static MusicChannelHelper FadeMusicIn<T>(T music, float fadeInTime, bool isMainmusic = false) where T : Enum
		{
			return InternalInstance.FadeMusicInInternal(MusicFileFromEnum(music), fadeInTime, isMainmusic);
		}

		public static MusicChannelHelper FadeMusicIn(MusicFileObject music, float fadeInTime, bool isMainmusic = false)
		{
			return InternalInstance.FadeMusicInInternal(music, fadeInTime, isMainmusic);
		}

		public static MusicChannelHelper FadeMainMusicOut(float fadeOutTime)
		{
			return InternalInstance.FadeMainMusicOutInternal(fadeOutTime);
		}

		public static MusicChannelHelper FadeMusicOut<T>(T music, float fadeOutTime) where T : Enum
		{
			return InternalInstance.FadeMusicOutInternal(MusicFileFromEnum(music), fadeOutTime);
		}

		public MusicChannelHelper FadeMusicOut(MusicChannelHelper helper, float fadeOutTime)
		{
			return InternalInstance.FadeMusicOutInternal(helper, fadeOutTime);
		}

		public static bool IsMusicPlaying<T>(T music) where T : Enum
		{
			return InternalInstance.IsMusicPlayingInternal(MusicFileFromEnum(music));
		}

		public static bool IsMusicPlaying(MusicFileObject music)
		{
			return InternalInstance.IsMusicPlayingInternal(music);
		}

		public static bool TryGetPlayingMusic<T>(T music, out MusicChannelHelper helper) where T : Enum
		{
			return InternalInstance.TryGetPlayingMusic(MusicFileFromEnum(music), out helper);
		}

		public static bool TryGetPlayingMusic(MusicFileObject music, out MusicChannelHelper helper)
		{
			return InternalInstance.TryGetPlayingMusic(music, out helper);
		}

		public static void StopAllMusic(bool stopInstantly = true)
		{
			InternalInstance.StopAllMusicInternal(stopInstantly);
		}

		public static MusicChannelHelper StopMusic<T>(T music, Transform transform = null, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopMusicInternal(MusicFileFromEnum(music), transform, stopInstantly);
		}

		public static MusicChannelHelper StopMusic<T>(T music, Vector3 position, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopMusicInternal(MusicFileFromEnum(music), position, stopInstantly);
		}

		public static MusicChannelHelper StopMusic(MusicFileObject music, Transform transform = null, bool stopInstantly = true)
		{
			return InternalInstance.StopMusicInternal(music, transform, stopInstantly);
		}

		public static MusicChannelHelper StopMusic(MusicFileObject music, Vector3 position, bool stopInstantly = true)
		{
			return InternalInstance.StopMusicInternal(music, position, stopInstantly);
		}

		public static bool StopMusicIfPlaying<T>(T music, Transform transform = null, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopMusicIfPlayingInternal(MusicFileFromEnum(music), transform, stopInstantly);
		}

		public static bool StopMusicIfPlaying<T>(T music, Vector3 position, bool stopInstantly = true) where T : Enum
		{
			return InternalInstance.StopMusicIfPlayingInternal(MusicFileFromEnum(music), position, stopInstantly);
		}

		public static bool StopMusicIfPlaying(MusicFileObject music, Transform transform = null, bool stopInstantly = true)
		{
			return InternalInstance.StopMusicIfPlayingInternal(music, transform, stopInstantly);
		}

		public static bool StopMusicIfPlaying(MusicFileObject music, Vector3 position, bool stopInstantly = true)
		{
			return InternalInstance.StopMusicIfPlayingInternal(music, position, stopInstantly);
		}

		[RuntimeInitializeOnLoadMethod]
		public void EstablishSingletonDominance()
		{
			if (!JSAMSettings.Settings.EstablishSingletonDominance || !(Instance != this) || !(Instance != null))
			{
				return;
			}
			if (Instance.gameObject.scene.name != base.gameObject.scene.name)
			{
				if (!(Instance.gameObject.scene.name == "DontDestroyOnLoad"))
				{
					_ = base.gameObject.scene;
					instance = this;
				}
				else
				{
					base.enabled = false;
				}
			}
			else if (!Instance.gameObject.activeInHierarchy)
			{
				instance = this;
			}
			else if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				instance = null;
			}
		}

		public static void DebugLog(string consoleOutput)
		{
			if (!JSAMSettings.Settings || !JSAMSettings.Settings.DisableConsoleLogs)
			{
				Debug.Log("JSAM: " + consoleOutput);
			}
		}

		public static void DebugWarning(string consoleOutput)
		{
			Debug.LogWarning("JSAM Warning: " + consoleOutput);
		}

		public static void DebugError(string consoleOutput)
		{
			Debug.LogError("JSAM ERROR: " + consoleOutput);
		}
	}
}
