using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RibbonRoomRow : MonoBehaviour
	{
		public enum Mode
		{
			Available = 0,
			Selected = 1,
			Locked = 2,
			Inactive = 3,
			LockedAffordable = 4,
			ContainsInvalidItems = 5
		}

		[Flags]
		public enum TemplateInvalidReason
		{
			None = 0,
			LockedItems = 1,
			BannedItems = 2,
			MissingUGC = 4,
			MissingDLC = 8,
			LockedRoom = 0x10
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
		private Image _missingItemsImage;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _price;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

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

		[SerializeField]
		private Sprite _inactiveBackgroundSprite;

		private RoomTemplate _template;

		private RoomDefinition _roomDefinition;

		private bool _affordable = true;

		private Metagame _metagame;

		private GameplayStatsTracker _gameplayStatsTracker;

		private Mode _currentMode;

		private Color _initialPriceColor;

		public TemplateInvalidReason InvalidReason;

		public List<uint> MissingDLC;

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
					_price.color = (_affordable ? _initialPriceColor : _unaffordableColor);
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
					if (_availableBackgroundSprite != null)
					{
						_backgroundImage.sprite = _availableBackgroundSprite;
					}
					_padlockImage.enabled = false;
					GameObjectUtils.SetActive(_missingItemsImage.gameObject, isActive: false);
					_price.text = GetCostString(value);
					break;
				case Mode.ContainsInvalidItems:
					if (_availableBackgroundSprite != null)
					{
						_backgroundImage.sprite = _availableBackgroundSprite;
					}
					_padlockImage.enabled = false;
					GameObjectUtils.SetActive(_missingItemsImage.gameObject, isActive: true);
					_price.text = GetCostString(value);
					break;
				case Mode.Selected:
					if (_selectedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _selectedBackgroundSprite;
					}
					_padlockImage.enabled = false;
					GameObjectUtils.SetActive(_missingItemsImage.gameObject, isActive: false);
					_price.text = GetCostString(value);
					break;
				case Mode.Locked:
					if (_lockedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _lockedBackgroundSprite;
					}
					_padlockImage.enabled = true;
					GameObjectUtils.SetActive(_missingItemsImage.gameObject, isActive: false);
					_padlockImage.color = _unaffordablePadlockColor;
					_price.text = GetCostString(value);
					break;
				case Mode.LockedAffordable:
					if (_lockedBackgroundSprite != null)
					{
						_backgroundImage.sprite = _lockedBackgroundSprite;
					}
					_padlockImage.enabled = true;
					_missingItemsImage.enabled = false;
					_padlockImage.color = _affordablePadlockColor;
					_price.text = GetCostString(value);
					break;
				case Mode.Inactive:
					if (_inactiveBackgroundSprite != null)
					{
						_backgroundImage.sprite = _inactiveBackgroundSprite;
					}
					_padlockImage.enabled = false;
					GameObjectUtils.SetActive(_missingItemsImage.gameObject, isActive: false);
					_price.text = GetCostString(value);
					break;
				}
				_currentMode = value;
			}
		}

		public RoomTemplate RoomTemplate => _template;

		public RoomDefinition RoomDefinition => _roomDefinition;

		public DynamicButton Button => _button;

		public Image BackgroundImage => _backgroundImage;

		public string GetCostString(Mode roomRowMode)
		{
			if (_template != null)
			{
				return StringUtils.FormatCurrency(Mathf.Max(GameAlgorithms.CalculatePurchaseCostOfRoomTemplate(_template.TemplateFloorPlan), 0));
			}
			switch (roomRowMode)
			{
			case Mode.Available:
			case Mode.Selected:
			case Mode.Inactive:
			case Mode.ContainsInvalidItems:
				return StringUtils.FormatCurrency(_roomDefinition.GetCostWithRequiredItems());
			case Mode.Locked:
			case Mode.LockedAffordable:
				return StringUtils.FormatSilverCurrency(_roomDefinition.SilverCost());
			default:
				return StringUtils.FormatCurrency(_roomDefinition.GetCostWithRequiredItems());
			}
		}

		public void Setup(RoomDefinition roomDefinition, Metagame metagame, GameplayStatsTracker gameplayStatsTracker, RoomTemplate template = null)
		{
			_template = template;
			_roomDefinition = roomDefinition;
			_metagame = metagame;
			_gameplayStatsTracker = gameplayStatsTracker;
			_image.overrideSprite = _roomDefinition._icon;
			if (template != null)
			{
				_name.text = template.UserDefinedName;
			}
			else
			{
				_name.text = _roomDefinition.GetLocalisedName();
			}
			_initialPriceColor = _price.color;
			_price.text = GetCostString(Mode.Available);
			_padlockImage.enabled = false;
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipDataProvider);
			}
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			TooltipRoomButton tooltipRoomButton = tooltip as TooltipRoomButton;
			if (tooltipRoomButton != null)
			{
				tooltipRoomButton.SetData(_roomDefinition, _currentMode, _metagame, _gameplayStatsTracker, _template, InvalidReason, MissingDLC);
			}
		}
	}
}
