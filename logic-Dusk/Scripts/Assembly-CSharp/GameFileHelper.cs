using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class GameFileHelper
{
	public const int ALIAS_FILE_VERSION = 1;

	private const string PRODUCT_NAME = "Duskers";

	private const string FILENAME_CONFIG = "config.txt";

	private const string FILENAME_GAMESAVE = "gamesave.txt";

	private const string FILENAME_GAMESAVE_WKLYCHALLANGE = "gamesave_ch_wkly.txt";

	private const string FILENAME_GAMESAVE_DLYCHALLANGE = "gamesave_ch_dly.txt";

	private const string FILENAME_ALIAS = "alias.txt";

	private const string FILENAME_DRONENAMEOVERRIDE = "dronenames.txt";

	private const string MY_GAMES_DIRECTORY = "My Games";

	private const string SCREENSHOT_DIRECTORY = "Screenshots";

	private const string DATA_DIRECTORY = "data";

	private const string DATA_UNIVERSE_DIRECTORY = "udata";

	private const string DATA_GALAXY_DIRECTORY = "gdata";

	private const string ARCHIVE_DIRECTORY = "archive";

	private const string SCREENSHOTS_EXTENSION = ".png";

	private const string BOARDS_DIRECTORY = "GameBoards";

	private const string INTERNAL_BOARDS_DIRECTORY = "Boards";

	private const string DEFAULT_BOARD_NAME = "--DefaultGameBoard--";

	private const string GAME_BOARD_FILE_EXTENSION = ".xml";

	private static List<UnityEngine.Object> _internalBoards;

	public static string GetBaseGameFileLocation()
	{
		string text = null;
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games");
		return Path.Combine(path, "Duskers");
	}

	public static string ConfigFileFullPath()
	{
		return Path.Combine(GetBaseGameFileLocation(), "config.txt");
	}

	public static string GameSaveFullPath(GameModeEnum mode)
	{
		switch (mode)
		{
		case GameModeEnum.Normal:
			return Path.Combine(GetBaseGameFileLocation(), "gamesave.txt");
		case GameModeEnum.WeeklyChallenge:
			return Path.Combine(GetBaseGameFileLocation(), "gamesave_ch_wkly.txt");
		case GameModeEnum.DailyChallenge:
			return Path.Combine(GetBaseGameFileLocation(), "gamesave_ch_dly.txt");
		default:
			return string.Empty;
		}
	}

	public static string AliasFullPath()
	{
		return Path.Combine(GetBaseGameFileLocation(), "alias.txt");
	}

	public static string DroneNameOverrideFullPath()
	{
		return Path.Combine(GetBaseGameFileLocation(), "dronenames.txt");
	}

	public static void EnsureGameFileDirectoriesExist()
	{
		CreateDirectory(GetBaseGameFileLocation());
		CreateDirectory(GetGameBoardLocation());
		CreateDirectory(GetDataLocation());
		CreateDirectory(GetDataUniverseLocation());
		CreateDirectory(GetDataGalaxyLocation());
	}

	public static void CreateDirectory(string directory)
	{
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
	}

	public static string GenerateUniqueScreenshotFilename()
	{
		string text = Path.Combine(GetBaseGameFileLocation(), "Screenshots");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string[] files = Directory.GetFiles(text);
		string text2 = "screenshot" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
		string text3 = text2;
		int num = 2;
		while (files.Contains(Path.Combine(text, text3 + ".png")))
		{
			text3 = string.Format("{0}({1})", text2, num++);
		}
		return Path.Combine(text, text3 + ".png");
	}

	public static string GetGameBoardLocation()
	{
		return Path.Combine(GetBaseGameFileLocation(), "GameBoards");
	}

	public static string GetArchiveLocation()
	{
		return Path.Combine(GetBaseGameFileLocation(), "archive");
	}

	public static string GetDataLocation()
	{
		return Path.Combine(GetBaseGameFileLocation(), "data");
	}

	public static string GetDataUniverseLocation()
	{
		return Path.Combine(GetDataLocation(), "udata");
	}

	public static string GetCurrentDataUniverseLocation()
	{
		string path = Path.Combine(GetDataLocation(), "udata");
		return Path.Combine(path, GameSaveFile.Get("UNIVERSE_ID", "DEFAULT"));
	}

	public static string GetDataUniverseLogLocation()
	{
		string currentDataUniverseLocation = GetCurrentDataUniverseLocation();
		return Path.Combine(currentDataUniverseLocation, "Logs");
	}

	public static string GetDataGalaxyLocation()
	{
		return Path.Combine(GetDataLocation(), "gdata");
	}

	public static string GetDefaultBoardName()
	{
		return "--DefaultGameBoard--";
	}

	public static string GetBoardFullPath(string boardName)
	{
		return Path.Combine(GetGameBoardLocation(), boardName + ".xml");
	}

	public static string GetBoardNameFromPath(string boardNameFullPath)
	{
		return Path.GetFileNameWithoutExtension(boardNameFullPath);
	}

	public static string[] ListAvailableUserGameBoardNames()
	{
		string[] files = Directory.GetFiles(GetGameBoardLocation(), "*.xml");
		string[] array = new string[files.Length];
		int num = 0;
		foreach (string item in files.OrderBy((string x) => x))
		{
			array[num++] = Path.GetFileNameWithoutExtension(item);
		}
		return array;
	}

	private static void GetInternalBoardAssets()
	{
		if (_internalBoards == null)
		{
			UnityEngine.Object[] source = Resources.LoadAll("Boards");
			_internalBoards = source.Where((UnityEngine.Object x) => x is TextAsset).ToList();
		}
	}

	public static string[] ListAvailableInternalGameBoardNames()
	{
		GetInternalBoardAssets();
		string[] array = new string[_internalBoards.Count];
		int num = 0;
		foreach (UnityEngine.Object item in _internalBoards.OrderBy((UnityEngine.Object x) => x.name))
		{
			array[num++] = GetDressedUpInternalName(item.name);
		}
		return array;
	}

	private static string GetDressedUpInternalName(string boardName)
	{
		return "--" + boardName + "--";
	}

	public static bool GetInternalBoardXml(string boardName, out string boardXml)
	{
		boardXml = string.Empty;
		GetInternalBoardAssets();
		TextAsset textAsset = _internalBoards.FirstOrDefault((UnityEngine.Object x) => GetDressedUpInternalName(x.name) == boardName) as TextAsset;
		if (textAsset != null)
		{
			boardXml = textAsset.text;
			return true;
		}
		return false;
	}

	public static GUIContent[] GetBoardFilesAsGuiContent()
	{
		string[] array = ListAvailableInternalGameBoardNames();
		string[] array2 = ListAvailableUserGameBoardNames();
		int num = array.Length + array2.Length;
		GUIContent[] array3 = new GUIContent[num];
		int num2 = 0;
		string[] array4 = array;
		foreach (string text in array4)
		{
			array3[num2++] = new GUIContent(text);
		}
		string[] array5 = array2;
		foreach (string text2 in array5)
		{
			array3[num2++] = new GUIContent(text2);
		}
		return array3;
	}
}
