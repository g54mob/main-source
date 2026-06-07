using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_LeaderboardScreenshot_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public LeaderboardEntry entry;

		internal bool _003CCR_LoadScreenshot_003Eb__0()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_LoadScreenshot_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderboardEntry entry;

		public UI_LeaderboardScreenshot_Popup _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

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
		public _003CCR_LoadScreenshot_003Ed__8(int _003C_003E1__state)
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
	private Button button_Close;

	[SerializeField]
	private RawImage image_Screenshot;

	[SerializeField]
	private Image image_Loading;

	private Coroutine CR_LoadingScreenshot;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnClickButton_Close()
	{
	}

	public void Setup(LeaderboardEntry entry)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LoadScreenshot_003Ed__8))]
	private IEnumerator CR_LoadScreenshot(LeaderboardEntry entry)
	{
		return null;
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
