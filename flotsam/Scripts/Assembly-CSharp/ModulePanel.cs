using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ModulePanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	[FormerlySerializedAs("_buttonCache")]
	private ChildBehaviourCache<ModuleOption> _optionCache;

	[SerializeField]
	private Button _launchButton;

	private Buildable _buildable;

	private ModuleManager _moduleManager;

	private int _selectedIndex;

	public BuildablePanelElementId Id => BuildablePanelElementId.Workshop;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.CommunityInventoryUpdated, UpdateOptions);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.CommunityInventoryUpdated, UpdateOptions);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		_buildable = buildable;
		if (IsActive(buildable) && (_buildable.TryReturnBuildableExtendable<ModuleManager>(out _moduleManager) || buildable.Properties.Upgrade != null))
		{
			if ((bool)_moduleManager && _moduleManager.HasLaunchedRocket())
			{
				return false;
			}
			UpdateOptions();
			base.gameObject.SetActive(value: true);
			GameEventDispatcher.AddListener(GameEventType.ModuleActivated, UpdateOptions);
			if ((bool)_moduleManager && _moduleManager.IsRocket())
			{
				GameEventDispatcher.AddListener(GameEventType.QuestUpdated, UpdateOptions);
				GameEventDispatcher.AddListener(GameEventType.PanelClosed, UpdateOptions);
			}
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		ClearButtons();
		base.gameObject.SetActive(value: false);
		GameEventDispatcher.RemoveListener(GameEventType.ModuleActivated, UpdateOptions);
		GameEventDispatcher.RemoveListener(GameEventType.QuestUpdated, UpdateOptions);
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, UpdateOptions);
	}

	private void UpdateOptions(GameEvent gameEvent = null)
	{
		ClearButtons();
		_optionCache.Reset();
		if ((bool)_buildable.Properties.Upgrade)
		{
			ModuleOption moduleOption = _optionCache.Get(active: true);
			moduleOption.Initialize(_buildable);
			moduleOption.OnClicked.AddListener(OnButtonClick);
		}
		if ((bool)_moduleManager)
		{
			if (_moduleManager.CanLaunchRocket())
			{
				_launchButton.gameObject.SetActive(value: true);
				_launchButton.onClick.AddListener(Launch);
				_launchButton.Select();
			}
			else if (_moduleManager.Modules != null)
			{
				using ListPool<ModuleProperties>.List list = ListPool<ModuleProperties>.Get(_moduleManager.Modules);
				Sorting.SlowSort(list, SortModules);
				foreach (ModuleProperties item in list)
				{
					ModuleOption moduleOption2 = _optionCache.Get(active: true);
					moduleOption2.Initialize(_moduleManager, item);
					moduleOption2.OnClicked.AddListener(OnButtonClick);
				}
			}
		}
		_optionCache.Trim();
		if (!_optionCache.TryGetAtIndex(_selectedIndex, out var instance) || !instance.Select())
		{
			_selectedIndex = -1;
			SelectNextOption();
		}
	}

	private void ClearButtons()
	{
		_launchButton.gameObject.SetActive(value: false);
		_launchButton.onClick.RemoveListener(Launch);
		foreach (ModuleOption instance in _optionCache.Instances)
		{
			instance.OnClicked.RemoveListener(OnButtonClick);
		}
	}

	private int SortModules(ModuleProperties lhs, ModuleProperties rhs)
	{
		bool num = _moduleManager.IsActiveModule(lhs);
		bool flag = _moduleManager.IsActiveModule(rhs);
		if (num == flag)
		{
			return 0;
		}
		if ((bool)rhs)
		{
			return -1;
		}
		return 1;
	}

	private bool IsActive(Buildable buildable)
	{
		if (buildable.BuildPhase != BuildPhase.Finished && buildable.BuildPhase != BuildPhase.UpgradeShutdown && buildable.BuildPhase != BuildPhase.UpgradeHaulTo)
		{
			return buildable.BuildPhase == BuildPhase.UpgradeHaulFrom;
		}
		return true;
	}

	public void SelectPreviousOption()
	{
		int num = _selectedIndex;
		ModuleOption instance;
		while (_optionCache.TryGetAtIndex(--num, out instance))
		{
			if (instance.Select())
			{
				_selectedIndex = num;
				break;
			}
		}
	}

	public void SelectNextOption()
	{
		int num = _selectedIndex;
		ModuleOption instance;
		while (_optionCache.TryGetAtIndex(++num, out instance))
		{
			if (instance.Select())
			{
				_selectedIndex = num;
				break;
			}
		}
	}

	private void SelectOption(int index)
	{
		if (_optionCache.TryGetAtIndex(index, out var instance) && instance.Select())
		{
			_selectedIndex = index;
		}
	}

	private void Launch()
	{
		GameManager.UIManager.CloseAllPanels();
		GameEventDispatcher.Dispatch(GameEventType.LaunchSpaceship);
	}

	private void OnButtonClick(ModuleOption upgradeButton)
	{
		if (!upgradeButton)
		{
			return;
		}
		if ((bool)upgradeButton.ModuleProperties)
		{
			_moduleManager?.PlaceModule(upgradeButton.ModuleProperties);
		}
		else if ((bool)upgradeButton.BuildableProperties)
		{
			if (upgradeButton.IsCancel)
			{
				_buildable.CancelUpgrade();
			}
			else
			{
				_buildable.Upgrade();
			}
		}
		UpdateOptions();
		SelectOption(_selectedIndex);
	}
}
