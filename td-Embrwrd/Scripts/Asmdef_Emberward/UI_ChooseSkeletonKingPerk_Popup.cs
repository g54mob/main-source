using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChooseSkeletonKingPerk_Popup : APopupWindow
{
	public enum ePerkType
	{
		BUFF_AND_DEBUFF = 0,
		DEBUFF_ONLY = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_Hide_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_UI_SkeletonKingCurseCard card;

		public UI_ChooseSkeletonKingPerk_Popup _003C_003E4__this;

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
		public _003CCR_Hide_003Ed__14(int _003C_003E1__state)
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
	private sealed class _003CCR_Show_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ChooseSkeletonKingPerk_Popup _003C_003E4__this;

		private List<Obj_UI_SkeletonKingCurseCard>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_Show_003Ed__12(int _003C_003E1__state)
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
	private TMP_Text text_Description;

	[SerializeField]
	private HorizontalLayoutGroup layoutGroup;

	[SerializeField]
	private GameObject prefab_UI_SkeletonKingCard_Normal;

	[SerializeField]
	private GameObject prefab_UI_SkeletonKingCard_Cursed;

	private List<Obj_UI_SkeletonKingCurseCard> list_CreatedCards;

	private bool isCardSelected;

	private float timeSinceWindowOpened;

	private Action<eItemType, eItemType> OnCardSelected;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void Update()
	{
	}

	public void Setup(int showInterval, ePerkType type, List<eItemType> perkList_Buff, List<eItemType> perkList_Debuff, List<eItemType> chosenBuff, List<eItemType> chosenDebuff)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Show_003Ed__12))]
	private IEnumerator CR_Show()
	{
		return null;
	}

	public void OnCardClicked(Obj_UI_SkeletonKingCurseCard card, PerkSettingData buffData, PerkSettingData debuffData)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Hide_003Ed__14))]
	private IEnumerator CR_Hide(Obj_UI_SkeletonKingCurseCard card)
	{
		return null;
	}

	public void RegisterOnPerkSelected(Action<eItemType, eItemType> action)
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
}
