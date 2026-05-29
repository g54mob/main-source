using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class QuestionPopup : Popup
{
	[CompilerGenerated]
	private sealed class _003CWaitForResult_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public QuestionPopup _003C_003E4__this;

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
		public _003CWaitForResult_003Ed__6(int _003C_003E1__state)
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

	private int m_Result;

	private bool m_WaitingResult;

	public void OnOKPressed()
	{
	}

	public void OnCancelPressed()
	{
	}

	protected override void OnHidden()
	{
	}

	public int GetResult()
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CWaitForResult_003Ed__6))]
	public IEnumerator WaitForResult()
	{
		return null;
	}
}
