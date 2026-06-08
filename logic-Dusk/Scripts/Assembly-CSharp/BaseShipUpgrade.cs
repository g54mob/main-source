using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShipUpgrade : IBreakable, ICommandable, IInventoryItem
{
	private static System.Random _random = new System.Random();

	private string guiName = string.Empty;

	private string guiSuffix = string.Empty;

	private string _guiValue = string.Empty;

	public int Id { get; private set; }

	public string GroupKey
	{
		get
		{
			return string.Format("{0}_{1}", "INVITMS", Id);
		}
	}

	public int UsedMissionCount { get; set; }

	public int MissionCountBeforeCanBreak { get; set; }

	public int DaysTraveled { get; private set; }

	public int DaysTraveledUntilBreaks { get; set; }

	public int NumMissions { get; set; }

	public bool UsedThisMission { get; set; }

	public float BreakProbability { get; set; }

	public virtual float UpgradeBreakFactor
	{
		get
		{
			return 1f;
		}
	}

	public abstract string CommandValue { get; }

	public abstract ShipUpgradeType UpgradeType { get; }

	public abstract bool IsPermanentUpgrade { get; }

	public InventoryTypeEnum InventoryType
	{
		get
		{
			return InventoryTypeEnum.ShipUpgrade;
		}
	}

	public abstract string Name { get; }

	public virtual string Suffix
	{
		get
		{
			return string.Empty;
		}
	}

	public virtual string Description
	{
		get
		{
			return string.Empty;
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
			return "Ship";
		}
	}

	public virtual float Weight
	{
		get
		{
			return 0f;
		}
	}

	public virtual float SellValue
	{
		get
		{
			return 6f;
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
			return true;
		}
	}

	public ModificationStorageIdEnum AppliedModifications { get; set; }

	public string CommandHeader
	{
		get
		{
			return "Ship Upgrades";
		}
	}

	public bool IsPrimaryCommandContext { get; set; }

	public BrokenStateEnum BrokenState { get; private set; }

	public string RepairId
	{
		get
		{
			return Name + "_" + Id;
		}
	}

	public BaseShipUpgrade(int id)
	{
		Id = id;
		BrokenState = BrokenStateEnum.OK;
		ResetBrokenState(false);
	}

	public void Initialize()
	{
		Debug.Log("Ship upgrade is active: " + Name);
		OnInitialize();
	}

	protected virtual void OnInitialize()
	{
	}

	public void Update()
	{
		OnUpdate();
	}

	protected virtual void OnUpdate()
	{
	}

	protected virtual void ResetBrokenState(bool isRepair)
	{
		NumMissions = 0;
		BreakProbability = (float)NumMissions * 0f;
	}

	public void UpgradeUsed()
	{
		if (!UsedThisMission && !GlobalSettings.IsTutorial)
		{
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", UpgradeType), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", UpgradeType), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_SUPG_USED", UpgradeType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_SUPG_USED", UpgradeType), 0) + 1);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_SUPG_USED", UpgradeType), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_SUPG_USED", UpgradeType), num);
			}
			UsedThisMission = true;
		}
	}

	public bool AddDaysTraveled(int additionalDays)
	{
		if (BrokenState != BrokenStateEnum.Broken)
		{
			DaysTraveled += additionalDays;
			if (UsedMissionCount >= MissionCountBeforeCanBreak && DaysTraveled >= DaysTraveledUntilBreaks)
			{
				Break();
				return false;
			}
		}
		return true;
	}

	public virtual List<CommandDefinition> QueryAvailableCommands()
	{
		return new List<CommandDefinition>();
	}

	public virtual void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
	}

	public List<CommandDefinition> QueryContextCommands()
	{
		return QueryAvailableCommands();
	}

	public List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		return new List<CommandDefinition>();
	}

	protected void SendConsoleResponseMessage(string message, ConsoleMessageType messageType)
	{
		ConsoleWindow3.SendConsoleResponse(message, messageType);
	}

	public void ReduceQuality()
	{
		BrokenState = BrokenStateEnum.Broken;
	}

	public void Break()
	{
		BrokenState = BrokenStateEnum.Broken;
	}

	public bool Fix(out string fixMessage)
	{
		fixMessage = string.Empty;
		BrokenState = BrokenStateEnum.OK;
		ResetBrokenState(true);
		return true;
	}

	public void OverrideBrokenState(BrokenStateEnum state)
	{
		BrokenState = state;
	}

	public void SaveData(string parentKey, int slotNumber)
	{
		SaveData(parentKey, slotNumber, false);
	}

	public void SaveData(string parentKey, int slotNumber, bool isGalaxyData)
	{
		if (!isGalaxyData)
		{
			UniverseSaveFile.Save(GroupKey, parentKey, "TYPE", UpgradeType);
			if (slotNumber > -1)
			{
				UniverseSaveFile.Save(GroupKey, parentKey, "SLOT", slotNumber);
			}
			UniverseSaveFile.Save(GroupKey, parentKey, "INV_MISSIONS", NumMissions);
			UniverseSaveFile.Save(GroupKey, parentKey, "INV_BREAK_PROB", BreakProbability);
			if (this is IStorageUpgrade)
			{
				UniverseSaveFile.Save(GroupKey, parentKey, "QTY", ((IStorageUpgrade)this).Quantity);
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
		else
		{
			GalaxySaveFile.Save(GroupKey, parentKey, "TYPE", UpgradeType);
			GalaxySaveFile.Save(GroupKey, parentKey, "SLOT", slotNumber);
			GalaxySaveFile.Save(GroupKey, parentKey, "INV_MISSIONS", NumMissions);
			GalaxySaveFile.Save(GroupKey, parentKey, "INV_BREAK_PROB", BreakProbability);
			if (this is IStorageUpgrade)
			{
				GalaxySaveFile.Save(GroupKey, parentKey, "QTY", ((IStorageUpgrade)this).Quantity);
			}
			if (this is IBreakable)
			{
				GalaxySaveFile.Save(GroupKey, parentKey, "STATE", ((IBreakable)this).BrokenState);
			}
			if (this is IDamagableObject)
			{
				GalaxySaveFile.Save(GroupKey, parentKey, "INV_HP", ((IDamagableObject)this).CurrentHitPoints);
				GalaxySaveFile.Save(GroupKey, parentKey, "INV_HP_TOTAL", ((IDamagableObject)this).TotalHitpoints);
			}
			GalaxySaveFile.Save(GroupKey, parentKey, "INV_MODS", (int)AppliedModifications);
		}
	}
}
