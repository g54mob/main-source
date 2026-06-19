using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TooltipPlayerAvatar : Tooltip
	{
		[Serializable]
		public struct ChallengeStatusImage
		{
			[SerializeField]
			public OnlineMetadata.ChallengeStatus ChallengeStatus;

			[SerializeField]
			public Sprite ChallengeStatusIcon;
		}

		[Serializable]
		public struct ChallengeItem
		{
			[SerializeField]
			public LayoutElement ChallengeLayoutElement;

			[SerializeField]
			public Image ChallengeIconImage;

			[SerializeField]
			public TMP_Text ChallengeNameText;

			[SerializeField]
			public TMP_Text ChallengeTimeText;

			public void SetItemActive(bool active)
			{
				GameObjectUtils.SetActive(ChallengeLayoutElement.gameObject, active);
				GameObjectUtils.SetActive(ChallengeIconImage.gameObject, active);
				GameObjectUtils.SetActive(ChallengeNameText.gameObject, active);
				GameObjectUtils.SetActive(ChallengeTimeText.gameObject, active);
			}
		}

		[SerializeField]
		private TMP_Text _nameLabel;

		[SerializeField]
		private GameObject _levelInfoPanel;

		[SerializeField]
		private TMP_Text _levelInfoLabel;

		[SerializeField]
		private HospitalStarIcons _hospitalStarIcons;

		[SerializeField]
		private TMP_Text _prestigeLevelText;

		[SerializeField]
		private TMP_Text _reputationText;

		[SerializeField]
		private TMP_Text _balanceText;

		[SerializeField]
		private TMP_Text _hospitalValueText;

		[SerializeField]
		private TMP_Text _onlineStatusText;

		[SerializeField]
		private GameObject _statsPanel;

		[SerializeField]
		private GameObject _challengesPanel;

		[SerializeField]
		private ChallengeStatusImage[] _challengeImages;

		[SerializeField]
		private ChallengeItem[] _challengeItems;

		public void Setup(OnlinePlayerID onlinePlayerID, LevelConfig levelConfig, OnlineMetadataManager metadataManager, CareerStatsManager statsManager, bool showChallenge, bool showLevelInfo)
		{
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(onlinePlayerID);
			_nameLabel.text = ((playerInfo != null) ? playerInfo.DisplayName : "");
			bool flag = showLevelInfo;
			bool flag2 = false;
			if (levelConfig != null && metadataManager != null)
			{
				int num = 0;
				OnlineMetadata onlineMetadata = metadataManager.GetOnlineMetadata(onlinePlayerID);
				if (onlineMetadata != null)
				{
					showChallenge &= PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.OnlineChallenges);
					SetChallengeStatsVisible(showChallenge);
					if (showChallenge)
					{
						for (int i = 0; i < levelConfig.GetLevelScriptConfig().OnlineChallenges.Count; i++)
						{
							if (num >= _challengeItems.Length)
							{
								break;
							}
							if (levelConfig.GetLevelScriptConfig().OnlineChallenges[i].Instance is OnlineChallengeDefinition { LeaderboardName: var leaderboardName } onlineChallengeDefinition && onlineMetadata.GetChallengeScore(leaderboardName, out var score))
							{
								metadataManager.LocalPlayerData.GetChallengeScore(leaderboardName, out var score2);
								float playerScore = ((score2 == null) ? (-1f) : ((float)score2.Score));
								_challengeItems[num].SetItemActive(active: true);
								OnlineMetadata.ChallengeStatus friendOnlineChallengeStatus = OnlineMetadata.GetFriendOnlineChallengeStatus(onlinePlayerID, isChallengeFinished: true, playerScore, score.Score, score.Rivals.Contains(OnlineManager.GetLocalPlayerID()));
								_challengeItems[num].ChallengeNameText.text = $"{onlineChallengeDefinition.NameLocalised.Translation}";
								_challengeItems[num].ChallengeTimeText.text = $"{StringUtils.FormatTimeSpan(OnlineManager.GetServerTime() - score.TimeStamp)}";
								_challengeItems[num].ChallengeIconImage.sprite = GetSpriteForChallengeStatus(friendOnlineChallengeStatus);
								num++;
							}
						}
					}
					GameObjectUtils.SetActive(_hospitalStarIcons.gameObject, showLevelInfo);
					if (showLevelInfo)
					{
						if (onlineMetadata.GetStarProgress(levelConfig, out var starScore))
						{
							_hospitalStarIcons.Setup(starScore);
						}
						else
						{
							_hospitalStarIcons.Setup(0);
						}
						if (statsManager.GetFriendScore(CareerStatsManager.Type.LevelBalance, onlinePlayerID, out var score3, levelConfig))
						{
							flag2 = true;
							if (_balanceText != null)
							{
								_balanceText.text = StringUtils.FormatCurrencyWithoutSymbol(score3);
							}
						}
						if (statsManager.GetFriendScore(CareerStatsManager.Type.LevelReputation, onlinePlayerID, out var score4, levelConfig))
						{
							flag2 = true;
							if (_reputationText != null)
							{
								_reputationText.text = $"{score4}%";
							}
						}
						if (statsManager.GetFriendScore(CareerStatsManager.Type.LevelPrestige, onlinePlayerID, out var score5, levelConfig))
						{
							flag2 = true;
							if (_prestigeLevelText != null)
							{
								_prestigeLevelText.text = $"{score5}%";
							}
						}
						if (statsManager.GetFriendScore(CareerStatsManager.Type.LevelHospitalValue, onlinePlayerID, out var score6, levelConfig))
						{
							flag2 = true;
							if (_hospitalValueText != null)
							{
								_hospitalValueText.text = StringUtils.FormatCurrencyWithoutSymbol(score6);
							}
						}
						if (OnlineManager.IsInitializedAndLoggedOn())
						{
							bool flag3 = playerInfo?.IsPlayingGame() ?? false;
							_onlineStatusText.text = $"{(flag3 ? ScriptLocalization.Online.Status_Online_CS : ScriptLocalization.Online.Status_Offline_CS)}";
						}
						flag = flag && flag2;
					}
					else
					{
						SetTooltipContentsVisible(active: false);
					}
					for (int j = num; j < _challengeItems.Length; j++)
					{
						_challengeItems[j].SetItemActive(active: false);
					}
				}
				else
				{
					flag = false;
					ChallengeItem[] challengeItems = _challengeItems;
					foreach (ChallengeItem challengeItem in challengeItems)
					{
						challengeItem.SetItemActive(active: false);
					}
				}
			}
			else
			{
				flag = false;
				ChallengeItem[] challengeItems = _challengeItems;
				foreach (ChallengeItem challengeItem2 in challengeItems)
				{
					challengeItem2.SetItemActive(active: false);
				}
			}
			SetTooltipContentsVisible(flag2);
			GameObjectUtils.SetActive(_levelInfoPanel, flag);
		}

		public void SetupWithOverrideSprite(string name)
		{
			_nameLabel.text = name;
			GameObjectUtils.SetActive(_levelInfoPanel, isActive: false);
			GameObjectUtils.SetActive(_hospitalStarIcons.gameObject, isActive: false);
		}

		public Sprite GetSpriteForChallengeStatus(OnlineMetadata.ChallengeStatus status)
		{
			ChallengeStatusImage[] challengeImages = _challengeImages;
			for (int i = 0; i < challengeImages.Length; i++)
			{
				ChallengeStatusImage challengeStatusImage = challengeImages[i];
				if (challengeStatusImage.ChallengeStatus == status)
				{
					return challengeStatusImage.ChallengeStatusIcon;
				}
			}
			return null;
		}

		private void SetTooltipContentsVisible(bool active)
		{
			GameObjectUtils.SetActive(_statsPanel, active);
		}

		private void SetChallengeStatsVisible(bool active)
		{
			GameObjectUtils.SetActive(_challengesPanel, active);
		}
	}
}
