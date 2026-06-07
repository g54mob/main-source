using UnityEngine;
using UnityEngine.SceneManagement;

namespace GAudio
{
	[ExecuteInEditMode]
	public class GATManager : MonoBehaviour, IGATDataAllocatorOwner
	{
		public enum SampleRatesSupport
		{
			All = 0,
			Only44100 = 1
		}

		public enum SpeakerModeBehaviour
		{
			Stereo = 0,
			PlatformMax = 1
		}

		public delegate void OnMainThreadResumed(double dspTimeDelta);

		[SerializeField]
		private GATDataAllocator.InitializationSettings _AllocatorInitSettings = new GATDataAllocator.InitializationSettings();

		[SerializeField]
		private double _PulseLatency = 0.1;

		[SerializeField]
		private int _MaxIOChannels = 2;

		[SerializeField]
		private SampleRatesSupport _supportedSampleRates;

		[SerializeField]
		private SpeakerModeBehaviour _speakerModeInit;

		[SerializeField]
		private GATPlayer _defaultPlayer;

		private static GATDataAllocator __allocator;

		private static GATManager __uniqueInstance;

		private double _dspTimeInUpdate;

		public static OnMainThreadResumed onMainThreadResumed;

		public GATDataAllocator.InitializationSettings AllocatorInitSettings => _AllocatorInitSettings;

		public double PulseLatency
		{
			get
			{
				return _PulseLatency;
			}
			set
			{
				if (_PulseLatency != value)
				{
					_PulseLatency = value;
				}
			}
		}

		public int MaxIOChannels
		{
			get
			{
				return _MaxIOChannels;
			}
			set
			{
				if (_MaxIOChannels != value)
				{
					_MaxIOChannels = value;
				}
			}
		}

		public SampleRatesSupport SupportedSampleRates
		{
			get
			{
				return _supportedSampleRates;
			}
			set
			{
				_supportedSampleRates = value;
			}
		}

		public SpeakerModeBehaviour SpeakerModeInit
		{
			get
			{
				return _speakerModeInit;
			}
			set
			{
				_speakerModeInit = value;
			}
		}

		public static GATPlayer DefaultPlayer { get; private set; }

		public static GATDataAllocator DefaultDataAllocator => __allocator;

		public static GATManager UniqueInstance => __uniqueInstance;

		GATDataAllocator IGATDataAllocatorOwner.DataAllocator => __allocator;

		private void Awake()
		{
			if (__uniqueInstance != null)
			{
				Debug.LogError("Only one GATManager may exist per scene! Manager found on go: " + __uniqueInstance.gameObject.name);
				Object.DestroyImmediate(this);
			}
			else
			{
				InitManager();
			}
		}

		private void OnEnable()
		{
			AudioSource component = _defaultPlayer.GetComponent<AudioSource>();
			if (__uniqueInstance == null)
			{
				InitManager();
			}
			if (!component.isPlaying)
			{
				component.Play();
			}
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
			_dspTimeInUpdate = AudioSettings.dspTime;
		}

		private void InitManager()
		{
			__uniqueInstance = this;
			if (GATInfo.UniqueInstance == null)
			{
				GATInfo.Init();
			}
			GATInfo.UniqueInstance.SetSyncDspTime(AudioSettings.dspTime);
			GATInfo.UniqueInstance.SetPulseLatency(_PulseLatency);
			GATInfo.UniqueInstance.SetMaxIOChannels(_MaxIOChannels);
			if (__allocator == null)
			{
				__allocator = new GATDataAllocator(_AllocatorInitSettings);
			}
			GATPlayer.InitStatics();
			if (_defaultPlayer == null)
			{
				GameObject gameObject = new GameObject("DefaultPlayer");
				gameObject.transform.parent = base.transform;
				gameObject.AddComponent<AudioSource>();
				_defaultPlayer = gameObject.AddComponent<GATPlayer>();
				_defaultPlayer.AddTrack<GATTrack>();
			}
			DefaultPlayer = _defaultPlayer;
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private void OnDestroy()
		{
			if (!(__uniqueInstance != this))
			{
				GATPlayer.CleanUpStatics();
				if (__allocator != null)
				{
					__allocator.Dispose();
					__allocator = null;
				}
				DefaultPlayer = null;
				__uniqueInstance = null;
				onMainThreadResumed = null;
				SceneManager.sceneLoaded -= OnSceneLoaded;
			}
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			GATInfo.UniqueInstance.SetSyncDspTime(AudioSettings.dspTime);
		}

		public static GATData GetDataContainer(int length)
		{
			return __allocator.GetDataContainer(length);
		}

		public static GATData GetFixedDataContainer(int length, string description)
		{
			return __allocator.GetFixedDataContainer(length, description);
		}

		private void Update()
		{
			if (onMainThreadResumed == null)
			{
				return;
			}
			double dspTimeInUpdate = _dspTimeInUpdate;
			_dspTimeInUpdate = AudioSettings.dspTime;
			double num = _dspTimeInUpdate - dspTimeInUpdate;
			if (Application.isPlaying)
			{
				if (Time.frameCount > 100 && num > 0.1 && onMainThreadResumed != null)
				{
					onMainThreadResumed(num);
				}
			}
			else if (num > 0.1 && onMainThreadResumed != null)
			{
				onMainThreadResumed(num);
			}
		}
	}
}
