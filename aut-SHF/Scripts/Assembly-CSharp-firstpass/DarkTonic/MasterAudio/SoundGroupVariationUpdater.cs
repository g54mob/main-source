using System;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	[AudioScriptOrder(-15)]
	public class SoundGroupVariationUpdater : MonoBehaviour
	{
		private enum WaitForSoundFinishMode
		{
			None = 0,
			Play = 1,
			WaitForEnd = 2,
			StopOrRepeat = 3
		}

		private const float TimeEarlyToScheduleNextClip = 0.1f;

		private const float FakeNegativeFloatValue = -10f;

		private Transform _objectToFollow;

		private GameObject _objectToFollowGo;

		private bool _isFollowing;

		private SoundGroupVariation _variation;

		private float _priorityLastUpdated;

		private bool _useClipAgePriority;

		private WaitForSoundFinishMode _waitMode;

		private AudioSource _varAudio;

		private MasterAudioGroup _parentGrp;

		private Transform _trans;

		private int _frameNum;

		private bool _inited;

		private float _fadeOutStartTime;

		private bool _fadeInOutWillFadeOut;

		private bool _hasFadeInOutSetMaxVolume;

		private float _fadeInOutInFactor;

		private float _fadeInOutOutFactor;

		private Action _fadeOutEarlyCompletionCallback;

		private int _fadeOutEarlyTotalFrames;

		private float _fadeOutEarlyFrameVolChange;

		private int _fadeOutEarlyFrameNumber;

		private float _fadeOutEarlyOrigVol;

		private float _fadeToTargetFrameVolChange;

		private int _fadeToTargetFrameNumber;

		private float _fadeToTargetOrigVol;

		private Action _fadeToTargetCompletionCallback;

		private int _fadeToTargetTotalFrames;

		private float _fadeToTargetVolume;

		private bool _fadeOutStarted;

		private float _lastFrameClipTime;

		private bool _isPlayingBackward;

		private int _pitchGlideToTargetTotalFrames;

		private float _pitchGlideToTargetFramePitchChange;

		private int _pitchGlideToTargetFrameNumber;

		private float _glideToTargetPitch;

		private float _glideToTargetOrigPitch;

		private Action _glideToPitchCompletionCallback;

		private bool _hasStartedNextInChain;

		private bool _isWaitingForQueuedOcclusionRay;

		private int _framesPlayed;

		private float? _clipStartPosition;

		private float? _clipEndPosition;

		private double? _clipSchedEndTime;

		private bool _hasScheduledNextClip;

		private bool _hasScheduledEndLinkedGroups;

		private int _lastFrameClipPosition;

		private int _timesLooped;

		private bool _isPaused;

		private double _pauseTime;

		private static int _maCachedFromFrame;

		private static MasterAudio _maThisFrame;

		private static Transform _listenerThisFrame;

		public float ClipStartPosition => 0f;

		public float ClipEndPosition => 0f;

		public int FramesPlayed => 0;

		public MasterAudio MAThisFrame => null;

		public float MaxOcclusionFreq => 0f;

		public float MinOcclusionFreq => 0f;

		private Transform Trans => null;

		private AudioSource VarAudio => null;

		private MasterAudioGroup ParentGroup => null;

		private SoundGroupVariation GrpVariation => null;

		private float RayCastOriginOffset => 0f;

		private bool IsOcclusionMeasuringPaused => false;

		private bool HasEndLinkedGroups => false;

		public void GlidePitch(float targetPitch, float glideTime, Action completionCallback = null)
		{
		}

		public void FadeOverTimeToVolume(float targetVolume, float fadeTime, Action completionCallback = null)
		{
		}

		public void FadeOutEarly(float fadeTime, Action completionCallback = null)
		{
		}

		public void Initialize()
		{
		}

		public void FadeInOut()
		{
		}

		public void FollowObject(bool follow, Transform objToFollow, bool clipAgePriority)
		{
		}

		public void WaitForSoundFinish()
		{
		}

		public void StopPitchGliding()
		{
		}

		public void StopFading()
		{
		}

		public void StopWaitingForFinish()
		{
		}

		public void StopFollowing()
		{
		}

		private void DisableIfFinished()
		{
		}

		private void UpdateAudioLocationAndPriority(bool rePrioritize)
		{
		}

		private void ResetToNonOcclusionSetting()
		{
		}

		private void UpdateOcclusion()
		{
		}

		private void DoneWithOcclusion()
		{
		}

		public bool RayCastForOcclusion()
		{
			return false;
		}

		private void PlaySoundAndWait()
		{
		}

		private void DuckIfNotSilent()
		{
		}

		private void StopOrChain()
		{
		}

		public void Pause()
		{
		}

		public void Unpause()
		{
		}

		public void MaybeChain()
		{
		}

		private void UpdatePitch()
		{
		}

		private void PerformFading()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void UpdateCachedObjects()
		{
		}

		public void ManualUpdate()
		{
		}
	}
}
