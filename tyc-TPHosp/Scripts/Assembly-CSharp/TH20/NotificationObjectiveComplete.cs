using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using UnityEngine.Video;

namespace TH20
{
	public class NotificationObjectiveComplete : NotificationMessage
	{
		private readonly string _scoreText;

		private readonly string _cachedLocalisedRewardTextWithObjective;

		private readonly string _cachedLocalisedRewardTextWithPrefix;

		private readonly string _cachedLocalisedRewardTextWithNeither;

		private bool _isCollaborativePortfolioReward;

		private bool _isSandboxReward;

		private bool _isFinalReward;

		private int _cashReward;

		private int _silverReward;

		private float _reputationReward;

		private float _researchPointsReward;

		private readonly List<SharedInstance<RoomDefinition>> _roomsUnlocked = new List<SharedInstance<RoomDefinition>>();

		private readonly List<SharedInstance<RoomItemDefinition>> _roomItemsUnlocked = new List<SharedInstance<RoomItemDefinition>>();

		private readonly List<SharedInstance<RoomItemUpgradeDefinition>> _roomItemUpgradesUnlocked = new List<SharedInstance<RoomItemUpgradeDefinition>>();

		private readonly VideoClip _videoToPlayAfterNotification;

		private readonly string _audioToPlayAfterNotification;

		private readonly bool _notificationAudioExclusiveMode;

		public bool IsCollaborativePortfolioReward => _isCollaborativePortfolioReward;

		public bool IsSandboxReward => _isSandboxReward;

		public bool IsFinalReward => _isFinalReward;

		public int CashReward => _cashReward;

		public int SilverReward => _silverReward;

		public float ReputationReward => _reputationReward;

		public float ResearchPointsReward => _researchPointsReward;

		public IReadOnlyList<SharedInstance<RoomDefinition>> RoomsUnlocked => _roomsUnlocked.AsReadOnly();

		public IReadOnlyList<SharedInstance<RoomItemDefinition>> RoomItemsUnlocked => _roomItemsUnlocked.AsReadOnly();

		public IReadOnlyList<SharedInstance<RoomItemUpgradeDefinition>> RoomItemUpgradesUnlocked => _roomItemUpgradesUnlocked.AsReadOnly();

		public VideoClip VideoToPlayAfter => _videoToPlayAfterNotification;

		public string AudioToPlayAfter => _audioToPlayAfterNotification;

		public bool NotificationAudioExclusiveMode => _notificationAudioExclusiveMode;

		public NotificationObjectiveComplete(NotificationMessages.Definition definition, IReward[] rewards, string scoreText, ResponseDelegate responseDelegate, Level level, Objective objective)
			: base(definition, level)
		{
			_scoreText = scoreText;
			_delegate = responseDelegate;
			_cachedLocalisedRewardTextWithObjective = GenerateRewardText(rewards, objective);
			_cachedLocalisedRewardTextWithPrefix = GenerateRewardText(rewards, objective, addPrefix: true, includeObjective: false);
			_cachedLocalisedRewardTextWithNeither = GenerateRewardText(rewards, objective, addPrefix: false, includeObjective: false);
			_videoToPlayAfterNotification = definition.VideoToPlayAfterMessage;
			_audioToPlayAfterNotification = definition.AudioToPlayAfterMessage;
			_notificationAudioExclusiveMode = definition.NotificationAudioExclusiveMode;
			ProcessRewards(rewards);
		}

		public override Character GetCharacter()
		{
			return null;
		}

		public string GetScoreText()
		{
			return _scoreText;
		}

		public string GetRewardText(bool addPrefix = true, bool includeObjective = true)
		{
			if (_cachedLocalisedRewardTextWithObjective != null && _cachedLocalisedRewardTextWithPrefix != null && _cachedLocalisedRewardTextWithNeither != null)
			{
				if (includeObjective && _cachedLocalisedRewardTextWithObjective != null)
				{
					return _cachedLocalisedRewardTextWithObjective;
				}
				if (addPrefix)
				{
					return _cachedLocalisedRewardTextWithPrefix;
				}
				return _cachedLocalisedRewardTextWithNeither;
			}
			return string.Empty;
		}

		public static string GenerateRewardText(IReward[] rewards, Objective objective, bool addPrefix = true, bool includeObjective = true)
		{
			if (rewards != null && rewards.Length != 0)
			{
				if (includeObjective && objective != null)
				{
					return objective.Definition.GetDescriptionString(objective, rewards);
				}
				string fullRewardString = RewardUtils.GetFullRewardString(null, rewards);
				if (addPrefix)
				{
					return ScriptLocalization.Notification.Challenge_ChallengeText_CS.Replace("{[REWARDS]}", fullRewardString);
				}
				return fullRewardString;
			}
			return string.Empty;
		}

		private void ProcessRewards(IReward[] rewards)
		{
			if (rewards == null)
			{
				return;
			}
			_cashReward = 0;
			_silverReward = 0;
			_reputationReward = 0f;
			_researchPointsReward = 0f;
			_roomsUnlocked.Clear();
			_roomItemsUnlocked.Clear();
			_roomItemUpgradesUnlocked.Clear();
			foreach (IReward reward in rewards)
			{
				if (reward is RewardMoney)
				{
					_cashReward += ((RewardMoney)reward).Amount;
				}
				else if (reward is RewardSilver)
				{
					_silverReward += ((RewardSilver)reward).Amount;
				}
				else if (reward is RewardReputation)
				{
					_reputationReward += ((RewardReputation)reward).Amount;
				}
				else if (reward is RewardResearchPoints)
				{
					_researchPointsReward += ((RewardResearchPoints)reward).Points;
				}
				else if (reward is RewardRoom)
				{
					_roomsUnlocked.Add(((RewardRoom)reward).Definition);
				}
				else if (reward is RewardRoomItem)
				{
					_roomItemsUnlocked.Add(((RewardRoomItem)reward).Definition);
				}
				else if (reward is RewardRoomItemUpgrade)
				{
					_roomItemUpgradesUnlocked.Add(((RewardRoomItemUpgrade)reward).Definition);
				}
				else if (reward is RewardFinalReward)
				{
					_isFinalReward = true;
				}
				else if (reward is RewardSandboxMode)
				{
					_isSandboxReward = true;
				}
			}
		}
	}
}
