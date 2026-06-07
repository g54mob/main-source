using System;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace PajamaLlama.UI
{
	public class RadialMenu : MonoBehaviour
	{
		[SerializeField]
		private InputFlags _supportedInputs = InputFlags.Joystick;

		[SerializeField]
		private RadialMenuOption[] _options;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The minimum magnitude the stick directional vector should have before an option is selected.")]
		private float _selectedMagnitude = 0.33f;

		[SerializeField]
		private Vector2 _angleVector = new Vector2(-1f, 0f);

		[SerializeField]
		private float _angleOffset;

		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private TextMeshProUGUI _description;

		[SerializeField]
		[Tooltip("The default description shown when no option is selected. Can be override with the description on the context.")]
		private LocalizedString _defaultDescription;

		[SerializeField]
		private bool _allowSelectNull = true;

		[Header("Buildable")]
		[SerializeField]
		private GameObject _buildableNameFieldContainer;

		[SerializeField]
		private TextMeshProUGUI _buildableNameField;

		[SerializeField]
		private GameObject _buildableStatsParent;

		[SerializeField]
		private TextField _footprintField;

		[SerializeField]
		private IntField _beautyField;

		[SerializeField]
		private IntField _energyRequirementField;

		[SerializeField]
		private TextField _weightField;

		[SerializeField]
		private ChildBehaviourCache<BuildableTooltipItemSlot> _tooltipItemSlotCache;

		private static RadialMenu _instance;

		private bool _isEnabled;

		private int _optionCount;

		private CursorContext _context;

		private RadialMenuOption _selectedOption;

		public static bool IsEnabled
		{
			get
			{
				if ((bool)_instance)
				{
					return _instance._isEnabled;
				}
				return false;
			}
		}

		private void Awake()
		{
			Initialize();
			_angleVector.Normalize();
			_buildableNameFieldContainer.gameObject.SetActive(value: false);
			_buildableStatsParent.gameObject.SetActive(value: false);
		}

		private void OnEnable()
		{
			GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputChanged);
		}

		private void Update()
		{
			Vector2 leftStick = FlotsamInputManager.GetLeftStick();
			if (_selectedMagnitude < leftStick.magnitude)
			{
				int num = Mathf.RoundToInt((Vector2.SignedAngle(leftStick, _angleVector) + _angleOffset + 360f) % 360f);
				SelectOption(GetOptionFromAngle(num));
			}
			else if (_allowSelectNull)
			{
				SelectOption(null);
			}
			if (FlotsamInputManager.GetButtonUp(93) && (bool)_selectedOption && _selectedOption.IsActive)
			{
				_selectedOption.Action.Trigger();
				base.gameObject.SetActive(value: false);
			}
			if (FlotsamInputManager.GetButtonUp(102) || GameManager.Gamepaused)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			if (_selectedOption != null)
			{
				_selectedOption.Deselect(this);
				_selectedOption = null;
			}
			GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputChanged);
			_isEnabled = false;
		}

		public void Initialize()
		{
			if (!_instance || !(_instance == this))
			{
				if (_instance == null)
				{
					_instance = this;
					_optionCount = _options.Length;
					base.gameObject.SetActive(value: false);
					_isEnabled = false;
				}
				else
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}

		public static void Enable(CursorContext context)
		{
			_instance?.i_Enable(context);
		}

		private void i_Enable(CursorContext context)
		{
			if (FlotsamInputManager.HasActiveInput(_supportedInputs) && !context.Actions.IsNullOrEmpty())
			{
				int num = context.Actions.Length;
				_selectedOption = null;
				ClearBuildable();
				_context = context;
				SetContextLabelAndDescription();
				if (_optionCount < num)
				{
					throw new NotSupportedException();
				}
				int i;
				for (i = 0; i < num && i < _optionCount; i++)
				{
					_options[i].Enable(context.Actions[i]);
				}
				for (; i < _optionCount; i++)
				{
					_options[i].Disable();
				}
				_isEnabled = true;
				base.gameObject.SetActive(value: true);
			}
		}

		public void SetUpgradeInfo(Buildable buildable, bool upgradeResources = false)
		{
			BuildableProperties properties = buildable.Properties;
			if ((bool)buildable.Properties.Upgrade)
			{
				_buildableNameFieldContainer.gameObject.SetActive(value: true);
				_buildableNameField.text = buildable.Properties.Upgrade.Name;
				SetDescription(buildable.Properties.Upgrade.Description);
			}
			_buildableStatsParent.gameObject.SetActive(value: true);
			_footprintField.SetText($"{properties.Width}x{properties.Depth}");
			_beautyField.SetInt(properties.BeautyScore);
			if (properties.TryGetEnergyCost(out var energyCost))
			{
				_energyRequirementField.SetFloat(energyCost);
			}
			else
			{
				_energyRequirementField.gameObject.SetActive(value: false);
			}
			_weightField.SetText(properties.GetWeightModeWeight().ToString(), Engine.CanTug(properties) ? TextField.States.Positive : TextField.States.Negative);
			_tooltipItemSlotCache.Reset();
			CountedItemProperty[] array = properties.ReturnTooltipRequiredResources(upgradeResources);
			foreach (CountedItemProperty slotItem in array)
			{
				_tooltipItemSlotCache.Get(active: true).Initialize(slotItem);
			}
			_tooltipItemSlotCache.Trim();
		}

		public void SetDeconstructInfo(Buildable buildable)
		{
			InventoryAuditor.Global.Reset();
			buildable.Inventory.Count(InventoryAuditor.Global, SubInventoryType.Composition);
			_tooltipItemSlotCache.Reset();
			foreach (InventoryAuditor.CountedItem countedItem in InventoryAuditor.Global.CountedItems)
			{
				if (countedItem.WasCounted)
				{
					_tooltipItemSlotCache.Get(active: true).Initialize(countedItem.ItemProperties, countedItem.ReturnCount(InventoryAuditor.CountType.All), showCounter: true);
				}
			}
			_tooltipItemSlotCache.Trim();
		}

		public void ClearBuildable()
		{
			_buildableNameFieldContainer.gameObject.SetActive(value: false);
			_buildableStatsParent.gameObject.SetActive(value: false);
			_tooltipItemSlotCache.DeactivateParent();
		}

		public RadialMenuOption GetOptionFromAngle(float angle)
		{
			RadialMenuOption[] options = _options;
			foreach (RadialMenuOption radialMenuOption in options)
			{
				if (radialMenuOption.Range.ReturnContainsValue(angle))
				{
					return radialMenuOption;
				}
			}
			return null;
		}

		private void SelectOption(RadialMenuOption optionToSelect)
		{
			if (optionToSelect == _selectedOption)
			{
				return;
			}
			if ((bool)optionToSelect && optionToSelect.IsActive)
			{
				if ((bool)_selectedOption)
				{
					_selectedOption?.Deselect(this);
				}
				_selectedOption = optionToSelect;
				_label.text = _selectedOption.Action.GetLabel();
				SetDescription(_selectedOption.Action.GetDescription());
				_selectedOption.Select(this);
			}
			else if (_allowSelectNull)
			{
				if ((bool)_selectedOption)
				{
					_selectedOption?.Deselect(this);
				}
				_selectedOption = null;
				SetContextLabelAndDescription();
			}
		}

		private void SetContextLabelAndDescription()
		{
			_label.text = _context.Title;
			if (string.IsNullOrEmpty(_context.Description.mTerm))
			{
				SetDescription(_defaultDescription);
			}
			else
			{
				SetDescription(_context.Description);
			}
		}

		private void SetDescription(string description)
		{
			_description.text = TextManager.ReplaceVariablesWithEmptyString(description);
		}

		private void OnActiveInputChanged(GameEvent gameEvent)
		{
			if (!FlotsamInputManager.HasActiveInput(_supportedInputs))
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
