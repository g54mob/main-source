using I2.Loc;
using JetBrains.Annotations;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RibbonItemRow : MonoBehaviour
	{
		public enum Mode
		{
			Available = 0,
			Selected = 1,
			Locked = 2,
			Inactive = 3,
			Banned = 4
		}

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Image _padlockImage;

		[SerializeField]
		private Image _requiredImage;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private Image _bannedImage;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _price;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private DynamicButton _buttonExtContent;

		[SerializeField]
		private Image _imageExtContent;

		[SerializeField]
		private TooltipSpawner _tooltipExtContent;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private Color _unaffordableColor = Color.red;

		[SerializeField]
		private Color _affordablePadlockColor = Color.green;

		[SerializeField]
		private Color _unaffordablePadlockColor = Color.white;

		[Space]
		[SerializeField]
		private LocalisedString _extViewInSteamWorkshopString;

		[SerializeField]
		private LocalisedString _extEditString;

		[SerializeField]
		private LocalisedString _extLocalTooltipString;

		[SerializeField]
		private LocalisedString _extWorkshopTooltipString;

		[Header("Assets")]
		[SerializeField]
		private Sprite _availableBackgroundSprite;

		[SerializeField]
		private Sprite _availableWorkshopBackgroundSprite;

		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private Sprite _lockedBackgroundSprite;

		[SerializeField]
		private Sprite _inactiveBackgroundSprite;

		[Space]
		[SerializeField]
		private Sprite _editLocalUGCSprite;

		[SerializeField]
		private Sprite _steamWorkshopUGCSprite;

		private IRoomItemDefinition _roomItemDefinition;

		private Metagame _metagame;

		private GameplayStatsTracker _gameplayStatsTracker;

		private bool _affordable = true;

		private Mode _currentMode;

		private Color _initialPriceColor;

		public bool Affordable
		{
			get
			{
				return _affordable;
			}
			set
			{
				if (value != _affordable)
				{
					_affordable = value;
					if (_padlockImage != null)
					{
						_padlockImage.color = (_affordable ? _affordablePadlockColor : _unaffordablePadlockColor);
					}
					if (_price != null)
					{
						_price.color = (_affordable ? _initialPriceColor : _unaffordableColor);
					}
				}
			}
		}

		public bool IsRequired
		{
			get
			{
				return _requiredImage.enabled;
			}
			set
			{
				_requiredImage.enabled = value;
			}
		}

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
					if (_roomItemDefinition is RoomItemDefinitionUGC)
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
					_padlockImage.enabled = false;
					_bannedImage.enabled = false;
					_price.text = StringUtils.FormatCurrency(_roomItemDefinition.GetCost());
					break;
				case Mode.Selected:
					if (_selectedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _selectedBackgroundSprite;
					}
					_padlockImage.enabled = false;
					_bannedImage.enabled = false;
					_price.text = StringUtils.FormatCurrency(_roomItemDefinition.GetCost());
					break;
				case Mode.Locked:
					if (_lockedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _lockedBackgroundSprite;
					}
					_padlockImage.enabled = true;
					_bannedImage.enabled = false;
					_price.text = StringUtils.FormatSilverCurrency(_roomItemDefinition.SilverCost());
					break;
				case Mode.Inactive:
					if (_inactiveBackgroundSprite != null)
					{
						_backgroundImage.sprite = _inactiveBackgroundSprite;
					}
					_padlockImage.enabled = false;
					_bannedImage.enabled = false;
					_price.text = StringUtils.FormatCurrency(_roomItemDefinition.GetCost());
					break;
				case Mode.Banned:
					if (_inactiveBackgroundSprite != null)
					{
						_backgroundImage.sprite = _inactiveBackgroundSprite;
					}
					_padlockImage.enabled = false;
					_bannedImage.enabled = true;
					_price.text = StringUtils.FormatCurrency(_roomItemDefinition.GetCost());
					break;
				}
				_currentMode = value;
			}
		}

		public IRoomItemDefinition RoomItemDefinition => _roomItemDefinition;

		public DynamicButton Button => _button;

		public DynamicButton ButtonExtContent => _buttonExtContent;

		public Image BackgroundImage => _backgroundImage;

		public void Setup(IRoomItemDefinition roomItemDefinition, Metagame metagame, GameplayStatsTracker gameplayStatsTracker)
		{
			_roomItemDefinition = roomItemDefinition;
			_metagame = metagame;
			_gameplayStatsTracker = gameplayStatsTracker;
			_image.overrideSprite = _roomItemDefinition.GetIcon();
			if (_name != null)
			{
				_name.text = _roomItemDefinition.GetLocalisedName();
			}
			_initialPriceColor = _price.color;
			_price.text = StringUtils.FormatCurrency(_roomItemDefinition.GetCost());
			_padlockImage.enabled = false;
			_bannedImage.enabled = false;
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipDataProvider);
			}
			if (roomItemDefinition is RoomItemDefinitionUGC && _availableWorkshopBackgroundSprite != null)
			{
				_backgroundImage.sprite = _availableWorkshopBackgroundSprite;
			}
			RoomItemDefinitionUGC roomItemDefinitionUGC = _roomItemDefinition as RoomItemDefinitionUGC;
			if (_buttonExtContent != null)
			{
				bool flag = roomItemDefinitionUGC != null;
				bool bCanInteract = false;
				bool flag2 = false;
				if (flag)
				{
					GameItemBase extContentGameItem = roomItemDefinitionUGC.ExtContentGameItem;
					if (extContentGameItem != null)
					{
						switch (extContentGameItem.ContentSource)
						{
						case EContentSourceType.LocalMods:
							flag2 = true;
							bCanInteract = true;
							_imageExtContent.sprite = _editLocalUGCSprite;
							break;
						case EContentSourceType.Workshop:
							flag2 = true;
							bCanInteract = true;
							_imageExtContent.sprite = _steamWorkshopUGCSprite;
							break;
						}
					}
				}
				_buttonExtContent.gameObject.SetActive(flag && flag2);
				ExtContentUIUtils.SetSelectableInteractable(_buttonExtContent, bCanInteract);
			}
			if (!(_tooltipExtContent != null) || roomItemDefinitionUGC == null)
			{
				return;
			}
			GameItemBase extContentGameItem2 = roomItemDefinitionUGC.ExtContentGameItem;
			if (extContentGameItem2 != null)
			{
				switch (extContentGameItem2.ContentSource)
				{
				case EContentSourceType.LocalMods:
					_tooltipExtContent.TooltipText = _extEditString.Translation;
					break;
				case EContentSourceType.Workshop:
					_tooltipExtContent.TooltipText = _extViewInSteamWorkshopString.Translation;
					break;
				}
			}
		}

		public void SetTooltipOffset(Vector3 tooltipOffset)
		{
			_tooltipSpawner.AnchorOffset = tooltipOffset;
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			TooltipItemButton tooltipItemButton = tooltip as TooltipItemButton;
			if (!(tooltipItemButton != null))
			{
				return;
			}
			string text = _roomItemDefinition.GetDescription();
			if (_currentMode == Mode.Locked)
			{
				text += "\n\n";
				text += StringUtils.FormatCurrency(_roomItemDefinition.GetCost());
				text += "\n\n";
				text += GameStringUtils.GetUnlockText(_roomItemDefinition.SilverCost(), _metagame.TotalSilver());
			}
			RoomItemDefinitionUGC roomItemDefinitionUGC = _roomItemDefinition as RoomItemDefinitionUGC;
			if (roomItemDefinitionUGC != null)
			{
				string nameAndType_CS = ScriptLocalization.Menu_UGC.NameAndType_CS;
				nameAndType_CS = nameAndType_CS.Replace("{[NAME]}", _roomItemDefinition.GetLocalisedName());
				EContentType contentType = ExtContentUtils.ExtContentManager.FindGameItemByContentID(roomItemDefinitionUGC.ContentID).ContentType;
				nameAndType_CS = nameAndType_CS.Replace("{[TYPE]}", ExtContentType.ContentTypeToStringLoc(contentType));
				tooltipItemButton.Text = nameAndType_CS;
			}
			else
			{
				tooltipItemButton.Text = _roomItemDefinition.GetLocalisedName();
			}
			tooltipItemButton.Description.text = text;
			tooltipItemButton.CurrentCount.text = GameStringUtils.GetRoomItemCountText(_gameplayStatsTracker, _roomItemDefinition);
			string functionalDescription = _roomItemDefinition.GetFunctionalDescription();
			functionalDescription = functionalDescription + "\n" + GameStringUtils.GetRoomModifiersTooltipText(_roomItemDefinition.RoomModifiers);
			tooltipItemButton.FunctionalDescription.text = functionalDescription;
			GameObjectUtils.SetActive(tooltipItemButton.FunctionalDescription.gameObject, !string.IsNullOrEmpty(functionalDescription));
			string requiredStaffText = GameStringUtils.GetRequiredStaffText(_roomItemDefinition.GetRequiredStaff(includeRoomModifier: true));
			if (!string.IsNullOrEmpty(requiredStaffText))
			{
				tooltipItemButton.StaffRequired.text = requiredStaffText;
				GameObjectUtils.SetActive(tooltipItemButton.StaffRequired.gameObject, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(tooltipItemButton.StaffRequired.gameObject, isActive: false);
			}
			if (roomItemDefinitionUGC != null)
			{
				tooltipItemButton.UGC.gameObject.SetActive(value: true);
				GameItemBase extContentGameItem = roomItemDefinitionUGC.ExtContentGameItem;
				if (extContentGameItem != null)
				{
					tooltipItemButton.UGC.text = ((extContentGameItem.ContentSource == EContentSourceType.Workshop) ? ScriptLocalization.Menu_UGC_Misc.ContentSourceWorkshop_CS : ScriptLocalization.Menu_UGC_Misc.ContentSourceLocal_CS);
				}
			}
			else
			{
				tooltipItemButton.UGC.gameObject.SetActive(value: false);
			}
		}
	}
}
