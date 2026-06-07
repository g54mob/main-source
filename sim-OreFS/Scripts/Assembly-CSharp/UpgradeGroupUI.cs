using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGroupUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI groupNameText;

	[SerializeField]
	private Image groupIcon;

	[SerializeField]
	private Transform nodeContainer;

	[SerializeField]
	private UpgradeDetailPanel detailPanel;

	private UpgradeGroupSO _group;

	private UpgradeType _upgradeType;

	private List<UpgradeNodeUI> _nodes = new List<UpgradeNodeUI>();

	public UpgradeType UpgradeType => _upgradeType;

	public static event Action<UpgradeType> OnAnyNodeClicked;

	public void Setup(UpgradeGroupSO group, int currentLevel, GameObject nodePrefab)
	{
		_group = group;
		_upgradeType = group.upgradeType;
		if (groupNameText != null)
		{
			groupNameText.text = group.UpgradeName;
		}
		if (groupIcon != null && group.icon != null)
		{
			groupIcon.sprite = group.icon;
		}
		ClearNodes();
		for (int i = 0; i < group.MaxLevel; i++)
		{
			int num = i + 1;
			bool isLastNode = i == group.MaxLevel - 1;
			UpgradeLevelData levelData = group.GetLevelData(num);
			Sprite icon = ((levelData?.levelIcon != null) ? levelData.levelIcon : group.icon);
			UpgradeNodeUI component = UnityEngine.Object.Instantiate(nodePrefab, nodeContainer).GetComponent<UpgradeNodeUI>();
			if (component != null)
			{
				component.Setup(group.upgradeType, num, currentLevel, icon, group.levelPrefixKey, isLastNode, levelData, OnNodeClicked);
				_nodes.Add(component);
			}
		}
		if (detailPanel != null)
		{
			detailPanel.Hide();
			detailPanel.SetOnUpgradeCallback(delegate(int newLevel)
			{
				UpdateLevels(newLevel);
			});
		}
		OnAnyNodeClicked += OnOtherNodeClicked;
		UpgradeManager.OnAnyUpgradeChanged = (Action<UpgradeType, int>)Delegate.Combine(UpgradeManager.OnAnyUpgradeChanged, new Action<UpgradeType, int>(OnUpgradeChanged));
	}

	private void OnUpgradeChanged(UpgradeType upgradeType, int newLevel)
	{
		if (upgradeType == _upgradeType)
		{
			UpdateLevels(newLevel);
			StartCoroutine(DelayedRefresh());
		}
	}

	private IEnumerator DelayedRefresh()
	{
		yield return null;
		if (UpgradeManager.Instance != null)
		{
			int upgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(_upgradeType);
			UpdateLevels(upgradeLevel);
		}
	}

	private void OnOtherNodeClicked(UpgradeType clickedUpgradeType)
	{
		if (clickedUpgradeType != _upgradeType && detailPanel != null)
		{
			detailPanel.Hide();
		}
	}

	public void UpdateLevels()
	{
		if (!(_group == null))
		{
			int currentLevel = 0;
			if (UpgradeManager.Instance != null)
			{
				currentLevel = UpgradeManager.Instance.GetUpgradeLevel(_upgradeType);
			}
			UpdateLevels(currentLevel);
		}
	}

	public void UpdateLevels(int currentLevel)
	{
		for (int i = 0; i < _nodes.Count; i++)
		{
			bool isLastNode = i == _nodes.Count - 1;
			_nodes[i].UpdateLevel(currentLevel, isLastNode);
		}
		if (detailPanel != null && detailPanel.IsVisible && _group != null)
		{
			detailPanel.Show(_group, currentLevel);
		}
	}

	private void OnNodeClicked(UpgradeType upgradeType, int levelIndex)
	{
		if (!(_group == null) && !(detailPanel == null))
		{
			UpgradeGroupUI.OnAnyNodeClicked?.Invoke(upgradeType);
			int currentLevel = 0;
			if (UpgradeManager.Instance != null)
			{
				currentLevel = UpgradeManager.Instance.GetUpgradeLevel(upgradeType);
			}
			UpgradeNodeUI node = null;
			int num = levelIndex - 1;
			if (num >= 0 && num < _nodes.Count)
			{
				node = _nodes[num];
			}
			detailPanel.Show(_group, currentLevel, levelIndex, node);
		}
	}

	private void ClearNodes()
	{
		foreach (UpgradeNodeUI node in _nodes)
		{
			if (node != null)
			{
				UnityEngine.Object.Destroy(node.gameObject);
			}
		}
		_nodes.Clear();
	}

	private void OnDestroy()
	{
		OnAnyNodeClicked -= OnOtherNodeClicked;
		UpgradeManager.OnAnyUpgradeChanged = (Action<UpgradeType, int>)Delegate.Remove(UpgradeManager.OnAnyUpgradeChanged, new Action<UpgradeType, int>(OnUpgradeChanged));
		ClearNodes();
	}
}
