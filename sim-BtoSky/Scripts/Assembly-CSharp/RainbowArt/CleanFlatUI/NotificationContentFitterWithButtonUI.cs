using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class NotificationContentFitterWithButtonUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private NotificationContentFitterWithButton notification;

		private void Start()
		{
			notification.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			notification.OnFirst.RemoveAllListeners();
			notification.OnFirst.AddListener(NotificationFirst);
			notification.OnSecond.RemoveAllListeners();
			notification.OnSecond.AddListener(NotificationSecond);
			notification.OnThird.RemoveAllListeners();
			notification.OnThird.AddListener(NotificationThird);
			notification.OnCancel.RemoveAllListeners();
			notification.OnCancel.AddListener(NotificationCancel);
			notification.ShowNotification();
		}

		private void NotificationFirst()
		{
			Debug.Log("First Button Clicked");
		}

		private void NotificationSecond()
		{
			Debug.Log("Second Button Clicked");
		}

		private void NotificationThird()
		{
			Debug.Log("Third Button Clicked");
		}

		private void NotificationCancel()
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
