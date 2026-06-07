using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class UIGameSettingItem_Button_ResetGame : UIGameSettingItem_Button
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public bool doReset_Step1;

		public bool doReset_Step2;

		public bool doReset_Step3;

		internal void _003CConfirmResetGame_003Eb__0(bool result)
		{
		}

		internal void _003CConfirmResetGame_003Eb__1(bool result)
		{
		}

		internal void _003CConfirmResetGame_003Eb__2(bool result)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CConfirmResetGame_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private _003C_003Ec__DisplayClass1_0 _003C_003E8__1;

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
		public _003CConfirmResetGame_003Ed__1(int _003C_003E1__state)
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

	protected override void OnButtonClickedProc()
	{
	}

	[IteratorStateMachine(typeof(_003CConfirmResetGame_003Ed__1))]
	private IEnumerator ConfirmResetGame()
	{
		return null;
	}
}
