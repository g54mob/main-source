using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestReward_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_QuestReward_Popup _003C_003E4__this;

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
		public _003CCR_Proc_003Ed__17(int _003C_003E1__state)
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
	private TMP_Text text_QuestSuccess;

	[SerializeField]
	private TMP_Text text_QuestFailed;

	[SerializeField]
	private TMP_Text text_QuestDescription;

	[SerializeField]
	private Transform node_Reward;

	[SerializeField]
	private Image image_BackLight;

	[SerializeField]
	private UI_Obj_ShopCard shopCard;

	[SerializeField]
	private Transform node_RewardGem;

	[SerializeField]
	private TMP_Text text_RewardGemValue;

	[SerializeField]
	private Transform node_RewardExp;

	[SerializeField]
	private TMP_Text text_RewardExpValue;

	[SerializeField]
	private Transform node_RewardReroll;

	[SerializeField]
	private TMP_Text text_RewardRerollValue;

	private QuestData questData;

	private bool isSuccess;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__17))]
	private IEnumerator CR_Proc()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
