using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CreateTables : MonoBehaviour
{
	[SerializeField]
	private CallPopupCreator callNotifier;

	[SerializeField]
	private AssistantSpawner peeker;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private Settings settings;

	public static bool DEV_MODE;

	public const float DEFAULT_ASSISTANT_SPAWN_TIME = 0.5f;

	private static bool hasLoad;

	private static bool hasLoadedWebsites;

	private void Awake()
	{
		TimeKeeper.SetStartTime();
		hasLoad = Save.LoadGame();
		if (LevelManager.GetCurrLevel() > 4)
		{
			Settings.DeleteSaves();
		}
		CreateTablesHelpers.LoadNames();
		MusicManager.SetSongs(ResourcesManager.GetSongs());
		if (DEV_MODE)
		{
			Save.EraseSave();
			DatabaseUtils.DropAllTables();
		}
		CreateBuiltInTables(hasLoad);
		if (LevelManager.GetCurrLevel() == 0)
		{
			if (PlayIntroCall())
			{
				callNotifier.CreateDelayedNewMessage(3f, SpawnIntroAssistant);
			}
			else if (!settings.IsAssistantDisabled())
			{
				if (PlayTutorial())
				{
					InitializeAssistant(3f);
				}
				else
				{
					StartCoroutine(peeker.PeekRoutine());
				}
			}
		}
		else
		{
			if (!DEV_MODE && !Save.HasPlayedIntro() && LevelManager.GetCurrLevel() <= 3)
			{
				callNotifier.CreateDelayedNewMessage(3f, SpawnIntroAssistant);
			}
			if (!settings.IsAssistantDisabled())
			{
				StartCoroutine(peeker.PeekRoutine());
			}
		}
	}

	public static void LoadWebsites()
	{
		if (!hasLoadedWebsites && LevelManager.GetCurrLevel() >= 5)
		{
			hasLoadedWebsites = true;
			Level5.LoadWebsites();
			WikiLevel.LoadWebsites();
			Level8.LoadWebsites();
		}
	}

	public void SpawnIntroAssistant()
	{
		if (PlayIntroCall())
		{
			InitializeAssistant(0.5f);
		}
		Save.SetIntroPlayed();
	}

	public void InitializeAssistant(float waitTime)
	{
		StartCoroutine(assistant.Spawn(waitTime));
	}

	public static bool PlayIntroCall()
	{
		if (!DEV_MODE && LevelManager.GetCurrLevel() == 0)
		{
			return !Save.HasPlayedIntro();
		}
		return false;
	}

	public static bool PlayTutorial()
	{
		if (LevelManager.GetCurrLevel() == 0)
		{
			return !Save.HasSeenTutorial();
		}
		return false;
	}

	private void OnApplicationQuit()
	{
		if (DEV_MODE)
		{
			DatabaseUtils.DropAllTables();
		}
	}

	public static void CreateBuiltInTables(bool hasLoad)
	{
		Debug.Log($"Creating tables for level: {LevelManager.GetCurrLevel()}");
		switch (LevelManager.GetCurrLevel())
		{
		case 0:
			Level0.Create(hasLoad);
			break;
		case 1:
			Level1.Create(hasLoad);
			break;
		case 2:
			Level2.Create(hasLoad);
			break;
		case 3:
			Level3.Create(hasLoad);
			break;
		case 4:
			DatabaseUtils.DropAllTables();
			CreateCreditsTable();
			break;
		}
	}

	private static void CreateCreditsTable()
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		DatabaseUtils.CreateTable(connection, "credits", "name TEXT, role TEXT, asset_name_or_source TEXT");
		List<string[]> cSV = ResourcesManager.GetCSV("Names/credits");
		List<Credit> list = new List<Credit>();
		foreach (string[] item in cSV)
		{
			list.Add(new Credit(item[0], item[1], item[2]));
		}
		CreateTablesHelpers.PopulateTable(connection, "credits", new string[3] { "name", "role", "asset_name_or_source" }, list);
		connection.Close();
	}
}
