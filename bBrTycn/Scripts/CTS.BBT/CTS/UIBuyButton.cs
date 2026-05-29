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
	public class UIBuyButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private Button _button;

		[SerializeField]
		[Required(null)]
		private Image _image;

		[SerializeField]
		[Required(null)]
		private Image _unpurchasableImage;

		[SerializeField]
		[Required(null)]
		private Image _background;

		[SerializeField]
		[Required(null)]
		private TextMeshProUGUI _textMeshProUGUI;

		[SerializeField]
		[Required(null)]
		private TextMeshProUGUI _TxtPrice;

		[SerializeField]
		private Color _priceRed;

		[SerializeField]
		[Required(null)]
		private Sprite _unselectedImage;

		[SerializeField]
		[Required(null)]
		private Sprite _selectedImage;

		private ToolTipsShower _toolTipsShower;

		private int _currentPrice = int.MinValue;

		public SurfaceData AssignedData { get; private set; }

		public static event Action OnMouseExit;

		private void Awake()
		{
			_toolTipsShower = GetComponentInChildren<ToolTipsShower>();
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnButtonClicked);
			LocalizationItemSOEvent.InitProcessEnded += OnLocalizationInitEnded;
			LocalizationSettings.SelectedLocaleChanged += OnChangedLocale;
			MoneyHandler.MoneyAmountChanged += PriceCheck;
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
			LocalizationItemSOEvent.InitProcessEnded -= OnLocalizationInitEnded;
			LocalizationSettings.SelectedLocaleChanged -= OnChangedLocale;
			MoneyHandler.MoneyAmountChanged -= PriceCheck;
		}

		public void RefreshData()
		{
			PriceCheck(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
		}

		private void PriceCheck(int p_currentMoneyAmount)
		{
			if ((bool)AssignedData)
			{
				bool flag = p_currentMoneyAmount < AssignedData.PurchasePrice;
				if (AssignedData.PurchasePrice != _currentPrice)
				{
					_TxtPrice.SetText("$" + AssignedData.PurchasePrice);
				}
				_currentPrice = AssignedData.PurchasePrice;
				_TxtPrice.color = (flag ? _priceRed : Color.white);
				_unpurchasableImage.enabled = flag;
			}
		}

		private void OnChangedLocale(Locale locale)
		{
			_textMeshProUGUI.text = AssignedData.Name;
			_toolTipsShower.SetTootipsInfo(AssignedData.LocalizationItemSONameKey, AssignedData.LocalizationItemSODescKey);
		}

		private void OnLocalizationInitEnded()
		{
			_textMeshProUGUI.text = AssignedData.Name;
			_toolTipsShower.SetTootipsInfo(AssignedData.LocalizationItemSONameKey, AssignedData.LocalizationItemSODescKey);
		}

		private void OnButtonClicked()
		{
		}

		private void PrepareButton()
		{
			if ((bool)AssignedData && (bool)_image)
			{
				_image.enabled = false;
				if ((bool)AssignedData.Icon)
				{
					_image.sprite = AssignedData.Icon;
					_image.enabled = true;
					_textMeshProUGUI.enabled = false;
				}
				_textMeshProUGUI.text = AssignedData.Name;
				_toolTipsShower.SetTootipsInfo(AssignedData.LocalizationItemSONameKey, AssignedData.LocalizationItemSODescKey);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			UIBuyButton.OnMouseExit?.Invoke();
		}
	}
}
