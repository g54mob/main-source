using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.Multiplayer;

public class WholeSaleOfferCanvas : MonoBehaviour, IPopUp
{
	[CompilerGenerated]
	private sealed class _003CCheckGamepadFocus_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WholeSaleOfferCanvas _003C_003E4__this;

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
		public _003CCheckGamepadFocus_003Ed__48(int _003C_003E1__state)
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

	[Separator("Buy Section", false)]
	[SerializeField]
	private GameObject m_DiscountAmount;

	[SerializeField]
	private TextMeshProUGUI m_DiscountAmountText;

	[SerializeField]
	private GameObject m_OfferToBuy;

	[SerializeField]
	private LocalizeStringEvent m_OfferToBuyText;

	[SerializeField]
	private LocalizeStringEvent m_OfferQuestionText;

	[SerializeField]
	private LocalizedString m_OfferQuestionBuy;

	[SerializeField]
	private LocalizedString m_OfferQuestionSell;

	[Separator("Sell Section", false)]
	[SerializeField]
	private GameObject m_OfferToSell;

	[SerializeField]
	private LocalizeStringEvent m_OfferToSellText;

	[Separator("Stats Info", false)]
	[SerializeField]
	private LocalizeStringEvent m_StockCount;

	[SerializeField]
	private TextMeshProUGUI m_StockCountText;

	[SerializeField]
	private LocalizeStringEvent m_AvgCost;

	[SerializeField]
	private TextMeshProUGUI m_AvgCostText;

	[SerializeField]
	private LocalizeStringEvent m_SalesPrice;

	[SerializeField]
	private TextMeshProUGUI m_SalesPriceText;

	[SerializeField]
	private LocalizeStringEvent m_BoxMarketPrice;

	[SerializeField]
	private TextMeshProUGUI m_BoxMarketPriceText;

	[Separator("Offer Info", false)]
	[SerializeField]
	private TextMeshProUGUI m_OrderCount;

	[SerializeField]
	private GameObject m_BoxIconToBuy;

	[SerializeField]
	private GameObject m_PiecesIconToSell;

	[SerializeField]
	private Image m_ProductIcon;

	[Separator("Bottom", false)]
	[SerializeField]
	private Button m_DeclineButton;

	[SerializeField]
	private Button m_AcceptButton;

	[SerializeField]
	private TextMeshProUGUI m_AcceptButtonText;

	[SerializeField]
	private LocalizeStringEvent m_AcceptButtonLocText;

	[SerializeField]
	private LocalizedString m_DefaultAcceptText;

	[SerializeField]
	private Image m_AcceptHoldImage;

	[SerializeField]
	private Image m_DeclineHoldImage;

	[Separator("NetworkWholeSaleOfferCanvas", false)]
	[SerializeField]
	private NetworkWholeSaleOfferCanvas m_NetworkWholeSaleOfferCanvas;

	[Separator("General", false)]
	[SerializeField]
	private Color m_FailColor;

	[SerializeField]
	private Color m_OriginalAmountTextColor;

	[SerializeField]
	private TextMeshProUGUI m_AmountText;

	[SerializeField]
	private LocalizedString m_BuyAcceptFail;

	[SerializeField]
	private LocalizedString m_SellAcceptFail;

	[SerializeField]
	private GamePadUIPanel m_gamePadUIPanel;

	private bool m_CameraControllerEnabled;

	private bool m_MovementControllerEnabled;

	private bool m_isShowing;

	private Coroutine m_GamepadCheckRoutine;

	private float m_ConfirmHoldPercentage;

	private float m_CancelHoldPercentage;

	public bool Show
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void InitializeWholeSaleOfferCanvas(bool isBuyOffer, bool canAccept, int amount, string productName, float finalPrice, Sprite productIcon, float stockCount, float AvgCost, float BoxMarketPrice = -1f, float SalesPrice = -1f, float initialPrice = -1f)
	{
	}

	public void ResetWholeSaleOfferCanvas()
	{
	}

	private void ResetAcceptButton()
	{
	}

	private void SetCursor(bool isGamepad)
	{
	}

	[IteratorStateMachine(typeof(_003CCheckGamepadFocus_003Ed__48))]
	private IEnumerator CheckGamepadFocus()
	{
		return null;
	}

	public void OnConfirmHold()
	{
	}

	public void OnCancelHold()
	{
	}

	public void OnConfirmRelease()
	{
	}

	public void OnCancelRelease()
	{
	}

	public void VoteAccept()
	{
	}

	public void VoteDecline()
	{
	}

	public void ResetVotes()
	{
	}
}
