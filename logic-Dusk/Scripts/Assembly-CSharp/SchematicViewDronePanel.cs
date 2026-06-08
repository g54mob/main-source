using UnityEngine;
using UnityEngine.UI;

public class SchematicViewDronePanel : DronePanelUI
{
	private const int UPGRADE_SLOT_COUNT = 4;

	private float _lastHitpoints = -1f;

	private bool _wasDead;

	private bool _wasUnderPlayerControl;

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

	public bool UpgradesChanged { get; set; }

	public IDrone ThisDrone { get; private set; }

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("droneNumberFrame");
		_initialized = true;
	}

	private void Update()
	{
		if (ThisDrone == null)
		{
			return;
		}
		if (_lastHitpoints != ThisDrone.CurrentHitPoints)
		{
			SetHitpoints();
		}
		if (_wasDead != ThisDrone.IsDead || _wasUnderPlayerControl != ThisDrone.IsUnderPlayerControl)
		{
			SetName();
		}
		if (UpgradesChanged)
		{
			UpgradesChanged = false;
			for (int i = 0; i < 4; i++)
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
		ThisDrone = drone;
		if (ThisDrone != null)
		{
			IsVisible = true;
			SetName();
			SetHitpoints();
			for (int i = 0; i < 4; i++)
			{
				CheckForUpdateUpgradeSlotText(i);
				if (i > drone.NumberOfUpgradeSlots - 1)
				{
					upgradeSlots[i].gameObject.SetActive(false);
					upgradeNumbers[i].gameObject.SetActive(false);
				}
				else
				{
					upgradeSlots[i].gameObject.SetActive(true);
					upgradeNumbers[i].gameObject.SetActive(true);
				}
			}
			modsText.text = ModificationsHelper.GetUpgradeIndicators(drone.AppliedModifications);
		}
		else
		{
			droneName.text = "(none)";
			droneNumber.text = "00";
			droneHP.text = "0/0";
			modsText.text = string.Empty;
			for (int j = 0; j < 4; j++)
			{
				upgradeSlots[j].label.text = "n/a";
			}
			IsVisible = false;
		}
	}

	private void SetName()
	{
		_wasDead = ThisDrone.IsDead;
		_wasUnderPlayerControl = ThisDrone.IsUnderPlayerControl;
		string text = ThisDrone.DroneName;
		Color color = Color.white;
		if (ThisDrone.IsDead && !ThisDrone.CanBeFullyRepaired)
		{
			color = Color.red;
			text += string.Format(" ({0})", "Destroyed");
		}
		else if (ThisDrone.IsDead && ThisDrone.CanBeFullyRepaired)
		{
			color = GlobalSettings.Constants.ORANGE;
			text += string.Format(" ({0})", "Disabled");
		}
		else if (!ThisDrone.IsUnderPlayerControl)
		{
			color = Color.green;
			text = string.Format("*{0}*", text);
		}
		droneName.text = text;
		droneName.color = color;
		droneNumber.text = ThisDrone.DroneNumber.ToString("00");
	}

	private void SetHitpoints()
	{
		_lastHitpoints = ThisDrone.CurrentHitPoints;
		droneHP.text = ThisDrone.CurrentHitPoints + "/" + ThisDrone.TotalHitpoints;
	}

	private void CheckForUpdateUpgradeSlotText(int slot)
	{
		if (slot >= ThisDrone.Upgrades.Count)
		{
			return;
		}
		BaseDroneUpgrade baseDroneUpgrade = ThisDrone.Upgrades[slot];
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
			Color droneUpgradeStatusColor = DroneManager.GetDroneUpgradeStatusColor(baseDroneUpgrade, ThisDrone);
			if (droneUpgradeStatusColor != label.color)
			{
				label.color = droneUpgradeStatusColor;
			}
		}
	}
}
