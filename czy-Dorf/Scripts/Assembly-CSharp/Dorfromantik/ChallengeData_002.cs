using System;
using UnityEngine;

namespace Dorfromantik
{
	[Serializable]
	public class ChallengeData_002 : ChallengeData
	{
		public ChallengeId id;

		public int currentLevel;

		public int currentProgress;

		public int state;

		public bool pinned;

		public ChallengeData_002(SessionQuest sessionQuest)
		{
			version = 2;
			id = sessionQuest.id;
			currentLevel = sessionQuest.CurrentLevelIndex;
			currentProgress = sessionQuest.GetCurrentProgress();
			state = (int)sessionQuest.CurrentState;
			pinned = sessionQuest.isPinned;
		}

		public ChallengeData_002(SessionQuestData oldData)
		{
			version = 2;
			id = SessionQuestData.ChallengeIdByName[oldData.id];
			currentLevel = oldData.currentLevel;
			currentProgress = oldData.currentProgress;
			state = oldData.state;
			pinned = false;
			Debug.Log($"Recreate Challenge Data: {oldData.id} -> {id}\n" + $"Level: {oldData.currentLevel} -> {currentLevel}\n" + $"Progress: {oldData.currentProgress} -> {currentProgress}\n" + $"State: {oldData.state} -> {state} ({(RewardState)oldData.state} -> {(RewardState)state})");
		}
	}
}
