using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class MapBarrierObelisk : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateAndDestroy_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapBarrierObelisk _003C_003E4__this;

		private float _003CwaitTime_003E5__2;

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
		public _003CAnimateAndDestroy_003Ed__10(int _003C_003E1__state)
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

	public Animator Animator;

	public float SinkingCameraShake;

	public float LandingCameraShake;

	public EventReference SinkSound;

	public Sprite CompletedBodySprite;

	public SpriteRenderer BodySpriteRenderer;

	public GameObject Body;

	public GameObject Shadow;

	public GameObject BodyCollider;

	public void AnimateAway()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateAndDestroy_003Ed__10))]
	private IEnumerator AnimateAndDestroy()
	{
		return null;
	}

	public void OnCompleted()
	{
	}
}
