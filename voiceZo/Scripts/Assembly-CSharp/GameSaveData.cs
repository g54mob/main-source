using System.Collections.Generic;

public class GameSaveData
{
	public Dictionary<int, AnimalSaveData> AnimalSaveDataDict;

	public long CurrentGold;

	public SettingSaveData SettingSaveData;

	public bool IsTutorialCompleted;

	public Dictionary<int, AnimalPosSaveData> AnimalPosSaveDataDict;

	public AreaSaveData AreaSaveData;

	public CampSaveData CampSaveData;

	public CostumeSaveData CostumeSaveData;

	public GameSaveData(Dictionary<int, AnimalSaveData> animalSaveDataDict, long currentGold, SettingSaveData settingSaveData, bool isTutorialCompleted, Dictionary<int, AnimalPosSaveData> animalPosSaveDataDict, AreaSaveData areaSaveData, CampSaveData campSaveData, CostumeSaveData costumeSaveData)
	{
		AnimalSaveDataDict = animalSaveDataDict;
		CurrentGold = currentGold;
		SettingSaveData = settingSaveData;
		IsTutorialCompleted = isTutorialCompleted;
		AnimalPosSaveDataDict = animalPosSaveDataDict;
		AreaSaveData = areaSaveData;
		CampSaveData = campSaveData;
		CostumeSaveData = costumeSaveData;
	}
}
