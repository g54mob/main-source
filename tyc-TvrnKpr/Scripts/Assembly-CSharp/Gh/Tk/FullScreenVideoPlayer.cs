using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI.Dialogs;
using I18n;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Gh.Tk
{
	public class FullScreenVideoPlayer : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FullScreenVideoPlayer _003C_003E4__this;

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
			public _003CStart_003Ed__9(int _003C_003E1__state)
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

		[SerializeField]
		private Image _backgroundBlocker;

		[SerializeField]
		private RawImage _videoRenderTarget;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		private VideoPlayerAudioProxy _videoPlayerAudioProxy;

		private bool _isWaitingForPreparedVideo;

		public Action videoReadyCallback;

		private Action _videoPreparedCallback;

		private float _introVideoFadeInDuration;

		private Tween _fadeInTween;

		private string _defaultSkipPromptMessage;

		[SerializeField]
		private TextMeshProUGUII18n _skipPromptText;

		[SerializeField]
		private Slider _skipPromptProgress;

		[SerializeField]
		private CanvasGroup _skipPromptProgressGroup;

		private float _spaceHoldTime;

		private float _spaceHoldTimeMax;

		private GameSettingsDialog3DUIView _settingsDialog;

		private bool _isSettingsDialogOpen;

		private long _lastFrameCount;

		private bool _isPlayerActive;

		public KeyCode SkipKey;

		private float _currentSkipPromptDisplayTime;

		private float _skipPromptDisplayTimeMax;

		private float _skipPromptTweenTime;

		private Sequence _showSkipPromptSequence;

		[SerializeField]
		private TextMeshProUGUII18n _anyKeyToSkipText;

		private Tween _anyKeyToSkipTween;

		private Sequence _hideSkipPromptSequence;

		private float _lastVolumeLevel;

		public Action videoCancelledCallback;

		public Action videoFinishedCallback;

		private Sequence _fadeOutSequence;

		public Action videoFadeOutFinishedCallback;

		public static FullScreenVideoPlayer ActivePlayer { get; private set; }

		public bool IsPlaying => false;

		public bool IsAnyKeySkipMode => false;

		public bool IsVideoSkipped { get; private set; }

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__9))]
		private IEnumerator Start()
		{
			return null;
		}

		private void OnVideoPrepared(VideoPlayer source)
		{
		}

		public void PlayVideo(bool skipTransition = true)
		{
		}

		public void SetPromptMessage(string message)
		{
		}

		private void ResumeVideo()
		{
		}

		private void PauseVideo()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private bool IsSkipKeyHeld()
		{
			return false;
		}

		private void LateUpdate()
		{
		}

		private void ShowSkipPrompt()
		{
		}

		private Sequence HideSkipPrompt()
		{
			return null;
		}

		private void UpdateSkipPromptProgress()
		{
		}

		private void UpdateVideoAudioFade(float percentage)
		{
		}

		private void OnDisable()
		{
		}

		private void CleanUpTweens()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnVideoFinished(VideoPlayer source)
		{
		}

		private void OnVideoFadeOutFinished()
		{
		}

		private void OnVideoSkipped()
		{
		}

		private void CleanUpVideo()
		{
		}

		public void SetLooping(bool loop)
		{
		}
	}
}
