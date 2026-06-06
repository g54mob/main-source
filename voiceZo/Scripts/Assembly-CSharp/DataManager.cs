using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
	private static DataManager _instance;

	private Dictionary<int, AnimalData> _animalDataDict;

	private AnimalDataSO _animalDataSO;

	private readonly string ANIMAL_DATA_SO_PATH = "Data/Animal/AnimalData";

	private Dictionary<CostumeID, CostumeData> _costumeDataDict;

	private CostumeDataSO _costumeDataSO;

	private readonly string COSTUME_DATA_SO_PATH = "Data/Costume/CostumeData";

	public static DataManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DataManager();
			}
			return _instance;
		}
	}

	public void Init()
	{
		_animalDataSO = Resources.Load<AnimalDataSO>(ANIMAL_DATA_SO_PATH);
		_animalDataDict = new Dictionary<int, AnimalData>();
		foreach (AnimalData animalData in _animalDataSO.AnimalDataList)
		{
			_animalDataDict.Add(animalData.ID, animalData);
		}
		_costumeDataSO = Resources.Load<CostumeDataSO>(COSTUME_DATA_SO_PATH);
		_costumeDataDict = new Dictionary<CostumeID, CostumeData>();
		foreach (CostumeData costumeData in _costumeDataSO.CostumeDataList)
		{
			_costumeDataDict.Add(costumeData.CostumeID, costumeData);
		}
	}

	public Dictionary<int, AnimalData> GetAnimalDataDict()
	{
		return _animalDataDict;
	}

	public string GetAnimalVoiceFileName(int animalID)
	{
		return _animalDataDict[animalID].VoiceFileName;
	}

	public CostumeData GetCostumeData(CostumeID costumeID)
	{
		if (_costumeDataDict.TryGetValue(costumeID, out var value))
		{
			return value;
		}
		Debug.LogError($"코스튬 데이터를 찾을 수 없습니다. {costumeID}");
		return null;
	}
}
