using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TutorialQuest_pause", menuName = "Tower Factory/Tutorial/Pause Quest")]
public class TutorialQuestData_pause : TutorialQuestData
{
	private bool gamePaused;

	private bool gameUnpaused;

	public override string GetObjectiveText()
	{
		string text = "";
		if (gamePaused && gameUnpaused)
		{
			text += "<s>";
		}
		text += new LocalizedString("Tutorial", "Tutorial_text_pauseUnpause").GetLocalizedString();
		if (gamePaused && gameUnpaused)
		{
			text += "</s>";
		}
		return text;
	}

	public override void StartQuest()
	{
		base.StartQuest();
		gamePaused = false;
		gameUnpaused = false;
	}

	public override bool UpdateQuest()
	{
		if (!gamePaused)
		{
			if (LTFunctionLibrary.GetTimeManager().GetGameSpeed() == TimeManager.ETimeSpeed.Pause)
			{
				gamePaused = true;
				return true;
			}
		}
		else if (!gameUnpaused && LTFunctionLibrary.GetTimeManager().GetGameSpeed() == TimeManager.ETimeSpeed.Play)
		{
			gameUnpaused = true;
			return true;
		}
		return false;
	}

	public override bool IsComplete()
	{
		if (gamePaused)
		{
			return gameUnpaused;
		}
		return false;
	}
}
