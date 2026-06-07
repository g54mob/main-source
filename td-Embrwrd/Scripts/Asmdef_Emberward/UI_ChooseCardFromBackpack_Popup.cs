using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChooseCardFromBackpack_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_CardSelectedProc_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Obj_ShopCard card;

		public UI_ChooseCardFromBackpack_Popup _003C_003E4__this;

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
		public _003CCR_CardSelectedProc_003Ed__15(int _003C_003E1__state)
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
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private Button button_Cancel;

	[SerializeField]
	private Transform node_CardParent;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_CreatedCards;

	private List<CardData> list_CardData;

	private Action<CardData> OnCardSelectedCallback;

	private int selectedCount;

	private int selectCountLimit;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void Setup(int selectCountLimit, string title, string description, Action<CardData> callback)
	{
	}

	public void SetupCards(List<CardData> list_Cards, List<bool> list_Available, List<int> list_Costs)
	{
	}

	private void Initialize()
	{
	}

	private void OnCardClicked(UI_Obj_ShopCard card)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CardSelectedProc_003Ed__15))]
	private IEnumerator CR_CardSelectedProc(UI_Obj_ShopCard card)
	{
		return null;
	}

	private void OnButtonCancelClick()
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

	private void RebuildNavigationAndSelect()
	{
	}
}
