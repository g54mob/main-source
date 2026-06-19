using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WholeScreenFadeEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoFadeEnumerator_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WholeScreenFadeEffect _003C_003E4__this;

		public float endOpacity;

		public float transitionTime;

		public Action onComplete;

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
		public _003CDoFadeEnumerator_003Ed__16(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CDoFadeOutAndInEnumerator_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WholeScreenFadeEffect _003C_003E4__this;

		public float startTime;

		public float fadeTime;

		public Action middleAction;

		public float fadedTime;

		public Action onComplete;

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
		public _003CDoFadeOutAndInEnumerator_003Ed__17(int _003C_003E1__state)
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
	private Image MainFadeImage;

	private Coroutine _activeFadeCoroutine;

	private Tween _activeTween;

	public static WholeScreenFadeEffect Instance { get; private set; }

	public bool Fading { get; private set; }

	public void Initiate()
	{
	}

	public void SetOpaque()
	{
	}

	public void SetClear()
	{
	}

	public void DoFade(float endOpacity, float transitionTime, Action onComplete = null)
	{
	}

	private void StopActiveFade()
	{
	}

	[IteratorStateMachine(typeof(_003CDoFadeEnumerator_003Ed__16))]
	private IEnumerator DoFadeEnumerator(float endOpacity, float transitionTime, Action onComplete = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDoFadeOutAndInEnumerator_003Ed__17))]
	public IEnumerator DoFadeOutAndInEnumerator(float startTime, float fadeTime, float fadedTime, Action middleAction = null, Action onComplete = null)
	{
		return null;
	}

	public void DoFadeOutAndIn(float startTime, float fadeTime, float fadedTime, Action middleAction = null, Action onComplete = null)
	{
	}

	public void DoFadeToClear(float transitionTime, Action onComplete = null, bool fromCurrent = false)
	{
	}

	public void DoFadeToBlack(float transitionTime, Action onComplete = null, bool fromCurrent = false)
	{
	}

	private void OnDestroy()
	{
	}
}
