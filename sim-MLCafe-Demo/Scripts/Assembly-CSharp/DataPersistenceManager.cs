using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DataPersistenceManager : MonoBehaviour
{
	[Header("File Storage Config")]
	[SerializeField]
	private string fileName;

	[SerializeField]
	private int fileSlot;

	[SerializeField]
	private string fileExtension;

	[SerializeField]
	private string dataMetaFile = "dataHandler.data";

	private GameData gameData;

	public SaveFileMeta gameMeta;

	private List<IDataPersistence> dataPersistenceObjects;

	private FileDataHandler dataHandler;

	public static UnityEvent OnGameSaveFinished = new UnityEvent();

	private string fileToLoad;

	public static DataPersistenceManager instance { get; private set; }

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found more than one Data Persistence Manager in the scene.");
		}
		instance = this;
	}

	private void Start()
	{
		if (!(WorldTime.instance == null))
		{
			WorldTime.instance.OnFinishedLoadNewDay.AddListener(SaveGame);
			GameDataSceneHandler gameDataSceneHandler = UnityEngine.Object.FindFirstObjectByType<GameDataSceneHandler>();
			if (gameDataSceneHandler != null)
			{
				fileToLoad = gameDataSceneHandler.ReadData();
			}
			if (fileToLoad == string.Empty)
			{
				NewGame();
			}
			else
			{
				LoadGameBySaveSlot(fileToLoad);
			}
			if (gameDataSceneHandler != null)
			{
				UnityEngine.Object.Destroy(gameDataSceneHandler.gameObject);
			}
		}
	}

	public static bool IsGameVersionCompatible(string version)
	{
		if (version == Application.version)
		{
			return version != null;
		}
		return false;
	}

	public static SaveFileMeta LoadSaveFileMeta()
	{
		if (instance.dataHandler == null)
		{
			instance.dataHandler = new FileDataHandler(Application.persistentDataPath, instance.fileToLoad);
		}
		instance.gameMeta = instance.dataHandler.LoadMetaFile();
		return instance.gameMeta;
	}

	public static void LoadGameBySaveSlot(string file)
	{
		instance.fileToLoad = file;
		instance.dataHandler = new FileDataHandler(Application.persistentDataPath, instance.fileToLoad);
		instance.dataPersistenceObjects = instance.FindAllDataPersistenceObjects();
		instance.LoadGame();
	}

	public void NewGame()
	{
		gameData = new GameData();
		gameData.version = Application.version;
	}

	public void LoadGame()
	{
		if (dataHandler == null || dataHandler.GetCurrentFileName() == null)
		{
			return;
		}
		gameData = dataHandler.Load();
		if (gameData == null)
		{
			Debug.Log("No data was found. INitializing data to defaults.");
			NewGame();
			return;
		}
		foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
		{
			dataPersistenceObject.LoadData(gameData, isNewGameData: false);
		}
	}

	public void SaveGame()
	{
		if (gameData == null)
		{
			Debug.LogWarning("Could Not Save to File! >> GameData is Null!");
			OnGameSaveFinished.Invoke();
			return;
		}
		fileSlot = Mathf.Abs(gameData.id);
		string fullName = fileName + "_" + fileSlot + fileExtension;
		dataHandler = new FileDataHandler(Application.persistentDataPath, fullName);
		dataPersistenceObjects = FindAllDataPersistenceObjects();
		foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
		{
			dataPersistenceObject.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);
		gameMeta = LoadSaveFileMeta();
		gameMeta.lastPlayedFile = dataHandler.GetCurrentFileName();
		GameDataPreview gameDataPreview = gameMeta.files.Find((GameDataPreview x) => x.id == gameData.id && x.fileName == fullName);
		if (gameDataPreview == null)
		{
			gameDataPreview = new GameDataPreview();
			gameDataPreview.id = gameData.id;
			gameDataPreview.version = gameData.version;
			gameDataPreview.fileName = fullName;
			gameMeta.files.Add(gameDataPreview);
		}
		gameDataPreview.cafeName = gameData.cafeName;
		gameDataPreview.budget = gameData.budget;
		gameDataPreview.level = gameData.level;
		gameDataPreview.day = gameData.gameDate.day;
		gameDataPreview.lastPlayed = DateTime.Now.ToString();
		gameDataPreview.gamemode = gameData.gamemode;
		dataHandler.SaveDataMeta(gameMeta);
		OnGameSaveFinished.Invoke();
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		return (from x in UnityEngine.Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>()
			where x != null && !x.Equals(null)
			select x).ToList();
	}
}
