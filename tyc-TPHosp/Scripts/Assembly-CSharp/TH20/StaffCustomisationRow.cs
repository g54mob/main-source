using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StaffCustomisationRow : MonoBehaviour
	{
		public enum Mode
		{
			Available = 0,
			Selected = 1,
			LockedAffordable = 2,
			LockedUnaffordable = 3
		}

		[SerializeField]
		private Localize _nameLocalize;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private Image _padlockImage;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private GameObject _priceGameObject;

		[SerializeField]
		private TMP_Text _priceText;

		[Header("Colors")]
		[SerializeField]
		private Color _unaffordableColor = Color.red;

		[SerializeField]
		private Color _affordablePadlockColor = Color.green;

		[SerializeField]
		private Color _unaffordablePadlockColor = Color.white;

		[Header("Assets")]
		[SerializeField]
		private Sprite _availableBackgroundSprite;

		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private Sprite _lockedBackgroundSprite;

		private Color _initialPriceColor;

		private Mode _currentMode;

		private CustomisationOption _option;

		public DynamicButton Button => _button;

		public CustomisationOption CustomisationOption => _option;

		public Mode CurrentMode
		{
			get
			{
				return _currentMode;
			}
			set
			{
				if (value == _currentMode)
				{
					return;
				}
				switch (value)
				{
				case Mode.Available:
					if (_availableBackgroundSprite != null)
					{
						_backgroundImage.sprite = _availableBackgroundSprite;
					}
					_padlockImage.enabled = false;
					_priceGameObject.SetActive(value: false);
					break;
				case Mode.Selected:
					if (_selectedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _selectedBackgroundSprite;
					}
					_padlockImage.enabled = false;
					_priceGameObject.SetActive(value: false);
					break;
				case Mode.LockedAffordable:
					if (_lockedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _lockedBackgroundSprite;
					}
					_padlockImage.enabled = true;
					_priceGameObject.SetActive(value: true);
					if (_option != null)
					{
						_priceText.text = StringUtils.FormatSilverCurrency(_option.SilverCost());
					}
					_padlockImage.color = _affordablePadlockColor;
					_priceText.color = _initialPriceColor;
					break;
				case Mode.LockedUnaffordable:
					if (_lockedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _lockedBackgroundSprite;
					}
					_padlockImage.enabled = true;
					_priceGameObject.SetActive(value: true);
					if (_option != null)
					{
						_priceText.text = StringUtils.FormatSilverCurrency(_option.SilverCost());
					}
					_padlockImage.color = _unaffordablePadlockColor;
					_priceText.color = _unaffordableColor;
					break;
				}
				_currentMode = value;
			}
		}

		public void SetupDefault(LocalisedString name, Sprite icon)
		{
			_initialPriceColor = _priceText.color;
			_option = null;
			_nameLocalize.Term = name.Term;
			_padlockImage.enabled = false;
			_priceGameObject.SetActive(value: false);
			if (icon != null)
			{
				_iconImage.sprite = icon;
			}
		}

		public void SetupOption(CustomisationOption option)
		{
			_initialPriceColor = _priceText.color;
			_option = option;
			_nameLocalize.Term = option.Name.Term;
			_padlockImage.enabled = false;
			_priceGameObject.SetActive(value: false);
			if (_option.Icon != null)
			{
				_iconImage.sprite = _option.Icon;
			}
		}
	}
}
