using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WholesaleOfferIndicator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CColorChangeRoutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public WholesaleOfferIndicator _003C_003E4__this;

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
		public _003CColorChangeRoutine_003Ed__6(int _003C_003E1__state)
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
	private Image m_TimerImage;

	[SerializeField]
	private Image m_WholesaleIcon;

	[SerializeField]
	private Color m_StartColor;

	[SerializeField]
	private Color m_MiddleColor;

	[SerializeField]
	private Color m_EndColor;

	public void StartTimer(float offertime)
	{
	}

	[IteratorStateMachine(typeof(_003CColorChangeRoutine_003Ed__6))]
	private IEnumerator ColorChangeRoutine(float duration)
	{
		return null;
	}

	public void ResetTimer()
	{
	}
}
