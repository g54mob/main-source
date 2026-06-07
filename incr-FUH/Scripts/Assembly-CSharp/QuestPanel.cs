using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
	public QuestItem QuestTemplate;

	public TMP_Text QuestTotal;

	public TMP_Text QuestNotClaimed;

	private List<QuestItem> _quests = new List<QuestItem>();

	private void Start()
	{
		foreach (AchievementDefinition achievement in GameController.Instance.Achievements)
		{
			if (!achievement.IsHidden && achievement.IsVisible())
			{
				_quests.Add(CreateItem(achievement));
			}
		}
		foreach (AchievementDefinition achievement2 in GameController.Instance.Achievements)
		{
			if (!achievement2.IsHidden && !achievement2.IsVisible())
			{
				_quests.Add(CreateItem(achievement2));
			}
		}
		QuestTemplate.gameObject.SetActive(value: false);
	}

	private QuestItem CreateItem(AchievementDefinition ad)
	{
		QuestItem questItem = Object.Instantiate(QuestTemplate, QuestTemplate.transform.parent);
		questItem.Achievement = ad;
		questItem.Refresh();
		questItem.gameObject.SetActive(value: true);
		return questItem;
	}

	private void FixedUpdate()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (AchievementDefinition achievement in GameController.Instance.Achievements)
		{
			if (!achievement.IsHidden)
			{
				if (achievement.CanActivate && !achievement.IsActivated)
				{
					num3++;
				}
				if (achievement.IsActivated)
				{
					num2++;
				}
				num++;
			}
		}
		if (num3 > 0)
		{
			QuestNotClaimed.gameObject.SetActive(value: true);
		}
		else
		{
			QuestNotClaimed.gameObject.SetActive(value: false);
		}
		QuestTotal.text = num2 + "/" + num;
	}
}
