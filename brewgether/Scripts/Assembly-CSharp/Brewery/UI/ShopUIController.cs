using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Items;
using Brewery.Shop;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class ShopUIController : BaseBreweryUIController
	{
		[CompilerGenerated]
		private sealed class _003CCloseAfterDelay_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public ShopUIController _003C_003E4__this;

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
			public _003CCloseAfterDelay_003Ed__55(int _003C_003E1__state)
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

		private const string TemplatePath = "UI/Shop";

		private const string StylesheetPath = "UI/Brewery";

		private VisualElement shopRoot;

		private Label shopTitle;

		private Label shopDescription;

		private VisualElement shopkeeperPortrait;

		private Label playerBalanceLabel;

		private Label itemsCountLabel;

		private VisualElement itemsGrid;

		private VisualElement cartItemsContainer;

		private Label cartEmptyMessage;

		private Label cartTotalValue;

		private Label cartItemsCountLabel;

		private Button cartClearBtn;

		private Button cartPurchaseBtn;

		private VisualElement purchaseResultOverlay;

		private Label resultIcon;

		private Label resultTitle;

		private Label resultMessage;

		private Label resultItemsCount;

		private Label resultTotalSpent;

		private Button resultContinueBtn;

		private Label shopStatusLabel;

		private Button shopCloseBtn;

		private Button tabBuyBtn;

		private Button tabSellBtn;

		private Label sectionTitleLabel;

		private Label cartHeaderTitleLabel;

		private Label cartTotalLabel;

		private bool isSellMode;

		private readonly Dictionary<string, int> sellCart;

		private VisualElement resultItemIcon;

		private BaseShop activeShop;

		private readonly Dictionary<string, int> shoppingCart;

		private readonly Dictionary<string, VisualElement> cartItemElements;

		private readonly Dictionary<string, DailyStockInfo> dailyStockCache;

		private readonly Dictionary<string, VisualElement> itemCardElements;

		public static ShopUIController Instance { get; private set; }

		protected override void RegisterSingleton()
		{
		}

		protected override VisualElement GetContainer()
		{
			return null;
		}

		protected override void OnUIHiding()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void BuildUI()
		{
		}

		private void ClearPreviewData()
		{
		}

		private void ShowWithAnimation()
		{
		}

		private void HideWithAnimation()
		{
		}

		public void ShowShopUI(BaseShop shop)
		{
		}

		private void ClearDailyStockCache()
		{
		}

		public void UpdateDailyStockDisplay(DailyStockInfo[] stockInfo)
		{
		}

		private void UpdateCardStockLabel(VisualElement card, DailyStockInfo stockInfo)
		{
		}

		public void ForceCloseShop(string reason)
		{
		}

		[IteratorStateMachine(typeof(_003CCloseAfterDelay_003Ed__55))]
		private IEnumerator CloseAfterDelay(float delay)
		{
			return null;
		}

		private void UpdatePlayerBalance()
		{
		}

		private void GenerateItemCards()
		{
		}

		private VisualElement CreateItemCard(BreweryItem item)
		{
			return null;
		}

		private void RegisterButtonSounds(VisualElement element)
		{
		}

		private static string TruncateDescription(string text, int maxLength)
		{
			return null;
		}

		private void AddToCart(string itemId, int quantity)
		{
		}

		private void ChangeCartQuantity(string itemId, int delta)
		{
		}

		private void RemoveFromCart(string itemId)
		{
		}

		private void ClearCart()
		{
		}

		private void UpdateCartDisplay()
		{
		}

		private void UpdateShopCardBadges()
		{
		}

		private VisualElement CreateCartItemElement(BreweryItem item, int quantity)
		{
			return null;
		}

		private void UpdateCartTotal()
		{
		}

		private int CalculateCartTotal()
		{
			return 0;
		}

		private void OnPurchaseClicked()
		{
		}

		public void OnPurchaseSuccess(string message)
		{
		}

		public void OnPurchaseFailed(string message)
		{
		}

		private void ShowPurchaseResult(bool success, int itemCount, int totalSpent, string message)
		{
		}

		private void HidePurchaseResult()
		{
		}

		private static int GetSellPrice(BreweryItem item)
		{
			return 0;
		}

		private void SwitchToMode(bool sellMode)
		{
		}

		private void UpdateTabVisuals()
		{
		}

		private void GenerateSellItemCards()
		{
		}

		private VisualElement CreateSellItemCard(BreweryItem item, int totalAvailable)
		{
			return null;
		}

		private int GetTotalAvailable(string itemId)
		{
			return 0;
		}

		private void AddToSellCart(string itemId, int quantity)
		{
		}

		private void RemoveFromSellCart(string itemId)
		{
		}

		private void ChangeSellCartQuantity(string itemId, int delta)
		{
		}

		private void UpdateSellCartDisplay()
		{
		}

		private VisualElement CreateSellCartItemElement(BreweryItem item, int quantity, string itemId)
		{
			return null;
		}

		private void UpdateSellCartTotal()
		{
		}

		private void UpdateSellCardBadges()
		{
		}

		private void OnSellClicked()
		{
		}

		public void OnSellSuccess(string message)
		{
		}

		public void OnSellFailed(string message)
		{
		}

		private void ShowSellResult(bool success, int itemCount, int totalEarned, string message, Sprite itemIcon = null)
		{
		}

		private void SetStatusMessage(string message, bool isError, string cssClass = "")
		{
		}

		private void ClearStatusMessage()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
