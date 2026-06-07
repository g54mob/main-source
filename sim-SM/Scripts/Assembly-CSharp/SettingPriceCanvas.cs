using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class SettingPriceCanvas : NoktaSingletonPunCallbacks<SettingPriceCanvas>, IPopUp
{
	[CompilerGenerated]
	private sealed class _003CDelayedEnableInput_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SettingPriceCanvas _003C_003E4__this;

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
		public _003CDelayedEnableInput_003Ed__31(int _003C_003E1__state)
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
	private PricingInteraction m_PricingInteractionSingle;

	[SerializeField]
	private GameObject m_Menu;

	[Separator("UI", false)]
	[SerializeField]
	private Image m_ProductIcon;

	[SerializeField]
	private TMP_Text m_ProductName;

	[SerializeField]
	private TMP_Text m_AvgCostText;

	[SerializeField]
	private LocalizeStringEvent m_MarketPrice;

	[SerializeField]
	private TMP_Text m_MarketPriceText;

	[SerializeField]
	private TMP_Text m_ProfitText;

	[SerializeField]
	private Color m_ProfitColor;

	[SerializeField]
	private Color m_LossColor;

	[SerializeField]
	private TMP_InputField m_PriceInput;

	[SerializeField]
	private Slider m_DiscountSlider;

	[SerializeField]
	private TMP_Text m_DiscountText;

	[SerializeField]
	private TMP_Text m_DiscountedPriceText;

	[SerializeField]
	private NumpadSystem m_gamepadNumpadSystem;

	private PriceTag m_CurrentPriceTag;

	private Pricing m_pricingData;

	private int m_CurrentProductID;

	private bool m_enabled;

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

	private void SetCursor(bool isGamepad)
	{
	}

	private void Start()
	{
	}

	public void OpenMenu(PriceTag priceTag)
	{
	}

	private void OnSliderChanged(float value)
	{
	}

	private void ApplyDiscount(int value)
	{
	}

	public void CloseMenu()
	{
	}

	public void ForceCloseMenu(PlayerInstance playerInstance)
	{
	}

	public void SetPrice_Broadcast(int productID, float price, int discountRate, int saleIndex)
	{
	}

	[PunRPC]
	public void SetPrice_RPC(int productID, float price, int discountRate, int saleIndex)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedEnableInput_003Ed__31))]
	private IEnumerator DelayedEnableInput()
	{
		return null;
	}

	private void SwitchNumpad(bool isGamepad)
	{
	}

	private void SetPrice(string input)
	{
	}

	public void SetPriceGamepad()
	{
	}

	public void SetDiscountGamepad(bool increase)
	{
	}

	private void UpdateProfit(float newPrice = -1f)
	{
	}
}
