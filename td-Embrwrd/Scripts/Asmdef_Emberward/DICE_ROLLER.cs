using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DICE_ROLLER : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRollDiceCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DICE_ROLLER _003C_003E4__this;

		public int targetFaceIndex;

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
		public _003CRollDiceCoroutine_003Ed__9(int _003C_003E1__state)
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
	private Transform node_DiceJump;

	[SerializeField]
	private Transform node_DiceCenter;

	[SerializeField]
	private Transform node_DiceOuterRotate;

	[SerializeField]
	private List<Transform> list_DiceFaces;

	private void Start()
	{
	}

	public void SortDiceFaces()
	{
	}

	private void Update()
	{
	}

	public void RollDice(int targetNumber)
	{
	}

	public void RollDiceRandom()
	{
	}

	[IteratorStateMachine(typeof(_003CRollDiceCoroutine_003Ed__9))]
	private IEnumerator RollDiceCoroutine(int targetFaceIndex)
	{
		return null;
	}
}
