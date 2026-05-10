using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Computer;
using __Project__.Scripts.ControllerInputModule;

public class MarketShoppingCart : MonoBehaviour
{
	[Serializable]
	public class ShippingCost
	{
		public Vector2Int ItemCount;

		public float ShippingPrice;
	}

	[CompilerGenerated]
	private sealed class _003CGamePadControl_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MarketShoppingCart _003C_003E4__this;

		public int index;

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
		public _003CGamePadControl_003Ed__82(int _003C_003E1__state)
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

	[Separator("Components", false)]
	[SerializeField]
	private CartItem m_CartItemPrefab;

	[SerializeField]
	private Transform m_ContentParent;

	[Separator("Shipping", false)]
	[SerializeField]
	private List<ShippingCost> m_ShippingCosts;

	[SerializeField]
	private int m_MaxItemCount;

	[Separator("UI", false)]
	[SerializeField]
	private GameObject m_CartWindow;

	[SerializeField]
	private TMP_Text[] m_OrderTotalTexts;

	[SerializeField]
	private TMP_Text CurrentShippingCostText;

	[SerializeField]
	private TMP_Text[] m_TotalPriceTexts;

	[SerializeField]
	private TMP_Text m_BalanceText;

	[SerializeField]
	private TMP_Text m_RemainingMoneyText;

	[SerializeField]
	private TMP_Text m_CartItemCountText;

	[SerializeField]
	private Button m_PurchaseButton;

	[SerializeField]
	private GameObject m_CartMaxedIndicator;

	[SerializeField]
	private GameObject m_ClosedMarketText;

	[Separator("Total Price Colors", false)]
	[SerializeField]
	private Color m_EnoughMoneyTextColor;

	[SerializeField]
	private Color m_NotEnoughMoneyTextColor;

	[Separator("Store Point", false)]
	[SerializeField]
	private int m_StorePointPerEachItemPurchased;

	[Separator("Latest Time For Customer Spawn", false)]
	[SerializeField]
	private int m_LatestTimeForOrdering;

	[SerializeField]
	private bool m_AM;

	[Header("Gamepad Handlers")]
	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	[SerializeField]
	private GamePadUIPanel m_gamePadUIPanel;

	[SerializeField]
	private WindowTab m_tab;

	private List<CartItem> m_CartItems;

	private float m_OrderTotalPrice;

	private bool m_MarketClosed;

	private Computer m_computerRef;

	private bool m_canPurchase;

	private NetworkMarketShoppingCart m_NetworkMarketShoppingCart;

	public Action onVeggieBought;

	public Action onScaleBought;

	public Action onStallBought;

	public bool EnableCartWindow
	{
		set
		{
		}
	}

	public float CurrentShippingCost => 0f;

	public int ExcessItemsCount => 0;

	public int ItemCountInCart => 0;

	public bool TooLateToOrderGoods => false;

	public bool CloseMarket
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public CartData CartData
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public NetworkMarketShoppingCart NetworkMarketShoppingCart => null;

	public bool CartMaxed(bool willBeAddedMore = false)
	{
		return false;
	}

	public bool CartMaxedPassive(bool willBeAddedMore = false)
	{
		return false;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Initialize()
	{
	}

	public bool TryAddProduct(ItemQuantity salesItem, SalesType salesType)
	{
		return false;
	}

	public void TryAddProductFailed()
	{
	}

	public int GetAllProductBoxCountInCart()
	{
		return 0;
	}

	public int GetAllFurnitureBoxCountInCart()
	{
		return 0;
	}

	public int GetAllFloorBoxCountInCart()
	{
		return 0;
	}

	public void UpdateTotalPrice()
	{
	}

	public bool GetHasMoneyForPurchase()
	{
		return false;
	}

	public float GetTotalPrice()
	{
		return 0f;
	}

	public void RemoveProduct(ItemQuantity productData, SalesType salesType)
	{
	}

	public void RemoveProductNetwork(ItemQuantity productData, SalesType salesType)
	{
	}

	public void Purchase(bool fromTablet)
	{
	}

	public void PurchaseNetwork(bool fromTablet)
	{
	}

	public void GamepadPurchase()
	{
	}

	public void OnItemCountChangedByButtons(int amount, int carItemIndex)
	{
	}

	public void OnItemCountChangedByButtonsNetwork(int amount, int carItemIndex)
	{
	}

	public void SetItemCountNetwork(int amount, int productID)
	{
	}

	public void AddProduct(ItemQuantity salesItem, SalesType salesType)
	{
	}

	public void AddProductNetwork(ItemQuantity salesItem, SalesType salesType)
	{
	}

	public void ReduceProduct(ItemQuantity salesItem, SalesType salesType)
	{
	}

	public void ReduceProductNetwork(ItemQuantity salesItem, SalesType salesType)
	{
	}

	public void ReGenerateCartUI()
	{
	}

	private void CleanCart()
	{
	}

	private void UpdateUI(bool hasMoney)
	{
	}

	private void UpdateBalance(float _amount, MoneyManager.TransitionType _type)
	{
	}

	private void UpdateAverageCosts()
	{
	}

	private void TimeCheck()
	{
	}

	private void OnDayCycleDisabled()
	{
	}

	private void OnCostsChanged(List<int> _)
	{
	}

	[IteratorStateMachine(typeof(_003CGamePadControl_003Ed__82))]
	private IEnumerator GamePadControl(int index = 0)
	{
		return null;
	}
}
