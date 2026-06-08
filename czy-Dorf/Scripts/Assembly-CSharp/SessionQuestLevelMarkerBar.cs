using System.Collections.Generic;
using UnityEngine;

public class SessionQuestLevelMarkerBar : MonoBehaviour
{
	[SerializeField]
	private SessionQuestLevelMarker levelMarkerPrefab;

	private List<SessionQuestLevelMarker> levelMarkers;

	private int currentlyActive;

	public void Setup(SessionQuestMenuCard sessionQuestMenuCard)
	{
		levelMarkers = new List<SessionQuestLevelMarker>();
		for (int i = 0; i < sessionQuestMenuCard.SessionQuest.LevelCount; i++)
		{
			CreateLevelMarker(sessionQuestMenuCard, i);
		}
		currentlyActive = Mathf.Clamp(sessionQuestMenuCard.SessionQuest.CurrentLevelIndex, 0, levelMarkers.Count - 1);
	}

	private void CreateLevelMarker(SessionQuestMenuCard sessionQuestMenuCard, int levelIndex)
	{
		SessionQuestLevelMarker sessionQuestLevelMarker = Object.Instantiate(levelMarkerPrefab, base.transform);
		sessionQuestLevelMarker.Setup(sessionQuestMenuCard, levelIndex);
		levelMarkers.Add(sessionQuestLevelMarker);
	}

	public void ShowLevel(int levelIndex)
	{
		foreach (SessionQuestLevelMarker levelMarker in levelMarkers)
		{
			levelMarker.UpdateState();
		}
		levelMarkers[currentlyActive].Activate(newShow: false);
		currentlyActive = Mathf.Clamp(levelIndex, 0, levelMarkers.Count - 1);
		levelMarkers[currentlyActive].Activate(newShow: true);
		levelMarkers[currentlyActive].UpdateState();
	}
}
