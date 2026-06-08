using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class ChallengeRestorationRow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI challengeTitle;

		[SerializeField]
		private RawImage challengeThumbnail;

		[SerializeField]
		private TextMeshProUGUI levelLabel;

		[SerializeField]
		private Slider levelSlider;

		[SerializeField]
		private TextMeshProUGUI progressLabel;

		[SerializeField]
		private Slider progressSlider;

		[SerializeField]
		private RawImage rewardImageTemplate;

		[SerializeField]
		private List<RawImage> unlockedRewardImages;

		[SerializeField]
		private Sprite lockedSprite;

		private RewardTileViewer tileViewer;

		private SessionQuest challenge;

		private ChallengeRestorationScreen screen;

		private bool initialized;

		public void Setup(ChallengeRestorationScreen screen, SessionQuest sessionQuest, RewardTileViewer tileViewer)
		{
			challengeTitle.text = sessionQuest.GetTitle(1, showLevel: false);
			this.tileViewer = tileViewer;
			challenge = sessionQuest;
			this.screen = screen;
			for (int i = 0; i < sessionQuest.LevelCount; i++)
			{
				RawImage rawImage = Object.Instantiate(rewardImageTemplate, base.transform);
				rawImage.texture = tileViewer.GetRenderTexture(i, RewardState.Completed);
				unlockedRewardImages.Add(rawImage);
			}
			UpdateLevel(challenge.CurrentLevelIndex, save: false);
			UpdateProgress(challenge.GetCurrentProgress(), save: false);
			initialized = true;
		}

		public void UpdateLevelFromSlider(float sliderValue)
		{
			if (initialized)
			{
				Debug.Log($"Update Level to {sliderValue - 1f}");
				UpdateLevel(Mathf.RoundToInt(sliderValue - 1f), save: true);
			}
		}

		public void UpdateLevel(int newLevel, bool save)
		{
			newLevel = Mathf.Clamp(newLevel, -1, challenge.LevelCount);
			challenge.SetCurrentLevelIndex(newLevel);
			levelLabel.text = $"Level: {challenge.CurrentLevelIndex}/{challenge.LevelCount}";
			levelSlider.maxValue = challenge.LevelCount + 1;
			levelSlider.SetValueWithoutNotify(challenge.CurrentLevelIndex + 1);
			if (save)
			{
				UpdateProgress(0, save: true);
			}
		}

		public void UpdateProgressFromSlider(float sliderValue)
		{
			if (initialized)
			{
				UpdateProgress(Mathf.RoundToInt(sliderValue), save: true);
			}
		}

		public void UpdateProgress(int newProgress, bool save)
		{
			if (challenge.CurrentLevelIndex == -1)
			{
				newProgress = 0;
			}
			else if (challenge.CurrentLevelIndex == challenge.LevelCount)
			{
				newProgress = challenge.TargetCount();
			}
			challenge.SetCurrentProgress(newProgress);
			if (challenge.CurrentLevelIndex < challenge.LevelCount && challenge.GetCurrentProgress() >= challenge.TargetCount(challenge.CurrentLevelIndex))
			{
				UpdateLevel(challenge.CurrentLevelIndex + 1, save: true);
			}
			progressLabel.text = $"Progress: {challenge.GetCurrentProgress()} / {challenge.TargetCount()}";
			progressSlider.maxValue = challenge.TargetCount();
			progressSlider.SetValueWithoutNotify(challenge.GetCurrentProgress());
			if (challenge.CurrentLevelIndex == -1)
			{
				challengeThumbnail.texture = lockedSprite.texture;
			}
			else
			{
				challengeThumbnail.texture = tileViewer.GetRenderTexture(challenge.CurrentLevelIndex, (challenge.CurrentLevelIndex != challenge.LevelCount) ? RewardState.InProgress : RewardState.Completed);
			}
			for (int i = 0; i < challenge.LevelCount; i++)
			{
				unlockedRewardImages[i].gameObject.SetActive(challenge.CurrentLevelIndex > i);
			}
			if (save)
			{
				screen.UpdateChallengeState(challenge);
			}
		}
	}
}
