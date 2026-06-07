using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TowerArrange_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TowerArrange_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__24(int _003C_003E1__state)
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
	private GameObject prefab_DraggableCard;

	[SerializeField]
	private List<UI_Obj_CardSlot> list_CardSlot;

	[SerializeField]
	private Transform node_ScrollviewContent;

	[SerializeField]
	private Transform node_DraggingCardParent;

	[SerializeField]
	private Button button_CloseWindow;

	[SerializeField]
	private TMP_Text text_NoOtherTowerCard;

	[SerializeField]
	private GameObject node_LockedInGame;

	[SerializeField]
	private List<UI_DraggableCard> list_DraggableCard;

	private UI_DraggableCard currentSelectedCard;

	private bool isInGame;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void SelectCard(UI_DraggableCard card)
	{
	}

	private void DeselectAllCards()
	{
	}

	private void Update()
	{
	}

	private void OnClickButton_CloseWindow()
	{
	}

	protected override void Start()
	{
	}

	private UI_DraggableCard CreateCard(TowerIngameData data)
	{
		return null;
	}

	public UI_Obj_CardSlot GetEmptyCardSlot()
	{
		return null;
	}

	public void OnCardStartDragCallback(UI_DraggableCard card)
	{
	}

	public void OnCardEndDragCallback(UI_DraggableCard card)
	{
	}

	public void OnCardClickCallback(UI_DraggableCard card)
	{
	}

	public void OnCardDropCallback(UI_DraggableCard card)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__24))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	public void Toggle(bool isOn)
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

	private void ResetSelection()
	{
	}

	public void RebuildCardNavigation()
	{
	}
}
