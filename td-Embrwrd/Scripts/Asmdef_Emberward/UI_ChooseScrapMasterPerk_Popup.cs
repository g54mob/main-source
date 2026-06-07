using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChooseScrapMasterPerk_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_Hide_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_UI_ScrapMasterUpgradeCard card;

		public UI_ChooseScrapMasterPerk_Popup _003C_003E4__this;

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
		public _003CCR_Hide_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CCR_Show_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ChooseScrapMasterPerk_Popup _003C_003E4__this;

		private List<Obj_UI_ScrapMasterUpgradeCard>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_Show_003Ed__13(int _003C_003E1__state)
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
	private HorizontalLayoutGroup layoutGroup;

	[SerializeField]
	private GameObject prefab_UI_ScrapMasterCard;

	private float timeSinceWindowOpened;

	private List<Obj_UI_ScrapMasterUpgradeCard> list_CreatedCards;

	private bool isCardSelected;

	private eScrapMasterSkillType skillType;

	private Action<ScrapMasterCardData> OnCardSelected;

	public bool IsCardSelected => false;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void Update()
	{
	}

	public void Setup(List<ScrapMasterCardData> list_CardData, ScrapMasterSettingAssetData assetData, Action<ScrapMasterCardData> OnCardSelected)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Show_003Ed__13))]
	private IEnumerator CR_Show()
	{
		return null;
	}

	public void OnCardClicked(Obj_UI_ScrapMasterUpgradeCard card, ScrapMasterCardData cardData)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Hide_003Ed__15))]
	private IEnumerator CR_Hide(Obj_UI_ScrapMasterUpgradeCard card)
	{
		return null;
	}

	public void RegisterOnPerkSelected(Action<ScrapMasterCardData> action)
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
