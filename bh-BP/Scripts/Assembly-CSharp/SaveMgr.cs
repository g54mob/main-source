using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class SaveMgr : SerializedMonoBehaviour
{
	public static SaveMgr I;

	public const int kMaxSaveSlots = 9;

	[NonSerialized]
	[OdinSerialize]
	public BattleSaveData BattleSave;

	[NonSerialized]
	[OdinSerialize]
	public MetaSaveData MetaSave;

	[NonSerialized]
	[OdinSerialize]
	public SlotMetaDataList SlotDataList;

	public bool DidJustTransferDemo;

	private bool _metaDirty;

	private float _lastSaveTime;

	public DelegateUtl.NoArgsEvent OnSaveLoaded;

	public DelegateUtl.ResourceEvent OnResourcesChanged;

	public DelegateUtl.NoArgsEvent[] OnResourceChanged;

	public static string kBattleSavePath;

	public static string kBattleSaveTempPath;

	public static string kBattleSaveBackupPath;

	public static string kMetaSaveTempPath;

	public static string kMetaSavePath;

	public static string kMetaSaveBackupPath;

	private Cost _preservedBattleResources;

	private void Awake()
	{
	}

	private void LoadSlotMeta()
	{
	}

	private void LateUpdate()
	{
	}

	public string GetSlotDataPath()
	{
		return null;
	}

	public string GetMetaSavePath(int slot)
	{
		return null;
	}

	public string GetMetaSaveBackupPath(int slot)
	{
		return null;
	}

	public string GetMetaSaveTempPath(int slot)
	{
		return null;
	}

	private void OnSaveSlotChanged()
	{
	}

	public void SaveDataToPathSafe(object sav, string mainPath, string tmpPath, string backupPath)
	{
	}

	public void SaveDataToPath(object sav, string path, bool saveToCloud)
	{
	}

	public void SaveBattle()
	{
	}

	public void MarkMetaDirty()
	{
	}

	public void SaveMeta()
	{
	}

	public BattleSaveData LoadBattleAtPath(string path)
	{
		return null;
	}

	public MetaSaveData LoadMetaAtPath(string path, string backupPath)
	{
		return null;
	}

	public SlotMetaDataList LoadSlotData()
	{
		return null;
	}

	public void SaveSlotData()
	{
	}

	public bool HasBattleSaveData()
	{
		return false;
	}

	public bool LoadBattle()
	{
		return false;
	}

	public int GetMaxSlot()
	{
		return 0;
	}

	public bool HasAnyData()
	{
		return false;
	}

	public bool HasMetaInSlot(int slot)
	{
		return false;
	}

	public MetaSaveData LoadMetaInSlot(int slot)
	{
		return null;
	}

	private void FixUpLevelData(LevelData ld)
	{
	}

	public bool LoadMeta()
	{
		return false;
	}

	private void StartNewBattle()
	{
	}

	private void StartNewGame()
	{
	}

	public void PreserveBattleResources()
	{
	}

	public void ClearBattle()
	{
	}

	public void ClearBattleSavedData()
	{
	}

	public void ClearSave()
	{
	}

	public void ClearSave(int slot)
	{
	}

	public void AddMetaGold(int amt)
	{
	}

	public void SpendGold(int amt)
	{
	}

	public int GetNumGold()
	{
		return 0;
	}

	public int GetNumResources(ResourceType rt)
	{
		return 0;
	}

	public void AddResources(ResourceType rt, int amt, bool saveGame = false, bool logStats = true)
	{
	}

	public void SpendResources(ResourceType rt, int amt)
	{
	}

	public void UnlockChar(CharType ct)
	{
	}

	public void LockChar(CharType ct)
	{
	}

	public int GetNumBlueprintsAvailable()
	{
		return 0;
	}

	public bool HasBlueprint(BuildingType bt)
	{
		return false;
	}

	public void GainBlueprint(BuildingType bt)
	{
	}

	public string GetDemoSlotMetaPath()
	{
		return null;
	}

	public bool HasDemoSave()
	{
		return false;
	}

	public string GetDemoMetaSavePath(int slot)
	{
		return null;
	}

	public void TransferDemoFiles()
	{
	}

	private void TryCopyFile(string sourcePath, string destPath)
	{
	}
}
