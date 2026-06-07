using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace NewGameplayScripts
{
	public class TotalScoreCalculator : MonoBehaviour, ISavedProgressReader
	{
		[SerializeField]
		private Transform plantsParent;

		private List<Plant> plantsList = new List<Plant>();

		private int totalScore;

		public static TotalScoreCalculator Instance { get; private set; }

		public event EventHandler OnTotalScoreChanged;

		private void Awake()
		{
			Instance = this;
			totalScore = 0;
		}

		private void Start()
		{
			MovementSystem.Instance.OnStopMovingItem += CalculateScore;
			for (int i = 0; i < plantsParent.childCount; i++)
			{
				plantsList.Add(plantsParent.GetChild(i).GetComponent<Plant>());
			}
			CalculateTotalScore();
		}

		private void OnDestroy()
		{
			MovementSystem.Instance.OnStopMovingItem -= CalculateScore;
		}

		private void CalculateScore(object sender, EventArgs e)
		{
			if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				CalculateTotalScore();
				if (totalScore >= 500 && totalScore < 1000)
				{
					SteamIntegration.Instance.UnlockAchievement("SCORE500_17", 17);
				}
				if (totalScore >= 1000 && totalScore < 1500)
				{
					SteamIntegration.Instance.UnlockAchievement("SCORE1000_18", 18);
				}
				if (totalScore >= 1500)
				{
					SteamIntegration.Instance.UnlockAchievement("SCORE1500_19", 19);
				}
				this.OnTotalScoreChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void CalculateTotalScore()
		{
			totalScore = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				totalScore += item.GetScore();
			}
		}

		public int GetTotalScore()
		{
			return totalScore;
		}

		public void LoadProgress(PlayerProgress progress)
		{
			if (!progress.CreativeMode)
			{
				totalScore = progress.Score;
			}
		}
	}
}
