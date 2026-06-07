using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_AddRuneToTetrisCard_Popup : APopupWindow
{
	public enum eDecorationType
	{
		BLUE = 0,
		RED = 1
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public bool isTutorialFinished;

		public UI_AddRuneToTetrisCard_Popup _003C_003E4__this;

		internal void _003CCR_Proc_003Eb__0()
		{
		}

		internal void _003CCR_Proc_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_AddRuneToTetrisCard_Popup _003C_003E4__this;

		private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

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
		public _003CCR_Proc_003Ed__26(int _003C_003E1__state)
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
	private UI_Obj_ShopCard tetrisCard;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_RuneCards;

	[SerializeField]
	private Transform node_RuneCards;

	[SerializeField]
	private ParticleSystem particle_AttachRune;

	[SerializeField]
	private ParticleSystem particle_BGParticle;

	[SerializeField]
	private Transform node_BackpackButton;

	[SerializeField]
	private UI_Button_ShowPlayerDeck button_ShowPlayerDeck;

	[SerializeField]
	private UI_Button_ShowTowerArrangePage button_ShowTowerArrangePage;

	[SerializeField]
	private GameObject node_Deco_Blue;

	[SerializeField]
	private GameObject node_Deco_Red;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private UI_RelicList ui_RelicList;

	private List<UI_Obj_ShopCard> list_SelectedRuneCard;

	private CardData initialCardData;

	private Action<TetrisCardData> OnCardCompleted;

	private int targetRuneCount;

	private int selectableRuneCount;

	private int selectedRune;

	private bool isShowRuneCompleted;

	private Action OnSelectRuneFinish;

	private float joystickMoveCooldown;

	private UI_Obj_ShopCard curSelectedCard;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void Setup(TetrisCardData initialCardData, int targetRuneCount, int selectableRuneCount, string title = "", Action OnSelectRuneFinish = null)
	{
	}

	public void SwitchDecoration(eDecorationType type)
	{
	}

	private void OnRuneCardClicked(UI_Obj_ShopCard card)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__26))]
	private IEnumerator CR_Proc()
	{
		return null;
	}

	public override void OnWindowLostFocus()
	{
	}

	private void Update()
	{
	}

	public override void OnWindowRegainFocus()
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

	private void SetSelectedCard(UI_Obj_ShopCard card)
	{
	}

	private bool SelectNodeByInputAxisDirection()
	{
		return false;
	}

	private UI_Obj_ShopCard GetNodeByInputAxisDirection(List<UI_Obj_ShopCard> list_Candidates)
	{
		return null;
	}
}
