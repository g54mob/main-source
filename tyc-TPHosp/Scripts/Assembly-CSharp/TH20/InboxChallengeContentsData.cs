using System;
using TMPro;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class InboxChallengeContentsData
	{
		[SerializeField]
		private TMP_Text _messageText;

		[SerializeField]
		private TMP_Text _rewardText;

		[SerializeField]
		private TMP_Text _scoreText;

		public void Setup(NotificationChallenge message)
		{
			_messageText.text = message.GetMessageText().Replace("\\n", "\n");
			string rewardsText = message.GetRewardsText();
			_rewardText.text = rewardsText;
			GameObjectUtils.SetActive(_rewardText.gameObject, !rewardsText.IsNullOrEmpty());
			string scoreText = message.GetScoreText();
			_scoreText.text = scoreText;
			GameObjectUtils.SetActive(_scoreText.gameObject, !scoreText.IsNullOrEmpty());
		}
	}
}
