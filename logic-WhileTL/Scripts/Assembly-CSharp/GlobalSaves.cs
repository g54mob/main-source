using System.Collections.Generic;
using UnityEngine;

public class GlobalSaves
{
	public bool ForcedVisualKeyBoard;

	public bool ForcedDisableController;

	public Pair<int, int> Resolution;

	public bool FullScreen = true;

	public int user_id_ab = -1;

	public bool bigNodes = true;

	public int cohort_day;

	public int cohort_week;

	public int cohort_month;

	public bool gameBought;

	public bool showFeelSurvey;

	public bool useRandomTheme;

	public float maxLockedZoom = -1f;

	public float cursorJoyConSens = 2f;

	public bool enableLockZoom = true;

	public bool hideHomeBtnOnIphoneX;

	public bool disableVibration;

	public List<PreviewData> Preview = new List<PreviewData>();

	public List<string> unlockedMainThemes = new List<string>();

	public string activeTheme = "DEFAULT";

	public HashSet<string> gainedAchivements = new HashSet<string>();

	public List<string> unlockedPromoCats = new List<string>();

	public int newGames;

	public Dictionary<string, int> passedTasks = new Dictionary<string, int>();

	public Dictionary<string, int> passedTasksCou;

	public string version;

	public int lang;

	public float soundVolume = 0.5f;

	public float musicVolume = 1f;

	public int video;

	public int vibration = 3;

	public int flags;

	public bool showOutro;

	public bool IsSet(SaveFlags flag)
	{
		return (flags & (1 << (int)flag)) != 0;
	}

	public void Set(SaveFlags flag, bool state = true)
	{
		if (state)
		{
			flags |= 1 << (int)flag;
		}
		else
		{
			flags &= ~(1 << (int)flag);
		}
		PlayerPrefs.SetInt("WTL_options", flags);
	}
}
