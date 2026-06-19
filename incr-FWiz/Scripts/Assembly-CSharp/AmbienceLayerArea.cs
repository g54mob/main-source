using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AmbienceLayerArea : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlayAmbience_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AmbienceLayerArea _003C_003E4__this;

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
		public _003CPlayAmbience_003Ed__10(int _003C_003E1__state)
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

	public CoreAmbienceTrack Track;

	public BoxCollider2D Box;

	public float FadeBuffer;

	public Coroutine coroutine;

	public CoreAmbienceLayer AmbienceLayer;

	public bool Initiated;

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	}

	[IteratorStateMachine(typeof(_003CPlayAmbience_003Ed__10))]
	public IEnumerator PlayAmbience()
	{
		return null;
	}
}
