using TMPro;
using UnityEngine;

namespace TH20
{
	public class ChallengeNotificationUI : NotificationMessageUI
	{
		[SerializeField]
		private TMP_Text _rewardText;

		[SerializeField]
		private TMP_Text _scoreText;

		[SerializeField]
		private Color _rewardPositiveColor = new Color(0.75f, 1f, 0.75f);

		[SerializeField]
		private Color _rewardNegativeColor = new Color(1f, 0.75f, 0.75f);

		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			NotificationChallenge notificationChallenge = (NotificationChallenge)message;
			if (_messageText != null)
			{
				_messageText.text = notificationChallenge.GetMessageText();
			}
			string rewardsText = notificationChallenge.GetRewardsText();
			_rewardText.text = rewardsText;
			_rewardText.color = ((notificationChallenge.CompletionResult == Objective.CompletionType.Successful) ? _rewardPositiveColor : _rewardNegativeColor);
			GameObjectUtils.SetActive(_rewardText.gameObject, !rewardsText.IsNullOrEmpty());
			string scoreText = notificationChallenge.GetScoreText();
			_scoreText.text = scoreText;
			GameObjectUtils.SetActive(_scoreText.gameObject, !scoreText.IsNullOrEmpty());
		}
	}
}
