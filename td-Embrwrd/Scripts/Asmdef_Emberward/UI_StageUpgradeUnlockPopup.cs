using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageUpgradeUnlockPopup : APopupWindow
{
	public enum eUpgradeType
	{
		NONE = 0,
		AddTowerSlot = 1,
		HandDrawIncrease = 2,
		AddExp = 3,
		AddGold = 4
	}

	[CompilerGenerated]
	private sealed class _003CCR_SelectedAnimProc_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Obj_StageUpgradeItem item;

		public UI_StageUpgradeUnlockPopup _003C_003E4__this;

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
		public _003CCR_SelectedAnimProc_003Ed__14(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_StageUpgradeUnlockPopup _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_ShowWindowProc_003Ed__11(int _003C_003E1__state)
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
	private List<UI_Obj_StageUpgradeItem> list_UpgradeItems;

	[SerializeField]
	private Transform node_Center;

	[SerializeField]
	private Button button_AddTowerSlot;

	[SerializeField]
	private Button button_HandDrawIncrease;

	[SerializeField]
	private Button button_AddExp;

	[SerializeField]
	private Button button_AddGold;

	private bool isUpgradeSelected;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__11))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	private void Anim_AfterSelectedItem(eUpgradeType selectedType)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SelectedAnimProc_003Ed__14))]
	private IEnumerator CR_SelectedAnimProc(UI_Obj_StageUpgradeItem item)
	{
		return null;
	}

	private void OnClickButton_AddTowerSlot()
	{
	}

	private void OnClickButton_HandDrawIncrease()
	{
	}

	private void OnClickButton_AddExp()
	{
	}

	private void OnClickButton_AddGold()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
