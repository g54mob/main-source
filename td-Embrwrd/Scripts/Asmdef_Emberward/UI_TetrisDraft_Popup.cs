using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_TetrisDraft_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_CloseWindowProc_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TetrisDraft_Popup _003C_003E4__this;

		private int _003Ccount_003E5__2;

		private List<UI_Obj_ShopCard>.Enumerator _003C_003E7__wrap2;

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
		public _003CCR_CloseWindowProc_003Ed__14(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowProc_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TetrisDraft_Popup _003C_003E4__this;

		private int _003CshowCardCount_003E5__2;

		private List<UI_Obj_ShopCard>.Enumerator _003C_003E7__wrap2;

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
		public _003CCR_ShowProc_003Ed__24(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private Button button_Random;

	[SerializeField]
	private Button button_Reset;

	[SerializeField]
	private List<Transform> list_TetrisCandidateAnchors;

	[SerializeField]
	private List<Transform> list_TetrisSelectedAnchors;

	[SerializeField]
	private List<UI_CardFace> list_RuneCards;

	[SerializeField]
	private GameObject prefab_UI_ShopCard;

	private List<UI_Obj_ShopCard> list_TetrisCandidateCards;

	private UI_Obj_ShopCard[] list_SelectedTetrisCards;

	private List<eItemType> list_StartingRunes;

	private bool isInAnimation;

	private Action<List<TetrisCardData>> OnTetrisDraftComplete;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CloseWindowProc_003Ed__14))]
	private IEnumerator CR_CloseWindowProc()
	{
		return null;
	}

	private void OnClickButton_OK()
	{
	}

	private void OnClickButton_Random()
	{
	}

	private UI_Obj_ShopCard GetRandomNotSelectedCard()
	{
		return null;
	}

	private void OnClickButton_Reset()
	{
	}

	private void UpdateOKButtonState()
	{
	}

	public void Setup(List<eItemType> list_TetrisCandidates, List<eItemType> list_StartingRunes = null, Action<List<TetrisCardData>> OnTetrisDraftComplete = null)
	{
	}

	private void OnCardClicked(UI_Obj_ShopCard card)
	{
	}

	private void SelectCard(UI_Obj_ShopCard card, int targetIndex)
	{
	}

	private void DeselectCard(UI_Obj_ShopCard card)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowProc_003Ed__24))]
	private IEnumerator CR_ShowProc()
	{
		return null;
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigation()
	{
	}
}
