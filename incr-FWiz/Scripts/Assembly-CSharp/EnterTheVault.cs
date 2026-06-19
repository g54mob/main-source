using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class EnterTheVault : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public bool faded;

		public bool runningSlides;

		internal void _003CEnterCinematic_003Eb__0()
		{
		}

		internal void _003CEnterCinematic_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CEnterCinematic_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnterTheVault _003C_003E4__this;

		private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

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
		public _003CEnterCinematic_003Ed__13(int _003C_003E1__state)
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

	public float FadeIntoVaultDuration;

	public float FadeIntoVaultZoom;

	public Transform FadeIntoVaultPoint;

	public SlideShowScreen SlideShowPrefab;

	public StorySlideShow SlideShow;

	public float FadeIntoSlideShowTime;

	public CoreAmbienceTrack AmbienceTrack;

	public CoreAmbienceLayer AmbienceLayer;

	public EventReference CinematicMusicTrack;

	public SingleTrackPriorityMusicSupplier PriorityMusicSupplier;

	public GlobalAmbienceTrigger MainAmbienceTrigger;

	public EventReference EnterVaultSound;

	public void Enter()
	{
	}

	[IteratorStateMachine(typeof(_003CEnterCinematic_003Ed__13))]
	public IEnumerator EnterCinematic()
	{
		return null;
	}
}
