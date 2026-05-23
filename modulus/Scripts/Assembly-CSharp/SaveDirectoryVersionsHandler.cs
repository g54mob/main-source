using Data.SaveData.PersistentSOs;
using SaveData.FactoryFloor;
using Utils;

public static class SaveDirectoryVersionsHandler
{
	public static bool CanHandle(SaveFile saveFile)
	{
		if (saveFile.Info != null && !saveFile.Info.IsSaveDirectoryOldVersion)
		{
			return true;
		}
		return false;
	}

	public static bool TryHandle(string savePath, SaveInfoPersistentSO saveInfo, out FactoryShapesSaveData factoryShapesSaveData, out FactoryFloorSaveData factoryFloorSaveData, out FactoryMapSaveData factoryMapSaveData)
	{
		factoryShapesSaveData = null;
		factoryFloorSaveData = null;
		factoryMapSaveData = null;
		if (!saveInfo.IsSaveDirectoryOldVersion)
		{
			return true;
		}
		if (saveInfo.SaveDirectoryVersion != 0)
		{
			_ = 1;
		}
		return false;
	}
}
