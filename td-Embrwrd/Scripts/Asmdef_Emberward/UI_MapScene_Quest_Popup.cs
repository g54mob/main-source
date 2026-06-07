using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_MapScene_Quest_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_QuestBoardClickedProc_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int index;

		public UI_MapScene_Quest_Popup _003C_003E4__this;

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
		public _003CCR_QuestBoardClickedProc_003Ed__8(int _003C_003E1__state)
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

		public UI_MapScene_Quest_Popup _003C_003E4__this;

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
	private List<UI_Obj_QuestBoard> list_QuestBoards;

	[SerializeField]
	private List<QuestData> list_QuestData;

	private bool isSelected;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	public void SetupContent()
	{
	}

	private void OnQuestBoardClickedCallback(int index)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_QuestBoardClickedProc_003Ed__8))]
	private IEnumerator CR_QuestBoardClickedProc(int index)
	{
		return null;
	}

	private void OnCardMouseEnterCallback(UI_Obj_ShopCard card)
	{
	}

	private void OnCardMouseExitCallback(UI_Obj_ShopCard card)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__11))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	private void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
