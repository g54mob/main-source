using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_BackToTitle : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public bool doBackToTitle;

		internal void _003CCR_BackToTitle_003Eb__0(bool result)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_BackToTitle_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private UI_Window_YesNo_Popup _003Cwindow_003E5__2;

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
		public _003CCR_BackToTitle_003Ed__4(int _003C_003E1__state)
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
	private Button button;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnButtonClick()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BackToTitle_003Ed__4))]
	private IEnumerator CR_BackToTitle()
	{
		return null;
	}
}
