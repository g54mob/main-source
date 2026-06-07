using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ScoreManager : WorldManager
	{
		public int CurrentScore { get; private set; }

		public static event Action<int, int> ScoreChanged;

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.START:
				Load();
				break;
			case EWorldEvent.SAVE:
				Save();
				break;
			}
		}

		public void AddScore(int amount, string debugMessage = "")
		{
			ChangeScore(CurrentScore + amount, debugMessage);
		}

		public void ComputeFromScore(Calculation calculation, string debugMessage = "")
		{
			int newScore = Mathf.RoundToInt(calculation.ComputeValue(CurrentScore));
			ChangeScore(newScore, debugMessage);
		}

		public void GainReward(ESimulatorXPRewardEvent simulatorXpRewardEvent, int quantity = 1)
		{
			int num = CurrentScore;
			Calculation scoreRewardCalculation = ScoreSettings.GetScoreRewardCalculation(simulatorXpRewardEvent);
			for (int i = 0; i < quantity; i++)
			{
				num = Mathf.RoundToInt(scoreRewardCalculation.ComputeValue(num));
			}
			ChangeScore(num, $"Gain reward due to event {simulatorXpRewardEvent}");
		}

		protected void ChangeScore(int newScore, string debugMessage = "")
		{
			int currentScore = CurrentScore;
			if (newScore > ScoreSettings.MaxScore)
			{
				newScore = ScoreSettings.MaxScore;
			}
			else if (newScore <= ScoreSettings.MinScore)
			{
				newScore = ScoreSettings.MinScore;
			}
			CurrentScore = newScore;
			if (currentScore != CurrentScore)
			{
				ScoreManager.ScoreChanged?.Invoke(currentScore, CurrentScore);
			}
			if (ScoreSettings.ThrowDebugLogs)
			{
				Debug.Log($"{debugMessage} - Change score from {currentScore} to {CurrentScore}");
			}
		}

		private void Save()
		{
			SaveManager.CurrentSave.globalState.shopScore = CurrentScore;
		}

		private void Load()
		{
			ChangeScore(SaveManager.CurrentSave.globalState.shopScore);
		}
	}
}
