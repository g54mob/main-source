using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using FMODUnity;
using UnityEngine;

public class SlideShowScreen : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseDown_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SlideShowScreen _003C_003E4__this;

		private Tween _003ChideTween_003E5__2;

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
		public _003CCloseDown_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003CTransitionToSlide_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SlideShowScreen _003C_003E4__this;

		public StorySlide slide;

		private Tween _003CshowTween_003E5__2;

		private Tween _003ChideTween_003E5__3;

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
		public _003CTransitionToSlide_003Ed__18(int _003C_003E1__state)
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

	private StorySlideShow _currentSlideshow;

	private int _currentIndex;

	private bool _transitioning;

	private Coroutine _transitionCoroutine;

	[SerializeField]
	private SlideShowScreenSlide _slideShowScreenSlide;

	public EventReference OnClickSound;

	private StorySlide CurrentSlide => null;

	public bool Running { get; private set; }

	private event Action _announceOnFinish
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

	public void Initiate(StorySlideShow storySlideShow, Action announceOnFinish = null)
	{
	}

	public void OnClick()
	{
	}

	private void AdvanceToNext()
	{
	}

	[IteratorStateMachine(typeof(_003CTransitionToSlide_003Ed__18))]
	private IEnumerator TransitionToSlide(StorySlide slide)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseDown_003Ed__19))]
	private IEnumerator CloseDown()
	{
		return null;
	}
}
