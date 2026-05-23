using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Presentation.UI.Splash
{
	public class HVSplashScreen : BaseSplashScreen
	{
		[Header("HV Logo")]
		[SerializeField]
		private Animator _splashAnimator;

		[SerializeField]
		private EventReference _splashAudioEvent;

		private EventInstance _splashAudioInstance;

		private PLAYBACK_STATE _audioPlaybackState;

		private Coroutine _animSyncRoutine;

		private float _animationClipLength = -1f;

		protected override void OnContentShowing()
		{
			base.OnContentShowing();
			AnimationClip[] animationClips = _splashAnimator.runtimeAnimatorController.animationClips;
			for (int i = 0; i < animationClips.Length; i++)
			{
				if (animationClips[i].name == "HV-Logo-splash")
				{
					_animationClipLength = animationClips[i].length;
					break;
				}
			}
			_splashAudioInstance = RuntimeManager.CreateInstance(_splashAudioEvent);
			_splashAudioInstance.start();
			_splashAudioInstance.setVolume(_masterVolume.Value);
			StopAnimationSyncing();
			_animSyncRoutine = StartCoroutine(AnimationSyncRoutine());
		}

		protected override void SplashComplete()
		{
			StopAnimationSyncing();
			base.SplashComplete();
		}

		private IEnumerator AnimationSyncRoutine()
		{
			do
			{
				_splashAudioInstance.getTimelinePosition(out var position);
				_splashAnimator.Play("HV-Logo", 0, (float)position / 1000f / _animationClipLength);
				yield return null;
				_splashAudioInstance.getPlaybackState(out _audioPlaybackState);
			}
			while (_audioPlaybackState == PLAYBACK_STATE.STARTING || _audioPlaybackState == PLAYBACK_STATE.PLAYING);
			SplashComplete();
		}

		private void StopAnimationSyncing()
		{
			if (_animSyncRoutine != null)
			{
				StopCoroutine(_animSyncRoutine);
				_animSyncRoutine = null;
				_splashAudioInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			}
		}
	}
}
