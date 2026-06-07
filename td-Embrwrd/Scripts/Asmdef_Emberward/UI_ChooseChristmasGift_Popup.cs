using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_ChooseChristmasGift_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindow_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ChooseChristmasGift_Popup _003C_003E4__this;

		private List<Obj_UI_ChristmasGift>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_ShowWindow_003Ed__6(int _003C_003E1__state)
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
	private GameObject prefab_Gifts;

	[SerializeField]
	private Transform node_Layout_Gifts;

	private int createGiftCount;

	private List<Obj_UI_ChristmasGift> list_CreatedGifts;

	private bool isInitialized;

	private List<eCharacterType> list_CharacterTypeCandidates;

	[IteratorStateMachine(typeof(_003CCR_ShowWindow_003Ed__6))]
	private IEnumerator CR_ShowWindow()
	{
		return null;
	}

	private void OnClick_ChooseGift(eCharacterType characterType)
	{
	}

	private void GiveGiftToPlayer(eCharacterType characterType)
	{
	}

	private void GiveGift_Basic()
	{
	}

	private void GiveGift_Knight()
	{
	}

	private void GiveGift_Scholar()
	{
	}

	private void GiveGift_Merchant()
	{
	}

	private void GiveGift_Sorcerer()
	{
	}

	private void GiveGift_Chunk()
	{
	}

	private void GiveGift_Tiny()
	{
	}

	private void GiveGift_TimeMagician()
	{
	}

	private void GiveGift_ScrapMaster()
	{
	}

	private void GiveGift_Joker()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void Update()
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
