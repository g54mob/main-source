using System.Collections;
using System.Collections.Generic;
using Enviro;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpPanel : MonoBehaviour
{
	private struct UpgradeUnlockInfo
	{
		public Sprite icon;

		public string title;

		public string subtitle;
	}

	[Header("Panel")]
	[SerializeField]
	private GameObject panelObject;

	[Header("Title")]
	[SerializeField]
	private TMP_Text levelTitleText;

	[Header("Properties Section")]
	[SerializeField]
	private GameObject propertiesSectionObject;

	[SerializeField]
	private Transform propertiesContainer;

	[SerializeField]
	private LevelUpUnlockItemUI propertyItemPrefab;

	[Header("Buildings Section")]
	[SerializeField]
	private GameObject buildingsSectionObject;

	[SerializeField]
	private Transform buildingsContainer;

	[SerializeField]
	private LevelUpUnlockItemUI buildingItemPrefab;

	[Header("Upgrades Section")]
	[SerializeField]
	private GameObject upgradesSectionObject;

	[SerializeField]
	private Transform upgradesContainer;

	[SerializeField]
	private LevelUpUnlockItemUI upgradeItemPrefab;

	[Header("Auto Close")]
	[Tooltip("Otomatik kapanma uyarısı gösteren obje (sağ tıkla kapatılır)")]
	[SerializeField]
	private GameObject closeAlertObject;

	[Tooltip("Kapatma butonu objesi (sağ tıktan sonra görünür)")]
	[SerializeField]
	private GameObject closeInputObject;

	[Tooltip("Geri sayım text'i (X saniye içinde kapanacak)")]
	[SerializeField]
	private TMP_Text closeAlertText;

	[Tooltip("Otomatik kapanma süresi (saniye)")]
	[SerializeField]
	private float autoCloseDelay = 10f;

	[Header("Replay")]
	[Tooltip("Panel kapandıktan sonra tekrar açılabilir olduğunu gösteren UI objesi")]
	[SerializeField]
	private GameObject replayIndicatorObject;

	[Tooltip("Panel kapandıktan sonra tekrar açılabilir olacağı süre (saniye)")]
	[SerializeField]
	private float replayDuration = 10f;

	[Header("Events")]
	public UnityEvent onPanelOpened;

	public UnityEvent onPanelClosed;

	private bool _isOpen;

	private List<LevelUpUnlockItemUI> _spawnedItems = new List<LevelUpUnlockItemUI>();

	private int _lastShownLevel;

	private bool _canReplay;

	private Coroutine _replayCoroutine;

	private Coroutine _autoCloseCoroutine;

	private bool _isAutoCloseActive;

	public bool IsOpen => _isOpen;

	public bool CanReplay => _canReplay;

	private void Awake()
	{
		if (panelObject != null)
		{
			panelObject.SetActive(value: false);
		}
		if (replayIndicatorObject != null)
		{
			replayIndicatorObject.SetActive(value: false);
		}
		if (closeAlertObject != null)
		{
			closeAlertObject.SetActive(value: false);
		}
		if (closeInputObject != null)
		{
			closeInputObject.SetActive(value: false);
		}
	}

	public void Show(int newLevel, bool withAutoClose = true)
	{
		if (_isOpen)
		{
			return;
		}
		StopReplayTimer();
		_lastShownLevel = newLevel;
		ClearSpawnedItems();
		PopulatePanel(newLevel);
		if (panelObject != null)
		{
			panelObject.SetActive(value: true);
		}
		_isOpen = true;
		onPanelOpened?.Invoke();
		if (withAutoClose)
		{
			StartAutoClose();
		}
		else
		{
			if (closeAlertObject != null)
			{
				closeAlertObject.SetActive(value: false);
			}
			if (closeInputObject != null)
			{
				closeInputObject.SetActive(value: true);
			}
		}
		Debug.Log($"[LevelUpPanel] Level {newLevel} paneli açıldı (AutoClose: {withAutoClose})");
	}

	public void CloseUI()
	{
		if (_isOpen)
		{
			StopAutoClose();
			_isOpen = false;
			onPanelClosed?.Invoke();
			if (DayNightManager.Instance.CurrentGameDay == 1)
			{
				StartCoroutine(TutorialNightTransitionCoroutine());
			}
			StartCoroutine(CloseUIActions());
			Debug.Log("[LevelUpPanel] Panel kapatıldı");
		}
	}

	private IEnumerator CloseUIActions()
	{
		yield return new WaitForSeconds(0.5f);
		ClearSpawnedItems();
		StartReplayTimer();
		if (panelObject != null)
		{
			panelObject.SetActive(value: false);
		}
	}

	public void Replay()
	{
		if (_canReplay && !_isOpen)
		{
			StopReplayTimer();
			Show(_lastShownLevel, withAutoClose: false);
			Debug.Log($"[LevelUpPanel] Level {_lastShownLevel} paneli tekrar açıldı (Replay)");
		}
	}

	private void StartReplayTimer()
	{
		_canReplay = true;
		if (replayIndicatorObject != null)
		{
			replayIndicatorObject.SetActive(value: true);
		}
		if (_replayCoroutine != null)
		{
			StopCoroutine(_replayCoroutine);
		}
		_replayCoroutine = StartCoroutine(ReplayTimerCoroutine());
	}

	private void StopReplayTimer()
	{
		_canReplay = false;
		if (replayIndicatorObject != null)
		{
			replayIndicatorObject.SetActive(value: false);
		}
		if (_replayCoroutine != null)
		{
			StopCoroutine(_replayCoroutine);
			_replayCoroutine = null;
		}
	}

	private IEnumerator ReplayTimerCoroutine()
	{
		yield return new WaitForSeconds(replayDuration);
		StopReplayTimer();
		Debug.Log("[LevelUpPanel] Replay süresi doldu");
	}

	private IEnumerator TutorialNightTransitionCoroutine()
	{
		yield return new WaitForSeconds(1f);
		if (DayNightManager.Instance.CurrentGameDay == 1)
		{
			DayNightManager.Instance.TriggerTutorialNightTransition();
		}
	}

	private void StartAutoClose()
	{
		_isAutoCloseActive = true;
		if (closeInputObject != null)
		{
			closeInputObject.SetActive(value: false);
		}
		if (closeAlertObject != null)
		{
			closeAlertObject.SetActive(value: true);
		}
		if (_autoCloseCoroutine != null)
		{
			StopCoroutine(_autoCloseCoroutine);
		}
		_autoCloseCoroutine = StartCoroutine(AutoCloseCoroutine());
	}

	private void StopAutoClose()
	{
		_isAutoCloseActive = false;
		if (closeAlertObject != null)
		{
			closeAlertObject.SetActive(value: false);
		}
		if (closeInputObject != null)
		{
			closeInputObject.SetActive(value: false);
		}
		if (_autoCloseCoroutine != null)
		{
			StopCoroutine(_autoCloseCoroutine);
			_autoCloseCoroutine = null;
		}
	}

	public void EnableCloseInput()
	{
		if (_isAutoCloseActive)
		{
			_isAutoCloseActive = false;
			if (_autoCloseCoroutine != null)
			{
				StopCoroutine(_autoCloseCoroutine);
				_autoCloseCoroutine = null;
			}
			if (closeAlertObject != null)
			{
				closeAlertObject.SetActive(value: false);
			}
			if (closeInputObject != null)
			{
				closeInputObject.SetActive(value: true);
			}
			Debug.Log("[LevelUpPanel] Auto close iptal edildi, kapatma butonu aktif");
		}
	}

	private IEnumerator AutoCloseCoroutine()
	{
		for (float remainingTime = autoCloseDelay; remainingTime > 0f; remainingTime -= Time.deltaTime)
		{
			if (closeAlertText != null)
			{
				int num = Mathf.CeilToInt(remainingTime);
				closeAlertText.text = $"{num}";
			}
			yield return null;
		}
		CloseUI();
	}

	private void PopulatePanel(int newLevel)
	{
		if (levelTitleText != null)
		{
			string translation = LocalizationManager.GetTranslation("New_Level_Unlocked");
			string translation2 = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation2, new Dictionary<string, object> { 
			{
				"Number",
				newLevel.ToString()
			} });
			levelTitleText.text = translation + " - " + translation2;
		}
		List<PropertyConfigSO> unlockedProperties = GetUnlockedProperties(newLevel);
		List<T_BuildingItemSO> unlockedBuildings = GetUnlockedBuildings(newLevel);
		List<UpgradeUnlockInfo> unlockedUpgrades = GetUnlockedUpgrades(newLevel);
		Debug.Log($"[LevelUpPanel] Level {newLevel}: Properties={unlockedProperties.Count}, Buildings={unlockedBuildings.Count}, Upgrades={unlockedUpgrades.Count}");
		PopulatePropertiesSection(unlockedProperties);
		PopulateBuildingsSection(unlockedBuildings);
		PopulateUpgradesSection(unlockedUpgrades);
	}

	private void PopulatePropertiesSection(List<PropertyConfigSO> properties)
	{
		bool flag = properties.Count > 0;
		if (propertiesSectionObject != null)
		{
			propertiesSectionObject.SetActive(flag);
		}
		if (!flag || propertiesContainer == null || propertyItemPrefab == null)
		{
			return;
		}
		foreach (PropertyConfigSO property in properties)
		{
			LevelUpUnlockItemUI levelUpUnlockItemUI = Object.Instantiate(propertyItemPrefab, propertiesContainer);
			Sprite randomVisual = property.GetRandomVisual();
			string text = LocalizationManager.GetTranslation(property.displayName);
			if (string.IsNullOrEmpty(text))
			{
				text = "NL/" + property.displayName;
			}
			levelUpUnlockItemUI.Setup(randomVisual, text);
			_spawnedItems.Add(levelUpUnlockItemUI);
		}
	}

	private void PopulateBuildingsSection(List<T_BuildingItemSO> buildings)
	{
		bool flag = buildings.Count > 0;
		if (buildingsSectionObject != null)
		{
			buildingsSectionObject.SetActive(flag);
		}
		if (!flag || buildingsContainer == null || buildingItemPrefab == null)
		{
			return;
		}
		foreach (T_BuildingItemSO building in buildings)
		{
			LevelUpUnlockItemUI levelUpUnlockItemUI = Object.Instantiate(buildingItemPrefab, buildingsContainer);
			string translation = LocalizationManager.GetTranslation(building.Name);
			levelUpUnlockItemUI.Setup(building.Icon, translation);
			_spawnedItems.Add(levelUpUnlockItemUI);
		}
	}

	private void PopulateUpgradesSection(List<UpgradeUnlockInfo> upgrades)
	{
		bool flag = upgrades.Count > 0;
		if (upgradesSectionObject != null)
		{
			upgradesSectionObject.SetActive(flag);
		}
		if (!flag || upgradesContainer == null || upgradeItemPrefab == null)
		{
			return;
		}
		foreach (UpgradeUnlockInfo upgrade in upgrades)
		{
			LevelUpUnlockItemUI levelUpUnlockItemUI = Object.Instantiate(upgradeItemPrefab, upgradesContainer);
			levelUpUnlockItemUI.Setup(upgrade.icon, upgrade.title, upgrade.subtitle);
			_spawnedItems.Add(levelUpUnlockItemUI);
		}
	}

	private List<PropertyConfigSO> GetUnlockedProperties(int level)
	{
		List<PropertyConfigSO> list = new List<PropertyConfigSO>();
		if (ScriptableListManager.Instance == null)
		{
			return list;
		}
		foreach (PropertyConfigSO allPropertyConfig in ScriptableListManager.Instance.AllPropertyConfigs)
		{
			if (allPropertyConfig != null && allPropertyConfig.propertyLevel == level)
			{
				list.Add(allPropertyConfig);
			}
		}
		return list;
	}

	private List<T_BuildingItemSO> GetUnlockedBuildings(int level)
	{
		List<T_BuildingItemSO> list = new List<T_BuildingItemSO>();
		if (ScriptableListManager.Instance == null)
		{
			return list;
		}
		foreach (T_BuildingItemSO allBuildingItemSO in ScriptableListManager.Instance.AllBuildingItemSOs)
		{
			if (allBuildingItemSO != null && allBuildingItemSO.Level == level)
			{
				list.Add(allBuildingItemSO);
			}
		}
		return list;
	}

	private List<UpgradeUnlockInfo> GetUnlockedUpgrades(int level)
	{
		List<UpgradeUnlockInfo> list = new List<UpgradeUnlockInfo>();
		if (ScriptableListManager.Instance == null)
		{
			return list;
		}
		foreach (UpgradeGroupSO allUpgradeGroup in ScriptableListManager.Instance.AllUpgradeGroups)
		{
			if (allUpgradeGroup == null || allUpgradeGroup.levels == null)
			{
				continue;
			}
			for (int i = 0; i < allUpgradeGroup.levels.Count; i++)
			{
				UpgradeLevelData upgradeLevelData = allUpgradeGroup.levels[i];
				if (upgradeLevelData != null && upgradeLevelData.requiredFactoryLevel == level)
				{
					Sprite icon = ((allUpgradeGroup.category == UpgradeCategory.Equipments) ? allUpgradeGroup.icon : ((upgradeLevelData.levelIcon != null) ? upgradeLevelData.levelIcon : allUpgradeGroup.icon));
					string subtitle = ((allUpgradeGroup.category == UpgradeCategory.Equipments && i == 0) ? string.Empty : upgradeLevelData.Title);
					list.Add(new UpgradeUnlockInfo
					{
						icon = icon,
						title = allUpgradeGroup.UpgradeName,
						subtitle = subtitle
					});
				}
			}
		}
		return list;
	}

	private void ClearSpawnedItems()
	{
		foreach (LevelUpUnlockItemUI spawnedItem in _spawnedItems)
		{
			if (spawnedItem != null)
			{
				Object.Destroy(spawnedItem.gameObject);
			}
		}
		_spawnedItems.Clear();
	}

	[ContextMenu("Test: Show Level 1")]
	private void TestShowLevel1()
	{
		Show(1);
	}

	[ContextMenu("Test: Show Level 2")]
	private void TestShowLevel2()
	{
		Show(2);
	}

	[ContextMenu("Test: Show Level 3")]
	private void TestShowLevel3()
	{
		Show(3);
	}
}
