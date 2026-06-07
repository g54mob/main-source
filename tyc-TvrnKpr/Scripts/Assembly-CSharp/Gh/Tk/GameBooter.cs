using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	[DefaultExecutionOrder(-99999999)]
	public class GameBooter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameBooter _003C_003E4__this;

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
			public _003CStart_003Ed__20(int _003C_003E1__state)
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
		private GameObject _versionOverlayText;

		private bool _isReadyToLoad;

		private AsyncOperation _gameStartLoadingOp;

		private int _frameCountBeforeStart;

		private int _currentFrameCount;

		[SerializeField]
		private GameObject _introVideoPrefab;

		private FullScreenVideoPlayer _fullScreenVideoPlayer;

		public static bool IsInitialized { get; private set; }

		public static bool IsLoadingSystems { get; private set; }

		public static bool IsFullyBooted { get; private set; }

		public static bool BootedFromStartScene { get; private set; }

		private bool ShouldPlayIntroVideo => false;

		private void DebugLog(string message)
		{
		}

		public void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__20))]
		private IEnumerator Start()
		{
			return null;
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnReadyToContinue()
		{
		}

		private void OnFinishedBooting()
		{
		}

		private void CheckForCrashInfo()
		{
		}

		private void SetupIntroVideo(Action onVideoReady, Action onVideoFinished, Action onVideoFadeOutFinished)
		{
		}

		private void PlayIntroVideo()
		{
		}
	}
}
