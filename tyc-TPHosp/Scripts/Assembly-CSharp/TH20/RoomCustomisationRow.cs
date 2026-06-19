using I2.Loc;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RoomCustomisationRow : MonoBehaviour
	{
		public enum Mode
		{
			Available = 0,
			Selected = 1,
			LockedAffordable = 2,
			LockedUnaffordable = 3
		}

		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private DynamicButton _buttonExtContent;

		[SerializeField]
		private TooltipSpawner _tooltipExtContent;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private Image _imageExtContent;

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

		[Space]
		[SerializeField]
		private LocalisedString _extViewInSteamWorkshopString;

		[SerializeField]
		private LocalisedString _extEditWallString;

		[SerializeField]
		private LocalisedString _extEditFloorString;

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
		private Sprite _availableWorkshopBackgroundSprite;

		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private Sprite _lockedBackgroundSprite;

		[Space]
		[SerializeField]
		private Sprite _editLocalUGCSprite;

		[SerializeField]
		private Sprite _steamWorkshopUGCSprite;

		private Color _initialPriceColor;

		private Mode _currentMode;

		private IFloorVisualOverrideDefinition _floorOption;

		private IWallVisualOverrideDefinition _wallOption;

		private GameItemBase _gameItem;

		public DynamicButton Button => _button;

		public DynamicButton ButtonExtContent => _buttonExtContent;

		public IFloorVisualOverrideDefinition FloorOption => _floorOption;

		public IWallVisualOverrideDefinition WallOption => _wallOption;

		public GameItemBase GameItem => _gameItem;

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
					ApplySelectableBackground();
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
					if (_floorOption != null)
					{
						_priceText.text = StringUtils.FormatSilverCurrency(_floorOption.SilverCost());
					}
					if (_wallOption != null)
					{
						_priceText.text = StringUtils.FormatSilverCurrency(_wallOption.SilverCost());
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
					if (_floorOption != null)
					{
						_priceText.text = StringUtils.FormatSilverCurrency(_floorOption.SilverCost());
					}
					if (_wallOption != null)
					{
						_priceText.text = StringUtils.FormatSilverCurrency(_wallOption.SilverCost());
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
			_floorOption = null;
			_nameText.text = name.Translation;
			_padlockImage.enabled = false;
			_priceGameObject.SetActive(value: false);
			if (icon != null)
			{
				_iconImage.sprite = icon;
			}
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipDataProvider);
			}
			SetupExternalContentData(string.Empty);
			ApplySelectableBackground();
		}

		public void SetupFloorOption(IFloorVisualOverrideDefinition option)
		{
			_initialPriceColor = _priceText.color;
			_wallOption = null;
			_floorOption = option;
			_nameText.text = option.Name;
			_padlockImage.enabled = false;
			_priceGameObject.SetActive(value: false);
			if (_floorOption.Icon != null)
			{
				_iconImage.sprite = _floorOption.Icon;
			}
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipDataProvider);
			}
			SetupExternalContentData(option.GetContentID());
			ApplySelectableBackground();
		}

		public void SetupWallOption(IWallVisualOverrideDefinition option)
		{
			_initialPriceColor = _priceText.color;
			_wallOption = option;
			_floorOption = null;
			_nameText.text = option.Name;
			_padlockImage.enabled = false;
			_priceGameObject.SetActive(value: false);
			if (_wallOption.Icon != null)
			{
				_iconImage.sprite = _wallOption.Icon;
			}
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipDataProvider);
			}
			SetupExternalContentData(option.GetContentID());
			ApplySelectableBackground();
		}

		private void ApplySelectableBackground()
		{
			if (_floorOption is FloorVisualOverrideDefinitionUGC || _wallOption is WallVisualOverrideDefinitionUGC)
			{
				if (_availableWorkshopBackgroundSprite != null)
				{
					_backgroundImage.sprite = _availableWorkshopBackgroundSprite;
				}
			}
			else if (_availableBackgroundSprite != null)
			{
				_backgroundImage.sprite = _availableBackgroundSprite;
			}
		}

		public void OnGameItemDataChanged()
		{
			Sprite sprite = null;
			if (_wallOption != null)
			{
				sprite = _wallOption.Icon;
			}
			else if (_floorOption.Icon != null)
			{
				sprite = _floorOption.Icon;
			}
			if (sprite != null)
			{
				_iconImage.sprite = sprite;
			}
		}

		private void SetupExternalContentData(string contentID)
		{
			_gameItem = null;
			if (!contentID.IsNullOrEmpty())
			{
				_gameItem = ExtContentUtils.ExtContentManager.FindGameItemByContentID(contentID);
			}
			if (_buttonExtContent != null)
			{
				bool active = _gameItem != null;
				ExtContentUIUtils.SetSelectableInteractable(_buttonExtContent, bCanInteract: true);
				_buttonExtContent.gameObject.SetActive(active);
			}
			if (_tooltipExtContent != null && _gameItem != null)
			{
				switch (_gameItem.ContentSource)
				{
				case EContentSourceType.LocalMods:
					if (_floorOption != null)
					{
						_tooltipExtContent.TooltipText = _extEditFloorString.Translation;
					}
					else if (_wallOption != null)
					{
						_tooltipExtContent.TooltipText = _extEditWallString.Translation;
					}
					break;
				case EContentSourceType.Workshop:
					_tooltipExtContent.TooltipText = _extViewInSteamWorkshopString.Translation;
					break;
				}
			}
			if (_imageExtContent != null && _gameItem != null)
			{
				switch (_gameItem.ContentSource)
				{
				case EContentSourceType.LocalMods:
					_imageExtContent.sprite = _editLocalUGCSprite;
					break;
				case EContentSourceType.Workshop:
					_imageExtContent.sprite = _steamWorkshopUGCSprite;
					break;
				}
			}
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			TooltipItemButton tooltipItemButton = tooltip as TooltipItemButton;
			if (tooltipItemButton != null)
			{
				tooltipItemButton.StaffRequired.gameObject.SetActive(value: false);
				tooltipItemButton.FunctionalDescription.gameObject.SetActive(value: false);
				tooltipItemButton.CurrentCount.gameObject.SetActive(value: false);
				if (_floorOption != null)
				{
					GameItemBase gameItemBase = (_floorOption as FloorVisualOverrideDefinitionUGC)?.ExtContentGameItem;
					SetTooltipText(tooltipItemButton, _floorOption.Name, _floorOption.Description, gameItemBase);
				}
				else if (_wallOption != null)
				{
					GameItemBase gameItemBase2 = (_wallOption as WallVisualOverrideDefinitionUGC)?.ExtContentGameItem;
					SetTooltipText(tooltipItemButton, _wallOption.Name, _wallOption.Description, gameItemBase2);
				}
			}
		}

		private static void SetTooltipText(TooltipItemButton tooltipItemButton, string name, string description, GameItemBase gameItemBase)
		{
			tooltipItemButton.Text = name;
			if (string.IsNullOrEmpty(description))
			{
				tooltipItemButton.Description.gameObject.SetActive(value: false);
			}
			else
			{
				tooltipItemButton.Description.text = description;
			}
			if (gameItemBase != null)
			{
				tooltipItemButton.UGC.text = ((gameItemBase.ContentSource == EContentSourceType.Workshop) ? ScriptLocalization.Menu_UGC_Misc.ContentSourceWorkshop_CS : ScriptLocalization.Menu_UGC_Misc.ContentSourceLocal_CS);
				tooltipItemButton.UGC.gameObject.SetActive(value: true);
			}
			else
			{
				tooltipItemButton.UGC.gameObject.SetActive(value: false);
			}
		}
	}
}
