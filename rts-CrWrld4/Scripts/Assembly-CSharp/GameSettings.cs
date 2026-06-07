public class GameSettings
{
	public static bool fullScreen;

	public static bool fullScreenExclusive;

	public static string fullScreenRes;

	public static int displayNumber;

	public static int windowWidth;

	public static int windowHeight;

	public static float soundEffectsVolume;

	public static float soundEffectsCommonVolume;

	public static float musicVolume;

	public static float menuMusicVolume;

	public static bool mute;

	public static bool muteMusic;

	public static bool muteMenuMusic;

	public static string lastLoadFileDir;

	public static float uiscale;

	public static bool uiScale2X;

	public static bool uiScaleAuto;

	public static int uiHiresSize;

	public static bool optionBloom;

	public static bool optionAmbientOcclusion;

	public static bool optionShadows;

	public static int optionAALevel;

	public static int optionFPSLevel;

	public static bool optionTerrainDetile;

	public static int sortEditor;

	public static int sortFinalized;

	public static string markVSeed;

	public static string spanLoc;

	public static string user;

	public static string mverseuser;

	public static string group;

	public static string email;

	public static string mverseHostIP;

	public static string tags;

	public static bool suppressWindowsNWarning;

	public static int miniMapSize;

	public static bool noCloseConfirmation;

	public static bool noAutoSave;

	public static bool creeperSmoothing;

	public static bool limitRecordings;

	public static int limitRecordingsCount;

	public static bool muteChatMessages;

	public static bool confirmEditor;

	public static bool topDownCam;

	public static bool hidePaths;

	public static bool flattenAC;

	public static bool transparentCreeper;

	public static bool enemyOutline;

	public static bool otherOutline;

	public static bool hideMist;

	public static bool hideUnitExplosions;

	public static bool hideMesh;

	public static bool hideShields;

	public static bool ecoSpike;

	public static bool enhanceResources;

	public static bool mapIndicator;

	public static bool hideCreeperContours;

	public static bool hideACContours;

	public static bool hoverPaths;

	public static bool hideUI;

	public static bool hideSpores;

	public static bool disableShake;

	public static bool autoCam;

	public static bool _p_topDownCam;

	public static bool _p_hidePaths;

	public static bool _p_flattenAC;

	public static bool _p_transparentCreeper;

	public static bool _p_enemyOutline;

	public static bool _p_otherOutline;

	public static bool _p_hideMist;

	public static bool _p_hideUnitExplosions;

	public static bool _p_hideMesh;

	public static bool _p_hideShields;

	public static bool _p_ecoSpike;

	public static bool _p_enhanceSpecials;

	public static bool _p_mapIndicator;

	public static bool _p_hideCreeperContours;

	public static bool _p_hideACContours;

	public static bool _p_hoverPaths;

	public static bool _p_hideUI;

	public static bool _p_hideSpores;

	public static bool _p_disableShake;

	public static bool _p_autoCam;

	public static bool mh_favoriteFilter;

	public static bool mh_inprogressFilter;

	public static bool mh_completedFilter;

	public static bool mh_notPlayedFilter;

	public static bool mh_downloadedFilter;

	public static bool mh_hiddenFilter;

	public static string mh_startNum;

	public static string mh_textTitleFilter;

	public static string mh_textAuthorFilter;

	public static string mh_textTagsFilter;

	public static bool mh_notTextTagsFilter;

	public static int mh_sortBy;

	public static bool mh_objNullifyFilter;

	public static bool mh_objTotemFilter;

	public static bool mh_objReclaimFilter;

	public static bool mh_objSurviveFilter;

	public static bool mh_objCollectFilter;

	public static bool mh_objCustomFilter;

	public static bool firstStart;

	public static int colonyID;

	public static int writeRetryCount;

	public static int networkTimeout;

	private static string fp;

	public static bool p_topDownCam
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hidePaths
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_flattenAC
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_transparentCreeper
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_enemyOutline
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_otherOutline
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideMist
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideUnitExplosions
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideMesh
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideShields
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_ecoSpike
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_enhanceSpecials
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_mapIndicator
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideCreeperContours
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideACContours
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hoverPaths
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideUI
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_hideSpores
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_disableShake
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool p_autoCam
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static void SaveTransientSettings()
	{
	}

	public static float GetUIScaleMod()
	{
		return 0f;
	}

	public static void Read()
	{
	}

	public static void Write()
	{
	}

	private static void DefaultData()
	{
	}
}
