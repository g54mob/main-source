using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NonVisualDrone : IHasHitpoints, IOverrideHitpoints, IToggleVisibilityInSchematic, IDrone, IHasVideoThatCanFail, IInventoryItem
{
	private string finalGroupKey = string.Empty;

	private int lastGroupKeyInternalID;

	private int _dvpSeed = -1;

	private string _dvpName = string.Empty;

	private float _traitVeer;

	private float _traitPermVeer;

	private float _traitPitchOffset;

	private int _csid;

	private int _droneNumber;

	private string tempDroneName = string.Empty;

	private float _originalSpeed = -1f;

	private int _numberOfUpgradeSlots = 3;

	private float _totalHitpoints = -1f;

	private float _currentHitPoints = -1f;

	private float guiHitPoints;

	private float guiSpeed;

	private string _guiDroneStatus = string.Empty;

	private int guiDaysTraveled;

	private string _guiTimeLeft = string.Empty;

	private string _guiDroneNote = string.Empty;

	private VideoFailManager _videoFailManager;

	private int lastKnownDroneNumber;

	private string lastKnownName = string.Empty;

	private string _name = string.Empty;

	private float lastknownCurrentHitPoints = -1f;

	private float lastKnownTotalHitpoints = -1f;

	private string _suffix = string.Empty;

	private string guiName = string.Empty;

	private string guiSuffix = string.Empty;

	private string _guiValue = string.Empty;

	private ModificationStorageIdEnum _appliedModifications = ModificationStorageIdEnum.Uninitialized;

	InventoryTypeEnum IInventoryItem.InventoryType
	{
		get
		{
			return InventoryTypeEnum.Drone;
		}
	}

	string IInventoryItem.GroupKey
	{
		get
		{
			return GroupKey;
		}
	}

	string IInventoryItem.Description
	{
		get
		{
			return string.Empty;
		}
	}

	float IInventoryItem.Weight
	{
		get
		{
			return 0f;
		}
	}

	float IInventoryItem.SellValue
	{
		get
		{
			return 0f;
		}
	}

	bool IInventoryItem.IsBroken
	{
		get
		{
			return CurrentHitPoints == 0f;
		}
	}

	bool IInventoryItem.AgesDuringTravel
	{
		get
		{
			Debug.LogError("AgesDuringTravel not implemented for Non-Visual Drone!!!");
			return false;
		}
	}

	ModificationStorageIdEnum IInventoryItem.AppliedModifications
	{
		get
		{
			return AppliedModifications;
		}
	}

	public string GroupKey
	{
		get
		{
			if (lastGroupKeyInternalID != InternalID)
			{
				finalGroupKey = string.Format("DRONE_{0}", InternalID);
				lastGroupKeyInternalID = InternalID;
			}
			return finalGroupKey;
		}
	}

	public DroneViewProcessor DVP { get; set; }

	public int InternalID { get; set; }

	public int DVPSeed
	{
		get
		{
			return _dvpSeed;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "DVPSEED", value);
			}
			_dvpSeed = value;
		}
	}

	public string DVPName
	{
		get
		{
			return _dvpName;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "DVPNAME", value);
			}
			_dvpName = value;
		}
	}

	public float TraitVeer
	{
		get
		{
			return _traitVeer;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "TRAIT_V", value);
			}
			_traitVeer = value;
		}
	}

	public float TraitPermVeer
	{
		get
		{
			return _traitPermVeer;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "TRAIT_VP", value);
			}
			_traitPermVeer = value;
		}
	}

	public float TraitPitchOffset
	{
		get
		{
			return _traitPitchOffset;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "TRAIT_P", value);
			}
			_traitPitchOffset = value;
		}
	}

	public int CSID
	{
		get
		{
			return _csid;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "CSID", value);
			}
			_csid = value;
		}
	}

	public int DroneNumber
	{
		get
		{
			return _droneNumber;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && InternalID != 0 && _droneNumber != 0)
			{
				UniverseSaveFile.Save(GroupKey, "NUM", value);
			}
			_droneNumber = value;
		}
	}

	public string DroneName
	{
		get
		{
			if (string.IsNullOrEmpty(tempDroneName))
			{
				return UniverseSaveFile.Get(GroupKey, "NAME", "ERROR");
			}
			return tempDroneName;
		}
		set
		{
			if (!string.IsNullOrEmpty(GroupKey))
			{
				UniverseSaveFile.Save(GroupKey, "NAME", value);
				tempDroneName = string.Empty;
			}
			else
			{
				tempDroneName = value;
			}
		}
	}

	public EngineTypeEnum engineType { get; set; }

	public int DroneVisualIndex { get; set; }

	public float OriginalSpeed
	{
		get
		{
			return _originalSpeed;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && _originalSpeed != -1f)
			{
				UniverseSaveFile.Save(GroupKey, "SPD", value);
			}
			_originalSpeed = value;
		}
	}

	public bool IsVisible { get; set; }

	public bool InterfaceDisconnected { get; set; }

	public bool CanBeFullyRepaired
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "RSTATE", false);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "RSTATE", value);
		}
	}

	public DungeonInfo DungeonLeftIn { get; set; }

	public Vector3 LastPosition { get; set; }

	public Quaternion LastRotation { get; set; }

	public List<BaseDroneUpgrade> Upgrades { get; set; }

	public int NumberOfUpgradeSlots
	{
		get
		{
			return _numberOfUpgradeSlots;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && _numberOfUpgradeSlots != 0 && !string.IsNullOrEmpty(GroupKey))
			{
				UniverseSaveFile.Save(GroupKey, "SLOTCT", value);
			}
			_numberOfUpgradeSlots = value;
		}
	}

	public bool IsUnderPlayerControl
	{
		get
		{
			return true;
		}
	}

	public float TotalHitpoints
	{
		get
		{
			return _totalHitpoints;
		}
	}

	public float CurrentHitPoints
	{
		get
		{
			return _currentHitPoints;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && _currentHitPoints != -1f)
			{
				UniverseSaveFile.Save(GroupKey, "HP", value);
			}
			_currentHitPoints = value;
		}
	}

	public bool IsDead
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "DSTATE", false);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "DSTATE", value);
			if (!value)
			{
				guiDaysTraveled = 0;
				_guiTimeLeft = string.Empty;
			}
		}
	}

	public int DaysTraveledWhileDead
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "DTRAVELED", 0);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "DTRAVELED", value);
		}
	}

	public float TimeInMission
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "MTIME", 0f);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "MTIME", value);
		}
	}

	public float TimePassed
	{
		get
		{
			return TimeInMission;
		}
	}

	public bool VideoSignalLost
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "ISFAIL", false);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "ISFAIL", value);
		}
	}

	public float TimeOfNextVideoLoss
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "FAIL_NXT", 0f);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "FAIL_NXT", value);
		}
	}

	public float TimeOfNextWarningVideoLoss { get; set; }

	public float VideoLossDuration
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "FAIL_DUR", 0f);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "FAIL_DUR", value);
		}
	}

	public float TimeOfNextVideoRestore
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "RESTORE_NXT", 0f);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "RESTORE_NXT", value);
		}
	}

	public float TimeTilNextFailMin
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "FAIL_NXT_MIN", 1200f);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "FAIL_NXT_MIN", value);
		}
	}

	public float TimeTilNextFailMax
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "FAIL_NXT_MAX", 6000f);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "FAIL_NXT_MAX", value);
		}
	}

	public string guiTimeLeft
	{
		get
		{
			if (guiDaysTraveled != DaysTraveledWhileDead)
			{
				_guiTimeLeft = string.Format("Days Left: {0}", 1 - DaysTraveledWhileDead);
				guiDaysTraveled = DaysTraveledWhileDead;
			}
			return _guiTimeLeft;
		}
	}

	public string guiDroneStatus
	{
		get
		{
			if (guiHitPoints != CurrentHitPoints || guiSpeed != OriginalSpeed)
			{
				_guiDroneStatus = "HP: " + CurrentHitPoints + ", SPD: " + OriginalSpeed;
				guiHitPoints = CurrentHitPoints;
				guiSpeed = OriginalSpeed;
			}
			return _guiDroneStatus;
		}
	}

	public string guiDroneNote
	{
		get
		{
			if (string.IsNullOrEmpty(_guiDroneNote))
			{
				_guiDroneNote = string.Format(" ({0})", DroneName);
			}
			return _guiDroneNote;
		}
	}

	public bool IsInvisibleDueToToggle { get; set; }

	public string Name
	{
		get
		{
			if (_name == string.Empty || lastKnownName != DroneName || lastKnownDroneNumber != DroneNumber)
			{
				_name = string.Format("{0} (Drone {1})", DroneName, DroneNumber);
				lastKnownName = DroneName;
				lastKnownDroneNumber = DroneNumber;
			}
			return _name;
		}
	}

	public string Suffix
	{
		get
		{
			if (lastknownCurrentHitPoints != CurrentHitPoints || lastKnownTotalHitpoints != TotalHitpoints)
			{
				_suffix = string.Format("[HP: {0}/{1}]", CurrentHitPoints, TotalHitpoints);
				lastknownCurrentHitPoints = CurrentHitPoints;
				lastKnownTotalHitpoints = TotalHitpoints;
			}
			return _suffix;
		}
	}

	public string guiValue
	{
		get
		{
			if (guiName != Name || guiSuffix != Suffix)
			{
				_guiValue = string.Format("{0} {1}", Name, Suffix);
				guiName = Name;
				guiSuffix = Suffix;
			}
			return _guiValue;
		}
	}

	public string guiInventoryType
	{
		get
		{
			return "Drone";
		}
	}

	public ModificationStorageIdEnum AppliedModifications
	{
		get
		{
			return _appliedModifications;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && _appliedModifications != ModificationStorageIdEnum.Uninitialized)
			{
				UniverseSaveFile.Save(GroupKey, "DRONE_APPLIED_MODS", (int)value);
			}
			_appliedModifications = value;
		}
	}

	public NonVisualDrone()
	{
		Upgrades = new List<BaseDroneUpgrade>();
		for (int i = 0; i < 4; i++)
		{
			Upgrades.Add(null);
		}
	}

	bool IInventoryItem.AddDaysTraveled(int additionalDays)
	{
		Debug.LogError("AddDaysTraveled not implemented for Non-Visual Drone!!!");
		return false;
	}

	public void Initalize(bool restore)
	{
		DaysTraveledWhileDead = 0;
		if (!restore)
		{
			_videoFailManager = new VideoFailManager(this, 1200f, 6000f, 900f, 1800f, 15f, 30f, 0f, 0f);
		}
		else
		{
			_videoFailManager = new VideoFailManager(this);
		}
	}

	public void ResetVideoFailureCompletely()
	{
		_videoFailManager = new VideoFailManager(this, 1200f, 6000f, 900f, 1800f, 15f, 30f, 0f, 0f);
		_videoFailManager.CalcInitialVideoSignalLossInfo();
	}

	public bool AddDroneUpgrade(BaseDroneUpgrade upgrade)
	{
		int num = 0;
		foreach (BaseDroneUpgrade upgrade2 in Upgrades)
		{
			if (num >= NumberOfUpgradeSlots)
			{
				return false;
			}
			if (upgrade2 == null)
			{
				break;
			}
			num++;
		}
		if (num < Upgrades.Count)
		{
			return AddDroneUpgrade(num, upgrade);
		}
		return false;
	}

	public bool AddDroneUpgrade(int slotNumber, BaseDroneUpgrade upgrade)
	{
		if (upgrade == null)
		{
			Debug.LogWarning("Ugrade is NULL!");
			return false;
		}
		if (Upgrades[slotNumber] != null)
		{
			RemoveDroneUpgrade(slotNumber);
		}
		Upgrades[slotNumber] = upgrade;
		upgrade.SaveData(GroupKey, slotNumber);
		return true;
	}

	public void RemoveDroneUpgrade(BaseDroneUpgrade upgrade)
	{
		int num = 0;
		foreach (BaseDroneUpgrade upgrade2 in Upgrades)
		{
			if (upgrade2 == upgrade)
			{
				break;
			}
			num++;
		}
		if (num < Upgrades.Count)
		{
			RemoveDroneUpgrade(num);
		}
	}

	public void RemoveDroneUpgrade(int slotNumber)
	{
		RemoveDroneUpgrade(slotNumber, true);
	}

	public void RemoveDroneUpgrade(int slotNumber, bool showWarnings)
	{
		if (Upgrades[slotNumber] != null)
		{
			if (showWarnings && Upgrades[slotNumber] == null)
			{
				Debug.Log("Attempting to remove an upgrade from an empty slot!!!");
				return;
			}
			UniverseSaveFile.ClearGroup(Upgrades[slotNumber].GroupKey, GroupKey);
			Upgrades[slotNumber] = null;
		}
	}

	public void RemoveAllUpgrades()
	{
		for (int i = 0; i < Upgrades.Count; i++)
		{
			RemoveDroneUpgrade(i, false);
		}
	}

	public int NumberOfUpgradesInstalled()
	{
		return Upgrades.Where((BaseDroneUpgrade x) => x != null).Count();
	}

	public void OverrideCurrentHitpoints(float hitpoints)
	{
		if (hitpoints <= TotalHitpoints)
		{
			CurrentHitPoints = hitpoints;
		}
		else
		{
			CurrentHitPoints = TotalHitpoints;
		}
		if (CurrentHitPoints > 0f && IsDead)
		{
			IsDead = false;
		}
	}

	public void OverrideTotalHitpoints(float hitpoints)
	{
		if (!GlobalSettings.IsTutorial && _totalHitpoints != -1f)
		{
			UniverseSaveFile.Save(GroupKey, "THP", hitpoints);
		}
		_totalHitpoints = hitpoints;
	}

	public void OverrideIsDead(bool isDead)
	{
		IsDead = isDead;
	}

	public bool HasUpgrade(DroneUpgradeType upgradeType)
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.Definition.Type == upgradeType)
			{
				return true;
			}
		}
		return false;
	}

	public void SetSchematicVisibility(bool show)
	{
	}
}
