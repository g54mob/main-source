using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UpgradeDetailPanel : MonoBehaviour
{
	[Header("Info")]
	[SerializeField]
	private TextMeshProUGUI titleText;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	[Header("Changes")]
	[SerializeField]
	private TextMeshProUGUI changesText;

	[Header("Requirements")]
	[SerializeField]
	private GameObject requirementsContainer;

	[SerializeField]
	private TextMeshProUGUI requiredLevelText;

	[SerializeField]
	private Image requiredLevelIcon;

	[SerializeField]
	private TextMeshProUGUI costText;

	[SerializeField]
	private Image costIcon;

	[SerializeField]
	private Color sufficientColor = Color.white;

	[SerializeField]
	private Color insufficientColor = Color.red;

	[Header("Action")]
	[SerializeField]
	private GameObject unlockButtonObject;

	[SerializeField]
	private GameObject upgradedButton;

	[SerializeField]
	private GameObject lockedObject;

	[SerializeField]
	private GameObject versionLockedGameObject;

	[SerializeField]
	private GameObject equipmentOnlyObject;

	[Header("Hold to Unlock")]
	[SerializeField]
	private InputActionReference holdInputAction;

	[SerializeField]
	private Image holdFillBar;

	[SerializeField]
	private float holdDuration = 1.5f;

	private CanvasGroup _canvasGroup;

	private UpgradeType _currentUpgradeType;

	private UpgradeGroupSO _currentGroup;

	private Action<int> _onUpgradeCallback;

	private bool _isHolding;

	private float _holdTimer;

	private bool _canUpgrade;

	private bool _isVersionLocked;

	private UpgradeNodeUI _currentNode;

	private int _selectedLevel = -1;

	public bool IsVisible
	{
		get
		{
			if (_canvasGroup != null)
			{
				return _canvasGroup.alpha > 0f;
			}
			return false;
		}
	}

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		if (_canvasGroup == null)
		{
			_canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
		ResetHoldState();
		Hide();
	}

	private void OnEnable()
	{
		UpgradeManager.OnAnyUpgradeChanged = (Action<UpgradeType, int>)Delegate.Combine(UpgradeManager.OnAnyUpgradeChanged, new Action<UpgradeType, int>(OnUpgradeChanged));
		if (holdInputAction != null)
		{
			holdInputAction.action.performed += OnHoldPerformed;
			holdInputAction.action.canceled += OnHoldCanceled;
			holdInputAction.action.Enable();
		}
	}

	private void OnDisable()
	{
		UpgradeManager.OnAnyUpgradeChanged = (Action<UpgradeType, int>)Delegate.Remove(UpgradeManager.OnAnyUpgradeChanged, new Action<UpgradeType, int>(OnUpgradeChanged));
		if (holdInputAction != null)
		{
			holdInputAction.action.performed -= OnHoldPerformed;
			holdInputAction.action.canceled -= OnHoldCanceled;
		}
		ResetHoldState();
	}

	private void Update()
	{
		if (_isHolding && _canUpgrade)
		{
			_holdTimer += Time.deltaTime;
			float num = Mathf.Clamp01(_holdTimer / holdDuration);
			if (holdFillBar != null)
			{
				holdFillBar.fillAmount = num;
			}
			if (_currentNode != null)
			{
				_currentNode.SetHoldProgress(num);
			}
			if (_holdTimer >= holdDuration)
			{
				PerformUpgrade();
				ResetHoldState();
			}
		}
	}

	private void OnHoldPerformed(InputAction.CallbackContext ctx)
	{
		if (IsVisible && _canUpgrade)
		{
			_isHolding = true;
			_holdTimer = 0f;
			if (holdFillBar != null)
			{
				holdFillBar.fillAmount = 0f;
			}
		}
	}

	private void OnHoldCanceled(InputAction.CallbackContext ctx)
	{
		ResetHoldState();
	}

	private void ResetHoldState()
	{
		_isHolding = false;
		_holdTimer = 0f;
		if (holdFillBar != null)
		{
			holdFillBar.fillAmount = 0f;
		}
		if (_currentNode != null)
		{
			_currentNode.SetHoldProgress(0f);
		}
	}

	private void OnUpgradeChanged(UpgradeType upgradeType, int newLevel)
	{
		if (upgradeType == _currentUpgradeType && !(_currentGroup == null))
		{
			if (IsVisible)
			{
				Show(_currentGroup, newLevel, _selectedLevel);
			}
			_onUpgradeCallback?.Invoke(newLevel);
		}
	}

	public void SetOnUpgradeCallback(Action<int> callback)
	{
		_onUpgradeCallback = callback;
	}

	private void PerformUpgrade()
	{
		Debug.Log(string.Format("[UpgradeDetailPanel] Hold completed! UpgradeType: {0}, Group: {1}", _currentUpgradeType, (_currentGroup != null) ? _currentGroup.UpgradeName : "null"));
		if (_currentGroup == null)
		{
			Debug.LogWarning("[UpgradeDetailPanel] _currentGroup is null!");
			return;
		}
		if (UpgradeManager.Instance == null)
		{
			Debug.LogWarning("[UpgradeDetailPanel] UpgradeManager.Instance is null!");
			return;
		}
		Debug.Log($"[UpgradeDetailPanel] Calling RequestUpgrade for {_currentUpgradeType}");
		UpgradeManager.Instance.RequestUpgrade(_currentUpgradeType);
	}

	public void Show(UpgradeGroupSO group, int currentLevel, int selectedLevel = -1, UpgradeNodeUI node = null)
	{
		SetVisible(visible: true);
		_currentGroup = group;
		_currentUpgradeType = group.upgradeType;
		if (equipmentOnlyObject != null && PlayerProgressManager.Instance != null && !PlayerProgressManager.Instance.useSharedUpgrades)
		{
			equipmentOnlyObject.SetActive(group.category == UpgradeCategory.Equipments);
		}
		if (node != null)
		{
			_currentNode = node;
		}
		if (selectedLevel > 0)
		{
			_selectedLevel = selectedLevel;
		}
		bool flag = currentLevel >= group.MaxLevel;
		int num = ((_selectedLevel > 0) ? _selectedLevel : (flag ? currentLevel : (currentLevel + 1)));
		UpgradeLevelData levelData = group.GetLevelData(num);
		if (titleText != null)
		{
			string translation = levelData?.Title;
			if (string.IsNullOrEmpty(translation))
			{
				translation = LocalizationManager.GetTranslation(group.levelPrefixKey);
				if (string.IsNullOrEmpty(translation))
				{
					translation = group.levelPrefixKey;
				}
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
				{
					"Number",
					num.ToString()
				} });
			}
			titleText.text = translation;
		}
		if (descriptionText != null)
		{
			descriptionText.text = levelData?.Description ?? "";
		}
		if (changesText != null)
		{
			List<string> list = levelData?.GetLocalizedChanges();
			if (list != null && list.Count > 0)
			{
				changesText.text = string.Join("\n", list);
			}
			else
			{
				changesText.text = "";
			}
		}
		PopulateRequirements(levelData, flag);
		UpdateButton(group, currentLevel, num);
	}

	public void Hide()
	{
		_selectedLevel = -1;
		SetVisible(visible: false);
	}

	private void SetVisible(bool visible)
	{
		if (!(_canvasGroup == null))
		{
			_canvasGroup.alpha = (visible ? 1f : 0f);
			_canvasGroup.interactable = visible;
			_canvasGroup.blocksRaycasts = visible;
		}
	}

	private void PopulateRequirements(UpgradeLevelData levelData, bool isMaxed)
	{
		bool flag = levelData != null && levelData.requiredFactoryLevel > 0;
		if (requirementsContainer != null)
		{
			requirementsContainer.SetActive(flag);
		}
		if (requiredLevelText != null)
		{
			requiredLevelText.gameObject.SetActive(flag);
		}
		if (costText != null)
		{
			costText.gameObject.SetActive(flag);
		}
		if (flag)
		{
			int num = ((FactoryManager.Instance != null) ? FactoryManager.Instance.Level : 0);
			int num2 = ((FactoryManager.Instance != null) ? FactoryManager.Instance.Money : 0);
			Color color = ((isMaxed || num >= levelData.requiredFactoryLevel) ? sufficientColor : insufficientColor);
			if (requiredLevelText != null)
			{
				string translation = LocalizationManager.GetTranslation("Level");
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
				{
					"Number",
					levelData.requiredFactoryLevel.ToString()
				} });
				requiredLevelText.text = translation;
				requiredLevelText.color = color;
			}
			if (requiredLevelIcon != null)
			{
				requiredLevelIcon.color = color;
			}
			Color color2 = ((isMaxed || num2 >= levelData.cost) ? sufficientColor : insufficientColor);
			if (costText != null)
			{
				costText.text = $"{levelData.cost}";
				costText.color = color2;
			}
			if (costIcon != null)
			{
				costIcon.color = color2;
			}
		}
	}

	private void UpdateButton(UpgradeGroupSO group, int currentLevel, int displayLevel)
	{
		ResetHoldState();
		UpgradeLevelData levelData = group.GetLevelData(displayLevel);
		_isVersionLocked = false;
		bool flag = SteamAppChecker.Instance != null;
		bool flag2 = flag && SteamAppChecker.Instance.IsDemo;
		bool flag3 = levelData != null;
		bool flag4 = flag3 && levelData.availableInDemo;
		Debug.Log($"[UpgradeDetailPanel] Version Check - Controller: {flag}, IsDemo: {flag2}, LevelData: {flag3}, FullVersionOnly: {flag4}");
		if (flag2 && !flag4)
		{
			_isVersionLocked = true;
		}
		Debug.Log(string.Format("[UpgradeDetailPanel] _isVersionLocked: {0}, versionLockedGameObject: {1}", _isVersionLocked, (versionLockedGameObject != null) ? "assigned" : "NULL"));
		if (versionLockedGameObject != null)
		{
			versionLockedGameObject.SetActive(_isVersionLocked);
		}
		bool flag5 = displayLevel <= currentLevel;
		bool flag6 = displayLevel == currentLevel + 1 && UpgradeManager.Instance != null && UpgradeManager.Instance.CanUpgrade(group.upgradeType);
		bool active = !flag5 && !flag6 && !_isVersionLocked;
		_canUpgrade = flag6;
		if (upgradedButton != null)
		{
			upgradedButton.SetActive(flag5 && !_isVersionLocked);
		}
		if (unlockButtonObject != null)
		{
			unlockButtonObject.SetActive(!flag5 && flag6 && !_isVersionLocked);
		}
		if (lockedObject != null)
		{
			lockedObject.SetActive(active);
		}
	}
}
