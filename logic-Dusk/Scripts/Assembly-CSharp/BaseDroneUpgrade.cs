using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDroneUpgrade : IBreakable, ICommandable, IInventoryItem
{
	private string finalGroupKey = string.Empty;

	private int lastGroupKeyInternalID;

	private static System.Random _random = new System.Random();

	private string guiName = string.Empty;

	private string guiSuffix = string.Empty;

	private string _guiValue = string.Empty;

	private string _guiInventoryType = string.Empty;

	private DroneUpgradeDefinition _definition;

	private bool _poweredUp;

	private bool _isActivated;

	protected float _abilityActivationTimeLeft;

	public Drone drone;

	private ColorBlinkManager blinkManager;

	private List<CommandDefinition> baseCommandList;

	public int Id { get; set; }

	public string GroupKey
	{
		get
		{
			if (lastGroupKeyInternalID != Id)
			{
				finalGroupKey = string.Format("{0}_{1}", "INVITMD", Id);
				lastGroupKeyInternalID = Id;
			}
			return finalGroupKey;
		}
	}

	public DroneUpgradeDefinition Definition
	{
		get
		{
			return _definition;
		}
	}

	public bool PoweredUp
	{
		get
		{
			return _poweredUp;
		}
	}

	public float CooldownTimer { get; set; }

	public bool IsActivated
	{
		get
		{
			return _isActivated;
		}
	}

	public bool IsBlinking { get; private set; }

	public Color BlinkingColor { get; private set; }

	public abstract string CommandValue { get; }

	public float TimeInMissionPostErrorMision { get; set; }

	public int NumMissions { get; set; }

	public float ErrorMissions { get; set; }

	public float ErrorTime { get; set; }

	public float BreakTime { get; set; }

	public bool UsedThisMission { get; set; }

	public float BreakProbability { get; set; }

	public virtual float UpgradeBreakFactor
	{
		get
		{
			return 1f;
		}
	}

	protected bool IsImmune { get; set; }

	public InventoryTypeEnum InventoryType
	{
		get
		{
			return InventoryTypeEnum.DroneUpgrade;
		}
	}

	public string Name
	{
		get
		{
			return Definition.Name;
		}
	}

	public string Suffix
	{
		get
		{
			string text = string.Empty;
			if (this is IStorageUpgrade)
			{
				IStorageUpgrade storageUpgrade = (IStorageUpgrade)this;
			}
			else if (this is IDamagableObject)
			{
				IDamagableObject damagableObject = (IDamagableObject)this;
				if (damagableObject.TotalHitpoints > 0f)
				{
					text += damagableObject.guiStatus;
				}
			}
			return text;
		}
	}

	public string Description
	{
		get
		{
			return Definition.Description;
		}
	}

	public string guiValue
	{
		get
		{
			if (guiName != Name || guiSuffix != Suffix)
			{
				_guiValue = string.Format("{0}{1}", Name, Suffix);
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
			if (string.IsNullOrEmpty(_guiInventoryType))
			{
				_guiInventoryType = ((InventoryType != InventoryTypeEnum.DroneUpgrade) ? "Ship" : "Drone") + " Upgrade";
			}
			return _guiInventoryType;
		}
	}

	public float Weight
	{
		get
		{
			return Definition.Weight;
		}
	}

	public virtual float SellValue
	{
		get
		{
			return Definition.Cost;
		}
	}

	public bool IsBroken
	{
		get
		{
			return BrokenState == BrokenStateEnum.Broken;
		}
	}

	public bool AgesDuringTravel
	{
		get
		{
			return false;
		}
	}

	public ModificationStorageIdEnum AppliedModifications { get; set; }

	public virtual string ModIndicator
	{
		get
		{
			return ModificationsHelper.GetUpgradeIndicators(AppliedModifications);
		}
	}

	public bool IsPrimaryCommandContext { get; set; }

	public string CommandHeader
	{
		get
		{
			return "Base";
		}
	}

	public BrokenStateEnum BrokenState { get; private set; }

	public string RepairId
	{
		get
		{
			return string.Format("{0}_{1}_{2}", CommandValue, Id, drone.RepairId);
		}
	}

	public event DroneUpgradeDelegate DroneUpgradeEvent;

	public BaseDroneUpgrade(DroneUpgradeDefinition definition)
	{
		_definition = definition;
		ResetBrokenState(false);
	}

	public bool AddDaysTraveled(int additionalDays)
	{
		return true;
	}

	public virtual bool ActivateAbility()
	{
		if (!IsImmune && (BrokenState == BrokenStateEnum.Broken || !UpgradeUsed()))
		{
			return false;
		}
		if (_isActivated)
		{
			return true;
		}
		if (Definition.ActivationDuration > 0f)
		{
			_abilityActivationTimeLeft = Definition.ActivationDuration;
		}
		_isActivated = true;
		if (this.DroneUpgradeEvent != null)
		{
			this.DroneUpgradeEvent(DroneUpgradeEventType.ActivateAbility, this);
		}
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
		return true;
	}

	public virtual void CancelAbility()
	{
		if (_isActivated)
		{
			_isActivated = false;
			if (this.DroneUpgradeEvent != null)
			{
				this.DroneUpgradeEvent(DroneUpgradeEventType.CancelAbility, this);
			}
			if (SchematicViewCanvas.Instance != null)
			{
				SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			}
			if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
		}
	}

	public virtual void PowerUp()
	{
		if (!_poweredUp && BrokenState != BrokenStateEnum.Broken)
		{
			_poweredUp = true;
			if (this.DroneUpgradeEvent != null)
			{
				this.DroneUpgradeEvent(DroneUpgradeEventType.UpgradePoweredUp, this);
			}
		}
	}

	public virtual void PowerDown()
	{
		if (_poweredUp)
		{
			if (IsActivated)
			{
				CancelAbility();
			}
			_poweredUp = false;
			if (this.DroneUpgradeEvent != null)
			{
				this.DroneUpgradeEvent(DroneUpgradeEventType.UpgradePoweredDown, this);
			}
		}
	}

	public void OnDroneUpgradeEvent(DroneUpgradeEventType upgradeType)
	{
		if (this.DroneUpgradeEvent != null)
		{
			this.DroneUpgradeEvent(upgradeType, this);
		}
	}

	public virtual void Update()
	{
		if (!GlobalSettings.IsGamePaused)
		{
			if (_abilityActivationTimeLeft > 0f)
			{
				_abilityActivationTimeLeft -= Time.deltaTime;
				if (_abilityActivationTimeLeft <= 0f)
				{
					_abilityActivationTimeLeft = 0f;
					CancelAbility();
				}
			}
			if (IsBlinking)
			{
				BlinkingColor = blinkManager.Update(Time.deltaTime);
				if (!blinkManager.IsActive)
				{
					IsBlinking = false;
					blinkManager = null;
				}
				if (GlobalSettings.cameraMode == CameraMode.Drone && DroneManager.Instance.CurrentDrone == drone && DroneManager.Instance.currentDronePanel != null)
				{
					DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
				}
			}
		}
		OnUpdate();
	}

	protected virtual void OnUpdate()
	{
	}

	public bool UpgradeUsed()
	{
		if (!UsedThisMission && !GlobalSettings.IsTutorial)
		{
			UsedThisMission = true;
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", _definition.Type), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", _definition.Type), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", _definition.Type), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", _definition.Type), 0) + 1);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", _definition.Type), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_DUPG_USED", _definition.Type), num);
			}
			Debug.Log(string.Format("Upgrade used - will suffer wear and tear at end of mission: {0}", Name));
		}
		return true;
	}

	public void StartBlinkForUI()
	{
		if (DroneManager.Instance.CurrentDrone != null)
		{
			if (blinkManager != null)
			{
				blinkManager.Stop();
			}
			blinkManager = new ColorBlinkManager();
			blinkManager.Start(DungeonManager.Instance.DVUpgradeAddedBlink, DroneManager.GetDroneUpgradeStatusColor(this, DroneManager.Instance.CurrentDrone), 0.1f, 12, false);
			IsBlinking = true;
		}
	}

	public void StopBlinkForUI()
	{
		if (blinkManager != null)
		{
			blinkManager.Stop();
			blinkManager = null;
		}
		IsBlinking = false;
	}

	public virtual void RegisterCommands()
	{
	}

	public virtual void UnRegisterCommands()
	{
	}

	public virtual List<CommandDefinition> QueryAvailableCommands()
	{
		if (baseCommandList == null)
		{
			baseCommandList = new List<CommandDefinition>();
		}
		else
		{
			baseCommandList.Clear();
		}
		return baseCommandList;
	}

	public virtual List<CommandDefinition> QueryContextCommands()
	{
		return new List<CommandDefinition>();
	}

	public virtual List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		return new List<CommandDefinition>();
	}

	public virtual void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!PoweredUp || !(this is IDropperUpgrade))
		{
			return;
		}
		IDropperUpgrade dropperUpgrade = (IDropperUpgrade)this;
		if (!(command.Command.CommandName == CommandValue))
		{
			return;
		}
		command.Handled = true;
		if (command.Arguments.Count > 0 || (command.Arguments.Count > 1 && command.Arguments[0].ToLower() == "all"))
		{
			bool flag = false;
			string empty = string.Empty;
			if (command.Arguments[0].ToLower() == "all")
			{
				flag = true;
				empty = ((command.Arguments.Count <= 1) ? "drop" : command.Arguments[1].ToLower());
			}
			else
			{
				empty = command.Arguments[0].ToLower();
			}
			if ("drop".StartsWith(empty))
			{
				dropperUpgrade.Drop();
			}
			else if ("pickup".StartsWith(empty))
			{
				dropperUpgrade.Pickup();
			}
			else if ("boom".StartsWith(empty))
			{
				dropperUpgrade.Detonate(true);
			}
			else
			{
				if (!"teleport".StartsWith(empty) || (AppliedModifications & ModificationStorageIdEnum.TeleportMod) != ModificationStorageIdEnum.TeleportMod)
				{
					return;
				}
				string text = string.Empty;
				if (!flag && command.Arguments.Count > 1)
				{
					text = command.Arguments[1].ToLower();
				}
				else if (flag && command.Arguments.Count > 2)
				{
					text = command.Arguments[2].ToLower();
				}
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				int num = DungeonManager.Instance.rooms.Length;
				for (int i = 0; i < num; i++)
				{
					if (DungeonManager.Instance.rooms[i].Label == text)
					{
						dropperUpgrade.Teleport(DungeonManager.Instance.rooms[i]);
						break;
					}
				}
			}
		}
		else
		{
			dropperUpgrade.Drop();
		}
	}

	protected void SendConsoleResponseMessage(string message, ConsoleMessageType messageType)
	{
		ConsoleWindow3.SendConsoleResponse(message, messageType);
	}

	public void NonInGameFix()
	{
		ResetBrokenState(true);
	}

	public bool Fix(out string fixMessage)
	{
		ResetBrokenState(true);
		fixMessage = string.Empty;
		PowerUp();
		return OnFixed();
	}

	public void ReduceQuality()
	{
		if (BrokenState == BrokenStateEnum.OK)
		{
			BrokenState = BrokenStateEnum.ErrorsDetected;
		}
		else
		{
			Break();
		}
	}

	public void Break()
	{
		BrokenState = BrokenStateEnum.Broken;
		PowerDown();
		OnBroken();
	}

	public void OverrideBrokenState(BrokenStateEnum state)
	{
		BrokenState = state;
	}

	protected virtual bool OnFixed()
	{
		return true;
	}

	protected virtual void OnBroken()
	{
	}

	protected virtual void ResetBrokenState(bool isRepair)
	{
		BrokenState = BrokenStateEnum.OK;
		NumMissions = 0;
		TimeInMissionPostErrorMision = 0f;
		if (!isRepair)
		{
			ErrorMissions = _random.Next(_definition.MinimumErrorMissions, _definition.MaximumErrorMissions + 1);
		}
		else
		{
			ErrorMissions = _random.Next(_definition.MinimumErrorMissionsPostRepair, _definition.MaximumErrorMissionsPostRepair + 1);
		}
		ErrorTime = _random.NextFloat(_definition.MinimumErrorTime, _definition.MaximumErrorTime);
		BreakTime = ErrorTime + _random.NextFloat(_definition.MinimumBreakTimeDelta, _definition.MaximumBreakTimeDelta);
		BreakProbability = (float)NumMissions * 0f;
	}

	public virtual void CleanUpForLeavingDungeon()
	{
		drone = null;
	}

	public void SaveData(string parentKey, int slotNumber)
	{
		UniverseSaveFile.Save(GroupKey, parentKey, "TYPE", Definition.Type);
		UniverseSaveFile.Save(GroupKey, parentKey, "SLOT", slotNumber);
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_MISSIONS", NumMissions);
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_ERROR_MISSIONS", ErrorMissions);
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_BREAK_TIME", BreakTime);
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_ERROR_TIME", ErrorTime);
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_TIME_POST_ERROR_MISSION", TimeInMissionPostErrorMision);
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_BREAK_PROB", BreakProbability);
		if (this is IStorageUpgrade)
		{
			UniverseSaveFile.Save(GroupKey, parentKey, "QTY", ((IStorageUpgrade)this).Quantity);
		}
		else if (this is IPoweredObject)
		{
			UniverseSaveFile.Save(GroupKey, parentKey, "QTY", ((IPoweredObject)this).CurrentPower);
		}
		if (this is IBreakable)
		{
			UniverseSaveFile.Save(GroupKey, parentKey, "STATE", ((IBreakable)this).BrokenState);
		}
		if (this is IDamagableObject)
		{
			UniverseSaveFile.Save(GroupKey, parentKey, "INV_HP", ((IDamagableObject)this).CurrentHitPoints);
			UniverseSaveFile.Save(GroupKey, parentKey, "INV_HP_TOTAL", ((IDamagableObject)this).TotalHitpoints);
		}
		UniverseSaveFile.Save(GroupKey, parentKey, "INV_MODS", (int)AppliedModifications);
	}
}
