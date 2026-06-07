using System;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.Furnitures;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS.BBT
{
	public class UIFurnitureButton : CTSBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IGive<TechTreeTechnologySO>
	{
		[SerializeField]
		[Required(null)]
		private Toggle _button;

		[SerializeField]
		[Required(null)]
		private Image _image;

		[SerializeField]
		private Image _outlineImage;

		[SerializeField]
		private Image _unpurchasableImage;

		[SerializeField]
		[Required(null)]
		private TextMeshProUGUI _textMeshProUGUI;

		[SerializeField]
		[Required(null)]
		private TextMeshProUGUI _TxtPrice;

		[SerializeField]
		private Color _priceRed;

		[SerializeField]
		private LocalizedString _prestigeKey;

		[SerializeField]
		private Image _bgImage;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private ValidationIcon _validationIcon;

		[Inject(false)]
		private ToolTipsShower _toolTipsShower;

		private int _currentPrice = int.MinValue;

		public FurnitureSO AssignedFurniture { get; private set; }

		public static event Action<FurnitureSO> FurnitureButtonHovered;

		public static event Action<FurnitureSO> FurnitureButtonExited;

		protected override void OnAwake()
		{
			base.OnAwake();
			LocalizationItemSOEvent.InitProcessEnded += OnLocalizationInitEnded;
		}

		public void AssignFurniture(FurnitureSO p_furniture)
		{
			AssignedFurniture = p_furniture;
			PrepareButton();
			PriceCheck(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
		}

		protected override void OnEnabled()
		{
			_button.onValueChanged.AddListener(OnToggleChanged);
			LocalizationSettings.SelectedLocaleChanged += OnChangedLocale;
			MoneyHandler.MoneyAmountChanged += PriceCheck;
		}

		protected override void OnDisabled()
		{
			_button.onValueChanged.RemoveListener(OnToggleChanged);
			LocalizationSettings.SelectedLocaleChanged -= OnChangedLocale;
			MoneyHandler.MoneyAmountChanged -= PriceCheck;
		}

		private void OnDestroy()
		{
			LocalizationItemSOEvent.InitProcessEnded -= OnLocalizationInitEnded;
		}

		public void RefreshData()
		{
			PriceCheck(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
			if (_button.isOn)
			{
				Furniture currentPickedUpFurniture = MonoSingleton<FurniturePlacer>.Instance.CurrentPickedUpFurniture;
				if (!currentPickedUpFurniture || currentPickedUpFurniture.Purchased || currentPickedUpFurniture.Parameters != AssignedFurniture)
				{
					_button.isOn = false;
				}
			}
		}

		private void PriceCheck(int p_currentMoneyAmount)
		{
			bool flag = p_currentMoneyAmount < AssignedFurniture.PurchasePrice;
			if (AssignedFurniture.PurchasePrice != _currentPrice)
			{
				_TxtPrice.SetText(MoneyHandler.GetToMoneyStringFormat(AssignedFurniture.PurchasePrice));
			}
			_currentPrice = AssignedFurniture.PurchasePrice;
			_image.color = (flag ? new Color(_image.color.r, _image.color.g, _image.color.b, 0.3f) : new Color(_image.color.r, _image.color.g, _image.color.b, 1f));
			_bgImage.enabled = !flag;
			_outlineImage.enabled = !flag;
			_button.interactable = !flag;
		}

		private void OnChangedLocale(Locale locale)
		{
			_textMeshProUGUI.text = AssignedFurniture.Name;
			_toolTipsShower.InsertedText = "<b>" + _prestigeKey.GetLocalizedStringSafe().ToUpper() + " : +" + AssignedFurniture.PrestigeValue + "</b>\n\n";
			_toolTipsShower.SetTootipsInfo(AssignedFurniture.LocalizationItemSONameKey, AssignedFurniture.LocalizationItemSODescKey);
		}

		private void OnLocalizationInitEnded()
		{
			_textMeshProUGUI.text = AssignedFurniture.Name;
			_toolTipsShower.InsertedText = "<b>" + _prestigeKey.GetLocalizedStringSafe().ToUpper() + " : +" + AssignedFurniture.PrestigeValue + "</b>\n\n";
			_toolTipsShower.SetTootipsInfo(AssignedFurniture.LocalizationItemSONameKey, AssignedFurniture.LocalizationItemSODescKey);
		}

		private void OnToggleChanged(bool value)
		{
			if (AssignedFurniture == null)
			{
				throw new NullReferenceException("No Furniture assigned in: " + base.name);
			}
			if (!value)
			{
				Furniture currentPickedUpFurniture = MonoSingleton<FurniturePlacer>.Instance.CurrentPickedUpFurniture;
				if ((bool)currentPickedUpFurniture && !currentPickedUpFurniture.Purchased && currentPickedUpFurniture.Parameters == AssignedFurniture)
				{
					MonoSingleton<FurniturePlacer>.Instance.TryCancelPlacement();
				}
				return;
			}
			if (AssignedFurniture.PurchasePrice <= MonoSingleton<MoneyHandler>.Instance.CurrentMoney)
			{
				AbsLockableItemSO.ELockState getValidationState = AssignedFurniture.GetValidationState;
				if (getValidationState == AbsLockableItemSO.ELockState.Validated || getValidationState == AbsLockableItemSO.ELockState.OnTesting)
				{
					MonoSingleton<FurniturePlacer>.Instance.StartPlacement(AssignedFurniture);
				}
			}
			RefreshData();
			if (!_button.isOn)
			{
				Furniture currentPickedUpFurniture2 = MonoSingleton<FurniturePlacer>.Instance.CurrentPickedUpFurniture;
				if ((bool)currentPickedUpFurniture2 && !currentPickedUpFurniture2.Purchased && currentPickedUpFurniture2.Parameters == AssignedFurniture)
				{
					_button.isOn = true;
				}
			}
		}

		private void PrepareButton()
		{
			if (!AssignedFurniture || !_image)
			{
				return;
			}
			_image.enabled = false;
			_outlineImage.enabled = false;
			if ((bool)AssignedFurniture.Icon)
			{
				_image.sprite = AssignedFurniture.Icon;
				_image.enabled = true;
				if ((bool)_outlineImage)
				{
					_outlineImage.sprite = AssignedFurniture.Icon;
					_outlineImage.enabled = true;
				}
				_textMeshProUGUI.enabled = false;
			}
			_validationIcon.SetIconState(AssignedFurniture);
			_textMeshProUGUI.text = AssignedFurniture.Name;
			string text = _prestigeKey.GetLocalizedStringSafe().ToUpper();
			_toolTipsShower.InsertedText = "<b>" + text + " : +" + AssignedFurniture.PrestigeValue + "</b>\n\n";
			_toolTipsShower.SetTootipsInfo(AssignedFurniture.LocalizationItemSONameKey, AssignedFurniture.LocalizationItemSODescKey);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UIFurnitureButton.FurnitureButtonHovered?.Invoke(AssignedFurniture);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			UIFurnitureButton.FurnitureButtonExited?.Invoke(AssignedFurniture);
		}

		TechTreeTechnologySO IGive<TechTreeTechnologySO>.Get()
		{
			return AssignedFurniture.TechTreeTechnologyRequiered;
		}
	}
}
