using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

namespace VampireSurvivors.Framework.Platforms
{
	public class AppleArcadeSplashController : MonoBehaviour
	{
		[Serializable]
		public class AspectRatioVideoHolder
		{
			public float _AspectRatio;

			public VideoClip _VideoClip;
		}

		[CompilerGenerated]
		private sealed class _003CDelaySetVideoClip_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AppleArcadeSplashController _003C_003E4__this;

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
			public _003CDelaySetVideoClip_003Ed__15(int _003C_003E1__state)
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
		private VideoPlayer _VideoPlayer;

		[SerializeField]
		private VideoClip _DefaultPortraitClip;

		[SerializeField]
		private VideoClip _DefaultLandscapeClip;

		public List<AspectRatioVideoHolder> _PortraitAspectRatioVideoHolders;

		public List<AspectRatioVideoHolder> _LandscapeAspectRatioVideoHolders;

		[SerializeField]
		private CanvasGroup _VampireSurvivorsSplashContainerPortrait;

		[SerializeField]
		private CanvasGroup _VampireSurvivorsSplashContainerLandscape;

		private bool _hasSkipped;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void SkipAppleSplash()
		{
		}

		private void OnLoopPointReached(VideoPlayer source)
		{
		}

		private void ShowVampireSurvivorsSplash()
		{
		}

		private void LoadGame()
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySetVideoClip_003Ed__15))]
		private IEnumerator DelaySetVideoClip()
		{
			return null;
		}

		private void SetVideoClipBasedOnAspectRatio()
		{
		}

		private float GetAspectRatio()
		{
			return 0f;
		}

		private VideoClip GetVideoClipForAspectRatio(float aspectRatio, bool isPortrait)
		{
			return null;
		}
	}
}
