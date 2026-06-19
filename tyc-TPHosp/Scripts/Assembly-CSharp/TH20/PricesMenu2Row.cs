using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class PricesMenu2Row : MonoBehaviour
	{
		[Header("Row")]
		[SerializeField]
		private Image _rowBGImage;

		[SerializeField]
		private Color _rowColour1 = Color.white;

		[SerializeField]
		private Color _rowColour2 = Color.black;

		[Header("Icon")]
		[SerializeField]
		private Image _iconImage;

		[Header("Name")]
		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private PricesCellComparable _itemCustomCellComparable;

		[Header("Price")]
		[SerializeField]
		private TMP_Text _priceText;

		[SerializeField]
		private IntCellComparable _priceIntCellComparable;

		[Header("Modifier")]
		[SerializeField]
		private TMP_Text _modifierText;

		[SerializeField]
		private IntCellComparable _modifierIntCellComparable;

		[SerializeField]
		private Slider _increaseSlider;

		[SerializeField]
		private Button _resetButton;

		private int _modifierDelta;

		private int _modifierMin;

		private int _modifierMax;

		private int _basePrice;

		private PriceModifiers _priceModifiers;

		private IPriceModifier _modifiable;

		private Sprite _iconSprite;

		private PricesMenu2 _owningMenu;

		private int _defaultSortOrderValue;

		private string _defaultSortOrderName;

		public int DefaultSortOrderValue => _defaultSortOrderValue;

		public string DefaultSortOrderName => _defaultSortOrderName;

		public void Setup(PricesMenu2 owningMenu, string name, Sprite iconSprite, int basePrice, PriceModifiers priceModifiers, IPriceModifier modifiable, int delta, int min, int max, int rowIndex, int defaultSortOrderValue, string defaultSortOrderName)
		{
			_modifierDelta = delta;
			_modifierMin = min;
			_modifierMax = max;
			_owningMenu = owningMenu;
			_basePrice = basePrice;
			_priceModifiers = priceModifiers;
			_nameText.text = name;
			_modifiable = modifiable;
			_iconSprite = iconSprite;
			_defaultSortOrderValue = defaultSortOrderValue;
			_defaultSortOrderName = defaultSortOrderName;
			if (string.IsNullOrEmpty(_defaultSortOrderName))
			{
				_defaultSortOrderName = string.Empty;
			}
			_increaseSlider.onValueChanged.AddListener(OnModifierValueChangedFloat);
			_increaseSlider.minValue = _modifierMin;
			_increaseSlider.maxValue = _modifierMax;
			_increaseSlider.value = _priceModifiers.GetModifier(_modifiable);
			if (_iconImage != null)
			{
				_iconImage.overrideSprite = _iconSprite;
			}
			SetRowIndex(rowIndex);
			if (_resetButton != null)
			{
				_resetButton.onClick.AddListener(delegate
				{
					OnResetButtonClicked();
				});
			}
			if (_itemCustomCellComparable != null)
			{
				_itemCustomCellComparable._row = this;
			}
			Refresh();
		}

		public void SetRowIndex(int rowIndex)
		{
			if (_rowBGImage != null)
			{
				_rowBGImage.color = (((rowIndex & 1) == 0) ? _rowColour1 : _rowColour2);
			}
		}

		public bool SetModifier(int ModifierAmount, bool bInformParent = true)
		{
			bool result = OnModifierValueChanged(ModifierAmount, bInformParent);
			_increaseSlider.value = _priceModifiers.GetModifier(_modifiable);
			Refresh();
			return result;
		}

		public int GetModifier()
		{
			return _priceModifiers.GetModifier(_modifiable);
		}

		public int DefaultCompare(PricesMenu2Row otherRow)
		{
			int num = 0;
			if (otherRow != null)
			{
				num = DefaultSortOrderValue.CompareTo(otherRow.DefaultSortOrderValue);
				if (num == 0 && DefaultSortOrderName != null)
				{
					num = DefaultSortOrderName.CompareTo(otherRow.DefaultSortOrderName);
				}
			}
			return num;
		}

		private void OnModifierValueChangedFloat(float value)
		{
			OnModifierValueChanged((int)value);
		}

		private bool OnModifierValueChanged(int newValue, bool bInformParent = true)
		{
			bool result = false;
			int modifier = _priceModifiers.GetModifier(_modifiable);
			int num = newValue - modifier;
			int num2 = ((num >= 0) ? 1 : (-1));
			int num3 = Mathf.Abs(num);
			int num4 = num3;
			if (_modifierDelta > 0)
			{
				num4 -= num3 % _modifierDelta;
			}
			num4 *= num2;
			int value = modifier + num4;
			value = Mathf.Clamp(value, _modifierMin, _modifierMax);
			_priceModifiers.SetModifier(_modifiable, value);
			if (_priceModifiers.GetModifier(_modifiable) != modifier)
			{
				result = true;
				if (bInformParent)
				{
					NotifyParentMenuOnValueChange();
				}
			}
			return result;
		}

		private void NotifyParentMenuOnValueChange()
		{
			if (_owningMenu != null)
			{
				_owningMenu.OnAnyRowItemChanges();
			}
		}

		private void OnResetButtonClicked()
		{
			_increaseSlider.value = 0f;
			OnModifierValueChangedFloat(_increaseSlider.value);
		}

		public void Refresh()
		{
			int num = Mathf.CeilToInt(_basePrice);
			int num2 = num + _priceModifiers.Percent(_modifiable, num);
			_priceText.text = StringUtils.FormatCurrency(num2);
			_priceIntCellComparable.Value = num2;
			int modifier = _priceModifiers.GetModifier(_modifiable);
			if (modifier == 0)
			{
				_modifierText.text = "0";
			}
			else if (modifier > 0)
			{
				_modifierText.text = $"+{modifier}%";
			}
			else
			{
				_modifierText.text = $"-{Mathf.Abs(modifier)}%";
			}
			if (_modifierIntCellComparable != null)
			{
				_modifierIntCellComparable.Value = modifier;
			}
		}

		protected void Update()
		{
			Refresh();
		}
	}
}
