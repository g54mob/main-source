using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeckListPopup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_DeckListPopup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__14(int _003C_003E1__state)
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
	private Transform node_GridLayout;

	[SerializeField]
	private GameObject prefab_Card;

	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private TMP_Text text_NoCard;

	private List<CardData> list_CardData;

	private List<UI_Obj_ShopCard> list_Cards;

	private UI_Obj_ShopCard currentSelectedCard;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnClickButton_Leave()
	{
	}

	private void Update()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__14))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void ResetSelection()
	{
	}

	public void RebuildCardNavigation()
	{
	}

	private void SelectCard(UI_Obj_ShopCard card)
	{
	}

	private void DeselectAllCards()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
