using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class OpeningCinematic : CinematicEvent
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public bool runningSlides;

		public bool finishedPanning;

		public bool finishedStory;

		internal void _003CDoCinematicAction_003Eb__0()
		{
		}

		internal void _003CDoCinematicAction_003Eb__1()
		{
		}

		internal void _003CDoCinematicAction_003Eb__2()
		{
		}

		internal void _003CDoCinematicAction_003Eb__3()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDoCinematicAction_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OpeningCinematic _003C_003E4__this;

		private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

		private SlideShowScreen _003CslideShow_003E5__2;

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
		public _003CDoCinematicAction_003Ed__9(int _003C_003E1__state)
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

	public StorySlideShow StartSlideShow;

	public float StartWaitTime;

	public float FadeInTime;

	public float InitialPanSpeed;

	public DialogueStory OpeningStory;

	public SlideShowScreen SlideShowPrefab;

	public PriorityMusicSupplier SlidesMusic;

	public Transform StartPositionTransform;

	public Transform TowerTransform;

	[IteratorStateMachine(typeof(_003CDoCinematicAction_003Ed__9))]
	public override IEnumerator DoCinematicAction()
	{
		return null;
	}
}
