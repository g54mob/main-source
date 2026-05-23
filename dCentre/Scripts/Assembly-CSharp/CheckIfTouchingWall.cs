using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckIfTouchingWall : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedOverlapCheck_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CheckIfTouchingWall _003C_003E4__this;

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
		public _003CDelayedOverlapCheck_003Ed__6(int _003C_003E1__state)
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

	private BoxCollider boxCollider;

	private Renderer[] allRenderers;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void PerformOverlapCheck()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedOverlapCheck_003Ed__6))]
	private IEnumerator DelayedOverlapCheck()
	{
		return null;
	}

	private void SetRenderersEnabled(bool isEnabled)
	{
	}
}
