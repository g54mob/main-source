using UnityEngine;

public class InGamePopUpHelper : MonoBehaviour
{
	public static InGamePopUpHelper instance;

	public const string SHOW_ONCE_IDENTIFIER_PREFIX = "PopupShown_";

	public InGamePopUp eternalTrialsFirstTime;

	public InGamePopUp eternalTrialsNewPatch;

	public InGamePopUp minimodesFirstTime;

	private void Awake()
	{
		instance = this;
	}

	public bool PopEternalTrials()
	{
		bool flag = false;
		bool flag2 = false;
		if (EternalTrialsRunManager.HasOngoingRun || LevelProgressManager.instance.EternalTrialsHighscore != 0)
		{
			flag = true;
			PlayerPrefs.SetInt("PopupShown_" + eternalTrialsFirstTime.identifier, 1);
		}
		if (PlayerPrefs.GetInt("PopupShown_" + eternalTrialsFirstTime.identifier) != 0)
		{
			flag = true;
		}
		else
		{
			PlayerPrefs.SetInt("PopupShown_" + eternalTrialsFirstTime.identifier, 1);
			PlayerPrefs.SetInt("PopupShown_" + eternalTrialsNewPatch.identifier, 1);
		}
		if (PlayerPrefs.GetInt("PopupShown_" + eternalTrialsNewPatch.identifier) != 0)
		{
			flag2 = true;
		}
		else
		{
			PlayerPrefs.SetInt("PopupShown_" + eternalTrialsNewPatch.identifier, 1);
		}
		if (!flag)
		{
			UIFrameManager.instance.ChangeActiveFrameKeepOldVisible(eternalTrialsFirstTime.uiFrame);
			return true;
		}
		if (!flag2)
		{
			UIFrameManager.instance.ChangeActiveFrameKeepOldVisible(eternalTrialsNewPatch.uiFrame);
			return true;
		}
		return false;
	}

	public bool PopMiniModes()
	{
		if (PlayerPrefs.GetInt("PopupShown_" + minimodesFirstTime.identifier, 0) == 0)
		{
			PlayerPrefs.SetInt("PopupShown_" + minimodesFirstTime.identifier, 1);
			UIFrameManager.instance.ChangeActiveFrameKeepOldVisible(minimodesFirstTime.uiFrame);
			return true;
		}
		return false;
	}
}
