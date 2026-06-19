using FullInspector;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class LevelObjectiveNotificationUI : NotificationMessageUI
	{
		[SerializeField]
		private TMP_Text _scoreText;

		[InspectorTooltip("Optional; parent of _scoreText, if _scoreText is nested. This is what gets disabled if the button needs to be hidden.")]
		[SerializeField]
		private Transform _scoreTransform;

		[SerializeField]
		private TMP_Text _rewardText;

		[InspectorTooltip("Optional; parent of _rewardText, if _rewardText is nested. This is what gets disabled if the button needs to be hidden.")]
		[SerializeField]
		private Transform _rewardTransform;

		[Tooltip("True to prefix the list of rewards with \"Reward\" or equivalent")]
		[SerializeField]
		private bool _addRewardPrefix = true;

		[Tooltip("True to include objective challenge information")]
		[SerializeField]
		private bool _includeChallengeInfo = true;

		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			NotificationObjectiveComplete notificationObjectiveComplete = (NotificationObjectiveComplete)message;
			string rewardText = notificationObjectiveComplete.GetRewardText(_addRewardPrefix, _includeChallengeInfo);
			if (_messageText != null)
			{
				_messageText.text = notificationObjectiveComplete.GetMessageText();
			}
			if (_scoreText != null)
			{
				string scoreText = notificationObjectiveComplete.GetScoreText();
				_scoreText.text = scoreText;
				if (_scoreTransform != null)
				{
					GameObjectUtils.SetActive(_scoreTransform.gameObject, scoreText != null);
				}
				else
				{
					GameObjectUtils.SetActive(_scoreText.gameObject, scoreText != null);
				}
			}
			if (_rewardText != null)
			{
				_rewardText.text = rewardText;
				if (_rewardTransform != null)
				{
					GameObjectUtils.SetActive(_rewardTransform.gameObject, rewardText != null);
				}
				else
				{
					GameObjectUtils.SetActive(_rewardText.gameObject, rewardText != null);
				}
			}
		}
	}
}
