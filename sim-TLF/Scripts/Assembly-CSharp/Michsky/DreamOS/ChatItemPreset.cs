using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class ChatItemPreset : MonoBehaviour
	{
		public Image coverImage;

		public TextMeshProUGUI nameText;

		public TextMeshProUGUI latestMessage;

		public TextMeshProUGUI timeText;

		public GameObject onlineIndicator;

		public GameObject offlineIndicator;

		[SerializeField]
		private GameObject notificationBadge;

		public void EnableNotificationBadge(bool value)
		{
			if (!(notificationBadge == null))
			{
				if (value)
				{
					notificationBadge.SetActive(value: true);
				}
				else
				{
					notificationBadge.SetActive(value: false);
				}
			}
		}

		public void UpdateLatestMessage(string newText, string time)
		{
			latestMessage.text = newText;
			timeText.text = time;
		}

		public void ChangeStatus(MessagingManager.Status status)
		{
			switch (status)
			{
			case MessagingManager.Status.Offline:
				onlineIndicator.SetActive(value: false);
				offlineIndicator.SetActive(value: true);
				break;
			case MessagingManager.Status.Online:
				onlineIndicator.SetActive(value: true);
				offlineIndicator.SetActive(value: false);
				break;
			}
		}
	}
}
