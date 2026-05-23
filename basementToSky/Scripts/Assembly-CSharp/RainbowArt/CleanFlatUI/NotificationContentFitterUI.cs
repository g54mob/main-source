using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class NotificationContentFitterUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private NotificationContentFitter notification;

		private void Start()
		{
			notification.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		public void OnButtonClick()
		{
			notification.OnCancel.AddListener(NotificationCancel);
			notification.ShowNotification();
			notification.ShowNotification();
		}

		private void NotificationCancel()
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
