using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "TutorialQuest_positionVisible", menuName = "Tower Factory/Tutorial/Position Visible Quest")]
public class TutorialQuestData_positionVisible : TutorialQuestData
{
	[SerializeField]
	private LocalizedString objectiveName;

	[SerializeField]
	private Vector3 positionToCheck;

	private bool questCompleted;

	public string ObjectiveName => objectiveName.GetLocalizedString();

	public override string GetObjectiveText()
	{
		string text = "";
		if (questCompleted)
		{
			text += "<s>";
		}
		text += LocalizationSettings.StringDatabase.GetTableEntry("Tutorial", "Tutorial_text_find").Entry.GetLocalizedString(new Dictionary<string, string> { { "name", ObjectiveName } });
		if (questCompleted)
		{
			text += "</s>";
		}
		return text;
	}

	public override void StartQuest()
	{
		base.StartQuest();
		questCompleted = false;
	}

	public override bool IsComplete()
	{
		if (LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(positionToCheck))
		{
			questCompleted = true;
			return true;
		}
		return false;
	}
}
