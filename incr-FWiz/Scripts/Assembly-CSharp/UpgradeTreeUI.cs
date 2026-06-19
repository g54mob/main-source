using System.Collections.Generic;
using UnityEngine;

public class UpgradeTreeUI : MonoBehaviour
{
	[SerializeField]
	private UpgradeTreeUIUpgrade _nodeUIPrefab;

	[SerializeField]
	private UpgradeTreeUIUpgrade _keyNodeUIPrefab;

	[SerializeField]
	private UpgradeTreeUIUpgrade _rootNodeUIPrefab;

	[SerializeField]
	private Transform _upgradeParent;

	[SerializeField]
	private RectTransform _upgradeLinkPrefab;

	[SerializeField]
	private Transform _upgradeLinkParent;

	[SerializeField]
	private float _gridItemSpacing;

	[SerializeField]
	private UpgradeTreeUpgradeAnimator _slotsAnimator;

	private List<RectTransform> _upgradeSlotLinks;

	private UpgradeTreeUIUpgrade _selectedSlot;

	[SerializeField]
	public GameObject _noUpgradeTableAlert;

	private UpgradeStation _currentStation;

	private Dictionary<UpgradeDef, UpgradeTreeUIUpgrade> _uiUpgrades;

	[SerializeField]
	private BigProgressBar _progressBar;

	public List<UpgradeTreeUIUpgrade> UpgradeTreeUpgrades { get; private set; }

	private UpgradesHandler _upgradeHandler => null;

	public bool HasCurrentStation => false;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void Open(UpgradeStation upgradeStation)
	{
	}

	public void CreateOrEvaluateChildren(UpgradeTreeUIUpgrade upgradeTreeUIUpgrade)
	{
	}

	public void Close()
	{
	}

	public void TryToggle()
	{
	}

	private UpgradeTreeUIUpgrade CreateUIUpgrade(UpgradeTreeUIUpgrade parent, UpgradeInstance upgradeInstance, bool root = false)
	{
		return null;
	}

	public void OnSelectUIUpgrade(UpgradeTreeUIUpgrade upgradeSlot)
	{
	}

	public void UpdateSelectedUpgrade(UpgradeInstance instance)
	{
	}

	public void OnUpgradeCompleted(UpgradeInstance _)
	{
	}

	public void HandleProgressBar()
	{
	}
}
