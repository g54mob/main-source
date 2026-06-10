using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MatchEndText : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCO_EndGame_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MatchEndText _003C_003E4__this;

		public TextData textData;

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
		public _003CCO_EndGame_003Ed__5(int _003C_003E1__state)
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

	public TextData[] textVariations;

	public int secondsToShowText;

	public TextMeshProUGUI text;

	public WizcardsApp app;

	public void EndGame(string key)
	{
	}

	[IteratorStateMachine(typeof(_003CCO_EndGame_003Ed__5))]
	private IEnumerator CO_EndGame(TextData textData)
	{
		return null;
	}
}
