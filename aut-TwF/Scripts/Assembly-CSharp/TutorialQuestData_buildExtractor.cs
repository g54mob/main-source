using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TutorialQuest_buildExtractor", menuName = "Tower Factory/Tutorial/Build Extractor Quest")]
public class TutorialQuestData_buildExtractor : TutorialQuestData
{
	[SerializeField]
	public GameplayObjectData questBuildingData;

	private bool completed;

	public override string GetObjectiveText()
	{
		string text = "";
		if (completed)
		{
			text += "<s>";
		}
		text = text + new LocalizedString("Tutorial", "Tutorial_text_build").GetLocalizedString() + " " + questBuildingData.DisplayName;
		if (completed)
		{
			text += "</s>";
		}
		return text;
	}

	public override void StartQuest()
	{
		base.StartQuest();
		completed = false;
	}

	public override bool IsComplete()
	{
		if (completed)
		{
			return true;
		}
		foreach (GameplayObject playerBuilding in LTFunctionLibrary.GetPlayerData().PlayerBuildings)
		{
			if (playerBuilding.TryGetComponent<Extractor>(out var component) && component.ObjectData == questBuildingData && component.IsExtracting)
			{
				completed = true;
				return true;
			}
		}
		return false;
	}
}
