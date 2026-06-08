using UnityEngine;

public class SlotInfo
{
	private string finalGroupKey = string.Empty;

	private int lastGroupKeyInternalID;

	private Inventory sourceInventory;

	public DungeonInfo parent { get; set; }

	public int InternalId { get; private set; }

	public string GroupKey
	{
		get
		{
			if (!parent.TempFlagAsNursery)
			{
				if (lastGroupKeyInternalID != InternalId)
				{
					finalGroupKey = string.Format("SLOT_{0}", InternalId);
					lastGroupKeyInternalID = InternalId;
				}
				return finalGroupKey;
			}
			return string.Format("SLOTN_{0}", InternalId);
		}
	}

	public string InstalledUpgradeGroupKey
	{
		get
		{
			if (parent.Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "SLOT_INSTKEY", string.Empty);
			}
			return UniverseSaveFile.Get(GroupKey, "SLOT_INSTKEY", string.Empty);
		}
		private set
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (parent.Parent != null)
				{
					GalaxySaveFile.Save(GroupKey, "SLOT_INSTKEY", value);
				}
				else
				{
					UniverseSaveFile.Save(GroupKey, "SLOT_INSTKEY", value);
				}
			}
			else if (parent.Parent != null)
			{
				GalaxySaveFile.Clear(GroupKey, "SLOT_INSTKEY");
			}
			else
			{
				UniverseSaveFile.Clear(GroupKey, "SLOT_INSTKEY");
			}
		}
	}

	public BaseShipUpgrade InstalledUpgrade { get; private set; }

	public int SlotNumber
	{
		get
		{
			if (parent.Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "SLOTNUM", 0);
			}
			return UniverseSaveFile.Get(GroupKey, "SLOTNUM", 0);
		}
		set
		{
			if (parent.Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "SLOTNUM", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "SLOTNUM", value);
			}
		}
	}

	public BrokenStateEnum BrokenState
	{
		get
		{
			if (parent.Parent != null)
			{
				return (BrokenStateEnum)GalaxySaveFile.Get(GroupKey, "STATE", 1);
			}
			return (BrokenStateEnum)UniverseSaveFile.Get(GroupKey, "STATE", 1);
		}
		set
		{
			if (parent.Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "STATE", (int)value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "STATE", (int)value);
			}
		}
	}

	public float BreakProbability
	{
		get
		{
			if (parent.Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "BREAK_PROB", 0f);
			}
			return UniverseSaveFile.Get(GroupKey, "BREAK_PROB", 0f);
		}
		set
		{
			if (parent.Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "BREAK_PROB", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "BREAK_PROB", value);
			}
		}
	}

	public int NumMissions
	{
		get
		{
			if (parent.Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "MCOUNT", 0);
			}
			return UniverseSaveFile.Get(GroupKey, "MCOUNT", 0);
		}
		set
		{
			if (parent.Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "MCOUNT", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "MCOUNT", value);
			}
		}
	}

	private SlotInfo()
	{
	}

	public SlotInfo(DungeonInfo parent, int slotNumber, int internalIDOverride)
	{
		this.parent = parent;
		int num = internalIDOverride;
		bool flag = false;
		if (num == -1)
		{
			do
			{
				num = Random.Range(0, int.MaxValue);
				if (parent.slotList != null)
				{
					int count = parent.slotList.Count;
					for (int i = 0; i < count; i++)
					{
						if (parent.slotList[i].InternalId == num)
						{
						}
					}
					flag = true;
				}
				else
				{
					flag = true;
				}
			}
			while (!flag);
		}
		InternalId = num;
		if (parent != null && !GlobalSettings.IsTutorial)
		{
			string empty = string.Empty;
			if (((parent.Parent == null) ? UniverseSaveFile.Get(GroupKey, "P", string.Empty) : GalaxySaveFile.Get(GroupKey, "P", string.Empty)) == string.Empty)
			{
				if (parent.Parent != null)
				{
					GalaxySaveFile.Save(GroupKey, "P", parent.GroupKey);
				}
				else
				{
					UniverseSaveFile.Save(GroupKey, "P", parent.GroupKey);
				}
				ResetBrokenState(false);
			}
		}
		if (slotNumber != -1)
		{
			SlotNumber = slotNumber;
		}
	}

	public void Break()
	{
		BrokenState = BrokenStateEnum.Broken;
	}

	public void Fix()
	{
		BrokenState = BrokenStateEnum.OK;
		BreakProbability = 0f;
		NumMissions = 0;
	}

	public void InstallUpgrade(BaseShipUpgrade upgrade, Inventory sourceInventory)
	{
		InstalledUpgrade = upgrade;
		InstalledUpgradeGroupKey = upgrade.GroupKey;
		this.sourceInventory = sourceInventory;
		this.sourceInventory.AddInventoryItem(upgrade, this);
	}

	public void UnInstallUpgrade()
	{
		if (sourceInventory != null)
		{
			sourceInventory.RemoveInventoryItem(InstalledUpgrade);
		}
		InstalledUpgradeGroupKey = string.Empty;
		InstalledUpgrade = null;
		sourceInventory = null;
	}

	public void ChangeSourceInventory(Inventory newInventory)
	{
		sourceInventory = newInventory;
	}

	private void ResetBrokenState(bool isRepair)
	{
		BrokenState = BrokenStateEnum.OK;
		NumMissions = 0;
		BreakProbability = (float)NumMissions * 0f;
	}
}
