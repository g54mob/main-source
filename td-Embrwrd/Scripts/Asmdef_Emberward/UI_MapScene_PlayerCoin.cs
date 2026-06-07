using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_MapScene_PlayerCoin : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_CoinLerpValue_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_PlayerCoin _003C_003E4__this;

		public int value;

		private float _003Cduration_003E5__2;

		private float _003Ctimer_003E5__3;

		private int _003CstartValue_003E5__4;

		private int _003CendValue_003E5__5;

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
		public _003CCR_CoinLerpValue_003Ed__8(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private TMP_Text text_Coin;

	private int curCoinValue;

	private Coroutine coroutine_CoinChange;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnCoinChanged(int coin, int delta)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CoinLerpValue_003Ed__8))]
	private IEnumerator CR_CoinLerpValue(int value)
	{
		return null;
	}
}
