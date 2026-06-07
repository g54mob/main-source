using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class PianoPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitForNextHint_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float wait;

			public PianoPage _003C_003E4__this;

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
			public _003CWaitForNextHint_003Ed__35(int _003C_003E1__state)
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
		private bool _DEBUG;

		[SerializeField]
		private Image _Fader;

		[SerializeField]
		private Image _Piano;

		[SerializeField]
		private Image _PianoOverlay;

		[SerializeField]
		private RectTransform _PeachoneHelper;

		[SerializeField]
		private RectTransform _EbonyHelper;

		[SerializeField]
		private RectTransform _BirdBox;

		[SerializeField]
		private GameObject _BackButton;

		[SerializeField]
		private List<RectTransform> _CorrectKeys;

		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private bool _hasPeachone;

		private bool _hasEbony;

		private int[] _keysToPush;

		private List<int> _keysPushed;

		private int _hintCounter;

		private float _birdSpeed;

		private Tween _peachoneXTween;

		private Tween _peachoneYTween;

		private Tween _peachoneAlphaTween;

		private Tween _ebonyXTween;

		private Tween _ebonyYTween;

		private Tween _ebonyAlphaTween;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions player)
		{
		}

		private void OnTouchedKeyRemotely(OnlineSignals.TouchedPianoKeySignal signal)
		{
		}

		private void OnExitPianoRemotely()
		{
		}

		private void OnSuccessfulPianoRemotely()
		{
		}

		public void PlayKey(int i)
		{
		}

		private static void PlaySoundForKey(int i)
		{
		}

		public void Back()
		{
		}

		protected void OnDestroy()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void FlyInNext()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForNextHint_003Ed__35))]
		private IEnumerator WaitForNextHint(float wait)
		{
			return null;
		}

		private void FlyInEbony(int nextKey)
		{
		}

		private void FlyOutEbony()
		{
		}

		private void FlyInPeachone(int nextKey)
		{
		}

		private void FlyOutPeachone()
		{
		}

		private void Exit()
		{
		}

		private void ExitSuccessfully()
		{
		}

		private void ProcessPianoSuccess()
		{
		}

		private void DoTheBigSpoop()
		{
		}
	}
}
