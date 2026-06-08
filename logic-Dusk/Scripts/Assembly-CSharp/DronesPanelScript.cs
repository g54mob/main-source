using UnityEngine;
using UnityEngine.UI;

public class DronesPanelScript : DronePanelUI
{
	private const int UPGRADE_SLOT_COUNT = 3;

	private float _lastHitpoints = -1f;

	private bool _wasDead;

	private bool _wasUnderPlayerControl;

	private IDrone _drone;

	private bool _initialized;

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

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		if (upgradeSlots[0] == null || upgradeSlots[1] == null || upgradeSlots[2] == null)
		{
			Debug.LogError("DronesPanelScript did not resolve all fields properly");
		}
		_initialized = true;
	}

	private void Update()
	{
		if (_drone != null)
		{
			if (_lastHitpoints != _drone.CurrentHitPoints)
			{
				SetHitpoints();
			}
			if (_wasDead != _drone.IsDead || _wasUnderPlayerControl != _drone.IsUnderPlayerControl)
			{
				SetName();
			}
			for (int i = 0; i < 3; i++)
			{
				CheckForUpdateUpgradeSlotText(i);
			}
		}
	}

	public void SetDrone(IDrone drone)
	{
		if (!_initialized)
		{
			Initialize();
		}
		_drone = drone;
		if (_drone != null)
		{
			SetName();
			SetHitpoints();
			for (int i = 0; i < 3; i++)
			{
				CheckForUpdateUpgradeSlotText(i);
			}
			return;
		}
		droneName.text = "(none)";
		droneNumber.text = "00";
		droneHP.text = "0/0";
		for (int j = 0; j < 3; j++)
		{
			upgradeSlots[j].label.text = "n/a";
		}
	}

	private void SetName()
	{
		_wasDead = _drone.IsDead;
		_wasUnderPlayerControl = _drone.IsUnderPlayerControl;
		string text = _drone.DroneName;
		Color color = Color.white;
		if (_drone.IsDead && !_drone.CanBeFullyRepaired)
		{
			color = Color.red;
			text += string.Format(" ({0})", "Destroyed");
		}
		else if (_drone.IsDead && _drone.CanBeFullyRepaired)
		{
			color = GlobalSettings.Constants.ORANGE;
			text += string.Format(" ({0})", "Disabled");
		}
		else if (!_drone.IsUnderPlayerControl)
		{
			color = Color.green;
			text = string.Format("*{0}*", text);
		}
		droneName.text = text;
		droneName.color = color;
		droneNumber.text = _drone.DroneNumber.ToString("00");
	}

	private void SetHitpoints()
	{
		_lastHitpoints = _drone.CurrentHitPoints;
		droneHP.text = _drone.CurrentHitPoints + "/" + _drone.TotalHitpoints;
	}

	private void CheckForUpdateUpgradeSlotText(int slot)
	{
		if (slot >= _drone.Upgrades.Count)
		{
			return;
		}
		BaseDroneUpgrade baseDroneUpgrade = _drone.Upgrades[slot];
		Text label = upgradeSlots[slot].label;
		string text = "---";
		if (baseDroneUpgrade != null)
		{
			text = DroneManager.GetDroneUpgradeText(baseDroneUpgrade);
		}
		if (label.text != text)
		{
			label.text = text;
		}
		if (!string.IsNullOrEmpty(text))
		{
			Color droneUpgradeStatusColor = DroneManager.GetDroneUpgradeStatusColor(baseDroneUpgrade, _drone);
			if (droneUpgradeStatusColor != label.color)
			{
				label.color = droneUpgradeStatusColor;
			}
		}
	}
}
