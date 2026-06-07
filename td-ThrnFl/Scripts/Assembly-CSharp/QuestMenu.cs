using System.Collections.Generic;
using UnityEngine;

public class QuestMenu : MonoBehaviour
{
	public void UpdateVisualization(LevelData _levelData, List<Quest> _quests)
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			QuestTagUI component = base.transform.GetChild(i).GetComponent<QuestTagUI>();
			if (i < _quests.Count)
			{
				component.UpdateVisualization(_quests[i], _levelData);
			}
			else
			{
				component.UpdateVisualization(null, null);
			}
		}
	}
}
