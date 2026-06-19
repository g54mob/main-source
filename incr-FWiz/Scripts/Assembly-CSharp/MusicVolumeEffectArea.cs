using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MusicVolumeEffectArea : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CControlVolume_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MusicVolumeEffectArea _003C_003E4__this;

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
		public _003CControlVolume_003Ed__9(int _003C_003E1__state)
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

	public float FadeBuffer;

	public float AreaVolume;

	public BoxCollider2D Box;

	public Coroutine coroutine;

	public string ModifierID;

	private void Awake()
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

	[IteratorStateMachine(typeof(_003CControlVolume_003Ed__9))]
	public IEnumerator ControlVolume()
	{
		return null;
	}
}
