using UnityEngine;

public class SaveGameConverter : MonoBehaviour
{
	public const int CurrentSaveGameVersion = 3;

	public static SaveGameData UpgradeSaveGame(SaveGameData inputData)
	{
		if (inputData.version == 3)
		{
			return inputData;
		}
		SaveGameData saveGameData = inputData;
		if (saveGameData is SaveGameData_001)
		{
			saveGameData = UpgradeFrom001To002(saveGameData);
		}
		if (saveGameData is SaveGameData_002)
		{
			saveGameData = UpgradeFrom002To003(saveGameData);
		}
		return saveGameData;
	}

	private static SaveGameData_002 UpgradeFrom001To002(SaveGameData data)
	{
		return new SaveGameData_002((SaveGameData_001)data);
	}

	private static SaveGameData_003 UpgradeFrom002To003(SaveGameData data)
	{
		return new SaveGameData_003((SaveGameData_002)data);
	}

	public static SaveGameData LoadCurrentVersionSavegame(int loadVersion, string path)
	{
		SuccessStatus successStatus;
		switch (loadVersion)
		{
		case 1:
			return UpgradeSaveGame(JsonLoader.LoadJsonFromDataLocation<SaveGameData_001>(path));
		case 2:
			return UpgradeSaveGame(BinarySaveLoad.LoadFromBinary<SaveGameData_002>(path, out successStatus));
		case 3:
			return UpgradeSaveGame(BinarySaveLoad.LoadFromBinary<SaveGameData_003>(path, out successStatus));
		default:
			Debug.LogError($"SaveGame with version {loadVersion} couldn't be loaded");
			return null;
		}
	}
}
