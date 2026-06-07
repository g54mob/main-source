using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Refic.Emberward.Minigame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TowerOvercharge_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_MinigameProc_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TowerOvercharge_Popup _003C_003E4__this;

		public eOverchargeType type;

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
		public _003CCR_MinigameProc_003Ed__18(int _003C_003E1__state)
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
	private List<Obj_UI_OverchargeButton> list_OverchargeButton;

	[SerializeField]
	private List<Color> list_TextColors;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Description;

	private ATowerOverchargeMinigame minigame;

	private bool isMinigameStarted;

	private Coroutine cr_MinigameProc;

	private ABaseTower targetTower;

	private float timer_TickSound;

	private int correctCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void StartMinigame(eOverchargeType type, ABaseTower targetTower)
	{
	}

	private void OnClickButtonCallback(int index, OverchargeItemData data)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_MinigameProc_003Ed__18))]
	private IEnumerator CR_MinigameProc(eOverchargeType type)
	{
		return null;
	}

	private void SetupMinigameByType(eOverchargeType type)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
