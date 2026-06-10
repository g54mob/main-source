using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMoveCardToAvailableSpace_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CardSpace space;

		public GameObject card;

		public DrawPile _003C_003E4__this;

		private Vector3 _003CstartPosition_003E5__2;

		private Vector3 _003CendPosition_003E5__3;

		private float _003Ctime_003E5__4;

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
		public _003CMoveCardToAvailableSpace_003Ed__6(int _003C_003E1__state)
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

	public WizcardPlayer player;

	public CardSpace[] cardSpaces;

	public Queue<GameObject> playerCards;

	public float lerpSpeed;

	public void DrawCard()
	{
	}

	public CardSpace GetFirstEmptySpace()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveCardToAvailableSpace_003Ed__6))]
	private IEnumerator MoveCardToAvailableSpace(GameObject card, CardSpace space)
	{
		return null;
	}

	public static List<T> Shuffle<T>(List<T> list)
	{
		return null;
	}
}
