using System;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Button))]
	public class UI_BuyableButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		[Required(null)]
		private Button _button;

		[SerializeField]
		[Required(null)]
		private Image _icon;

		[SerializeField]
		[Required(null)]
		private TextMeshProUGUI _textMeshProUGUI;

		[SerializeField]
		[Required(null)]
		private TextMeshProUGUI _txtPrice;

		[SerializeField]
		private Color _priceRed;

		[SerializeField]
		[Required(null)]
		private Image _background;

		[SerializeField]
		private Sprite _selectedBackground;

		[SerializeField]
		private Sprite _normalBackground;

		[SerializeField]
		private LocalizedString _prestigeKey;

		private ToolTipsShower _toolTipsShower;

		private int _currentPrice = int.MinValue;

		private ValidationIcon _validationIcon;

		private FeatureIcon _featureIcon;

		public AbsBuyableItemSO AssignedBuyable { get; private set; }

		public bool Interactable
		{
			get
			{
				return _button.interactable;
			}
			set
			{
				_button.interactable = value;
				if (_featureIcon != null)
				{
					_featureIcon.Interactable = value;
				}
			}
		}

		public static event Action<AbsBuyableItemSO> BuyableButtonClicked;

		public static event Action<AbsBuyableItemSO> BuyableButtonHovered;

		public static event Action<AbsBuyableItemSO> BuyableButtonExited;

		private void Awake()
		{
			_toolTipsShower = GetComponent<ToolTipsShower>();
			BuyableButtonClicked += UI_BuyableButton_BuyableButtonClicked;
			if (_validationIcon == null)
			{
				_validationIcon = GetComponentInChildren<ValidationIcon>();
			}
			_featureIcon = GetComponentInChildren<FeatureIcon>();
		}

		private void OnDestroy()
		{
			BuyableButtonClicked -= UI_BuyableButton_BuyableButtonClicked;
		}

		private void UI_BuyableButton_BuyableButtonClicked(AbsBuyableItemSO obj)
		{
			RefreshData(obj);
		}

		public void AssignBuyable(AbsBuyableItemSO p_furniture)
		{
			AssignedBuyable = p_furniture;
			PrepareButton();
			PriceCheck(MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney());
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnButtonClicked);
			LocalizationSettings.SelectedLocaleChanged += OnChangedLocale;
			AbsMoneyHandlerBridge.MoneyAmountChanged += PriceCheck;
			RefreshData();
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
			LocalizationSettings.SelectedLocaleChanged -= OnChangedLocale;
			AbsMoneyHandlerBridge.MoneyAmountChanged -= PriceCheck;
			_background.sprite = _normalBackground;
		}

		public void RefreshData(AbsBuyableItemSO obj)
		{
			_background.sprite = ((obj == AssignedBuyable) ? _selectedBackground : _normalBackground);
			RefreshData();
		}

		private void RefreshData()
		{
			PriceCheck(MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney());
		}

		private void PriceCheck(int p_currentMoneyAmount)
		{
			if (!(AssignedBuyable == null))
			{
				bool flag = p_currentMoneyAmount < AssignedBuyable.PurchasePrice;
				if (AssignedBuyable.PurchasePrice != _currentPrice)
				{
					_txtPrice.SetText(MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetToMoneyStringFormat(AssignedBuyable.PurchasePrice));
				}
				_currentPrice = AssignedBuyable.PurchasePrice;
				_txtPrice.color = (flag ? _priceRed : Color.white);
			}
		}

		public void OnButtonClicked()
		{
			if (AssignedBuyable == null)
			{
				Debug.LogError("No Buyable assigned in: " + base.name);
			}
			else if (AssignedBuyable.GetValidationState != AbsLockableItemSO.ELockState.Locked && AssignedBuyable.GetValidationState != AbsLockableItemSO.ELockState.Removed)
			{
				if (MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable != AssignedBuyable)
				{
					UI_BuyableButton.BuyableButtonClicked?.Invoke(AssignedBuyable);
				}
				RefreshData();
			}
		}

		public void Select()
		{
			if (AssignedBuyable == null)
			{
				Debug.LogError("No Buyable assigned in: " + base.name);
			}
			else if (AssignedBuyable.GetValidationState != AbsLockableItemSO.ELockState.Locked && AssignedBuyable.GetValidationState != AbsLockableItemSO.ELockState.Removed)
			{
				UI_BuyableButton.BuyableButtonClicked?.Invoke(AssignedBuyable);
				RefreshData();
			}
		}

		private void PrepareButton()
		{
			if ((bool)AssignedBuyable && (bool)_icon)
			{
				_icon.enabled = false;
				if ((bool)AssignedBuyable.Icon)
				{
					_icon.sprite = AssignedBuyable.Icon;
					_icon.enabled = true;
					_textMeshProUGUI.enabled = false;
				}
				if (_validationIcon == null)
				{
					_validationIcon = GetComponentInChildren<ValidationIcon>();
				}
				_validationIcon?.SetIconState(AssignedBuyable);
				_textMeshProUGUI.text = AssignedBuyable.LocalizationItemSONameKey.GetLocalizedStringSafe();
				if (_toolTipsShower == null)
				{
					_toolTipsShower = GetComponent<ToolTipsShower>();
				}
				if (AssignedBuyable is AbsInfluentBuyableItemSO absInfluentBuyableItemSO)
				{
					_toolTipsShower.InsertedText = "<b>" + _prestigeKey.GetLocalizedStringSafe().ToUpper() + " : +" + absInfluentBuyableItemSO.PrestigeValue + "</b>\n\n";
				}
				_toolTipsShower.SetTootipsInfo(AssignedBuyable.LocalizationItemSONameKey, AssignedBuyable.LocalizationItemSODescKey);
			}
		}

		private void OnChangedLocale(Locale locale)
		{
			_textMeshProUGUI.text = AssignedBuyable.LocalizationItemSONameKey.GetLocalizedStringSafe();
			if (AssignedBuyable is AbsInfluentBuyableItemSO absInfluentBuyableItemSO)
			{
				_toolTipsShower.InsertedText = "<b>" + _prestigeKey.GetLocalizedStringSafe().ToUpper() + " : +" + absInfluentBuyableItemSO.PrestigeValue + "</b>\n\n";
			}
			_toolTipsShower.SetTootipsInfo(AssignedBuyable.LocalizationItemSONameKey, AssignedBuyable.LocalizationItemSODescKey);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UI_BuyableButton.BuyableButtonHovered?.Invoke(AssignedBuyable);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			UI_BuyableButton.BuyableButtonExited?.Invoke(AssignedBuyable);
		}
	}
}
