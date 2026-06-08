using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigUpgradeSlot : UIUpgradeSlot
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

	public bool IsEmpty { get; private set; }

	public string upgradeName { get; private set; }

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

	private new void OnDestroy()
	{
		_selectedBorder = null;
		_cursorBorder = null;
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("selectedBorder");
		if (transform != null)
		{
			_selectedBorder = transform.gameObject.GetComponent<Image>();
		}
		transform = base.transform.FindChild("cursorBorder");
		if (transform != null)
		{
			_cursorBorder = transform.gameObject.GetComponent<Image>();
		}
		if (_selectedBorder == null || _cursorBorder == null)
		{
			Debug.LogError("BoardingConfigUpgradeSlot did not resolve all fields properly");
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
			upgradeName = upgrade.CommandValue;
			text = DroneManager.GetDroneUpgradeText(upgrade);
			label.color = DroneManager.GetBasicUpgradeStatusColor(upgrade);
			IsEmpty = false;
		}
		else
		{
			upgradeName = string.Empty;
			label.color = Color.blue;
			IsEmpty = false;
		}
		label.text = text;
		address.color = label.color;
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
		Color upgradeStatus = DroneManager.GetUpgradeStatus(Upgrade, !cursorIsHere);
		label.color = upgradeStatus;
		address.color = upgradeStatus;
	}
}
