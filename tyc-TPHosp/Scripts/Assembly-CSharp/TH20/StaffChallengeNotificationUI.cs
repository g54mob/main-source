using TMPro;
using UnityEngine;

namespace TH20
{
	public class StaffChallengeNotificationUI : StaffNotificationUI
	{
		[SerializeField]
		private TMP_Text _challengeText;

		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			NotificationStaffChallenge notificationStaffChallenge = (NotificationStaffChallenge)message;
			SetStaff(notificationStaffChallenge.Challenge.Staff);
			if (_messageText != null)
			{
				_messageText.text = notificationStaffChallenge.GetFlavourText();
			}
			_challengeText.text = notificationStaffChallenge.GetChallengeText();
		}
	}
}
