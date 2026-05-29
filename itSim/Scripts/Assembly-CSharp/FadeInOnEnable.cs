using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInOnEnable : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeIn_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FadeInOnEnable _003C_003E4__this;

		private float _003Ct_003E5__2;

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
		public _003CFadeIn_003Ed__6(int _003C_003E1__state)
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
	private float duration;

	[SerializeField]
	private bool useUnscaledTime;

	private CanvasGroup cg;

	private Coroutine fadeCoroutine;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeIn_003Ed__6))]
	private IEnumerator FadeIn()
	{
		return null;
	}
}
