using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeNotificationBox : MonoBehaviour
	{
		[Serializable]
		public struct ChallengeStatusImage
		{
			[SerializeField]
			public OnlineMetadata.ChallengeStatus ChallengeStatus;

			[SerializeField]
			public Sprite ChallengeStatusIcon;
		}

		[SerializeField]
		private GameObject _root;

		[SerializeField]
		private PlayerAvatar _avatar;

		[SerializeField]
		private TMP_Text _notificationText;

		[SerializeField]
		private TMP_Text _timeSinceText;

		[SerializeField]
		private UnseenNotificationsIcon _notificationIcon;

		[SerializeField]
		private Image _statusIcon;

		[SerializeField]
		private ChallengeStatusImage[] _challengeImages;

		private OnlineChallengeData _challengeData;

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

		public void Setup(OnlineChallengeData challengeData, bool hasSeen, int playerScore)
		{
			_challengeData = challengeData;
			if (challengeData == null)
			{
				GameObjectUtils.SetActive(_root, isActive: false);
				return;
			}
			GameObjectUtils.SetActive(_root, isActive: true);
			_avatar.PlayerID = challengeData.PlayerID;
			_notificationIcon.UnseenNotifications = ((!hasSeen) ? 1 : 0);
			RefreshTimeSince();
			int finalScore;
			bool isChallengeFinished = challengeData.HasFinishedChallenge(out finalScore);
			bool challengedMe = challengeData.PlayersList.Contains(OnlineManager.GetLocalPlayerID());
			_notificationText.text = GameStringUtils.GetFriendOnlineChallengeStatusText(challengeData.PlayerID, isChallengeFinished, playerScore, finalScore, challengedMe);
			OnlineMetadata.ChallengeStatus friendOnlineChallengeStatus = OnlineMetadata.GetFriendOnlineChallengeStatus(challengeData.PlayerID, isChallengeFinished, playerScore, finalScore, challengedMe);
			Sprite spriteForChallengeStatus = GetSpriteForChallengeStatus(friendOnlineChallengeStatus);
			if ((bool)_statusIcon)
			{
				_statusIcon.sprite = spriteForChallengeStatus;
			}
		}

		private void Update()
		{
			RefreshTimeSince();
		}

		private void RefreshTimeSince()
		{
			if (_challengeData != null)
			{
				_timeSinceText.text = StringUtils.FormatTimeSpan(OnlineManager.GetServerTime() - _challengeData.LastUpdateTime);
			}
		}
	}
}
