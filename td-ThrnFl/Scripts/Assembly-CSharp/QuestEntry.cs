using TMPro;
using UnityEngine;

public class QuestEntry : MonoBehaviour
{
	public TextMeshProUGUI questText;

	public TextMeshProUGUI numericalCondition;

	public GameObject equippableConditionsParent;

	public QuestConditionEquippable equippableConditionPrefab;

	public CanvasGroup canvasGroup;

	public void Init(Quest data, int index, bool completed)
	{
		string text = "<style=\"Body Bold Italic\">";
		switch (index)
		{
		case 0:
			text += "A.";
			break;
		case 1:
			text += "B.";
			break;
		case 2:
			text += "C.";
			break;
		case 3:
			text += "D.";
			break;
		case 4:
			text += "E.";
			break;
		case 5:
			text += "F.";
			break;
		case 6:
			text += "G.";
			break;
		case 7:
			text += "H.";
			break;
		}
		text += " ";
		text += "<style=\"Body Light\">";
		switch (data.questType)
		{
		case Quest.EType.AchieveScoreOf:
			equippableConditionsParent.SetActive(value: false);
			numericalCondition.gameObject.SetActive(value: true);
			numericalCondition.text = data.achieveScoreOf.ToString();
			text += TextTranslator.Translate("Quests/Achieve Score");
			break;
		case Quest.EType.BeatTheLevel:
			equippableConditionsParent.SetActive(value: false);
			numericalCondition.gameObject.SetActive(value: false);
			text += TextTranslator.Translate("Quests/Achieve Victory");
			break;
		case Quest.EType.BeatTheLevelWith:
			equippableConditionsParent.SetActive(value: true);
			numericalCondition.gameObject.SetActive(value: false);
			text += TextTranslator.Translate("Quests/Achieve Victory With");
			foreach (Equippable item in data.beatTheLevelWith)
			{
				Object.Instantiate(equippableConditionPrefab, equippableConditionsParent.transform).SetData(item);
			}
			break;
		case Quest.EType.BeatTheLevelWithout:
			equippableConditionsParent.SetActive(value: true);
			numericalCondition.gameObject.SetActive(value: false);
			text += TextTranslator.Translate("Quests/Achieve Victory Without");
			foreach (Equippable item2 in data.beatTheLevelWithout)
			{
				Object.Instantiate(equippableConditionPrefab, equippableConditionsParent.transform).SetData(item2);
			}
			break;
		}
		questText.text = text;
		if (completed)
		{
			canvasGroup.alpha = 0.1f;
			questText.text = questText.text.ToUpper();
			questText.fontStyle = FontStyles.Strikethrough;
		}
	}
}
