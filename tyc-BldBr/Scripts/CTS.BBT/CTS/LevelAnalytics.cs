using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

namespace CTS
{
	public class LevelAnalytics : MonoBehaviour
	{
		[SerializeField]
		private string _levelName = "Level_";

		private float _levelStartTime;

		private Dictionary<string, float> _missionsStarted = new Dictionary<string, float>();

		private void OnDisable()
		{
			GameOver.GameOverTriggered += OnGameOver;
			Quest.QuestStarted -= OnQuestStarted;
			Quest.QuestSucceeded -= OnQuestSucceeded;
			SendData();
		}

		private void OnEnable()
		{
			_levelStartTime = Time.time;
			GameOver.GameOverTriggered -= OnGameOver;
			Quest.QuestStarted += OnQuestStarted;
			Quest.QuestSucceeded += OnQuestSucceeded;
		}

		private void OnGameOver(GameOverUIData obj)
		{
			GameAnalytics.NewDesignEvent(obj.AnalyticsEvent, Time.time - _levelStartTime);
		}

		private void OnQuestStarted(Quest quest)
		{
			if (!_missionsStarted.ContainsKey(quest.QuestName))
			{
				_missionsStarted.Add(quest.QuestName, Time.time);
			}
		}

		private void OnQuestSucceeded(Quest quest)
		{
			if (_missionsStarted.ContainsKey(quest.QuestName))
			{
				float eventValue = Time.time - _missionsStarted[quest.QuestName];
				GameAnalytics.NewDesignEvent($"{_levelName}:{quest}:TimeToSucceed", eventValue);
				_missionsStarted.Remove(quest.QuestName);
			}
		}

		private void SendData()
		{
		}
	}
}
