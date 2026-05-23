using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestTagUI : MonoBehaviour
{
	[Header("Setup")]
	public Image completeImage;

	public Color completeColor;

	public Color incompleteColor;

	public TMP_Text description;

	public Image icon1;

	public GameObject crossedOut1;

	public Image icon2;

	public GameObject crossedOut2;

	public Image icon3;

	public GameObject crossedOut3;

	public TMP_Text goalNumber;

	[Header("Quest Texts")]
	public string completeLevel = "Achieve a victory.";

	public string achieveScoreOf = "Achieve score:";

	public string winWith = "Win with:";

	public string winWithout = "Win without:";

	public void UpdateVisualization(Quest _quest, LevelData _levelData)
	{
		if (_quest == null || _levelData == null)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: true);
		bool flag = _quest.CheckBeaten(_levelData);
		completeImage.color = (flag ? completeColor : incompleteColor);
		crossedOut1.SetActive(value: false);
		crossedOut2.SetActive(value: false);
		crossedOut3.SetActive(value: false);
		icon1.gameObject.SetActive(value: false);
		icon2.gameObject.SetActive(value: false);
		icon3.gameObject.SetActive(value: false);
		goalNumber.gameObject.SetActive(value: false);
		switch (_quest.questType)
		{
		case Quest.EType.BeatTheLevel:
			description.text = completeLevel;
			break;
		case Quest.EType.AchieveScoreOf:
			description.text = achieveScoreOf;
			goalNumber.gameObject.SetActive(value: true);
			goalNumber.text = _quest.achieveScoreOf.ToString();
			break;
		case Quest.EType.BeatTheLevelWith:
			icon1.gameObject.SetActive(_quest.beatTheLevelWith.Count > 0);
			icon2.gameObject.SetActive(_quest.beatTheLevelWith.Count > 1);
			icon3.gameObject.SetActive(_quest.beatTheLevelWith.Count > 2);
			if (_quest.beatTheLevelWith.Count > 0)
			{
				icon1.sprite = _quest.beatTheLevelWith[0].icon;
			}
			if (_quest.beatTheLevelWith.Count > 1)
			{
				icon2.sprite = _quest.beatTheLevelWith[1].icon;
			}
			if (_quest.beatTheLevelWith.Count > 2)
			{
				icon3.sprite = _quest.beatTheLevelWith[2].icon;
			}
			description.text = winWith;
			break;
		case Quest.EType.BeatTheLevelWithout:
			description.text = winWithout;
			crossedOut1.SetActive(value: true);
			crossedOut2.SetActive(value: true);
			crossedOut3.SetActive(value: true);
			icon1.gameObject.SetActive(_quest.beatTheLevelWithout.Count > 0);
			icon2.gameObject.SetActive(_quest.beatTheLevelWithout.Count > 1);
			icon3.gameObject.SetActive(_quest.beatTheLevelWithout.Count > 2);
			if (_quest.beatTheLevelWithout.Count > 0)
			{
				icon1.sprite = _quest.beatTheLevelWithout[0].icon;
			}
			if (_quest.beatTheLevelWithout.Count > 1)
			{
				icon3.sprite = _quest.beatTheLevelWithout[1].icon;
			}
			if (_quest.beatTheLevelWithout.Count > 2)
			{
				icon3.sprite = _quest.beatTheLevelWithout[2].icon;
			}
			break;
		}
	}
}
