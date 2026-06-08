using System;
using System.Collections.Generic;
using System.Linq;
using BoardEditor;
using UnityEngine;

public class DungeonInfo : IDifficulty, IMetaData, IHasVideoThatCanFail
{
	private string finalGroupKey = string.Empty;

	private int lastGroupKeyInternalID;

	private bool _hasRequiredEquipment = true;

	private KeyValuePair<DungeonConfigurationManager.DungeonHelper.DungeonDefinition, DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition> _definition;

	private string _displayName = string.Empty;

	private bool _haveVisited;

	public DungeonInfoEventDelegate OnDungeonEvent;

	public List<SlotInfo> slotList;

	public StarSystemInfo Parent { get; set; }

	public int InternalId { get; private set; }

	public Inventory InstalledInventory { get; set; }

	public int Id
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "ID", 0);
			}
			return UniverseSaveFile.Get(GroupKey, "ID", 0);
		}
		set
		{
			if (value > 0)
			{
				if (Parent != null)
				{
					GalaxySaveFile.Save(GroupKey, "ID", value);
				}
				else
				{
					UniverseSaveFile.Save(GroupKey, "ID", value);
				}
			}
		}
	}

	public int Age { get; private set; }

	public string AgeText
	{
		get
		{
			string empty = string.Empty;
			if (Age <= 199)
			{
				return "stable";
			}
			if (Age <= 299)
			{
				return "volatile";
			}
			if (Age <= 399)
			{
				return "hazardous";
			}
			return "fatal";
		}
	}

	public DungeonConfigurationManager.EarlyPlayConfiguration EarlyPlayProperties { get; private set; }

	public DungeonTypeEnum DungeonType
	{
		get
		{
			if (Parent != null)
			{
				return (DungeonTypeEnum)GalaxySaveFile.Get(GroupKey, "DTYPE", 0);
			}
			return (DungeonTypeEnum)UniverseSaveFile.Get(GroupKey, "DTYPE", 0);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "DTYPE", (int)value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "DTYPE", (int)value);
			}
		}
	}

	public ShipUpgradeType FixedShipUpgradeType
	{
		get
		{
			if (Parent != null)
			{
				return (ShipUpgradeType)GalaxySaveFile.Get(GroupKey, "SHP_FXD_TYPE", 0);
			}
			return (ShipUpgradeType)UniverseSaveFile.Get(GroupKey, "SHP_FXD_TYPE", 0);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "SHP_FXD_TYPE", (int)value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "SHP_FXD_TYPE", (int)value);
			}
		}
	}

	public string Name
	{
		get
		{
			if (Parent != null)
			{
				string text = GalaxySaveFile.Get(GroupKey, "NAME", string.Empty);
				if (string.IsNullOrEmpty(text))
				{
					if (DungeonType == DungeonTypeEnum.Stargate || DungeonType == DungeonTypeEnum.AutoTrade)
					{
						string arg = (Id + UnityEngine.Random.Range(111111, 999999)).ToString("X");
						text = string.Format("{0} {1}", DungeonType, arg).ToLower();
						GalaxySaveFile.Save(GroupKey, "NAME", text);
					}
					else
					{
						text = string.Format("{0} #{1}", DungeonType, Id);
					}
				}
				return text;
			}
			string text2 = UniverseSaveFile.Get(GroupKey, "NAME", string.Empty);
			if (string.IsNullOrEmpty(text2))
			{
				text2 = string.Format("{0} #{1}", DungeonType, Id);
				if (DungeonType == DungeonTypeEnum.Stargate)
				{
					UniverseSaveFile.Save(GroupKey, "NAME", text2);
				}
			}
			return text2;
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "NAME", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "NAME", value);
			}
		}
	}

	public bool TempFlagAsNursery { get; set; }

	public string GroupKey
	{
		get
		{
			if (!TempFlagAsNursery)
			{
				if (lastGroupKeyInternalID != InternalId)
				{
					finalGroupKey = string.Format("OBJ_{0}", InternalId);
					lastGroupKeyInternalID = InternalId;
				}
				return finalGroupKey;
			}
			return string.Format("OBJN_{0}", InternalId);
		}
	}

	public string Tag
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "TAG", string.Empty);
			}
			return UniverseSaveFile.Get(GroupKey, "TAG", string.Empty);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "TAG", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "TAG", value);
			}
		}
	}

	public bool HasRequiredEquipment
	{
		get
		{
			return _hasRequiredEquipment;
		}
		set
		{
			_hasRequiredEquipment = value;
		}
	}

	public KeyValuePair<DungeonConfigurationManager.DungeonHelper.DungeonDefinition, DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition> Definition
	{
		get
		{
			return _definition;
		}
		set
		{
			_definition = value;
			_displayName = string.Empty;
			if (_definition.Key != null)
			{
				if (Parent != null)
				{
					GalaxySaveFile.Save(GroupKey, "DEFNAME", _definition.Key.name);
				}
				else
				{
					UniverseSaveFile.Save(GroupKey, "DEFNAME", _definition.Key.name);
				}
				if (Definition.Key.name == "Tech")
				{
					int num = 0;
					num++;
				}
				_displayName = Definition.Key.name;
				if (Definition.Value != null)
				{
					if (Parent != null)
					{
						GalaxySaveFile.Save(GroupKey, "DEFCLASS", Definition.Value.name);
					}
					else
					{
						UniverseSaveFile.Save(GroupKey, "DEFCLASS", Definition.Value.name);
					}
					_displayName = _displayName + " " + Definition.Value.name;
				}
				else if (Parent != null)
				{
					GalaxySaveFile.Clear(GroupKey, "DEFCLASS");
				}
				else
				{
					UniverseSaveFile.Clear(GroupKey, "DEFCLASS");
				}
			}
			else if (Parent != null)
			{
				GalaxySaveFile.Clear(GroupKey, "DEFNAME");
			}
			else
			{
				UniverseSaveFile.Clear(GroupKey, "DEFNAME");
			}
		}
	}

	public string DisplayName
	{
		get
		{
			return _displayName;
		}
	}

	public List<ShipInfestationType> InfestationType { get; private set; }

	public Vector3 Coordinates { get; set; }

	public bool HaveVisited
	{
		get
		{
			return _haveVisited;
		}
		set
		{
			_haveVisited = value;
		}
	}

	public bool WasPlayerOwned { get; set; }

	public bool HideDisplayCount { get; set; }

	public string InfestationTypeCount
	{
		get
		{
			if (HideDisplayCount)
			{
				return "??";
			}
			if (InfestationType != null)
			{
				return InfestationType.Count.ToString();
			}
			return "0";
		}
	}

	public int InfestationTypeCountValue
	{
		get
		{
			if (InfestationType != null)
			{
				return InfestationType.Count;
			}
			return 0;
		}
	}

	public int PercentComplete { get; set; }

	public int ShipUpgradeSlots
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "SLOTS", 2);
			}
			return UniverseSaveFile.Get(GroupKey, "SLOTS", 2);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "SLOTS", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "SLOTS", value);
			}
		}
	}

	public int BackgroundImageID
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "BKIMGID", -1);
			}
			return UniverseSaveFile.Get(GroupKey, "BKIMGID", -1);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "BKIMGID", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "BKIMGID", value);
			}
		}
	}

	public float OriginalDifficultyMin
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "DMIN", -1f);
			}
			return UniverseSaveFile.Get(GroupKey, "DMIN", -1f);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "DMIN", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "DMIN", value);
			}
		}
	}

	public float OriginalDifficultyMax
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "DMAX", -1f);
			}
			return UniverseSaveFile.Get(GroupKey, "DMAX", -1f);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "DMAX", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "DMAX", value);
			}
		}
	}

	public int ScrapMax
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "MAX_SCRAP", 50);
			}
			return UniverseSaveFile.Get(GroupKey, "MAX_SCRAP", 50);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "MAX_SCRAP", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "MAX_SCRAP", value);
			}
		}
	}

	public int PFuelMax
	{
		get
		{
			if (Parent != null)
			{
				return GalaxySaveFile.Get(GroupKey, "MAX_PFUEL", 6);
			}
			return UniverseSaveFile.Get(GroupKey, "MAX_PFUEL", 6);
		}
		set
		{
			if (Parent != null)
			{
				GalaxySaveFile.Save(GroupKey, "MAX_PFUEL", value);
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "MAX_PFUEL", value);
			}
		}
	}

	public string SceneName { get; set; }

	public float TimeInMission { get; set; }

	public float TimePassed
	{
		get
		{
			return TimeInMission;
		}
	}

	public bool VideoSignalLost { get; set; }

	public float TimeOfNextVideoLoss { get; set; }

	public float TimeOfNextWarningVideoLoss { get; set; }

	public float VideoLossDuration { get; set; }

	public float TimeOfNextVideoRestore { get; set; }

	public float TimeTilNextFailMin { get; set; }

	public float TimeTilNextFailMax { get; set; }

	public bool VideoSignalLostWarning { get; set; }

	public bool VideoSignalLostWarningShown { get; set; }

	public bool VideoSignalLostWarningTemp { get; set; }

	public float TimerVideoSignalLostWarning { get; set; }

	public float DifficultyFactor { get; private set; }

	public DungeonConfigurationManager.DifficultyValues CalculatedDifficultyValues { get; set; }

	public HullIntegrity HullIntegrity { get; set; }

	public VideoFailManager VideoFailManager { get; set; }

	public bool IsQuarentined { get; set; }

	public bool IsDesignedShip { get; set; }

	public TileData[,] designedShipTileData { get; set; }

	public List<IGEObject> designedBoardObjects { get; private set; }

	public List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

	protected DungeonInfo()
	{
	}

	public DungeonInfo(StarSystemInfo parentStarSysInfo, int id)
		: this(parentStarSysInfo, id, -1)
	{
	}

	public DungeonInfo(StarSystemInfo parentStarSysInfo, int id, int internalIDOverride)
	{
		Parent = parentStarSysInfo;
		bool flag = false;
		int num = internalIDOverride;
		if (num == -1)
		{
			System.Random random = new System.Random(UnityEngine.Random.seed);
			do
			{
				num = random.Next(0, int.MaxValue);
				if (parentStarSysInfo != null && parentStarSysInfo.Dungeons != null)
				{
					foreach (DungeonInfo dungeon in parentStarSysInfo.Dungeons)
					{
						if (dungeon.Id != num)
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
		if (Id == 0 && id > 0)
		{
			Id = id;
		}
		if (parentStarSysInfo != null && (parentStarSysInfo.Id > 0 || GalaxySaveFile.Get(GroupKey, "P", string.Empty) == string.Empty) && !GlobalSettings.IsTutorial)
		{
			GalaxySaveFile.Save(GroupKey, "P", parentStarSysInfo.GroupKey);
		}
		VideoFailManager = new VideoFailManager(this, 3000f, 7200f, 1200f, 2400f, 15f, 60f, 15f, 30f);
		InstalledInventory = new Inventory(10, GroupKey, true);
	}

	public void LoadSlotsFromData(int numberOfPerm)
	{
		if (ShipUpgradeSlots <= numberOfPerm)
		{
			return;
		}
		if (slotList == null)
		{
			slotList = new List<SlotInfo>();
		}
		else
		{
			slotList.Clear();
		}
		List<string> list = null;
		list = ((Parent == null) ? UniverseSaveFile.GetAllGroups("SLOT_", "P", GroupKey) : GameSaveFile.GetAllGroups("SLOT_", "P", GroupKey));
		if (list == null || list.Count == 0)
		{
			for (int i = 0; i < ShipUpgradeSlots - numberOfPerm; i++)
			{
				SlotInfo slotInfo = new SlotInfo(this, i, -1);
				if (Parent != null)
				{
					int num = (slotInfo.NumMissions = UnityEngine.Random.Range(0, 5));
					if (num > 0)
					{
						for (int j = 0; j < num; j++)
						{
							float num3 = UnityEngine.Random.Range(1.5f, 3f);
							slotInfo.BreakProbability += num3;
						}
					}
				}
				slotList.Add(slotInfo);
			}
			return;
		}
		int count = list.Count;
		SortedList<int, string> sortedList = new SortedList<int, string>();
		for (int k = 0; k < count; k++)
		{
			int key = UniverseSaveFile.Get(list[k], "SLOTNUM", -1);
			if (!sortedList.ContainsKey(key))
			{
				sortedList.Add(key, list[k]);
			}
		}
		count = sortedList.Count;
		for (int l = 0; l < count; l++)
		{
			string value = sortedList.ElementAt(l).Value;
			string[] array = value.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 2)
			{
				int result = -1;
				if (int.TryParse(array[1], out result))
				{
					SlotInfo item = new SlotInfo(this, -1, result);
					slotList.Add(item);
				}
			}
		}
	}

	public SlotInfo AddEmptySlot()
	{
		if (slotList == null)
		{
			slotList = new List<SlotInfo>();
		}
		SlotInfo slotInfo = new SlotInfo(this, slotList.Count, -1);
		slotList.Add(slotInfo);
		return slotInfo;
	}

	public int GetUsedSlotCount()
	{
		int num = 0;
		if (slotList != null && slotList.Count > 0)
		{
			int count = slotList.Count;
			for (int i = 0; i < count; i++)
			{
				if (slotList[i].InstalledUpgradeGroupKey != string.Empty)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetFreeSlotCount()
	{
		int num = 0;
		if (slotList != null && slotList.Count > 0)
		{
			int count = slotList.Count;
			for (int i = 0; i < count; i++)
			{
				if (slotList[i].InstalledUpgradeGroupKey == string.Empty)
				{
					num++;
				}
			}
		}
		return num;
	}

	public SlotInfo GetNextFreeSlot(string keyToPlace)
	{
		if (slotList != null && slotList.Count > 0)
		{
			int count = slotList.Count;
			for (int i = 0; i < count; i++)
			{
				if ((slotList[i].InstalledUpgradeGroupKey == string.Empty || slotList[i].InstalledUpgradeGroupKey == keyToPlace) && slotList[i].BrokenState == BrokenStateEnum.OK)
				{
					return slotList[i];
				}
			}
		}
		return null;
	}

	public SlotInfo GetSlotByUpgrade(BaseShipUpgrade upgrade)
	{
		if (upgrade == null)
		{
			return null;
		}
		if (slotList != null && slotList.Count > 0)
		{
			int count = slotList.Count;
			for (int i = 0; i < count; i++)
			{
				if (slotList[i].InstalledUpgradeGroupKey == upgrade.GroupKey)
				{
					return slotList[i];
				}
			}
		}
		return null;
	}

	public bool IsUpgradeOfTypeInstalledInSlot(Type type)
	{
		if (slotList != null && slotList.Count > 0)
		{
			int count = slotList.Count;
			for (int i = 0; i < count; i++)
			{
				if (slotList[i].InstalledUpgrade != null && slotList[i].InstalledUpgrade.GetType() == type)
				{
					return true;
				}
			}
		}
		return false;
	}

	public List<BaseShipUpgrade> UninstallShipUpgradesFromAllSlots()
	{
		List<BaseShipUpgrade> list = null;
		if (slotList != null && slotList.Count > 0)
		{
			int count = slotList.Count;
			for (int i = 0; i < count; i++)
			{
				if (slotList[i].InstalledUpgradeGroupKey != string.Empty)
				{
					if (list == null)
					{
						list = new List<BaseShipUpgrade>();
					}
					list.Add(slotList[i].InstalledUpgrade);
					slotList[i].UnInstallUpgrade();
				}
			}
		}
		return list;
	}

	public void SetOverrideInternalID(int newID)
	{
		InternalId = newID;
	}

	public void ClearInfestationType()
	{
		if (InfestationType != null)
		{
			InfestationType.Clear();
		}
	}

	public void AddInfestationType(ShipInfestationType infestationType)
	{
		if (InfestationType == null)
		{
			InfestationType = new List<ShipInfestationType>();
		}
		InfestationType.Add(infestationType);
		if (Parent != null)
		{
			GalaxySaveFile.Add(GroupKey, "ITYPE", infestationType.ToString());
		}
		else
		{
			UniverseSaveFile.Add(GroupKey, "ITYPE", infestationType.ToString());
		}
	}

	public void AddRangeInfestationType(List<ShipInfestationType> infestationTypeList)
	{
		if (InfestationType == null)
		{
			InfestationType = new List<ShipInfestationType>();
		}
		InfestationType.AddRange(infestationTypeList);
		int count = InfestationType.Count;
		for (int i = 0; i < count; i++)
		{
			GalaxySaveFile.Add(GroupKey, "ITYPE", InfestationType[i].ToString());
		}
	}

	public void SetDifficulty(float difficulty)
	{
		DifficultyFactor = DungeonConfigurationManager.CalculateOverallDifficulty(this);
		UpdateCommonDifficultyValues();
	}

	public void SetEarlyPlayProperties(DungeonConfigurationManager.EarlyPlayConfiguration earlyPlay)
	{
		EarlyPlayProperties = earlyPlay;
		CalculatedDifficultyValues = earlyPlay.DifficultyValues;
		DifficultyFactor = earlyPlay.DifficultyValues.GetWeightedDifficulty();
		int num = 500;
		int num2 = UnityEngine.Random.Range(earlyPlay.AgeMin, earlyPlay.AgeMax + 1);
		Age = 0 + num2;
		if (earlyPlay.IsDesignedShip)
		{
			IsDesignedShip = true;
			TextAsset textAsset = Resources.Load<TextAsset>("Data/Designed Ships/" + earlyPlay.DesignedShipFile);
			if (textAsset == null)
			{
				Debug.LogError("Could not load designed ship: " + earlyPlay.DesignedShipFile);
			}
			string text = textAsset.text;
			List<IGEObject> boardObjects = null;
			List<DesignedDungeonManager.MetaData> shipMetaData = null;
			DesignedDungeonManager.InitializeTiles();
			DesignedDungeonManager.LoadBoardFromXml(text, ref boardObjects, ref shipMetaData);
			designedShipTileData = DesignedDungeonManager.tiles;
			designedBoardObjects = boardObjects;
			metaDataList = shipMetaData;
			ScrapMax = earlyPlay.ScrapMax;
		}
	}

	public void UpdateCommonDifficultyValues(float difficultyOverride)
	{
		DifficultyFactor = difficultyOverride;
		UpdateCommonDifficultyValues();
	}

	private void UpdateCommonDifficultyValues()
	{
		int num = 500;
		int num2 = (int)((float)num * DifficultyFactor);
		Age = 0 + num2;
	}

	public string GetMetaData(string name)
	{
		if (metaDataList != null)
		{
			foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
			{
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
		}
		return string.Empty;
	}
}
