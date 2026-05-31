using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ValueCounter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCountUpCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ValueCounter _003C_003E4__this;

		private float _003Ct_003E5__2;

		private int _003Cstart_003E5__3;

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
		public _003CCountUpCoroutine_003Ed__13(int _003C_003E1__state)
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
	private TMP_Text valueText;

	[SerializeField]
	private int targetValue;

	[SerializeField]
	private float duration;

	[SerializeField]
	private bool useUnscaledTime;

	[SerializeField]
	private AnimationCurve ease;

	public string text_a;

	public string text_b;

	private Coroutine countCoroutine;

	public GameObject counter;

	public bool isDailyCount;

	private void Reset()
	{
	}

	public void SetTarget(int newTarget)
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CCountUpCoroutine_003Ed__13))]
	private IEnumerator CountUpCoroutine()
	{
		return null;
	}
}
