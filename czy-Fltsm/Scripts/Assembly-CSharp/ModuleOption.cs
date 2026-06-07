using I2.Loc;
using PajamaLlama.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ModuleOption : MonoBehaviour, ILocalizationParamsManager
{
	[SerializeField]
	private TextMeshProUGUI _titleField;

	[SerializeField]
	private TextMeshProUGUI _descriptionField;

	[SerializeField]
	private ChildBehaviourCache<BuildableTooltipItemSlot> _itemSlotCache;

	[SerializeField]
	private ButtonWithIconAndLabel _button;

	[Header("State")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _activeParameter = "Module_Active";

	[SerializeField]
	private string _lockedParameter = "Module_Locked";

	[SerializeField]
	private string _cancelParameter = "Module_Cancel";

	[Header("Localization")]
	[SerializeField]
	private LocalizedString _buttonLabelUpgrade;

	[SerializeField]
	private LocalizedString _buttonLabelCancelUpgrade;

	[SerializeField]
	private LocalizedString _buttonLabelInstall;

	private Buildable _buildable;

	private ModuleManager _manager;

	private ResearchUnlockable _researchUnlockable;

	private int _modifier;

	public UnityEvent<ModuleOption> OnClicked { get; } = new UnityEvent<ModuleOption>();

	public BuildableProperties BuildableProperties { get; private set; }

	public ModuleProperties ModuleProperties { get; private set; }

	public bool Interactable
	{
		get
		{
			if ((bool)_button)
			{
				return _button.interactable;
			}
			return false;
		}
	}

	public bool IsCancel { get; private set; }

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
		if ((bool)_animator)
		{
			_animator.SetBool(_lockedParameter, !_researchUnlockable.IsUnlocked());
			_animator.SetBool(_activeParameter, _manager != null && _manager.IsActiveModule(ModuleProperties));
			GameEventDispatcher.AddListener(GameEventType.ResearchFinished, OnResearchFinished);
			GameEventDispatcher.AddListener(GameEventType.CommunityInventoryUpdated, OnCommunityInventoryUpdated);
		}
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, OnResearchFinished);
		GameEventDispatcher.RemoveListener(GameEventType.CommunityInventoryUpdated, OnCommunityInventoryUpdated);
	}

	public void Initialize(Buildable buildable)
	{
		BuildableProperties = buildable.Properties;
		ModuleProperties = null;
		_buildable = buildable;
		_researchUnlockable = BuildableProperties;
		_titleField.text = BuildableProperties.Upgrade.Name;
		_descriptionField.text = BuildableProperties.Upgrade.Description;
		_itemSlotCache.Reset();
		CountedItemProperty[] upgradeResources = BuildableProperties.UpgradeResources;
		foreach (CountedItemProperty slotItem in upgradeResources)
		{
			_itemSlotCache.Get(active: true).Initialize(slotItem);
		}
		_itemSlotCache.Trim();
		_animator?.SetBool(_activeParameter, value: false);
		UpdateButtonState();
		OnResearchFinished();
	}

	public void Initialize(ModuleManager manager, ModuleProperties module)
	{
		LocalizationManager.ParamManagers.Add(this);
		bool flag = manager.IsActiveModule(module);
		ModuleProperties = module;
		BuildableProperties = null;
		_buildable = manager.Buildable;
		_researchUnlockable = module;
		_manager = manager;
		_modifier = Mathf.RoundToInt(module.ModifierValue * 100f);
		_titleField.text = module.Name;
		_descriptionField.text = module.Description;
		_itemSlotCache.Reset();
		if (!flag)
		{
			CountedItemProperty[] cost = module.GetCost(manager.Buildable, excludeItemsinInventory: true);
			foreach (CountedItemProperty slotItem in cost)
			{
				_itemSlotCache.Get(active: true).Initialize(slotItem);
			}
		}
		_itemSlotCache.Trim();
		_animator?.SetBool(_activeParameter, flag);
		UpdateButtonState();
		OnResearchFinished();
		LocalizationManager.ParamManagers.Remove(this);
	}

	public bool Select()
	{
		if (_button.interactable)
		{
			_button.Select();
			return true;
		}
		return false;
	}

	private void UpdateButtonState()
	{
		if ((bool)BuildableProperties)
		{
			bool flag = _buildable.CanUpgrade();
			IsCancel = _buildable.BuildPhase == BuildPhase.UpgradeShutdown || _buildable.BuildPhase == BuildPhase.UpgradeHaulTo;
			_button.interactable = flag || IsCancel;
			_button.Initialize(IsCancel ? _buttonLabelCancelUpgrade : _buttonLabelUpgrade);
			_animator?.SetBool(_cancelParameter, IsCancel);
		}
		else if ((bool)ModuleProperties)
		{
			_button.interactable = !_manager.IsActiveModule(ModuleProperties) && ModuleProperties.CanBeDone(_buildable);
			_button.Initialize(_buttonLabelInstall);
		}
	}

	private void OnClick()
	{
		OnClicked.Invoke(this);
	}

	private void OnCommunityInventoryUpdated(GameEvent gameEvent)
	{
		UpdateButtonState();
	}

	private void OnResearchFinished(GameEvent gameEvent = null)
	{
		_animator.SetBool(_lockedParameter, !_researchUnlockable.IsUnlocked());
	}

	public string GetParameterValue(string Param)
	{
		if (Param == "AMOUNT")
		{
			return $"{_modifier}%";
		}
		return null;
	}
}
