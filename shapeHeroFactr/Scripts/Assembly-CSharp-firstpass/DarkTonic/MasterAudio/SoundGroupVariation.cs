using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	[AudioScriptOrder(-40)]
	[RequireComponent(typeof(SoundGroupVariationUpdater))]
	public class SoundGroupVariation : MonoBehaviour
	{
		public delegate void SoundFinishedEventHandler();

		public delegate void SoundLoopedEventHandler(int loopNumberStarted);

		public class PlaySoundParams
		{
			public string SoundType;

			public float VolumePercentage;

			public float? Pitch;

			public double? TimeToSchedulePlay;

			public Transform SourceTrans;

			public bool AttachToSource;

			public float DelaySoundTime;

			public bool IsChainLoop;

			public bool IsSingleSubscribedPlay;

			public float GroupCalcVolume;

			public bool IsPlaying;

			public PlaySoundParams(string soundType, float volPercent, float groupCalcVolume, float? pitch, Transform sourceTrans, bool attach, float delaySoundTime, double? timeToSchedulePlay, bool isChainLoop, bool isSingleSubscribedPlay)
			{
			}
		}

		public enum PitchMode
		{
			None = 0,
			Gliding = 1
		}

		public enum FadeMode
		{
			None = 0,
			FadeInOut = 1,
			FadeOutEarly = 2,
			GradualFade = 3
		}

		public enum RandomPitchMode
		{
			AddToClipPitch = 0,
			IgnoreClipPitch = 1
		}

		public enum RandomVolumeMode
		{
			AddToClipVolume = 0,
			IgnoreClipVolume = 1
		}

		public enum DetectEndMode
		{
			None = 0,
			DetectEnd = 1
		}

		[CompilerGenerated]
		private sealed class _003CWaitForLoadToUnloadClipAndDeactivate_003Ed__113 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SoundGroupVariation _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForLoadToUnloadClipAndDeactivate_003Ed__113(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public int weight;

		[Range(0f, 1f)]
		public int probabilityToPlay;

		[Range(0f, 10f)]
		public int importance;

		public bool isUninterruptible;

		public bool useLocalization;

		public bool useRandomPitch;

		public RandomPitchMode randomPitchMode;

		public float randomPitchMin;

		public float randomPitchMax;

		public bool useRandomVolume;

		public RandomVolumeMode randomVolumeMode;

		public float randomVolumeMin;

		public float randomVolumeMax;

		public string clipAlias;

		public MasterAudio.AudioLocation audLocation;

		public string resourceFileName;

		public float original_pitch;

		public float original_volume;

		public bool isExpanded;

		public bool isChecked;

		public bool useFades;

		public float fadeInTime;

		public float fadeOutTime;

		public bool useCustomLooping;

		public int minCustomLoops;

		public int maxCustomLoops;

		public bool useRandomStartTime;

		public float randomStartMinPercent;

		public float randomStartMaxPercent;

		public float randomEndPercent;

		public bool useIntroSilence;

		public float introSilenceMin;

		public float introSilenceMax;

		public float fadeMaxVolume;

		public FadeMode curFadeMode;

		public PitchMode curPitchMode;

		public DetectEndMode curDetectEndMode;

		public int frames;

		private AudioSource _audioSource;

		private readonly PlaySoundParams _playSndParam;

		private AudioDistortionFilter _distFilter;

		private AudioEchoFilter _echoFilter;

		private AudioHighPassFilter _hpFilter;

		private AudioLowPassFilter _lpFilter;

		private AudioReverbFilter _reverbFilter;

		private AudioChorusFilter _chorusFilter;

		private string _objectName;

		private float _maxVol;

		private int _instanceId;

		private bool? _audioLoops;

		private int _maxLoops;

		private SoundGroupVariationUpdater _varUpdater;

		private int _previousSoundFinishedFrame;

		private string _soundGroupName;

		private MasterAudio.VariationLoadStatus _loadStatus;

		private bool _isStopRequested;

		private bool _isPaused;

		private bool _isWarmingPlay;

		private Transform _trans;

		private GameObject _go;

		private Transform _objectToFollow;

		private Transform _objectToTriggerFrom;

		private MasterAudioGroup _parentGroupScript;

		private bool _attachToSource;

		private string _resFileName;

		private bool _hasStartedEndLinkedGroups;

		private Coroutine _loadResourceFileCoroutine;

		private Coroutine _loadAddressableCoroutine;

		private bool _isUnloadAddressableCoroutineRunning;

		private TransformFollower _ambientFollower;

		public TransformFollower AmbientFollower => null;

		public AudioDistortionFilter DistortionFilter => null;

		public AudioReverbFilter ReverbFilter => null;

		public AudioChorusFilter ChorusFilter => null;

		public AudioEchoFilter EchoFilter => null;

		public AudioLowPassFilter LowPassFilter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AudioHighPassFilter HighPassFilter => null;

		public Transform ObjectToFollow
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform ObjectToTriggerFrom
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasActiveFXFilter => false;

		public MasterAudioGroup ParentGroup => null;

		public float OriginalPitch => 0f;

		public float OriginalVolume => 0f;

		public string SoundGroupName => null;

		public bool IsAvailableToPlay => false;

		public float LastTimePlayed { get; set; }

		public bool ClipIsLoaded => false;

		public bool IsPlaying => false;

		public MasterAudio.VariationLoadStatus LoadStatus
		{
			get
			{
				return default(MasterAudio.VariationLoadStatus);
			}
			set
			{
			}
		}

		public int InstanceId => 0;

		public bool IsStopRequested => false;

		public Transform Trans => null;

		public GameObject GameObj => null;

		public AudioSource VarAudio => null;

		public bool AudioLoops => false;

		public string ResFileName => null;

		public SoundGroupVariationUpdater VariationUpdater => null;

		public PlaySoundParams PlaySoundParm => null;

		public float SetGroupVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int MaxLoops => 0;

		private bool Is2D => false;

		public bool UsesOcclusion => false;

		public bool IsPaused => false;

		public string GameObjectName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event SoundFinishedEventHandler SoundFinished
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

		public event SoundLoopedEventHandler SoundLooped
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

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void SetMixerGroup()
		{
		}

		public void SetSpatialBlend()
		{
		}

		private void SetOcclusion()
		{
		}

		private void SetPriority()
		{
		}

		public void DisableUpdater()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void StopSoundEarly()
		{
		}

		public void Play(float? pitch, float maxVolume, string gameObjectName, float volPercent, float targetVol, float? targetPitch, Transform sourceTrans, bool attach, float delayTime, double? timeToSchedulePlay, bool isChaining, bool isSingleSubscribedPlay)
		{
		}

		public void SetPlaySoundParams(string gameObjectName, float volPercent, float targetVol, float? targetPitch, Transform sourceTrans, bool attach, float delayTime, double? timeToSchedulePlay, bool isChaining, bool isSingleSubscribedPlay)
		{
		}

		private void MaybeCleanupFinishedDelegate()
		{
		}

		private void ResourceFailedToLoad()
		{
		}

		private void FinishSetupToPlay()
		{
		}

		public void JumpToTime(float timeToJumpTo)
		{
		}

		public void GlideByPitch(float pitchAddition, float glideTime, Action completionCallback = null)
		{
		}

		public void AdjustVolume(float volumePercentage)
		{
		}

		public void Pause()
		{
		}

		public void PlayVideo()
		{
		}

		public void StopVideo()
		{
		}

		public void Unpause()
		{
		}

		public void DoNextChain(float volumePercentage, float? pitch, Transform transActor, bool attach)
		{
		}

		public void PlayEndLinkedGroups(double? timeToPlayClip = null)
		{
		}

		private void EnableUpdater(bool waitForSoundFinish = true)
		{
		}

		private void MaybeUnloadClip()
		{
		}

		private void PlayEndLinkedGroup(string sType, double? timeToPlayClip = null)
		{
		}

		public void Stop(bool stopEndDetection = false, bool skipLinked = false)
		{
		}

		private void StopEndCleanup()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForLoadToUnloadClipAndDeactivate_003Ed__113))]
		private IEnumerator WaitForLoadToUnloadClipAndDeactivate()
		{
			return null;
		}

		public void FadeToVolume(float newVolume, float fadeTime, Action completionCallback = null)
		{
		}

		public void FadeOutNowAndStop(Action completionCallback = null)
		{
		}

		public void FadeOutNowAndStop(float fadeTime, Action completionCallback = null)
		{
		}

		public void MoveToAmbientColliderPosition(Vector3 newPosition, TransformFollower follower)
		{
		}

		public void UpdateAudioVariation(TransformFollower transformFollower)
		{
		}

		public bool WasTriggeredFromTransform(Transform trans)
		{
			return false;
		}

		public bool WasTriggeredFromAnyOfTransformMap(HashSet<Transform> transMap)
		{
			return false;
		}

		public void UpdateTransformTracker(Transform sourceTrans)
		{
		}

		public void SoundLoopStarted(int numberOfLoops)
		{
		}

		public void ClearSubscribers()
		{
		}
	}
}
