using UnityEngine;
using UnityEngine.UI;

public class DroneSwapUpgradeSlot : UIUpgradeSlot
{
	private Image _selectedBorder;

	private Image _cursorBorder;

	private BaseDroneUpgrade _upgrade;

	private bool _initialized;

	public bool IsSelected
	{
		get
		{
			return _selectedBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsCursorHere
	{
		get
		{
			return _cursorBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	public BaseDroneUpgrade Upgrade
	{
		get
		{
			return _upgrade;
		}
	}

	protected override void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("SelectedBorder");
		if (transform != null)
		{
			_selectedBorder = transform.gameObject.GetComponent<Image>();
		}
		transform = base.transform.FindChild("CursorBorder");
		if (transform != null)
		{
			_cursorBorder = transform.gameObject.GetComponent<Image>();
		}
		if (_selectedBorder == null || _cursorBorder == null)
		{
			Debug.LogError("DroneSwapUpgradeSlot did not resolve all fields properly");
		}
		else
		{
			_selectedBorder.gameObject.SetActive(false);
			_cursorBorder.gameObject.SetActive(false);
		}
		_initialized = true;
	}

	public void SetUpgrade(BaseDroneUpgrade upgrade)
	{
		_upgrade = upgrade;
		string text = "------";
		if (upgrade != null)
		{
			text = DroneManager.GetDroneUpgradeText(upgrade);
			label.color = DroneManager.GetBasicUpgradeStatusColor(upgrade);
		}
		else
		{
			label.color = Color.blue;
		}
		label.text = text;
		if (IsCursorHere)
		{
			string hintText = string.Empty;
			if (_upgrade != null)
			{
				hintText = DroneSwapUi2.Instance.helper.FindHelpText(_upgrade.CommandValue);
			}
			DroneSwapUi2.Instance.SetHintText(hintText);
		}
		RefreshBreakStats();
	}

	public void SetIsSelected(bool isSelected)
	{
		if (!_initialized)
		{
			Initialize();
		}
		_selectedBorder.gameObject.SetActive(isSelected);
	}

	public void SetCursorHere(bool cursorIsHere)
	{
		if (!_initialized)
		{
			Initialize();
		}
		_cursorBorder.gameObject.SetActive(cursorIsHere);
		string hintText = string.Empty;
		if (_upgrade != null)
		{
			hintText = DroneSwapUi2.Instance.helper.FindHelpText(_upgrade.CommandValue);
		}
		DroneSwapUi2.Instance.SetHintText(hintText);
		RefreshBreakStats();
	}

	private void RefreshBreakStats()
	{
		if (_upgrade != null)
		{
			DroneSwapUi2.Instance.breakStats.gameObject.SetActive(true);
			DroneSwapUi2.Instance.breakStats.MissionCountLabel.text = _upgrade.NumMissions.ToString();
			DroneSwapUi2.Instance.breakStats.BreakProbabilityLabel.text = _upgrade.BreakProbability.ToString("0.00") + "%";
			Color upgradeStatus = DroneManager.GetUpgradeStatus(_upgrade, !IsCursorHere);
			if (DroneSwapUi2.Instance.breakStats.Border != null)
			{
				DroneSwapUi2.Instance.breakStats.Border.color = upgradeStatus;
			}
			DroneSwapUi2.Instance.breakStats.DescriptionLabel.color = upgradeStatus;
			DroneSwapUi2.Instance.breakStats.MissionCountLabel.color = upgradeStatus;
			DroneSwapUi2.Instance.breakStats.BreakProbabilityLabel.color = upgradeStatus;
		}
		else
		{
			DroneSwapUi2.Instance.breakStats.gameObject.SetActive(false);
		}
	}
}
