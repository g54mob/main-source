using API;

public class ApiManager
{
	private static ApiManager _instance;

	private IApi _api;

	private bool IsLog;

	public const string PLAYERPREF_KEY = "SaveGame";

	public const string APPLICATIONPREF_KEY = "SaveApplication";

	public static ApiManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new ApiManager();
				_instance.Initialize();
			}
			return _instance;
		}
	}

	public static string GetPlayerPrefKey(int saveId)
	{
		if (saveId == 0 || saveId == 1)
		{
			return "SaveGame";
		}
		return "SaveGame_" + saveId;
	}

	public void Initialize()
	{
		Log();
	}

	public void Log()
	{
		if (!IsLog)
		{
			IsLog = true;
			if (Installation.IsSteamConnected())
			{
				_api = new Steam();
				_api.API_Log();
			}
			else if (Installation.IsNewgroundsConnected())
			{
				_api = new NewGrounds();
				_api.API_Log();
			}
			else if (Installation.IsKongregateConnected())
			{
				_api = new Kongregate();
				_api.API_Log();
			}
			else
			{
				_api = new Generic();
			}
		}
	}

	public void SetAchievement(AchievementDefinition achievement)
	{
		if (IsLog && _api != null && achievement != null)
		{
			_api.API_SendAchievement(achievement);
		}
	}

	public void SendXpInformation(int totalXp)
	{
		if (IsLog && _api != null)
		{
			_api.API_SendXpInformation(totalXp);
		}
	}

	public void SaveGame(int saveId, string gameData)
	{
		if (IsLog && _api != null)
		{
			_api.API_SaveGame(saveId, gameData);
		}
	}

	public string LoadGame(int saveId)
	{
		if (IsLog && _api != null)
		{
			return _api.API_LoadGame(saveId);
		}
		return "";
	}

	public void ClearSave(int saveId)
	{
		if (IsLog && _api != null)
		{
			_api.API_SaveGame(saveId, "");
		}
	}

	public bool HasSave(int saveId)
	{
		if (IsLog && _api != null)
		{
			return _api.API_HasSave(saveId);
		}
		return false;
	}

	public void SaveApplication(string applicationData)
	{
		if (IsLog && _api != null)
		{
			_api.API_SaveApplication(applicationData);
		}
	}

	public string LoadApplication()
	{
		if (IsLog && _api != null)
		{
			return _api.API_LoadApplication();
		}
		return "";
	}

	public bool HasApplication()
	{
		if (IsLog && _api != null)
		{
			return _api.API_HasApplicationSave();
		}
		return false;
	}

	public void API_RunCallbacks()
	{
		if (IsLog && _api != null)
		{
			_api.API_RunCallbacks();
		}
	}

	public bool OpenSteamForWishlist()
	{
		if (Installation.IsSteamConnected())
		{
			return ((Steam)_api).OpenSteamForWishlist();
		}
		return false;
	}
}
