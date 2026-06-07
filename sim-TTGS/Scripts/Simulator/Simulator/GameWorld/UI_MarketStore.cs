using System;
using System.Collections.Generic;
using System.Linq;
using Dhs5.Utility.Updates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_MarketStore : MonoBehaviour
	{
		[Header("Main Components")]
		[SerializeField]
		private ObjectStackActivator m_pageActivator;

		[Header("Browser")]
		[SerializeField]
		private GameObject m_browserPage;

		[Space(10f)]
		[SerializeField]
		private ObjectActivator m_browserActivator;

		[SerializeField]
		private List<UI_MarketStoreBrowser> m_browsers;

		[SerializeField]
		private List<Transform> m_itemContainers;

		[Header("Browser Toolbar")]
		[SerializeField]
		private NavButton m_cartButton;

		[SerializeField]
		private TextMeshProUGUI m_cartValueText;

		[SerializeField]
		private TextMeshProUGUI m_cartQuantityText;

		[Space(10f)]
		[SerializeField]
		private Toggle m_sortByShopLvlToggle;

		[SerializeField]
		private Toggle m_sortByNameToggle;

		[SerializeField]
		private Toggle m_sortByPriceToggle;

		[Space(10f)]
		[SerializeField]
		private UI_SearchBar m_searchBar;

		[Space(10f)]
		[SerializeField]
		private Toggle m_showLockedItemsToggle;

		[Space(10f)]
		[SerializeField]
		private ToggleGroup m_categoryToggleGroup;

		[SerializeField]
		private List<Toggle> m_categoryToggles;

		[Header("Cart")]
		[SerializeField]
		private NavBox m_cartPage;

		[SerializeField]
		private NavButton m_cartBackButton;

		[SerializeField]
		private RectTransform m_cartItemsContainer;

		[SerializeField]
		private TextMeshProUGUI m_cartToolbarMoney;

		[SerializeField]
		private TextMeshProUGUI m_cartToolbarTime;

		[SerializeField]
		private TextMeshProUGUI m_cartToolbarShopLevel;

		[SerializeField]
		private Image m_cartToolbarShopLevelBar;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_subTotalText;

		[SerializeField]
		private TextMeshProUGUI m_deliveryFeeText;

		[SerializeField]
		private TextMeshProUGUI m_totalText;

		[SerializeField]
		private NavButton m_payButton;

		[Header("Navigation")]
		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private NavBox m_navBoxFallback;

		[SerializeField]
		private NavBox m_navBoxCartContainer;

		[Header("Prefabs")]
		[SerializeField]
		private UI_MarketStoreItem m_browserItemPrefab;

		[SerializeField]
		private UI_MarketStoreCartItem m_cartItemPrefab;

		protected bool m_initialized;

		protected Dictionary<int, List<UI_MarketStoreItem>> m_browserItems = new Dictionary<int, List<UI_MarketStoreItem>>();

		protected Dictionary<BaseShopBoxData, int> m_cartContent = new Dictionary<BaseShopBoxData, int>();

		protected Dictionary<BaseShopBoxData, UI_MarketStoreCartItem> m_cartItems = new Dictionary<BaseShopBoxData, UI_MarketStoreCartItem>();

		protected EMarketStoreSortType m_sortType;

		protected string m_searchString;

		protected bool m_showLockedItems;

		private bool m_isControlled;

		public int CurrentlyOpenCategory { get; private set; } = -1;

		public BaseShopBoxData CurrentlyOpenProduct { get; private set; }

		public int CurrentBoxQuantity { get; private set; }

		public float CartValue { get; private set; }

		public float DeliveryFees { get; private set; }

		public NavBox NavBox => m_navBox;

		public bool CartPageActive => m_cartPage.gameObject.activeSelf;

		protected virtual void OnEnable()
		{
			if (!m_initialized)
			{
				OnInit();
				m_initialized = true;
			}
			RegisterBrowserToolbarButtons(register: true);
			RegisterCategoryToggles(register: true);
			RegisterCartButtons(register: true);
			GameState.MoneyAmountChanged += OnMoneyAmountChanged;
			EventManager.OnWorldEvent += OnWorldEvent;
			InputManager.DeviceChanged += OnDeviceChange;
			GameState.ShopLevelChanged += OnShopLevelChanged;
		}

		protected virtual void OnDisable()
		{
			RegisterBrowserToolbarButtons(register: false);
			RegisterCategoryToggles(register: false);
			RegisterCartButtons(register: false);
			GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
			EventManager.OnWorldEvent -= OnWorldEvent;
			InputManager.DeviceChanged -= OnDeviceChange;
			GameState.ShopLevelChanged -= OnShopLevelChanged;
		}

		private void OnShopLevelChanged(int level)
		{
			UpdateBrowsers();
			if (CartPageActive)
			{
				m_cartToolbarShopLevel.text = level.ToString();
			}
		}

		protected virtual void OnInit()
		{
			InitPages();
			OpenCategoryBrowser(0);
			OnCartValueChanged(0f);
			UpdateCartButtonInteractivity();
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.INITIALISATION:
				RegisterToMarketStore(register: true);
				break;
			case EWorldEvent.PREPARE_QUIT:
				RegisterToMarketStore(register: false);
				break;
			}
		}

		private void RegisterToMarketStore(bool register)
		{
			if (register)
			{
				World.MarketStore.Register(this);
			}
			else
			{
				World.MarketStore.Unregister(this);
			}
		}

		private void OnDeviceChange(EInputDeviceType type)
		{
			if (m_isControlled)
			{
				if (m_pageActivator.CurrentGameObject == m_cartPage.gameObject)
				{
					m_cartPage.OnDeviceChange(type);
				}
				else
				{
					m_navBox.OnDeviceChange(type);
				}
			}
		}

		protected virtual void RegisterBrowserToolbarButtons(bool register)
		{
			if (register)
			{
				m_cartButton.Button.onClick.AddListener(OpenCart);
				if ((bool)m_sortByShopLvlToggle)
				{
					m_sortByShopLvlToggle.onValueChanged.AddListener(OnSortByShopLevelToggleValueChanged);
				}
				if ((bool)m_sortByNameToggle)
				{
					m_sortByNameToggle.onValueChanged.AddListener(OnSortByNameToggleValueChanged);
				}
				if ((bool)m_sortByPriceToggle)
				{
					m_sortByPriceToggle.onValueChanged.AddListener(OnSortByPriceToggleValueChanged);
				}
				if ((bool)m_searchBar)
				{
					m_searchBar.AnyChange += OnSearchStringValueChanged;
					m_searchBar.Validate += OnValidateSearch;
				}
				if ((bool)m_showLockedItemsToggle)
				{
					m_showLockedItemsToggle.onValueChanged.AddListener(OnShowLockedItemsToggleValueChanged);
				}
			}
			else
			{
				m_cartButton.Button.onClick.RemoveListener(OpenCart);
				if ((bool)m_sortByShopLvlToggle)
				{
					m_sortByShopLvlToggle.onValueChanged.RemoveListener(OnSortByShopLevelToggleValueChanged);
				}
				if ((bool)m_sortByNameToggle)
				{
					m_sortByNameToggle.onValueChanged.RemoveListener(OnSortByNameToggleValueChanged);
				}
				if ((bool)m_sortByPriceToggle)
				{
					m_sortByPriceToggle.onValueChanged.RemoveListener(OnSortByPriceToggleValueChanged);
				}
				if ((bool)m_searchBar)
				{
					m_searchBar.AnyChange -= OnSearchStringValueChanged;
					m_searchBar.Validate -= OnValidateSearch;
				}
				if ((bool)m_showLockedItemsToggle)
				{
					m_showLockedItemsToggle.onValueChanged.RemoveListener(OnShowLockedItemsToggleValueChanged);
				}
			}
		}

		protected virtual void RegisterCategoryToggles(bool register)
		{
			if (register)
			{
				foreach (Toggle categoryToggle in m_categoryToggles)
				{
					categoryToggle.onValueChanged.AddListener(OnCategoryToggleValueChanged);
				}
				return;
			}
			foreach (Toggle categoryToggle2 in m_categoryToggles)
			{
				categoryToggle2.onValueChanged.RemoveListener(OnCategoryToggleValueChanged);
			}
		}

		private void RegisterCartButtons(bool register)
		{
			if (register)
			{
				m_payButton.Button.onClick.AddListener(OnCheckout);
				m_cartBackButton.Button.onClick.AddListener(CloseCart);
			}
			else
			{
				m_payButton.Button.onClick.RemoveListener(OnCheckout);
				m_cartBackButton.Button.onClick.RemoveListener(CloseCart);
			}
		}

		public void Init()
		{
			m_sortType = EMarketStoreSortType.SHOP_LEVEL_DOWN;
			m_showLockedItems = true;
			foreach (var (num2, list2) in World.MarketStore.GetMarketStoreDatas())
			{
				m_browserItems.Add(num2, new List<UI_MarketStoreItem>());
				list2.Sort(BrowserSortMethod);
				foreach (BaseShopBoxData item in list2)
				{
					if (DoesElementPassFilters(item))
					{
						InstantiateBrowserItem(item, num2);
					}
				}
			}
			SetCurrentBrowserNavigationNeighbours();
			m_browsers[CurrentlyOpenCategory].BrowserNavBox.SelectFirstChild();
		}

		private void SetCurrentBrowserNavigationNeighbours()
		{
			foreach (KeyValuePair<int, List<UI_MarketStoreItem>> browserItem in m_browserItems)
			{
				browserItem.Deconstruct(out var key, out var value);
				int index = key;
				List<UI_MarketStoreItem> list = value;
				int constraintCount = m_browsers[index].LayoutGroup.constraintCount;
				for (int i = 0; i < list.Count; i++)
				{
					int index2 = i - 1;
					int index3 = i + 1;
					int index4 = i - constraintCount;
					int index5 = i + constraintCount;
					UINavElement leftNeighbour = null;
					if (list.IsIndexValid(index2))
					{
						leftNeighbour = list[index2];
					}
					UINavElement rightNeighbour = null;
					if (list.IsIndexValid(index3))
					{
						rightNeighbour = list[index3];
					}
					UINavElement upNeighbour = null;
					if (list.IsIndexValid(index4))
					{
						upNeighbour = list[index4];
					}
					UINavElement downNeighbour = null;
					if (list.IsIndexValid(index5))
					{
						downNeighbour = list[index5];
					}
					UI_MarketStoreItem uI_MarketStoreItem = list[i];
					SimpleNavElementNeighbours neighbours = new SimpleNavElementNeighbours
					{
						LeftNeighbour = leftNeighbour,
						RightNeighbour = rightNeighbour,
						UpNeighbour = upNeighbour,
						DownNeighbour = downNeighbour
					};
					uI_MarketStoreItem.SetNeighbours(neighbours);
				}
			}
		}

		private void InitPages()
		{
			m_pageActivator.Init(m_browserPage);
		}

		private void OpenCart()
		{
			m_pageActivator.Activate(m_cartPage.gameObject);
			RefreshCartLayout();
			Updater.CallInXFrames(1, delegate
			{
				m_cartPage.SelectFirstChild();
			}, out var _);
			m_cartToolbarMoney.text = GameState.MoneyAmount.ToStringMoneyFormat();
			m_cartToolbarTime.text = World.TimeController.Time.ToString();
			m_cartToolbarShopLevelBar.fillAmount = Mathf.Clamp01(World.GameState.GetNormalizedShopXP());
			m_cartToolbarShopLevel.text = GameState.ShopLevel.ToString();
			TimeController.TimeChanged += OnTimeChanged;
			GameState.XPChanged += OnXPChanged;
		}

		public void CloseCart()
		{
			Back();
			TimeController.TimeChanged -= OnTimeChanged;
			GameState.XPChanged -= OnXPChanged;
		}

		private void Back()
		{
			m_pageActivator.Back();
			m_navBox.SetActive();
		}

		public void GoToBrowser()
		{
			Back();
			TimeController.TimeChanged -= OnTimeChanged;
			GameState.XPChanged -= OnXPChanged;
		}

		private void InstantiateBrowserItem(BaseShopBoxData data, int type)
		{
			UI_MarketStoreItem uI_MarketStoreItem = UnityEngine.Object.Instantiate(m_browserItemPrefab, m_itemContainers[type]);
			m_browserItems[type].Add(uI_MarketStoreItem);
			uI_MarketStoreItem.SetData(this, data);
			m_browsers[type].BrowserNavBox.AddChild(uI_MarketStoreItem);
			m_browsers[type].ScrollRect.AddElement(uI_MarketStoreItem);
			uI_MarketStoreItem.Unlocked += OnUnlockLicense;
			uI_MarketStoreItem.AddedToCart += OnAddToCart;
		}

		private UI_MarketStoreCartItem InstantiateCartItem(BaseShopBoxData data, int quantity)
		{
			UI_MarketStoreCartItem uI_MarketStoreCartItem = UnityEngine.Object.Instantiate(m_cartItemPrefab, m_cartItemsContainer);
			m_cartItems.Add(data, uI_MarketStoreCartItem);
			uI_MarketStoreCartItem.SetData(data);
			uI_MarketStoreCartItem.UpdateQuantity(quantity);
			uI_MarketStoreCartItem.RemovedUnit += OnRemoveUnitFromCart;
			uI_MarketStoreCartItem.AddedUnit += OnAddToCart;
			uI_MarketStoreCartItem.RemovedProduct += OnRemoveProductFromCart;
			return uI_MarketStoreCartItem;
		}

		private async void OpenCategoryBrowser(int type)
		{
			if (CurrentlyOpenCategory == type)
			{
				return;
			}
			CurrentlyOpenCategory = type;
			UI_MarketStoreBrowser browser = m_browsers[CurrentlyOpenCategory];
			m_browserActivator.Activate(browser.gameObject);
			await Awaitable.NextFrameAsync();
			List<UI_MarketStoreItem> list = m_browserItems[CurrentlyOpenCategory];
			if (list.IsValid() && list[0].gameObject.activeSelf)
			{
				foreach (UI_MarketStoreItem item in list)
				{
					item.SetFirstButton();
				}
				browser.BrowserNavBox.SelectFirstChild();
			}
			else
			{
				UINavElement deepestCurrentElement = m_navBox.GetDeepestCurrentElement();
				if (deepestCurrentElement == null || !UINavElement.IsValidElement(deepestCurrentElement))
				{
					m_navBoxFallback.SelectFirstChild();
				}
				else
				{
					m_navBox.ResumeSelection();
				}
			}
		}

		protected virtual void UpdateBrowsers()
		{
			if (!World.MarketStore.Initialized)
			{
				return;
			}
			foreach (var (type, datas) in World.MarketStore.GetMarketStoreDatas())
			{
				UpdateBrowser(type, datas);
			}
		}

		protected virtual void UpdateBrowser(int type, List<BaseShopBoxData> datas)
		{
			datas = datas.Where((BaseShopBoxData d) => DoesElementPassFilters(d)).ToList();
			datas.Sort(BrowserSortMethod);
			List<UI_MarketStoreItem> list = m_browserItems[type];
			for (int num = 0; num < list.Count; num++)
			{
				if (num < datas.Count)
				{
					list[num].SetData(this, datas[num]);
				}
				else
				{
					((IActivable)list[num]).SetActive(false);
				}
			}
			m_browsers[type].ScrollRect.RefreshScrollView();
		}

		protected virtual bool DoesElementPassFilters(BaseShopBoxData item)
		{
			if (!MarketStore.IsDataAvailable(item))
			{
				return false;
			}
			if (!m_showLockedItems && MarketStore.IsDataLocked(item))
			{
				return false;
			}
			if (!string.IsNullOrWhiteSpace(m_searchString))
			{
				return item.name.Contains(m_searchString, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		protected virtual int BrowserSortMethod(BaseShopBoxData i1, BaseShopBoxData i2)
		{
			return m_sortType switch
			{
				EMarketStoreSortType.SHOP_LEVEL_DOWN => MarketStore.GetRequiredShopLevel(i1).CompareTo(MarketStore.GetRequiredShopLevel(i2)), 
				EMarketStoreSortType.SHOP_LEVEL_UP => -MarketStore.GetRequiredShopLevel(i1).CompareTo(MarketStore.GetRequiredShopLevel(i2)), 
				EMarketStoreSortType.NAME_DOWN => i1.name.CompareTo(i2.name), 
				EMarketStoreSortType.NAME_UP => -i1.name.CompareTo(i2.name), 
				EMarketStoreSortType.PRICE_DOWN => i1.Price.CompareTo(i2.Price), 
				EMarketStoreSortType.PRICE_UP => -i1.Price.CompareTo(i2.Price), 
				_ => throw new NotImplementedException(), 
			};
		}

		private void IncreaseBoxQuantity()
		{
			CurrentBoxQuantity++;
		}

		private void DecreaseBoxQuantity()
		{
			if (CurrentBoxQuantity > 1)
			{
				CurrentBoxQuantity--;
			}
		}

		private void OnAddToCart(BaseShopBoxData data)
		{
			OnAddToCart(data, 1);
		}

		private void OnAddToCart(BaseShopBoxData data, int quantity)
		{
			if (m_cartContent.ContainsKey(data))
			{
				m_cartContent[data] += quantity;
			}
			else
			{
				m_cartContent[data] = quantity;
			}
			UpdateCartButtonInteractivity();
			UpdateCartContent();
			RefreshCartLayout();
		}

		private void RefreshCartQuantity()
		{
			int num = 0;
			foreach (KeyValuePair<BaseShopBoxData, int> item in m_cartContent)
			{
				item.Deconstruct(out var _, out var value);
				int num2 = value;
				num += num2;
			}
			m_cartQuantityText.text = num.ToString();
		}

		private void OnRemoveUnitFromCart(BaseShopBoxData data)
		{
			if (m_cartContent.TryGetValue(data, out var value) && value > 1)
			{
				m_cartContent[data]--;
				UpdateCartContent();
				RefreshCartLayout();
				RefreshCartQuantity();
			}
			else
			{
				OnRemoveProductFromCart(data);
			}
		}

		private void OnRemoveProductFromCart(BaseShopBoxData data)
		{
			m_cartContent.Remove(data);
			m_navBoxCartContainer.RemoveChild(m_cartItems[data]);
			if (m_cartItems.Remove(data, out var value))
			{
				UnityEngine.Object.Destroy(value.gameObject);
			}
			UpdateCartButtonInteractivity();
			UpdateCartContent();
			RefreshCartLayout();
			if (m_cartItems.Count <= 0)
			{
				m_navBox.NavigateTo(m_cartBackButton);
			}
		}

		private void UpdateCartButtonInteractivity()
		{
			m_cartButton.SetInteractable(m_cartContent.Count > 0);
			RefreshCartQuantity();
		}

		private void UpdateCartContent()
		{
			float num = 0f;
			foreach (KeyValuePair<BaseShopBoxData, int> item in m_cartContent)
			{
				item.Deconstruct(out var key, out var value);
				BaseShopBoxData baseShopBoxData = key;
				int num2 = value;
				num += (float)num2 * World.MarketStore.GetDataPrice(baseShopBoxData);
				if (m_cartItems.TryGetValue(baseShopBoxData, out var value2))
				{
					value2.UpdateQuantity(num2);
					continue;
				}
				UI_MarketStoreCartItem child = InstantiateCartItem(baseShopBoxData, num2);
				m_navBoxCartContainer.AddChild(child);
			}
			SetCurrentCartNavigationNeighbours();
			if (num != CartValue)
			{
				OnCartValueChanged(num);
			}
		}

		private void SetCurrentCartNavigationNeighbours()
		{
			List<UINavElement> list = new List<UINavElement>();
			Transform transform = m_cartItemsContainer.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				if (transform.GetChild(i).TryGetComponent<UI_MarketStoreCartItem>(out var component))
				{
					list.Add(component);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				int index = j - 1;
				int index2 = j + 1;
				UINavElement upNeighbour = null;
				if (list.IsIndexValid(index))
				{
					upNeighbour = list[index];
				}
				UINavElement downNeighbour = null;
				if (list.IsIndexValid(index2))
				{
					downNeighbour = list[index2];
				}
				list[j].SetNeighbours(new SimpleNavElementNeighbours
				{
					DownNeighbour = downNeighbour,
					UpNeighbour = upNeighbour
				});
			}
		}

		private void ClearCart()
		{
			foreach (KeyValuePair<BaseShopBoxData, UI_MarketStoreCartItem> cartItem in m_cartItems)
			{
				cartItem.Deconstruct(out var _, out var value);
				UnityEngine.Object.Destroy(value.gameObject);
			}
			m_cartItems.Clear();
			m_cartContent.Clear();
			m_navBoxCartContainer.ClearAllElements();
			OnCartValueChanged(0f);
			UpdateCartButtonInteractivity();
		}

		private void RefreshCartLayout()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_cartItemsContainer);
		}

		protected virtual void OnCategoryToggleValueChanged(bool on)
		{
			if (!on)
			{
				return;
			}
			Toggle firstActiveToggle = m_categoryToggleGroup.GetFirstActiveToggle();
			for (int i = 0; i < m_categoryToggles.Count; i++)
			{
				if (firstActiveToggle == m_categoryToggles[i])
				{
					OpenCategoryBrowser(i);
				}
			}
		}

		protected virtual void OnSortByShopLevelToggleValueChanged(bool on)
		{
			if (on)
			{
				m_sortType = ((m_sortType == EMarketStoreSortType.SHOP_LEVEL_DOWN) ? EMarketStoreSortType.SHOP_LEVEL_UP : EMarketStoreSortType.SHOP_LEVEL_DOWN);
				UpdateBrowsers();
			}
		}

		protected virtual void OnSortByNameToggleValueChanged(bool on)
		{
			if (on)
			{
				m_sortType = ((m_sortType == EMarketStoreSortType.NAME_DOWN) ? EMarketStoreSortType.NAME_UP : EMarketStoreSortType.NAME_DOWN);
				UpdateBrowsers();
			}
		}

		protected virtual void OnSortByPriceToggleValueChanged(bool on)
		{
			if (on)
			{
				m_sortType = ((m_sortType == EMarketStoreSortType.PRICE_DOWN) ? EMarketStoreSortType.PRICE_UP : EMarketStoreSortType.PRICE_DOWN);
				UpdateBrowsers();
			}
		}

		protected virtual void OnSearchStringValueChanged(string content)
		{
			m_searchString = content;
		}

		protected virtual void OnValidateSearch()
		{
			UpdateBrowsers();
		}

		protected virtual void OnShowLockedItemsToggleValueChanged(bool on)
		{
			m_showLockedItems = on;
			UpdateBrowsers();
		}

		private void OnUnlockLicense(BaseShopBoxData data)
		{
			World.MarketStore.BuyLicense(data);
		}

		private void OnButtonAddToCart()
		{
			OnAddToCart(CurrentlyOpenProduct, CurrentBoxQuantity);
			CurrentlyOpenProduct = null;
			m_pageActivator.Back();
		}

		private void OnCartValueChanged(float value)
		{
			CartValue = value;
			ComputeDeliveryFees();
			m_cartValueText.text = value.ToStringMoneyFormat();
			m_subTotalText.text = value.ToStringMoneyFormat();
			m_deliveryFeeText.text = DeliveryFees.ToStringMoneyFormat();
			m_totalText.text = (value + DeliveryFees).ToStringMoneyFormat();
			UpdatePayButtonInteractivity();
		}

		private void ComputeDeliveryFees()
		{
			int num = 0;
			foreach (KeyValuePair<BaseShopBoxData, int> item in m_cartContent)
			{
				item.Deconstruct(out var _, out var value);
				int num2 = value;
				num += num2;
			}
			DeliveryFees = MarketStoreSettings.ComputeDeliveryFees(num);
		}

		private void OnCheckout()
		{
			if (World.MarketStore.Checkout(m_cartContent))
			{
				ClearCart();
				Tutorial.TryShow(World.MarketStore.SellTutorialData, Back);
			}
		}

		private bool CanPay()
		{
			if (CartValue > 0f)
			{
				return CartValue + DeliveryFees <= GameState.MoneyAmount;
			}
			return false;
		}

		private void UpdatePayButtonInteractivity()
		{
			m_payButton.SetInteractable(CanPay());
		}

		protected virtual void OnMoneyAmountChanged(float amount)
		{
			UpdatePayButtonInteractivity();
			if (CartPageActive)
			{
				m_cartToolbarMoney.text = GameState.MoneyAmount.ToStringMoneyFormat();
			}
		}

		private void OnTimeChanged(DayTime time)
		{
			m_cartToolbarTime.text = time.ToString();
		}

		private void OnXPChanged(int type, float normalizedXP)
		{
			if (type == 0)
			{
				m_cartToolbarShopLevelBar.fillAmount = Mathf.Clamp01(normalizedXP);
			}
		}

		public void OnControlled()
		{
			m_isControlled = true;
			m_navBox.SetActive();
			UI_MarketStoreBrowser uI_MarketStoreBrowser = m_browsers[CurrentlyOpenCategory];
			if (uI_MarketStoreBrowser != null)
			{
				uI_MarketStoreBrowser.BrowserNavBox.SelectFirstChild();
			}
		}

		public void OnUncontrolled()
		{
			m_navBox.SetInactive();
			m_isControlled = false;
		}

		public bool DoesCartContains(BaseShopBoxData data)
		{
			return m_cartContent.ContainsKey(data);
		}

		public int GetCartDataCount(BaseShopBoxData data)
		{
			if (DoesCartContains(data))
			{
				return m_cartContent[data];
			}
			return 0;
		}
	}
}
