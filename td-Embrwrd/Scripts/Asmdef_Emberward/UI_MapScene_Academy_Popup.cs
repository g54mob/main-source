using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_MapScene_Academy_Popup : APopupWindow
{
	public enum eState
	{
		SELECT_CARDSET = 0,
		SELECT_RELIC = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_CardSetClickedProc_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Academy_Popup _003C_003E4__this;

		public int index;

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
		public _003CCR_CardSetClickedProc_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CCR_Reroll_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Academy_Popup _003C_003E4__this;

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
		public _003CCR_Reroll_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003CCR_RerollRelics_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Academy_Popup _003C_003E4__this;

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
		public _003CCR_RerollRelics_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003CCR_SelectRelicProc_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Academy_Popup _003C_003E4__this;

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
		public _003CCR_SelectRelicProc_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowWindowProc_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Academy_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__49(int _003C_003E1__state)
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

	[Header("標題文字")]
	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_NPCDialog;

	[Header("Reroll按鈕")]
	[SerializeField]
	private UI_Button_AcademyReroll button_RerollAll;

	[SerializeField]
	private UI_MapScene_PlayerAcademyRerollCount ui_PlayerAcademyRerollCount;

	[Header("卡片產生的Parent node")]
	[SerializeField]
	private Transform node_Cards;

	[Header("卡片顯示動畫的interval")]
	[SerializeField]
	private float showCardInterval;

	[Header("卡片顯示動畫的interval")]
	[SerializeField]
	private float showRelicInterval;

	[SerializeField]
	private List<UI_Obj_AcademyCardSet> list_CardSet;

	[SerializeField]
	private List<Transform> list_RelicCardAnchors;

	[SerializeField]
	private List<Transform> list_RelicCardAnchors_FirstPage;

	[SerializeField]
	private Transform node_SelectedCardSet;

	[Header("已產生的卡片")]
	[SerializeField]
	private List<UI_Obj_ShopCard> list_CreatedItemCards;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_CreatedRelicCards;

	private List<AcademyCardSetData> list_CardSetData;

	private bool isSelected;

	private bool isCardSetSelected;

	private bool isRelicSelected;

	private int selectedRelicIndex;

	private bool isInAnimation;

	private bool isRerolling;

	private eState state;

	[SerializeField]
	private bool isRerollUnlocked;

	[SerializeField]
	private bool isInfiniteRerollUnlocked;

	private float joystickMoveCooldown;

	private AcademyCardSetData selectedCardSetData;

	private UI_Obj_AcademyCardSet selectedCardSet;

	private UI_Obj_ShopCard curSelectedCard;

	public eState State => default(eState);

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnRerollButtonClickedCallback()
	{
	}

	public void RerollAll()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Reroll_003Ed__34))]
	private IEnumerator CR_Reroll()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_RerollRelics_003Ed__35))]
	private IEnumerator CR_RerollRelics()
	{
		return null;
	}

	private void GetNewRelicSet()
	{
	}

	private void OnRequestAcademyCardSetReroll(int index)
	{
	}

	public void SetupContent(List<AcademyCardSetData> list_CardSetData)
	{
	}

	private void SetupDataset(int index, AcademyCardSetData cardSetData, UI_Obj_AcademyCardSet targetCardset)
	{
	}

	private UI_Obj_ShopCard CreateCard(CardData cardData, Vector3 scale)
	{
		return null;
	}

	private void OnCardSetClickedCallback(int index)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CardSetClickedProc_003Ed__42))]
	private IEnumerator CR_CardSetClickedProc(int index)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_SelectRelicProc_003Ed__43))]
	private IEnumerator CR_SelectRelicProc()
	{
		return null;
	}

	private void OnRelicCardClickedCallback(UI_Obj_ShopCard card)
	{
	}

	private void OnCardMouseEnterCallback(UI_Obj_ShopCard card)
	{
	}

	private void OnCardMouseExitCallback(UI_Obj_ShopCard card)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__49))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	private void ClearContent()
	{
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

	private void SetSelectedCard(UI_Obj_ShopCard card)
	{
	}

	private bool SelectNodeByInputAxisDirection(List<UI_Obj_ShopCard> list_SelectableCards)
	{
		return false;
	}

	private UI_Obj_ShopCard GetNodeByInputAxisDirection(List<UI_Obj_ShopCard> list_Candidates)
	{
		return null;
	}
}
