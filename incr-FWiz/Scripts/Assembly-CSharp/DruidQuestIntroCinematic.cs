using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class DruidQuestIntroCinematic : QuestPart
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public bool finishedPanning;

		public bool finishedStory;

		internal void _003CIntroAnimation_003Eb__0()
		{
		}

		internal void _003CIntroAnimation_003Eb__1()
		{
		}

		internal void _003CIntroAnimation_003Eb__2()
		{
		}

		internal void _003CIntroAnimation_003Eb__3()
		{
		}

		internal void _003CIntroAnimation_003Eb__4()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CIntroAnimation_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DruidQuestIntroCinematic _003C_003E4__this;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

		private Vector3 _003CbackPos_003E5__2;

		private float _003Ctime_003E5__3;

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
		public _003CIntroAnimation_003Ed__17(int _003C_003E1__state)
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

	public float StartBuffer;

	public float PanInDuration;

	public float PanBackDuration;

	public float ZoomInModifier;

	public float EndBuffer;

	public Transform PanToTransform;

	public DialogueStory Dialogue;

	public Animator FrogalAnimator;

	public EventReference ZoneMusicTrack;

	public DefaultPriorityMusicSupplier DefaultMusicSupplier;

	public EventReference CinematicMusicTrack;

	public SingleTrackPriorityMusicSupplier PriorityMusicSupplier;

	public float FadeOutCinematicMusicDuration;

	public Checkpoint Checkpoint;

	public override void ActivateQuestPart()
	{
	}

	public override void ApplyCompletedEffects()
	{
	}

	public override void ApplyFreshCompletedEffects()
	{
	}

	[IteratorStateMachine(typeof(_003CIntroAnimation_003Ed__17))]
	public IEnumerator IntroAnimation()
	{
		return null;
	}
}
