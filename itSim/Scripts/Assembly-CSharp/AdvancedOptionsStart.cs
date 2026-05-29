using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedOptionsStart : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Ccontrols_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AdvancedOptionsStart _003C_003E4__this;

		public Action<string> setter;

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
		public _003Ccontrols_003Ed__9(int _003C_003E1__state)
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

	public ComputerVariables computerVariables;

	public yourComputerInSmallCorp urComputer;

	public GameObject OptionsStart;

	public Image[] bgImage;

	public TextMeshProUGUI[] textAdvanced;

	public Coroutine controlsCoroutine;

	private int i;

	private string hexColorGray;

	private Color newColorGray;

	[IteratorStateMachine(typeof(_003Ccontrols_003Ed__9))]
	public IEnumerator controls(Action<string> setter)
	{
		return null;
	}

	public void ResetBG()
	{
	}

	public void SetPaletteCollor()
	{
	}
}
