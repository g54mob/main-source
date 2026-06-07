using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
	[Header("Containers")]
	[SerializeField]
	private Transform groupContainer;

	[Header("Prefabs")]
	[SerializeField]
	private GameObject groupPrefab;

	[SerializeField]
	private GameObject nodePrefab;

	[Header("Factory Info")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[SerializeField]
	private TextMeshProUGUI levelText;

	private UpgradeCategory _currentTab;

	private List<UpgradeGroupUI> _activeGroups = new List<UpgradeGroupUI>();

	private void OnEnable()
	{
		if (UpgradeManager.Instance != null)
		{
			UpgradeManager.Instance.onGlobalUpgradeChanged.AddListener(OnUpgradeChanged);
			UpgradeManager.Instance.onMyEquipmentUpgradeChanged.AddListener(OnUpgradeChanged);
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.AddListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.AddListener(OnLevelChanged);
		}
		RefreshHeader();
		SwitchTab(_currentTab);
	}

	private void OnDisable()
	{
		if (UpgradeManager.Instance != null)
		{
			UpgradeManager.Instance.onGlobalUpgradeChanged.RemoveListener(OnUpgradeChanged);
			UpgradeManager.Instance.onMyEquipmentUpgradeChanged.RemoveListener(OnUpgradeChanged);
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.RemoveListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.RemoveListener(OnLevelChanged);
		}
	}

	public void SwitchToFactory()
	{
		SwitchTab(UpgradeCategory.Factory);
	}

	public void SwitchToLicenses()
	{
		SwitchTab(UpgradeCategory.Licenses);
	}

	public void SwitchToEquipments()
	{
		SwitchTab(UpgradeCategory.Equipments);
	}

	public void SwitchTab(UpgradeCategory category)
	{
		_currentTab = category;
		RebuildGrid();
	}

	private void RebuildGrid()
	{
		ClearGroups();
		if (UpgradeManager.Instance == null)
		{
			return;
		}
		UpgradeTabSO tabSO = UpgradeManager.Instance.GetTabSO(_currentTab);
		if (tabSO == null || tabSO.groups == null)
		{
			return;
		}
		foreach (UpgradeGroupSO group in tabSO.groups)
		{
			if (group == null)
			{
				continue;
			}
			int upgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(group.upgradeType);
			if (!(groupPrefab == null) && !(groupContainer == null))
			{
				UpgradeGroupUI component = Object.Instantiate(groupPrefab, groupContainer).GetComponent<UpgradeGroupUI>();
				if (component != null)
				{
					component.Setup(group, upgradeLevel, nodePrefab);
					_activeGroups.Add(component);
				}
			}
		}
	}

	private void OnUpgradeChanged(UpgradeType upgradeType, int newLevel)
	{
		foreach (UpgradeGroupUI activeGroup in _activeGroups)
		{
			if (activeGroup.UpgradeType == upgradeType)
			{
				activeGroup.UpdateLevels(newLevel);
				break;
			}
		}
		RefreshHeader();
	}

	private void OnMoneyChanged(int oldValue, int newValue)
	{
		RefreshHeader();
		RefreshAllGroups();
	}

	private void OnLevelChanged(int oldValue, int newValue)
	{
		RefreshHeader();
		RefreshAllGroups();
	}

	private void RefreshAllGroups()
	{
		if (UpgradeManager.Instance == null)
		{
			return;
		}
		foreach (UpgradeGroupUI activeGroup in _activeGroups)
		{
			int upgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(activeGroup.UpgradeType);
			activeGroup.UpdateLevels(upgradeLevel);
		}
	}

	private void RefreshHeader()
	{
		if (!(FactoryManager.Instance == null))
		{
			if (moneyText != null)
			{
				moneyText.text = FactoryManager.Instance.Money.ToString();
			}
			if (levelText != null)
			{
				string translation = LocalizationManager.GetTranslation("Level");
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
				{
					"Number",
					FactoryManager.Instance.Level.ToString()
				} });
				levelText.text = translation;
			}
		}
	}

	private void ClearGroups()
	{
		foreach (UpgradeGroupUI activeGroup in _activeGroups)
		{
			if (activeGroup != null)
			{
				Object.Destroy(activeGroup.gameObject);
			}
		}
		_activeGroups.Clear();
	}

	private void OnDestroy()
	{
		ClearGroups();
	}
}
