using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_MarketStoreItem : NavBox, IActivable
	{
		[Header("UI Components")]
		[SerializeField]
		private NavButton m_button;

		[SerializeField]
		private List<UI_MarketStoreItemLockedChanges> m_lockedElementsList = new List<UI_MarketStoreItemLockedChanges>();

		[SerializeField]
		private GenericTooltipDisplayer m_lockedTooltipDisplayer;

		[Space(10f)]
		[SerializeField]
		protected Image m_itemImage;

		[SerializeField]
		protected SimulatorText m_nameText;

		[SerializeField]
		protected TextMeshProUGUI m_quantityText;

		[SerializeField]
		protected TextMeshProUGUI m_pricePerUnitText;

		[SerializeField]
		protected GameObject m_newIcon;

		[Space(10f)]
		[SerializeField]
		private NavButton m_buyButton;

		[SerializeField]
		protected TextMeshProUGUI m_priceText;

		[SerializeField]
		protected TextMeshProUGUI m_cartQuantityText;

		[Space(10f)]
		[SerializeField]
		protected NavButton m_unlockButton;

		[SerializeField]
		protected TextMeshProUGUI m_shopLevelToUnlockValueText;

		protected UI_MarketStore m_marketStore;

		private NavButton m_currentButton;

		public BaseShopBoxData Data { get; private set; }

		public bool DataIsExtension { get; private set; }

		public bool Locked { get; protected set; }

		public event Action<BaseShopBoxData> Unlocked;

		public event Action<BaseShopBoxData> AddedToCart;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_buyButton.Button.onClick.AddListener(OnButton_Buy);
			m_unlockButton.Button.onClick.AddListener(OnButton_Unlock);
			NavButton button = m_button;
			button.PointerEnterEvent = (Action)Delegate.Combine(button.PointerEnterEvent, new Action(OnPointerEnter));
			GameState.MoneyAmountChanged += OnMoneyAmountChanged;
			GameState.ShopLevelChanged += OnShopLevelChanged;
			PriceManager.LicenseUnlocked += OnLicenseUnlocked;
			ShopExtensionSystem.ShopExtensionBought += OnExtensionBought;
			ShopExtensionSystem.ReserveExtensionBought += OnExtensionBought;
			if (Data != null)
			{
				UpdateContent(Data);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_buyButton.Button.onClick.RemoveListener(OnButton_Buy);
			m_unlockButton.Button.onClick.RemoveListener(OnButton_Unlock);
			NavButton button = m_button;
			button.PointerEnterEvent = (Action)Delegate.Remove(button.PointerEnterEvent, new Action(OnPointerEnter));
			GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
			GameState.ShopLevelChanged -= OnShopLevelChanged;
			PriceManager.LicenseUnlocked -= OnLicenseUnlocked;
			ShopExtensionSystem.ShopExtensionBought -= OnExtensionBought;
			ShopExtensionSystem.ReserveExtensionBought -= OnExtensionBought;
		}

		void IActivable.SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public virtual void SetData(UI_MarketStore marketStore, BaseShopBoxData data)
		{
			((IActivable)this).SetActive(true);
			m_marketStore = marketStore;
			Data = data;
			DataIsExtension = data is ExtensionShopBoxData;
			UpdateContent(Data);
		}

		protected virtual void UpdateContent(BaseShopBoxData data)
		{
			Locked = IsDataLocked();
			foreach (UI_MarketStoreItemLockedChanges lockedElements in m_lockedElementsList)
			{
				lockedElements.ToggleLocked(Locked);
			}
			m_itemImage.sprite = data.Sprite;
			m_nameText.SetTerm(data.NameTerm);
			if ((bool)m_quantityText)
			{
				m_quantityText.text = data.Quantity.ToString();
			}
			if ((bool)m_cartQuantityText)
			{
				m_cartQuantityText.text = m_marketStore.GetCartDataCount(data).ToString();
			}
			if ((bool)m_pricePerUnitText)
			{
				m_pricePerUnitText.text = (GetDataPrice() / (float)data.Quantity).ToStringMoneyFormat();
			}
			if ((bool)m_buyButton)
			{
				m_buyButton.SetInteractable(IsBuyButtonInteractable());
			}
			if ((bool)m_unlockButton)
			{
				m_unlockButton.SetInteractable(IsUnlockButtonInteractable());
				if (!MarketStoreSettings.NeedToPayLicenses)
				{
					m_unlockButton.gameObject.SetActive(value: false);
				}
			}
			m_priceText.text = GetPriceToDisplay();
			if ((bool)m_shopLevelToUnlockValueText)
			{
				m_shopLevelToUnlockValueText.text = $"{MarketStore.GetRequiredShopLevel(data)}";
			}
			if (m_button.TryGetTooltipTerm(out var tooltipTerm))
			{
				m_button.SetTooltipTerm(data.TooltipTerm);
			}
			if (m_lockedTooltipDisplayer.TryGetTooltipTerm(out tooltipTerm))
			{
				m_lockedTooltipDisplayer.SetTerm(data.TooltipTerm);
			}
		}

		public void SetFirstButton()
		{
			NavButton buyButton = m_buyButton;
			buyButton.SelectElementEvent = (Action<RectTransform>)Delegate.Remove(buyButton.SelectElementEvent, new Action<RectTransform>(OnBuyButtonSelected));
			NavButton buyButton2 = m_buyButton;
			buyButton2.DeselectElementEvent = (Action)Delegate.Remove(buyButton2.DeselectElementEvent, new Action(OnBuyButtonDeselected));
			if (UINavElement.IsValidElement(m_buyButton) && IsBuyButtonInteractable())
			{
				NavButton buyButton3 = m_buyButton;
				buyButton3.SelectElementEvent = (Action<RectTransform>)Delegate.Combine(buyButton3.SelectElementEvent, new Action<RectTransform>(OnBuyButtonSelected));
				SetFirstElement(m_buyButton);
			}
			else if (UINavElement.IsValidElement(m_unlockButton) && IsUnlockButtonInteractable())
			{
				SetFirstElement(m_unlockButton);
			}
			else
			{
				SetFirstElement(m_button);
			}
		}

		private void OnBuyButtonSelected(RectTransform _)
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				m_button.AppendTooltip(m_button);
				NavButton buyButton = m_buyButton;
				buyButton.DeselectElementEvent = (Action)Delegate.Combine(buyButton.DeselectElementEvent, new Action(OnBuyButtonDeselected));
			}
		}

		private void OnBuyButtonDeselected()
		{
			m_button.CancelAllTooltips();
			NavButton buyButton = m_buyButton;
			buyButton.DeselectElementEvent = (Action)Delegate.Remove(buyButton.DeselectElementEvent, new Action(OnBuyButtonDeselected));
		}

		protected virtual void OnButton_Buy()
		{
			this.AddedToCart?.Invoke(Data);
			UpdateContent(Data);
		}

		protected virtual void OnButton_Unlock()
		{
			this.Unlocked?.Invoke(Data);
		}

		protected virtual void OnLicenseUnlocked(int productUID)
		{
			if (Data != null && productUID == Data.UID)
			{
				UpdateContent(Data);
				m_buyButton.Select();
			}
		}

		protected virtual void OnMoneyAmountChanged(float changedAmount)
		{
			bool flag = IsBuyButtonInteractable();
			m_buyButton.SetInteractable(flag);
			if ((bool)m_unlockButton)
			{
				m_unlockButton.SetInteractable(IsUnlockButtonInteractable());
			}
		}

		protected virtual void OnShopLevelChanged(int shopLevel)
		{
			if (Data != null)
			{
				UpdateContent(Data);
				SetFirstButton();
				if (shopLevel == Data.RequiredShopLevel)
				{
					m_newIcon.SetActive(value: true);
				}
			}
		}

		protected virtual void OnExtensionBought(int level)
		{
			if (Data != null)
			{
				UpdateContent(Data);
				SetFirstButton();
			}
		}

		private void OnPointerEnter()
		{
			m_newIcon.SetActive(value: false);
		}

		protected virtual bool IsDataLocked()
		{
			return MarketStore.IsDataLocked(Data);
		}

		protected virtual bool IsBuyButtonInteractable()
		{
			if (DataIsExtension && m_marketStore.DoesCartContains(Data))
			{
				return false;
			}
			if (GetDataPrice() <= GameState.MoneyAmount)
			{
				return !IsDataLocked();
			}
			return false;
		}

		protected virtual bool IsUnlockButtonInteractable()
		{
			if (GameState.ShopLevel >= MarketStore.GetRequiredShopLevel(Data))
			{
				return Data.LicensePrice <= GameState.MoneyAmount;
			}
			return false;
		}

		protected virtual string GetPriceToDisplay()
		{
			if (DataIsExtension)
			{
				return GetDataPrice().ToStringMoneyFormat();
			}
			return ((Locked && MarketStoreSettings.NeedToPayLicenses) ? Data.LicensePrice : GetDataPrice()).ToStringMoneyFormat();
		}

		protected float GetDataPrice()
		{
			return World.MarketStore.GetDataPrice(Data);
		}
	}
}
