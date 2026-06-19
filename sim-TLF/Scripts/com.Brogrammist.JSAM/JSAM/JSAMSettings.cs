using UnityEngine;
using UnityEngine.Audio;

namespace JSAM
{
	public class JSAMSettings : ScriptableObject
	{
		public enum SpatializeUpdateMode
		{
			Default = 0,
			FixedUpdate = 1,
			LateUpdate = 2,
			Parented = 3
		}

		[Tooltip("Ensures that the AudioManager you think you're referring to actually exists in this scene")]
		[SerializeField]
		private bool establishSingletonDominance = true;

		[Tooltip("If true, enables 3D spatialized audio for all sound effects, does not effect music")]
		[SerializeField]
		private bool spatialSound = true;

		[Tooltip("Number of Sound Channels to be created on start")]
		[SerializeField]
		private int startingSoundChannels = 16;

		[Tooltip("Number of Music Channels to be created on start")]
		[SerializeField]
		private int startingMusicChannels = 3;

		[Tooltip("If the maxDistance property of an Audio File Object is left at 0, then this value will be used as a substitute.")]
		[SerializeField]
		private float defaultSoundMaxDistance = 7f;

		[Tooltip("Affects how AudioClip lists are displayed in FileObject inspectors. Toggle this option if you're experiencing issues manipulating Audio Clips in the inspector")]
		[SerializeField]
		private bool useBuiltInAudioListRenderer = true;

		[Tooltip("If true, AudioManager no longer prints info to the console. Does not affect AudioManager errors/warnings")]
		[SerializeField]
		private bool disableConsoleLogs;

		[Tooltip("If true, keeps AudioManager alive through scene loads. You're recommended to disable this if your AudioManager is instanced")]
		[SerializeField]
		private bool dontDestroyOnLoad = true;

		[Tooltip("If true, adds more Audio Sources automatically if you exceed the starting count, you are recommended to keep this enabled")]
		[SerializeField]
		private bool dynamicSourceAllocation = true;

		[Tooltip("The AudioManager will instantiate this prefab during runtime to play sounds from. If null, will use default AudioSource settings.")]
		[SerializeField]
		private GameObject soundChannelPrefabOverride;

		[Tooltip("The AudioManager will instantiate this prefab during runtime to play music from. If null, will use default AudioSource settings.")]
		[SerializeField]
		private GameObject musicChannelPrefabOverride;

		[Tooltip("If true, stops all sounds when you change the active scene")]
		[SerializeField]
		private bool stopSoundsOnSceneChanged;

		[Tooltip("If true, stops all sounds when you change the active scene")]
		[SerializeField]
		private bool stopMusicOnSceneChanged;

		[Tooltip("Use if spatialized sounds are spatializing late when playing in-editor, known to happen with the Oculus SDK")]
		[SerializeField]
		private bool spatializeLateUpdate;

		[Tooltip("Default - Audio Channels track their targets in World Space every update.\n\nFixedUpdate - Audio channels track their targets in FixedUpdate. Good for targets that move during FixedUpdate.\n\nLateUpdate - Same as FixedUpdate but in LateUpdate instead.\n\nParented - Audio channels are parented in the hierarchy to their targets. Slightly less performance overhead, but will clutter your object hierarchies during runtime.")]
		[SerializeField]
		private SpatializeUpdateMode spatializationMode;

		[Tooltip("Changes the pitch of sounds according to Time.timeScale. When Time.timeScale is set to 0, pauses all sounds instead")]
		[SerializeField]
		private bool timeScaledSounds = true;

		[SerializeField]
		private AudioMixer mixer;

		[SerializeField]
		private AudioMixerGroup masterGroup;

		[SerializeField]
		private AudioMixerGroup musicGroup;

		[SerializeField]
		private AudioMixerGroup soundGroup;

		[SerializeField]
		private AudioMixerGroup voiceGroup;

		[Tooltip("If true, will save volume settings into PlayerPrefs and automatically loads previous volume settings on play. ")]
		[SerializeField]
		private bool saveVolumeToPlayerPrefs = true;

		[SerializeField]
		private string masterVolumeKey = "JSAM_MASTER_VOL";

		[SerializeField]
		private string masterMutedKey = "JSAM_MASTER_MUTE";

		[SerializeField]
		private string musicVolumeKey = "JSAM_MUSIC_VOL";

		[SerializeField]
		private string musicMutedKey = "JSAM_MUSIC_MUTE";

		[SerializeField]
		private string soundVolumeKey = "JSAM_SOUND_VOL";

		[SerializeField]
		private string soundMutedKey = "JSAM_SOUND_MUTE";

		[SerializeField]
		private string voiceVolumeKey = "JSAM_VOICE_VOL";

		[SerializeField]
		private string voiceMutedKey = "JSAM_VOICE_MUTE";

		[Tooltip("The font size used when rendering \"quick reference guides\" in JSAM editor windows")]
		[SerializeField]
		private int quickReferenceFontSize = 10;

		private static JSAMSettings settings;

		public bool EstablishSingletonDominance => establishSingletonDominance;

		public bool Spatialize => spatialSound;

		public int StartingSoundChannels => startingSoundChannels;

		public int StartingMusicChannels => startingMusicChannels;

		public float DefaultSoundMaxDistance => defaultSoundMaxDistance;

		public bool UseBuiltInAudioListRenderer => useBuiltInAudioListRenderer;

		public bool DisableConsoleLogs => disableConsoleLogs;

		public new bool DontDestroyOnLoad => dontDestroyOnLoad;

		public bool DynamicSourceAllocation => dynamicSourceAllocation;

		public GameObject SoundChannelPrefab => soundChannelPrefabOverride;

		public GameObject MusicChannelPrefab => musicChannelPrefabOverride;

		public bool StopSoundsOnSceneChanged => stopSoundsOnSceneChanged;

		public bool StopMusicOnSceneChanged => stopMusicOnSceneChanged;

		public bool SpatializeOnLateUpdate => spatializeLateUpdate;

		public SpatializeUpdateMode SpatializationMode => spatializationMode;

		public bool TimeScaledSounds => timeScaledSounds;

		public AudioMixer Mixer => mixer;

		public AudioMixerGroup MasterGroup => masterGroup;

		public AudioMixerGroup MusicGroup => musicGroup;

		public AudioMixerGroup SoundGroup => soundGroup;

		public AudioMixerGroup VoiceGroup => voiceGroup;

		public bool SaveVolumeToPlayerPrefs => saveVolumeToPlayerPrefs;

		public string MasterVolumeKey => masterVolumeKey;

		public string MasterMutedKey => masterMutedKey;

		public string MusicVolumeKey => musicVolumeKey;

		public string MusicMutedKey => musicMutedKey;

		public string SoundVolumeKey => soundVolumeKey;

		public string SoundMutedKey => soundMutedKey;

		public string VoiceVolumeKey => voiceVolumeKey;

		public string VoiceMutedKey => voiceMutedKey;

		public int QuickReferenceFontSize => quickReferenceFontSize;

		public static JSAMSettings Settings
		{
			get
			{
				if (settings == null)
				{
					settings = Resources.Load("JSAMSettings") as JSAMSettings;
				}
				return settings;
			}
		}
	}
}
