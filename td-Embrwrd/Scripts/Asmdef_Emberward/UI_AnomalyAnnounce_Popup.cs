using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_AnomalyAnnounce_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_AnomalyAnnounce_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__7(int _003C_003E1__state)
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
	private TMP_Text text_QuestDescription;

	[SerializeField]
	private eItemType anomalyType;

	private float waitTime;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	public void Setup(PerkSettingData perkData, PerkSettingData secondAnomalyData = null)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__7))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
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
